namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class TeeterHelper : CustomHelper
    {
        public TeeterHelper(Ped ped) : base(ped, "teeter")
        {
        }

        public Vector3 EdgeLeft
        {
            set => 
                base.SetArgument("edgeLeft", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public Vector3 EdgeRight
        {
            set => 
                base.SetArgument("edgeRight", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public bool UseExclusionZone
        {
            set => 
                base.SetArgument("useExclusionZone", value);
        }

        public bool UseHeadLook
        {
            set => 
                base.SetArgument("useHeadLook", value);
        }

        public bool CallHighFall
        {
            set => 
                base.SetArgument("callHighFall", value);
        }

        public bool LeanAway
        {
            set => 
                base.SetArgument("leanAway", value);
        }

        public float PreTeeterTime
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
                base.SetArgument("preTeeterTime", value);
            }
        }

        public float LeanAwayTime
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
                base.SetArgument("leanAwayTime", value);
            }
        }

        public float LeanAwayScale
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
                base.SetArgument("leanAwayScale", value);
            }
        }

        public float TeeterTime
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
                base.SetArgument("teeterTime", value);
            }
        }
    }
}

