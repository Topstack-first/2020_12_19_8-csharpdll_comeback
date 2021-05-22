namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class StaggerFallHelper : CustomHelper
    {
        public StaggerFallHelper(Ped ped) : base(ped, "staggerFall")
        {
        }

        public float ArmStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armStiffness", value);
            }
        }

        public float ArmDamping
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armDamping", value);
            }
        }

        public float SpineDamping
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spineDamping", value);
            }
        }

        public float SpineStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spineStiffness", value);
            }
        }

        public float ArmStiffnessStart
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armStiffnessStart", value);
            }
        }

        public float ArmDampingStart
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armDampingStart", value);
            }
        }

        public float SpineDampingStart
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spineDampingStart", value);
            }
        }

        public float SpineStiffnessStart
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spineStiffnessStart", value);
            }
        }

        public float TimeAtStartValues
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("timeAtStartValues", value);
            }
        }

        public float RampTimeFromStartValues
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rampTimeFromStartValues", value);
            }
        }

        public float StaggerStepProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("staggerStepProb", value);
            }
        }

        public int StepsTillStartEnd
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("stepsTillStartEnd", value);
            }
        }

        public float TimeStartEnd
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("timeStartEnd", value);
            }
        }

        public float RampTimeToEndValues
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rampTimeToEndValues", value);
            }
        }

        public float LowerBodyStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("lowerBodyStiffness", value);
            }
        }

        public float LowerBodyStiffnessEnd
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("lowerBodyStiffnessEnd", value);
            }
        }

        public float PredictionTime
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("predictionTime", value);
            }
        }

        public float PerStepReduction1
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("perStepReduction1", value);
            }
        }

        public float LeanInDirRate
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanInDirRate", value);
            }
        }

        public float LeanInDirMaxF
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanInDirMaxF", value);
            }
        }

        public float LeanInDirMaxB
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanInDirMaxB", value);
            }
        }

        public float LeanHipsMaxF
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanHipsMaxF", value);
            }
        }

        public float LeanHipsMaxB
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanHipsMaxB", value);
            }
        }

        public float Lean2multF
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < -5f)
                {
                    value = -5f;
                }
                base.SetArgument("lean2multF", value);
            }
        }

        public float Lean2multB
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < -5f)
                {
                    value = -5f;
                }
                base.SetArgument("lean2multB", value);
            }
        }

        public float PushOffDist
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("pushOffDist", value);
            }
        }

        public float MaxPushoffVel
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < -20f)
                {
                    value = -20f;
                }
                base.SetArgument("maxPushoffVel", value);
            }
        }

        public float HipBendMult
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("hipBendMult", value);
            }
        }

        public bool AlwaysBendForwards
        {
            set => 
                base.SetArgument("alwaysBendForwards", value);
        }

        public float SpineBendMult
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("spineBendMult", value);
            }
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public Vector3 HeadLookPos
        {
            set => 
                base.SetArgument("headLookPos", value);
        }

        public int HeadLookInstanceIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("headLookInstanceIndex", value);
            }
        }

        public float HeadLookAtVelProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("headLookAtVelProb", value);
            }
        }

        public float TurnOffProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turnOffProb", value);
            }
        }

        public float Turn2TargetProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turn2TargetProb", value);
            }
        }

        public float Turn2VelProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turn2VelProb", value);
            }
        }

        public float TurnAwayProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turnAwayProb", value);
            }
        }

        public float TurnLeftProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turnLeftProb", value);
            }
        }

        public float TurnRightProb
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("turnRightProb", value);
            }
        }

        public bool UseBodyTurn
        {
            set => 
                base.SetArgument("useBodyTurn", value);
        }

        public bool UpperBodyReaction
        {
            set => 
                base.SetArgument("upperBodyReaction", value);
        }
    }
}

