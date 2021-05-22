namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class FallOverWallHelper : CustomHelper
    {
        public FallOverWallHelper(Ped ped) : base(ped, "fallOverWall")
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

        public float Damping
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
                base.SetArgument("damping", value);
            }
        }

        public float MagOfForce
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
                base.SetArgument("magOfForce", value);
            }
        }

        public float MaxDistanceFromPelToHitPoint
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
                base.SetArgument("maxDistanceFromPelToHitPoint", value);
            }
        }

        public float MaxForceDist
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
                base.SetArgument("maxForceDist", value);
            }
        }

        public float StepExclusionZone
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
                base.SetArgument("stepExclusionZone", value);
            }
        }

        public float MinLegHeight
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
                base.SetArgument("minLegHeight", value);
            }
        }

        public float BodyTwist
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
                base.SetArgument("bodyTwist", value);
            }
        }

        public float MaxTwist
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
                base.SetArgument("maxTwist", value);
            }
        }

        public Vector3 FallOverWallEndA
        {
            set => 
                base.SetArgument("fallOverWallEndA", value);
        }

        public Vector3 FallOverWallEndB
        {
            set => 
                base.SetArgument("fallOverWallEndB", value);
        }

        public float ForceAngleAbort
        {
            set => 
                base.SetArgument("forceAngleAbort", value);
        }

        public float ForceTimeOut
        {
            set => 
                base.SetArgument("forceTimeOut", value);
        }

        public bool MoveArms
        {
            set => 
                base.SetArgument("moveArms", value);
        }

        public bool MoveLegs
        {
            set => 
                base.SetArgument("moveLegs", value);
        }

        public bool BendSpine
        {
            set => 
                base.SetArgument("bendSpine", value);
        }

        public float AngleDirWithWallNormal
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("angleDirWithWallNormal", value);
            }
        }

        public float LeaningAngleThreshold
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leaningAngleThreshold", value);
            }
        }

        public float MaxAngVel
        {
            set
            {
                if (value > 30f)
                {
                    value = 30f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("maxAngVel", value);
            }
        }

        public bool AdaptForcesToLowWall
        {
            set => 
                base.SetArgument("adaptForcesToLowWall", value);
        }

        public float MaxWallHeight
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("maxWallHeight", value);
            }
        }

        public float DistanceToSendSuccessMessage
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("distanceToSendSuccessMessage", value);
            }
        }

        public float RollingBackThr
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
                base.SetArgument("rollingBackThr", value);
            }
        }

        public float RollingPotential
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("rollingPotential", value);
            }
        }

        public bool UseArmIK
        {
            set => 
                base.SetArgument("useArmIK", value);
        }

        public float ReachDistanceFromHitPoint
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
                base.SetArgument("reachDistanceFromHitPoint", value);
            }
        }

        public float MinReachDistanceFromHitPoint
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
                base.SetArgument("minReachDistanceFromHitPoint", value);
            }
        }

        public float AngleTotallyBack
        {
            set
            {
                if (value > 180f)
                {
                    value = 180f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("angleTotallyBack", value);
            }
        }
    }
}

