namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class DefineAttachedObjectHelper : CustomHelper
    {
        public DefineAttachedObjectHelper(Ped ped) : base(ped, "defineAttachedObject")
        {
        }

        public int PartIndex
        {
            set
            {
                if (value > 0x15)
                {
                    value = 0x15;
                }
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("partIndex", value);
            }
        }

        public float ObjectMass
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("objectMass", value);
            }
        }

        public Vector3 WorldPos
        {
            set => 
                base.SetArgument("worldPos", value);
        }
    }
}

