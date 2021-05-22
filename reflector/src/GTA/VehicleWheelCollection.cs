namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class VehicleWheelCollection
    {
        private Vehicle _owner;
        private readonly Dictionary<int, VehicleWheel> _vehicleWheels = new Dictionary<int, VehicleWheel>();

        internal VehicleWheelCollection(Vehicle owner)
        {
            this._owner = owner;
        }

        public VehicleWheel this[int index]
        {
            get
            {
                VehicleWheel wheel = null;
                if (!this._vehicleWheels.TryGetValue(index, out wheel))
                {
                    wheel = new VehicleWheel(this._owner, index);
                    this._vehicleWheels.Add(index, wheel);
                }
                return wheel;
            }
        }

        public int Count
        {
            get
            {
                if (this._owner.MemoryAddress == IntPtr.Zero)
                {
                    return 0;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0xaa8 : 0xa88;
                num = (Game.Version >= GameVersion.v1_0_505_2_Steam) ? 0xa98 : num;
                num = (Game.Version >= GameVersion.v1_0_791_2_Steam) ? 0xab8 : num;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0xae8 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0xb18 : num;
                return MemoryAccess.ReadInt(this._owner.MemoryAddress + num);
            }
        }
    }
}

