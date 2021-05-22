// Decompiled with JetBrains decompiler
// Type: GTA.CoordinateParticleEffect
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public class CoordinateParticleEffect : ParticleEffect
  {
    public CoordinateParticleEffect(
      ParticleEffectsAsset asset,
      string effectName,
      Vector3 location)
      : base(asset, effectName)
    {
      this.Offset = location;
    }

    public override bool Start()
    {
      this.Stop();
      if (!this._asset.SetNextCall())
        return false;
      this.Handle = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, (InputArgument) this._effectName, (InputArgument) this.Offset.X, (InputArgument) this.Offset.Y, (InputArgument) this.Offset.Z, (InputArgument) this.Rotation.X, (InputArgument) this.Rotation.Y, (InputArgument) this.Rotation.Z, (InputArgument) this.Scale, (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.X), (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.Y), (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.Z), (InputArgument) false);
      if (this.IsActive)
        return true;
      this.Handle = -1;
      return false;
    }

    public CoordinateParticleEffect CopyTo(Vector3 position)
    {
      CoordinateParticleEffect coordinateParticleEffect1 = new CoordinateParticleEffect(this._asset, this._effectName, position);
      coordinateParticleEffect1.Rotation = this._rotation;
      coordinateParticleEffect1.Color = this._color;
      coordinateParticleEffect1.Scale = this._scale;
      coordinateParticleEffect1.Range = this._range;
      coordinateParticleEffect1.InvertAxis = this._InvertAxis;
      CoordinateParticleEffect coordinateParticleEffect2 = coordinateParticleEffect1;
      if (this.IsActive)
        coordinateParticleEffect2.Start();
      return coordinateParticleEffect2;
    }
  }
}
