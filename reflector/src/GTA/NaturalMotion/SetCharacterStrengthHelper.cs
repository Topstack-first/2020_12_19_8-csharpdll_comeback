namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetCharacterStrengthHelper : CustomHelper
    {
        public SetCharacterStrengthHelper(Ped ped) : base(ped, "setCharacterStrength")
        {
        }

        public float CharacterStrength
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
                base.SetArgument("characterStrength", value);
            }
        }
    }
}

