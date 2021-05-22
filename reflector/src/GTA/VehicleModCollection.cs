namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public sealed class VehicleModCollection
    {
        private Vehicle _owner;
        private readonly Dictionary<VehicleModType, VehicleMod> _vehicleMods = new Dictionary<VehicleModType, VehicleMod>();
        private readonly Dictionary<VehicleToggleModType, VehicleToggleMod> _vehicleToggleMods = new Dictionary<VehicleToggleModType, VehicleToggleMod>();
        private static readonly ReadOnlyDictionary<VehicleWheelType, Tuple<string, string>> _wheelNames;

        static VehicleModCollection()
        {
            Dictionary<VehicleWheelType, Tuple<string, string>> dictionary = new Dictionary<VehicleWheelType, Tuple<string, string>>();
            dictionary.Add(VehicleWheelType.BikeWheels, new Tuple<string, string>("CMOD_WHE1_0", "Bike"));
            dictionary.Add(VehicleWheelType.HighEnd, new Tuple<string, string>("CMOD_WHE1_1", "High End"));
            dictionary.Add(VehicleWheelType.Lowrider, new Tuple<string, string>("CMOD_WHE1_2", "Lowrider"));
            dictionary.Add(VehicleWheelType.Muscle, new Tuple<string, string>("CMOD_WHE1_3", "Muscle"));
            dictionary.Add(VehicleWheelType.Offroad, new Tuple<string, string>("CMOD_WHE1_4", "Offroad"));
            dictionary.Add(VehicleWheelType.Sport, new Tuple<string, string>("CMOD_WHE1_5", "Sport"));
            dictionary.Add(VehicleWheelType.SUV, new Tuple<string, string>("CMOD_WHE1_6", "SUV"));
            dictionary.Add(VehicleWheelType.Tuner, new Tuple<string, string>("CMOD_WHE1_7", "Tuner"));
            dictionary.Add(VehicleWheelType.BennysOriginals, new Tuple<string, string>("CMOD_WHE1_8", "Benny's Originals"));
            dictionary.Add(VehicleWheelType.BennysBespoke, new Tuple<string, string>("CMOD_WHE1_9", "Benny's Bespoke"));
            _wheelNames = new ReadOnlyDictionary<VehicleWheelType, Tuple<string, string>>(dictionary);
        }

        internal VehicleModCollection(Vehicle owner)
        {
            this._owner = owner;
        }

        public void ClearCustomPrimaryColor()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
            Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_PRIMARY_COLOUR, arguments);
        }

        public void ClearCustomSecondaryColor()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
            Function.Call(Hash.CLEAR_VEHICLE_CUSTOM_SECONDARY_COLOUR, arguments);
        }

        public VehicleMod[] GetAllMods() => 
            (from modType in Enum.GetValues(typeof(VehicleModType)).Cast<VehicleModType>().Where<VehicleModType>(new Func<VehicleModType, bool>(this.HasVehicleMod)) select this[modType]).ToArray<VehicleMod>();

        public string GetLocalizedLiveryName(int index)
        {
            if (this[VehicleModType.Livery].ModCount > 0)
            {
                return this[VehicleModType.Livery].GetLocalizedModName(index);
            }
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, index };
            return Game.GetGXTEntry(Function.Call<string>(Hash.GET_LIVERY_NAME, arguments));
        }

        public string GetLocalizedWheelTypeName(VehicleWheelType wheelType)
        {
            InputArgument[] arguments = new InputArgument[] { "mod_mnu", 10 };
            if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, arguments))
            {
                InputArgument[] argumentArray2 = new InputArgument[] { 10, true };
                Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, argumentArray2);
                InputArgument[] argumentArray3 = new InputArgument[] { "mod_mnu", 10 };
                Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, argumentArray3);
            }
            if (!_wheelNames.ContainsKey(wheelType))
            {
                throw new ArgumentException("Wheel Type is undefined", "wheelType");
            }
            return (!Game.DoesGXTEntryExist(_wheelNames[wheelType].Item1) ? _wheelNames[wheelType].Item2 : Game.GetGXTEntry(_wheelNames[wheelType].Item1));
        }

        public bool HasNeonLight(VehicleNeonLight neonLight)
        {
            switch (neonLight)
            {
                case VehicleNeonLight.Left:
                    return this._owner.Bones.HasBone("neon_l");

                case VehicleNeonLight.Right:
                    return this._owner.Bones.HasBone("neon_r");

                case VehicleNeonLight.Front:
                    return this._owner.Bones.HasBone("neon_f");

                case VehicleNeonLight.Back:
                    return this._owner.Bones.HasBone("neon_b");
            }
            return false;
        }

        public bool HasVehicleMod(VehicleModType type)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, type };
            return (Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, arguments) > 0);
        }

        public void InstallModKit()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, 0 };
            Function.Call(Hash.SET_VEHICLE_MOD_KIT, arguments);
        }

        public bool IsNeonLightsOn(VehicleNeonLight light)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, light };
            return Function.Call<bool>(Hash._IS_VEHICLE_NEON_LIGHT_ENABLED, arguments);
        }

        public bool RequestAdditionTextFile(int timeout = 0x3e8)
        {
            InputArgument[] arguments = new InputArgument[] { "mod_mnu", 10 };
            if (Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, arguments))
            {
                return true;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { 10, true };
            Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, argumentArray2);
            InputArgument[] argumentArray3 = new InputArgument[] { "mod_mnu", 10 };
            Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, argumentArray3);
            int num = Game.GameTime + timeout;
            while (Game.GameTime < num)
            {
                InputArgument[] argumentArray4 = new InputArgument[] { "mod_mnu", 10 };
                if (Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, argumentArray4))
                {
                    return true;
                }
                Script.Yield();
            }
            return false;
        }

        public void SetNeonLightsOn(VehicleNeonLight light, bool on)
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, light, on };
            Function.Call(Hash._SET_VEHICLE_NEON_LIGHT_ENABLED, arguments);
        }

        public VehicleMod this[VehicleModType modType]
        {
            get
            {
                VehicleMod mod = null;
                if (!this._vehicleMods.TryGetValue(modType, out mod))
                {
                    mod = new VehicleMod(this._owner, modType);
                    this._vehicleMods.Add(modType, mod);
                }
                return mod;
            }
        }

        public VehicleToggleMod this[VehicleToggleModType modType]
        {
            get
            {
                VehicleToggleMod mod = null;
                if (!this._vehicleToggleMods.TryGetValue(modType, out mod))
                {
                    mod = new VehicleToggleMod(this._owner, modType);
                    this._vehicleToggleMods.Add(modType, mod);
                }
                return mod;
            }
        }

        public VehicleWheelType WheelType
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<VehicleWheelType>(Hash.GET_VEHICLE_WHEEL_TYPE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(Hash.SET_VEHICLE_WHEEL_TYPE, arguments);
            }
        }

        public VehicleWheelType[] AllowedWheelTypes
        {
            get
            {
                if (this._owner.Model.IsBicycle || this._owner.Model.IsBike)
                {
                    return new VehicleWheelType[] { VehicleWheelType.BikeWheels };
                }
                if (!this._owner.Model.IsCar)
                {
                    return new VehicleWheelType[0];
                }
                List<VehicleWheelType> list1 = new List<VehicleWheelType>();
                list1.Add(VehicleWheelType.Sport);
                list1.Add(VehicleWheelType.Muscle);
                list1.Add(VehicleWheelType.Lowrider);
                list1.Add(VehicleWheelType.SUV);
                list1.Add(VehicleWheelType.Offroad);
                list1.Add(VehicleWheelType.Tuner);
                list1.Add(VehicleWheelType.HighEnd);
                List<VehicleWheelType> list = list1;
                VehicleHash model = (VehicleHash) this._owner.Model;
                if (model > ((VehicleHash) (-2039755226)))
                {
                    if (model > ((VehicleHash) (-1361687965)))
                    {
                        if (model > ((VehicleHash) (-1013450936)))
                        {
                            if (model != ((VehicleHash) (-899509638)))
                            {
                                if (model != ((VehicleHash) (-295689028)))
                                {
                                    goto TR_0000;
                                }
                                goto TR_0001;
                            }
                        }
                        else if ((model != ((VehicleHash) (-1126264336))) && (model != ((VehicleHash) (-1013450936))))
                        {
                            goto TR_0000;
                        }
                    }
                    else if ((model != ((VehicleHash) (-1797613329))) && ((model != ((VehicleHash) (-1790546981))) && (model != ((VehicleHash) (-1361687965)))))
                    {
                        goto TR_0000;
                    }
                }
                else if (model > VehicleHash.Banshee2)
                {
                    if (model > VehicleHash.Moonbeam2)
                    {
                        if ((model != ((VehicleHash) (-2040426790))) && (model != ((VehicleHash) (-2039755226))))
                        {
                            goto TR_0000;
                        }
                    }
                    else if ((model != VehicleHash.SlamVan3) && (model != VehicleHash.Moonbeam2))
                    {
                        goto TR_0000;
                    }
                }
                else if ((model != VehicleHash.SabreGT2) && (model != VehicleHash.Voodoo2))
                {
                    if (model != VehicleHash.Banshee2)
                    {
                        goto TR_0000;
                    }
                    goto TR_0001;
                }
                VehicleWheelType[] collection = new VehicleWheelType[] { VehicleWheelType.BennysOriginals, VehicleWheelType.BennysBespoke };
                list.AddRange(collection);
            TR_0000:
                return list.ToArray();
            TR_0001:
                list.Add(VehicleWheelType.BennysOriginals);
                goto TR_0000;
            }
        }

        public string LocalizedWheelTypeName =>
            this.GetLocalizedWheelTypeName(this.WheelType);

        public int Livery
        {
            get
            {
                int modCount = this[VehicleModType.Livery].ModCount;
                if (modCount > 0)
                {
                    return modCount;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<int>(Hash.GET_VEHICLE_LIVERY, arguments);
            }
            set
            {
                if (this[VehicleModType.Livery].ModCount > 0)
                {
                    this[VehicleModType.Livery].Index = value;
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                    Function.Call(Hash.SET_VEHICLE_LIVERY, arguments);
                }
            }
        }

        public int LiveryCount
        {
            get
            {
                int modCount = this[VehicleModType.Livery].ModCount;
                if (modCount > 0)
                {
                    return modCount;
                }
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<int>(Hash.GET_VEHICLE_LIVERY_COUNT, arguments);
            }
        }

        public string LocalizedLiveryName =>
            this.GetLocalizedLiveryName(this.Livery);

        public VehicleWindowTint WindowTint
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<VehicleWindowTint>(Hash.GET_VEHICLE_WINDOW_TINT, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(Hash.SET_VEHICLE_WINDOW_TINT, arguments);
            }
        }

        public VehicleColor PrimaryColor
        {
            get
            {
                int num;
                int num2;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num, (IntPtr) &num2 };
                Function.Call(Hash.GET_VEHICLE_COLOURS, arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value, this.SecondaryColor };
                Function.Call(Hash.SET_VEHICLE_COLOURS, arguments);
            }
        }

        public VehicleColor SecondaryColor
        {
            get
            {
                int num;
                int num2;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_VEHICLE_COLOURS, arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.PrimaryColor, value };
                Function.Call(Hash.SET_VEHICLE_COLOURS, arguments);
            }
        }

        public VehicleColor RimColor
        {
            get
            {
                int num;
                int num2;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.PearlescentColor, value };
                Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, arguments);
            }
        }

        public VehicleColor PearlescentColor
        {
            get
            {
                int num;
                int num2;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num, (IntPtr) &num2 };
                Function.Call(Hash.GET_VEHICLE_EXTRA_COLOURS, arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value, this.RimColor };
                Function.Call(Hash.SET_VEHICLE_EXTRA_COLOURS, arguments);
            }
        }

        public VehicleColor TrimColor
        {
            get
            {
                int num;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num };
                Function.Call((Hash) 0x7d1464d472d32136L, arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call((Hash) (-860796651183309031L), arguments);
            }
        }

        public VehicleColor DashboardColor
        {
            get
            {
                int num;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num };
                Function.Call((Hash) (-5232234435444532225L), arguments);
                return (VehicleColor) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call((Hash) 0x6089cdf6a57f326cL, arguments);
            }
        }

        public int ColorCombination
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<int>(Hash.GET_VEHICLE_COLOUR_COMBINATION, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(Hash.SET_VEHICLE_COLOUR_COMBINATION, arguments);
            }
        }

        public int ColorCombinationCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<int>(Hash.GET_NUMBER_OF_VEHICLE_COLOURS, arguments);
            }
        }

        public Color TireSmokeColor
        {
            get
            {
                int num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_VEHICLE_TYRE_SMOKE_COLOR, arguments);
                return Color.FromArgb(num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value.R, value.G, value.B };
                Function.Call(Hash.SET_VEHICLE_TYRE_SMOKE_COLOR, arguments);
            }
        }

        public Color NeonLightsColor
        {
            get
            {
                int num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash._GET_VEHICLE_NEON_LIGHTS_COLOUR, arguments);
                return Color.FromArgb(num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value.R, value.G, value.B };
                Function.Call(Hash._SET_VEHICLE_NEON_LIGHTS_COLOUR, arguments);
            }
        }

        public bool HasNeonLights =>
            Enum.GetValues(typeof(VehicleNeonLight)).Cast<VehicleNeonLight>().Any<VehicleNeonLight>(new Func<VehicleNeonLight, bool>(this.HasNeonLight));

        public Color CustomPrimaryColor
        {
            get
            {
                int num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_VEHICLE_CUSTOM_PRIMARY_COLOUR, arguments);
                return Color.FromArgb(num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value.R, value.G, value.B };
                Function.Call(Hash.SET_VEHICLE_CUSTOM_PRIMARY_COLOUR, arguments);
            }
        }

        public Color CustomSecondaryColor
        {
            get
            {
                int num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_VEHICLE_CUSTOM_SECONDARY_COLOUR, arguments);
                return Color.FromArgb(num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value.R, value.G, value.B };
                Function.Call(Hash.SET_VEHICLE_CUSTOM_SECONDARY_COLOUR, arguments);
            }
        }

        public bool IsPrimaryColorCustom
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<bool>(Hash.GET_IS_VEHICLE_PRIMARY_COLOUR_CUSTOM, arguments);
            }
        }

        public bool IsSecondaryColorCustom
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<bool>(Hash.GET_IS_VEHICLE_SECONDARY_COLOUR_CUSTOM, arguments);
            }
        }

        public GTA.LicensePlateStyle LicensePlateStyle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<GTA.LicensePlateStyle>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT_INDEX, arguments);
            }
        }

        public GTA.LicensePlateType LicensePlateType
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<GTA.LicensePlateType>(Hash.GET_VEHICLE_PLATE_TYPE, arguments);
            }
        }

        public string LicensePlate
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle };
                return Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, value };
                Function.Call(Hash.SET_VEHICLE_NUMBER_PLATE_TEXT, arguments);
            }
        }
    }
}

