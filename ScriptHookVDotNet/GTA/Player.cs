// Decompiled with JetBrains decompiler
// Type: GTA.Player
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA
{
  public sealed class Player : INativeValue, IEquatable<Player>
  {
    private int _handle;
    private Ped _ped;

    public Player(int handle) => this._handle = handle;

    public int Handle => this._handle;

    public ulong NativeValue
    {
      get => (ulong) this._handle;
      set => this._handle = (int) value;
    }

    public Ped Character
    {
      get
      {
        int handle = Function.Call<int>(Hash.GET_PLAYER_PED, (InputArgument) this.Handle);
        if (this._ped == null || handle != this._ped.Handle)
          this._ped = new Ped(handle);
        return this._ped;
      }
    }

    public string Name => Function.Call<string>(Hash.GET_PLAYER_NAME, (InputArgument) this.Handle);

    public unsafe int Money
    {
      get
      {
        int hash;
        switch ((PedHash) this.Character.Model.Hash)
        {
          case PedHash.Michael:
            hash = Game.GenerateHash("SP0_TOTAL_CASH");
            break;
          case PedHash.Franklin:
            hash = Game.GenerateHash("SP1_TOTAL_CASH");
            break;
          case PedHash.Trevor:
            hash = Game.GenerateHash("SP2_TOTAL_CASH");
            break;
          default:
            return 0;
        }
        int num;
        Function.Call(Hash.STAT_GET_INT, (InputArgument) hash, (InputArgument) (void*) &num, (InputArgument) -1);
        return num;
      }
      set
      {
        int hash;
        switch ((PedHash) this.Character.Model.Hash)
        {
          case PedHash.Michael:
            hash = Game.GenerateHash("SP0_TOTAL_CASH");
            break;
          case PedHash.Franklin:
            hash = Game.GenerateHash("SP1_TOTAL_CASH");
            break;
          case PedHash.Trevor:
            hash = Game.GenerateHash("SP2_TOTAL_CASH");
            break;
          default:
            return;
        }
        Function.Call(Hash.STAT_SET_INT, (InputArgument) hash, (InputArgument) value, (InputArgument) 1);
      }
    }

    public int WantedLevel
    {
      get => Function.Call<int>(Hash.GET_PLAYER_WANTED_LEVEL, (InputArgument) this.Handle);
      set
      {
        Function.Call(Hash.SET_PLAYER_WANTED_LEVEL, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) false);
        Function.Call(Hash.SET_PLAYER_WANTED_LEVEL_NOW, (InputArgument) this.Handle, (InputArgument) false);
      }
    }

    public Vector3 WantedCenterPosition
    {
      get => Function.Call<Vector3>(Hash.GET_PLAYER_WANTED_CENTRE_POSITION, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PLAYER_WANTED_CENTRE_POSITION, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z);
    }

    public int MaxArmor
    {
      get => Function.Call<int>(Hash.GET_PLAYER_MAX_ARMOUR, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PLAYER_MAX_ARMOUR, (InputArgument) this.Handle, (InputArgument) value);
    }

    public unsafe ParachuteTint PrimaryParachuteTint
    {
      get
      {
        int num;
        Function.Call(Hash.GET_PLAYER_PARACHUTE_TINT_INDEX, (InputArgument) this.Handle, (InputArgument) (void*) &num);
        return (ParachuteTint) num;
      }
      set => Function.Call(Hash.SET_PLAYER_PARACHUTE_TINT_INDEX, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public unsafe ParachuteTint ReserveParachuteTint
    {
      get
      {
        int num;
        Function.Call(Hash.GET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX, (InputArgument) this.Handle, (InputArgument) (void*) &num);
        return (ParachuteTint) num;
      }
      set => Function.Call(Hash.SET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public bool CanLeaveParachuteSmokeTrail
    {
      set => Function.Call(Hash.SET_PLAYER_CAN_LEAVE_PARACHUTE_SMOKE_TRAIL, (InputArgument) this.Handle, (InputArgument) value);
    }

    public unsafe Color ParachuteSmokeTrailColor
    {
      get
      {
        int red;
        int green;
        int blue;
        Function.Call(Hash.GET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR, (InputArgument) this.Handle, (InputArgument) (void*) &red, (InputArgument) (void*) &green, (InputArgument) (void*) &blue);
        return Color.FromArgb(red, green, blue);
      }
      set => Function.Call(Hash.SET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR, (InputArgument) this.Handle, (InputArgument) value.R, (InputArgument) value.G, (InputArgument) value.B);
    }

    public bool IsAlive => !this.IsDead;

    public bool IsDead => Function.Call<bool>(Hash.IS_PLAYER_DEAD, (InputArgument) this.Handle);

    public bool IsAiming => Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument) this.Handle);

    public bool IsClimbing => Function.Call<bool>(Hash.IS_PLAYER_CLIMBING, (InputArgument) this.Handle);

    public bool IsRidingTrain => Function.Call<bool>(Hash.IS_PLAYER_RIDING_TRAIN, (InputArgument) this.Handle);

    public bool IsPressingHorn => Function.Call<bool>(Hash.IS_PLAYER_PRESSING_HORN, (InputArgument) this.Handle);

    public bool IsPlaying => Function.Call<bool>(Hash.IS_PLAYER_PLAYING, (InputArgument) this.Handle);

    public bool IsInvincible
    {
      get => Function.Call<bool>(Hash.GET_PLAYER_INVINCIBLE, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PLAYER_INVINCIBLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IgnoredByPolice
    {
      set => Function.Call(Hash.SET_POLICE_IGNORE_PLAYER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IgnoredByEveryone
    {
      set => Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool DispatchsCops
    {
      set => Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanUseCover
    {
      set => Function.Call(Hash.SET_PLAYER_CAN_USE_COVER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanStartMission => Function.Call<bool>(Hash.CAN_PLAYER_START_MISSION, (InputArgument) this.Handle);

    public bool CanControlRagdoll
    {
      set => Function.Call(Hash.GIVE_PLAYER_RAGDOLL_CONTROL, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanControlCharacter
    {
      get => Function.Call<bool>(Hash.IS_PLAYER_CONTROL_ON, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PLAYER_CONTROL, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) 0);
    }

    public bool ChangeModel(Model model)
    {
      if (!model.IsInCdImage || !model.IsPed || !model.Request(1000))
        return false;
      Function.Call(Hash.SET_PLAYER_MODEL, (InputArgument) this.Handle, (InputArgument) model.Hash);
      model.MarkAsNoLongerNeeded();
      return true;
    }

    public float RemainingSprintTime => Function.Call<float>(Hash.GET_PLAYER_SPRINT_TIME_REMAINING, (InputArgument) this.Handle);

    public float RemainingSprintStamina => Function.Call<float>(Hash.GET_PLAYER_SPRINT_STAMINA_REMAINING, (InputArgument) this.Handle);

    public float RemainingUnderwaterTime => Function.Call<float>(Hash.GET_PLAYER_UNDERWATER_TIME_REMAINING, (InputArgument) this.Handle);

    public bool IsSpecialAbilityActive => Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_ACTIVE, (InputArgument) this.Handle);

    public bool IsSpecialAbilityEnabled
    {
      get => Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_ENABLED, (InputArgument) this.Handle);
      set => Function.Call(Hash.ENABLE_SPECIAL_ABILITY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void ChargeSpecialAbility(int absoluteAmount) => Function.Call(Hash.SPECIAL_ABILITY_CHARGE_ABSOLUTE, (InputArgument) this.Handle, (InputArgument) absoluteAmount, (InputArgument) true);

    public void ChargeSpecialAbility(float normalizedRatio) => Function.Call(Hash.SPECIAL_ABILITY_CHARGE_NORMALIZED, (InputArgument) this.Handle, (InputArgument) normalizedRatio, (InputArgument) true);

    public void RefillSpecialAbility() => Function.Call(Hash.SPECIAL_ABILITY_FILL_METER, (InputArgument) this.Handle, (InputArgument) 1);

    public void DepleteSpecialAbility() => Function.Call(Hash.SPECIAL_ABILITY_DEPLETE_METER, (InputArgument) this.Handle, (InputArgument) 1);

    public Vehicle LastVehicle
    {
      get
      {
        Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_PLAYERS_LAST_VEHICLE, (InputArgument[]) Array.Empty<InputArgument>()));
        return !vehicle.Exists() ? (Vehicle) null : vehicle;
      }
    }

    public bool IsTargetting(Entity entity) => Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING_AT_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle);

    public bool IsTargettingAnything => Function.Call<bool>(Hash.IS_PLAYER_TARGETTING_ANYTHING, (InputArgument) this.Handle);

    public unsafe Entity GetTargetedEntity()
    {
      int handle;
      return Function.Call<bool>(Hash.GET_ENTITY_PLAYER_IS_FREE_AIMING_AT, (InputArgument) this.Handle, (InputArgument) (void*) &handle) ? Entity.FromHandle(handle) : (Entity) null;
    }

    public bool ForcedAim
    {
      set => Function.Call(Hash.SET_PLAYER_FORCED_AIM, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void DisableFiringThisFrame() => Function.Call(Hash.DISABLE_PLAYER_FIRING, (InputArgument) this.Handle, (InputArgument) 0);

    public void SetRunSpeedMultThisFrame(float mult)
    {
      if ((double) mult > 1.49899995326996)
        mult = 1.499f;
      Function.Call(Hash.SET_RUN_SPRINT_MULTIPLIER_FOR_PLAYER, (InputArgument) this.Handle, (InputArgument) mult);
    }

    public void SetSwimSpeedMultThisFrame(float mult)
    {
      if ((double) mult > 1.49899995326996)
        mult = 1.499f;
      Function.Call(Hash.SET_SWIM_MULTIPLIER_FOR_PLAYER, (InputArgument) this.Handle, (InputArgument) mult);
    }

    public void SetFireAmmoThisFrame() => Function.Call(Hash.SET_FIRE_AMMO_THIS_FRAME, (InputArgument) this.Handle);

    public void SetExplosiveAmmoThisFrame() => Function.Call(Hash.SET_EXPLOSIVE_AMMO_THIS_FRAME, (InputArgument) this.Handle);

    public void SetExplosiveMeleeThisFrame() => Function.Call(Hash.SET_EXPLOSIVE_MELEE_THIS_FRAME, (InputArgument) this.Handle);

    public void SetSuperJumpThisFrame() => Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, (InputArgument) this.Handle);

    public void SetMayNotEnterAnyVehicleThisFrame() => Function.Call(Hash.SET_PLAYER_MAY_NOT_ENTER_ANY_VEHICLE, (InputArgument) this.Handle);

    public void SetMayOnlyEnterThisVehicleThisFrame(Vehicle vehicle) => Function.Call(Hash.SET_PLAYER_MAY_ONLY_ENTER_THIS_VEHICLE, (InputArgument) this.Handle, (InputArgument) vehicle.Handle);

    public bool Equals(Player player) => (object) player != null && this.Handle == player.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((object) (Entity) obj);

    public override int GetHashCode() => this.Handle.GetHashCode();

    public static bool operator ==(Player left, Player right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Player left, Player right) => !(left == right);
  }
}
