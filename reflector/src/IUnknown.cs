﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size=8), NativeCppClass]
internal static class IUnknown : ValueType
{
    private long _alignment_member_;
}

