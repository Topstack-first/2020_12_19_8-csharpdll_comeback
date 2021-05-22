// Decompiled with JetBrains decompiler
// Type: GTA.VehicleWindowCollection
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System.Collections.Generic;

namespace GTA
{
  public sealed class VehicleWindowCollection
  {
    private Vehicle _owner;
    private readonly Dictionary<VehicleWindowIndex, VehicleWindow> _vehicleWindows = new Dictionary<VehicleWindowIndex, VehicleWindow>();

    internal VehicleWindowCollection(Vehicle owner) => this._owner = owner;

    public VehicleWindow this[VehicleWindowIndex index]
    {
      get
      {
        VehicleWindow vehicleWindow = (VehicleWindow) null;
        if (!this._vehicleWindows.TryGetValue(index, out vehicleWindow))
        {
          vehicleWindow = new VehicleWindow(this._owner, index);
          this._vehicleWindows.Add(index, vehicleWindow);
        }
        return vehicleWindow;
      }
    }

    public bool AreAllWindowsIntact => Function.Call<bool>(Hash.ARE_ALL_VEHICLE_WINDOWS_INTACT, (InputArgument) this._owner.Handle);

    public void RollDownAllWindows() => Function.Call(Hash.ROLL_DOWN_WINDOWS, (InputArgument) this._owner.Handle);
  }
}
