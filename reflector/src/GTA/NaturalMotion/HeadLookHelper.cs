namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class HeadLookHelper : CustomHelper
    {
        public HeadLookHelper(Ped ped) : base(ped, "headLook")
        {
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

        public float Stiffness
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
                base.SetArgument("stiffness", value);
            }
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

        public Vector3 Vel
        {
            set => 
                base.SetArgument("vel", Vector3.Clamp(value, new Vector3(-100f, -100f, -100f), new Vector3(100f, 100f, 100f)));
        }

        public Vector3 Pos
        {
            set => 
                base.SetArgument("pos", value);
        }

        public bool AlwaysLook
        {
            set => 
                base.SetArgument("alwaysLook", value);
        }

        public bool EyesHorizontal
        {
            set => 
                base.SetArgument("eyesHorizontal", value);
        }

        public bool AlwaysEyesHorizontal
        {
            set => 
                base.SetArgument("alwaysEyesHorizontal", value);
        }

        public bool KeepHeadAwayFromGround
        {
            set => 
                base.SetArgument("keepHeadAwayFromGround", value);
        }

        public bool TwistSpine
        {
            set => 
                base.SetArgument("twistSpine", value);
        }
    }
}

