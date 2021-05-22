namespace GTA.Native._A0x50a72c60
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Pack=0x10)]
    internal struct EntityPool
    {
        [FieldOffset(0x10)]
        public uint num1;
        [FieldOffset(0x20)]
        public uint num2;

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Full() => 
            ((this.num1 - (this.num2 & 0x3fffffff)) <= 0x100) ? ((bool) ((byte) 1)) : ((bool) ((byte) 0));
    }
}

