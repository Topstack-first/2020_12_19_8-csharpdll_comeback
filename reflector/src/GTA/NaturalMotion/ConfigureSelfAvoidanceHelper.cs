namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureSelfAvoidanceHelper : CustomHelper
    {
        public ConfigureSelfAvoidanceHelper(Ped ped) : base(ped, "configureSelfAvoidance")
        {
        }

        public bool UseSelfAvoidance
        {
            set => 
                base.SetArgument("useSelfAvoidance", value);
        }

        public bool OverwriteDragReduction
        {
            set => 
                base.SetArgument("overwriteDragReduction", value);
        }

        public float TorsoSwingFraction
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
                base.SetArgument("torsoSwingFraction", value);
            }
        }

        public float MaxTorsoSwingAngleRad
        {
            set
            {
                if (value > 1.6f)
                {
                    value = 1.6f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxTorsoSwingAngleRad", value);
            }
        }

        public bool SelfAvoidIfInSpineBoundsOnly
        {
            set => 
                base.SetArgument("selfAvoidIfInSpineBoundsOnly", value);
        }

        public float SelfAvoidAmount
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
                base.SetArgument("selfAvoidAmount", value);
            }
        }

        public bool OverwriteTwist
        {
            set => 
                base.SetArgument("overwriteTwist", value);
        }

        public bool UsePolarPathAlgorithm
        {
            set => 
                base.SetArgument("usePolarPathAlgorithm", value);
        }

        public float Radius
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
                base.SetArgument("radius", value);
            }
        }
    }
}

