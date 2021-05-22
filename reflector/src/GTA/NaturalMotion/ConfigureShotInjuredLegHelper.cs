namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureShotInjuredLegHelper : CustomHelper
    {
        public ConfigureShotInjuredLegHelper(Ped ped) : base(ped, "configureShotInjuredLeg")
        {
        }

        public float TimeBeforeCollapseWoundLeg
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
                base.SetArgument("timeBeforeCollapseWoundLeg", value);
            }
        }

        public float LegInjuryTime
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
                base.SetArgument("legInjuryTime", value);
            }
        }

        public bool LegForceStep
        {
            set => 
                base.SetArgument("legForceStep", value);
        }

        public float LegLimpBend
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
                base.SetArgument("legLimpBend", value);
            }
        }

        public float LegLiftTime
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
                base.SetArgument("legLiftTime", value);
            }
        }

        public float LegInjury
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
                base.SetArgument("legInjury", value);
            }
        }

        public float LegInjuryHipPitch
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("legInjuryHipPitch", value);
            }
        }

        public float LegInjuryLiftHipPitch
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("legInjuryLiftHipPitch", value);
            }
        }

        public float LegInjurySpineBend
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("legInjurySpineBend", value);
            }
        }

        public float LegInjuryLiftSpineBend
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("legInjuryLiftSpineBend", value);
            }
        }
    }
}

