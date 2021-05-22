namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class CatchFallHelper : CustomHelper
    {
        public CatchFallHelper(Ped ped) : base(ped, "catchFall")
        {
        }

        public float TorsoStiffness
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
                base.SetArgument("torsoStiffness", value);
            }
        }

        public float LegsStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 4f)
                {
                    value = 4f;
                }
                base.SetArgument("legsStiffness", value);
            }
        }

        public float ArmsStiffness
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
                base.SetArgument("armsStiffness", value);
            }
        }

        public float BackwardsMinArmOffset
        {
            set
            {
                if (value > 0f)
                {
                    value = 0f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("backwardsMinArmOffset", value);
            }
        }

        public float ForwardMaxArmOffset
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
                base.SetArgument("forwardMaxArmOffset", value);
            }
        }

        public float ZAxisSpinReduction
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
                base.SetArgument("zAxisSpinReduction", value);
            }
        }

        public float ExtraSit
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
                base.SetArgument("extraSit", value);
            }
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

