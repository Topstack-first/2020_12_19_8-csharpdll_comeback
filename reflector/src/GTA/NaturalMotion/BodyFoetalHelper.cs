namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class BodyFoetalHelper : CustomHelper
    {
        public BodyFoetalHelper(Ped ped) : base(ped, "bodyFoetal")
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

        public float DampingFactor
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
                base.SetArgument("dampingFactor", value);
            }
        }

        public float Asymmetry
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
                base.SetArgument("asymmetry", value);
            }
        }

        public int RandomSeed
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("randomSeed", value);
            }
        }

        public float BackTwist
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
                base.SetArgument("backTwist", value);
            }
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

