namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ElectrocuteHelper : CustomHelper
    {
        public ElectrocuteHelper(Ped ped) : base(ped, "electrocute")
        {
        }

        public float StunMag
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
                base.SetArgument("stunMag", value);
            }
        }

        public float InitialMult
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("initialMult", value);
            }
        }

        public float LargeMult
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("largeMult", value);
            }
        }

        public float LargeMinTime
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
                base.SetArgument("largeMinTime", value);
            }
        }

        public float LargeMaxTime
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
                base.SetArgument("largeMaxTime", value);
            }
        }

        public float MovingMult
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("movingMult", value);
            }
        }

        public float BalancingMult
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("balancingMult", value);
            }
        }

        public float AirborneMult
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("airborneMult", value);
            }
        }

        public float MovingThresh
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("movingThresh", value);
            }
        }

        public float StunInterval
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
                base.SetArgument("stunInterval", value);
            }
        }

        public float DirectionRandomness
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
                base.SetArgument("directionRandomness", value);
            }
        }

        public bool LeftArm
        {
            set => 
                base.SetArgument("leftArm", value);
        }

        public bool RightArm
        {
            set => 
                base.SetArgument("rightArm", value);
        }

        public bool LeftLeg
        {
            set => 
                base.SetArgument("leftLeg", value);
        }

        public bool RightLeg
        {
            set => 
                base.SetArgument("rightLeg", value);
        }

        public bool Spine
        {
            set => 
                base.SetArgument("spine", value);
        }

        public bool Neck
        {
            set => 
                base.SetArgument("neck", value);
        }

        public bool PhasedLegs
        {
            set => 
                base.SetArgument("phasedLegs", value);
        }

        public bool ApplyStiffness
        {
            set => 
                base.SetArgument("applyStiffness", value);
        }

        public bool UseTorques
        {
            set => 
                base.SetArgument("useTorques", value);
        }

        public int HipType
        {
            set
            {
                if (value > 2)
                {
                    value = 2;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("hipType", value);
            }
        }
    }
}

