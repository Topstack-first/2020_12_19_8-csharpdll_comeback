namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class BuoyancyHelper : CustomHelper
    {
        public BuoyancyHelper(Ped ped) : base(ped, "buoyancy")
        {
        }

        public Vector3 SurfacePoint
        {
            set => 
                base.SetArgument("surfacePoint", value);
        }

        public Vector3 SurfaceNormal
        {
            set => 
                base.SetArgument("surfaceNormal", Vector3.Maximize(value, new Vector3(0f, 0f, 0f)));
        }

        public float Buoyancy
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("buoyancy", value);
            }
        }

        public float ChestBuoyancy
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("chestBuoyancy", value);
            }
        }

        public float Damping
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("damping", value);
            }
        }

        public bool Righting
        {
            set => 
                base.SetArgument("righting", value);
        }

        public float RightingStrength
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rightingStrength", value);
            }
        }

        public float RightingTime
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rightingTime", value);
            }
        }
    }
}

