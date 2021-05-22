// Decompiled with JetBrains decompiler
// Type: GTA.WeaponComponentCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA
{
  public class WeaponComponentCollection
  {
    private readonly Ped _owner;
    private readonly Weapon _weapon;
    private readonly Dictionary<WeaponComponentHash, WeaponComponent> _weaponComponents = new Dictionary<WeaponComponentHash, WeaponComponent>();
    private readonly WeaponComponentHash[] _components;
    private static readonly InvalidWeaponComponent _invalidComponent = new InvalidWeaponComponent();

    internal WeaponComponentCollection(Ped owner, Weapon weapon)
    {
      this._owner = owner;
      this._weapon = weapon;
      this._components = WeaponComponentCollection.GetComponentsFromHash(weapon.Hash);
    }

    public WeaponComponent this[WeaponComponentHash componentHash]
    {
      get
      {
        if (!((IEnumerable<WeaponComponentHash>) this._components).Contains<WeaponComponentHash>(componentHash))
          return (WeaponComponent) WeaponComponentCollection._invalidComponent;
        WeaponComponent weaponComponent = (WeaponComponent) null;
        if (!this._weaponComponents.TryGetValue(componentHash, out weaponComponent))
        {
          weaponComponent = new WeaponComponent(this._owner, this._weapon, componentHash);
          this._weaponComponents.Add(componentHash, weaponComponent);
        }
        return weaponComponent;
      }
    }

    public WeaponComponent this[int index]
    {
      get
      {
        WeaponComponent weaponComponent = (WeaponComponent) null;
        if (index < 0 || index >= this.Count)
          return (WeaponComponent) WeaponComponentCollection._invalidComponent;
        WeaponComponentHash component = this._components[index];
        if (!this._weaponComponents.TryGetValue(component, out weaponComponent))
        {
          weaponComponent = new WeaponComponent(this._owner, this._weapon, component);
          this._weaponComponents.Add(component, weaponComponent);
        }
        return weaponComponent;
      }
    }

    public int Count => this._components.Length;

    public IEnumerator<WeaponComponent> GetEnumerator()
    {
      WeaponComponent[] weaponComponentArray = new WeaponComponent[this.Count];
      for (int index = 0; index < this.Count; ++index)
        weaponComponentArray[index] = this[this._components[index]];
      return ((IEnumerable<WeaponComponent>) weaponComponentArray).GetEnumerator();
    }

    public WeaponComponent GetClipComponent(int index)
    {
      foreach (WeaponComponent weaponComponent in this)
      {
        if ((weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Clip || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Clip2) && index-- == 0)
          return weaponComponent;
      }
      return (WeaponComponent) WeaponComponentCollection._invalidComponent;
    }

    public int ClipVariationsCount
    {
      get
      {
        int num = 0;
        foreach (WeaponComponent weaponComponent in this)
        {
          if (weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Clip || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Clip2)
            ++num;
        }
        return num;
      }
    }

    public WeaponComponent GetScopeComponent(int index)
    {
      foreach (WeaponComponent weaponComponent in this)
      {
        if ((weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Scope || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Scope2) && index-- == 0)
          return weaponComponent;
      }
      return (WeaponComponent) WeaponComponentCollection._invalidComponent;
    }

    public int ScopeVariationsCount
    {
      get
      {
        int num = 0;
        foreach (WeaponComponent weaponComponent in this)
        {
          if (weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Scope || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Scope2)
            ++num;
        }
        return num;
      }
    }

    public WeaponComponent GetSuppressorComponent()
    {
      foreach (WeaponComponent weaponComponent in this)
      {
        if (weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Supp || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.Supp2)
          return weaponComponent;
      }
      return (WeaponComponent) WeaponComponentCollection._invalidComponent;
    }

    public WeaponComponent GetFlashLightComponent()
    {
      foreach (WeaponComponent weaponComponent in this)
      {
        if (weaponComponent.AttachmentPoint == ComponentAttachmentPoint.FlashLaser || weaponComponent.AttachmentPoint == ComponentAttachmentPoint.FlashLaser2)
          return weaponComponent;
      }
      return (WeaponComponent) WeaponComponentCollection._invalidComponent;
    }

    public WeaponComponent GetLuxuryFinishComponent()
    {
      foreach (WeaponComponent weaponComponent in this)
      {
        if (weaponComponent.AttachmentPoint == ComponentAttachmentPoint.GunRoot)
          return weaponComponent;
      }
      return (WeaponComponent) WeaponComponentCollection._invalidComponent;
    }

    public static unsafe WeaponComponentHash[] GetComponentsFromHash(
      WeaponHash hash)
    {
      switch (hash)
      {
        case WeaponHash.SniperRifle:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.SniperRifleClip01,
            WeaponComponentHash.AtScopeLarge,
            WeaponComponentHash.AtScopeMax,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.SniperRifleVarmodLuxe
          };
        case WeaponHash.CombatPDW:
          return new WeaponComponentHash[6]
          {
            WeaponComponentHash.CombatPDWClip01,
            WeaponComponentHash.CombatPDWClip02,
            WeaponComponentHash.CombatPDWClip03,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeSmall,
            WeaponComponentHash.AtArAfGrip
          };
        case WeaponHash.HeavySniper:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.HeavySniperClip01,
            WeaponComponentHash.AtScopeLarge,
            WeaponComponentHash.AtScopeMax
          };
        case WeaponHash.MicroSMG:
          return new WeaponComponentHash[6]
          {
            WeaponComponentHash.MicroSMGClip01,
            WeaponComponentHash.MicroSMGClip02,
            WeaponComponentHash.AtPiFlsh,
            WeaponComponentHash.AtScopeMacro,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.MicroSMGVarmodLuxe
          };
        case WeaponHash.Pistol:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.PistolClip01,
            WeaponComponentHash.PistolClip02,
            WeaponComponentHash.AtPiFlsh,
            WeaponComponentHash.AtPiSupp02,
            WeaponComponentHash.PistolVarmodLuxe
          };
        case WeaponHash.PumpShotgun:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.AtSrSupp,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.PumpShotgunVarmodLowrider
          };
        case WeaponHash.APPistol:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.APPistolClip01,
            WeaponComponentHash.APPistolClip02,
            WeaponComponentHash.AtPiFlsh,
            WeaponComponentHash.AtPiSupp,
            WeaponComponentHash.APPistolVarmodLuxe
          };
        case WeaponHash.SMG:
          return new WeaponComponentHash[8]
          {
            WeaponComponentHash.SMGClip01,
            WeaponComponentHash.SMGClip02,
            WeaponComponentHash.SMGClip03,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtPiSupp,
            WeaponComponentHash.AtScopeMacro02,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.SMGVarmodLuxe
          };
        case WeaponHash.Minigun:
          return new WeaponComponentHash[1]
          {
            WeaponComponentHash.MinigunClip01
          };
        case WeaponHash.CombatPistol:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.CombatPistolClip01,
            WeaponComponentHash.CombatPistolClip02,
            WeaponComponentHash.AtPiFlsh,
            WeaponComponentHash.AtPiSupp,
            WeaponComponentHash.CombatPistolVarmodLowrider
          };
        case WeaponHash.SawnOffShotgun:
          return new WeaponComponentHash[1]
          {
            WeaponComponentHash.SawnoffShotgunVarmodLuxe
          };
        case WeaponHash.BullpupRifle:
          return new WeaponComponentHash[7]
          {
            WeaponComponentHash.BullpupRifleClip01,
            WeaponComponentHash.BullpupRifleClip02,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeSmall,
            WeaponComponentHash.AtArSupp,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.BullpupRifleVarmodLow
          };
        case WeaponHash.CombatMG:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.CombatMGClip01,
            WeaponComponentHash.CombatMGClip02,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtScopeMedium,
            WeaponComponentHash.CombatMGVarmodLowrider
          };
        case WeaponHash.CarbineRifle:
          return new WeaponComponentHash[9]
          {
            WeaponComponentHash.CarbineRifleClip01,
            WeaponComponentHash.CarbineRifleClip02,
            WeaponComponentHash.CarbineRifleClip03,
            WeaponComponentHash.AtRailCover01,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeMedium,
            WeaponComponentHash.AtArSupp,
            WeaponComponentHash.CarbineRifleVarmodLuxe
          };
        case WeaponHash.Pistol50:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.Pistol50Clip01,
            WeaponComponentHash.Pistol50Clip02,
            WeaponComponentHash.AtPiFlsh,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.Pistol50VarmodLuxe
          };
        case WeaponHash.MG:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.MGClip01,
            WeaponComponentHash.MGClip02,
            WeaponComponentHash.AtScopeSmall02,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.MGVarmodLowrider
          };
        case WeaponHash.BullpupShotgun:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtArSupp02
          };
        case WeaponHash.GrenadeLauncher:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeSmall
          };
        case WeaponHash.AdvancedRifle:
          return new WeaponComponentHash[6]
          {
            WeaponComponentHash.AdvancedRifleClip01,
            WeaponComponentHash.AdvancedRifleClip02,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeSmall,
            WeaponComponentHash.AtArSupp,
            WeaponComponentHash.AdvancedRifleVarmodLuxe
          };
        case WeaponHash.SNSPistol:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.SNSPistolClip01,
            WeaponComponentHash.SNSPistolClip02,
            WeaponComponentHash.SNSPistolVarmodLowrider
          };
        case WeaponHash.AssaultRifle:
          return new WeaponComponentHash[8]
          {
            WeaponComponentHash.AssaultRifleClip01,
            WeaponComponentHash.AssaultRifleClip02,
            WeaponComponentHash.AssaultRifleClip03,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeMacro,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.AssaultRifleVarmodLuxe
          };
        case WeaponHash.SpecialCarbine:
          return new WeaponComponentHash[8]
          {
            WeaponComponentHash.SpecialCarbineClip01,
            WeaponComponentHash.SpecialCarbineClip02,
            WeaponComponentHash.SpecialCarbineClip03,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeMedium,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.SpecialCarbineVarmodLowrider
          };
        case WeaponHash.Revolver:
          return new WeaponComponentHash[3]
          {
            WeaponComponentHash.RevolverClip01,
            WeaponComponentHash.RevolverVarmodBoss,
            WeaponComponentHash.RevolverVarmodGoon
          };
        case WeaponHash.KnuckleDuster:
          return new WeaponComponentHash[9]
          {
            WeaponComponentHash.KnuckleVarmodPimp,
            WeaponComponentHash.KnuckleVarmodBallas,
            WeaponComponentHash.KnuckleVarmodDollar,
            WeaponComponentHash.KnuckleVarmodDiamond,
            WeaponComponentHash.KnuckleVarmodHate,
            WeaponComponentHash.KnuckleVarmodLove,
            WeaponComponentHash.KnuckleVarmodPlayer,
            WeaponComponentHash.KnuckleVarmodKing,
            WeaponComponentHash.KnuckleVarmodVagos
          };
        case WeaponHash.MachinePistol:
          return new WeaponComponentHash[4]
          {
            WeaponComponentHash.MachinePistolClip01,
            WeaponComponentHash.MachinePistolClip02,
            WeaponComponentHash.MachinePistolClip03,
            WeaponComponentHash.AtPiSupp
          };
        case WeaponHash.SwitchBlade:
          return new WeaponComponentHash[2]
          {
            WeaponComponentHash.SwitchbladeVarmodVar1,
            WeaponComponentHash.SwitchbladeVarmodVar2
          };
        case WeaponHash.AssaultShotgun:
          return new WeaponComponentHash[5]
          {
            WeaponComponentHash.AssaultShotgunClip01,
            WeaponComponentHash.AssaultShotgunClip02,
            WeaponComponentHash.AtArAfGrip,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtArSupp
          };
        case WeaponHash.AssaultSMG:
          return new WeaponComponentHash[6]
          {
            WeaponComponentHash.AssaultSMGClip01,
            WeaponComponentHash.AssaultSMGClip02,
            WeaponComponentHash.AtArFlsh,
            WeaponComponentHash.AtScopeMacro,
            WeaponComponentHash.AtArSupp02,
            WeaponComponentHash.AssaultSMGVarmodLowrider
          };
        default:
          WeaponComponentHash[] weaponComponentHashArray1 = (WeaponComponentHash[]) null;
          int num = 0;
          for (int index1 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, (InputArgument[]) Array.Empty<InputArgument>()); num < index1; ++num)
          {
            DlcWeaponData dlcWeaponData;
            if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, (InputArgument) num, (InputArgument) (void*) &dlcWeaponData) && dlcWeaponData.Hash == hash)
            {
              WeaponComponentHash[] weaponComponentHashArray2 = new WeaponComponentHash[Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, (InputArgument) num)];
              for (int index2 = 0; index2 < weaponComponentHashArray2.Length; ++index2)
              {
                DlcWeaponComponentData weaponComponentData;
                InputArgument[] inputArgumentArray = new InputArgument[3]
                {
                  (InputArgument) num,
                  (InputArgument) index2,
                  (InputArgument) (void*) &weaponComponentData
                };
                weaponComponentHashArray2[index2] = !Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, inputArgumentArray) ? WeaponComponentHash.Invalid : weaponComponentData.Hash;
              }
              return weaponComponentHashArray2;
            }
          }
          if (weaponComponentHashArray1 == null)
            weaponComponentHashArray1 = new WeaponComponentHash[0];
          return weaponComponentHashArray1;
      }
    }
  }
}
