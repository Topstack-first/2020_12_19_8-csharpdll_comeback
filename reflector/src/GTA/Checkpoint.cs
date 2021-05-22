namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;

    public sealed class Checkpoint : PoolObject, IEquatable<Checkpoint>
    {
        public Checkpoint(int handle) : base(handle)
        {
        }

        public override void Delete()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.DELETE_CHECKPOINT, arguments);
        }

        public bool Equals(Checkpoint checkpoint) => 
            (checkpoint != null) && (base.Handle == checkpoint.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Checkpoint) obj));

        public override bool Exists() => 
            (base.Handle != 0) && (this.MemoryAddress != IntPtr.Zero);

        public static bool Exists(Checkpoint checkpoint) => 
            (checkpoint != null) && checkpoint.Exists();

        public sealed override int GetHashCode() => 
            base.Handle.GetHashCode();

        public static bool operator ==(Checkpoint left, Checkpoint right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Checkpoint left, Checkpoint right) => 
            !(left == right);

        public IntPtr MemoryAddress =>
            MemoryAccess.GetCheckpointAddress(base.Handle);

        public Vector3 Position
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(memoryAddress) : Vector3.Zero);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteVector3(memoryAddress, value);
                }
            }
        }

        public Vector3 TargetPosition
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(memoryAddress + 0x10) : Vector3.Zero);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteVector3(memoryAddress + 0x10, value);
                }
            }
        }

        public CheckpointIcon Icon
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? ((CheckpointIcon) MemoryAccess.ReadInt(memoryAddress + 0x38)) : CheckpointIcon.CylinderSingleArrow);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteInt(memoryAddress + 0x38, (int) value);
                }
            }
        }

        public CheckpointCustomIcon CustomIcon
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadByte(memoryAddress + 0x34) : 0);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteByte(memoryAddress + 0x34, (byte) value);
                    MemoryAccess.WriteInt(memoryAddress + 0x38, 0x2a);
                }
            }
        }

        public float Radius
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(memoryAddress + 60) : 0f);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(memoryAddress + 60, value);
                }
            }
        }

        public System.Drawing.Color Color
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? System.Drawing.Color.FromArgb(MemoryAccess.ReadInt(memoryAddress + 80)) : System.Drawing.Color.Transparent);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteInt(memoryAddress + 80, this.Color.ToArgb());
                }
            }
        }

        public System.Drawing.Color IconColor
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? System.Drawing.Color.FromArgb(MemoryAccess.ReadInt(memoryAddress + 0x54)) : System.Drawing.Color.Transparent);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteInt(memoryAddress + 0x54, this.Color.ToArgb());
                }
            }
        }

        public float CylinderNearHeight
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(memoryAddress + 0x44) : 0f);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(memoryAddress + 0x44, value);
                }
            }
        }

        public float CylinderFarHeight
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(memoryAddress + 0x48) : 0f);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(memoryAddress + 0x48, value);
                }
            }
        }

        public float CylinderRadius
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(memoryAddress + 0x4c) : 0f);
            }
            set
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(memoryAddress + 0x4c, value);
                }
            }
        }
    }
}

