namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class BodyWritheHelper : CustomHelper
    {
        public BodyWritheHelper(Ped ped) : base(ped, "bodyWrithe")
        {
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

        public float BackStiffness
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
                base.SetArgument("backStiffness", value);
            }
        }

        public float LegStiffness
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
                base.SetArgument("legStiffness", value);
            }
        }

        public float ArmDamping
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armDamping", value);
            }
        }

        public float BackDamping
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("backDamping", value);
            }
        }

        public float LegDamping
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legDamping", value);
            }
        }

        public float ArmPeriod
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armPeriod", value);
            }
        }

        public float BackPeriod
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("backPeriod", value);
            }
        }

        public float LegPeriod
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legPeriod", value);
            }
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }

        public float ArmAmplitude
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("armAmplitude", value);
            }
        }

        public float BackAmplitude
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("backAmplitude", value);
            }
        }

        public float LegAmplitude
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legAmplitude", value);
            }
        }

        public float ElbowAmplitude
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("elbowAmplitude", value);
            }
        }

        public float KneeAmplitude
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("kneeAmplitude", value);
            }
        }

        public bool RollOverFlag
        {
            set => 
                base.SetArgument("rollOverFlag", value);
        }

        public float BlendArms
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
                base.SetArgument("blendArms", value);
            }
        }

        public float BlendBack
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
                base.SetArgument("blendBack", value);
            }
        }

        public float BlendLegs
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
                base.SetArgument("blendLegs", value);
            }
        }

        public bool ApplyStiffness
        {
            set => 
                base.SetArgument("applyStiffness", value);
        }

        public bool OnFire
        {
            set => 
                base.SetArgument("onFire", value);
        }

        public float ShoulderLean1
        {
            set
            {
                if (value > 6.3f)
                {
                    value = 6.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("shoulderLean1", value);
            }
        }

        public float ShoulderLean2
        {
            set
            {
                if (value > 6.3f)
                {
                    value = 6.3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("shoulderLean2", value);
            }
        }

        public float Lean1BlendFactor
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
                base.SetArgument("lean1BlendFactor", value);
            }
        }

        public float Lean2BlendFactor
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
                base.SetArgument("lean2BlendFactor", value);
            }
        }

        public float RollTorqueScale
        {
            set
            {
                if (value > 300f)
                {
                    value = 300f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("rollTorqueScale", value);
            }
        }

        public float MaxRollOverTime
        {
            set
            {
                if (value > 60f)
                {
                    value = 60f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxRollOverTime", value);
            }
        }

        public float RollOverRadius
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
                base.SetArgument("rollOverRadius", value);
            }
        }
    }
}

