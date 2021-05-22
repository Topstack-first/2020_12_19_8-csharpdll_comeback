namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Model : IEquatable<Model>, INativeValue
    {
        public Model(int hash)
        {
            this = new Model();
            this.Hash = hash;
        }

        public Model(string name) : this(Game.GenerateHash(name))
        {
        }

        public Model(PedHash hash) : this((int) hash)
        {
        }

        public Model(VehicleHash hash) : this((int) hash)
        {
        }

        public Model(WeaponHash hash) : this((int) hash)
        {
        }

        public ulong NativeValue
        {
            get => 
                (ulong) this.Hash;
            set => 
                this.Hash = (int) value;
        }
        public int Hash { get; private set; }
        public bool IsValid
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_MODEL_VALID, arguments);
            }
        }
        public bool IsInCdImage
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_MODEL_IN_CDIMAGE, arguments);
            }
        }
        public bool IsLoaded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.HAS_MODEL_LOADED, arguments);
            }
        }
        public bool IsCollisionLoaded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.HAS_COLLISION_FOR_MODEL_LOADED, arguments);
            }
        }
        public bool IsBicycle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BICYCLE, arguments);
            }
        }
        public bool IsBike
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BIKE, arguments);
            }
        }
        public bool IsBoat
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_BOAT, arguments);
            }
        }
        public bool IsCar
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_CAR, arguments);
            }
        }
        public bool IsAmphibiousCar
        {
            get
            {
                if (Game.Version < GameVersion.v1_0_944_2_Steam)
                {
                    return false;
                }
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash._IS_THIS_MODEL_AN_AMPHIBIOUS_CAR, arguments);
            }
        }
        public bool IsBlimp =>
            MemoryAccess.IsModelABlimp(this.Hash);
        public bool IsCargobob
        {
            get
            {
                VehicleHash hash = (VehicleHash) this.Hash;
                return ((hash == ((VehicleHash) (-50547061))) || ((hash == VehicleHash.Cargobob2) || ((hash == VehicleHash.Cargobob3) || (hash == VehicleHash.Cargobob4))));
            }
        }
        public bool IsHelicopter
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_HELI, arguments);
            }
        }
        public bool IsJetSki
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash._IS_THIS_MODEL_AN_EMERGENCY_BOAT, arguments);
            }
        }
        public bool IsPed =>
            MemoryAccess.IsModelAPed(this.Hash);
        public bool IsPlane
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_PLANE, arguments);
            }
        }
        public bool IsProp =>
            this.IsValid && (!this.IsPed && !this.IsVehicle);
        public bool IsQuadBike
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_QUADBIKE, arguments);
            }
        }
        public bool IsAmphibiousQuadBike =>
            (Game.Version >= GameVersion.v1_0_944_2_Steam) && MemoryAccess.IsModelAnAmphibiousQuadBike(this.Hash);
        public bool IsTrain
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_A_TRAIN, arguments);
            }
        }
        public bool IsTrailer =>
            MemoryAccess.IsModelATrailer(this.Hash);
        public bool IsVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Hash };
                return Function.Call<bool>(GTA.Native.Hash.IS_MODEL_A_VEHICLE, arguments);
            }
        }
        public bool IsAmphibiousVehicle =>
            (Game.Version >= GameVersion.v1_0_944_2_Steam) && (this.IsAmphibiousCar || this.IsAmphibiousQuadBike);
        public Vector3 GetDimensions()
        {
            Vector3 vector;
            Vector3 vector2;
            this.GetDimensions(out vector2, out vector);
            return Vector3.Subtract(vector, vector2);
        }

        public unsafe void GetDimensions(out Vector3 minimum, out Vector3 maximum)
        {
            NativeVector3 vector;
            NativeVector3 vector2;
            InputArgument[] arguments = new InputArgument[] { this.Hash, (IntPtr) &vector2, (IntPtr) &vector };
            Function.Call(GTA.Native.Hash.GET_MODEL_DIMENSIONS, arguments);
            minimum = (Vector3) vector2;
            maximum = (Vector3) vector;
        }

        public void Request()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash };
            Function.Call(GTA.Native.Hash.REQUEST_MODEL, arguments);
        }

        public bool Request(int timeout)
        {
            this.Request();
            DateTime time = (timeout >= 0) ? (DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout)) : DateTime.MaxValue;
            while (!this.IsLoaded)
            {
                Script.Yield();
                this.Request();
                if (DateTime.UtcNow >= time)
                {
                    return false;
                }
            }
            return true;
        }

        public void RequestCollision()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash };
            Function.Call(GTA.Native.Hash.REQUEST_COLLISION_FOR_MODEL, arguments);
        }

        public bool RequestCollision(int timeout)
        {
            this.Request();
            DateTime time = (timeout >= 0) ? (DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout)) : DateTime.MaxValue;
            while (!this.IsLoaded)
            {
                Script.Yield();
                this.RequestCollision();
                if (DateTime.UtcNow >= time)
                {
                    return false;
                }
            }
            return true;
        }

        public void MarkAsNoLongerNeeded()
        {
            InputArgument[] arguments = new InputArgument[] { this.Hash };
            Function.Call(GTA.Native.Hash.SET_MODEL_AS_NO_LONGER_NEEDED, arguments);
        }

        public bool Equals(Model model) => 
            this.Hash == model.Hash;

        public override bool Equals(object obj) => 
            (obj != null) && this.Equals((Model) obj);

        public override int GetHashCode() => 
            this.Hash;

        public override string ToString() => 
            "0x" + this.Hash.ToString("X");

        public static implicit operator Model(int source) => 
            new Model(source);

        public static implicit operator Model(string source) => 
            new Model(source);

        public static implicit operator Model(PedHash source) => 
            new Model(source);

        public static implicit operator Model(VehicleHash source) => 
            new Model(source);

        public static implicit operator Model(WeaponHash source) => 
            new Model(source);

        public static implicit operator int(Model source) => 
            source.Hash;

        public static implicit operator PedHash(Model source) => 
            (PedHash) source.Hash;

        public static implicit operator VehicleHash(Model source) => 
            (VehicleHash) source.Hash;

        public static implicit operator WeaponHash(Model source) => 
            (WeaponHash) source.Hash;

        public static bool operator ==(Model left, Model right) => 
            left.Equals(right);

        public static bool operator !=(Model left, Model right) => 
            !left.Equals(right);
    }
}

