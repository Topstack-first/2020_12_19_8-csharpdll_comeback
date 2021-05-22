namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class ParticleEffectsAsset
    {
        private readonly string _assetName;

        public ParticleEffectsAsset(string assetName)
        {
            this._assetName = assetName;
        }

        public CoordinateParticleEffect CreateEffectAtCoord(string effectName, Vector3 pos, Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0, bool startNow = false)
        {
            CoordinateParticleEffect effect1 = new CoordinateParticleEffect(this, effectName, pos);
            effect1.Rotation = rot;
            effect1.Scale = scale;
            effect1.InvertAxis = invertAxis;
            CoordinateParticleEffect effect = effect1;
            if (startNow)
            {
                effect.Start();
            }
            return effect;
        }

        public EntityParticleEffect CreateEffectOnEntity(string effectName, Entity entity, Vector3 off = new Vector3(), Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0, bool startNow = false)
        {
            EntityParticleEffect effect1 = new EntityParticleEffect(this, effectName, entity);
            effect1.Offset = off;
            effect1.Rotation = rot;
            effect1.Scale = scale;
            effect1.InvertAxis = invertAxis;
            EntityParticleEffect effect = effect1;
            if (startNow)
            {
                effect.Start();
            }
            return effect;
        }

        public EntityParticleEffect CreateEffectOnEntity(string effectName, EntityBone entityBone, Vector3 off = new Vector3(), Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0, bool startNow = false)
        {
            EntityParticleEffect effect1 = new EntityParticleEffect(this, effectName, entityBone);
            effect1.Offset = off;
            effect1.Rotation = rot;
            effect1.Scale = scale;
            effect1.InvertAxis = invertAxis;
            EntityParticleEffect effect = effect1;
            if (startNow)
            {
                effect.Start();
            }
            return effect;
        }

        public override int GetHashCode() => 
            this._assetName.GetHashCode();

        public void MarkAsNoLongerNeeded()
        {
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash._REMOVE_NAMED_PTFX_ASSET, arguments);
        }

        public static implicit operator InputArgument(ParticleEffectsAsset asset) => 
            new InputArgument(asset._assetName);

        public void Request()
        {
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, arguments);
        }

        public bool Request(int timeout)
        {
            this.Request();
            DateTime time = (timeout >= 0) ? (DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, timeout)) : DateTime.MaxValue;
            while (!this.IsLoaded)
            {
                Script.Yield();
                if (DateTime.UtcNow >= time)
                {
                    return false;
                }
                this.Request();
            }
            return true;
        }

        internal bool SetNextCall()
        {
            this.Request();
            if (!this.IsLoaded)
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, arguments);
            return true;
        }

        public bool StartNonLoopedAtCoord(string effectName, Vector3 pos, Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0)
        {
            if (!this.SetNextCall())
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, arguments);
            InputArgument[] argumentArray2 = new InputArgument[11];
            argumentArray2[0] = effectName;
            argumentArray2[1] = pos.X;
            argumentArray2[2] = pos.Y;
            argumentArray2[3] = pos.Z;
            argumentArray2[4] = rot.X;
            argumentArray2[5] = rot.Y;
            argumentArray2[6] = rot.Z;
            argumentArray2[7] = scale;
            argumentArray2[8] = invertAxis.HasFlag(InvertAxis.X);
            argumentArray2[9] = invertAxis.HasFlag(InvertAxis.Y);
            argumentArray2[10] = invertAxis.HasFlag(InvertAxis.Z);
            return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, argumentArray2);
        }

        public bool StartNonLoopedOnEntity(string effectName, Entity entity, Vector3 off = new Vector3(), Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0)
        {
            if (!this.SetNextCall())
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, arguments);
            InputArgument[] argumentArray2 = new InputArgument[13];
            argumentArray2[0] = effectName;
            argumentArray2[1] = entity.Handle;
            argumentArray2[2] = off.X;
            argumentArray2[3] = off.Y;
            argumentArray2[4] = off.Z;
            argumentArray2[5] = rot.X;
            argumentArray2[6] = rot.Y;
            argumentArray2[7] = rot.Z;
            argumentArray2[8] = -1;
            argumentArray2[9] = scale;
            argumentArray2[10] = invertAxis.HasFlag(InvertAxis.X);
            argumentArray2[11] = invertAxis.HasFlag(InvertAxis.Y);
            argumentArray2[12] = invertAxis.HasFlag(InvertAxis.Z);
            return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE, argumentArray2);
        }

        public bool StartNonLoopedOnEntity(string effectName, EntityBone entityBone, Vector3 off = new Vector3(), Vector3 rot = new Vector3(), float scale = 1f, InvertAxis invertAxis = 0)
        {
            if (!this.SetNextCall())
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this._assetName };
            Function.Call(Hash._USE_PARTICLE_FX_ASSET_NEXT_CALL, arguments);
            InputArgument[] argumentArray2 = new InputArgument[13];
            argumentArray2[0] = effectName;
            argumentArray2[1] = entityBone.Owner.Handle;
            argumentArray2[2] = off.X;
            argumentArray2[3] = off.Y;
            argumentArray2[4] = off.Z;
            argumentArray2[5] = rot.X;
            argumentArray2[6] = rot.Y;
            argumentArray2[7] = rot.Z;
            argumentArray2[8] = (InputArgument) entityBone;
            argumentArray2[9] = scale;
            argumentArray2[10] = invertAxis.HasFlag(InvertAxis.X);
            argumentArray2[11] = invertAxis.HasFlag(InvertAxis.Y);
            argumentArray2[12] = invertAxis.HasFlag(InvertAxis.Z);
            return Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_PED_BONE, argumentArray2);
        }

        public override string ToString() => 
            this._assetName;

        public string AssetName =>
            this._assetName;

        public bool IsLoaded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._assetName };
                return Function.Call<bool>(Hash.HAS_NAMED_PTFX_ASSET_LOADED, arguments);
            }
        }

        private static Color NonLoopedColor
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { ((float) value.R) / 255f, ((float) value.G) / 255f, ((float) value.B) / 255f };
                Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_COLOUR, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { ((float) value.A) / 255f };
                Function.Call(Hash.SET_PARTICLE_FX_NON_LOOPED_ALPHA, argumentArray2);
            }
        }
    }
}

