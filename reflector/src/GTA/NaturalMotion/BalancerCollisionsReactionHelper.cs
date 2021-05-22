namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class BalancerCollisionsReactionHelper : CustomHelper
    {
        public BalancerCollisionsReactionHelper(Ped ped) : base(ped, "balancerCollisionsReaction")
        {
        }

        public int NumStepsTillSlump
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("numStepsTillSlump", value);
            }
        }

        public float Stable2SlumpTime
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stable2SlumpTime", value);
            }
        }

        public float ExclusionZone
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("exclusionZone", value);
            }
        }

        public float FootFrictionMultStart
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
                base.SetArgument("footFrictionMultStart", value);
            }
        }

        public float FootFrictionMultRate
        {
            set
            {
                if (value > 50f)
                {
                    value = 50f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("footFrictionMultRate", value);
            }
        }

        public float BackFrictionMultStart
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
                base.SetArgument("backFrictionMultStart", value);
            }
        }

        public float BackFrictionMultRate
        {
            set
            {
                if (value > 50f)
                {
                    value = 50f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("backFrictionMultRate", value);
            }
        }

        public float ImpactLegStiffReduction
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
                base.SetArgument("impactLegStiffReduction", value);
            }
        }

        public float SlumpLegStiffReduction
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
                base.SetArgument("slumpLegStiffReduction", value);
            }
        }

        public float SlumpLegStiffRate
        {
            set
            {
                if (value > 50f)
                {
                    value = 50f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("slumpLegStiffRate", value);
            }
        }

        public float ReactTime
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
                base.SetArgument("reactTime", value);
            }
        }

        public float ImpactExagTime
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
                base.SetArgument("impactExagTime", value);
            }
        }

        public float GlanceSpinTime
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
                base.SetArgument("glanceSpinTime", value);
            }
        }

        public float GlanceSpinMag
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("glanceSpinMag", value);
            }
        }

        public float GlanceSpinDecayMult
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
                base.SetArgument("glanceSpinDecayMult", value);
            }
        }

        public int IgnoreColWithIndex
        {
            set
            {
                if (value < -2)
                {
                    value = -2;
                }
                base.SetArgument("ignoreColWithIndex", value);
            }
        }

        public int SlumpMode
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
                base.SetArgument("slumpMode", value);
            }
        }

        public int ReboundMode
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
                base.SetArgument("reboundMode", value);
            }
        }

        public float IgnoreColMassBelow
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
                base.SetArgument("ignoreColMassBelow", value);
            }
        }

        public int ForwardMode
        {
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("forwardMode", value);
            }
        }

        public float TimeToForward
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
                base.SetArgument("timeToForward", value);
            }
        }

        public float ReboundForce
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
                base.SetArgument("reboundForce", value);
            }
        }

        public bool BraceWall
        {
            set => 
                base.SetArgument("braceWall", value);
        }

        public float IgnoreColVolumeBelow
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
                base.SetArgument("ignoreColVolumeBelow", value);
            }
        }

        public bool FallOverWallDrape
        {
            set => 
                base.SetArgument("fallOverWallDrape", value);
        }

        public bool FallOverHighWalls
        {
            set => 
                base.SetArgument("fallOverHighWalls", value);
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

        public float ImpactWeaknessZeroDuration
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
                base.SetArgument("impactWeaknessZeroDuration", value);
            }
        }

        public float ImpactWeaknessRampDuration
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
                base.SetArgument("impactWeaknessRampDuration", value);
            }
        }

        public float ImpactLoosenessAmount
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
                base.SetArgument("impactLoosenessAmount", value);
            }
        }

        public bool ObjectBehindVictim
        {
            set => 
                base.SetArgument("objectBehindVictim", value);
        }

        public Vector3 ObjectBehindVictimPos
        {
            set => 
                base.SetArgument("objectBehindVictimPos", value);
        }

        public Vector3 ObjectBehindVictimNormal
        {
            set => 
                base.SetArgument("objectBehindVictimNormal", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }
    }
}

