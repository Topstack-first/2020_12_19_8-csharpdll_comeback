namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class DangleHelper : CustomHelper
    {
        public DangleHelper(Ped ped) : base(ped, "dangle")
        {
        }

        public bool DoGrab
        {
            set => 
                base.SetArgument("doGrab", value);
        }

        public float GrabFrequency
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
                base.SetArgument("grabFrequency", value);
            }
        }
    }
}

