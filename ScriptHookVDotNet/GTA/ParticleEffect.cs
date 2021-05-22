// Decompiled with JetBrains decompiler
// Type: GTA.ParticleEffect
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA
{
  public abstract class ParticleEffect
  {
    protected readonly ParticleEffectsAsset _asset;
    protected readonly string _effectName;
    protected Vector3 _offset;
    protected Vector3 _rotation;
    protected Color _color;
    protected float _scale;
    protected float _range;
    protected InvertAxis _InvertAxis;

    internal ParticleEffect(ParticleEffectsAsset asset, string effectName)
    {
      this.Handle = -1;
      this._asset = asset;
      this._effectName = effectName;
    }

    public int Handle { get; protected set; }

    public bool IsActive
    {
      get
      {
        if (this.Handle == -1)
          return false;
        return Function.Call<bool>(Hash.DOES_PARTICLE_FX_LOOPED_EXIST, (InputArgument) this.Handle);
      }
    }

    public abstract bool Start();

    public void Stop()
    {
      if (this.IsActive)
        Function.Call(Hash.REMOVE_PARTICLE_FX, (InputArgument) this.Handle, (InputArgument) false);
      this.Handle = -1;
    }

    public IntPtr MemoryAddress => !this.IsActive ? IntPtr.Zero : MemoryAccess.GetPtfxAddress(this.Handle);

    public Vector3 Offset
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress != IntPtr.Zero)
        {
          IntPtr num = MemoryAccess.ReadPtr(memoryAddress + 32);
          if (num != IntPtr.Zero)
            return this._offset = MemoryAccess.ReadVector3(num + 144);
        }
        return this._offset;
      }
      set
      {
        this._offset = value;
        IntPtr memoryAddress = this.MemoryAddress;
        if (!(memoryAddress != IntPtr.Zero))
          return;
        IntPtr num = MemoryAccess.ReadPtr(memoryAddress + 32);
        if (!(num != IntPtr.Zero))
          return;
        MemoryAccess.WriteVector3(num + 144, value);
      }
    }

    public Vector3 Rotation
    {
      get => this._rotation;
      set
      {
        this._rotation = value;
        if (!this.IsActive)
          return;
        Vector3 offset = this.Offset;
        Function.Call(Hash.SET_PARTICLE_FX_LOOPED_OFFSETS, (InputArgument) this.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z);
      }
    }

    public Color Color
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (!(memoryAddress != IntPtr.Zero))
          return this._color;
        IntPtr address = MemoryAccess.ReadPtr(memoryAddress + 32) + 320;
        byte num1 = Convert.ToByte(MemoryAccess.ReadFloat(address) * (float) byte.MaxValue);
        byte num2 = Convert.ToByte(MemoryAccess.ReadFloat(address + 4) * (float) byte.MaxValue);
        byte num3 = Convert.ToByte(MemoryAccess.ReadFloat(address + 8) * (float) byte.MaxValue);
        return this._color = Color.FromArgb((int) Convert.ToByte(MemoryAccess.ReadFloat(address + 12) * (float) byte.MaxValue), (int) num1, (int) num2, (int) num3);
      }
      set
      {
        this._color = value;
        IntPtr memoryAddress = this.MemoryAddress;
        if (!(memoryAddress != IntPtr.Zero))
          return;
        IntPtr address = MemoryAccess.ReadPtr(memoryAddress + 32) + 320;
        MemoryAccess.WriteFloat(address, (float) value.R / (float) byte.MaxValue);
        MemoryAccess.WriteFloat(address + 4, (float) value.G / (float) byte.MaxValue);
        MemoryAccess.WriteFloat(address + 8, (float) value.B / (float) byte.MaxValue);
        MemoryAccess.WriteFloat(address + 12, (float) value.A / (float) byte.MaxValue);
      }
    }

    public float Scale
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress != IntPtr.Zero ? (this._scale = MemoryAccess.ReadFloat(MemoryAccess.ReadPtr(memoryAddress + 32) + 336)) : this._scale;
      }
      set
      {
        this._scale = value;
        IntPtr memoryAddress = this.MemoryAddress;
        if (!(memoryAddress != IntPtr.Zero))
          return;
        MemoryAccess.WriteFloat(MemoryAccess.ReadPtr(memoryAddress + 32) + 336, value);
      }
    }

    public float Range
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress != IntPtr.Zero ? (this._range = MemoryAccess.ReadFloat(MemoryAccess.ReadPtr(memoryAddress + 32) + 384)) : this._range;
      }
      set
      {
        this._range = value;
        Function.Call(Hash._SET_PARTICLE_FX_LOOPED_RANGE, (InputArgument) this.Handle, (InputArgument) value);
      }
    }

    public InvertAxis InvertAxis
    {
      get => this._InvertAxis;
      set
      {
        this._InvertAxis = value;
        if (!this.IsActive)
          return;
        this.Stop();
        this.Start();
      }
    }

    public void SetParameter(string parameterName, float value)
    {
      if (!this.IsActive)
        return;
      Function.Call(Hash.SET_PARTICLE_FX_LOOPED_EVOLUTION, (InputArgument) parameterName, (InputArgument) value, (InputArgument) 0);
    }

    public string AssetName => this._asset.AssetName;

    public string EffectName => this._effectName;

    public override string ToString() => string.Format("{0}\\{1}", (object) this.AssetName, (object) this.EffectName);

    public static implicit operator InputArgument(ParticleEffect effect) => new InputArgument((object) effect.Handle);
  }
}
