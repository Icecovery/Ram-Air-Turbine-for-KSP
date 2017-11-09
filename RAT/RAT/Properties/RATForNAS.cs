using System;
using UnityEngine;

public class RATForNAS : PartModule
{
    [KSPField]
    private Transform RotateTransformA= null;
    private Transform RotateTransformB = null;
    private float rotateAngle;

    public string RotateTransformAName = "RotateTransform";
    public string RotateTransformBName = "RotateTransformB";

    public bool IsForwardRotation = true;

    public float rotateDPS = 30.0f;


    public override void OnStart(PartModule.StartState state)
    {
        RotateTransformA = base.part.FindModelTransform(RotateTransformAName);
        RotateTransformB = base.part.FindModelTransform(RotateTransformBName);
    }

    void FixedUpdate()
    {
        if (vessel.parts.Count == 1 && vessel.Splashed == true) 
        {
                    rotateAngle = rotateDPS * TimeWarp.fixedDeltaTime;
                    /*
                    if (IsForwardRotation == false)
                    {
                        rotateAngle = rotateAngle * -1;
                    }
                    */
                    RotateTransformA.Rotate(0, 0, rotateAngle);
                    if (RotateTransformB != null)
                    {
                        RotateTransformB.Rotate(0, 0, rotateAngle);
                    }       
        }
    }
}
