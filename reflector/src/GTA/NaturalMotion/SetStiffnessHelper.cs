namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetStiffnessHelper : CustomHelper
    {
        public SetStiffnessHelper(Ped ped) : base(ped, "setStiffness")
        {
        }

        public float BodyStiffness
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 2f)
                {
                    value = 2f;
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

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

