namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ShotHeadLookHelper : CustomHelper
    {
        public ShotHeadLookHelper(Ped ped) : base(ped, "shotHeadLook")
        {
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public Vector3 HeadLook
        {
            set => 
                base.SetArgument("headLook", value);
        }

        public float HeadLookAtWoundMinTimer
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("headLookAtWoundMinTimer", value);
            }
        }

        public float HeadLookAtWoundMaxTimer
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("headLookAtWoundMaxTimer", value);
            }
        }

        public float HeadLookAtHeadPosMaxTimer
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("headLookAtHeadPosMaxTimer", value);
            }
        }

        public float HeadLookAtHeadPosMinTimer
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("headLookAtHeadPosMinTimer", value);
            }
        }
    }
}

