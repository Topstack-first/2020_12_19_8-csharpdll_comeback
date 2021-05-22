namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class PointArmHelper : CustomHelper
    {
        public PointArmHelper(Ped ped) : base(ped, "pointArm")
        {
        }

        public Vector3 TargetLeft
        {
            set => 
                base.SetArgument("targetLeft", value);
        }

        public float TwistLeft
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
                base.SetArgument("twistLeft", value);
            }
        }

        public float ArmStraightnessLeft
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
                base.SetArgument("armStraightnessLeft", value);
            }
        }

        public bool UseLeftArm
        {
            set => 
                base.SetArgument("useLeftArm", value);
        }

        public float ArmStiffnessLeft
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
                base.SetArgument("armStiffnessLeft", value);
            }
        }

        public float ArmDampingLeft
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
                base.SetArgument("armDampingLeft", value);
            }
        }

        public int InstanceIndexLeft
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("instanceIndexLeft", value);
            }
        }

        public float PointSwingLimitLeft
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
                base.SetArgument("pointSwingLimitLeft", value);
            }
        }

        public bool UseZeroPoseWhenNotPointingLeft
        {
            set => 
                base.SetArgument("useZeroPoseWhenNotPointingLeft", value);
        }

        public Vector3 TargetRight
        {
            set => 
                base.SetArgument("targetRight", value);
        }

        public float TwistRight
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
                base.SetArgument("twistRight", value);
            }
        }

        public float ArmStraightnessRight
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
                base.SetArgument("armStraightnessRight", value);
            }
        }

        public bool UseRightArm
        {
            set => 
                base.SetArgument("useRightArm", value);
        }

        public float ArmStiffnessRight
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
                base.SetArgument("armStiffnessRight", value);
            }
        }

        public float ArmDampingRight
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
                base.SetArgument("armDampingRight", value);
            }
        }

        public int InstanceIndexRight
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("instanceIndexRight", value);
            }
        }

        public float PointSwingLimitRight
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
                base.SetArgument("pointSwingLimitRight", value);
            }
        }

        public bool UseZeroPoseWhenNotPointingRight
        {
            set => 
                base.SetArgument("useZeroPoseWhenNotPointingRight", value);
        }
    }
}

