namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public class CoordinateParticleEffect : ParticleEffect
    {
        public CoordinateParticleEffect(ParticleEffectsAsset asset, string effectName, Vector3 location) : base(asset, effectName)
        {
            base.Offset = location;
        }

        public CoordinateParticleEffect CopyTo(Vector3 position)
        {
            CoordinateParticleEffect effect1 = new CoordinateParticleEffect(base._asset, base._effectName, position);
            effect1.Rotation = base._rotation;
            effect1.Color = base._color;
            effect1.Scale = base._scale;
            effect1.Range = base._range;
            effect1.InvertAxis = base._InvertAxis;
            CoordinateParticleEffect effect = effect1;
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
                InputArgument[] arguments = new InputArgument[12];
                arguments[0] = base._effectName;
                arguments[1] = base.Offset.X;
                arguments[2] = base.Offset.Y;
                arguments[3] = base.Offset.Z;
                arguments[4] = base.Rotation.X;
                arguments[5] = base.Rotation.Y;
                arguments[6] = base.Rotation.Z;
                arguments[7] = base.Scale;
                arguments[8] = base.InvertAxis.HasFlag(InvertAxis.X);
                arguments[9] = base.InvertAxis.HasFlag(InvertAxis.Y);
                arguments[10] = base.InvertAxis.HasFlag(InvertAxis.Z);
                arguments[11] = false;
                base.Handle = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, arguments);
                if (base.IsActive)
                {
                    return true;
                }
                base.Handle = -1;
            }
            return false;
        }
    }
}

