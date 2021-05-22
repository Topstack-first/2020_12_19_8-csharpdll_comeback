namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class Weapon
    {
        private Ped _owner;
        private WeaponComponentCollection _components;

        internal Weapon()
        {
            this.Hash = (WeaponHash) (-1569615261);
        }

        internal Weapon(Ped owner, WeaponHash hash)
        {
            this._owner = owner;
            this.Hash = hash;
        }

        public static unsafe string GetDisplayNameFromHash(WeaponHash hash)
        {
            if (hash <= ((WeaponHash) (-1951375401)))
            {
                if (hash <= WeaponHash.HeavyShotgun)
                {
                    if (hash <= WeaponHash.MicroSMG)
                    {
                        if (hash <= WeaponHash.VintagePistol)
                        {
                            if (hash == WeaponHash.SniperRifle)
                            {
                                return "WT_SNIP_RIF";
                            }
                            if (hash == WeaponHash.VintagePistol)
                            {
                                return "TT_VPISTOL";
                            }
                        }
                        else
                        {
                            if (hash == WeaponHash.CombatPDW)
                            {
                                return "WT_COMBATPDW";
                            }
                            if (hash == WeaponHash.HeavySniper)
                            {
                                return "WT_SNIP_HVY";
                            }
                            if (hash == WeaponHash.MicroSMG)
                            {
                                return "WT_SMG_MCR";
                            }
                        }
                    }
                    else if (hash <= WeaponHash.PumpShotgun)
                    {
                        if (hash == WeaponHash.Pistol)
                        {
                            return "WT_PIST";
                        }
                        if (hash == WeaponHash.PumpShotgun)
                        {
                            return "WT_SG_PMP";
                        }
                    }
                    else
                    {
                        if (hash == WeaponHash.APPistol)
                        {
                            return "WT_PIST_AP";
                        }
                        if (hash == WeaponHash.SMG)
                        {
                            return "WT_SMG";
                        }
                        if (hash == WeaponHash.HeavyShotgun)
                        {
                            return "WT_HVYSHOT";
                        }
                    }
                }
                else if (hash <= WeaponHash.CompactRifle)
                {
                    if (hash <= WeaponHash.FlareGun)
                    {
                        if (hash == WeaponHash.Minigun)
                        {
                            return "WT_MINIGUN";
                        }
                        if (hash == WeaponHash.FlareGun)
                        {
                            return "WT_FLAREGUN";
                        }
                    }
                    else
                    {
                        if (hash == WeaponHash.CombatPistol)
                        {
                            return "WT_PIST_CBT";
                        }
                        if (hash == WeaponHash.Gusenberg)
                        {
                            return "WT_GUSENBERG";
                        }
                        if (hash == WeaponHash.CompactRifle)
                        {
                            return "WT_CMPRIFLE";
                        }
                    }
                }
                else if (hash <= WeaponHash.Firework)
                {
                    if (hash == WeaponHash.HomingLauncher)
                    {
                        return "WT_HOMLNCH";
                    }
                    if (hash == WeaponHash.SawnOffShotgun)
                    {
                        return "WT_SG_SOF";
                    }
                    if (hash == WeaponHash.Firework)
                    {
                        return "WT_FWRKLNCHR";
                    }
                }
                else
                {
                    if (hash == WeaponHash.CombatMG)
                    {
                        return "WT_MG_CBT";
                    }
                    if (hash == ((WeaponHash) (-2084633992)))
                    {
                        return "WT_RIFLE_CBN";
                    }
                    if (hash == ((WeaponHash) (-1951375401)))
                    {
                        return "WT_FLASHLIGHT";
                    }
                }
            }
            else if (hash <= ((WeaponHash) (-1074790547)))
            {
                if (hash <= ((WeaponHash) (-1568386805)))
                {
                    if (hash <= ((WeaponHash) (-1716589765)))
                    {
                        if (hash == ((WeaponHash) (-1834847097)))
                        {
                            return "WT_DAGGER";
                        }
                        if (hash == ((WeaponHash) (-1716589765)))
                        {
                            return "WT_PIST_50";
                        }
                    }
                    else
                    {
                        if (hash == ((WeaponHash) (-1660422300)))
                        {
                            return "WT_MG";
                        }
                        if (hash == ((WeaponHash) (-1654528753)))
                        {
                            return "WT_SG_BLP";
                        }
                        if (hash == ((WeaponHash) (-1568386805)))
                        {
                            return "WT_GL";
                        }
                    }
                }
                else if (hash <= ((WeaponHash) (-1357824103)))
                {
                    if (hash == ((WeaponHash) (-1466123874)))
                    {
                        return "WT_MUSKET";
                    }
                    if (hash == ((WeaponHash) (-1420407917)))
                    {
                        return "WT_PRXMINE";
                    }
                    if (hash == ((WeaponHash) (-1357824103)))
                    {
                        return "WT_RIFLE_ADV";
                    }
                }
                else
                {
                    if (hash == ((WeaponHash) (-1312131151)))
                    {
                        return "WT_RPG";
                    }
                    if (hash == ((WeaponHash) (-1076751822)))
                    {
                        return "WT_SNSPISTOL";
                    }
                    if (hash == ((WeaponHash) (-1074790547)))
                    {
                        return "WT_RIFLE_ASL";
                    }
                }
            }
            else if (hash <= ((WeaponHash) (-598887786)))
            {
                if (hash <= ((WeaponHash) (-952879014)))
                {
                    if (hash == ((WeaponHash) (-1045183535)))
                    {
                        return "WT_REVOLVER";
                    }
                    if (hash == ((WeaponHash) (-952879014)))
                    {
                        return "WT_HMKRIFLE";
                    }
                }
                else
                {
                    if (hash == ((WeaponHash) (-656458692)))
                    {
                        return "WT_KNUCKLE";
                    }
                    if (hash == ((WeaponHash) (-619010992)))
                    {
                        return "WT_MCHPIST";
                    }
                    if (hash == ((WeaponHash) (-598887786)))
                    {
                        return "WT_MKPISTOL";
                    }
                }
            }
            else if (hash <= ((WeaponHash) (-494615257)))
            {
                if (hash == ((WeaponHash) (-581044007)))
                {
                    return "WT_MACHETE";
                }
                if (hash == ((WeaponHash) (-538741184)))
                {
                    return "WT_SWBLADE";
                }
                if (hash == ((WeaponHash) (-494615257)))
                {
                    return "WT_SG_ASL";
                }
            }
            else
            {
                if (hash == ((WeaponHash) (-275439685)))
                {
                    return "WT_DBSHGN";
                }
                if (hash == ((WeaponHash) (-270015777)))
                {
                    return "WT_SMG_ASL";
                }
                if (hash == ((WeaponHash) (-102323637)))
                {
                    return "WT_BOTTLE";
                }
            }
            int num = 0;
            int num2 = Function.Call<int>(GTA.Native.Hash.GET_NUM_DLC_WEAPONS, Array.Empty<InputArgument>());
            while (num < num2)
            {
                DlcWeaponData data;
                InputArgument[] arguments = new InputArgument[] { num, (IntPtr) &data };
                if (Function.Call<bool>(GTA.Native.Hash.GET_DLC_WEAPON_DATA, arguments) && (data.Hash == hash))
                {
                    return data.DisplayName;
                }
                num++;
            }
            return "WT_INVALID";
        }

        public static implicit operator WeaponHash(Weapon weapon) => 
            weapon.Hash;

        public WeaponHash Hash { get; private set; }

        public bool IsPresent
        {
            get
            {
                if (this.Hash == ((WeaponHash) (-1569615261)))
                {
                    return true;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.HAS_PED_GOT_WEAPON, arguments);
            }
        }

        public string DisplayName =>
            GetDisplayNameFromHash(this.Hash);

        public string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        public GTA.Model Model
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return new GTA.Model(Function.Call<int>(GTA.Native.Hash.GET_WEAPONTYPE_MODEL, arguments));
            }
        }

        public WeaponTint Tint
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash };
                return Function.Call<WeaponTint>(GTA.Native.Hash.GET_PED_WEAPON_TINT_INDEX, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, value };
                Function.Call(GTA.Native.Hash.SET_PED_WEAPON_TINT_INDEX, arguments);
            }
        }

        public WeaponGroup Group
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<WeaponGroup>(GTA.Native.Hash.GET_WEAPONTYPE_GROUP, arguments);
            }
        }

        public int Ammo
        {
            get
            {
                if (this.Hash == ((WeaponHash) (-1569615261)))
                {
                    return 1;
                }
                if (!this.IsPresent)
                {
                    return 0;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash };
                return Function.Call<int>(GTA.Native.Hash.GET_AMMO_IN_PED_WEAPON, arguments);
            }
            set
            {
                if (this.Hash != ((WeaponHash) (-1569615261)))
                {
                    if (this.IsPresent)
                    {
                        InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, value };
                        Function.Call(GTA.Native.Hash.SET_PED_AMMO, arguments);
                    }
                    else
                    {
                        InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, value, false, true };
                        Function.Call(GTA.Native.Hash.GIVE_WEAPON_TO_PED, arguments);
                    }
                }
            }
        }

        public int AmmoInClip
        {
            get
            {
                int num;
                if (this.Hash == ((WeaponHash) (-1569615261)))
                {
                    return 1;
                }
                if (!this.IsPresent)
                {
                    return 0;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, (IntPtr) &num };
                Function.Call(GTA.Native.Hash.GET_AMMO_IN_CLIP, arguments);
                return num;
            }
            set
            {
                if (this.Hash != ((WeaponHash) (-1569615261)))
                {
                    if (this.IsPresent)
                    {
                        InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, value };
                        Function.Call(GTA.Native.Hash.SET_AMMO_IN_CLIP, arguments);
                    }
                    else
                    {
                        InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, value, true, false };
                        Function.Call(GTA.Native.Hash.GIVE_WEAPON_TO_PED, arguments);
                    }
                }
            }
        }

        public int MaxAmmo
        {
            get
            {
                int num;
                if (this.Hash == ((WeaponHash) (-1569615261)))
                {
                    return 1;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, (IntPtr) &num };
                Function.Call(GTA.Native.Hash.GET_MAX_AMMO, arguments);
                return num;
            }
        }

        public int MaxAmmoInClip
        {
            get
            {
                if (this.Hash == ((WeaponHash) (-1569615261)))
                {
                    return 1;
                }
                if (!this.IsPresent)
                {
                    return 0;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Hash, true };
                return Function.Call<int>(GTA.Native.Hash.GET_MAX_AMMO_IN_CLIP, arguments);
            }
        }

        public int DefaultClipSize
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<int>(GTA.Native.Hash.GET_WEAPON_CLIP_SIZE, arguments);
            }
        }

        public bool InfiniteAmmo
        {
            set
            {
                if (this.Hash != ((WeaponHash) (-1569615261)))
                {
                    InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value, this.Hash };
                    Function.Call(GTA.Native.Hash.SET_PED_INFINITE_AMMO, arguments);
                }
            }
        }

        public bool InfiniteAmmoClip
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(GTA.Native.Hash.SET_PED_INFINITE_AMMO_CLIP, arguments);
            }
        }

        public bool CanUseOnParachute
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.CAN_USE_WEAPON_ON_PARACHUTE, arguments);
            }
        }

        public WeaponComponentCollection Components
        {
            get
            {
                this._components ??= new WeaponComponentCollection(this._owner, this);
                return this._components;
            }
        }
    }
}

