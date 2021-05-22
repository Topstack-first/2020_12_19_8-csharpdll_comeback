namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetFrictionScaleHelper : CustomHelper
    {
        public SetFrictionScaleHelper(Ped ped) : base(ped, "setFrictionScale")
        {
        }

        public float Scale
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
                base.SetArgument("scale", value);
            }
        }

        public float GlobalMin
        {
            set
            {
                if (value > 1000000f)
                {
                    value = 1000000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("globalMin", value);
            }
        }

        public float GlobalMax
        {
            set
            {
                if (value > 1000000f)
                {
                    value = 1000000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("globalMax", value);
            }
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

