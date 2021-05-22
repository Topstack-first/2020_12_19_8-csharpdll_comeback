namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetMuscleStiffnessHelper : CustomHelper
    {
        public SetMuscleStiffnessHelper(Ped ped) : base(ped, "setMuscleStiffness")
        {
        }

        public float MuscleStiffness
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
                base.SetArgument("muscleStiffness", value);
            }
        }

        public string Mask
        {
            set => 
                base.SetArgument("mask", value);
        }
    }
}

