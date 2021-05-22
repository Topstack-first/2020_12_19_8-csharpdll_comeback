// Decompiled with JetBrains decompiler
// Type: GTA.VehicleToggleMod
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public sealed class VehicleToggleMod
  {
    private Vehicle _owner;

    internal VehicleToggleMod(Vehicle owner, VehicleToggleModType modType)
    {
      this._owner = owner;
      this.ModType = modType;
    }

    public VehicleToggleModType ModType { get; private set; }

    public bool IsInstalled
    {
      get => Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
      set => Function.Call(Hash.TOGGLE_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType, (InputArgument) value);
    }

    public string LocalizedModTypeName => Function.Call<string>(Hash.GET_MOD_SLOT_NAME, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);

    public Vehicle Vehicle => this._owner;

    public void Remove() => Function.Call(Hash.REMOVE_VEHICLE_MOD, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.ModType);
  }
}
