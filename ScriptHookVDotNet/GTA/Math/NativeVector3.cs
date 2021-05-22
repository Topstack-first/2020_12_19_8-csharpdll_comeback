// Decompiled with JetBrains decompiler
// Type: GTA.Math.NativeVector3
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Runtime.InteropServices;

namespace GTA.Math
{
  [StructLayout(LayoutKind.Explicit, Size = 24, Pack = 16)]
  internal struct NativeVector3
  {
    [FieldOffset(0)]
    public float X;
    [FieldOffset(8)]
    public float Y;
    [FieldOffset(16)]
    public float Z;

    public NativeVector3(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }

    public static implicit operator Vector3(NativeVector3 value) => new Vector3(value.X, value.Y, value.Z);

    public static implicit operator NativeVector3(Vector3 value)
    {
      float z = value.Z;
      float y = value.Y;
      float x = value.X;
      NativeVector3 nativeVector3;
      nativeVector3.X = x;
      nativeVector3.Y = y;
      nativeVector3.Z = z;
      return nativeVector3;
    }
  }
}
