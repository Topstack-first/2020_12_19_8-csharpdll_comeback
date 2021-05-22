namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public sealed class Pickup : PoolObject, IEquatable<Pickup>
    {
        public Pickup(int handle) : base(handle)
        {
        }

        public override void Delete()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.REMOVE_PICKUP, arguments);
        }

        public bool Equals(Pickup pickup) => 
            (pickup != null) && (base.Handle == pickup.Handle);

        public sealed override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Pickup) obj));

        public override bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_PICKUP_EXIST, arguments);
        }

        public static bool Exists(Pickup pickup) => 
            (pickup != null) && pickup.Exists();

        public sealed override int GetHashCode() => 
            base.Handle;

        public bool ObjectExists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_PICKUP_OBJECT_EXIST, arguments);
        }

        public static bool operator ==(Pickup left, Pickup right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Pickup left, Pickup right) => 
            !(left == right);

        public Vector3 Position
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<Vector3>(Hash.GET_PICKUP_COORDS, arguments);
            }
        }

        public bool IsCollected
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.HAS_PICKUP_BEEN_COLLECTED, arguments);
            }
        }
    }
}

