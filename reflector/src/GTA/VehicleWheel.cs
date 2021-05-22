namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class VehicleWheel
    {
        private GTA.Vehicle _owner;

        internal VehicleWheel(GTA.Vehicle owner, int index)
        {
            this._owner = owner;
            this.Index = index;
        }

        public void Burst()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, true, 1000f };
            Function.Call(Hash.SET_VEHICLE_TYRE_BURST, arguments);
        }

        public void Fix()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.SET_VEHICLE_TYRE_FIXED, arguments);
        }

        public int Index { get; private set; }

        public GTA.Vehicle Vehicle =>
            this._owner;
    }
}

