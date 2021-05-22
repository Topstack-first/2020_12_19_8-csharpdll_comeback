namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class BodyRollUpHelper : CustomHelper
    {
        public BodyRollUpHelper(Ped ped) : base(ped, "bodyRollUp")
        {
        }

        public float Stiffness
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
                base.SetArgument("stiffness", value);
            }
        }

        public float UseArmToSlowDown
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("useArmToSlowDown", value);
            }
        }

        public float ArmReachAmount
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armReachAmount", value);
            }
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }

        public float LegPush
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("legPush", value);
            }
        }

        public float AsymmetricalLegs
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
                base.SetArgument("asymmetricalLegs", value);
            }
        }

        public float NoRollTimeBeforeSuccess
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
                base.SetArgument("noRollTimeBeforeSuccess", value);
            }
        }

        public float RollVelForSuccess
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
                base.SetArgument("rollVelForSuccess", value);
            }
        }

        public float RollVelLinearContribution
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
                base.SetArgument("rollVelLinearContribution", value);
            }
        }

        public float VelocityScale
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
                base.SetArgument("velocityScale", value);
            }
        }

        public float VelocityOffset
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
                base.SetArgument("velocityOffset", value);
            }
        }

        public bool ApplyMinMaxFriction
        {
            set => 
                base.SetArgument("applyMinMaxFriction", value);
        }
    }
}

