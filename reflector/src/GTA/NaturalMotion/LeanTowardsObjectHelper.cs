namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class LeanTowardsObjectHelper : CustomHelper
    {
        public LeanTowardsObjectHelper(Ped ped) : base(ped, "leanTowardsObject")
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

        public Vector3 Offset
        {
            set => 
                base.SetArgument("offset", Vector3.Clamp(value, new Vector3(-100f, -100f, -100f), new Vector3(100f, 100f, 100f)));
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

        public int BoundIndex
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("boundIndex", value);
            }
        }
    }
}

