namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class HipsLeanInDirectionHelper : CustomHelper
    {
        public HipsLeanInDirectionHelper(Ped ped) : base(ped, "hipsLeanInDirection")
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
    }
}

