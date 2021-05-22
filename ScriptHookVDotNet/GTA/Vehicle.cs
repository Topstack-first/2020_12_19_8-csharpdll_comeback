// Decompiled with JetBrains decompiler
// Type: GTA.Vehicle
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA
{
  public sealed class Vehicle : Entity
  {
    private VehicleDoorCollection _doors;
    private VehicleModCollection _mods;
    private VehicleWheelCollection _wheels;
    private VehicleWindowCollection _windows;

    public Vehicle(int handle)
      : base(handle)
    {
    }

    public string DisplayName => Vehicle.GetModelDisplayName(this.Model);

    public string LocalizedName => Game.GetGXTEntry(this.DisplayName);

    public string ClassDisplayName => Vehicle.GetClassDisplayName(this.ClassType);

    public string ClassLocalizedName => Game.GetGXTEntry(this.ClassDisplayName);

    public VehicleClass ClassType => Function.Call<VehicleClass>(Hash.GET_VEHICLE_CLASS, (InputArgument) this.Handle);

    public float BodyHealth
    {
      get => Function.Call<float>(Hash.GET_VEHICLE_BODY_HEALTH, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_BODY_HEALTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float EngineHealth
    {
      get => Function.Call<float>(Hash.GET_VEHICLE_ENGINE_HEALTH, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float PetrolTankHealth
    {
      get => Function.Call<float>(Hash.GET_VEHICLE_PETROL_TANK_HEALTH, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float HeliMainRotorHealth
    {
      get
      {
        if (!this.Model.IsHelicopter)
          return 0.0f;
        return Function.Call<float>(Hash._GET_HELI_MAIN_ROTOR_HEALTH, (InputArgument) this.Handle);
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero || !this.Model.IsHelicopter)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5964 : 5948;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5996 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 6172 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 6220 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 6380 : num4), value);
      }
    }

    public float HeliTailRotorHealth
    {
      get
      {
        if (!this.Model.IsHelicopter)
          return 0.0f;
        return Function.Call<float>(Hash._GET_HELI_TAIL_ROTOR_HEALTH, (InputArgument) this.Handle);
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero || !this.Model.IsHelicopter)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5968 : 5952;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 6000 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 6176 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 6224 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 6384 : num4), value);
      }
    }

    public float HeliEngineHealth
    {
      get
      {
        if (!this.Model.IsHelicopter)
          return 0.0f;
        return Function.Call<float>(Hash._GET_HELI_ENGINE_HEALTH, (InputArgument) this.Handle);
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero || !this.Model.IsHelicopter)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5972 : 5956;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 6004 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 6180 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 6228 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 6388 : num4), value);
      }
    }

    public float FuelLevel
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1896 : 1880;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1928 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1960 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1976 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2004 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1896 : 1880;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1928 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1960 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1976 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2004 : num4), value);
      }
    }

    public float OilLevel
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1900 : 1884;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1932 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1964 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1980 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2008 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1900 : 1884;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1932 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1964 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1980 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2008 : num4), value);
      }
    }

    public float Gravity
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2860 : 2844;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2892 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2940 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2956 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2988 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2860 : 2844;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2892 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2940 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2956 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2988 : num4), value);
      }
    }

    public bool IsEngineRunning
    {
      get => Function.Call<bool>(Hash.GET_IS_VEHICLE_ENGINE_RUNNING, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_ENGINE_ON, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) true);
    }

    public bool IsEngineStarting
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2114 : 2098;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2146 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2186 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2202 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2234 : num4), 5);
      }
    }

    public bool IsRadioEnabled
    {
      set => Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public RadioStation RadioStation
    {
      set
      {
        if (value == RadioStation.RadioOff)
        {
          Function.Call(Hash.SET_VEH_RADIO_STATION, (InputArgument) "OFF");
        }
        else
        {
          if (!Enum.IsDefined(typeof (RadioStation), (object) value))
            return;
          Function.Call(Hash.SET_VEH_RADIO_STATION, (InputArgument) Game._radioNames[(int) value]);
        }
      }
    }

    public float ForwardSpeed
    {
      set
      {
        if (this.Model.IsTrain)
        {
          Function.Call(Hash.SET_TRAIN_SPEED, (InputArgument) this.Handle, (InputArgument) value);
          Function.Call(Hash.SET_TRAIN_CRUISE_SPEED, (InputArgument) this.Handle, (InputArgument) value);
        }
        else
          Function.Call(Hash.SET_VEHICLE_FORWARD_SPEED, (InputArgument) this.Handle, (InputArgument) value);
      }
    }

    public float WheelSpeed
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2468 : 2452;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2500 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2544 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2560 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2576 : num4));
      }
    }

    public float HeliBladesSpeed
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero || !this.Model.IsHelicopter)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5952 : 5936;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5984 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 6160 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 6208 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 6368 : num4));
      }
      set
      {
        if (!this.Model.IsHelicopter)
          return;
        Function.Call(Hash.SET_HELI_BLADES_SPEED, (InputArgument) this.Handle, (InputArgument) value);
      }
    }

    public float Acceleration
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2020 : 2004;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2052 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2084 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2100 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2132 : num4));
      }
    }

    public float CurrentRPM
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2004 : 1988;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2036 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2068 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2084 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2116 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2004 : 1988;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2036 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2068 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2084 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2116 : num4), value);
      }
    }

    public byte HighGear
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1958 : 1942;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1990 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2022 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2038 : num3;
        return MemoryAccess.ReadByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2070 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        if (value < (byte) 0 || value > (byte) 7)
          throw new ArgumentOutOfRangeException(nameof (value), "Values must be between 0 and 7, inclusive.");
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1958 : 1942;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1990 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2022 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2038 : num3;
        MemoryAccess.WriteByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2070 : num4), value);
      }
    }

    public byte CurrentGear
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1954 : 1938;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1986 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2018 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2034 : num3;
        return MemoryAccess.ReadByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2066 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1954 : 1938;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1986 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2018 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2034 : num3;
        MemoryAccess.WriteByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2066 : num4), value);
      }
    }

    public float EngineTemperature
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2436 : 0;
        int num2 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2476 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2492 : num2;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2524 : num3));
      }
    }

    public float OilVolume => this.MemoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(this.MemoryAddress + 260);

    public float PetrolTankVolume => this.MemoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(this.MemoryAddress + 256);

    public float Clutch
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2016 : 2000;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2048 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2080 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2096 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2128 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2016 : 2000;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2048 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2080 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2096 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2128 : num4), value);
      }
    }

    public float Turbo
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2040 : 2008;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2072 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2104 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2120 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2152 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2040 : 2008;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2072 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2104 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2120 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2152 : num4), value);
      }
    }

    public int Gears
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1952 : 1936;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1984 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2016 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2032 : num3;
        return MemoryAccess.ReadInt(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2064 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1952 : 1936;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1984 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2016 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2032 : num3;
        MemoryAccess.WriteInt(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2064 : num4), value);
      }
    }

    public float NextGear
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1952 : 1936;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1984 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2016 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2032 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2064 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1952 : 1936;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1984 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2016 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2032 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2064 : num4), value);
      }
    }

    public float Throttle
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2020 : 2004;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2052 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2084 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2100 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2132 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2020 : 2004;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2052 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2084 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2100 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2132 : num4), value);
      }
    }

    public float ThrottlePower
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2228 : 2212;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2260 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2300 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2316 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2348 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2228 : 2212;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2260 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2300 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2316 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2348 : num4), value);
      }
    }

    public float BrakePower
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2232 : 2216;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2264 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2304 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2320 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2352 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2232 : 2216;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2264 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2304 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2320 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2352 : num4), value);
      }
    }

    public float SteeringAngle
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2220 : 2204;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2252 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2292 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2308 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2340 : num4)) * 57.29578f;
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2220 : 2204;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2252 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2292 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2308 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2340 : num4), value);
      }
    }

    public float SteeringScale
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2212 : 2196;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2244 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2284 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2300 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2332 : num4));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2212 : 2196;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2244 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2284 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2300 : num3;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2332 : num4), value);
      }
    }

    public bool HasForks => this.Bones.HasBone("forks");

    public bool IsAlarmSet
    {
      set => Function.Call(Hash.SET_VEHICLE_ALARM, (InputArgument) this.Handle, (InputArgument) value);
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2456 : 2440;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2488 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2532 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2548 : num3;
        return MemoryAccess.ReadShort(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 4120 : num4)) == (short) -1;
      }
    }

    public bool IsAlarmSounding => Function.Call<bool>(Hash.IS_VEHICLE_ALARM_ACTIVATED, (InputArgument) this.Handle);

    public int AlarmTimeLeft
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2456 : 2440;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2488 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2532 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2548 : num3;
        ushort num5 = (ushort) MemoryAccess.ReadShort(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2584 : num4));
        return num5 == ushort.MaxValue ? 0 : (int) num5;
      }
      set
      {
        ushort num1 = (ushort) value;
        if (num1 == ushort.MaxValue || this.MemoryAddress == IntPtr.Zero)
          return;
        int num2 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2456 : 2440;
        int num3 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2488 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2532 : num3;
        int num5 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2548 : num4;
        MemoryAccess.WriteShort(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2584 : num5), (short) num1);
      }
    }

    public void StartAlarm() => Function.Call(Hash.START_VEHICLE_ALARM, (InputArgument) this.Handle);

    public bool HasSiren => this.Bones.HasBone("siren1");

    public bool IsSirenActive
    {
      get => Function.Call<bool>(Hash.IS_VEHICLE_SIREN_ON, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_SIREN, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsSirenSilent
    {
      set => Function.Call(Hash.DISABLE_VEHICLE_IMPACT_EXPLOSION_ACTIVATION, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void SoundHorn(int duration) => Function.Call(Hash.START_VEHICLE_HORN, (InputArgument) this.Handle, (InputArgument) duration, (InputArgument) Game.GenerateHash("HELDDOWN"), (InputArgument) 0);

    public bool IsWanted
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2124 : 2108;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2156 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2196 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2212 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2244 : num4), 3);
      }
      set => Function.Call(Hash.SET_VEHICLE_IS_WANTED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool ProvidesCover
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2108 : 2092;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2140 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2180 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2196 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2228 : num4), 2);
      }
      set => Function.Call(Hash.SET_VEHICLE_PROVIDES_COVER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool DropsMoneyOnExplosion
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2712 : 2680;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2760 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2776 : num2;
        return MemoryAccess.ReadInt(memoryAddress + num3) <= 8 && MemoryAccess.IsBitSet(memoryAddress + 4857, 1);
      }
      set => Function.Call(Hash._SET_VEHICLE_CREATES_MONEY_PICKUPS_WHEN_EXPLODED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool PreviouslyOwnedByPlayer
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2116 : 2100;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2148 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2188 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2204 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2236 : num4), 1);
      }
      set => Function.Call(Hash.SET_VEHICLE_HAS_BEEN_OWNED_BY_PLAYER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool NeedsToBeHotwired
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2116 : 2100;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2148 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2188 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2204 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2236 : num4), 2);
      }
      set => Function.Call(Hash.SET_VEHICLE_NEEDS_TO_BE_HOTWIRED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool AreLightsOn
    {
      get
      {
        OutputArgument outputArgument1 = new OutputArgument();
        OutputArgument outputArgument2 = new OutputArgument();
        Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, (InputArgument) this.Handle, (InputArgument) outputArgument1, (InputArgument) outputArgument2);
        return outputArgument1.GetResult<bool>();
      }
      set => Function.Call(Hash.SET_VEHICLE_LIGHTS, (InputArgument) this.Handle, (InputArgument) (value ? 3 : 4));
    }

    public bool AreHighBeamsOn
    {
      get
      {
        OutputArgument outputArgument1 = new OutputArgument();
        OutputArgument outputArgument2 = new OutputArgument();
        Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, (InputArgument) this.Handle, (InputArgument) outputArgument1, (InputArgument) outputArgument2);
        return outputArgument2.GetResult<bool>();
      }
      set => Function.Call(Hash.SET_VEHICLE_FULLBEAM, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsInteriorLightOn
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2113 : 2097;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2145 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2185 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2201 : num3;
        return MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2233 : num4), 6);
      }
      set => Function.Call(Hash.SET_VEHICLE_INTERIORLIGHT, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsSearchLightOn
    {
      get => Function.Call<bool>(Hash.IS_VEHICLE_SEARCHLIGHT_ON, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_SEARCHLIGHT, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) 0);
    }

    public bool IsTaxiLightOn
    {
      get => Function.Call<bool>(Hash.IS_TAXI_LIGHT_ON, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_TAXI_LIGHTS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsLeftIndicatorLightOn
    {
      set => Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, (InputArgument) this.Handle, (InputArgument) true, (InputArgument) value);
    }

    public bool IsRightIndicatorLightOn
    {
      set => Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, (InputArgument) this.Handle, (InputArgument) false, (InputArgument) value);
    }

    public bool IsHandbrakeForcedOn
    {
      set => Function.Call(Hash.SET_VEHICLE_HANDBRAKE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool AreBrakeLightsOn
    {
      set => Function.Call(Hash.SET_VEHICLE_BRAKE_LIGHTS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float LightsMultiplier
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2316 : 2300;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2348 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2388 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2404 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2436 : num4));
      }
      set => Function.Call(Hash.SET_VEHICLE_LIGHT_MULTIPLIER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float LodMultiplier
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 4612 : 4596;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 4644 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 4708 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 4724 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 4776 : num4));
      }
      set => Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanBeVisiblyDamaged
    {
      set => Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsDamaged => Function.Call<bool>(Hash._IS_VEHICLE_DAMAGED, (InputArgument) this.Handle);

    public bool IsDriveable
    {
      get => Function.Call<bool>(Hash.IS_VEHICLE_DRIVEABLE, (InputArgument) this.Handle, (InputArgument) 0);
      set => Function.Call(Hash.SET_VEHICLE_UNDRIVEABLE, (InputArgument) this.Handle, (InputArgument) !value);
    }

    public bool HasRoof => Function.Call<bool>(Hash.DOES_VEHICLE_HAVE_ROOF, (InputArgument) this.Handle);

    public bool IsLeftHeadLightBroken
    {
      get => Function.Call<bool>(Hash.GET_IS_LEFT_VEHICLE_HEADLIGHT_DAMAGED, (InputArgument) this.Handle);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1916 : 1900;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1948 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1980 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1996 : num3;
        int num5 = Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2028 : num4;
        if (value)
          MemoryAccess.SetBit(this.MemoryAddress + num5, 0);
        else
          MemoryAccess.ClearBit(this.MemoryAddress + num5, 0);
      }
    }

    public bool IsRightHeadLightBroken
    {
      get => Function.Call<bool>(Hash.GET_IS_RIGHT_VEHICLE_HEADLIGHT_DAMAGED, (InputArgument) this.Handle);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 1916 : 1900;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 1948 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 1980 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 1996 : num3;
        int num5 = Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2028 : num4;
        if (value)
          MemoryAccess.SetBit(this.MemoryAddress + num5, 0);
        else
          MemoryAccess.ClearBit(this.MemoryAddress + num5, 0);
      }
    }

    public bool IsRearBumperBrokenOff => Function.Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, (InputArgument) this.Handle, (InputArgument) false);

    public bool IsFrontBumperBrokenOff => Function.Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, (InputArgument) this.Handle, (InputArgument) true);

    public bool IsAxlesStrong
    {
      set => Function.Call<bool>(Hash.SET_VEHICLE_HAS_STRONG_AXLES, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanEngineDegrade
    {
      set => Function.Call(Hash.SET_VEHICLE_ENGINE_CAN_DEGRADE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float EnginePowerMultiplier
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2512 : 2496;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2544 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2584 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2600 : num3;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2632 : num4));
      }
      set => Function.Call(Hash._SET_VEHICLE_ENGINE_POWER_MULTIPLIER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float EngineTorqueMultiplier
    {
      set => Function.Call(Hash._SET_VEHICLE_ENGINE_TORQUE_MULTIPLIER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public VehicleLandingGearState LandingGearState
    {
      get => Function.Call<VehicleLandingGearState>(Hash.GET_LANDING_GEAR_STATE, (InputArgument) this.Handle);
      set => Function.Call(Hash.CONTROL_LANDING_GEAR, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public VehicleRoofState RoofState
    {
      get => Function.Call<VehicleRoofState>(Hash.GET_CONVERTIBLE_ROOF_STATE, (InputArgument) this.Handle);
      set
      {
        switch (value)
        {
          case VehicleRoofState.Closed:
            Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) true);
            Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) false);
            break;
          case VehicleRoofState.Opening:
            Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) false);
            break;
          case VehicleRoofState.Opened:
            Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) true);
            Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) false);
            break;
          case VehicleRoofState.Closing:
            Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, (InputArgument) this.Handle, (InputArgument) false);
            break;
        }
      }
    }

    public VehicleLockStatus LockStatus
    {
      get => Function.Call<VehicleLockStatus>(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public float MaxBraking => Function.Call<float>(Hash.GET_VEHICLE_MAX_BRAKING, (InputArgument) this.Handle);

    public float MaxTraction => Function.Call<float>(Hash.GET_VEHICLE_MAX_TRACTION, (InputArgument) this.Handle);

    public bool IsOnAllWheels => Function.Call<bool>(Hash.IS_VEHICLE_ON_ALL_WHEELS, (InputArgument) this.Handle);

    public bool IsStopped => Function.Call<bool>(Hash.IS_VEHICLE_STOPPED, (InputArgument) this.Handle);

    public bool IsStoppedAtTrafficLights => Function.Call<bool>(Hash.IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS, (InputArgument) this.Handle);

    public bool IsStolen
    {
      get => Function.Call<bool>(Hash.IS_VEHICLE_STOLEN, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_IS_STOLEN, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsConvertible => Function.Call<bool>(Hash.IS_VEHICLE_A_CONVERTIBLE, (InputArgument) this.Handle, (InputArgument) 0);

    public bool IsBurnoutForced
    {
      set => Function.Call<bool>(Hash.SET_VEHICLE_BURNOUT, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsInBurnout => Function.Call<bool>(Hash.IS_VEHICLE_IN_BURNOUT, (InputArgument) this.Handle);

    public Ped Driver => this.GetPedOnSeat(VehicleSeat.Driver);

    public Ped[] Occupants
    {
      get
      {
        Ped driver = this.Driver;
        if (!Ped.Exists(driver))
          return this.Passengers;
        Ped[] pedArray = new Ped[this.PassengerCount + 1];
        pedArray[0] = driver;
        int num1 = 0;
        int num2 = 0;
        for (int passengerCapacity = this.PassengerCapacity; num1 < passengerCapacity && num2 < pedArray.Length; ++num1)
        {
          if (!this.IsSeatFree((VehicleSeat) num1))
            pedArray[num2++ + 1] = this.GetPedOnSeat((VehicleSeat) num1);
        }
        return pedArray;
      }
    }

    public Ped[] Passengers
    {
      get
      {
        Ped[] pedArray = new Ped[this.PassengerCount];
        if (pedArray.Length == 0)
          return pedArray;
        int num1 = 0;
        int num2 = 0;
        for (int passengerCapacity = this.PassengerCapacity; num1 < passengerCapacity && num2 < pedArray.Length; ++num1)
        {
          if (!this.IsSeatFree((VehicleSeat) num1))
            pedArray[num2++] = this.GetPedOnSeat((VehicleSeat) num1);
        }
        return pedArray;
      }
    }

    public int PassengerCapacity => Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, (InputArgument) this.Handle);

    public int PassengerCount => Function.Call<int>(Hash.GET_VEHICLE_NUMBER_OF_PASSENGERS, (InputArgument) this.Handle);

    public VehicleDoorCollection Doors
    {
      get
      {
        if (this._doors == null)
          this._doors = new VehicleDoorCollection(this);
        return this._doors;
      }
    }

    public VehicleModCollection Mods
    {
      get
      {
        if (this._mods == null)
          this._mods = new VehicleModCollection(this);
        return this._mods;
      }
    }

    public VehicleWheelCollection Wheels
    {
      get
      {
        if (this._wheels == null)
          this._wheels = new VehicleWheelCollection(this);
        return this._wheels;
      }
    }

    public VehicleWindowCollection Windows
    {
      get
      {
        if (this._windows == null)
          this._windows = new VehicleWindowCollection(this);
        return this._windows;
      }
    }

    public bool ExtraExists(int extra) => Function.Call<bool>(Hash.DOES_EXTRA_EXIST, (InputArgument) this.Handle, (InputArgument) extra);

    public bool IsExtraOn(int extra) => Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, (InputArgument) this.Handle, (InputArgument) extra);

    public void ToggleExtra(int extra, bool toggle) => Function.Call(Hash.SET_VEHICLE_EXTRA, (InputArgument) this.Handle, (InputArgument) extra, (InputArgument) !toggle);

    public Ped GetPedOnSeat(VehicleSeat seat) => new Ped(Function.Call<int>(Hash.GET_PED_IN_VEHICLE_SEAT, (InputArgument) this.Handle, (InputArgument) (Enum) seat));

    public bool IsSeatFree(VehicleSeat seat) => Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, (InputArgument) this.Handle, (InputArgument) (Enum) seat);

    public void Wash() => this.DirtLevel = 0.0f;

    public float DirtLevel
    {
      get => Function.Call<float>(Hash.GET_VEHICLE_DIRT_LEVEL, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool PlaceOnGround() => Function.Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, (InputArgument) this.Handle);

    public void PlaceOnNextStreet()
    {
      Vector3 position = this.Position;
      OutputArgument outputArgument1 = new OutputArgument();
      OutputArgument outputArgument2 = new OutputArgument();
      for (int index = 1; index < 40; ++index)
      {
        Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) index, (InputArgument) outputArgument2, (InputArgument) outputArgument1, (InputArgument) new OutputArgument(), (InputArgument) 1, (InputArgument) 1077936128, (InputArgument) 0);
        Vector3 result = outputArgument2.GetResult<Vector3>();
        if (!Function.Call<bool>(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, (InputArgument) result.X, (InputArgument) result.Y, (InputArgument) result.Z, (InputArgument) 5f, (InputArgument) 5f, (InputArgument) 5f, (InputArgument) 0))
        {
          this.Position = result;
          this.PlaceOnGround();
          this.Heading = outputArgument1.GetResult<float>();
          break;
        }
      }
    }

    public void Repair() => Function.Call(Hash.SET_VEHICLE_FIXED, (InputArgument) this.Handle);

    public void Explode() => Function.Call(Hash.EXPLODE_VEHICLE, (InputArgument) this.Handle, (InputArgument) true, (InputArgument) false);

    public bool CanTiresBurst
    {
      get => Function.Call<bool>(Hash.GET_VEHICLE_TYRES_CAN_BURST, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanWheelsBreak
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2107 : 2091;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2139 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_944_2_Steam ? 2179 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_1103_2_Steam ? 2195 : num3;
        return !MemoryAccess.IsBitSet(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_1180_2_Steam ? 2227 : num4), 6);
      }
      set => Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool HasBombBay => this.Bones.HasBone("door_hatch_l") && this.Bones.HasBone("door_hatch_r");

    public void OpenBombBay()
    {
      if (!this.HasBombBay)
        return;
      Function.Call(Hash.OPEN_BOMB_BAY_DOORS, (InputArgument) this.Handle);
    }

    public void CloseBombBay()
    {
      if (!this.HasBombBay)
        return;
      Function.Call(Hash.CLOSE_BOMB_BAY_DOORS, (InputArgument) this.Handle);
    }

    public void SetHeliYawPitchRollMult(float mult)
    {
      if (!this.Model.IsHelicopter || (double) mult < 0.0 || (double) mult > 1.0)
        return;
      Function.Call(Hash._SET_HELICOPTER_ROLL_PITCH_YAW_MULT, (InputArgument) this.Handle, (InputArgument) mult);
    }

    public void DropCargobobHook(CargobobHook hook)
    {
      if (!this.Model.IsCargobob)
        return;
      Function.Call(Hash.CREATE_PICK_UP_ROPE_FOR_CARGOBOB, (InputArgument) this.Handle, (InputArgument) (Enum) hook);
    }

    public void RetractCargobobHook()
    {
      if (!this.Model.IsCargobob)
        return;
      Function.Call(Hash.REMOVE_PICK_UP_ROPE_FOR_CARGOBOB, (InputArgument) this.Handle);
    }

    public bool IsCargobobHookActive()
    {
      if (!this.Model.IsCargobob)
        return false;
      if (Function.Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, (InputArgument) this.Handle))
        return true;
      return Function.Call<bool>(Hash._DOES_CARGOBOB_HAVE_PICKUP_MAGNET, (InputArgument) this.Handle);
    }

    public bool IsCargobobHookActive(CargobobHook hook)
    {
      if (this.Model.IsCargobob)
      {
        if (hook != CargobobHook.Hook)
        {
          if (hook == CargobobHook.Magnet)
            return Function.Call<bool>(Hash._DOES_CARGOBOB_HAVE_PICKUP_MAGNET, (InputArgument) this.Handle);
        }
        else
          return Function.Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, (InputArgument) this.Handle);
      }
      return false;
    }

    public void CargoBobMagnetGrabVehicle()
    {
      if (!this.IsCargobobHookActive(CargobobHook.Magnet))
        return;
      Function.Call(Hash._SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, (InputArgument) this.Handle, (InputArgument) true);
    }

    public void CargoBobMagnetReleaseVehicle()
    {
      if (!this.IsCargobobHookActive(CargobobHook.Magnet))
        return;
      Function.Call(Hash._SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, (InputArgument) this.Handle, (InputArgument) false);
    }

    public bool HasTowArm => this.Bones.HasBone("tow_arm");

    public float TowingCraneRaisedAmount
    {
      set => Function.Call(Hash._SET_TOW_TRUCK_CRANE_HEIGHT, (InputArgument) this.Handle, (InputArgument) value);
    }

    public Vehicle TowedVehicle => new Vehicle(Function.Call<int>(Hash.GET_ENTITY_ATTACHED_TO_TOW_TRUCK, (InputArgument) this.Handle));

    public void TowVehicle(Vehicle vehicle, bool rear) => Function.Call(Hash.ATTACH_VEHICLE_TO_TOW_TRUCK, (InputArgument) this.Handle, (InputArgument) vehicle.Handle, (InputArgument) rear, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f);

    public void DetachFromTowTruck() => Function.Call(Hash.DETACH_VEHICLE_FROM_ANY_TOW_TRUCK, (InputArgument) this.Handle);

    public void DetachTowedVehicle()
    {
      Vehicle towedVehicle = this.TowedVehicle;
      if (!Vehicle.Exists(towedVehicle))
        return;
      Function.Call(Hash.DETACH_VEHICLE_FROM_TOW_TRUCK, (InputArgument) this.Handle, (InputArgument) towedVehicle.Handle);
    }

    public void Deform(Vector3 position, float damageAmount, float radius) => Function.Call(Hash.SET_VEHICLE_DAMAGE, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) damageAmount, (InputArgument) radius);

    public Ped CreatePedOnSeat(VehicleSeat seat, Model model)
    {
      if (!this.IsSeatFree(seat))
        throw new ArgumentException("The VehicleSeat selected was not free", nameof (seat));
      if (!model.IsPed || !model.Request(1000))
        return (Ped) null;
      return new Ped(Function.Call<int>(Hash.CREATE_PED_INSIDE_VEHICLE, (InputArgument) this.Handle, (InputArgument) 26, (InputArgument) model.Hash, (InputArgument) (Enum) seat, (InputArgument) 1, (InputArgument) 1));
    }

    public Ped CreateRandomPedOnSeat(VehicleSeat seat)
    {
      if (!this.IsSeatFree(seat))
        throw new ArgumentException("The VehicleSeat selected was not free", nameof (seat));
      if (seat == VehicleSeat.Driver)
        return new Ped(Function.Call<int>(Hash.CREATE_RANDOM_PED_AS_DRIVER, (InputArgument) this.Handle, (InputArgument) true));
      int handle = Function.Call<int>(Hash.CREATE_RANDOM_PED, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f);
      Function.Call(Hash.SET_PED_INTO_VEHICLE, (InputArgument) handle, (InputArgument) this.Handle, (InputArgument) (Enum) seat);
      return new Ped(handle);
    }

    public static string GetModelDisplayName(Model vehicleModel) => Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument) vehicleModel.Hash);

    public static VehicleClass GetModelClass(Model vehicleModel) => Function.Call<VehicleClass>(Hash.GET_VEHICLE_CLASS_FROM_NAME, (InputArgument) vehicleModel.Hash);

    public static string GetClassDisplayName(VehicleClass vehicleClass) => "VEH_CLASS_" + ((int) vehicleClass).ToString();

    public static VehicleHash[] GetAllModelsOfClass(VehicleClass vehicleClass) => Array.ConvertAll<int, VehicleHash>(MemoryAccess.VehicleModels[(int) vehicleClass].ToArray<int>(), (Converter<int, VehicleHash>) (item => (VehicleHash) item));

    public static VehicleHash[] GetAllModels()
    {
      List<VehicleHash> vehicleHashList = new List<VehicleHash>();
      for (int index = 0; index < 32; ++index)
        vehicleHashList.AddRange((IEnumerable<VehicleHash>) Array.ConvertAll<int, VehicleHash>(MemoryAccess.VehicleModels[index].ToArray<int>(), (Converter<int, VehicleHash>) (item => (VehicleHash) item)));
      return vehicleHashList.ToArray();
    }

    public new bool Exists() => Function.Call<int>(Hash.GET_ENTITY_TYPE, (InputArgument) this.Handle) == 2;

    public static bool Exists(Vehicle vehicle) => vehicle != null && vehicle.Exists();
  }
}
