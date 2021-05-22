// Decompiled with JetBrains decompiler
// Type: GTA.EntityParticleEffect
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public class EntityParticleEffect : ParticleEffect
  {
    private EntityBone _entityBone;

    internal EntityParticleEffect(ParticleEffectsAsset asset, string effectName, Entity entity)
      : base(asset, effectName)
      => this._entityBone = entity.Bones.Core;

    internal EntityParticleEffect(
      ParticleEffectsAsset asset,
      string effectName,
      EntityBone entitybone)
      : base(asset, effectName)
    {
      this._entityBone = entitybone;
    }

    public Entity Entity
    {
      get => this._entityBone.Owner;
      set
      {
        this._entityBone = value.Bones.Core;
        if (!this.IsActive)
          return;
        this.Stop();
        this.Start();
      }
    }

    public EntityBone Bone
    {
      get => this._entityBone;
      set
      {
        this._entityBone = value;
        if (!this.IsActive)
          return;
        this.Stop();
        this.Start();
      }
    }

    public override bool Start()
    {
      this.Stop();
      if (!this._asset.SetNextCall())
        return false;
      this.Handle = Function.Call<int>((Hash) (this._entityBone.Owner is Ped ? -968931481310103428L : -4113118388411728117L), (InputArgument) this._effectName, (InputArgument) this._entityBone.Owner.Handle, (InputArgument) this.Offset.X, (InputArgument) this.Offset.Y, (InputArgument) this.Offset.Z, (InputArgument) this.Rotation.X, (InputArgument) this.Rotation.Y, (InputArgument) this.Rotation.Z, (InputArgument) this._entityBone.Index, (InputArgument) this._scale, (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.X), (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.Y), (InputArgument) this.InvertAxis.HasFlag((Enum) InvertAxis.Z));
      if (this.IsActive)
        return true;
      this.Handle = -1;
      return false;
    }

    public EntityParticleEffect CopyTo(Entity entity)
    {
      EntityParticleEffect entityParticleEffect1 = new EntityParticleEffect(this._asset, this._effectName, entity);
      entityParticleEffect1.Bone = entity.Bones[this._entityBone.Index];
      entityParticleEffect1.Offset = this._offset;
      entityParticleEffect1.Rotation = this._rotation;
      entityParticleEffect1.Color = this._color;
      entityParticleEffect1.Scale = this._scale;
      entityParticleEffect1.Range = this._range;
      entityParticleEffect1.InvertAxis = this._InvertAxis;
      EntityParticleEffect entityParticleEffect2 = entityParticleEffect1;
      if (this.IsActive)
        entityParticleEffect2.Start();
      return entityParticleEffect2;
    }

    public EntityParticleEffect CopyTo(EntityBone entityBone)
    {
      EntityParticleEffect entityParticleEffect1 = new EntityParticleEffect(this._asset, this._effectName, entityBone);
      entityParticleEffect1.Offset = this._offset;
      entityParticleEffect1.Rotation = this._rotation;
      entityParticleEffect1.Color = this._color;
      entityParticleEffect1.Scale = this._scale;
      entityParticleEffect1.Range = this._range;
      entityParticleEffect1.InvertAxis = this._InvertAxis;
      EntityParticleEffect entityParticleEffect2 = entityParticleEffect1;
      if (this.IsActive)
        entityParticleEffect2.Start();
      return entityParticleEffect2;
    }
  }
}
