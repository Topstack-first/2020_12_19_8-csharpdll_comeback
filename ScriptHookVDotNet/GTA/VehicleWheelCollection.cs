// Decompiled with JetBrains decompiler
// Type: GTA.VehicleWheelCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Collections.Generic;

namespace GTA
{
  public sealed class VehicleWheelCollection
  {
    private Vehicle _owner;
    private readonly Dictionary<int, VehicleWheel> _vehicleWheels = new Dictionary<int, VehicleWheel>();

    internal VehicleWheelCollection(Vehicle owner) => this._owner = owner;

    public VehicleWheel this[int index]
    {
      get
      {
        VehicleWheel vehicleWheel = (VehicleWheel) null;
        if (!this._vehicleWheels.TryGetValue(index, out vehicleWheel))
        {
          vehicleWheel = new VehicleWheel(this._owner, index);
          this._vehicleWheels.Add(index, vehicleWheel);
        }
        return vehicleWheel;
      }
    }

    public int Count
    {
      get
      {
        if (this._owner.MemoryAddress == IntPtr.Zero)
          return 0;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 2728 : 2696;
        int num2 = Game.Version >= GameVersion.v1_0_505_2_Steam ? 2712 : num1;
        int num3 = Game.Version >= GameVersion.v1_0_791_2_Steam ? 2744 : num2;
        int num4 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 2792 : num3;
        return MemoryAccess.ReadInt(this._owner.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 2840 : num4));
      }
    }
  }
}
