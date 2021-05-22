namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ForceLeanTowardsObjectHelper : CustomHelper
    {
        public ForceLeanTowardsObjectHelper(Ped ped) : base(ped, "forceLeanTowardsObject")
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

