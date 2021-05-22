namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    public sealed class VehicleMod
    {
        private GTA.Vehicle _owner;
        private static readonly ReadOnlyDictionary<int, Tuple<string, string>> _hornNames;

        static VehicleMod()
        {
            Dictionary<int, Tuple<string, string>> dictionary = new Dictionary<int, Tuple<string, string>>();
            dictionary.Add(-1, new Tuple<string, string>("CMOD_HRN_0", "Stock Horn"));
            dictionary.Add(0, new Tuple<string, string>("CMOD_HRN_TRK", "Truck Horn"));
            dictionary.Add(1, new Tuple<string, string>("CMOD_HRN_COP", "Cop Horn"));
            dictionary.Add(2, new Tuple<string, string>("CMOD_HRN_CLO", "Clown Horn"));
            dictionary.Add(3, new Tuple<string, string>("CMOD_HRN_MUS1", "Musical Horn 1"));
            dictionary.Add(4, new Tuple<string, string>("CMOD_HRN_MUS2", "Musical Horn 2"));
            dictionary.Add(5, new Tuple<string, string>("CMOD_HRN_MUS3", "Musical Horn 3"));
            dictionary.Add(6, new Tuple<string, string>("CMOD_HRN_MUS4", "Musical Horn 4"));
            dictionary.Add(7, new Tuple<string, string>("CMOD_HRN_MUS5", "Musical Horn 5"));
            dictionary.Add(8, new Tuple<string, string>("CMOD_HRN_SAD", "Sad Trombone"));
            dictionary.Add(9, new Tuple<string, string>("HORN_CLAS1", "Classical Horn 1"));
            dictionary.Add(10, new Tuple<string, string>("HORN_CLAS2", "Classical Horn 2"));
            dictionary.Add(11, new Tuple<string, string>("HORN_CLAS3", "Classical Horn 3"));
            dictionary.Add(12, new Tuple<string, string>("HORN_CLAS4", "Classical Horn 4"));
            dictionary.Add(13, new Tuple<string, string>("HORN_CLAS5", "Classical Horn 5"));
            dictionary.Add(14, new Tuple<string, string>("HORN_CLAS6", "Classical Horn 6"));
            dictionary.Add(15, new Tuple<string, string>("HORN_CLAS7", "Classical Horn 7"));
            dictionary.Add(0x10, new Tuple<string, string>("HORN_CNOTE_C0", "Scale Do"));
            dictionary.Add(0x11, new Tuple<string, string>("HORN_CNOTE_D0", "Scale Re"));
            dictionary.Add(0x12, new Tuple<string, string>("HORN_CNOTE_E0", "Scale Mi"));
            dictionary.Add(0x13, new Tuple<string, string>("HORN_CNOTE_F0", "Scale Fa"));
            dictionary.Add(20, new Tuple<string, string>("HORN_CNOTE_G0", "Scale Sol"));
            dictionary.Add(0x15, new Tuple<string, string>("HORN_CNOTE_A0", "Scale La"));
            dictionary.Add(0x16, new Tuple<string, string>("HORN_CNOTE_B0", "Scale Ti"));
            dictionary.Add(0x17, new Tuple<string, string>("HORN_CNOTE_C1", "Scale Do (High)"));
            dictionary.Add(0x18, new Tuple<string, string>("HORN_HIPS1", "Jazz Horn 1"));
            dictionary.Add(0x19, new Tuple<string, string>("HORN_HIPS2", "Jazz Horn 2"));
            dictionary.Add(0x1a, new Tuple<string, string>("HORN_HIPS3", "Jazz Horn 3"));
            dictionary.Add(0x1b, new Tuple<string, string>("HORN_HIPS4", "Jazz Horn Loop"));
            dictionary.Add(0x1c, new Tuple<string, string>("HORN_INDI_1", "Star Spangled Banner 1"));
            dictionary.Add(0x1d, new Tuple<string, string>("HORN_INDI_2", "Star Spangled Banner 2"));
            dictionary.Add(30, new Tuple<string, string>("HORN_INDI_3", "Star Spangled Banner 3"));
            dictionary.Add(0x1f, new Tuple<string, string>("HORN_INDI_4", "Star Spangled Banner 4"));
            dictionary.Add(0x20, new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1"));
            dictionary.Add(0x21, new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8"));
            dictionary.Add(0x22, new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2"));
            dictionary.Add(0x23, new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1"));
            dictionary.Add(0x24, new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8"));
            dictionary.Add(0x25, new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2"));
            dictionary.Add(0x26, new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1"));
            dictionary.Add(0x27, new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1"));
            dictionary.Add(40, new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2"));
            dictionary.Add(0x29, new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2"));
            dictionary.Add(0x2a, new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop"));
            dictionary.Add(0x2b, new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop"));
            dictionary.Add(0x2c, new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop"));
            dictionary.Add(0x2d, new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop"));
            dictionary.Add(0x2e, new Tuple<string, string>("HORN_XM15_1", "Festive Loop 1"));
            dictionary.Add(0x2f, new Tuple<string, string>("HORN_XM15_2", "Festive Loop 2"));
            dictionary.Add(0x30, new Tuple<string, string>("HORN_XM15_3", "Festive Loop 3"));
            _hornNames = new ReadOnlyDictionary<int, Tuple<string, string>>(dictionary);
        }

        internal VehicleMod(GTA.Vehicle owner, VehicleModType modType)
        {
            this._owner = owner;
            this.ModType = modType;
        }

        public string GetLocalizedModName(int index)
        {
            if (this.ModCount == 0)
            {
                return "";
            }
            if ((index < -1) || (index >= this.ModCount))
            {
                return "";
            }
            InputArgument[] arguments = new InputArgument[] { "mod_mnu", 10 };
            if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, arguments))
            {
                InputArgument[] argumentArray2 = new InputArgument[] { 10, true };
                Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, argumentArray2);
                InputArgument[] argumentArray3 = new InputArgument[] { "mod_mnu", 10 };
                Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, argumentArray3);
            }
            if (this.ModType == VehicleModType.Horns)
            {
                return (!_hornNames.ContainsKey(index) ? "" : (!Game.DoesGXTEntryExist(_hornNames[index].Item1) ? _hornNames[index].Item2 : Game.GetGXTEntry(_hornNames[index].Item1)));
            }
            if ((this.ModType == VehicleModType.FrontWheel) || (this.ModType == VehicleModType.RearWheel))
            {
                if (index == -1)
                {
                    return ((this._owner.Model.IsBike || !this._owner.Model.IsBicycle) ? Game.GetGXTEntry("CMOD_WHE_B_0") : Game.GetGXTEntry("CMOD_WHE_0"));
                }
                if (index >= (this.ModCount / 2))
                {
                    InputArgument[] argumentArray4 = new InputArgument[] { this._owner.Handle, this.ModType, index };
                    return (Game.GetGXTEntry("CHROME") + " " + Game.GetGXTEntry(Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, argumentArray4)));
                }
                InputArgument[] argumentArray5 = new InputArgument[] { this._owner.Handle, this.ModType, index };
                return Game.GetGXTEntry(Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, argumentArray5));
            }
            switch (this.ModType)
            {
                case VehicleModType.Engine:
                    return ((index != -1) ? Game.GetGXTEntry("CMOD_ENG_" + (index + 2).ToString()) : Game.GetGXTEntry("CMOD_ARM_0"));

                case VehicleModType.Brakes:
                    return Game.GetGXTEntry("CMOD_BRA_" + (index + 1).ToString());

                case VehicleModType.Transmission:
                    return Game.GetGXTEntry("CMOD_GBX_" + (index + 1).ToString());

                case VehicleModType.Suspension:
                    return Game.GetGXTEntry("CMOD_SUS_" + (index + 1).ToString());

                case VehicleModType.Armor:
                    return Game.GetGXTEntry("CMOD_ARM_" + (index + 1).ToString());
            }
            if (index > -1)
            {
                InputArgument[] argumentArray6 = new InputArgument[] { this._owner.Handle, this.ModType, index };
                string entry = Function.Call<string>(Hash.GET_MOD_TEXT_LABEL, argumentArray6);
                if (!Game.DoesGXTEntryExist(entry))
                {
                    return (this.LocalizedModTypeName + " " + (index + 1).ToString());
                }
                entry = Game.GetGXTEntry(entry);
                return (((entry == "") || (entry == "NULL")) ? (this.LocalizedModTypeName + " " + (index + 1).ToString()) : entry);
            }
            VehicleModType modType = this.ModType;
            if (modType == VehicleModType.AirFilter)
            {
                if (this._owner.Model == 0x1bb290bc)
                {
                }
            }
            else if (modType == VehicleModType.Struts)
            {
                VehicleHash model = (VehicleHash) this._owner.Model;
                if ((model == VehicleHash.Banshee2) || ((model == ((VehicleHash) (-1041692462))) || (model == ((VehicleHash) (-295689028)))))
                {
                    return Game.GetGXTEntry("CMOD_COL5_41");
                }
            }
            return Game.GetGXTEntry("CMOD_DEF_0");
        }

        public void Remove()
        {
            InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
            Function.Call(Hash.REMOVE_VEHICLE_MOD, arguments);
        }

        public VehicleModType ModType { get; private set; }

        public int Index
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
                return Function.Call<int>(Hash.GET_VEHICLE_MOD, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType, value, this.Variation };
                Function.Call(Hash.SET_VEHICLE_MOD, arguments);
            }
        }

        public bool Variation
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
                return Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType, this.Index, value };
                Function.Call(Hash.SET_VEHICLE_MOD, arguments);
            }
        }

        public string LocalizedModTypeName
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { "mod_mnu", 10 };
                if (!Function.Call<bool>(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, arguments))
                {
                    InputArgument[] argumentArray2 = new InputArgument[] { 10, true };
                    Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, argumentArray2);
                    InputArgument[] argumentArray3 = new InputArgument[] { "mod_mnu", 10 };
                    Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, argumentArray3);
                }
                string entry = "";
                switch (this.ModType)
                {
                    case VehicleModType.Engine:
                        entry = Game.GetGXTEntry("CMOD_MOD_ENG");
                        break;

                    case VehicleModType.Brakes:
                        entry = Game.GetGXTEntry("CMOD_MOD_BRA");
                        break;

                    case VehicleModType.Transmission:
                        entry = Game.GetGXTEntry("CMOD_MOD_TRN");
                        break;

                    case VehicleModType.Horns:
                        entry = Game.GetGXTEntry("CMOD_MOD_HRN");
                        break;

                    case VehicleModType.Suspension:
                        entry = Game.GetGXTEntry("CMOD_MOD_SUS");
                        break;

                    case VehicleModType.Armor:
                        entry = Game.GetGXTEntry("CMOD_MOD_ARM");
                        break;

                    case VehicleModType.FrontWheel:
                        if (this._owner.Model.IsBike || !this._owner.Model.IsBicycle)
                        {
                            entry = Game.GetGXTEntry("CMOD_WHE0_0");
                        }
                        else
                        {
                            entry = Game.GetGXTEntry("CMOD_MOD_WHEM");
                            if (entry == "")
                            {
                                return "Wheels";
                            }
                        }
                        break;

                    case VehicleModType.RearWheel:
                        entry = Game.GetGXTEntry("CMOD_WHE0_1");
                        break;

                    case VehicleModType.PlateHolder:
                        entry = Game.GetGXTEntry("CMM_MOD_S0");
                        break;

                    case VehicleModType.VanityPlates:
                        entry = Game.GetGXTEntry("CMM_MOD_S1");
                        break;

                    case VehicleModType.TrimDesign:
                        entry = (this._owner.Model != -295689028) ? Game.GetGXTEntry("CMM_MOD_S2") : Game.GetGXTEntry("CMM_MOD_S2b");
                        break;

                    case VehicleModType.Ornaments:
                        entry = Game.GetGXTEntry("CMM_MOD_S3");
                        break;

                    case VehicleModType.Dashboard:
                        entry = Game.GetGXTEntry("CMM_MOD_S4");
                        break;

                    case VehicleModType.DialDesign:
                        entry = Game.GetGXTEntry("CMM_MOD_S5");
                        break;

                    case VehicleModType.DoorSpeakers:
                        entry = Game.GetGXTEntry("CMM_MOD_S6");
                        break;

                    case VehicleModType.Seats:
                        entry = Game.GetGXTEntry("CMM_MOD_S7");
                        break;

                    case VehicleModType.SteeringWheels:
                        entry = Game.GetGXTEntry("CMM_MOD_S8");
                        break;

                    case VehicleModType.ColumnShifterLevers:
                        entry = Game.GetGXTEntry("CMM_MOD_S9");
                        break;

                    case VehicleModType.Plaques:
                        entry = Game.GetGXTEntry("CMM_MOD_S10");
                        break;

                    case VehicleModType.Speakers:
                        entry = Game.GetGXTEntry("CMM_MOD_S11");
                        break;

                    case VehicleModType.Trunk:
                        entry = Game.GetGXTEntry("CMM_MOD_S12");
                        break;

                    case VehicleModType.Hydraulics:
                        entry = Game.GetGXTEntry("CMM_MOD_S13");
                        break;

                    case VehicleModType.EngineBlock:
                        entry = Game.GetGXTEntry("CMM_MOD_S14");
                        break;

                    case VehicleModType.AirFilter:
                        entry = (this._owner.Model != -295689028) ? Game.GetGXTEntry("CMM_MOD_S15") : Game.GetGXTEntry("CMM_MOD_S15b");
                        break;

                    case VehicleModType.Struts:
                        entry = ((this._owner.Model == -295689028) || (this._owner.Model == 0x25c5af13)) ? Game.GetGXTEntry("CMM_MOD_S16b") : Game.GetGXTEntry("CMM_MOD_S16");
                        break;

                    case VehicleModType.ArchCover:
                        entry = (this._owner.Model != -295689028) ? Game.GetGXTEntry("CMM_MOD_S17") : Game.GetGXTEntry("CMM_MOD_S17b");
                        break;

                    case VehicleModType.Aerials:
                        entry = (this._owner.Model != -295689028) ? ((this._owner.Model != -602287871) ? Game.GetGXTEntry("CMM_MOD_S18") : Game.GetGXTEntry("CMM_MOD_S18c")) : Game.GetGXTEntry("CMM_MOD_S18b");
                        break;

                    case VehicleModType.Trim:
                        entry = (this._owner.Model != -295689028) ? ((this._owner.Model != -602287871) ? ((this._owner.Model != -899509638) ? Game.GetGXTEntry("CMM_MOD_S19") : Game.GetGXTEntry("CMM_MOD_S19d")) : Game.GetGXTEntry("CMM_MOD_S19c")) : Game.GetGXTEntry("CMM_MOD_S19b");
                        break;

                    case VehicleModType.Tank:
                        entry = (this._owner.Model != 0x42bc5e19) ? Game.GetGXTEntry("CMM_MOD_S20") : Game.GetGXTEntry("CMM_MOD_S27");
                        break;

                    case VehicleModType.Windows:
                        entry = (this._owner.Model != -602287871) ? Game.GetGXTEntry("CMM_MOD_S21") : Game.GetGXTEntry("CMM_MOD_S21b");
                        break;

                    case (VehicleModType.Windows | VehicleModType.FrontBumper):
                        entry = (this._owner.Model != 0x42bc5e19) ? Game.GetGXTEntry("CMM_MOD_S22") : Game.GetGXTEntry("SLVAN3_RDOOR");
                        break;

                    case VehicleModType.Livery:
                        entry = Game.GetGXTEntry("CMM_MOD_S23");
                        break;

                    default:
                    {
                        InputArgument[] argumentArray4 = new InputArgument[] { this._owner.Handle, this.ModType };
                        entry = Function.Call<string>(Hash.GET_MOD_SLOT_NAME, argumentArray4);
                        if (Game.DoesGXTEntryExist(entry))
                        {
                            entry = Game.GetGXTEntry(entry);
                        }
                        break;
                    }
                }
                if (entry == "")
                {
                    entry = this.ModType.ToString();
                }
                return entry;
            }
        }

        public string LocalizedModName =>
            this.GetLocalizedModName(this.Index);

        public int ModCount
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this.ModType };
                return Function.Call<int>(Hash.GET_NUM_VEHICLE_MODS, arguments);
            }
        }

        public GTA.Vehicle Vehicle =>
            this._owner;
    }
}

