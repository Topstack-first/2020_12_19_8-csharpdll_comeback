namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotHelper : CustomHelper
    {
        public ShotHelper(Ped ped) : base(ped, "shot")
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

        public float SpineDamping
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
                base.SetArgument("spineDamping", value);
            }
        }

        public float ArmStiffness
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
                base.SetArgument("armStiffness", value);
            }
        }

        public float InitialNeckStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 3f)
                {
                    value = 3f;
                }
                base.SetArgument("initialNeckStiffness", value);
            }
        }

        public float InitialNeckDamping
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("initialNeckDamping", value);
            }
        }

        public float NeckStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 3f)
                {
                    value = 3f;
                }
                base.SetArgument("neckStiffness", value);
            }
        }

        public float NeckDamping
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
                base.SetArgument("neckDamping", value);
            }
        }

        public float KMultOnLoose
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
                base.SetArgument("kMultOnLoose", value);
            }
        }

        public float KMult4Legs
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
                base.SetArgument("kMult4Legs", value);
            }
        }

        public float LoosenessAmount
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
                base.SetArgument("loosenessAmount", value);
            }
        }

        public float Looseness4Fall
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
                base.SetArgument("looseness4Fall", value);
            }
        }

        public float Looseness4Stagger
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
                base.SetArgument("looseness4Stagger", value);
            }
        }

        public float MinArmsLooseness
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
                base.SetArgument("minArmsLooseness", value);
            }
        }

        public float MinLegsLooseness
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
                base.SetArgument("minLegsLooseness", value);
            }
        }

        public float GrabHoldTime
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
                base.SetArgument("grabHoldTime", value);
            }
        }

        public bool SpineBlendExagCPain
        {
            set => 
                base.SetArgument("spineBlendExagCPain", value);
        }

        public float SpineBlendZero
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
                base.SetArgument("spineBlendZero", value);
            }
        }

        public bool BulletProofVest
        {
            set => 
                base.SetArgument("bulletProofVest", value);
        }

        public bool AlwaysResetLooseness
        {
            set => 
                base.SetArgument("alwaysResetLooseness", value);
        }

        public bool AlwaysResetNeckLooseness
        {
            set => 
                base.SetArgument("alwaysResetNeckLooseness", value);
        }

        public float AngVelScale
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
                base.SetArgument("angVelScale", value);
            }
        }

        public string AngVelScaleMask
        {
            set => 
                base.SetArgument("angVelScaleMask", value);
        }

        public float FlingWidth
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
                base.SetArgument("flingWidth", value);
            }
        }

        public float FlingTime
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
                base.SetArgument("flingTime", value);
            }
        }

        public float TimeBeforeReachForWound
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
                base.SetArgument("timeBeforeReachForWound", value);
            }
        }

        public float ExagDuration
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
                base.SetArgument("exagDuration", value);
            }
        }

        public float ExagMag
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
                base.SetArgument("exagMag", value);
            }
        }

        public float ExagTwistMag
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
                base.SetArgument("exagTwistMag", value);
            }
        }

        public float ExagSmooth2Zero
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
                base.SetArgument("exagSmooth2Zero", value);
            }
        }

        public float ExagZeroTime
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
                base.SetArgument("exagZeroTime", value);
            }
        }

        public float CpainSmooth2Time
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
                base.SetArgument("cpainSmooth2Time", value);
            }
        }

        public float CpainDuration
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
                base.SetArgument("cpainDuration", value);
            }
        }

        public float CpainMag
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
                base.SetArgument("cpainMag", value);
            }
        }

        public float CpainTwistMag
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
                base.SetArgument("cpainTwistMag", value);
            }
        }

        public float CpainSmooth2Zero
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
                base.SetArgument("cpainSmooth2Zero", value);
            }
        }

        public bool Crouching
        {
            set => 
                base.SetArgument("crouching", value);
        }

        public bool ChickenArms
        {
            set => 
                base.SetArgument("chickenArms", value);
        }

        public bool ReachForWound
        {
            set => 
                base.SetArgument("reachForWound", value);
        }

        public bool Fling
        {
            set => 
                base.SetArgument("fling", value);
        }

        public bool AllowInjuredArm
        {
            set => 
                base.SetArgument("allowInjuredArm", value);
        }

        public bool AllowInjuredLeg
        {
            set => 
                base.SetArgument("allowInjuredLeg", value);
        }

        public bool AllowInjuredLowerLegReach
        {
            set => 
                base.SetArgument("allowInjuredLowerLegReach", value);
        }

        public bool AllowInjuredThighReach
        {
            set => 
                base.SetArgument("allowInjuredThighReach", value);
        }

        public bool StableHandsAndNeck
        {
            set => 
                base.SetArgument("stableHandsAndNeck", value);
        }

        public bool Melee
        {
            set => 
                base.SetArgument("melee", value);
        }

        public int FallingReaction
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
                base.SetArgument("fallingReaction", value);
            }
        }

        public bool UseExtendedCatchFall
        {
            set => 
                base.SetArgument("useExtendedCatchFall", value);
        }

        public float InitialWeaknessZeroDuration
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
                base.SetArgument("initialWeaknessZeroDuration", value);
            }
        }

        public float InitialWeaknessRampDuration
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
                base.SetArgument("initialWeaknessRampDuration", value);
            }
        }

        public float InitialNeckDuration
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
                base.SetArgument("initialNeckDuration", value);
            }
        }

        public float InitialNeckRampDuration
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
                base.SetArgument("initialNeckRampDuration", value);
            }
        }

        public bool UseCStrModulation
        {
            set => 
                base.SetArgument("useCStrModulation", value);
        }

        public float CStrUpperMin
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("cStrUpperMin", value);
            }
        }

        public float CStrUpperMax
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("cStrUpperMax", value);
            }
        }

        public float CStrLowerMin
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("cStrLowerMin", value);
            }
        }

        public float CStrLowerMax
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("cStrLowerMax", value);
            }
        }

        public float DeathTime
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("deathTime", value);
            }
        }
    }
}

