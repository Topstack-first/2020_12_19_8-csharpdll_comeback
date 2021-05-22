namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotConfigureArmsHelper : CustomHelper
    {
        public ShotConfigureArmsHelper(Ped ped) : base(ped, "shotConfigureArms")
        {
        }

        public bool Brace
        {
            set => 
                base.SetArgument("brace", value);
        }

        public bool PointGun
        {
            set => 
                base.SetArgument("pointGun", value);
        }

        public bool UseArmsWindmill
        {
            set => 
                base.SetArgument("useArmsWindmill", value);
        }

        public int ReleaseWound
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
                base.SetArgument("releaseWound", value);
            }
        }

        public int ReachFalling
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
                base.SetArgument("reachFalling", value);
            }
        }

        public int ReachFallingWithOneHand
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("reachFallingWithOneHand", value);
            }
        }

        public int ReachOnFloor
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
                base.SetArgument("reachOnFloor", value);
            }
        }

        public float AlwaysReachTime
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
                base.SetArgument("alwaysReachTime", value);
            }
        }

        public float AWSpeedMult
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
                base.SetArgument("AWSpeedMult", value);
            }
        }

        public float AWRadiusMult
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
                base.SetArgument("AWRadiusMult", value);
            }
        }

        public float AWStiffnessAdd
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("AWStiffnessAdd", value);
            }
        }

        public int ReachWithOneHand
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
                base.SetArgument("reachWithOneHand", value);
            }
        }

        public bool AllowLeftPistolRFW
        {
            set => 
                base.SetArgument("allowLeftPistolRFW", value);
        }

        public bool AllowRightPistolRFW
        {
            set => 
                base.SetArgument("allowRightPistolRFW", value);
        }

        public bool RfwWithPistol
        {
            set => 
                base.SetArgument("rfwWithPistol", value);
        }

        public bool Fling2
        {
            set => 
                base.SetArgument("fling2", value);
        }

        public bool Fling2Left
        {
            set => 
                base.SetArgument("fling2Left", value);
        }

        public bool Fling2Right
        {
            set => 
                base.SetArgument("fling2Right", value);
        }

        public bool Fling2OverrideStagger
        {
            set => 
                base.SetArgument("fling2OverrideStagger", value);
        }

        public float Fling2TimeBefore
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
                base.SetArgument("fling2TimeBefore", value);
            }
        }

        public float Fling2Time
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
                base.SetArgument("fling2Time", value);
            }
        }

        public float Fling2MStiffL
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("fling2MStiffL", value);
            }
        }

        public float Fling2MStiffR
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("fling2MStiffR", value);
            }
        }

        public float Fling2RelaxTimeL
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
                base.SetArgument("fling2RelaxTimeL", value);
            }
        }

        public float Fling2RelaxTimeR
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
                base.SetArgument("fling2RelaxTimeR", value);
            }
        }

        public float Fling2AngleMinL
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1.5f)
                {
                    value = -1.5f;
                }
                base.SetArgument("fling2AngleMinL", value);
            }
        }

        public float Fling2AngleMaxL
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1.5f)
                {
                    value = -1.5f;
                }
                base.SetArgument("fling2AngleMaxL", value);
            }
        }

        public float Fling2AngleMinR
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1.5f)
                {
                    value = -1.5f;
                }
                base.SetArgument("fling2AngleMinR", value);
            }
        }

        public float Fling2AngleMaxR
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1.5f)
                {
                    value = -1.5f;
                }
                base.SetArgument("fling2AngleMaxR", value);
            }
        }

        public float Fling2LengthMinL
        {
            set
            {
                if (value > 0.6f)
                {
                    value = 0.6f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("fling2LengthMinL", value);
            }
        }

        public float Fling2LengthMaxL
        {
            set
            {
                if (value > 0.6f)
                {
                    value = 0.6f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("fling2LengthMaxL", value);
            }
        }

        public float Fling2LengthMinR
        {
            set
            {
                if (value > 0.6f)
                {
                    value = 0.6f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("fling2LengthMinR", value);
            }
        }

        public float Fling2LengthMaxR
        {
            set
            {
                if (value > 0.6f)
                {
                    value = 0.6f;
                }
                if (value < 0.3f)
                {
                    value = 0.3f;
                }
                base.SetArgument("fling2LengthMaxR", value);
            }
        }

        public bool Bust
        {
            set => 
                base.SetArgument("bust", value);
        }

        public float BustElbowLift
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
                base.SetArgument("bustElbowLift", value);
            }
        }

        public float CupSize
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
                base.SetArgument("cupSize", value);
            }
        }

        public bool CupBust
        {
            set => 
                base.SetArgument("cupBust", value);
        }
    }
}

