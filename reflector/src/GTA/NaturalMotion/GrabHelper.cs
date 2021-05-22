namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class GrabHelper : CustomHelper
    {
        public GrabHelper(Ped ped) : base(ped, "grab")
        {
        }

        public bool UseLeft
        {
            set => 
                base.SetArgument("useLeft", value);
        }

        public bool UseRight
        {
            set => 
                base.SetArgument("useRight", value);
        }

        public bool DropWeaponIfNecessary
        {
            set => 
                base.SetArgument("dropWeaponIfNecessary", value);
        }

        public float DropWeaponDistance
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
                base.SetArgument("dropWeaponDistance", value);
            }
        }

        public float GrabStrength
        {
            set
            {
                if (value > 10000f)
                {
                    value = 10000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("grabStrength", value);
            }
        }

        public float StickyHands
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
                base.SetArgument("stickyHands", value);
            }
        }

        public TurnType TurnToTarget
        {
            set => 
                base.SetArgument("turnToTarget", (int) value);
        }

        public float GrabHoldMaxTimer
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
                base.SetArgument("grabHoldMaxTimer", value);
            }
        }

        public float PullUpTime
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
                base.SetArgument("pullUpTime", value);
            }
        }

        public float PullUpStrengthRight
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
                base.SetArgument("pullUpStrengthRight", value);
            }
        }

        public float PullUpStrengthLeft
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
                base.SetArgument("pullUpStrengthLeft", value);
            }
        }

        public Vector3 Pos1
        {
            set => 
                base.SetArgument("pos1", value);
        }

        public Vector3 Pos2
        {
            set => 
                base.SetArgument("pos2", value);
        }

        public Vector3 Pos3
        {
            set => 
                base.SetArgument("pos3", value);
        }

        public Vector3 Pos4
        {
            set => 
                base.SetArgument("pos4", value);
        }

        public Vector3 NormalR
        {
            set => 
                base.SetArgument("normalR", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 NormalL
        {
            set => 
                base.SetArgument("normalL", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 NormalR2
        {
            set => 
                base.SetArgument("normalR2", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }

        public Vector3 NormalL2
        {
            set => 
                base.SetArgument("normalL2", Vector3.Clamp(value, new Vector3(-1f, -1f, -1f), new Vector3(1f, 1f, 1f)));
        }

        public bool HandsCollide
        {
            set => 
                base.SetArgument("handsCollide", value);
        }

        public bool JustBrace
        {
            set => 
                base.SetArgument("justBrace", value);
        }

        public bool UseLineGrab
        {
            set => 
                base.SetArgument("useLineGrab", value);
        }

        public bool PointsX4grab
        {
            set => 
                base.SetArgument("pointsX4grab", value);
        }

        public bool FromEA
        {
            set => 
                base.SetArgument("fromEA", value);
        }

        public bool SurfaceGrab
        {
            set => 
                base.SetArgument("surfaceGrab", value);
        }

        public int InstanceIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("instanceIndex", value);
            }
        }

        public int InstancePartIndex
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("instancePartIndex", value);
            }
        }

        public bool DontLetGo
        {
            set => 
                base.SetArgument("dontLetGo", value);
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

        public float ReachAngle
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
                base.SetArgument("reachAngle", value);
            }
        }

        public float OneSideReachAngle
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
                base.SetArgument("oneSideReachAngle", value);
            }
        }

        public float GrabDistance
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
                base.SetArgument("grabDistance", value);
            }
        }

        public float Move2Radius
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("move2Radius", value);
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

        public float MaxReachDistance
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
                base.SetArgument("maxReachDistance", value);
            }
        }

        public float OrientationConstraintScale
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
                base.SetArgument("orientationConstraintScale", value);
            }
        }

        public float MaxWristAngle
        {
            set
            {
                if (value > 3.2f)
                {
                    value = 3.2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxWristAngle", value);
            }
        }

        public bool UseHeadLookToTarget
        {
            set => 
                base.SetArgument("useHeadLookToTarget", value);
        }

        public bool LookAtGrab
        {
            set => 
                base.SetArgument("lookAtGrab", value);
        }

        public Vector3 TargetForHeadLook
        {
            set => 
                base.SetArgument("targetForHeadLook", value);
        }
    }
}

