namespace GTA
{
    using GTA.Native;
    using System;

    public class EntityParticleEffect : ParticleEffect
    {
        private EntityBone _entityBone;

        internal EntityParticleEffect(ParticleEffectsAsset asset, string effectName, GTA.Entity entity) : base(asset, effectName)
        {
            this._entityBone = entity.Bones.Core;
        }

        internal EntityParticleEffect(ParticleEffectsAsset asset, string effectName, EntityBone entitybone) : base(asset, effectName)
        {
            this._entityBone = entitybone;
        }

        public EntityParticleEffect CopyTo(GTA.Entity entity)
        {
            EntityParticleEffect effect1 = new EntityParticleEffect(base._asset, base._effectName, entity);
            effect1.Bone = entity.Bones[this._entityBone.Index];
            effect1.Offset = base._offset;
            effect1.Rotation = base._rotation;
            effect1.Color = base._color;
            effect1.Scale = base._scale;
            effect1.Range = base._range;
            effect1.InvertAxis = base._InvertAxis;
            EntityParticleEffect effect = effect1;
            if (base.IsActive)
            {
                effect.Start();
            }
            return effect;
        }

        public EntityParticleEffect CopyTo(EntityBone entityBone)
        {
            EntityParticleEffect effect1 = new EntityParticleEffect(base._asset, base._effectName, entityBone);
            effect1.Offset = base._offset;
            effect1.Rotation = base._rotation;
            effect1.Color = base._color;
            effect1.Scale = base._scale;
            effect1.Range = base._range;
            effect1.InvertAxis = base._InvertAxis;
            EntityParticleEffect effect = effect1;
            if (base.IsActive)
            {
                effect.Start();
            }
            return effect;
        }

        public override bool Start()
        {
            base.Stop();
            if (base._asset.SetNextCall())
            {
                Hash hash = (this._entityBone.Owner is Ped) ? Hash.START_PARTICLE_FX_LOOPED_ON_PED_BONE : Hash._START_PARTICLE_FX_LOOPED_ON_ENTITY_BONE;
                InputArgument[] arguments = new InputArgument[13];
                arguments[0] = base._effectName;
                arguments[1] = this._entityBone.Owner.Handle;
                arguments[2] = base.Offset.X;
                arguments[3] = base.Offset.Y;
                arguments[4] = base.Offset.Z;
                arguments[5] = base.Rotation.X;
                arguments[6] = base.Rotation.Y;
                arguments[7] = base.Rotation.Z;
                arguments[8] = this._entityBone.Index;
                arguments[9] = base._scale;
                arguments[10] = base.InvertAxis.HasFlag(InvertAxis.X);
                arguments[11] = base.InvertAxis.HasFlag(InvertAxis.Y);
                arguments[12] = base.InvertAxis.HasFlag(InvertAxis.Z);
                base.Handle = Function.Call<int>(hash, arguments);
                if (base.IsActive)
                {
                    return true;
                }
                base.Handle = -1;
            }
            return false;
        }

        public GTA.Entity Entity
        {
            get => 
                this._entityBone.Owner;
            set
            {
                this._entityBone = value.Bones.Core;
                if (base.IsActive)
                {
                    base.Stop();
                    this.Start();
                }
            }
        }

        public EntityBone Bone
        {
            get => 
                this._entityBone;
            set
            {
                this._entityBone = value;
                if (base.IsActive)
                {
                    base.Stop();
                    this.Start();
                }
            }
        }
    }
}

