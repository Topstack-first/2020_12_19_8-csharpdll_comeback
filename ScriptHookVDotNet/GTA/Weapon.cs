// Decompiled with JetBrains decompiler
// Type: GTA.Weapon
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public sealed class Weapon
  {
    private Ped _owner;
    private WeaponComponentCollection _components;

    internal Weapon() => this.Hash = WeaponHash.Unarmed;

    internal Weapon(Ped owner, WeaponHash hash)
    {
      this._owner = owner;
      this.Hash = hash;
    }

    public WeaponHash Hash { get; private set; }

    public static implicit operator WeaponHash(Weapon weapon) => weapon.Hash;

    public bool IsPresent
    {
      get
      {
        if (this.Hash == WeaponHash.Unarmed)
          return true;
        return Function.Call<bool>(GTA.Native.Hash.HAS_PED_GOT_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash);
      }
    }

    public string DisplayName => Weapon.GetDisplayNameFromHash(this.Hash);

    public string LocalizedName => Game.GetGXTEntry(this.DisplayName);

    public Model Model => new Model(Function.Call<int>(GTA.Native.Hash.GET_WEAPONTYPE_MODEL, (InputArgument) (Enum) this.Hash));

    public WeaponTint Tint
    {
      get => Function.Call<WeaponTint>(GTA.Native.Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash);
      set => Function.Call(GTA.Native.Hash.SET_PED_WEAPON_TINT_INDEX, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) (Enum) value);
    }

    public WeaponGroup Group => Function.Call<WeaponGroup>(GTA.Native.Hash.GET_WEAPONTYPE_GROUP, (InputArgument) (Enum) this.Hash);

    public int Ammo
    {
      get
      {
        if (this.Hash == WeaponHash.Unarmed)
          return 1;
        if (!this.IsPresent)
          return 0;
        return Function.Call<int>(GTA.Native.Hash.GET_AMMO_IN_PED_WEAPON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash);
      }
      set
      {
        if (this.Hash == WeaponHash.Unarmed)
          return;
        if (this.IsPresent)
          Function.Call(GTA.Native.Hash.SET_PED_AMMO, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) value);
        else
          Function.Call(GTA.Native.Hash.GIVE_WEAPON_TO_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) value, (InputArgument) false, (InputArgument) true);
      }
    }

    public unsafe int AmmoInClip
    {
      get
      {
        if (this.Hash == WeaponHash.Unarmed)
          return 1;
        if (!this.IsPresent)
          return 0;
        int num;
        Function.Call(GTA.Native.Hash.GET_AMMO_IN_CLIP, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) (void*) &num);
        return num;
      }
      set
      {
        if (this.Hash == WeaponHash.Unarmed)
          return;
        if (this.IsPresent)
          Function.Call(GTA.Native.Hash.SET_AMMO_IN_CLIP, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) value);
        else
          Function.Call(GTA.Native.Hash.GIVE_WEAPON_TO_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) value, (InputArgument) true, (InputArgument) false);
      }
    }

    public unsafe int MaxAmmo
    {
      get
      {
        if (this.Hash == WeaponHash.Unarmed)
          return 1;
        int num;
        Function.Call(GTA.Native.Hash.GET_MAX_AMMO, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) (void*) &num);
        return num;
      }
    }

    public int MaxAmmoInClip
    {
      get
      {
        if (this.Hash == WeaponHash.Unarmed)
          return 1;
        if (!this.IsPresent)
          return 0;
        return Function.Call<int>(GTA.Native.Hash.GET_MAX_AMMO_IN_CLIP, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Hash, (InputArgument) true);
      }
    }

    public int DefaultClipSize => Function.Call<int>(GTA.Native.Hash.GET_WEAPON_CLIP_SIZE, (InputArgument) (Enum) this.Hash);

    public bool InfiniteAmmo
    {
      set
      {
        if (this.Hash == WeaponHash.Unarmed)
          return;
        Function.Call(GTA.Native.Hash.SET_PED_INFINITE_AMMO, (InputArgument) this._owner.Handle, (InputArgument) value, (InputArgument) (Enum) this.Hash);
      }
    }

    public bool InfiniteAmmoClip
    {
      set => Function.Call(GTA.Native.Hash.SET_PED_INFINITE_AMMO_CLIP, (InputArgument) this._owner.Handle, (InputArgument) value);
    }

    public bool CanUseOnParachute => Function.Call<bool>(GTA.Native.Hash.CAN_USE_WEAPON_ON_PARACHUTE, (InputArgument) (Enum) this.Hash);

    public WeaponComponentCollection Components
    {
      get
      {
        if (this._components == null)
          this._components = new WeaponComponentCollection(this._owner, this);
        return this._components;
      }
    }

    public static unsafe string GetDisplayNameFromHash(WeaponHash hash)
    {
      switch (hash)
      {
        case WeaponHash.SniperRifle:
          return "WT_SNIP_RIF";
        case WeaponHash.VintagePistol:
          return "TT_VPISTOL";
        case WeaponHash.CombatPDW:
          return "WT_COMBATPDW";
        case WeaponHash.HeavySniper:
          return "WT_SNIP_HVY";
        case WeaponHash.MicroSMG:
          return "WT_SMG_MCR";
        case WeaponHash.Pistol:
          return "WT_PIST";
        case WeaponHash.PumpShotgun:
          return "WT_SG_PMP";
        case WeaponHash.APPistol:
          return "WT_PIST_AP";
        case WeaponHash.SMG:
          return "WT_SMG";
        case WeaponHash.HeavyShotgun:
          return "WT_HVYSHOT";
        case WeaponHash.Minigun:
          return "WT_MINIGUN";
        case WeaponHash.FlareGun:
          return "WT_FLAREGUN";
        case WeaponHash.CombatPistol:
          return "WT_PIST_CBT";
        case WeaponHash.Gusenberg:
          return "WT_GUSENBERG";
        case WeaponHash.CompactRifle:
          return "WT_CMPRIFLE";
        case WeaponHash.HomingLauncher:
          return "WT_HOMLNCH";
        case WeaponHash.SawnOffShotgun:
          return "WT_SG_SOF";
        case WeaponHash.Firework:
          return "WT_FWRKLNCHR";
        case WeaponHash.CombatMG:
          return "WT_MG_CBT";
        case WeaponHash.CarbineRifle:
          return "WT_RIFLE_CBN";
        case WeaponHash.Flashlight:
          return "WT_FLASHLIGHT";
        case WeaponHash.Dagger:
          return "WT_DAGGER";
        case WeaponHash.Pistol50:
          return "WT_PIST_50";
        case WeaponHash.MG:
          return "WT_MG";
        case WeaponHash.BullpupShotgun:
          return "WT_SG_BLP";
        case WeaponHash.GrenadeLauncher:
          return "WT_GL";
        case WeaponHash.Musket:
          return "WT_MUSKET";
        case WeaponHash.ProximityMine:
          return "WT_PRXMINE";
        case WeaponHash.AdvancedRifle:
          return "WT_RIFLE_ADV";
        case WeaponHash.RPG:
          return "WT_RPG";
        case WeaponHash.SNSPistol:
          return "WT_SNSPISTOL";
        case WeaponHash.AssaultRifle:
          return "WT_RIFLE_ASL";
        case WeaponHash.Revolver:
          return "WT_REVOLVER";
        case WeaponHash.MarksmanRifle:
          return "WT_HMKRIFLE";
        case WeaponHash.KnuckleDuster:
          return "WT_KNUCKLE";
        case WeaponHash.MachinePistol:
          return "WT_MCHPIST";
        case WeaponHash.MarksmanPistol:
          return "WT_MKPISTOL";
        case WeaponHash.Machete:
          return "WT_MACHETE";
        case WeaponHash.SwitchBlade:
          return "WT_SWBLADE";
        case WeaponHash.AssaultShotgun:
          return "WT_SG_ASL";
        case WeaponHash.DoubleBarrelShotgun:
          return "WT_DBSHGN";
        case WeaponHash.AssaultSMG:
          return "WT_SMG_ASL";
        case WeaponHash.Bottle:
          return "WT_BOTTLE";
        default:
          int num = 0;
          for (int index = Function.Call<int>(GTA.Native.Hash.GET_NUM_DLC_WEAPONS, (InputArgument[]) Array.Empty<InputArgument>()); num < index; ++num)
          {
            DlcWeaponData dlcWeaponData;
            if (Function.Call<bool>(GTA.Native.Hash.GET_DLC_WEAPON_DATA, (InputArgument) num, (InputArgument) (void*) &dlcWeaponData) && dlcWeaponData.Hash == hash)
              return dlcWeaponData.DisplayName;
          }
          return "WT_INVALID";
      }
    }
  }
}
