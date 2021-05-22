namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ApplyBulletImpulseHelper : CustomHelper
    {
        public ApplyBulletImpulseHelper(Ped ped) : base(ped, "applyBulletImpulse")
        {
        }

        public float EqualizeAmount
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("equalizeAmount", value);
            }
        }

        public int PartIndex
        {
            set
            {
                if (value > 0x1c)
                {
                    value = 0x1c;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("partIndex", value);
            }
        }

        public Vector3 Impulse
        {
            set => 
                base.SetArgument("impulse", Vector3.Clamp(value, new Vector3(-1000f, -1000f, -1000f), new Vector3(1000f, 1000f, 1000f)));
        }

        public Vector3 HitPoint
        {
            set => 
                base.SetArgument("hitPoint", value);
        }

        public bool LocalHitPointInfo
        {
            set => 
                base.SetArgument("localHitPointInfo", value);
        }

        public float ExtraShare
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("extraShare", value);
            }
        }
    }
}

