namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class StayUprightHelper : CustomHelper
    {
        public StayUprightHelper(Ped ped) : base(ped, "stayUpright")
        {
        }

        public bool UseForces
        {
            set => 
                base.SetArgument("useForces", value);
        }

        public bool UseTorques
        {
            set => 
                base.SetArgument("useTorques", value);
        }

        public bool LastStandMode
        {
            set => 
                base.SetArgument("lastStandMode", value);
        }

        public float LastStandSinkRate
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
                base.SetArgument("lastStandSinkRate", value);
            }
        }

        public float LastStandHorizDamping
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
                base.SetArgument("lastStandHorizDamping", value);
            }
        }

        public float LastStandMaxTime
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("lastStandMaxTime", value);
            }
        }

        public bool TurnTowardsBullets
        {
            set => 
                base.SetArgument("turnTowardsBullets", value);
        }

        public bool VelocityBased
        {
            set => 
                base.SetArgument("velocityBased", value);
        }

        public bool TorqueOnlyInAir
        {
            set => 
                base.SetArgument("torqueOnlyInAir", value);
        }

        public float ForceStrength
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
                base.SetArgument("forceStrength", value);
            }
        }

        public float ForceDamping
        {
            set
            {
                if (value > 50f)
                {
                    value = 50f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("forceDamping", value);
            }
        }

        public float ForceFeetMult
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
                base.SetArgument("forceFeetMult", value);
            }
        }

        public float ForceSpine3Share
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
                base.SetArgument("forceSpine3Share", value);
            }
        }

        public float ForceLeanReduction
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
                base.SetArgument("forceLeanReduction", value);
            }
        }

        public float ForceInAirShare
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
                base.SetArgument("forceInAirShare", value);
            }
        }

        public float ForceMin
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("forceMin", value);
            }
        }

        public float ForceMax
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("forceMax", value);
            }
        }

        public float ForceSaturationVel
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("forceSaturationVel", value);
            }
        }

        public float ForceThresholdVel
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("forceThresholdVel", value);
            }
        }

        public float TorqueStrength
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
                base.SetArgument("torqueStrength", value);
            }
        }

        public float TorqueDamping
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
                base.SetArgument("torqueDamping", value);
            }
        }

        public float TorqueSaturationVel
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("torqueSaturationVel", value);
            }
        }

        public float TorqueThresholdVel
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("torqueThresholdVel", value);
            }
        }

        public float SupportPosition
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("supportPosition", value);
            }
        }

        public float NoSupportForceMult
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
                base.SetArgument("noSupportForceMult", value);
            }
        }

        public float StepUpHelp
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
                base.SetArgument("stepUpHelp", value);
            }
        }

        public float StayUpAcc
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
                base.SetArgument("stayUpAcc", value);
            }
        }

        public float StayUpAccMax
        {
            set
            {
                if (value > 15f)
                {
                    value = 15f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stayUpAccMax", value);
            }
        }
    }
}

