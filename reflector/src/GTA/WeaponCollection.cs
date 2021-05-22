namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class WeaponCollection
    {
        private Ped _owner;
        private readonly Dictionary<WeaponHash, Weapon> _weapons = new Dictionary<WeaponHash, Weapon>();

        internal WeaponCollection(Ped owner)
        {
            this._owner = owner;
        }

        public void Drop()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
            Function.Call(Hash.SET_PED_DROPS_WEAPON, arguments);
        }

        public Weapon Give(WeaponHash hash, int ammoCount, bool equipNow, bool isAmmoLoaded)
        {
            Weapon weapon = null;
            if (!this._weapons.TryGetValue(hash, out weapon))
            {
                weapon = new Weapon(this._owner, hash);
                this._weapons.Add(hash, weapon);
            }
            if (weapon.IsPresent)
            {
                this.Select(weapon);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, weapon.Hash, ammoCount, equipNow, isAmmoLoaded };
                Function.Call(Hash.GIVE_WEAPON_TO_PED, arguments);
            }
            return weapon;
        }

        public bool HasWeapon(WeaponHash weaponHash)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, weaponHash };
            return Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, arguments);
        }

        public bool IsWeaponValid(WeaponHash hash)
        {
            InputArgument[] arguments = new InputArgument[] { hash };
            return Function.Call<bool>(Hash.IS_WEAPON_VALID, arguments);
        }

        public void Remove(Weapon weapon)
        {
            WeaponHash key = weapon.Hash;
            if (this._weapons.ContainsKey(key))
            {
                this._weapons.Remove(key);
            }
            this.Remove(weapon.Hash);
        }

        public void Remove(WeaponHash weaponHash)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, weaponHash };
            Function.Call(Hash.REMOVE_WEAPON_FROM_PED, arguments);
        }

        public void RemoveAll()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, true };
            Function.Call(Hash.REMOVE_ALL_PED_WEAPONS, arguments);
            this._weapons.Clear();
        }

        public bool Select(Weapon weapon)
        {
            if (!weapon.IsPresent)
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, weapon.Hash, true };
            Function.Call(Hash.SET_CURRENT_PED_WEAPON, arguments);
            return true;
        }

        public bool Select(WeaponHash weaponHash) => 
            this.Select(weaponHash, true);

        public bool Select(WeaponHash weaponHash, bool equipNow)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, weaponHash };
            if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, arguments))
            {
                return false;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { this._owner.Handle, weaponHash, equipNow };
            Function.Call(Hash.SET_CURRENT_PED_WEAPON, argumentArray2);
            return true;
        }

        public Weapon this[WeaponHash hash]
        {
            get
            {
                Weapon weapon = null;
                if (!this._weapons.TryGetValue(hash, out weapon))
                {
                    InputArgument[] arguments = new InputArgument[] { this._owner.Handle, hash, 0 };
                    if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, arguments))
                    {
                        return null;
                    }
                    weapon = new Weapon(this._owner, hash);
                    this._weapons.Add(hash, weapon);
                }
                return weapon;
            }
        }

        public Weapon Current
        {
            get
            {
                int num;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num, true };
                Function.Call(Hash.GET_CURRENT_PED_WEAPON, arguments);
                WeaponHash key = (WeaponHash) num;
                if (this._weapons.ContainsKey(key))
                {
                    return this._weapons[key];
                }
                Weapon weapon = new Weapon(this._owner, key);
                this._weapons.Add(key, weapon);
                return weapon;
            }
        }

        public Prop CurrentWeaponObject
        {
            get
            {
                if (this.Current.Hash == ((WeaponHash) (-1569615261)))
                {
                    return null;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return new Prop(Function.Call<int>(Hash.GET_CURRENT_PED_WEAPON_ENTITY_INDEX, arguments));
            }
        }

        public Weapon BestWeapon
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, 0 };
                WeaponHash key = Function.Call<WeaponHash>(Hash.GET_BEST_PED_WEAPON, arguments);
                if (this._weapons.ContainsKey(key))
                {
                    return this._weapons[key];
                }
                Weapon weapon = new Weapon(this._owner, key);
                this._weapons.Add(key, weapon);
                return weapon;
            }
        }
    }
}

