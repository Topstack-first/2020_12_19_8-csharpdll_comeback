namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ForceLeanRandomHelper : CustomHelper
    {
        public ForceLeanRandomHelper(Ped ped) : base(ped, "forceLeanRandom")
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

        public int BodyPart
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("bodyPart", value);
            }
        }
    }
}

