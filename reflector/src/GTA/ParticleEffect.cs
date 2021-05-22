namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public abstract class ParticleEffect
    {
        protected readonly ParticleEffectsAsset _asset;
        protected readonly string _effectName;
        protected Vector3 _offset;
        protected Vector3 _rotation;
        protected System.Drawing.Color _color;
        protected float _scale;
        protected float _range;
        protected GTA.InvertAxis _InvertAxis;

        internal ParticleEffect(ParticleEffectsAsset asset, string effectName)
        {
            this.Handle = -1;
            this._asset = asset;
            this._effectName = effectName;
        }

        public static implicit operator InputArgument(ParticleEffect effect) => 
            new InputArgument(effect.Handle);

        public void SetParameter(string parameterName, float value)
        {
            if (this.IsActive)
            {
                InputArgument[] arguments = new InputArgument[] { parameterName, value, 0 };
                Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, arguments);
            }
        }

        public abstract bool Start();
        public void Stop()
        {
            if (this.IsActive)
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, false };
                Function.Call(Hash.REMOVE_PARTICLE_FX, arguments);
            }
            this.Handle = -1;
        }

        public override string ToString() => 
            $"{this.AssetName}\{this.EffectName}";

        public int Handle { get; protected set; }

        public bool IsActive
        {
            get
            {
                if (this.Handle == -1)
                {
                    return false;
                }
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, arguments);
            }
        }

        public IntPtr MemoryAddress =>
            this.IsActive ? MemoryAccess.GetPtfxAddress(this.Handle) : IntPtr.Zero;

        public Vector3 Offset
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    memoryAddress = MemoryAccess.ReadPtr(memoryAddress + 0x20);
                    if (memoryAddress != IntPtr.Zero)
                    {
                        Vector3 vector;
                        this._offset = vector = MemoryAccess.ReadVector3(memoryAddress + 0x90);
                        return vector;
                    }
                }
                return this._offset;
            }
            set
            {
                this._offset = value;
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    memoryAddress = MemoryAccess.ReadPtr(memoryAddress + 0x20);
                    if (memoryAddress != IntPtr.Zero)
                    {
                        MemoryAccess.WriteVector3(memoryAddress + 0x90, value);
                    }
                }
            }
        }

        public Vector3 Rotation
        {
            get => 
                this._rotation;
            set
            {
                this._rotation = value;
                if (this.IsActive)
                {
                    Vector3 offset = this.Offset;
                    InputArgument[] arguments = new InputArgument[] { this.Handle, offset.X, offset.Y, offset.Z, value.X, value.Y, value.Z };
                    Function.Call(Hash.SET_PARTICLE_FX_LOOPED_OFFSETS, arguments);
                }
            }
        }

        public System.Drawing.Color Color
        {
            get
            {
                System.Drawing.Color color;
                IntPtr memoryAddress = this.MemoryAddress;
                if (!(memoryAddress != IntPtr.Zero))
                {
                    return this._color;
                }
                memoryAddress = MemoryAccess.ReadPtr(memoryAddress + 0x20) + 320;
                byte alpha = Convert.ToByte((float) (MemoryAccess.ReadFloat(memoryAddress + 12) * 255f));
                this._color = color = System.Drawing.Color.FromArgb(alpha, Convert.ToByte((float) (MemoryAccess.ReadFloat(memoryAddress) * 255f)), Convert.ToByte((float) (MemoryAccess.ReadFloat(memoryAddress + 4) * 255f)), Convert.ToByte((float) (MemoryAccess.ReadFloat(memoryAddress + 8) * 255f)));
                return color;
            }
            set
            {
                this._color = value;
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    memoryAddress = MemoryAccess.ReadPtr(memoryAddress + 0x20) + 320;
                    MemoryAccess.WriteFloat(memoryAddress, ((float) value.R) / 255f);
                    MemoryAccess.WriteFloat(memoryAddress + 4, ((float) value.G) / 255f);
                    MemoryAccess.WriteFloat(memoryAddress + 8, ((float) value.B) / 255f);
                    MemoryAccess.WriteFloat(memoryAddress + 12, ((float) value.A) / 255f);
                }
            }
        }

        public float Scale
        {
            get
            {
                float num;
                IntPtr memoryAddress = this.MemoryAddress;
                if (!(memoryAddress != IntPtr.Zero))
                {
                    return this._scale;
                }
                this._scale = num = MemoryAccess.ReadFloat(MemoryAccess.ReadPtr(memoryAddress + 0x20) + 0x150);
                return num;
            }
            set
            {
                this._scale = value;
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(MemoryAccess.ReadPtr(memoryAddress + 0x20) + 0x150, value);
                }
            }
        }

        public float Range
        {
            get
            {
                float num;
                IntPtr memoryAddress = this.MemoryAddress;
                if (!(memoryAddress != IntPtr.Zero))
                {
                    return this._range;
                }
                this._range = num = MemoryAccess.ReadFloat(MemoryAccess.ReadPtr(memoryAddress + 0x20) + 0x180);
                return num;
            }
            set
            {
                this._range = value;
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash._SET_PARTICLE_FX_LOOPED_RANGE, arguments);
            }
        }

        public GTA.InvertAxis InvertAxis
        {
            get => 
                this._InvertAxis;
            set
            {
                this._InvertAxis = value;
                if (this.IsActive)
                {
                    this.Stop();
                    this.Start();
                }
            }
        }

        public string AssetName =>
            this._asset.AssetName;

        public string EffectName =>
            this._effectName;
    }
}

