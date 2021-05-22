// Decompiled with JetBrains decompiler
// Type: GTA.WeaponComponent
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public class WeaponComponent
  {
    protected readonly Ped _owner;
    protected readonly Weapon _weapon;
    protected readonly WeaponComponentHash _component;

    internal WeaponComponent(Ped owner, Weapon weapon, WeaponComponentHash component)
    {
      this._owner = owner;
      this._weapon = weapon;
      this._component = component;
    }

    public WeaponComponentHash ComponentHash => this._component;

    public static implicit operator WeaponComponentHash(
      WeaponComponent weaponComponent)
    {
      return weaponComponent.ComponentHash;
    }

    public virtual bool Active
    {
      get => Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this._weapon.Hash, (InputArgument) (Enum) this._component);
      set
      {
        if (value)
          Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this._weapon.Hash, (InputArgument) (Enum) this._component);
        else
          Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this._weapon.Hash, (InputArgument) (Enum) this._component);
      }
    }

    public virtual string DisplayName => WeaponComponent.GetComponentDisplayNameFromHash(this._weapon.Hash, this._component);

    public virtual string LocalizedName => Game.GetGXTEntry(this.DisplayName);

    public virtual ComponentAttachmentPoint AttachmentPoint => WeaponComponent.GetAttachmentPoint(this._weapon.Hash, this._component);

    public static unsafe string GetComponentDisplayNameFromHash(
      WeaponHash hash,
      WeaponComponentHash component)
    {
      if (hash == WeaponHash.KnuckleDuster)
      {
        switch (component)
        {
          case WeaponComponentHash.KnuckleVarmodPlayer:
            return "WCT_KNUCK_PC";
          case WeaponComponentHash.KnuckleVarmodLove:
            return "WCT_KNUCK_LV";
          case WeaponComponentHash.KnuckleVarmodDollar:
            return "WCT_KNUCK_DLR";
          case WeaponComponentHash.KnuckleVarmodVagos:
            return "WCT_KNUCK_VG";
          case WeaponComponentHash.KnuckleVarmodHate:
            return "WCT_KNUCK_HT";
          case WeaponComponentHash.KnuckleVarmodDiamond:
            return "WCT_KNUCK_DMD";
          case WeaponComponentHash.KnuckleVarmodPimp:
            return "WCT_KNUCK_02";
          case WeaponComponentHash.KnuckleVarmodKing:
            return "WCT_KNUCK_SLG";
          case WeaponComponentHash.KnuckleVarmodBallas:
            return "WCT_KNUCK_BG";
          case WeaponComponentHash.KnuckleVarmodBase:
            return "WT_KNUCKLE";
        }
      }
      else
      {
        switch (component)
        {
          case WeaponComponentHash.CombatPistolClip01:
          case (WeaponComponentHash) 195735895:
          case WeaponComponentHash.Pistol50Clip01:
          case WeaponComponentHash.APPistolClip01:
          case WeaponComponentHash.HeavyShotgunClip01:
          case WeaponComponentHash.CombatPDWClip01:
          case WeaponComponentHash.VintagePistolClip01:
          case WeaponComponentHash.MachinePistolClip01:
          case WeaponComponentHash.HeavySniperClip01:
          case (WeaponComponentHash) 1525977990:
          case WeaponComponentHash.AssaultSMGClip01:
          case WeaponComponentHash.AssaultShotgunClip01:
          case WeaponComponentHash.SniperRifleClip01:
          case WeaponComponentHash.CarbineRifleClip01:
          case WeaponComponentHash.AssaultRifleClip01:
          case (WeaponComponentHash) 3404452422:
          case WeaponComponentHash.MicroSMGClip01:
          case WeaponComponentHash.MarksmanPistolClip01:
          case WeaponComponentHash.MarksmanRifleClip01:
          case WeaponComponentHash.CombatMGClip01:
          case WeaponComponentHash.MGClip01:
          case WeaponComponentHash.SNSPistolClip01:
          case (WeaponComponentHash) 4170538377:
          case WeaponComponentHash.AdvancedRifleClip01:
          case WeaponComponentHash.PistolClip01:
            return "WCT_CLIP1";
          case WeaponComponentHash.AtArAfGrip:
            return "WCT_GRIP";
          case WeaponComponentHash.MicroSMGClip02:
          case WeaponComponentHash.APPistolClip02:
          case WeaponComponentHash.CombatPDWClip02:
          case WeaponComponentHash.VintagePistolClip02:
          case WeaponComponentHash.SMGClip02:
          case (WeaponComponentHash) 1048471894:
          case (WeaponComponentHash) 1824470811:
          case WeaponComponentHash.SNSPistolClip02:
          case WeaponComponentHash.MGClip02:
          case WeaponComponentHash.AssaultShotgunClip02:
          case WeaponComponentHash.AdvancedRifleClip02:
          case WeaponComponentHash.CarbineRifleClip02:
          case WeaponComponentHash.HeavyShotgunClip02:
          case WeaponComponentHash.AssaultRifleClip02:
          case WeaponComponentHash.MachinePistolClip02:
          case WeaponComponentHash.AssaultSMGClip02:
          case WeaponComponentHash.MinigunClip01:
          case WeaponComponentHash.MarksmanRifleClip02:
          case WeaponComponentHash.CombatPistolClip02:
          case WeaponComponentHash.CombatMGClip02:
          case WeaponComponentHash.Pistol50Clip02:
          case (WeaponComponentHash) 3787849722:
          case WeaponComponentHash.PistolClip02:
            return "WCT_CLIP2";
          case WeaponComponentHash.MarksmanRifleVarmodLuxe:
          case WeaponComponentHash.SMGVarmodLuxe:
          case WeaponComponentHash.AssaultSMGVarmodLowrider:
          case WeaponComponentHash.MicroSMGVarmodLuxe:
          case WeaponComponentHash.AssaultRifleVarmodLuxe:
          case WeaponComponentHash.PumpShotgunVarmodLowrider:
          case WeaponComponentHash.CombatPistolVarmodLowrider:
          case WeaponComponentHash.MGVarmodLowrider:
          case WeaponComponentHash.PistolVarmodLuxe:
          case WeaponComponentHash.CarbineRifleVarmodLuxe:
            return "WCT_VAR_GOLD";
          case WeaponComponentHash.RevolverVarmodBoss:
            return "WCT_REV_VARB";
          case WeaponComponentHash.AtScopeLargeFixedZoom:
            return "WCT_SCOPE_LRG";
          case WeaponComponentHash.AtPiFlsh:
          case WeaponComponentHash.AtArFlsh:
            return "WCT_FLASH";
          case WeaponComponentHash.AdvancedRifleVarmodLuxe:
          case WeaponComponentHash.SawnoffShotgunVarmodLuxe:
          case WeaponComponentHash.APPistolVarmodLuxe:
          case WeaponComponentHash.BullpupRifleVarmodLow:
            return "WCT_VAR_METAL";
          case WeaponComponentHash.AtScopeSmall02:
            return "WCT_SCOPE_SML";
          case WeaponComponentHash.AtScopeMacro02:
            return "WCT_SCOPE_MAC";
          case WeaponComponentHash.SniperRifleVarmodLuxe:
          case WeaponComponentHash.HeavyPistolVarmodLuxe:
          case WeaponComponentHash.SNSPistolVarmodLowrider:
            return "WCT_VAR_WOOD";
          case WeaponComponentHash.SwitchbladeVarmodVar1:
            return "WCT_SB_VAR1";
          case WeaponComponentHash.AtPiSupp02:
            return "WCT_SUPP";
          case WeaponComponentHash.SpecialCarbineVarmodLowrider:
          case WeaponComponentHash.CombatMGVarmodLowrider:
            return "WCT_VAR_ETCHM";
          case WeaponComponentHash.AtRailCover01:
            return "WCT_RAIL";
          case WeaponComponentHash.Pistol50VarmodLuxe:
            return "WCT_VAR_SIL";
          case WeaponComponentHash.SMGClip03:
          case WeaponComponentHash.HeavyShotgunClip03:
          case WeaponComponentHash.AssaultRifleClip03:
            return "WCT_CLIP_DRM";
          case WeaponComponentHash.AtArSupp:
          case WeaponComponentHash.AtArSupp02:
          case WeaponComponentHash.AtPiSupp:
          case WeaponComponentHash.AtSrSupp:
            return "WCT_SUPP";
          case WeaponComponentHash.SwitchbladeVarmodBase:
            return "WCT_SB_BASE";
          case WeaponComponentHash.RevolverVarmodGoon:
            return "WCT_REV_VARG";
          case WeaponComponentHash.AtScopeMacro:
            return "WCT_SCOPE_MAC";
          case WeaponComponentHash.AtScopeMedium:
            return "WCT_SCOPE_MED";
          case WeaponComponentHash.AtScopeSmall:
            return "WCT_SCOPE_SML";
          case WeaponComponentHash.CarbineRifleClip03:
            return "WCT_CLIP_BOX";
          case WeaponComponentHash.AtScopeMax:
            return "WCT_SCOPE_MAX";
          case WeaponComponentHash.AtScopeLarge:
            return "WCT_SCOPE_LRG";
          case WeaponComponentHash.SwitchbladeVarmodVar2:
            return "WCT_SB_VAR2";
          case WeaponComponentHash.RevolverClip01:
            return "WCT_CLIP1";
          case WeaponComponentHash.Invalid:
            return "WCT_INVALID";
        }
      }
      string str = "WCT_INVALID";
      int num1 = 0;
      for (int index1 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, (InputArgument[]) Array.Empty<InputArgument>()); num1 < index1; ++num1)
      {
        DlcWeaponData dlcWeaponData;
        if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, (InputArgument) num1, (InputArgument) (void*) &dlcWeaponData) && dlcWeaponData.Hash == hash)
        {
          int num2 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, (InputArgument) num1);
          for (int index2 = 0; index2 < num2; ++index2)
          {
            DlcWeaponComponentData weaponComponentData;
            if (Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, (InputArgument) num1, (InputArgument) index2, (InputArgument) (void*) &weaponComponentData) && weaponComponentData.Hash == component)
              return weaponComponentData.DisplayName;
          }
          break;
        }
      }
      return str;
    }

    public static unsafe ComponentAttachmentPoint GetAttachmentPoint(
      WeaponHash hash,
      WeaponComponentHash componentHash)
    {
      switch (hash)
      {
        case WeaponHash.SniperRifle:
          switch (componentHash)
          {
            case WeaponComponentHash.SniperRifleVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.SniperRifleClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.AtScopeMax:
            case WeaponComponentHash.AtScopeLarge:
              return ComponentAttachmentPoint.Scope;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.HeavySniper:
          switch (componentHash)
          {
            case WeaponComponentHash.HeavySniperClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtScopeMax:
            case WeaponComponentHash.AtScopeLarge:
              return ComponentAttachmentPoint.Scope;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.MicroSMG:
          switch (componentHash)
          {
            case WeaponComponentHash.MicroSMGClip02:
            case WeaponComponentHash.MicroSMGClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtPiFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.MicroSMGVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtScopeMacro:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.Pistol:
          switch (componentHash)
          {
            case WeaponComponentHash.AtPiFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtPiSupp02:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.PistolVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.PistolClip02:
            case WeaponComponentHash.PistolClip01:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.PumpShotgun:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtArSupp:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.PumpShotgunVarmodLowrider:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.PumpShotgunClip01:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.APPistol:
          switch (componentHash)
          {
            case WeaponComponentHash.APPistolClip02:
            case WeaponComponentHash.APPistolClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtPiFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.APPistolVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtPiSupp:
              return ComponentAttachmentPoint.Supp;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.SMG:
          switch (componentHash)
          {
            case WeaponComponentHash.SMGClip01:
            case WeaponComponentHash.SMGClip02:
            case WeaponComponentHash.SMGClip03:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.SMGVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtScopeMacro02:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtPiSupp:
              return ComponentAttachmentPoint.Supp;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.Minigun:
          return componentHash == WeaponComponentHash.MinigunClip01 ? ComponentAttachmentPoint.Clip : ComponentAttachmentPoint.Invalid;
        case WeaponHash.CombatPistol:
          switch (componentHash)
          {
            case WeaponComponentHash.CombatPistolClip01:
            case WeaponComponentHash.CombatPistolClip02:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtPiFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtPiSupp:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.CombatPistolVarmodLowrider:
              return ComponentAttachmentPoint.GunRoot;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.SawnOffShotgun:
          if (componentHash == WeaponComponentHash.SawnoffShotgunVarmodLuxe)
            return ComponentAttachmentPoint.GunRoot;
          return componentHash == WeaponComponentHash.SawnoffShotgunClip01 ? ComponentAttachmentPoint.Clip : ComponentAttachmentPoint.Invalid;
        case WeaponHash.CombatMG:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.CombatMGVarmodLowrider:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtScopeMedium:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.CombatMGClip02:
            case WeaponComponentHash.CombatMGClip01:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.CarbineRifle:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.AtRailCover01:
              return ComponentAttachmentPoint.Rail;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtArSupp:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.CarbineRifleClip02:
            case WeaponComponentHash.CarbineRifleClip01:
            case WeaponComponentHash.CarbineRifleClip03:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtScopeMedium:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.CarbineRifleVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.Pistol50:
          switch (componentHash)
          {
            case WeaponComponentHash.Pistol50Clip01:
            case WeaponComponentHash.Pistol50Clip02:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtPiFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.Pistol50VarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.MG:
          switch (componentHash)
          {
            case WeaponComponentHash.AtScopeSmall02:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.MGClip02:
            case WeaponComponentHash.MGClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.MGVarmodLowrider:
              return ComponentAttachmentPoint.GunRoot;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.BullpupShotgun:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.BullpupShotgunClip01:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.GrenadeLauncher:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.GrenadeLauncherClip01:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtScopeSmall:
              return ComponentAttachmentPoint.Scope;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.AdvancedRifle:
          switch (componentHash)
          {
            case WeaponComponentHash.AdvancedRifleVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtArSupp:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.AdvancedRifleClip02:
            case WeaponComponentHash.AdvancedRifleClip01:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtScopeSmall:
              return ComponentAttachmentPoint.Scope;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.AssaultRifle:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.AssaultRifleVarmodLuxe:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtScopeMacro:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.AssaultRifleClip02:
            case WeaponComponentHash.AssaultRifleClip01:
            case WeaponComponentHash.AssaultRifleClip03:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.AssaultShotgun:
          switch (componentHash)
          {
            case WeaponComponentHash.AtArAfGrip:
              return ComponentAttachmentPoint.Grip;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AtArSupp:
              return ComponentAttachmentPoint.Supp;
            case WeaponComponentHash.AssaultShotgunClip02:
            case WeaponComponentHash.AssaultShotgunClip01:
              return ComponentAttachmentPoint.Clip;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        case WeaponHash.AssaultSMG:
          switch (componentHash)
          {
            case WeaponComponentHash.AssaultSMGVarmodLowrider:
              return ComponentAttachmentPoint.GunRoot;
            case WeaponComponentHash.AtArFlsh:
              return ComponentAttachmentPoint.FlashLaser;
            case WeaponComponentHash.AssaultSMGClip01:
            case WeaponComponentHash.AssaultSMGClip02:
              return ComponentAttachmentPoint.Clip;
            case WeaponComponentHash.AtScopeMacro:
              return ComponentAttachmentPoint.Scope;
            case WeaponComponentHash.AtArSupp02:
              return ComponentAttachmentPoint.Supp;
            default:
              return ComponentAttachmentPoint.Invalid;
          }
        default:
          int num1 = 0;
          for (int index1 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, (InputArgument[]) Array.Empty<InputArgument>()); num1 < index1; ++num1)
          {
            DlcWeaponData dlcWeaponData;
            if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, (InputArgument) num1, (InputArgument) (void*) &dlcWeaponData) && dlcWeaponData.Hash == hash)
            {
              int num2 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, (InputArgument) num1);
              for (int index2 = 0; index2 < num2; ++index2)
              {
                DlcWeaponComponentData weaponComponentData;
                if (Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, (InputArgument) num1, (InputArgument) index2, (InputArgument) (void*) &weaponComponentData) && weaponComponentData.Hash == componentHash)
                  return weaponComponentData.AttachPoint;
              }
              break;
            }
          }
          return ComponentAttachmentPoint.Invalid;
      }
    }
  }
}
