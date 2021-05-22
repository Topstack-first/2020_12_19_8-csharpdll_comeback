namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class YankedHelper : CustomHelper
    {
        public YankedHelper(Ped ped) : base(ped, "yanked")
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
                if (value < 6f)
                {
                    value = 6f;
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
                if (value < 6f)
                {
                    value = 6f;
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

        public float PerStepReduction
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
                base.SetArgument("perStepReduction", value);
            }
        }

        public float HipPitchForward
        {
            set
            {
                if (value > 1.3f)
                {
                    value = 1.3f;
                }
                if (value < -1.3f)
                {
                    value = -1.3f;
                }
                base.SetArgument("hipPitchForward", value);
            }
        }

        public float HipPitchBack
        {
            set
            {
                if (value > 1.3f)
                {
                    value = 1.3f;
                }
                if (value < -1.3f)
                {
                    value = -1.3f;
                }
                base.SetArgument("hipPitchBack", value);
            }
        }

        public float SpineBend
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
                base.SetArgument("spineBend", value);
            }
        }

        public float FootFriction
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
                base.SetArgument("footFriction", value);
            }
        }

        public float TurnThresholdMin
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -0.1f)
                {
                    value = -0.1f;
                }
                base.SetArgument("turnThresholdMin", value);
            }
        }

        public float TurnThresholdMax
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -0.1f)
                {
                    value = -0.1f;
                }
                base.SetArgument("turnThresholdMax", value);
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

        public float ComVelRDSThresh
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("comVelRDSThresh", value);
            }
        }

        public float HulaPeriod
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
                base.SetArgument("hulaPeriod", value);
            }
        }

        public float HipAmplitude
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("hipAmplitude", value);
            }
        }

        public float SpineAmplitude
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spineAmplitude", value);
            }
        }

        public float MinRelaxPeriod
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
                base.SetArgument("minRelaxPeriod", value);
            }
        }

        public float MaxRelaxPeriod
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
                base.SetArgument("maxRelaxPeriod", value);
            }
        }

        public float RollHelp
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
                base.SetArgument("rollHelp", value);
            }
        }

        public float GroundLegStiffness
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
                base.SetArgument("groundLegStiffness", value);
            }
        }

        public float GroundArmStiffness
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
                base.SetArgument("groundArmStiffness", value);
            }
        }

        public float GroundSpineStiffness
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
                base.SetArgument("groundSpineStiffness", value);
            }
        }

        public float GroundLegDamping
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
                base.SetArgument("groundLegDamping", value);
            }
        }

        public float GroundArmDamping
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
                base.SetArgument("groundArmDamping", value);
            }
        }

        public float GroundSpineDamping
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
                base.SetArgument("groundSpineDamping", value);
            }
        }

        public float GroundFriction
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
                base.SetArgument("groundFriction", value);
            }
        }
    }
}

