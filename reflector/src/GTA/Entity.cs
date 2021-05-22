namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    public abstract class Entity : PoolObject, IEquatable<Entity>, ISpatial
    {
        private EntityBoneCollection _bones;

        public Entity(int handle) : base(handle)
        {
        }

        public void ApplyForce(Vector3 direction, Vector3 rotation = new Vector3(), ForceType forceType = 3)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = base.Handle;
            arguments[1] = forceType;
            arguments[2] = direction.X;
            arguments[3] = direction.Y;
            arguments[4] = direction.Z;
            arguments[5] = rotation.X;
            arguments[6] = rotation.Y;
            arguments[7] = rotation.Z;
            arguments[8] = false;
            arguments[9] = false;
            arguments[10] = true;
            arguments[11] = true;
            arguments[12] = false;
            arguments[13] = true;
            Function.Call(Hash.APPLY_FORCE_TO_ENTITY, arguments);
        }

        public void ApplyForceRelative(Vector3 direction, Vector3 rotation = new Vector3(), ForceType forceType = 3)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = base.Handle;
            arguments[1] = forceType;
            arguments[2] = direction.X;
            arguments[3] = direction.Y;
            arguments[4] = direction.Z;
            arguments[5] = rotation.X;
            arguments[6] = rotation.Y;
            arguments[7] = rotation.Z;
            arguments[8] = false;
            arguments[9] = true;
            arguments[10] = true;
            arguments[11] = true;
            arguments[12] = false;
            arguments[13] = true;
            Function.Call(Hash.APPLY_FORCE_TO_ENTITY, arguments);
        }

        public Blip AttachBlip()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_ENTITY, arguments));
        }

        public void AttachTo(Entity entity, Vector3 position = new Vector3(), Vector3 rotation = new Vector3())
        {
            InputArgument[] arguments = new InputArgument[15];
            arguments[0] = base.Handle;
            arguments[1] = entity.Handle;
            arguments[2] = -1;
            arguments[3] = position.X;
            arguments[4] = position.Y;
            arguments[5] = position.Z;
            arguments[6] = rotation.X;
            arguments[7] = rotation.Y;
            arguments[8] = rotation.Z;
            arguments[9] = 0;
            arguments[10] = 0;
            arguments[11] = 0;
            arguments[12] = 0;
            arguments[13] = 2;
            arguments[14] = 1;
            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, arguments);
        }

        public void AttachTo(EntityBone entityBone, Vector3 position = new Vector3(), Vector3 rotation = new Vector3())
        {
            InputArgument[] arguments = new InputArgument[15];
            arguments[0] = base.Handle;
            arguments[1] = entityBone.Owner.Handle;
            arguments[2] = (InputArgument) entityBone;
            arguments[3] = position.X;
            arguments[4] = position.Y;
            arguments[5] = position.Z;
            arguments[6] = rotation.X;
            arguments[7] = rotation.Y;
            arguments[8] = rotation.Z;
            arguments[9] = 0;
            arguments[10] = 0;
            arguments[11] = 0;
            arguments[12] = 0;
            arguments[13] = 2;
            arguments[14] = 1;
            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, arguments);
        }

        public virtual void ClearLastWeaponDamage()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.CLEAR_ENTITY_LAST_WEAPON_DAMAGE, arguments);
        }

        public override unsafe void Delete()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, false, true };
            Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, arguments);
            int handle = base.Handle;
            InputArgument[] argumentArray2 = new InputArgument[] { (IntPtr) &handle };
            Function.Call(Hash.DELETE_ENTITY, argumentArray2);
            base.Handle = handle;
        }

        public void Detach()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, true, true };
            Function.Call(Hash.DETACH_ENTITY, arguments);
        }

        public bool Equals(Entity entity) => 
            (entity != null) && (base.Handle == entity.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Entity) obj));

        public override bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_ENTITY_EXIST, arguments);
        }

        public static bool Exists(Entity entity) => 
            (entity != null) && entity.Exists();

        public static Entity FromHandle(int handle)
        {
            InputArgument[] arguments = new InputArgument[] { handle };
            switch (Function.Call<int>(Hash.GET_ENTITY_TYPE, arguments))
            {
                case 1:
                    return new Ped(handle);

                case 2:
                    return new Vehicle(handle);

                case 3:
                    return new Prop(handle);
            }
            return null;
        }

        public Entity GetEntityAttachedTo()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return FromHandle(Function.Call<int>(Hash.GET_ENTITY_ATTACHED_TO, arguments));
        }

        public override int GetHashCode() => 
            base.Handle.GetHashCode();

        public Vector3 GetOffsetPosition(Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, offset.X, offset.Y, offset.Z };
            return Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, arguments);
        }

        public Vector3 GetPositionOffset(Vector3 worldCoords)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, worldCoords.X, worldCoords.Y, worldCoords.Z };
            return Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_GIVEN_WORLD_COORDS, arguments);
        }

        public bool HasBeenDamagedBy(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle, 1 };
            return Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_ENTITY, arguments);
        }

        public virtual bool HasBeenDamagedBy(WeaponHash weapon)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, weapon, 0 };
            return Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public virtual bool HasBeenDamagedByAnyMeleeWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0, 1 };
            return Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public virtual bool HasBeenDamagedByAnyWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0, 2 };
            return Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public bool IsAttached()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.IS_ENTITY_ATTACHED, arguments);
        }

        public bool IsAttachedTo(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle };
            return Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, arguments);
        }

        public bool IsInAngledArea(Vector3 origin, Vector3 edge, float angle)
        {
            InputArgument[] arguments = new InputArgument[11];
            arguments[0] = base.Handle;
            arguments[1] = origin.X;
            arguments[2] = origin.Y;
            arguments[3] = origin.Z;
            arguments[4] = edge.X;
            arguments[5] = edge.Y;
            arguments[6] = edge.Z;
            arguments[7] = angle;
            arguments[8] = false;
            arguments[9] = true;
            arguments[10] = false;
            return Function.Call<bool>(Hash.IS_ENTITY_IN_ANGLED_AREA, arguments);
        }

        public bool IsInArea(Vector3 minBounds, Vector3 maxBounds)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, minBounds.X, minBounds.Y, minBounds.Z, maxBounds.X, maxBounds.Y, maxBounds.Z };
            return Function.Call<bool>(Hash.IS_ENTITY_IN_AREA, arguments);
        }

        public bool IsInRangeOf(Vector3 position, float range) => 
            Vector3.Subtract(this.Position, position).LengthSquared() < (range * range);

        public bool IsNearEntity(Entity entity, Vector3 bounds)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle, bounds.X, bounds.Y, bounds.Z, false, true, false };
            return Function.Call<bool>(Hash.IS_ENTITY_AT_ENTITY, arguments);
        }

        public bool IsTouching(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle };
            return Function.Call<bool>(Hash.IS_ENTITY_TOUCHING_ENTITY, arguments);
        }

        public bool IsTouching(GTA.Model model)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, model.Hash };
            return Function.Call<bool>(Hash.IS_ENTITY_TOUCHING_MODEL, arguments);
        }

        public unsafe void MarkAsNoLongerNeeded()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, false, true };
            Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, arguments);
            int handle = base.Handle;
            InputArgument[] argumentArray2 = new InputArgument[] { (IntPtr) &handle };
            Function.Call(Hash.SET_ENTITY_AS_NO_LONGER_NEEDED, argumentArray2);
            base.Handle = handle;
        }

        public static bool operator ==(Entity left, Entity right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Entity left, Entity right) => 
            !(left == right);

        public void RemoveAllParticleEffects()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, arguments);
        }

        public void ResetOpacity()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.RESET_ENTITY_ALPHA, arguments);
        }

        public void SetNoCollision(Entity entity, bool toggle)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle, toggle };
            Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, arguments);
        }

        public IntPtr MemoryAddress =>
            MemoryAccess.GetEntityAddress(base.Handle);

        public int Health
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return (Function.Call<int>(Hash.GET_ENTITY_HEALTH, arguments) - 100);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value + 100 };
                Function.Call(Hash.SET_ENTITY_HEALTH, arguments);
            }
        }

        public float HealthFloat
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadFloat(this.MemoryAddress + 640) : 0f;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    MemoryAccess.WriteFloat(this.MemoryAddress + 640, value);
                }
            }
        }

        public int MaxHealth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return (Function.Call<int>(Hash.GET_ENTITY_MAX_HEALTH, arguments) - 100);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value + 100 };
                Function.Call(Hash.SET_ENTITY_MAX_HEALTH, arguments);
            }
        }

        public float MaxHealthFloat
        {
            get
            {
                if (this.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x2a0 : 0x284;
                return MemoryAccess.ReadFloat(this.MemoryAddress + num);
            }
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x2a0 : 0x284;
                    MemoryAccess.WriteFloat(this.MemoryAddress + num, value);
                }
            }
        }

        public bool IsDead
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_DEAD, arguments);
            }
        }

        public bool IsAlive =>
            !this.IsDead;

        public GTA.Model Model
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return new GTA.Model(Function.Call<int>(Hash.GET_ENTITY_MODEL, arguments));
            }
        }

        public virtual Vector3 Position
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 0 };
                return Function.Call<Vector3>(Hash.GET_ENTITY_COORDS, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z, 0, 0, 0, 1 };
                Function.Call(Hash.SET_ENTITY_COORDS, arguments);
            }
        }

        public Vector3 PositionNoOffset
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z, 1, 1, 1 };
                Function.Call(Hash.SET_ENTITY_COORDS_NO_OFFSET, arguments);
            }
        }

        public virtual Vector3 Rotation
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 2 };
                return Function.Call<Vector3>(Hash.GET_ENTITY_ROTATION, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z, 2, 1 };
                Function.Call(Hash.SET_ENTITY_ROTATION, arguments);
            }
        }

        public GTA.Math.Quaternion Quaternion
        {
            get
            {
                float num;
                float num2;
                float num3;
                float num4;
                InputArgument[] arguments = new InputArgument[] { base.Handle, (IntPtr) &num4, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_ENTITY_QUATERNION, arguments);
                return new GTA.Math.Quaternion(num4, num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z, value.W };
                Function.Call(Hash.SET_ENTITY_QUATERNION, arguments);
            }
        }

        public float Heading
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_ENTITY_HEADING, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call<float>(Hash.SET_ENTITY_HEADING, arguments);
            }
        }

        public Vector3 UpVector =>
            !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(this.MemoryAddress + 0x80) : Vector3.RelativeTop;

        public Vector3 RightVector =>
            !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(this.MemoryAddress + 0x60) : Vector3.RelativeRight;

        public Vector3 ForwardVector =>
            !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(this.MemoryAddress + 0x70) : Vector3.RelativeFront;

        public Vector3 LeftPosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector, out vector2);
                return this.GetOffsetPosition(new Vector3(vector.X, 0f, 0f));
            }
        }

        public Vector3 RightPosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector2, out vector);
                return this.GetOffsetPosition(new Vector3(vector.X, 0f, 0f));
            }
        }

        public Vector3 FrontPosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector2, out vector);
                return this.GetOffsetPosition(new Vector3(0f, vector.Y, 0f));
            }
        }

        public Vector3 RearPosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector, out vector2);
                return this.GetOffsetPosition(new Vector3(0f, vector.Y, 0f));
            }
        }

        public Vector3 AbovePosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector2, out vector);
                return this.GetOffsetPosition(new Vector3(0f, 0f, vector.Z));
            }
        }

        public Vector3 BelowPosition
        {
            get
            {
                Vector3 vector;
                Vector3 vector2;
                this.Model.GetDimensions(out vector, out vector2);
                return this.GetOffsetPosition(new Vector3(0f, 0f, vector.Z));
            }
        }

        public GTA.Math.Matrix Matrix
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (!(memoryAddress == IntPtr.Zero))
                {
                    return MemoryAccess.ReadMatrix(memoryAddress + 0x60);
                }
                return new GTA.Math.Matrix();
            }
        }

        public bool IsPositionFrozen
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x2e, 1) : false;
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.FREEZE_ENTITY_POSITION, arguments);
            }
        }

        public Vector3 Velocity
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<Vector3>(Hash.GET_ENTITY_VELOCITY, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z };
                Function.Call(Hash.SET_ENTITY_VELOCITY, arguments);
            }
        }

        public Vector3 RotationVelocity
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<Vector3>(Hash.GET_ENTITY_ROTATION_VELOCITY, arguments);
            }
        }

        public float Speed
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_ENTITY_SPEED, arguments);
            }
            set => 
                this.Velocity = this.Velocity.Normalized * value;
        }

        public float MaxSpeed
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_MAX_SPEED, arguments);
            }
        }

        public bool HasGravity
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                if (memoryAddress == IntPtr.Zero)
                {
                    return true;
                }
                memoryAddress = MemoryAccess.ReadPtr(memoryAddress + 0x30);
                return (!(memoryAddress == IntPtr.Zero) ? !MemoryAccess.IsBitSet(memoryAddress + 0x1a, 4) : true);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_HAS_GRAVITY, arguments);
            }
        }

        public float HeightAboveGround
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_ENTITY_HEIGHT_ABOVE_GROUND, arguments);
            }
        }

        public float SubmersionLevel
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_ENTITY_SUBMERGED_LEVEL, arguments);
            }
        }

        public int LodDistance
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_ENTITY_LOD_DIST, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_LOD_DIST, arguments);
            }
        }

        public bool IsVisible
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_VISIBLE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_VISIBLE, arguments);
            }
        }

        public bool IsOccluded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_OCCLUDED, arguments);
            }
        }

        public bool IsOnScreen
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_ON_SCREEN, arguments);
            }
        }

        public bool IsRendered =>
            !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0xb0, 4) : false;

        public bool IsUpright
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 30f };
                return Function.Call<bool>(Hash.IS_ENTITY_UPRIGHT, arguments);
            }
        }

        public bool IsUpsideDown
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_UPSIDEDOWN, arguments);
            }
        }

        public bool IsInAir
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_IN_AIR, arguments);
            }
        }

        public bool IsInWater
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_IN_WATER, arguments);
            }
        }

        public bool IsPersistent
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_A_MISSION_ENTITY, arguments);
            }
            set
            {
                if (!value)
                {
                    this.MarkAsNoLongerNeeded();
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle, true, false };
                    Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, arguments);
                }
            }
        }

        public bool IsOnFire
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ENTITY_ON_FIRE, arguments);
            }
        }

        public bool IsFireProof
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 5) : false;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    IntPtr address = this.MemoryAddress + 0x188;
                    if (value)
                    {
                        MemoryAccess.SetBit(address, 5);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(address, 5);
                    }
                }
            }
        }

        public bool IsMeleeProof
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 7) : false;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    IntPtr address = this.MemoryAddress + 0x188;
                    if (value)
                    {
                        MemoryAccess.SetBit(address, 7);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(address, 7);
                    }
                }
            }
        }

        public bool IsBulletProof
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 4) : false;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    IntPtr address = this.MemoryAddress + 0x188;
                    if (value)
                    {
                        MemoryAccess.SetBit(address, 4);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(address, 4);
                    }
                }
            }
        }

        public bool IsExplosionProof
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 11) : false;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    IntPtr address = this.MemoryAddress + 0x188;
                    if (value)
                    {
                        MemoryAccess.SetBit(address, 11);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(address, 11);
                    }
                }
            }
        }

        public bool IsCollisionProof
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 6) : false;
            set
            {
                if (this.MemoryAddress != IntPtr.Zero)
                {
                    IntPtr address = this.MemoryAddress + 0x188;
                    if (value)
                    {
                        MemoryAccess.SetBit(address, 6);
                    }
                    else
                    {
                        MemoryAccess.ClearBit(address, 6);
                    }
                }
            }
        }

        public bool IsInvincible
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 8) : false;
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_INVINCIBLE, arguments);
            }
        }

        public bool IsOnlyDamagedByPlayer
        {
            get => 
                !(this.MemoryAddress == IntPtr.Zero) ? MemoryAccess.IsBitSet(this.MemoryAddress + 0x188, 9) : false;
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER, arguments);
            }
        }

        public int Opacity
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_ENTITY_ALPHA, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value, false };
                Function.Call(Hash.SET_ENTITY_ALPHA, arguments);
            }
        }

        public bool HasCollided
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.HAS_ENTITY_COLLIDED_WITH_ANYTHING, arguments);
            }
        }

        public bool IsCollisionEnabled
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return !Function.Call<bool>(Hash._GET_ENTITY_COLLISON_DISABLED, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value, false };
                Function.Call(Hash.SET_ENTITY_COLLISION, arguments);
            }
        }

        public bool IsRecordingCollisions
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_ENTITY_RECORDS_COLLISIONS, arguments);
            }
        }

        public virtual EntityBoneCollection Bones
        {
            get
            {
                this._bones ??= new EntityBoneCollection(this);
                return this._bones;
            }
        }

        public Blip AttachedBlip
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                int handle = Function.Call<int>(Hash.GET_BLIP_FROM_ENTITY, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { handle };
                return (!Function.Call<bool>(Hash.DOES_BLIP_EXIST, argumentArray2) ? null : new Blip(handle));
            }
        }

        public Blip[] AttachedBlips =>
            (from x in World.GetAllBlips(Array.Empty<BlipSprite>())
                where Function.Call<int>(Hash.GET_BLIP_INFO_ID_ENTITY_INDEX, new InputArgument[] { x }) == base.Handle
                select x).ToArray<Blip>();
    }
}

