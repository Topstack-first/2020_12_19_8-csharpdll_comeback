namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetCharacterHealthHelper : CustomHelper
    {
        public SetCharacterHealthHelper(Ped ped) : base(ped, "setCharacterHealth")
        {
        }

        public float CharacterHealth
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
                base.SetArgument("characterHealth", value);
            }
        }
    }
}

