namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public sealed class Vehicle : Entity
    {
        private VehicleDoorCollection _doors;
        private VehicleModCollection _mods;
        private VehicleWheelCollection _wheels;
        private VehicleWindowCollection _windows;

        public Vehicle(int handle) : base(handle)
        {
        }

        public void CargoBobMagnetGrabVehicle()
        {
            if (this.IsCargobobHookActive(CargobobHook.Magnet))
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, true };
                Function.Call(Hash._SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, arguments);
            }
        }

        public void CargoBobMagnetReleaseVehicle()
        {
            if (this.IsCargobobHookActive(CargobobHook.Magnet))
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                Function.Call(Hash._SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, arguments);
            }
        }

        public void CloseBombBay()
        {
            if (this.HasBombBay)
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                Function.Call(Hash.CLOSE_BOMB_BAY_DOORS, arguments);
            }
        }

        public Ped CreatePedOnSeat(VehicleSeat seat, Model model)
        {
            if (!this.IsSeatFree(seat))
            {
                throw new ArgumentException("The VehicleSeat selected was not free", "seat");
            }
            if (!model.IsPed || !model.Request(0x3e8))
            {
                return null;
            }
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0x1a, model.Hash, seat, 1, 1 };
            return new Ped(Function.Call<int>(Hash.CREATE_PED_INSIDE_VEHICLE, arguments));
        }

        public Ped CreateRandomPedOnSeat(VehicleSeat seat)
        {
            if (!this.IsSeatFree(seat))
            {
                throw new ArgumentException("The VehicleSeat selected was not free", "seat");
            }
            if (seat == VehicleSeat.Driver)
            {
                InputArgument[] argumentArray1 = new InputArgument[] { base.Handle, true };
                return new Ped(Function.Call<int>(Hash.CREATE_RANDOM_PED_AS_DRIVER, argumentArray1));
            }
            InputArgument[] arguments = new InputArgument[] { 0f, 0f, 0f };
            int handle = Function.Call<int>(Hash.CREATE_RANDOM_PED, arguments);
            InputArgument[] argumentArray3 = new InputArgument[] { handle, base.Handle, seat };
            Function.Call(Hash.SET_PED_INTO_VEHICLE, argumentArray3);
            return new Ped(handle);
        }

        public void Deform(Vector3 position, float damageAmount, float radius)
        {
            InputArgument[] arguments = new InputArgument[] { position.X, position.Y, position.Z, damageAmount, radius };
            Function.Call(Hash.SET_VEHICLE_DAMAGE, arguments);
        }

        public void DetachFromTowTruck()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.DETACH_VEHICLE_FROM_ANY_TOW_TRUCK, arguments);
        }

        public void DetachTowedVehicle()
        {
            Vehicle towedVehicle = this.TowedVehicle;
            if (Exists(towedVehicle))
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, towedVehicle.Handle };
                Function.Call(Hash.DETACH_VEHICLE_FROM_TOW_TRUCK, arguments);
            }
        }

        public void DropCargobobHook(CargobobHook hook)
        {
            if (base.Model.IsCargobob)
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, hook };
                Function.Call(Hash.CREATE_PICK_UP_ROPE_FOR_CARGOBOB, arguments);
            }
        }

        public bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return (Function.Call<int>(Hash.GET_ENTITY_TYPE, arguments) == 2);
        }

        public static bool Exists(Vehicle vehicle) => 
            (vehicle != null) && vehicle.Exists();

        public void Explode()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, true, false };
            Function.Call(Hash.EXPLODE_VEHICLE, arguments);
        }

        public bool ExtraExists(int extra)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, extra };
            return Function.Call<bool>(Hash.DOES_EXTRA_EXIST, arguments);
        }

        public static VehicleHash[] GetAllModels()
        {
            List<VehicleHash> list = new List<VehicleHash>();
            for (int i = 0; i < 0x20; i++)
            {
                Converter<int, VehicleHash> converter = <>c.<>9__285_0;
                if (<>c.<>9__285_0 == null)
                {
                    Converter<int, VehicleHash> local1 = <>c.<>9__285_0;
                    converter = <>c.<>9__285_0 = item => (VehicleHash) item;
                }
                list.AddRange(Array.ConvertAll<int, VehicleHash>(MemoryAccess.VehicleModels[i].ToArray<int>(), converter));
            }
            return list.ToArray();
        }

        public static VehicleHash[] GetAllModelsOfClass(VehicleClass vehicleClass)
        {
            Converter<int, VehicleHash> converter = <>c.<>9__284_0;
            if (<>c.<>9__284_0 == null)
            {
                Converter<int, VehicleHash> local1 = <>c.<>9__284_0;
                converter = <>c.<>9__284_0 = item => (VehicleHash) item;
            }
            return Array.ConvertAll<int, VehicleHash>(MemoryAccess.VehicleModels[(int) vehicleClass].ToArray<int>(), converter);
        }

        public static string GetClassDisplayName(VehicleClass vehicleClass) => 
            "VEH_CLASS_" + ((int) vehicleClass).ToString();

        public static VehicleClass GetModelClass(Model vehicleModel)
        {
            InputArgument[] arguments = new InputArgument[] { vehicleModel.Hash };
            return Function.Call<VehicleClass>(Hash.GET_VEHICLE_CLASS_FROM_NAME, arguments);
        }

        public static string GetModelDisplayName(Model vehicleModel)
        {
            InputArgument[] arguments = new InputArgument[] { vehicleModel.Hash };
            return Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, arguments);
        }

        public Ped GetPedOnSeat(VehicleSeat seat)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, seat };
            return new Ped(Function.Call<int>(Hash.GET_PED_IN_VEHICLE_SEAT, arguments));
        }

        public bool IsCargobobHookActive()
        {
            if (!base.Model.IsCargobob)
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            if (Function.Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, arguments))
            {
                return true;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash._DOES_CARGOBOB_HAVE_PICKUP_MAGNET, argumentArray2);
        }

        public bool IsCargobobHookActive(CargobobHook hook)
        {
            if (base.Model.IsCargobob)
            {
                if (hook == CargobobHook.Hook)
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle };
                    return Function.Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, arguments);
                }
                if (hook == CargobobHook.Magnet)
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle };
                    return Function.Call<bool>(Hash._DOES_CARGOBOB_HAVE_PICKUP_MAGNET, arguments);
                }
            }
            return false;
        }

        public bool IsExtraOn(int extra)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, extra };
            return Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, arguments);
        }

        public bool IsSeatFree(VehicleSeat seat)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, seat };
            return Function.Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, arguments);
        }

        public void OpenBombBay()
        {
            if (this.HasBombBay)
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                Function.Call(Hash.OPEN_BOMB_BAY_DOORS, arguments);
            }
        }

        public bool PlaceOnGround()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, arguments);
        }

        public void PlaceOnNextStreet()
        {
            Vector3 position = this.Position;
            OutputArgument argument2 = new OutputArgument();
            OutputArgument argument = new OutputArgument();
            for (int i = 1; i < 40; i++)
            {
                InputArgument[] arguments = new InputArgument[10];
                arguments[0] = position.X;
                arguments[1] = position.Y;
                arguments[2] = position.Z;
                arguments[3] = i;
                arguments[4] = argument;
                arguments[5] = argument2;
                arguments[6] = new OutputArgument();
                arguments[7] = 1;
                arguments[8] = 0x40400000;
                arguments[9] = 0;
                Function.Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING, arguments);
                Vector3 result = argument.GetResult<Vector3>();
                InputArgument[] argumentArray2 = new InputArgument[] { result.X, result.Y, result.Z, 5f, 5f, 5f, 0 };
                if (!Function.Call<bool>(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, argumentArray2))
                {
                    this.Position = result;
                    this.PlaceOnGround();
                    base.Heading = argument2.GetResult<float>();
                    return;
                }
            }
        }

        public void Repair()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.SET_VEHICLE_FIXED, arguments);
        }

        public void RetractCargobobHook()
        {
            if (base.Model.IsCargobob)
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                Function.Call(Hash.REMOVE_PICK_UP_ROPE_FOR_CARGOBOB, arguments);
            }
        }

        public void SetHeliYawPitchRollMult(float mult)
        {
            if (base.Model.IsHelicopter && ((mult >= 0f) && (mult <= 1f)))
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, mult };
                Function.Call(Hash._SET_HELICOPTER_ROLL_PITCH_YAW_MULT, arguments);
            }
        }

        public void SoundHorn(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, duration, Game.GenerateHash("HELDDOWN"), 0 };
            Function.Call(Hash.START_VEHICLE_HORN, arguments);
        }

        public void StartAlarm()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.START_VEHICLE_ALARM, arguments);
        }

        public void ToggleExtra(int extra, bool toggle)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, extra, !toggle };
            Function.Call(Hash.SET_VEHICLE_EXTRA, arguments);
        }

        public void TowVehicle(Vehicle vehicle, bool rear)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vehicle.Handle, rear, 0f, 0f, 0f };
            Function.Call(Hash.ATTACH_VEHICLE_TO_TOW_TRUCK, arguments);
        }

        public void Wash()
        {
            this.DirtLevel = 0f;
        }

        public string DisplayName =>
            GetModelDisplayName(base.Model);

        public string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        public string ClassDisplayName =>
            GetClassDisplayName(this.ClassType);

        public string ClassLocalizedName =>
            Game.GetGXTEntry(this.ClassDisplayName);

        public VehicleClass ClassType
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<VehicleClass>(Hash.GET_VEHICLE_CLASS, arguments);
            }
        }

        public float BodyHealth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_BODY_HEALTH, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_BODY_HEALTH, arguments);
            }
        }

        public float EngineHealth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_ENGINE_HEALTH, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_ENGINE_HEALTH, arguments);
            }
        }

        public float PetrolTankHealth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_PETROL_TANK_HEALTH, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, arguments);
            }
        }

        public float HeliMainRotorHealth
        {
            get
            {
                if (!base.Model.IsHelicopter)
                {
                    return 0f;
                }
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash._GET_HELI_MAIN_ROTOR_HEALTH, arguments);
            }
            set
            {
                if ((base.MemoryAddress != IntPtr.Zero) && base.Model.IsHelicopter)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x174c : 0x173c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x176c : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x181c : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x184c : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x18ec : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float HeliTailRotorHealth
        {
            get
            {
                if (!base.Model.IsHelicopter)
                {
                    return 0f;
                }
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash._GET_HELI_TAIL_ROTOR_HEALTH, arguments);
            }
            set
            {
                if ((base.MemoryAddress != IntPtr.Zero) && base.Model.IsHelicopter)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1750 : 0x1740;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x1770 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x1820 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x1850 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x18f0 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float HeliEngineHealth
        {
            get
            {
                if (!base.Model.IsHelicopter)
                {
                    return 0f;
                }
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash._GET_HELI_ENGINE_HEALTH, arguments);
            }
            set
            {
                if ((base.MemoryAddress != IntPtr.Zero) && base.Model.IsHelicopter)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1754 : 0x1744;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x1774 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x1824 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x1854 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x18f4 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float FuelLevel
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x768 : 0x758;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x788 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7a8 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7b8 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7d4 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x768 : 0x758;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x788 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7a8 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7b8 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7d4 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float OilLevel
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x76c : 0x75c;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x78c : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7ac : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7bc : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7d8 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x76c : 0x75c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x78c : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7ac : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7bc : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7d8 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float Gravity
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0xb2c : 0xb1c;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0xb4c : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0xb7c : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0xb8c : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xbac : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0xb2c : 0xb1c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0xb4c : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0xb7c : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0xb8c : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xbac : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public bool IsEngineRunning
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.GET_IS_VEHICLE_ENGINE_RUNNING, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value, true };
                Function.Call(Hash.SET_VEHICLE_ENGINE_ON, arguments);
            }
        }

        public bool IsEngineStarting
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x842 : 0x832;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x862 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x88a : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x89a : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8ba : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 5);
            }
        }

        public bool IsRadioEnabled
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_RADIO_ENABLED, arguments);
            }
        }

        public GTA.RadioStation RadioStation
        {
            set
            {
                if (value == GTA.RadioStation.RadioOff)
                {
                    InputArgument[] arguments = new InputArgument[] { "OFF" };
                    Function.Call(Hash.SET_VEH_RADIO_STATION, arguments);
                }
                else if (Enum.IsDefined(typeof(GTA.RadioStation), value))
                {
                    InputArgument[] arguments = new InputArgument[] { Game._radioNames[(int) value] };
                    Function.Call(Hash.SET_VEH_RADIO_STATION, arguments);
                }
            }
        }

        public float ForwardSpeed
        {
            set
            {
                if (!base.Model.IsTrain)
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                    Function.Call(Hash.SET_VEHICLE_FORWARD_SPEED, arguments);
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                    Function.Call(Hash.SET_TRAIN_SPEED, arguments);
                    InputArgument[] argumentArray2 = new InputArgument[] { base.Handle, value };
                    Function.Call(Hash.SET_TRAIN_CRUISE_SPEED, argumentArray2);
                }
            }
        }

        public float WheelSpeed
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x9a4 : 0x994;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x9c4 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x9f0 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0xa00 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xa10 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
        }

        public float HeliBladesSpeed
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                if (!base.Model.IsHelicopter)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1740 : 0x1730;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x1760 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x1810 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x1840 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x18e0 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.Model.IsHelicopter)
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                    Function.Call(Hash.SET_HELI_BLADES_SPEED, arguments);
                }
            }
        }

        public float Acceleration
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7e4 : 0x7d4;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x804 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x824 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x834 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x854 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
        }

        public float CurrentRPM
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7d4 : 0x7c4;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7f4 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x814 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x824 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x844 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7d4 : 0x7c4;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7f4 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x814 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x824 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x844 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public byte HighGear
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a6 : 0x796;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c6 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e6 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f6 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x816 : num;
                return MemoryAccess.ReadByte(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    if ((value < 0) || (value > 7))
                    {
                        throw new ArgumentOutOfRangeException("value", "Values must be between 0 and 7, inclusive.");
                    }
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a6 : 0x796;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c6 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e6 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f6 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x816 : num;
                    MemoryAccess.WriteByte(base.MemoryAddress + num, value);
                }
            }
        }

        public byte CurrentGear
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a2 : 0x792;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c2 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e2 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f2 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x812 : num;
                return MemoryAccess.ReadByte(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a2 : 0x792;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c2 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e2 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f2 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x812 : num;
                    MemoryAccess.WriteByte(base.MemoryAddress + num, value);
                }
            }
        }

        public float EngineTemperature
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x984 : 0;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x9ac : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x9bc : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x9dc : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
        }

        public float OilVolume =>
            !(base.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(base.MemoryAddress + 260) : 0f;

        public float PetrolTankVolume =>
            !(base.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(base.MemoryAddress + 0x100) : 0f;

        public float Clutch
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7e0 : 0x7d0;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x800 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x820 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x830 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x850 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7e0 : 0x7d0;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x800 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x820 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x830 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x850 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float Turbo
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7f8 : 0x7d8;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x818 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x838 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x848 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x868 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7f8 : 0x7d8;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x818 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x838 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x848 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x868 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public int Gears
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a0 : 0x790;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c0 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e0 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f0 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x810 : num;
                return MemoryAccess.ReadInt(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a0 : 0x790;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c0 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e0 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f0 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x810 : num;
                    MemoryAccess.WriteInt(base.MemoryAddress + num, value);
                }
            }
        }

        public float NextGear
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a0 : 0x790;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c0 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e0 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f0 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x810 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7a0 : 0x790;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x7c0 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7e0 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7f0 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x810 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float Throttle
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7e4 : 0x7d4;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x804 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x824 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x834 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x854 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x7e4 : 0x7d4;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x804 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x824 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x834 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x854 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float ThrottlePower
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8b4 : 0x8a4;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8d4 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8fc : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x90c : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x92c : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8b4 : 0x8a4;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8d4 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8fc : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x90c : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x92c : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float BrakePower
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8b8 : 0x8a8;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8d8 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x900 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x910 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x930 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8b8 : 0x8a8;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8d8 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x900 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x910 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x930 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float SteeringAngle
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8ac : 0x89c;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8cc : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8f4 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x904 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x924 : num;
                return (float) (MemoryAccess.ReadFloat(base.MemoryAddress + num) * 57.295779513082323);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8ac : 0x89c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8cc : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8f4 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x904 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x924 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float SteeringScale
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8a4 : 0x894;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8c4 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8ec : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x8fc : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x91c : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x8a4 : 0x894;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x8c4 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x8ec : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x8fc : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x91c : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public bool HasForks =>
            this.Bones.HasBone("forks");

        public bool IsAlarmSet
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x998 : 0x988;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x9b8 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x9e4 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x9f4 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x1018 : num;
                return (((ushort) MemoryAccess.ReadShort(base.MemoryAddress + num)) == 0xffff);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_ALARM, arguments);
            }
        }

        public bool IsAlarmSounding
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_ALARM_ACTIVATED, arguments);
            }
        }

        public int AlarmTimeLeft
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x998 : 0x988;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x9b8 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x9e4 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x9f4 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xa18 : num;
                ushort num2 = (ushort) MemoryAccess.ReadShort(base.MemoryAddress + num);
                return ((num2 != 0xffff) ? num2 : 0);
            }
            set
            {
                ushort num2 = (ushort) value;
                if ((num2 != 0xffff) && (base.MemoryAddress != IntPtr.Zero))
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x998 : 0x988;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x9b8 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x9e4 : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x9f4 : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xa18 : num;
                    MemoryAccess.WriteShort(base.MemoryAddress + num, (short) num2);
                }
            }
        }

        public bool HasSiren =>
            this.Bones.HasBone("siren1");

        public bool IsSirenActive
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_SIREN_ON, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_SIREN, arguments);
            }
        }

        public bool IsSirenSilent
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.DISABLE_VEHICLE_IMPACT_EXPLOSION_ACTIVATION, arguments);
            }
        }

        public bool IsWanted
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x84c : 0x83c;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x86c : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x894 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x8a4 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8c4 : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 3);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_IS_WANTED, arguments);
            }
        }

        public bool ProvidesCover
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x83c : 0x82c;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x85c : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x884 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x894 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8b4 : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 2);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_PROVIDES_COVER, arguments);
            }
        }

        public bool DropsMoneyOnExplosion
        {
            get
            {
                IntPtr memoryAddress = base.MemoryAddress;
                if (memoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0xa98 : 0xa78;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0xac8 : num;
                return ((MemoryAccess.ReadInt(memoryAddress + ((Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0xad8 : num)) <= 8) && MemoryAccess.IsBitSet(memoryAddress + 0x12f9, 1));
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash._SET_VEHICLE_CREATES_MONEY_PICKUPS_WHEN_EXPLODED, arguments);
            }
        }

        public bool PreviouslyOwnedByPlayer
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x844 : 0x834;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x864 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x88c : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x89c : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8bc : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 1);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_HAS_BEEN_OWNED_BY_PLAYER, arguments);
            }
        }

        public bool NeedsToBeHotwired
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x844 : 0x834;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x864 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x88c : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x89c : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8bc : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 2);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_NEEDS_TO_BE_HOTWIRED, arguments);
            }
        }

        public bool AreLightsOn
        {
            get
            {
                OutputArgument argument = new OutputArgument();
                OutputArgument argument2 = new OutputArgument();
                InputArgument[] arguments = new InputArgument[] { base.Handle, argument, argument2 };
                Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, arguments);
                return argument.GetResult<bool>();
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value ? 3 : 4 };
                Function.Call(Hash.SET_VEHICLE_LIGHTS, arguments);
            }
        }

        public bool AreHighBeamsOn
        {
            get
            {
                OutputArgument argument2 = new OutputArgument();
                OutputArgument argument = new OutputArgument();
                InputArgument[] arguments = new InputArgument[] { base.Handle, argument2, argument };
                Function.Call(Hash.GET_VEHICLE_LIGHTS_STATE, arguments);
                return argument.GetResult<bool>();
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_FULLBEAM, arguments);
            }
        }

        public bool IsInteriorLightOn
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x841 : 0x831;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x861 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x889 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x899 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8b9 : num;
                return MemoryAccess.IsBitSet(base.MemoryAddress + num, 6);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_INTERIORLIGHT, arguments);
            }
        }

        public bool IsSearchLightOn
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_SEARCHLIGHT_ON, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value, 0 };
                Function.Call(Hash.SET_VEHICLE_SEARCHLIGHT, arguments);
            }
        }

        public bool IsTaxiLightOn
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_TAXI_LIGHT_ON, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_TAXI_LIGHTS, arguments);
            }
        }

        public bool IsLeftIndicatorLightOn
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, true, value };
                Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, arguments);
            }
        }

        public bool IsRightIndicatorLightOn
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, false, value };
                Function.Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, arguments);
            }
        }

        public bool IsHandbrakeForcedOn
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_HANDBRAKE, arguments);
            }
        }

        public bool AreBrakeLightsOn
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_BRAKE_LIGHTS, arguments);
            }
        }

        public float LightsMultiplier
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x90c : 0x8fc;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x92c : num;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x954 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x964 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x984 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_LIGHT_MULTIPLIER, arguments);
            }
        }

        public float LodMultiplier
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1204 : 0x11f4;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x1224 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x1264 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x1274 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x12a8 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, arguments);
            }
        }

        public bool CanBeVisiblyDamaged
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, arguments);
            }
        }

        public bool IsDamaged
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash._IS_VEHICLE_DAMAGED, arguments);
            }
        }

        public bool IsDriveable
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 0 };
                return Function.Call<bool>(Hash.IS_VEHICLE_DRIVEABLE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, !value };
                Function.Call(Hash.SET_VEHICLE_UNDRIVEABLE, arguments);
            }
        }

        public bool HasRoof
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.DOES_VEHICLE_HAVE_ROOF, arguments);
            }
        }

        public bool IsLeftHeadLightBroken
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.GET_IS_LEFT_VEHICLE_HEADLIGHT_DAMAGED, arguments);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x77c : 0x76c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x79c : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7bc : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7cc : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7ec : num;
                    if (value)
                    {
                        MemoryAccess.SetBit(base.MemoryAddress + num, 0);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(base.MemoryAddress + num, 0);
                    }
                }
            }
        }

        public bool IsRightHeadLightBroken
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.GET_IS_RIGHT_VEHICLE_HEADLIGHT_DAMAGED, arguments);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x77c : 0x76c;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x79c : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x7bc : num;
                    num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x7cc : num;
                    num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x7ec : num;
                    if (value)
                    {
                        MemoryAccess.SetBit(base.MemoryAddress + num, 0);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(base.MemoryAddress + num, 0);
                    }
                }
            }
        }

        public bool IsRearBumperBrokenOff
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                return Function.Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, arguments);
            }
        }

        public bool IsFrontBumperBrokenOff
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, true };
                return Function.Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, arguments);
            }
        }

        public bool IsAxlesStrong
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call<bool>(Hash.SET_VEHICLE_HAS_STRONG_AXLES, arguments);
            }
        }

        public bool CanEngineDegrade
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_ENGINE_CAN_DEGRADE, arguments);
            }
        }

        public float EnginePowerMultiplier
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x9d0 : 0x9c0;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x9f0 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0xa18 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0xa28 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0xa48 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash._SET_VEHICLE_ENGINE_POWER_MULTIPLIER, arguments);
            }
        }

        public float EngineTorqueMultiplier
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash._SET_VEHICLE_ENGINE_TORQUE_MULTIPLIER, arguments);
            }
        }

        public VehicleLandingGearState LandingGearState
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<VehicleLandingGearState>(Hash.GET_LANDING_GEAR_STATE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.CONTROL_LANDING_GEAR, arguments);
            }
        }

        public VehicleRoofState RoofState
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<VehicleRoofState>(Hash.GET_CONVERTIBLE_ROOF_STATE, arguments);
            }
            set
            {
                switch (value)
                {
                    case VehicleRoofState.Closed:
                    {
                        InputArgument[] arguments = new InputArgument[] { base.Handle, true };
                        Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, arguments);
                        InputArgument[] argumentArray2 = new InputArgument[] { base.Handle, false };
                        Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, argumentArray2);
                        return;
                    }
                    case VehicleRoofState.Opening:
                    {
                        InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                        Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, arguments);
                        return;
                    }
                    case VehicleRoofState.Opened:
                    {
                        InputArgument[] arguments = new InputArgument[] { base.Handle, true };
                        Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, arguments);
                        InputArgument[] argumentArray5 = new InputArgument[] { base.Handle, false };
                        Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, argumentArray5);
                        return;
                    }
                    case VehicleRoofState.Closing:
                    {
                        InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                        Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, arguments);
                        return;
                    }
                }
            }
        }

        public VehicleLockStatus LockStatus
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<VehicleLockStatus>(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_DOORS_LOCKED, arguments);
            }
        }

        public float MaxBraking
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_MAX_BRAKING, arguments);
            }
        }

        public float MaxTraction
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_MAX_TRACTION, arguments);
            }
        }

        public bool IsOnAllWheels
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_ON_ALL_WHEELS, arguments);
            }
        }

        public bool IsStopped
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_STOPPED, arguments);
            }
        }

        public bool IsStoppedAtTrafficLights
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS, arguments);
            }
        }

        public bool IsStolen
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_STOLEN, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_IS_STOLEN, arguments);
            }
        }

        public bool IsConvertible
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 0 };
                return Function.Call<bool>(Hash.IS_VEHICLE_A_CONVERTIBLE, arguments);
            }
        }

        public bool IsBurnoutForced
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call<bool>(Hash.SET_VEHICLE_BURNOUT, arguments);
            }
        }

        public bool IsInBurnout
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_VEHICLE_IN_BURNOUT, arguments);
            }
        }

        public Ped Driver =>
            this.GetPedOnSeat(VehicleSeat.Driver);

        public Ped[] Occupants
        {
            get
            {
                Ped driver = this.Driver;
                if (!Ped.Exists(driver))
                {
                    return this.Passengers;
                }
                Ped[] pedArray = new Ped[] { driver };
                int num = 0;
                int num2 = 0;
                int passengerCapacity = this.PassengerCapacity;
                while ((num < passengerCapacity) && (num2 < pedArray.Length))
                {
                    if (!this.IsSeatFree((VehicleSeat) num))
                    {
                        pedArray[num2++ + 1] = this.GetPedOnSeat((VehicleSeat) num);
                    }
                    num++;
                }
                return pedArray;
            }
        }

        public Ped[] Passengers
        {
            get
            {
                Ped[] pedArray = new Ped[this.PassengerCount];
                if (pedArray.Length != 0)
                {
                    int num = 0;
                    int num2 = 0;
                    int passengerCapacity = this.PassengerCapacity;
                    while ((num < passengerCapacity) && (num2 < pedArray.Length))
                    {
                        if (!this.IsSeatFree((VehicleSeat) num))
                        {
                            pedArray[num2++] = this.GetPedOnSeat((VehicleSeat) num);
                        }
                        num++;
                    }
                }
                return pedArray;
            }
        }

        public int PassengerCapacity
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, arguments);
            }
        }

        public int PassengerCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_VEHICLE_NUMBER_OF_PASSENGERS, arguments);
            }
        }

        public VehicleDoorCollection Doors
        {
            get
            {
                this._doors ??= new VehicleDoorCollection(this);
                return this._doors;
            }
        }

        public VehicleModCollection Mods
        {
            get
            {
                this._mods ??= new VehicleModCollection(this);
                return this._mods;
            }
        }

        public VehicleWheelCollection Wheels
        {
            get
            {
                this._wheels ??= new VehicleWheelCollection(this);
                return this._wheels;
            }
        }

        public VehicleWindowCollection Windows
        {
            get
            {
                this._windows ??= new VehicleWindowCollection(this);
                return this._windows;
            }
        }

        public float DirtLevel
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_VEHICLE_DIRT_LEVEL, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_DIRT_LEVEL, arguments);
            }
        }

        public bool CanTiresBurst
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.GET_VEHICLE_TYRES_CAN_BURST, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, arguments);
            }
        }

        public bool CanWheelsBreak
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x83b : 0x82b;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x85b : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x883 : num;
                num = (Game.Version >= GameVersion.v1_0_1103_2_Steam) ? 0x893 : num;
                num = (Game.Version >= GameVersion.v1_0_1180_2_Steam) ? 0x8b3 : num;
                return !MemoryAccess.IsBitSet(base.MemoryAddress + num, 6);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, arguments);
            }
        }

        public bool HasBombBay =>
            this.Bones.HasBone("door_hatch_l") && this.Bones.HasBone("door_hatch_r");

        public bool HasTowArm =>
            this.Bones.HasBone("tow_arm");

        public float TowingCraneRaisedAmount
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash._SET_TOW_TRUCK_CRANE_HEIGHT, arguments);
            }
        }

        public Vehicle TowedVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return new Vehicle(Function.Call<int>(Hash.GET_ENTITY_ATTACHED_TO_TOW_TRUCK, arguments));
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly Vehicle.<>c <>9 = new Vehicle.<>c();
            public static Converter<int, VehicleHash> <>9__284_0;
            public static Converter<int, VehicleHash> <>9__285_0;

            internal VehicleHash <GetAllModels>b__285_0(int item) => 
                (VehicleHash) item;

            internal VehicleHash <GetAllModelsOfClass>b__284_0(int item) => 
                (VehicleHash) item;
        }
    }
}

