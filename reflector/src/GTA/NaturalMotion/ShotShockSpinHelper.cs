namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotShockSpinHelper : CustomHelper
    {
        public ShotShockSpinHelper(Ped ped) : base(ped, "shotShockSpin")
        {
        }

        public bool AddShockSpin
        {
            set => 
                base.SetArgument("addShockSpin", value);
        }

        public bool RandomizeShockSpinDirection
        {
            set => 
                base.SetArgument("randomizeShockSpinDirection", value);
        }

        public bool AlwaysAddShockSpin
        {
            set => 
                base.SetArgument("alwaysAddShockSpin", value);
        }

        public float ShockSpinMin
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("shockSpinMin", value);
            }
        }

        public float ShockSpinMax
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("shockSpinMax", value);
            }
        }

        public float ShockSpinLiftForceMult
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
                base.SetArgument("shockSpinLiftForceMult", value);
            }
        }

        public float ShockSpinDecayMult
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
                base.SetArgument("shockSpinDecayMult", value);
            }
        }

        public float ShockSpinScalePerComponent
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
                base.SetArgument("shockSpinScalePerComponent", value);
            }
        }

        public float ShockSpinMaxTwistVel
        {
            set
            {
                if (value > 200f)
                {
                    value = 200f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("shockSpinMaxTwistVel", value);
            }
        }

        public bool ShockSpinScaleByLeverArm
        {
            set => 
                base.SetArgument("shockSpinScaleByLeverArm", value);
        }

        public float ShockSpinAirMult
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
                base.SetArgument("shockSpinAirMult", value);
            }
        }

        public float ShockSpin1FootMult
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
                base.SetArgument("shockSpin1FootMult", value);
            }
        }

        public float ShockSpinFootGripMult
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
                base.SetArgument("shockSpinFootGripMult", value);
            }
        }

        public float BracedSideSpinMult
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < 1f)
                {
                    value = 1f;
                }
                base.SetArgument("bracedSideSpinMult", value);
            }
        }
    }
}

