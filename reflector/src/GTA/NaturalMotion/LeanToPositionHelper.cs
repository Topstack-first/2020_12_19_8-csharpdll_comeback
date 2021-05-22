namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class LeanToPositionHelper : CustomHelper
    {
        public LeanToPositionHelper(Ped ped) : base(ped, "leanToPosition")
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
    }
}

