namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class HighFallHelper : CustomHelper
    {
        public HighFallHelper(Ped ped) : base(ped, "highFall")
        {
        }

        public float BodyStiffness
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
                base.SetArgument("bodyStiffness", value);
            }
        }

        public float Bodydamping
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("bodydamping", value);
            }
        }

        public float Catchfalltime
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
                base.SetArgument("catchfalltime", value);
            }
        }

        public float CrashOrLandCutOff
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
                base.SetArgument("crashOrLandCutOff", value);
            }
        }

        public float PdStrength
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
                base.SetArgument("pdStrength", value);
            }
        }

        public float PdDamping
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
                base.SetArgument("pdDamping", value);
            }
        }

        public float ArmAngSpeed
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
                base.SetArgument("armAngSpeed", value);
            }
        }

        public float ArmAmplitude
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
                base.SetArgument("armAmplitude", value);
            }
        }

        public float ArmPhase
        {
            set
            {
                if (value > 6.3f)
                {
                    value = 6.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armPhase", value);
            }
        }

        public bool ArmBendElbows
        {
            set => 
                base.SetArgument("armBendElbows", value);
        }

        public float LegRadius
        {
            set
            {
                if (value > 0.5f)
                {
                    value = 0.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legRadius", value);
            }
        }

        public float LegAngSpeed
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
                base.SetArgument("legAngSpeed", value);
            }
        }

        public float LegAsymmetry
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
                base.SetArgument("legAsymmetry", value);
            }
        }

        public float Arms2LegsPhase
        {
            set
            {
                if (value > 6.5f)
                {
                    value = 6.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("arms2LegsPhase", value);
            }
        }

        public Synchroisation Arms2LegsSync
        {
            set => 
                base.SetArgument("arms2LegsSync", (int) value);
        }

        public float ArmsUp
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -4f)
                {
                    value = -4f;
                }
                base.SetArgument("armsUp", value);
            }
        }

        public bool OrientateBodyToFallDirection
        {
            set => 
                base.SetArgument("orientateBodyToFallDirection", value);
        }

        public bool OrientateTwist
        {
            set => 
                base.SetArgument("orientateTwist", value);
        }

        public float OrientateMax
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
                base.SetArgument("orientateMax", value);
            }
        }

        public bool AlanRickman
        {
            set => 
                base.SetArgument("alanRickman", value);
        }

        public bool FowardRoll
        {
            set => 
                base.SetArgument("fowardRoll", value);
        }

        public bool UseZeroPose_withFowardRoll
        {
            set => 
                base.SetArgument("useZeroPose_withFowardRoll", value);
        }

        public float AimAngleBase
        {
            set
            {
                if (value > 3.1f)
                {
                    value = 3.1f;
                }
                if (value < -3.1f)
                {
                    value = -3.1f;
                }
                base.SetArgument("aimAngleBase", value);
            }
        }

        public float FowardVelRotation
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
                base.SetArgument("fowardVelRotation", value);
            }
        }

        public float FootVelCompScale
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
                base.SetArgument("footVelCompScale", value);
            }
        }

        public float SideD
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
                base.SetArgument("sideD", value);
            }
        }

        public float FowardOffsetOfLegIK
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
                base.SetArgument("fowardOffsetOfLegIK", value);
            }
        }

        public float LegL
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
                base.SetArgument("legL", value);
            }
        }

        public float CatchFallCutOff
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
                base.SetArgument("catchFallCutOff", value);
            }
        }

        public float LegStrength
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
                base.SetArgument("legStrength", value);
            }
        }

        public bool Balance
        {
            set => 
                base.SetArgument("balance", value);
        }

        public bool IgnorWorldCollisions
        {
            set => 
                base.SetArgument("ignorWorldCollisions", value);
        }

        public bool AdaptiveCircling
        {
            set => 
                base.SetArgument("adaptiveCircling", value);
        }

        public bool Hula
        {
            set => 
                base.SetArgument("hula", value);
        }

        public float MaxSpeedForRecoverableFall
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
                base.SetArgument("maxSpeedForRecoverableFall", value);
            }
        }

        public float MinSpeedForBrace
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
                base.SetArgument("minSpeedForBrace", value);
            }
        }

        public float LandingNormal
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
                base.SetArgument("landingNormal", value);
            }
        }
    }
}

