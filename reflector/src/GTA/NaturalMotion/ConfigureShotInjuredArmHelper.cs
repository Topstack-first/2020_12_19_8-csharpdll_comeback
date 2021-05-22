namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureShotInjuredArmHelper : CustomHelper
    {
        public ConfigureShotInjuredArmHelper(Ped ped) : base(ped, "configureShotInjuredArm")
        {
        }

        public float InjuredArmTime
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
                base.SetArgument("injuredArmTime", value);
            }
        }

        public float HipYaw
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("hipYaw", value);
            }
        }

        public float HipRoll
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < -2f)
                {
                    value = -2f;
                }
                base.SetArgument("hipRoll", value);
            }
        }

        public float ForceStepExtraHeight
        {
            set
            {
                if (value > 0.7f)
                {
                    value = 0.7f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("forceStepExtraHeight", value);
            }
        }

        public bool ForceStep
        {
            set => 
                base.SetArgument("forceStep", value);
        }

        public bool StepTurn
        {
            set => 
                base.SetArgument("stepTurn", value);
        }

        public float VelMultiplierStart
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
                base.SetArgument("velMultiplierStart", value);
            }
        }

        public float VelMultiplierEnd
        {
            set
            {
                if (value > 40f)
                {
                    value = 40f;
                }
                if (value < 1f)
                {
                    value = 1f;
                }
                base.SetArgument("velMultiplierEnd", value);
            }
        }

        public float VelForceStep
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
                base.SetArgument("velForceStep", value);
            }
        }

        public float VelStepTurn
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
                base.SetArgument("velStepTurn", value);
            }
        }

        public bool VelScales
        {
            set => 
                base.SetArgument("velScales", value);
        }
    }
}

