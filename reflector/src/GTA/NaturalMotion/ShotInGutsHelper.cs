namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotInGutsHelper : CustomHelper
    {
        public ShotInGutsHelper(Ped ped) : base(ped, "shotInGuts")
        {
        }

        public bool ShotInGuts
        {
            set => 
                base.SetArgument("shotInGuts", value);
        }

        public float SigSpineAmount
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
                base.SetArgument("sigSpineAmount", value);
            }
        }

        public float SigNeckAmount
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
                base.SetArgument("sigNeckAmount", value);
            }
        }

        public float SigHipAmount
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
                base.SetArgument("sigHipAmount", value);
            }
        }

        public float SigKneeAmount
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
                base.SetArgument("sigKneeAmount", value);
            }
        }

        public float SigPeriod
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
                base.SetArgument("sigPeriod", value);
            }
        }

        public float SigForceBalancePeriod
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
                base.SetArgument("sigForceBalancePeriod", value);
            }
        }

        public float SigKneesOnset
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
                base.SetArgument("sigKneesOnset", value);
            }
        }
    }
}

