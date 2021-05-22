namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class BodyRelaxHelper : CustomHelper
    {
        public BodyRelaxHelper(Ped ped) : base(ped, "bodyRelax")
        {
        }

        public float Relaxation
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
                base.SetArgument("relaxation", value);
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

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }

        public bool HoldPose
        {
            set => 
                base.SetArgument("holdPose", value);
        }

        public bool DisableJointDriving
        {
            set => 
                base.SetArgument("disableJointDriving", value);
        }
    }
}

