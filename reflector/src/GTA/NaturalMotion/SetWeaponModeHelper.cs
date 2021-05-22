namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class SetWeaponModeHelper : CustomHelper
    {
        public SetWeaponModeHelper(Ped ped) : base(ped, "setWeaponMode")
        {
        }

        public GTA.NaturalMotion.WeaponMode WeaponMode
        {
            set => 
                base.SetArgument("weaponMode", (int) value);
        }
    }
}

