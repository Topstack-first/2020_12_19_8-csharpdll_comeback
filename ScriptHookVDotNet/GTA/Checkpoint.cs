// Decompiled with JetBrains decompiler
// Type: GTA.Checkpoint
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA
{
  public sealed class Checkpoint : PoolObject, IEquatable<Checkpoint>
  {
    public Checkpoint(int handle)
      : base(handle)
    {
    }

    public IntPtr MemoryAddress => MemoryAccess.GetCheckpointAddress(this.Handle);

    public Vector3 Position
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? Vector3.Zero : MemoryAccess.ReadVector3(memoryAddress);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteVector3(memoryAddress, value);
      }
    }

    public Vector3 TargetPosition
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? Vector3.Zero : MemoryAccess.ReadVector3(memoryAddress + 16);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteVector3(memoryAddress + 16, value);
      }
    }

    public CheckpointIcon Icon
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? CheckpointIcon.CylinderSingleArrow : (CheckpointIcon) MemoryAccess.ReadInt(memoryAddress + 56);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteInt(memoryAddress + 56, (int) value);
      }
    }

    public CheckpointCustomIcon CustomIcon
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? (CheckpointCustomIcon) (byte) 0 : (CheckpointCustomIcon) MemoryAccess.ReadByte(memoryAddress + 52);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteByte(memoryAddress + 52, (byte) value);
        MemoryAccess.WriteInt(memoryAddress + 56, 42);
      }
    }

    public float Radius
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(memoryAddress + 60);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(memoryAddress + 60, value);
      }
    }

    public Color Color
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? Color.Transparent : Color.FromArgb(MemoryAccess.ReadInt(memoryAddress + 80));
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteInt(memoryAddress + 80, this.Color.ToArgb());
      }
    }

    public Color IconColor
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? Color.Transparent : Color.FromArgb(MemoryAccess.ReadInt(memoryAddress + 84));
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteInt(memoryAddress + 84, this.Color.ToArgb());
      }
    }

    public float CylinderNearHeight
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(memoryAddress + 68);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(memoryAddress + 68, value);
      }
    }

    public float CylinderFarHeight
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(memoryAddress + 72);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(memoryAddress + 72, value);
      }
    }

    public float CylinderRadius
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(memoryAddress + 76);
      }
      set
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(memoryAddress + 76, value);
      }
    }

    public override void Delete() => Function.Call(Hash.DELETE_CHECKPOINT, (InputArgument) this.Handle);

    public override bool Exists() => this.Handle != 0 && this.MemoryAddress != IntPtr.Zero;

    public static bool Exists(Checkpoint checkpoint) => (object) checkpoint != null && checkpoint.Exists();

    public bool Equals(Checkpoint checkpoint) => (object) checkpoint != null && this.Handle == checkpoint.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Checkpoint) obj);

    public override sealed int GetHashCode() => this.Handle.GetHashCode();

    public static bool operator ==(Checkpoint left, Checkpoint right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Checkpoint left, Checkpoint right) => !(left == right);
  }
}
