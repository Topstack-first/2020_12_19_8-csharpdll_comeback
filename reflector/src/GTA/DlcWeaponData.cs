namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Size=0x138)]
    public struct DlcWeaponData
    {
        [FieldOffset(0)]
        private int validCheck;
        [FieldOffset(8)]
        private int weaponHash;
        [FieldOffset(0x18)]
        private int weaponCost;
        [FieldOffset(0x20)]
        private int ammoCost;
        [FieldOffset(40)]
        private int ammoType;
        [FieldOffset(0x30)]
        private int defaultClipSize;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(0x38)]
        private <name>e__FixedBuffer name;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(120)]
        private <desc>e__FixedBuffer desc;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(0xb8)]
        private <simpleDesc>e__FixedBuffer simpleDesc;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(0xf8)]
        private <upperCaseName>e__FixedBuffer upperCaseName;

        public bool IsValid
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.validCheck };
                return !Function.Call<bool>(GTA.Native.Hash._IS_DLC_DATA_EMPTY, arguments);
            }
        }

        public WeaponHash Hash =>
            (WeaponHash) this.weaponHash;

        public string DisplaySimpleDescription =>
            new string((char*) this.simpleDesc.FixedElementField);

        public string LocalizedSimpleDescription =>
            Game.GetGXTEntry(this.DisplaySimpleDescription);

        public string DisplayDescription =>
            new string((char*) this.desc.FixedElementField);

        public string LocalizedDescription =>
            Game.GetGXTEntry(this.DisplayDescription);

        public string DisplayName =>
            new string((char*) this.name.FixedElementField);

        public string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        public string DisplayUpperName =>
            new string((char*) this.upperCaseName.FixedElementField);

        public string LocalizedUpperName =>
            Game.GetGXTEntry(this.DisplayUpperName);

        [StructLayout(LayoutKind.Sequential, Size=0x80), CompilerGenerated, UnsafeValueType]
        public struct <desc>e__FixedBuffer
        {
            public char FixedElementField;
        }

        [StructLayout(LayoutKind.Sequential, Size=0x80), UnsafeValueType, CompilerGenerated]
        public struct <name>e__FixedBuffer
        {
            public char FixedElementField;
        }

        [StructLayout(LayoutKind.Sequential, Size=0x80), UnsafeValueType, CompilerGenerated]
        public struct <simpleDesc>e__FixedBuffer
        {
            public char FixedElementField;
        }

        [StructLayout(LayoutKind.Sequential, Size=0x80), CompilerGenerated, UnsafeValueType]
        public struct <upperCaseName>e__FixedBuffer
        {
            public char FixedElementField;
        }
    }
}

