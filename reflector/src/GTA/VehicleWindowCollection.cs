namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class VehicleWindowCollection
    {
        private Vehicle _owner;
        private readonly Dictionary<VehicleWindowIndex, VehicleWindow> _vehicleWindows = new Dictionary<VehicleWindowIndex, VehicleWindow>();

        internal VehicleWindowCollection(Vehicle owner)
        {
            this._owner = owner;
        }

        public void RollDownAllWindows()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
            Function.Call(Hash.ROLL_DOWN_WINDOWS, arguments);
        }

        public VehicleWindow this[VehicleWindowIndex index]
        {
            get
            {
                VehicleWindow window = null;
                if (!this._vehicleWindows.TryGetValue(index, out window))
                {
                    window = new VehicleWindow(this._owner, index);
                    this._vehicleWindows.Add(index, window);
                }
                return window;
            }
        }

        public bool AreAllWindowsIntact
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<bool>(Hash.ARE_ALL_VEHICLE_WINDOWS_INTACT, arguments);
            }
        }
    }
}

