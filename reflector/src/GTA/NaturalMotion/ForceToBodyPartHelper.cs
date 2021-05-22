namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class ForceToBodyPartHelper : CustomHelper
    {
        public ForceToBodyPartHelper(Ped ped) : base(ped, "forceToBodyPart")
        {
        }

        public int PartIndex
        {
            set
            {
                if (value > 0x1c)
                {
                    value = 0x1c;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("partIndex", value);
            }
        }

        public Vector3 Force
        {
            set => 
                base.SetArgument("force", Vector3.Clamp(value, new Vector3(-100000f, -100000f, -100000f), new Vector3(100000f, 100000f, 100000f)));
        }

        public bool ForceDefinedInPartSpace
        {
            set => 
                base.SetArgument("forceDefinedInPartSpace", value);
        }
    }
}

