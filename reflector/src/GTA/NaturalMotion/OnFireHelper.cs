namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class OnFireHelper : CustomHelper
    {
        public OnFireHelper(Ped ped) : base(ped, "onFire")
        {
        }

        public float StaggerTime
        {
            set
            {
                if (value > 30f)
                {
                    value = 30f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("staggerTime", value);
            }
        }

        public float StaggerLeanRate
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
                base.SetArgument("staggerLeanRate", value);
            }
        }

        public float StumbleMaxLeanBack
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stumbleMaxLeanBack", value);
            }
        }

        public float StumbleMaxLeanForward
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stumbleMaxLeanForward", value);
            }
        }

        public float ArmsWindmillWritheBlend
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
                base.SetArgument("armsWindmillWritheBlend", value);
            }
        }

        public float SpineStumbleWritheBlend
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
                base.SetArgument("spineStumbleWritheBlend", value);
            }
        }

        public float LegsStumbleWritheBlend
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
                base.SetArgument("legsStumbleWritheBlend", value);
            }
        }

        public float ArmsPoseWritheBlend
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
                base.SetArgument("armsPoseWritheBlend", value);
            }
        }

        public float SpinePoseWritheBlend
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
                base.SetArgument("spinePoseWritheBlend", value);
            }
        }

        public float LegsPoseWritheBlend
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
                base.SetArgument("legsPoseWritheBlend", value);
            }
        }

        public bool RollOverFlag
        {
            set => 
                base.SetArgument("rollOverFlag", value);
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

        public float PredictTime
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
                base.SetArgument("predictTime", value);
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

