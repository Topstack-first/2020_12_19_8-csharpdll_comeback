namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed class VehicleDoor
    {
        private GTA.Vehicle _owner;

        internal VehicleDoor(GTA.Vehicle owner, VehicleDoorIndex index)
        {
            this._owner = owner;
            this.Index = index;
        }

        public void Break(bool stayInTheWorld = true)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, !stayInTheWorld };
            Function.Call(Hash.SET_VEHICLE_DOOR_BROKEN, arguments);
        }

        public void Close(bool instantly = false)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, instantly };
            Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, arguments);
        }

        public void Open(bool loose = false, bool instantly = false)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, loose, instantly };
            Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, arguments);
        }

        public VehicleDoorIndex Index { get; private set; }

        public float AngleRatio
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
                return Function.Call<float>(Hash.GET_VEHICLE_DOOR_ANGLE_RATIO, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, 1, value };
                Function.Call(Hash.SET_VEHICLE_DOOR_CONTROL, arguments);
            }
        }

        public bool CanBeBroken
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index, value };
                Function.Call(Hash._SET_VEHICLE_DOOR_CAN_BREAK, arguments);
            }
        }

        public bool IsOpen =>
            this.AngleRatio > 0f;

        public bool IsFullyOpen
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
                return Function.Call<bool>(Hash.IS_VEHICLE_DOOR_FULLY_OPEN, arguments);
            }
        }

        public bool IsBroken
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.Index };
                return Function.Call<bool>(Hash.IS_VEHICLE_DOOR_DAMAGED, arguments);
            }
        }

        public GTA.Vehicle Vehicle =>
            this._owner;
    }
}

