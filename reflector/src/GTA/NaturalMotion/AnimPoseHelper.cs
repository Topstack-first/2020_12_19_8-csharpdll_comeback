namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class AnimPoseHelper : CustomHelper
    {
        public AnimPoseHelper(Ped ped) : base(ped, "animPose")
        {
        }

        public float MuscleStiffness
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -1.1f)
                {
                    value = -1.1f;
                }
                base.SetArgument("muscleStiffness", value);
            }
        }

        public float Stiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1.1f)
                {
                    value = -1.1f;
                }
                base.SetArgument("stiffness", value);
            }
        }

        public float Damping
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
                base.SetArgument("damping", value);
            }
        }

        public string EffectorMask
        {
            set => 
                base.SetArgument("effectorMask", value);
        }

        public bool OverideHeadlook
        {
            set => 
                base.SetArgument("overideHeadlook", value);
        }

        public bool OveridePointArm
        {
            set => 
                base.SetArgument("overidePointArm", value);
        }

        public bool OveridePointGun
        {
            set => 
                base.SetArgument("overidePointGun", value);
        }

        public bool UseZMPGravityCompensation
        {
            set => 
                base.SetArgument("useZMPGravityCompensation", value);
        }

        public float GravityCompensation
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravityCompensation", value);
            }
        }

        public float MuscleStiffnessLeftArm
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
                base.SetArgument("muscleStiffnessLeftArm", value);
            }
        }

        public float MuscleStiffnessRightArm
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
                base.SetArgument("muscleStiffnessRightArm", value);
            }
        }

        public float MuscleStiffnessSpine
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
                base.SetArgument("muscleStiffnessSpine", value);
            }
        }

        public float MuscleStiffnessLeftLeg
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
                base.SetArgument("muscleStiffnessLeftLeg", value);
            }
        }

        public float MuscleStiffnessRightLeg
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
                base.SetArgument("muscleStiffnessRightLeg", value);
            }
        }

        public float StiffnessLeftArm
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stiffnessLeftArm", value);
            }
        }

        public float StiffnessRightArm
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stiffnessRightArm", value);
            }
        }

        public float StiffnessSpine
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stiffnessSpine", value);
            }
        }

        public float StiffnessLeftLeg
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stiffnessLeftLeg", value);
            }
        }

        public float StiffnessRightLeg
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stiffnessRightLeg", value);
            }
        }

        public float DampingLeftArm
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
                base.SetArgument("dampingLeftArm", value);
            }
        }

        public float DampingRightArm
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
                base.SetArgument("dampingRightArm", value);
            }
        }

        public float DampingSpine
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
                base.SetArgument("dampingSpine", value);
            }
        }

        public float DampingLeftLeg
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
                base.SetArgument("dampingLeftLeg", value);
            }
        }

        public float DampingRightLeg
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
                base.SetArgument("dampingRightLeg", value);
            }
        }

        public float GravCompLeftArm
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravCompLeftArm", value);
            }
        }

        public float GravCompRightArm
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravCompRightArm", value);
            }
        }

        public float GravCompSpine
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravCompSpine", value);
            }
        }

        public float GravCompLeftLeg
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravCompLeftLeg", value);
            }
        }

        public float GravCompRightLeg
        {
            set
            {
                if (value > 14f)
                {
                    value = 14f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("gravCompRightLeg", value);
            }
        }

        public int ConnectedLeftHand
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("connectedLeftHand", value);
            }
        }

        public int ConnectedRightHand
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("connectedRightHand", value);
            }
        }

        public int ConnectedLeftFoot
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < -2)
                {
                    value = -2;
                }
                base.SetArgument("connectedLeftFoot", value);
            }
        }

        public int ConnectedRightFoot
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < -2)
                {
                    value = -2;
                }
                base.SetArgument("connectedRightFoot", value);
            }
        }

        public GTA.NaturalMotion.AnimSource AnimSource
        {
            set => 
                base.SetArgument("animSource", (int) value);
        }

        public int DampenSideMotionInstanceIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("dampenSideMotionInstanceIndex", value);
            }
        }
    }
}

