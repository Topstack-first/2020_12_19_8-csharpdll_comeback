// Decompiled with JetBrains decompiler
// Type: GTA.VehicleWheel
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;

namespace GTA
{
  public sealed class VehicleWheel
  {
    private Vehicle _owner;

    internal VehicleWheel(Vehicle owner, int index)
    {
      this._owner = owner;
      this.Index = index;
    }

    public int Index { get; private set; }

    public Vehicle Vehicle => this._owner;

    public void Burst() => Function.Call(Hash.SET_VEHICLE_TYRE_BURST, (InputArgument) this._owner.Handle, (InputArgument) this.Index, (InputArgument) true, (InputArgument) 1000f);

    public void Fix() => Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, (InputArgument) this._owner.Handle, (InputArgument) this.Index);
  }
}
