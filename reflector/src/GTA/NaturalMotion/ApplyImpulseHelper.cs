namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ApplyImpulseHelper : CustomHelper
    {
        public ApplyImpulseHelper(Ped ped) : base(ped, "applyImpulse")
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
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("partIndex", value);
            }
        }

        public Vector3 Impulse
        {
            set => 
                base.SetArgument("impulse", Vector3.Clamp(value, new Vector3(-4500f, -4500f, -4500f), new Vector3(4500f, 4500f, 4500f)));
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

        public bool LocalImpulseInfo
        {
            set => 
                base.SetArgument("localImpulseInfo", value);
        }

        public bool AngularImpulse
        {
            set => 
                base.SetArgument("angularImpulse", value);
        }
    }
}

