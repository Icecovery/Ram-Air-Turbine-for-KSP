using System;
using UnityEngine;

public class RATForNAS : PartModule
{
    [KSPField]
    private Transform RotateTransform= null;
    private float rotateAngle;

    public string RotateTransformAName = "RotateTransform";

    public bool IsForwardRotation = true;

    public float rotateDPS = 30.0f;


    public override void OnStart(PartModule.StartState state)
    {
        RotateTransform = base.part.FindModelTransform(RotateTransformAName);
    }

    void FixedUpdate()
    {
        if (vessel.parts.Count == 1 && vessel.Splashed == true) 
        {
                    rotateAngle = rotateDPS * TimeWarp.fixedDeltaTime;
                    if (IsForwardRotation == false)
                    {
                        rotateAngle = rotateAngle * -1;
                    }
                    RotateTransform.Rotate(0, 0, rotateAngle);
        }
    }
}
