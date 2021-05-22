// Decompiled with JetBrains decompiler
// Type: GTA.ParticleEffectsAsset
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA
{
  public class ParticleEffectsAsset
  {
    private readonly string _assetName;

    public ParticleEffectsAsset(string assetName) => this._assetName = assetName;

    public string AssetName => this._assetName;

    public bool IsLoaded => Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, (InputArgument) this._assetName);

    public bool StartNonLoopedAtCoord(
      string effectName,
      Vector3 pos,
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None)
    {
      if (!this.SetNextCall())
        return false;
      Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, (InputArgument) this._assetName);
      return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, (InputArgument) effectName, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) rot.X, (InputArgument) rot.Y, (InputArgument) rot.Z, (InputArgument) scale, (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.X), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Y), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Z));
    }

    public bool StartNonLoopedOnEntity(
      string effectName,
      Entity entity,
      Vector3 off = default (Vector3),
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None)
    {
      if (!this.SetNextCall())
        return false;
      Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, (InputArgument) this._assetName);
      return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE, (InputArgument) effectName, (InputArgument) entity.Handle, (InputArgument) off.X, (InputArgument) off.Y, (InputArgument) off.Z, (InputArgument) rot.X, (InputArgument) rot.Y, (InputArgument) rot.Z, (InputArgument) -1, (InputArgument) scale, (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.X), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Y), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Z));
    }

    public bool StartNonLoopedOnEntity(
      string effectName,
      EntityBone entityBone,
      Vector3 off = default (Vector3),
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None)
    {
      if (!this.SetNextCall())
        return false;
      Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, (InputArgument) this._assetName);
      return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE, (InputArgument) effectName, (InputArgument) entityBone.Owner.Handle, (InputArgument) off.X, (InputArgument) off.Y, (InputArgument) off.Z, (InputArgument) rot.X, (InputArgument) rot.Y, (InputArgument) rot.Z, (InputArgument) entityBone, (InputArgument) scale, (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.X), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Y), (InputArgument) invertAxis.HasFlag((Enum) InvertAxis.Z));
    }

    public EntityParticleEffect CreateEffectOnEntity(
      string effectName,
      Entity entity,
      Vector3 off = default (Vector3),
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None,
      bool startNow = false)
    {
      EntityParticleEffect entityParticleEffect1 = new EntityParticleEffect(this, effectName, entity);
      entityParticleEffect1.Offset = off;
      entityParticleEffect1.Rotation = rot;
      entityParticleEffect1.Scale = scale;
      entityParticleEffect1.InvertAxis = invertAxis;
      EntityParticleEffect entityParticleEffect2 = entityParticleEffect1;
      if (startNow)
        entityParticleEffect2.Start();
      return entityParticleEffect2;
    }

    public EntityParticleEffect CreateEffectOnEntity(
      string effectName,
      EntityBone entityBone,
      Vector3 off = default (Vector3),
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None,
      bool startNow = false)
    {
      EntityParticleEffect entityParticleEffect1 = new EntityParticleEffect(this, effectName, entityBone);
      entityParticleEffect1.Offset = off;
      entityParticleEffect1.Rotation = rot;
      entityParticleEffect1.Scale = scale;
      entityParticleEffect1.InvertAxis = invertAxis;
      EntityParticleEffect entityParticleEffect2 = entityParticleEffect1;
      if (startNow)
        entityParticleEffect2.Start();
      return entityParticleEffect2;
    }

    public CoordinateParticleEffect CreateEffectAtCoord(
      string effectName,
      Vector3 pos,
      Vector3 rot = default (Vector3),
      float scale = 1f,
      InvertAxis invertAxis = InvertAxis.None,
      bool startNow = false)
    {
      CoordinateParticleEffect coordinateParticleEffect1 = new CoordinateParticleEffect(this, effectName, pos);
      coordinateParticleEffect1.Rotation = rot;
      coordinateParticleEffect1.Scale = scale;
      coordinateParticleEffect1.InvertAxis = invertAxis;
      CoordinateParticleEffect coordinateParticleEffect2 = coordinateParticleEffect1;
      if (startNow)
        coordinateParticleEffect2.Start();
      return coordinateParticleEffect2;
    }

    private static Color NonLoopedColor
    {
      set
      {
        Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, (InputArgument) ((float) value.R / (float) byte.MaxValue), (InputArgument) ((float) value.G / (float) byte.MaxValue), (InputArgument) ((float) value.B / (float) byte.MaxValue));
        Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_ALPHA, (InputArgument) ((float) value.A / (float) byte.MaxValue));
      }
    }

    public void Request() => Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument) this._assetName);

    public bool Request(int timeout)
    {
      this.Request();
      DateTime dateTime = timeout >= 0 ? DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout) : DateTime.MaxValue;
      while (!this.IsLoaded)
      {
        Script.Yield();
        if (DateTime.UtcNow >= dateTime)
          return false;
        this.Request();
      }
      return true;
    }

    internal bool SetNextCall()
    {
      this.Request();
      if (!this.IsLoaded)
        return false;
      Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, (InputArgument) this._assetName);
      return true;
    }

    public void MarkAsNoLongerNeeded() => Function.Call(Hash._REMOVE_NAMED_PTFX_ASSET, (InputArgument) this._assetName);

    public override string ToString() => this._assetName;

    public override int GetHashCode() => this._assetName.GetHashCode();

    public static implicit operator InputArgument(ParticleEffectsAsset asset) => new InputArgument((object) asset._assetName);
  }
}
