namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ShotRelaxHelper : CustomHelper
    {
        public ShotRelaxHelper(Ped ped) : base(ped, "shotRelax")
        {
        }

        public float RelaxPeriodUpper
        {
            set
            {
                if (value > 40f)
                {
                    value = 40f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("relaxPeriodUpper", value);
            }
        }

        public float RelaxPeriodLower
        {
            set
            {
                if (value > 40f)
                {
                    value = 40f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("relaxPeriodLower", value);
            }
        }
    }
}

