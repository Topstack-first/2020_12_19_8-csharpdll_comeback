namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ActivePoseHelper : CustomHelper
    {
        public ActivePoseHelper(Ped ped) : base(ped, "activePose")
        {
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }

        public bool UseGravityCompensation
        {
            set => 
                base.SetArgument("useGravityCompensation", value);
        }

        public GTA.NaturalMotion.AnimSource AnimSource
        {
            set => 
                base.SetArgument("animSource", (int) value);
        }
    }
}

