// Decompiled with JetBrains decompiler
// Type: GTA.Native.InputArgument
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Runtime.InteropServices;

namespace GTA.Native
{
  public class InputArgument
  {
    internal ulong _data;

    public InputArgument(object value)
    {
      this._data = _Module_.GTA__2ENative__2EObjectToNative(value);
      // ISSUE: explicit constructor call
      base.__2Ector();
    }

    public override string ToString() => this._data.ToString();

    public static unsafe implicit operator InputArgument(void* value) => new InputArgument((object) new IntPtr(value));

    public static implicit operator InputArgument(IntPtr value) => new InputArgument((object) value);

    public static unsafe implicit operator InputArgument(sbyte* value) => new InputArgument((object) new string(value));

    public static implicit operator InputArgument(string value) => new InputArgument((object) value);

    public static implicit operator InputArgument(INativeValue value) => new InputArgument((object) value);

    public static implicit operator InputArgument(Enum value) => new InputArgument((object) value);

    public static implicit operator InputArgument(double value) => new InputArgument((object) (float) value);

    public static implicit operator InputArgument(float value) => new InputArgument((object) value);

    public static implicit operator InputArgument(ulong value) => new InputArgument((object) value);

    public static implicit operator InputArgument(long value) => new InputArgument((object) value);

    public static implicit operator InputArgument(uint value) => new InputArgument((object) value);

    public static implicit operator InputArgument(int value) => new InputArgument((object) value);

    public static implicit operator InputArgument(ushort value) => new InputArgument((object) (int) value);

    public static implicit operator InputArgument(short value) => new InputArgument((object) (int) value);

    public static implicit operator InputArgument(byte value) => new InputArgument((object) (int) value);

    public static implicit operator InputArgument(sbyte value) => new InputArgument((object) (int) value);

    public static implicit operator InputArgument([MarshalAs(UnmanagedType.U1)] bool value) => new InputArgument((object) value);
  }
}
