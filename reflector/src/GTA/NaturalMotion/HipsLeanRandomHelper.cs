namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class HipsLeanRandomHelper : CustomHelper
    {
        public HipsLeanRandomHelper(Ped ped) : base(ped, "hipsLeanRandom")
        {
        }

        public float LeanAmountMin
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
                base.SetArgument("leanAmountMin", value);
            }
        }

        public float LeanAmountMax
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
                base.SetArgument("leanAmountMax", value);
            }
        }

        public float ChangeTimeMin
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
                base.SetArgument("changeTimeMin", value);
            }
        }

        public float ChangeTimeMax
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
                base.SetArgument("changeTimeMax", value);
            }
        }
    }
}

