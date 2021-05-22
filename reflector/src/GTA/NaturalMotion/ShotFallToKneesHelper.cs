namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotFallToKneesHelper : CustomHelper
    {
        public ShotFallToKneesHelper(Ped ped) : base(ped, "shotFallToKnees")
        {
        }

        public bool FallToKnees
        {
            set => 
                base.SetArgument("fallToKnees", value);
        }

        public bool FtkAlwaysChangeFall
        {
            set => 
                base.SetArgument("ftkAlwaysChangeFall", value);
        }

        public float FtkBalanceTime
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
                base.SetArgument("ftkBalanceTime", value);
            }
        }

        public float FtkHelperForce
        {
            set
            {
                if (value > 2000f)
                {
                    value = 2000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("ftkHelperForce", value);
            }
        }

        public bool FtkHelperForceOnSpine
        {
            set => 
                base.SetArgument("ftkHelperForceOnSpine", value);
        }

        public float FtkLeanHelp
        {
            set
            {
                if (value > 0.3f)
                {
                    value = 0.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("ftkLeanHelp", value);
            }
        }

        public float FtkSpineBend
        {
            set
            {
                if (value > 0.3f)
                {
                    value = 0.3f;
                }
                if (value < -0.2f)
                {
                    value = -0.2f;
                }
                base.SetArgument("ftkSpineBend", value);
            }
        }

        public bool FtkStiffSpine
        {
            set => 
                base.SetArgument("ftkStiffSpine", value);
        }

        public float FtkImpactLooseness
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
                base.SetArgument("ftkImpactLooseness", value);
            }
        }

        public float FtkImpactLoosenessTime
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -0.1f)
                {
                    value = -0.1f;
                }
                base.SetArgument("ftkImpactLoosenessTime", value);
            }
        }

        public float FtkBendRate
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("ftkBendRate", value);
            }
        }

        public float FtkHipBlend
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
                base.SetArgument("ftkHipBlend", value);
            }
        }

        public float FtkLungeProb
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
                base.SetArgument("ftkLungeProb", value);
            }
        }

        public bool FtkKneeSpin
        {
            set => 
                base.SetArgument("ftkKneeSpin", value);
        }

        public float FtkFricMult
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
                base.SetArgument("ftkFricMult", value);
            }
        }

        public float FtkHipAngleFall
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("ftkHipAngleFall", value);
            }
        }

        public float FtkPitchForwards
        {
            set
            {
                if (value > 0.5f)
                {
                    value = 0.5f;
                }
                if (value < -0.5f)
                {
                    value = -0.5f;
                }
                base.SetArgument("ftkPitchForwards", value);
            }
        }

        public float FtkPitchBackwards
        {
            set
            {
                if (value > 0.5f)
                {
                    value = 0.5f;
                }
                if (value < -0.5f)
                {
                    value = -0.5f;
                }
                base.SetArgument("ftkPitchBackwards", value);
            }
        }

        public float FtkFallBelowStab
        {
            set
            {
                if (value > 15f)
                {
                    value = 15f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("ftkFallBelowStab", value);
            }
        }

        public float FtkBalanceAbortThreshold
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("ftkBalanceAbortThreshold", value);
            }
        }

        public int FtkOnKneesArmType
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
                base.SetArgument("ftkOnKneesArmType", value);
            }
        }

        public float FtkReleaseReachForWound
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("ftkReleaseReachForWound", value);
            }
        }

        public bool FtkReachForWound
        {
            set => 
                base.SetArgument("ftkReachForWound", value);
        }

        public bool FtkReleasePointGun
        {
            set => 
                base.SetArgument("ftkReleasePointGun", value);
        }

        public bool FtkFailMustCollide
        {
            set => 
                base.SetArgument("ftkFailMustCollide", value);
        }
    }
}

