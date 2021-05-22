namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class HipsLeanToPositionHelper : CustomHelper
    {
        public HipsLeanToPositionHelper(Ped ped) : base(ped, "hipsLeanToPosition")
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

