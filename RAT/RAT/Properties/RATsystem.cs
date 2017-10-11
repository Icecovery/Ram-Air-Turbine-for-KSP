using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RATsystem : PartModule
{
    [KSPField]
    private Transform RotateTransform = null;
    private double dynPre;
    private double minDynPre;
    private double generatePower;
    private float rotateAngle;

    public string resourceName = "ElectricCharge";
    public string RotateTransformName = "RotateTransform";

    public float rotateDPS = 30.0f;

    public bool IsForwardRotation = true;

    public double minAtmDen = 0.05;
    public double minSpeed = 10.0;
    public double generateKey = 1.0;
    public double maxGenerateValue = 30.0;

    public override void OnStart(PartModule.StartState state)
    {
        RotateTransform = base.part.FindModelTransform(RotateTransformName);
        minDynPre = (0.5 * minAtmDen * (minSpeed * minSpeed)) / 1000;
    }

    void FixedUpdate()
    {
        if (1==1) //<---How hard it is???
        {
            dynPre = this.part.dynamicPressurekPa;
            if (dynPre >= minDynPre) 
            {
                
                generatePower = dynPre * generateKey;
                if (generatePower > maxGenerateValue)
                {
                    generatePower = maxGenerateValue;
                }
                generatePower = generatePower * TimeWarp.fixedDeltaTime * -1;
                this.part.RequestResource(resourceName, generatePower);
                rotateAngle = (float)dynPre * rotateDPS * TimeWarp.fixedDeltaTime;
                if (IsForwardRotation == false)
                {
                    rotateAngle = rotateAngle * -1;
                }
                RotateTransform.Rotate(0, 0, rotateAngle);
            }
        }
    }
}

