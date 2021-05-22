namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class PointGunExtraHelper : CustomHelper
    {
        public PointGunExtraHelper(Ped ped) : base(ped, "pointGunExtra")
        {
        }

        public float ConstraintStrength
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("constraintStrength", value);
            }
        }

        public float ConstraintThresh
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
                base.SetArgument("constraintThresh", value);
            }
        }

        public int WeaponMask
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("weaponMask", value);
            }
        }

        public bool TimeWarpActive
        {
            set => 
                base.SetArgument("timeWarpActive", value);
        }

        public float TimeWarpStrengthScale
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("timeWarpStrengthScale", value);
            }
        }

        public float OriStiff
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("oriStiff", value);
            }
        }

        public float OriDamp
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
                base.SetArgument("oriDamp", value);
            }
        }

        public float PosStiff
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("posStiff", value);
            }
        }

        public float PosDamp
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
                base.SetArgument("posDamp", value);
            }
        }
    }
}

