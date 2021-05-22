// Decompiled with JetBrains decompiler
// Type: GTA.Entity
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA
{
  public abstract class Entity : PoolObject, IEquatable<Entity>, ISpatial
  {
    private EntityBoneCollection _bones;

    public Entity(int handle)
      : base(handle)
    {
    }

    public IntPtr MemoryAddress => MemoryAccess.GetEntityAddress(this.Handle);

    public int Health
    {
      get => Function.Call<int>(Hash.GET_ENTITY_HEALTH, (InputArgument) this.Handle) - 100;
      set => Function.Call(Hash.SET_ENTITY_HEALTH, (InputArgument) this.Handle, (InputArgument) (value + 100));
    }

    public float HealthFloat
    {
      get => this.MemoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(this.MemoryAddress + 640);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(this.MemoryAddress + 640, value);
      }
    }

    public int MaxHealth
    {
      get => Function.Call<int>(Hash.GET_ENTITY_MAX_HEALTH, (InputArgument) this.Handle) - 100;
      set => Function.Call(Hash.SET_ENTITY_MAX_HEALTH, (InputArgument) this.Handle, (InputArgument) (value + 100));
    }

    public float MaxHealthFloat
    {
      get => this.MemoryAddress == IntPtr.Zero ? 0.0f : MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_877_1_Steam ? 672 : 644));
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_877_1_Steam ? 672 : 644), value);
      }
    }

    public bool IsDead => Function.Call<bool>(Hash.IS_ENTITY_DEAD, (InputArgument) this.Handle);

    public bool IsAlive => !this.IsDead;

    public Model Model => new Model(Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument) this.Handle));

    public virtual Vector3 Position
    {
      get => Function.Call<Vector3>(Hash.GET_ENTITY_COORDS, (InputArgument) this.Handle, (InputArgument) 0);
      set => Function.Call(Hash.SET_ENTITY_COORDS, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
    }

    public Vector3 PositionNoOffset
    {
      set => Function.Call(Hash.SET_ENTITY_COORDS_NO_OFFSET, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1);
    }

    public virtual Vector3 Rotation
    {
      get => Function.Call<Vector3>(Hash.GET_ENTITY_ROTATION, (InputArgument) this.Handle, (InputArgument) 2);
      set => Function.Call(Hash.SET_ENTITY_ROTATION, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z, (InputArgument) 2, (InputArgument) 1);
    }

    public unsafe Quaternion Quaternion
    {
      get
      {
        float x;
        float y;
        float z;
        float w;
        Function.Call(Hash.GET_ENTITY_QUATERNION, (InputArgument) this.Handle, (InputArgument) (void*) &x, (InputArgument) (void*) &y, (InputArgument) (void*) &z, (InputArgument) (void*) &w);
        return new Quaternion(x, y, z, w);
      }
      set => Function.Call(Hash.SET_ENTITY_QUATERNION, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z, (InputArgument) value.W);
    }

    public float Heading
    {
      get => Function.Call<float>(Hash.GET_ENTITY_HEADING, (InputArgument) this.Handle);
      set
      {
        double num = (double) Function.Call<float>(Hash.SET_ENTITY_HEADING, (InputArgument) this.Handle, (InputArgument) value);
      }
    }

    public Vector3 UpVector => this.MemoryAddress == IntPtr.Zero ? Vector3.RelativeTop : MemoryAccess.ReadVector3(this.MemoryAddress + 128);

    public Vector3 RightVector => this.MemoryAddress == IntPtr.Zero ? Vector3.RelativeRight : MemoryAccess.ReadVector3(this.MemoryAddress + 96);

    public Vector3 ForwardVector => this.MemoryAddress == IntPtr.Zero ? Vector3.RelativeFront : MemoryAccess.ReadVector3(this.MemoryAddress + 112);

    public Vector3 LeftPosition
    {
      get
      {
        Vector3 minimum;
        this.Model.GetDimensions(out minimum, out Vector3 _);
        return this.GetOffsetPosition(new Vector3(minimum.X, 0.0f, 0.0f));
      }
    }

    public Vector3 RightPosition
    {
      get
      {
        Vector3 maximum;
        this.Model.GetDimensions(out Vector3 _, out maximum);
        return this.GetOffsetPosition(new Vector3(maximum.X, 0.0f, 0.0f));
      }
    }

    public Vector3 FrontPosition
    {
      get
      {
        Vector3 maximum;
        this.Model.GetDimensions(out Vector3 _, out maximum);
        return this.GetOffsetPosition(new Vector3(0.0f, maximum.Y, 0.0f));
      }
    }

    public Vector3 RearPosition
    {
      get
      {
        Vector3 minimum;
        this.Model.GetDimensions(out minimum, out Vector3 _);
        return this.GetOffsetPosition(new Vector3(0.0f, minimum.Y, 0.0f));
      }
    }

    public Vector3 AbovePosition
    {
      get
      {
        Vector3 maximum;
        this.Model.GetDimensions(out Vector3 _, out maximum);
        return this.GetOffsetPosition(new Vector3(0.0f, 0.0f, maximum.Z));
      }
    }

    public Vector3 BelowPosition
    {
      get
      {
        Vector3 minimum;
        this.Model.GetDimensions(out minimum, out Vector3 _);
        return this.GetOffsetPosition(new Vector3(0.0f, 0.0f, minimum.Z));
      }
    }

    public Matrix Matrix
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        return memoryAddress == IntPtr.Zero ? new Matrix() : MemoryAccess.ReadMatrix(memoryAddress + 96);
      }
    }

    public bool IsPositionFrozen
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 46, 1);
      set => Function.Call(Hash.FREEZE_ENTITY_POSITION, (InputArgument) this.Handle, (InputArgument) value);
    }

    public Vector3 Velocity
    {
      get => Function.Call<Vector3>(Hash.GET_ENTITY_VELOCITY, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_ENTITY_VELOCITY, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z);
    }

    public Vector3 RotationVelocity => Function.Call<Vector3>(Hash.GET_ENTITY_ROTATION_VELOCITY, (InputArgument) this.Handle);

    public float Speed
    {
      get => Function.Call<float>(Hash.GET_ENTITY_SPEED, (InputArgument) this.Handle);
      set => this.Velocity = this.Velocity.Normalized * value;
    }

    public float MaxSpeed
    {
      set => Function.Call(Hash.SET_ENTITY_MAX_SPEED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool HasGravity
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return true;
        IntPtr num = MemoryAccess.ReadPtr(memoryAddress + 48);
        return num == IntPtr.Zero || !MemoryAccess.IsBitSet(num + 26, 4);
      }
      set => Function.Call(Hash.SET_ENTITY_HAS_GRAVITY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float HeightAboveGround => Function.Call<float>(Hash.GET_ENTITY_HEIGHT_ABOVE_GROUND, (InputArgument) this.Handle);

    public float SubmersionLevel => Function.Call<float>(Hash.GET_ENTITY_SUBMERGED_LEVEL, (InputArgument) this.Handle);

    public int LodDistance
    {
      get => Function.Call<int>(Hash.GET_ENTITY_LOD_DIST, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_ENTITY_LOD_DIST, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsVisible
    {
      get => Function.Call<bool>(Hash.IS_ENTITY_VISIBLE, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_ENTITY_VISIBLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsOccluded => Function.Call<bool>(Hash.IS_ENTITY_OCCLUDED, (InputArgument) this.Handle);

    public bool IsOnScreen => Function.Call<bool>(Hash.IS_ENTITY_ON_SCREEN, (InputArgument) this.Handle);

    public bool IsRendered => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 176, 4);

    public bool IsUpright => Function.Call<bool>(Hash.IS_ENTITY_UPRIGHT, (InputArgument) this.Handle, (InputArgument) 30f);

    public bool IsUpsideDown => Function.Call<bool>(Hash.IS_ENTITY_UPSIDEDOWN, (InputArgument) this.Handle);

    public bool IsInAir => Function.Call<bool>(Hash.IS_ENTITY_IN_AIR, (InputArgument) this.Handle);

    public bool IsInWater => Function.Call<bool>(Hash.IS_ENTITY_IN_WATER, (InputArgument) this.Handle);

    public bool IsPersistent
    {
      get => Function.Call<bool>(Hash.IS_ENTITY_A_MISSION_ENTITY, (InputArgument) this.Handle);
      set
      {
        if (value)
          Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, (InputArgument) this.Handle, (InputArgument) true, (InputArgument) false);
        else
          this.MarkAsNoLongerNeeded();
      }
    }

    public bool IsOnFire => Function.Call<bool>(Hash.IS_ENTITY_ON_FIRE, (InputArgument) this.Handle);

    public bool IsFireProof
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 5);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        IntPtr address = this.MemoryAddress + 392;
        if (value)
          MemoryAccess.SetBit(address, 5);
        else
          MemoryAccess.ClearBit(address, 5);
      }
    }

    public bool IsMeleeProof
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 7);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        IntPtr address = this.MemoryAddress + 392;
        if (value)
          MemoryAccess.SetBit(address, 7);
        else
          MemoryAccess.ClearBit(address, 7);
      }
    }

    public bool IsBulletProof
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 4);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        IntPtr address = this.MemoryAddress + 392;
        if (value)
          MemoryAccess.SetBit(address, 4);
        else
          MemoryAccess.ClearBit(address, 4);
      }
    }

    public bool IsExplosionProof
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 11);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        IntPtr address = this.MemoryAddress + 392;
        if (value)
          MemoryAccess.SetBit(address, 11);
        else
          MemoryAccess.ClearBit(address, 11);
      }
    }

    public bool IsCollisionProof
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 6);
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        IntPtr address = this.MemoryAddress + 392;
        if (value)
          MemoryAccess.SetBit(address, 6);
        else
          MemoryAccess.ClearBit(address, 6);
      }
    }

    public bool IsInvincible
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 8);
      set => Function.Call(Hash.SET_ENTITY_INVINCIBLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsOnlyDamagedByPlayer
    {
      get => !(this.MemoryAddress == IntPtr.Zero) && MemoryAccess.IsBitSet(this.MemoryAddress + 392, 9);
      set => Function.Call(Hash.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int Opacity
    {
      get => Function.Call<int>(Hash.GET_ENTITY_ALPHA, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_ENTITY_ALPHA, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) false);
    }

    public void ResetOpacity() => Function.Call(Hash.RESET_ENTITY_ALPHA, (InputArgument) this.Handle);

    public bool HasCollided => Function.Call<bool>(Hash.HAS_ENTITY_COLLIDED_WITH_ANYTHING, (InputArgument) this.Handle);

    public bool IsCollisionEnabled
    {
      get => !Function.Call<bool>(Hash._GET_ENTITY_COLLISON_DISABLED, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_ENTITY_COLLISION, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) false);
    }

    public bool IsRecordingCollisions
    {
      set => Function.Call(Hash.SET_ENTITY_RECORDS_COLLISIONS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void SetNoCollision(Entity entity, bool toggle) => Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) toggle);

    public bool HasBeenDamagedBy(Entity entity) => Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) 1);

    public virtual bool HasBeenDamagedBy(WeaponHash weapon) => Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) (Enum) weapon, (InputArgument) 0);

    public virtual bool HasBeenDamagedByAnyWeapon() => Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) 0, (InputArgument) 2);

    public virtual bool HasBeenDamagedByAnyMeleeWeapon() => Function.Call<bool>(Hash.HAS_ENTITY_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) 0, (InputArgument) 1);

    public virtual void ClearLastWeaponDamage() => Function.Call(Hash.CLEAR_ENTITY_LAST_WEAPON_DAMAGE, (InputArgument) this.Handle);

    public bool IsInArea(Vector3 minBounds, Vector3 maxBounds) => Function.Call<bool>(Hash.IS_ENTITY_IN_AREA, (InputArgument) this.Handle, (InputArgument) minBounds.X, (InputArgument) minBounds.Y, (InputArgument) minBounds.Z, (InputArgument) maxBounds.X, (InputArgument) maxBounds.Y, (InputArgument) maxBounds.Z);

    public bool IsInAngledArea(Vector3 origin, Vector3 edge, float angle) => Function.Call<bool>(Hash.IS_ENTITY_IN_ANGLED_AREA, (InputArgument) this.Handle, (InputArgument) origin.X, (InputArgument) origin.Y, (InputArgument) origin.Z, (InputArgument) edge.X, (InputArgument) edge.Y, (InputArgument) edge.Z, (InputArgument) angle, (InputArgument) false, (InputArgument) true, (InputArgument) false);

    public bool IsInRangeOf(Vector3 position, float range) => (double) Vector3.Subtract(this.Position, position).LengthSquared() < (double) range * (double) range;

    public bool IsNearEntity(Entity entity, Vector3 bounds) => Function.Call<bool>(Hash.IS_ENTITY_AT_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) bounds.X, (InputArgument) bounds.Y, (InputArgument) bounds.Z, (InputArgument) false, (InputArgument) true, (InputArgument) false);

    public bool IsTouching(Model model) => Function.Call<bool>(Hash.IS_ENTITY_TOUCHING_MODEL, (InputArgument) this.Handle, (InputArgument) model.Hash);

    public bool IsTouching(Entity entity) => Function.Call<bool>(Hash.IS_ENTITY_TOUCHING_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle);

    public Vector3 GetOffsetPosition(Vector3 offset) => Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, (InputArgument) this.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z);

    public Vector3 GetPositionOffset(Vector3 worldCoords) => Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_GIVEN_WORLD_COORDS, (InputArgument) this.Handle, (InputArgument) worldCoords.X, (InputArgument) worldCoords.Y, (InputArgument) worldCoords.Z);

    public virtual EntityBoneCollection Bones
    {
      get
      {
        if (this._bones == null)
          this._bones = new EntityBoneCollection(this);
        return this._bones;
      }
    }

    public Blip AttachBlip() => new Blip(Function.Call<int>(Hash.ADD_BLIP_FOR_ENTITY, (InputArgument) this.Handle));

    public Blip AttachedBlip
    {
      get
      {
        int handle = Function.Call<int>(Hash.GET_BLIP_FROM_ENTITY, (InputArgument) this.Handle);
        return Function.Call<bool>(Hash.DOES_BLIP_EXIST, (InputArgument) handle) ? new Blip(handle) : (Blip) null;
      }
    }

    public Blip[] AttachedBlips => ((IEnumerable<Blip>) World.GetAllBlips((BlipSprite[]) Array.Empty<BlipSprite>())).Where<Blip>((Func<Blip, bool>) (x => Function.Call<int>(Hash.GET_BLIP_INFO_ID_ENTITY_INDEX, (InputArgument) (INativeValue) x) == this.Handle)).ToArray<Blip>();

    public void AttachTo(Entity entity, Vector3 position = default (Vector3), Vector3 rotation = default (Vector3)) => Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) -1, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);

    public void AttachTo(EntityBone entityBone, Vector3 position = default (Vector3), Vector3 rotation = default (Vector3)) => Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) entityBone.Owner.Handle, (InputArgument) entityBone, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);

    public void Detach() => Function.Call(Hash.DETACH_ENTITY, (InputArgument) this.Handle, (InputArgument) true, (InputArgument) true);

    public bool IsAttached() => Function.Call<bool>(Hash.IS_ENTITY_ATTACHED, (InputArgument) this.Handle);

    public bool IsAttachedTo(Entity entity) => Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle);

    public Entity GetEntityAttachedTo() => Entity.FromHandle(Function.Call<int>(Hash.GET_ENTITY_ATTACHED_TO, (InputArgument) this.Handle));

    public void ApplyForce(Vector3 direction, Vector3 rotation = default (Vector3), ForceType forceType = ForceType.MaxForceRot2) => Function.Call(Hash.APPLY_FORCE_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) (Enum) forceType, (InputArgument) direction.X, (InputArgument) direction.Y, (InputArgument) direction.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) false, (InputArgument) false, (InputArgument) true, (InputArgument) true, (InputArgument) false, (InputArgument) true);

    public void ApplyForceRelative(Vector3 direction, Vector3 rotation = default (Vector3), ForceType forceType = ForceType.MaxForceRot2) => Function.Call(Hash.APPLY_FORCE_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) (Enum) forceType, (InputArgument) direction.X, (InputArgument) direction.Y, (InputArgument) direction.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) false, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) false, (InputArgument) true);

    public void RemoveAllParticleEffects() => Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument) this.Handle);

    public override unsafe void Delete()
    {
      Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, (InputArgument) this.Handle, (InputArgument) false, (InputArgument) true);
      int handle = this.Handle;
      Function.Call(Hash.DELETE_ENTITY, (InputArgument) (void*) &handle);
      this.Handle = handle;
    }

    public unsafe void MarkAsNoLongerNeeded()
    {
      Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, (InputArgument) this.Handle, (InputArgument) false, (InputArgument) true);
      int handle = this.Handle;
      Function.Call(Hash.SET_ENTITY_AS_NO_LONGER_NEEDED, (InputArgument) (void*) &handle);
      this.Handle = handle;
    }

    public static Entity FromHandle(int handle)
    {
      switch (Function.Call<int>(Hash.GET_ENTITY_TYPE, (InputArgument) handle))
      {
        case 1:
          return (Entity) new Ped(handle);
        case 2:
          return (Entity) new Vehicle(handle);
        case 3:
          return (Entity) new Prop(handle);
        default:
          return (Entity) null;
      }
    }

    public override bool Exists() => Function.Call<bool>(Hash.DOES_ENTITY_EXIST, (InputArgument) this.Handle);

    public static bool Exists(Entity entity) => (object) entity != null && entity.Exists();

    public bool Equals(Entity entity) => (object) entity != null && this.Handle == entity.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Entity) obj);

    public override int GetHashCode() => this.Handle.GetHashCode();

    public static bool operator ==(Entity left, Entity right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Entity left, Entity right) => !(left == right);
  }
}
