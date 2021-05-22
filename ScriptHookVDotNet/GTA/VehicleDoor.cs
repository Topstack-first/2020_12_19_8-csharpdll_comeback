// Decompiled with JetBrains decompiler
// Type: GTA.VehicleDoor
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public sealed class VehicleDoor
  {
    private Vehicle _owner;

    internal VehicleDoor(Vehicle owner, VehicleDoorIndex index)
    {
      this._owner = owner;
      this.Index = index;
    }

    public VehicleDoorIndex Index { get; private set; }

    public float AngleRatio
    {
      get => Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);
      set => Function.Call(Hash.SET_VEHICLE_DOOR_CONTROL, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index, (InputArgument) 1, (InputArgument) value);
    }

    public bool CanBeBroken
    {
      set => Function.Call(Hash._SET_VEHICLE_DOOR_CAN_BREAK, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index, (InputArgument) value);
    }

    public bool IsOpen => (double) this.AngleRatio > 0.0;

    public bool IsFullyOpen => Function.Call<bool>(Hash.IS_VEHICLE_DOOR_FULLY_OPEN, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public bool IsBroken => Function.Call<bool>(Hash.IS_VEHICLE_DOOR_DAMAGED, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index);

    public Vehicle Vehicle => this._owner;

    public void Open(bool loose = false, bool instantly = false) => Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index, (InputArgument) loose, (InputArgument) instantly);

    public void Close(bool instantly = false) => Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index, (InputArgument) instantly);

    public void Break(bool stayInTheWorld = true) => Function.Call(Hash.SET_VEHICLE_DOOR_BROKEN, (InputArgument) this._owner.Handle, (InputArgument) (Enum) this.Index, (InputArgument) !stayInTheWorld);
  }
}
