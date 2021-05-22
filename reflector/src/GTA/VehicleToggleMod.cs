namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;

    public sealed class VehicleToggleMod
    {
        private GTA.Vehicle _owner;

        internal VehicleToggleMod(GTA.Vehicle owner, VehicleToggleModType modType)
        {
            this._owner = owner;
            this.ModType = modType;
        }

        public void Remove()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
            Function.Call(Hash.REMOVE_VEHICLE_MOD, arguments);
        }

        public VehicleToggleModType ModType { get; private set; }

        public bool IsInstalled
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
                return Function.Call<bool>(Hash.IS_TOGGLE_MOD_ON, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType, value };
                Function.Call(Hash.TOGGLE_VEHICLE_MOD, arguments);
            }
        }

        public string LocalizedModTypeName
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
                return Function.Call<string>(Hash.GET_MOD_SLOT_NAME, arguments);
            }
        }

        public GTA.Vehicle Vehicle =>
            this._owner;
    }
}

