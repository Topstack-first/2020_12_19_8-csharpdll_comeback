// Decompiled with JetBrains decompiler
// Type: GTA.VehicleWindow
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public sealed class VehicleWindow
  {
    private Vehicle _owner;

    internal VehicleWindow(Vehicle owner, VehicleWindowIndex index)
    {
      this._owner = owner;
      this.Index = index;
    }

    public VehicleWindowIndex Index { get; private set; }

    public bool IsIntact => Function.Call<bool>(Hash.IS_VEHICLE_WINDOW_INTACT, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public Vehicle Vehicle => this._owner;

    public void Repair() => Function.Call(Hash.FIX_VEHICLE_WINDOW, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public void Smash() => Function.Call(Hash.SMASH_VEHICLE_WINDOW, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public void RollUp() => Function.Call(Hash.ROLL_UP_WINDOW, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public void RollDown() => Function.Call(Hash.ROLL_DOWN_WINDOW, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public void Remove() => Function.Call(Hash.REMOVE_VEHICLE_WINDOW, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);
  }
}
