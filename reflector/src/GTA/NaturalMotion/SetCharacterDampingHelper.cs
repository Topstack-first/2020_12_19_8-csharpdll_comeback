namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetCharacterDampingHelper : CustomHelper
    {
        public SetCharacterDampingHelper(Ped ped) : base(ped, "setCharacterDamping")
        {
        }

        public float SomersaultThresh
        {
            set
            {
                if (value > 200f)
                {
                    value = 200f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("somersaultThresh", value);
            }
        }

        public float SomersaultDamp
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("somersaultDamp", value);
            }
        }

        public float CartwheelThresh
        {
            set
            {
                if (value > 200f)
                {
                    value = 200f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("cartwheelThresh", value);
            }
        }

        public float CartwheelDamp
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("cartwheelDamp", value);
            }
        }

        public float VehicleCollisionTime
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("vehicleCollisionTime", value);
            }
        }

        public bool V2
        {
            set => 
                base.SetArgument("v2", value);
        }
    }
}

