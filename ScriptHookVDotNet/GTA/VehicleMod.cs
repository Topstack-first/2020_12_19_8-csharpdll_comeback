// Decompiled with JetBrains decompiler
// Type: GTA.VehicleMod
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GTA
{
  public sealed class VehicleMod
  {
    private Vehicle _owner;
    private static readonly ReadOnlyDictionary<int, Tuple<string, string>> _hornNames = new ReadOnlyDictionary<int, Tuple<string, string>>((IDictionary<int, Tuple<string, string>>) new Dictionary<int, Tuple<string, string>>()
    {
      {
        -1,
        new Tuple<string, string>("CMOD_HRN_0", "Stock Horn")
      },
      {
        0,
        new Tuple<string, string>("CMOD_HRN_TRK", "Truck Horn")
      },
      {
        1,
        new Tuple<string, string>("CMOD_HRN_COP", "Cop Horn")
      },
      {
        2,
        new Tuple<string, string>("CMOD_HRN_CLO", "Clown Horn")
      },
      {
        3,
        new Tuple<string, string>("CMOD_HRN_MUS1", "Musical Horn 1")
      },
      {
        4,
        new Tuple<string, string>("CMOD_HRN_MUS2", "Musical Horn 2")
      },
      {
        5,
        new Tuple<string, string>("CMOD_HRN_MUS3", "Musical Horn 3")
      },
      {
        6,
        new Tuple<string, string>("CMOD_HRN_MUS4", "Musical Horn 4")
      },
      {
        7,
        new Tuple<string, string>("CMOD_HRN_MUS5", "Musical Horn 5")
      },
      {
        8,
        new Tuple<string, string>("CMOD_HRN_SAD", "Sad Trombone")
      },
      {
        9,
        new Tuple<string, string>("HORN_CLAS1", "Classical Horn 1")
      },
      {
        10,
        new Tuple<string, string>("HORN_CLAS2", "Classical Horn 2")
      },
      {
        11,
        new Tuple<string, string>("HORN_CLAS3", "Classical Horn 3")
      },
      {
        12,
        new Tuple<string, string>("HORN_CLAS4", "Classical Horn 4")
      },
      {
        13,
        new Tuple<string, string>("HORN_CLAS5", "Classical Horn 5")
      },
      {
        14,
        new Tuple<string, string>("HORN_CLAS6", "Classical Horn 6")
      },
      {
        15,
        new Tuple<string, string>("HORN_CLAS7", "Classical Horn 7")
      },
      {
        16,
        new Tuple<string, string>("HORN_CNOTE_C0", "Scale Do")
      },
      {
        17,
        new Tuple<string, string>("HORN_CNOTE_D0", "Scale Re")
      },
      {
        18,
        new Tuple<string, string>("HORN_CNOTE_E0", "Scale Mi")
      },
      {
        19,
        new Tuple<string, string>("HORN_CNOTE_F0", "Scale Fa")
      },
      {
        20,
        new Tuple<string, string>("HORN_CNOTE_G0", "Scale Sol")
      },
      {
        21,
        new Tuple<string, string>("HORN_CNOTE_A0", "Scale La")
      },
      {
        22,
        new Tuple<string, string>("HORN_CNOTE_B0", "Scale Ti")
      },
      {
        23,
        new Tuple<string, string>("HORN_CNOTE_C1", "Scale Do (High)")
      },
      {
        24,
        new Tuple<string, string>("HORN_HIPS1", "Jazz Horn 1")
      },
      {
        25,
        new Tuple<string, string>("HORN_HIPS2", "Jazz Horn 2")
      },
      {
        26,
        new Tuple<string, string>("HORN_HIPS3", "Jazz Horn 3")
      },
      {
        27,
        new Tuple<string, string>("HORN_HIPS4", "Jazz Horn Loop")
      },
      {
        28,
        new Tuple<string, string>("HORN_INDI_1", "Star Spangled Banner 1")
      },
      {
        29,
        new Tuple<string, string>("HORN_INDI_2", "Star Spangled Banner 2")
      },
      {
        30,
        new Tuple<string, string>("HORN_INDI_3", "Star Spangled Banner 3")
      },
      {
        31,
        new Tuple<string, string>("HORN_INDI_4", "Star Spangled Banner 4")
      },
      {
        32,
        new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1")
      },
      {
        33,
        new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8")
      },
      {
        34,
        new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2")
      },
      {
        35,
        new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1")
      },
      {
        36,
        new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8")
      },
      {
        37,
        new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2")
      },
      {
        38,
        new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1")
      },
      {
        39,
        new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1")
      },
      {
        40,
        new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2")
      },
      {
        41,
        new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2")
      },
      {
        42,
        new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop")
      },
      {
        43,
        new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop")
      },
      {
        44,
        new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop")
      },
      {
        45,
        new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop")
      },
      {
        46,
        new Tuple<string, string>("HORN_XM15_1", "Festive Loop 1")
      },
      {
        47,
        new Tuple<string, string>("HORN_XM15_2", "Festive Loop 2")
      },
      {
        48,
        new Tuple<string, string>("HORN_XM15_3", "Festive Loop 3")
      }
    });

    internal VehicleMod(Vehicle owner, VehicleModType modType)
    {
      this._owner = owner;
      this.ModType = modType;
    }

    public VehicleModType ModType { get; private set; }

    public int Index
    {
      get => Function.Call<int>(Hash.GET_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
      set => Function.Call(Hash.SET_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) value, (InputArgument) this.Variation);
    }

    public bool Variation
    {
      get => Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
      set => Function.Call(Hash.SET_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) this.Index, (InputArgument) value);
    }

    public string LocalizedModTypeName
    {
      get
      {
        if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, (InputArgument) "mod_mnu", (InputArgument) 10))
        {
          Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, (InputArgument) 10, (InputArgument) true);
          Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, (InputArgument) "mod_mnu", (InputArgument) 10);
        }
        string entry;
        switch (this.ModType)
        {
          case VehicleModType.Engine:
            entry = Game.GetGXTEntry("CMOD_MOD_ENG");
            break;
          case VehicleModType.Brakes:
            entry = Game.GetGXTEntry("CMOD_MOD_BRA");
            break;
          case VehicleModType.Transmission:
            entry = Game.GetGXTEntry("CMOD_MOD_TRN");
            break;
          case VehicleModType.Horns:
            entry = Game.GetGXTEntry("CMOD_MOD_HRN");
            break;
          case VehicleModType.Suspension:
            entry = Game.GetGXTEntry("CMOD_MOD_SUS");
            break;
          case VehicleModType.Armor:
            entry = Game.GetGXTEntry("CMOD_MOD_ARM");
            break;
          case VehicleModType.FrontWheel:
            Model model = this._owner.Model;
            if (!model.IsBike)
            {
              model = this._owner.Model;
              if (model.IsBicycle)
              {
                entry = Game.GetGXTEntry("CMOD_MOD_WHEM");
                if (entry == "")
                  return "Wheels";
                break;
              }
            }
            entry = Game.GetGXTEntry("CMOD_WHE0_0");
            break;
          case VehicleModType.RearWheel:
            entry = Game.GetGXTEntry("CMOD_WHE0_1");
            break;
          case VehicleModType.PlateHolder:
            entry = Game.GetGXTEntry("CMM_MOD_S0");
            break;
          case VehicleModType.VanityPlates:
            entry = Game.GetGXTEntry("CMM_MOD_S1");
            break;
          case VehicleModType.TrimDesign:
            entry = !(this._owner.Model == (Model) VehicleHash.SultanRS) ? Game.GetGXTEntry("CMM_MOD_S2") : Game.GetGXTEntry("CMM_MOD_S2b");
            break;
          case VehicleModType.Ornaments:
            entry = Game.GetGXTEntry("CMM_MOD_S3");
            break;
          case VehicleModType.Dashboard:
            entry = Game.GetGXTEntry("CMM_MOD_S4");
            break;
          case VehicleModType.DialDesign:
            entry = Game.GetGXTEntry("CMM_MOD_S5");
            break;
          case VehicleModType.DoorSpeakers:
            entry = Game.GetGXTEntry("CMM_MOD_S6");
            break;
          case VehicleModType.Seats:
            entry = Game.GetGXTEntry("CMM_MOD_S7");
            break;
          case VehicleModType.SteeringWheels:
            entry = Game.GetGXTEntry("CMM_MOD_S8");
            break;
          case VehicleModType.ColumnShifterLevers:
            entry = Game.GetGXTEntry("CMM_MOD_S9");
            break;
          case VehicleModType.Plaques:
            entry = Game.GetGXTEntry("CMM_MOD_S10");
            break;
          case VehicleModType.Speakers:
            entry = Game.GetGXTEntry("CMM_MOD_S11");
            break;
          case VehicleModType.Trunk:
            entry = Game.GetGXTEntry("CMM_MOD_S12");
            break;
          case VehicleModType.Hydraulics:
            entry = Game.GetGXTEntry("CMM_MOD_S13");
            break;
          case VehicleModType.EngineBlock:
            entry = Game.GetGXTEntry("CMM_MOD_S14");
            break;
          case VehicleModType.AirFilter:
            entry = !(this._owner.Model == (Model) VehicleHash.SultanRS) ? Game.GetGXTEntry("CMM_MOD_S15") : Game.GetGXTEntry("CMM_MOD_S15b");
            break;
          case VehicleModType.Struts:
            entry = this._owner.Model == (Model) VehicleHash.SultanRS || this._owner.Model == (Model) VehicleHash.Banshee2 ? Game.GetGXTEntry("CMM_MOD_S16b") : Game.GetGXTEntry("CMM_MOD_S16");
            break;
          case VehicleModType.ArchCover:
            entry = !(this._owner.Model == (Model) VehicleHash.SultanRS) ? Game.GetGXTEntry("CMM_MOD_S17") : Game.GetGXTEntry("CMM_MOD_S17b");
            break;
          case VehicleModType.Aerials:
            entry = !(this._owner.Model == (Model) VehicleHash.SultanRS) ? (!(this._owner.Model == (Model) VehicleHash.BType3) ? Game.GetGXTEntry("CMM_MOD_S18") : Game.GetGXTEntry("CMM_MOD_S18c")) : Game.GetGXTEntry("CMM_MOD_S18b");
            break;
          case VehicleModType.Trim:
            entry = !(this._owner.Model == (Model) VehicleHash.SultanRS) ? (!(this._owner.Model == (Model) VehicleHash.BType3) ? (!(this._owner.Model == (Model) VehicleHash.Virgo2) ? Game.GetGXTEntry("CMM_MOD_S19") : Game.GetGXTEntry("CMM_MOD_S19d")) : Game.GetGXTEntry("CMM_MOD_S19c")) : Game.GetGXTEntry("CMM_MOD_S19b");
            break;
          case VehicleModType.Tank:
            entry = !(this._owner.Model == (Model) VehicleHash.SlamVan3) ? Game.GetGXTEntry("CMM_MOD_S20") : Game.GetGXTEntry("CMM_MOD_S27");
            break;
          case VehicleModType.Windows:
            entry = !(this._owner.Model == (Model) VehicleHash.BType3) ? Game.GetGXTEntry("CMM_MOD_S21") : Game.GetGXTEntry("CMM_MOD_S21b");
            break;
          case VehicleModType.Suspension | VehicleModType.Seats:
            entry = !(this._owner.Model == (Model) VehicleHash.SlamVan3) ? Game.GetGXTEntry("CMM_MOD_S22") : Game.GetGXTEntry("SLVAN3_RDOOR");
            break;
          case VehicleModType.Livery:
            entry = Game.GetGXTEntry("CMM_MOD_S23");
            break;
          default:
            entry = Function.Call<string>(Hash.GET_MOD_SLOT_NAME, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
            if (Game.DoesGXTEntryExist(entry))
            {
              entry = Game.GetGXTEntry(entry);
              break;
            }
            break;
        }
        if (entry == "")
          entry = this.ModType.ToString();
        return entry;
      }
    }

    public string LocalizedModName => this.GetLocalizedModName(this.Index);

    public string GetLocalizedModName(int index)
    {
      if (this.ModCount == 0 || index < -1 || index >= this.ModCount)
        return "";
      if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, (InputArgument) "mod_mnu", (InputArgument) 10))
      {
        Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, (InputArgument) 10, (InputArgument) true);
        Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, (InputArgument) "mod_mnu", (InputArgument) 10);
      }
      if (this.ModType == VehicleModType.Horns)
      {
        if (!VehicleMod._hornNames.ContainsKey(index))
          return "";
        return Game.DoesGXTEntryExist(VehicleMod._hornNames[index].Item1) ? Game.GetGXTEntry(VehicleMod._hornNames[index].Item1) : VehicleMod._hornNames[index].Item2;
      }
      if (this.ModType == VehicleModType.FrontWheel || this.ModType == VehicleModType.RearWheel)
      {
        if (index == -1)
        {
          Model model = this._owner.Model;
          if (!model.IsBike)
          {
            model = this._owner.Model;
            if (model.IsBicycle)
              return Game.GetGXTEntry("CMOD_WHE_0");
          }
          return Game.GetGXTEntry("CMOD_WHE_B_0");
        }
        return index >= this.ModCount / 2 ? Game.GetGXTEntry("CHROME") + " " + Game.GetGXTEntry(Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) index)) : Game.GetGXTEntry(Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) index));
      }
      switch (this.ModType)
      {
        case VehicleModType.Engine:
          return index == -1 ? Game.GetGXTEntry("CMOD_ARM_0") : Game.GetGXTEntry("CMOD_ENG_" + (index + 2).ToString());
        case VehicleModType.Brakes:
          return Game.GetGXTEntry("CMOD_BRA_" + (index + 1).ToString());
        case VehicleModType.Transmission:
          return Game.GetGXTEntry("CMOD_GBX_" + (index + 1).ToString());
        case VehicleModType.Suspension:
          return Game.GetGXTEntry("CMOD_SUS_" + (index + 1).ToString());
        case VehicleModType.Armor:
          return Game.GetGXTEntry("CMOD_ARM_" + (index + 1).ToString());
        default:
          if (index > -1)
          {
            string entry = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) index);
            if (!Game.DoesGXTEntryExist(entry))
              return this.LocalizedModTypeName + " " + (index + 1).ToString();
            string gxtEntry = Game.GetGXTEntry(entry);
            return gxtEntry == "" || gxtEntry == "NULL" ? this.LocalizedModTypeName + " " + (index + 1).ToString() : gxtEntry;
          }
          switch (this.ModType)
          {
            case VehicleModType.AirFilter:
              if (!(this._owner.Model == (Model) VehicleHash.Tornado))
                break;
              break;
            case VehicleModType.Struts:
              switch ((VehicleHash) this._owner.Model)
              {
                case VehicleHash.Banshee2:
                case VehicleHash.Banshee:
                case VehicleHash.SultanRS:
                  return Game.GetGXTEntry("CMOD_COL5_41");
              }
              break;
          }
          return Game.GetGXTEntry("CMOD_DEF_0");
      }
    }

    public int ModCount => Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);

    public Vehicle Vehicle => this._owner;

    public void Remove() => Function.Call(Hash.REMOVE_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
  }
}
