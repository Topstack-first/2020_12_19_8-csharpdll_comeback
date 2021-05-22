namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ForceLeanInDirectionHelper : CustomHelper
    {
        public ForceLeanInDirectionHelper(Ped ped) : base(ped, "forceLeanInDirection")
        {
        }

        public float LeanAmount
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
                base.SetArgument("leanAmount", value);
            }
        }

        public Vector3 Dir
        {
            set => 
                base.SetArgument("dir", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public int BodyPart
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("bodyPart", value);
            }
        }
    }
}

