namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class VehicleWindow
    {
        private GTA.Vehicle _owner;

        internal VehicleWindow(GTA.Vehicle owner, VehicleWindowIndex index)
        {
            this._owner = owner;
            this.Index = index;
        }

        public void Remove()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.REMOVE_VEHICLE_WINDOW, arguments);
        }

        public void Repair()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.FIX_VEHICLE_WINDOW, arguments);
        }

        public void RollDown()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.ROLL_DOWN_WINDOW, arguments);
        }

        public void RollUp()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.ROLL_UP_WINDOW, arguments);
        }

        public void Smash()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
            Function.Call(Hash.SMASH_VEHICLE_WINDOW, arguments);
        }

        public VehicleWindowIndex Index { get; private set; }

        public bool IsIntact
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
                return Function.Call<bool>(Hash.IS_VEHICLE_WINDOW_INTACT, arguments);
            }
        }

        public GTA.Vehicle Vehicle =>
            this._owner;
    }
}

