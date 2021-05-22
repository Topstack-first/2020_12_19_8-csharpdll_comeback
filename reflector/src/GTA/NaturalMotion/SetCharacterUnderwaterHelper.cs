namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetCharacterUnderwaterHelper : CustomHelper
    {
        public SetCharacterUnderwaterHelper(Ped ped) : base(ped, "setCharacterUnderwater")
        {
        }

        public bool Underwater
        {
            set => 
                base.SetArgument("underwater", value);
        }

        public float Viscosity
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("viscosity", value);
            }
        }

        public float GravityFactor
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
                base.SetArgument("gravityFactor", value);
            }
        }

        public float Stroke
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1000f)
                {
                    value = -1000f;
                }
                base.SetArgument("stroke", value);
            }
        }

        public bool LinearStroke
        {
            set => 
                base.SetArgument("linearStroke", value);
        }
    }
}

