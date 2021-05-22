namespace GTA
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class VehicleDoorCollection
    {
        private Vehicle _owner;
        private readonly Dictionary<VehicleDoorIndex, VehicleDoor> _vehicleDoors = new Dictionary<VehicleDoorIndex, VehicleDoor>();

        internal VehicleDoorCollection(Vehicle owner)
        {
            this._owner = owner;
        }

        public VehicleDoor[] GetAll()
        {
            List<VehicleDoor> list = new List<VehicleDoor>();
            foreach (VehicleDoorIndex index in Enum.GetValues(typeof(VehicleDoorIndex)))
            {
                if (this.HasDoor(index))
                {
                    list.Add(this[index]);
                }
            }
            return list.ToArray();
        }

        public IEnumerator<VehicleDoor> GetEnumerator() => 
            this.GetAll().GetEnumerator();

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
            }
            return false;
        }

        public VehicleDoor this[VehicleDoorIndex index]
        {
            get
            {
                VehicleDoor door = null;
                if (!this._vehicleDoors.TryGetValue(index, out door))
                {
                    door = new VehicleDoor(this._owner, index);
                    this._vehicleDoors.Add(index, door);
                }
                return door;
            }
        }
    }
}

