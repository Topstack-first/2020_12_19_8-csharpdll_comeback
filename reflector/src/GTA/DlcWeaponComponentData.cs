namespace GTA
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Size=0x110)]
    public struct DlcWeaponComponentData
    {
        [FieldOffset(0)]
        private int attachBone;
        [FieldOffset(8)]
        private int bActiveByDefault;
        [FieldOffset(0x18)]
        private int componentHash;
        [FieldOffset(40)]
        private int componentCost;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(0x30)]
        private <name>e__FixedBuffer name;
        [FixedBuffer(typeof(char), 0x40), FieldOffset(0x70)]
        private <desc>e__FixedBuffer desc;

        public WeaponComponentHash Hash =>
            (WeaponComponentHash) this.componentHash;

        public ComponentAttachmentPoint AttachPoint =>
            (ComponentAttachmentPoint) this.attachBone;

        public bool ActiveByDefault =>
            this.bActiveByDefault != 0;

        public string DisplayDescription =>
            new string((char*) this.desc.FixedElementField);

        public string LocalizedDescription =>
            Game.GetGXTEntry(this.DisplayDescription);

        public string DisplayName =>
            new string((char*) this.name.FixedElementField);

        public string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        [StructLayout(LayoutKind.Sequential, Size=0x80), CompilerGenerated, UnsafeValueType]
        public struct <desc>e__FixedBuffer
        {
            public char FixedElementField;
        }

        [StructLayout(LayoutKind.Sequential, Size=0x80), CompilerGenerated, UnsafeValueType]
        public struct <name>e__FixedBuffer
        {
            public char FixedElementField;
        }
    }
}

