// Decompiled with JetBrains decompiler
// Type: GTA.VehicleDoorCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Collections.Generic;

namespace GTA
{
  public sealed class VehicleDoorCollection
  {
    private Vehicle _owner;
    private readonly Dictionary<VehicleDoorIndex, VehicleDoor> _vehicleDoors = new Dictionary<VehicleDoorIndex, VehicleDoor>();

    internal VehicleDoorCollection(Vehicle owner) => this._owner = owner;

    public VehicleDoor this[VehicleDoorIndex index]
    {
      get
      {
        VehicleDoor vehicleDoor = (VehicleDoor) null;
        if (!this._vehicleDoors.TryGetValue(index, out vehicleDoor))
        {
          vehicleDoor = new VehicleDoor(this._owner, index);
          this._vehicleDoors.Add(index, vehicleDoor);
        }
        return vehicleDoor;
      }
    }

    public bool HasDoor(VehicleDoorIndex door)
    {
      switch (door)
      {
        case VehicleDoorIndex.FrontLeftDoor:
          return this._owner.Bones.HasBone("door_dside_f");
        case VehicleDoorIndex.FrontRightDoor:
          return this._owner.Bones.HasBone("door_pside_f");
        case VehicleDoorIndex.BackLeftDoor:
          return this._owner.Bones.HasBone("door_dside_r");
        case VehicleDoorIndex.BackRightDoor:
          return this._owner.Bones.HasBone("door_pside_r");
        case VehicleDoorIndex.Hood:
          return this._owner.Bones.HasBone("bonnet");
        case VehicleDoorIndex.Trunk:
          return this._owner.Bones.HasBone("boot");
        default:
          return false;
      }
    }

    public VehicleDoor[] GetAll()
    {
      List<VehicleDoor> vehicleDoorList = new List<VehicleDoor>();
      foreach (VehicleDoorIndex vehicleDoorIndex in Enum.GetValues(typeof (VehicleDoorIndex)))
      {
        if (this.HasDoor(vehicleDoorIndex))
          vehicleDoorList.Add(this[vehicleDoorIndex]);
      }
      return vehicleDoorList.ToArray();
    }

    public IEnumerator<VehicleDoor> GetEnumerator() => ((IEnumerable<VehicleDoor>) this.GetAll()).GetEnumerator();
  }
}
