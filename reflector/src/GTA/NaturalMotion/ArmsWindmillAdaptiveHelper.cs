namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ArmsWindmillAdaptiveHelper : CustomHelper
    {
        public ArmsWindmillAdaptiveHelper(Ped ped) : base(ped, "armsWindmillAdaptive")
        {
        }

        public float AngSpeed
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0.1f)
                {
                    value = 0.1f;
                }
                base.SetArgument("angSpeed", value);
            }
        }

        public float BodyStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("bodyStiffness", value);
            }
        }

        public float Amplitude
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
                base.SetArgument("amplitude", value);
            }
        }

        public float Phase
        {
            set
            {
                if (value > 8f)
                {
                    value = 8f;
                }
                if (value < -4f)
                {
                    value = -4f;
                }
                base.SetArgument("phase", value);
            }
        }

        public float ArmStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("armStiffness", value);
            }
        }

        public float LeftElbowAngle
        {
            set
            {
                if (value > 6f)
                {
                    value = 6f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("leftElbowAngle", value);
            }
        }

        public float RightElbowAngle
        {
            set
            {
                if (value > 6f)
                {
                    value = 6f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("rightElbowAngle", value);
            }
        }

        public float Lean1mult
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
                base.SetArgument("lean1mult", value);
            }
        }

        public float Lean1offset
        {
            set
            {
                if (value > 6f)
                {
                    value = 6f;
                }
                if (value < -6f)
                {
                    value = -6f;
                }
                base.SetArgument("lean1offset", value);
            }
        }

        public float ElbowRate
        {
            set
            {
                if (value > 6f)
                {
                    value = 6f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("elbowRate", value);
            }
        }

        public GTA.NaturalMotion.ArmDirection ArmDirection
        {
            set => 
                base.SetArgument("armDirection", (int) value);
        }

        public bool DisableOnImpact
        {
            set => 
                base.SetArgument("disableOnImpact", value);
        }

        public bool SetBackAngles
        {
            set => 
                base.SetArgument("setBackAngles", value);
        }

        public bool UseAngMom
        {
            set => 
                base.SetArgument("useAngMom", value);
        }

        public bool BendLeftElbow
        {
            set => 
                base.SetArgument("bendLeftElbow", value);
        }

        public bool BendRightElbow
        {
            set => 
                base.SetArgument("bendRightElbow", value);
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

