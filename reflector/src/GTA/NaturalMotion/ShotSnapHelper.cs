namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotSnapHelper : CustomHelper
    {
        public ShotSnapHelper(Ped ped) : base(ped, "shotSnap")
        {
        }

        public bool Snap
        {
            set => 
                base.SetArgument("snap", value);
        }

        public float SnapMag
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
                base.SetArgument("snapMag", value);
            }
        }

        public float SnapMovingMult
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
                base.SetArgument("snapMovingMult", value);
            }
        }

        public float SnapBalancingMult
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
                base.SetArgument("snapBalancingMult", value);
            }
        }

        public float SnapAirborneMult
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
                base.SetArgument("snapAirborneMult", value);
            }
        }

        public float SnapMovingThresh
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
                base.SetArgument("snapMovingThresh", value);
            }
        }

        public float SnapDirectionRandomness
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
                base.SetArgument("snapDirectionRandomness", value);
            }
        }

        public bool SnapLeftArm
        {
            set => 
                base.SetArgument("snapLeftArm", value);
        }

        public bool SnapRightArm
        {
            set => 
                base.SetArgument("snapRightArm", value);
        }

        public bool SnapLeftLeg
        {
            set => 
                base.SetArgument("snapLeftLeg", value);
        }

        public bool SnapRightLeg
        {
            set => 
                base.SetArgument("snapRightLeg", value);
        }

        public bool SnapSpine
        {
            set => 
                base.SetArgument("snapSpine", value);
        }

        public bool SnapNeck
        {
            set => 
                base.SetArgument("snapNeck", value);
        }

        public bool SnapPhasedLegs
        {
            set => 
                base.SetArgument("snapPhasedLegs", value);
        }

        public int SnapHipType
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("snapHipType", value);
            }
        }

        public bool SnapUseBulletDir
        {
            set => 
                base.SetArgument("snapUseBulletDir", value);
        }

        public bool SnapHitPart
        {
            set => 
                base.SetArgument("snapHitPart", value);
        }

        public float UnSnapInterval
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
                base.SetArgument("unSnapInterval", value);
            }
        }

        public float UnSnapRatio
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
                base.SetArgument("unSnapRatio", value);
            }
        }

        public bool SnapUseTorques
        {
            set => 
                base.SetArgument("snapUseTorques", value);
        }
    }
}

