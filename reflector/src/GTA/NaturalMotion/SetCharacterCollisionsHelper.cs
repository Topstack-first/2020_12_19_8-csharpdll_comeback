namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetCharacterCollisionsHelper : CustomHelper
    {
        public SetCharacterCollisionsHelper(Ped ped) : base(ped, "setCharacterCollisions")
        {
        }

        public float Spin
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("spin", value);
            }
        }

        public float MaxVelocity
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxVelocity", value);
            }
        }

        public bool ApplyToAll
        {
            set => 
                base.SetArgument("applyToAll", value);
        }

        public bool ApplyToSpine
        {
            set => 
                base.SetArgument("applyToSpine", value);
        }

        public bool ApplyToThighs
        {
            set => 
                base.SetArgument("applyToThighs", value);
        }

        public bool ApplyToClavicles
        {
            set => 
                base.SetArgument("applyToClavicles", value);
        }

        public bool ApplyToUpperArms
        {
            set => 
                base.SetArgument("applyToUpperArms", value);
        }

        public bool FootSlip
        {
            set => 
                base.SetArgument("footSlip", value);
        }

        public int VehicleClass
        {
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("vehicleClass", value);
            }
        }
    }
}

