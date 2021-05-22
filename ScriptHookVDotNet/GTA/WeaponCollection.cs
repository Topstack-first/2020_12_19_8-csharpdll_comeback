// Decompiled with JetBrains decompiler
// Type: GTA.WeaponCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;

namespace GTA
{
  public sealed class WeaponCollection
  {
    private Ped _owner;
    private readonly Dictionary<WeaponHash, Weapon> _weapons = new Dictionary<WeaponHash, Weapon>();

    internal WeaponCollection(Ped owner) => this._owner = owner;

    public Weapon this[WeaponHash hash]
    {
      get
      {
        Weapon weapon = (Weapon) null;
        if (!this._weapons.TryGetValue(hash, out weapon))
        {
          if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) hash, (InputArgument) 0))
            return (Weapon) null;
          weapon = new Weapon(this._owner, hash);
          this._weapons.Add(hash, weapon);
        }
        return weapon;
      }
    }

    public unsafe Weapon Current
    {
      get
      {
        int num;
        Function.Call(Hash.GET_CURRENT_PED_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num, (InputArgument) true);
        WeaponHash weaponHash = (WeaponHash) num;
        if (this._weapons.ContainsKey(weaponHash))
          return this._weapons[weaponHash];
        Weapon weapon = new Weapon(this._owner, weaponHash);
        this._weapons.Add(weaponHash, weapon);
        return weapon;
      }
    }

    public Prop CurrentWeaponObject
    {
      get
      {
        if (this.Current.Hash == WeaponHash.Unarmed)
          return (Prop) null;
        return new Prop(Function.Call<int>(Hash.GET_CURRENT_PED_WEAPON_ENTITY_INDEX, (InputArgument) this._owner.Handle));
      }
    }

    public Weapon BestWeapon
    {
      get
      {
        WeaponHash weaponHash = Function.Call<WeaponHash>(Hash.GET_BEST_PED_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) 0);
        if (this._weapons.ContainsKey(weaponHash))
          return this._weapons[weaponHash];
        Weapon weapon = new Weapon(this._owner, weaponHash);
        this._weapons.Add(weaponHash, weapon);
        return weapon;
      }
    }

    public bool HasWeapon(WeaponHash weaponHash) => Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weaponHash);

    public bool IsWeaponValid(WeaponHash hash) => Function.Call<bool>(Hash.IS_WEAPON_VALID, (InputArgument) (Enum) hash);

    public Weapon Give(WeaponHash hash, int ammoCount, bool equipNow, bool isAmmoLoaded)
    {
      Weapon weapon = (Weapon) null;
      if (!this._weapons.TryGetValue(hash, out weapon))
      {
        weapon = new Weapon(this._owner, hash);
        this._weapons.Add(hash, weapon);
      }
      if (weapon.IsPresent)
        this.Select(weapon);
      else
        Function.Call(Hash.GIVE_WEAPON_TO_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weapon.Hash, (InputArgument) ammoCount, (InputArgument) equipNow, (InputArgument) isAmmoLoaded);
      return weapon;
    }

    public bool Select(Weapon weapon)
    {
      if (!weapon.IsPresent)
        return false;
      Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weapon.Hash, (InputArgument) true);
      return true;
    }

    public bool Select(WeaponHash weaponHash) => this.Select(weaponHash, true);

    public bool Select(WeaponHash weaponHash, bool equipNow)
    {
      if (!Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weaponHash))
        return false;
      Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weaponHash, (InputArgument) equipNow);
      return true;
    }

    public void Drop() => Function.Call(Hash.SET_PED_DROPS_WEAPON, (InputArgument) this._owner.Handle);

    public void Remove(Weapon weapon)
    {
      WeaponHash hash = weapon.Hash;
      if (this._weapons.ContainsKey(hash))
        this._weapons.Remove(hash);
      this.Remove(weapon.Hash);
    }

    public void Remove(WeaponHash weaponHash) => Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) weaponHash);

    public void RemoveAll()
    {
      Function.Call(Hash.REMOVE_ALL_PED_WEAPONS, (InputArgument) this._owner.Handle, (InputArgument) true);
      this._weapons.Clear();
    }
  }
}
