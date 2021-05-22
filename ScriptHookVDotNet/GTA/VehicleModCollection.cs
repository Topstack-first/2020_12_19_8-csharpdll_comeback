// Decompiled with JetBrains decompiler
// Type: GTA.VehicleModCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace GTA
{
  public sealed class VehicleModCollection
  {
    private Vehicle _owner;
    private readonly Dictionary<VehicleModType, VehicleMod> _vehicleMods = new Dictionary<VehicleModType, VehicleMod>();
    private readonly Dictionary<VehicleToggleModType, VehicleToggleMod> _vehicleToggleMods = new Dictionary<VehicleToggleModType, VehicleToggleMod>();
    private static readonly ReadOnlyDictionary<VehicleWheelType, Tuple<string, string>> _wheelNames = new ReadOnlyDictionary<VehicleWheelType, Tuple<string, string>>((IDictionary<VehicleWheelType, Tuple<string, string>>) new Dictionary<VehicleWheelType, Tuple<string, string>>()
    {
      {
        VehicleWheelType.BikeWheels,
        new Tuple<string, string>("CMOD_WHE1_0", "Bike")
      },
      {
        VehicleWheelType.HighEnd,
        new Tuple<string, string>("CMOD_WHE1_1", "High End")
      },
      {
        VehicleWheelType.Lowrider,
        new Tuple<string, string>("CMOD_WHE1_2", "Lowrider")
      },
      {
        VehicleWheelType.Muscle,
        new Tuple<string, string>("CMOD_WHE1_3", "Muscle")
      },
      {
        VehicleWheelType.Offroad,
        new Tuple<string, string>("CMOD_WHE1_4", "Offroad")
      },
      {
        VehicleWheelType.Sport,
        new Tuple<string, string>("CMOD_WHE1_5", "Sport")
      },
      {
        VehicleWheelType.SUV,
        new Tuple<string, string>("CMOD_WHE1_6", "SUV")
      },
      {
        VehicleWheelType.Tuner,
        new Tuple<string, string>("CMOD_WHE1_7", "Tuner")
      },
      {
        VehicleWheelType.BennysOriginals,
        new Tuple<string, string>("CMOD_WHE1_8", "Benny's Originals")
      },
      {
        VehicleWheelType.BennysBespoke,
        new Tuple<string, string>("CMOD_WHE1_9", "Benny's Bespoke")
      }
    });

    internal VehicleModCollection(Vehicle owner) => this._owner = owner;

    public VehicleMod this[VehicleModType modType]
    {
      get
      {
        VehicleMod vehicleMod = (VehicleMod) null;
        if (!this._vehicleMods.TryGetValue(modType, out vehicleMod))
        {
          vehicleMod = new VehicleMod(this._owner, modType);
          this._vehicleMods.Add(modType, vehicleMod);
        }
        return vehicleMod;
      }
    }

    public VehicleToggleMod this[VehicleToggleModType modType]
    {
      get
      {
        VehicleToggleMod vehicleToggleMod = (VehicleToggleMod) null;
        if (!this._vehicleToggleMods.TryGetValue(modType, out vehicleToggleMod))
        {
          vehicleToggleMod = new VehicleToggleMod(this._owner, modType);
          this._vehicleToggleMods.Add(modType, vehicleToggleMod);
        }
        return vehicleToggleMod;
      }
    }

    public bool HasVehicleMod(VehicleModType type) => Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) type) > 0;

    public VehicleMod[] GetAllMods() => Enum.GetValues(typeof (VehicleModType)).Cast<VehicleModType>().Where<VehicleModType>(new Func<VehicleModType, bool>(this.HasVehicleMod)).Select<VehicleModType, VehicleMod>((Func<VehicleModType, VehicleMod>) (modType => this[modType])).ToArray<VehicleMod>();

    public VehicleWheelType WheelType
    {
      get => Function.Call<VehicleWheelType>(Hash.GET_VEHICLE_WHEEL_TYPE, (InputArgument) this._owner.Handle);
      set => Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value);
    }

    public VehicleWheelType[] AllowedWheelTypes
    {
      get
      {
        if (this._owner.Model.IsBicycle || this._owner.Model.IsBike)
          return new VehicleWheelType[1]
          {
            VehicleWheelType.BikeWheels
          };
        if (!this._owner.Model.IsCar)
          return new VehicleWheelType[0];
        List<VehicleWheelType> vehicleWheelTypeList = new List<VehicleWheelType>()
        {
          VehicleWheelType.Sport,
          VehicleWheelType.Muscle,
          VehicleWheelType.Lowrider,
          VehicleWheelType.SUV,
          VehicleWheelType.Offroad,
          VehicleWheelType.Tuner,
          VehicleWheelType.HighEnd
        };
        switch ((VehicleHash) this._owner.Model)
        {
          case VehicleHash.SabreGT2:
          case VehicleHash.Voodoo2:
          case VehicleHash.SlamVan3:
          case VehicleHash.Moonbeam2:
          case VehicleHash.Primo2:
          case VehicleHash.Faction3:
          case VehicleHash.Tornado5:
          case VehicleHash.Faction2:
          case VehicleHash.Chino2:
          case VehicleHash.Minivan2:
          case VehicleHash.Buccaneer2:
          case VehicleHash.Virgo2:
            vehicleWheelTypeList.AddRange((IEnumerable<VehicleWheelType>) new VehicleWheelType[2]
            {
              VehicleWheelType.BennysOriginals,
              VehicleWheelType.BennysBespoke
            });
            break;
          case VehicleHash.Banshee2:
          case VehicleHash.SultanRS:
            vehicleWheelTypeList.Add(VehicleWheelType.BennysOriginals);
            break;
        }
        return vehicleWheelTypeList.ToArray();
      }
    }

    public string LocalizedWheelTypeName => this.GetLocalizedWheelTypeName(this.WheelType);

    public string GetLocalizedWheelTypeName(VehicleWheelType wheelType)
    {
      if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, (InputArgument) "mod_mnu", (InputArgument) 10))
      {
        Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, (InputArgument) 10, (InputArgument) true);
        Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, (InputArgument) "mod_mnu", (InputArgument) 10);
      }
      if (!VehicleModCollection._wheelNames.ContainsKey(wheelType))
        throw new ArgumentException("Wheel Type is undefined", nameof (wheelType));
      return Game.DoesGXTEntryExist(VehicleModCollection._wheelNames[wheelType].Item1) ? Game.GetGXTEntry(VehicleModCollection._wheelNames[wheelType].Item1) : VehicleModCollection._wheelNames[wheelType].Item2;
    }

    public void InstallModKit() => Function.Call(Hash.SET_VEHICLE_MOD_KIT, (InputArgument) this._owner.Handle, (InputArgument) 0);

    public bool RequestAdditionTextFile(int timeout = 1000)
    {
      if (Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, (InputArgument) "mod_mnu", (InputArgument) 10))
        return true;
      Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, (InputArgument) 10, (InputArgument) true);
      Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, (InputArgument) "mod_mnu", (InputArgument) 10);
      int num = Game.GameTime + timeout;
      while (Game.GameTime < num)
      {
        if (Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, (InputArgument) "mod_mnu", (InputArgument) 10))
          return true;
        Script.Yield();
      }
      return false;
    }

    public int Livery
    {
      get
      {
        int modCount = this[VehicleModType.Livery].ModCount;
        if (modCount > 0)
          return modCount;
        return Function.Call<int>(Hash.GET_VEHICLE_LIVERY, (InputArgument) this._owner.Handle);
      }
      set
      {
        if (this[VehicleModType.Livery].ModCount > 0)
          this[VehicleModType.Livery].Index = value;
        else
          Function.Call(Hash.SET_VEHICLE_LIVERY, (InputArgument) this._owner.Handle, (InputArgument) value);
      }
    }

    public int LiveryCount
    {
      get
      {
        int modCount = this[VehicleModType.Livery].ModCount;
        if (modCount > 0)
          return modCount;
        return Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, (InputArgument) this._owner.Handle);
      }
    }

    public string LocalizedLiveryName => this.GetLocalizedLiveryName(this.Livery);

    public string GetLocalizedLiveryName(int index)
    {
      if (this[VehicleModType.Livery].ModCount > 0)
        return this[VehicleModType.Livery].GetLocalizedModName(index);
      return Game.GetGXTEntry(Function.Call<string>(Hash.GET_LIVERY_NAME, (InputArgument) this._owner.Handle, (InputArgument) index));
    }

    public VehicleWindowTint WindowTint
    {
      get => Function.Call<VehicleWindowTint>(Hash.GET_VEHICLE_WINDOW_TINT, (InputArgument) this._owner.Handle);
      set => Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value);
    }

    public unsafe VehicleColor PrimaryColor
    {
      get
      {
        int num1;
        int num2;
        Function.Call(Hash.GET_VEHICLE_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
        return (VehicleColor) num1;
      }
      set => Function.Call(Hash.SET_VEHICLE_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value, (InputArgument) (Enum) this.SecondaryColor);
    }

    public unsafe VehicleColor SecondaryColor
    {
      get
      {
        int num1;
        int num2;
        Function.Call(Hash.GET_VEHICLE_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
        return (VehicleColor) num2;
      }
      set => Function.Call(Hash.SET_VEHICLE_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.PrimaryColor, (InputArgument) (Enum) value);
    }

    public unsafe VehicleColor RimColor
    {
      get
      {
        int num1;
        int num2;
        Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
        return (VehicleColor) num2;
      }
      set => Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.PearlescentColor, (InputArgument) (Enum) value);
    }

    public unsafe VehicleColor PearlescentColor
    {
      get
      {
        int num1;
        int num2;
        Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num1, (InputArgument) (void*) &num2);
        return (VehicleColor) num1;
      }
      set => Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value, (InputArgument) (Enum) this.RimColor);
    }

    public unsafe VehicleColor TrimColor
    {
      get
      {
        int num;
        Function.Call((Hash) 9012939617897488694, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num);
        return (VehicleColor) num;
      }
      set => Function.Call((Hash) 17585947422526242585, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value);
    }

    public unsafe VehicleColor DashboardColor
    {
      get
      {
        int num;
        Function.Call((Hash) 13214509638265019391, (InputArgument) this._owner.Handle, (InputArgument) (void*) &num);
        return (VehicleColor) num;
      }
      set => Function.Call((Hash) 6956317558672667244, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value);
    }

    public int ColorCombination
    {
      get => Function.Call<int>(Hash.GET_VEHICLE_COLOUR_COMBINATION, (InputArgument) this._owner.Handle);
      set => Function.Call(Hash.SET_VEHICLE_COLOUR_COMBINATION, (InputArgument) this._owner.Handle, (InputArgument) value);
    }

    public int ColorCombinationCount => Function.Call<int>(Hash.GET_NUMBER_OF_VEHICLE_COLOURS, (InputArgument) this._owner.Handle);

    public unsafe Color TireSmokeColor
    {
      get
      {
        int red;
        int green;
        int blue;
        Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, (InputArgument) this._owner.Handle, (InputArgument) (void*) &red, (InputArgument) (void*) &green, (InputArgument) (void*) &blue);
        return Color.FromArgb(red, green, blue);
      }
      set => Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, (InputArgument) this._owner.Handle, (InputArgument) value.R, (InputArgument) value.G, (InputArgument) value.B);
    }

    public unsafe Color NeonLightsColor
    {
      get
      {
        int red;
        int green;
        int blue;
        Function.Call(Hash._GET_VEHICLE_NEON_LIGHTS_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) (void*) &red, (InputArgument) (void*) &green, (InputArgument) (void*) &blue);
        return Color.FromArgb(red, green, blue);
      }
      set => Function.Call(Hash._SET_VEHICLE_NEON_LIGHTS_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) value.R, (InputArgument) value.G, (InputArgument) value.B);
    }

    public bool IsNeonLightsOn(VehicleNeonLight light) => Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) light);

    public void SetNeonLightsOn(VehicleNeonLight light, bool on) => Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) light, (InputArgument) on);

    public bool HasNeonLights => Enum.GetValues(typeof (VehicleNeonLight)).Cast<VehicleNeonLight>().Any<VehicleNeonLight>(new Func<VehicleNeonLight, bool>(this.HasNeonLight));

    public bool HasNeonLight(VehicleNeonLight neonLight)
    {
      switch (neonLight)
      {
        case VehicleNeonLight.Left:
          return this._owner.Bones.HasBone("neon_l");
        case VehicleNeonLight.Right:
          return this._owner.Bones.HasBone("neon_r");
        case VehicleNeonLight.Front:
          return this._owner.Bones.HasBone("neon_f");
        case VehicleNeonLight.Back:
          return this._owner.Bones.HasBone("neon_b");
        default:
          return false;
      }
    }

    public unsafe Color CustomPrimaryColor
    {
      get
      {
        int red;
        int green;
        int blue;
        Function.Call(Hash.GET_VEHICLE_CUSTOM_PRIMARY_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) (void*) &red, (InputArgument) (void*) &green, (InputArgument) (void*) &blue);
        return Color.FromArgb(red, green, blue);
      }
      set => Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) value.R, (InputArgument) value.G, (InputArgument) value.B);
    }

    public unsafe Color CustomSecondaryColor
    {
      get
      {
        int red;
        int green;
        int blue;
        Function.Call(Hash.GET_VEHICLE_CUSTOM_SECONDARY_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) (void*) &red, (InputArgument) (void*) &green, (InputArgument) (void*) &blue);
        return Color.FromArgb(red, green, blue);
      }
      set => Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, (InputArgument) this._owner.Handle, (InputArgument) value.R, (InputArgument) value.G, (InputArgument) value.B);
    }

    public bool IsPrimaryColorCustom => Function.Call<bool>(Hash.GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM, (InputArgument) this._owner.Handle);

    public bool IsSecondaryColorCustom => Function.Call<bool>(Hash.GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM, (InputArgument) this._owner.Handle);

    public void ClearCustomPrimaryColor() => Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR, (InputArgument) this._owner.Handle);

    public void ClearCustomSecondaryColor() => Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR, (InputArgument) this._owner.Handle);

    public LicensePlateStyle LicensePlateStyle
    {
      get => Function.Call<LicensePlateStyle>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, (InputArgument) this._owner.Handle);
      set => Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, (InputArgument) this._owner.Handle, (InputArgument) (Enum) value);
    }

    public LicensePlateType LicensePlateType => Function.Call<LicensePlateType>(Hash.GET_VEHICLE_PLATE_TYPE, (InputArgument) this._owner.Handle);

    public string LicensePlate
    {
      get => Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument) this._owner.Handle);
      set => Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument) this._owner.Handle, (InputArgument) value);
    }
  }
}
