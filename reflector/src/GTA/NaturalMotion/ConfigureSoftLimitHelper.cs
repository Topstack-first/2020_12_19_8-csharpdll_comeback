namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureSoftLimitHelper : CustomHelper
    {
        public ConfigureSoftLimitHelper(Ped ped) : base(ped, "configureSoftLimit")
        {
        }

        public int Index
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("index", value);
            }
        }

        public float Stiffness
        {
            set
            {
                if (value > 30f)
                {
                    value = 30f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stiffness", value);
            }
        }

        public float Damping
        {
            set
            {
                if (value > 1.1f)
                {
                    value = 1.1f;
                }
                if (value < 0.9f)
                {
                    value = 0.9f;
                }
                base.SetArgument("damping", value);
            }
        }

        public float LimitAngle
        {
            set
            {
                if (value > 6.3f)
                {
                    value = 6.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("limitAngle", value);
            }
        }

        public int ApproachDirection
        {
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("approachDirection", value);
            }
        }

        public bool VelocityScaled
        {
            set => 
                base.SetArgument("velocityScaled", value);
        }
    }
}

