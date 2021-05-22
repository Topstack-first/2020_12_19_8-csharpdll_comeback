namespace GTA.Native
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=0x20), NativeCppClass, UnsafeValueType]
    internal struct checkpoint
    {
        private long _alignment_member_;
    }
}

