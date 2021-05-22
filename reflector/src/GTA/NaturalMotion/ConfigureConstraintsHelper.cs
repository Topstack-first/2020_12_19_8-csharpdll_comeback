namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureConstraintsHelper : CustomHelper
    {
        public ConfigureConstraintsHelper(Ped ped) : base(ped, "configureConstraints")
        {
        }

        public bool HandCuffs
        {
            set => 
                base.SetArgument("handCuffs", value);
        }

        public bool HandCuffsBehindBack
        {
            set => 
                base.SetArgument("handCuffsBehindBack", value);
        }

        public bool LegCuffs
        {
            set => 
                base.SetArgument("legCuffs", value);
        }

        public bool RightDominant
        {
            set => 
                base.SetArgument("rightDominant", value);
        }

        public int PassiveMode
        {
            set
            {
                if (value > 5)
                {
                    value = 5;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("passiveMode", value);
            }
        }

        public bool BespokeBehaviour
        {
            set => 
                base.SetArgument("bespokeBehaviour", value);
        }

        public float Blend2ZeroPose
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
                base.SetArgument("blend2ZeroPose", value);
            }
        }
    }
}

