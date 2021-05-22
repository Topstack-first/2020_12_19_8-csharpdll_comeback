namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotFromBehindHelper : CustomHelper
    {
        public ShotFromBehindHelper(Ped ped) : base(ped, "shotFromBehind")
        {
        }

        public bool ShotFromBehind
        {
            set => 
                base.SetArgument("shotFromBehind", value);
        }

        public float SfbSpineAmount
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
                base.SetArgument("sfbSpineAmount", value);
            }
        }

        public float SfbNeckAmount
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
                base.SetArgument("sfbNeckAmount", value);
            }
        }

        public float SfbHipAmount
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
                base.SetArgument("sfbHipAmount", value);
            }
        }

        public float SfbKneeAmount
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
                base.SetArgument("sfbKneeAmount", value);
            }
        }

        public float SfbPeriod
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
                base.SetArgument("sfbPeriod", value);
            }
        }

        public float SfbForceBalancePeriod
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
                base.SetArgument("sfbForceBalancePeriod", value);
            }
        }

        public float SfbArmsOnset
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
                base.SetArgument("sfbArmsOnset", value);
            }
        }

        public float SfbKneesOnset
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
                base.SetArgument("sfbKneesOnset", value);
            }
        }

        public float SfbNoiseGain
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
                base.SetArgument("sfbNoiseGain", value);
            }
        }

        public int SfbIgnoreFail
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("sfbIgnoreFail", value);
            }
        }
    }
}

