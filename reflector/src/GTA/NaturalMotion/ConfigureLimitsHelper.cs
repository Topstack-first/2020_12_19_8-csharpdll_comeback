namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureLimitsHelper : CustomHelper
    {
        public ConfigureLimitsHelper(Ped ped) : base(ped, "configureLimits")
        {
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }

        public bool Enable
        {
            set => 
                base.SetArgument("enable", value);
        }

        public bool ToDesired
        {
            set => 
                base.SetArgument("toDesired", value);
        }

        public bool Restore
        {
            set => 
                base.SetArgument("restore", value);
        }

        public bool ToCurAnimation
        {
            set => 
                base.SetArgument("toCurAnimation", value);
        }

        public int Index
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("index", value);
            }
        }

        public float Lean1
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("lean1", value);
            }
        }

        public float Lean2
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("lean2", value);
            }
        }

        public float Twist
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("twist", value);
            }
        }

        public float Margin
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("margin", value);
            }
        }
    }
}

