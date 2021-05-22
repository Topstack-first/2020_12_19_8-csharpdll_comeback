namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ForceLeanToPositionHelper : CustomHelper
    {
        public ForceLeanToPositionHelper(Ped ped) : base(ped, "forceLeanToPosition")
        {
        }

        public float LeanAmount
        {
            set
            {
                if (value > 0.5f)
                {
                    value = 0.5f;
                }
                if (value < -0.5f)
                {
                    value = -0.5f;
                }
                base.SetArgument("leanAmount", value);
            }
        }

        public Vector3 Pos
        {
            set => 
                base.SetArgument("pos", value);
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

