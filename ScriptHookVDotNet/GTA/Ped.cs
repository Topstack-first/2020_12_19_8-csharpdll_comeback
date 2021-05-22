// Decompiled with JetBrains decompiler
// Type: GTA.Ped
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using GTA.NaturalMotion;
using System;

namespace GTA
{
  public sealed class Ped : Entity
  {
    private Tasks _tasks;
    private Euphoria _euphoria;
    private WeaponCollection _weapons;
    private Style _style;
    private PedBoneCollection _pedBones;
    internal static readonly string[] _speechModifierNames = new string[37]
    {
      "SPEECH_PARAMS_STANDARD",
      "SPEECH_PARAMS_ALLOW_REPEAT",
      "SPEECH_PARAMS_BEAT",
      "SPEECH_PARAMS_FORCE",
      "SPEECH_PARAMS_FORCE_FRONTEND",
      "SPEECH_PARAMS_FORCE_NO_REPEAT_FRONTEND",
      "SPEECH_PARAMS_FORCE_NORMAL",
      "SPEECH_PARAMS_FORCE_NORMAL_CLEAR",
      "SPEECH_PARAMS_FORCE_NORMAL_CRITICAL",
      "SPEECH_PARAMS_FORCE_SHOUTED",
      "SPEECH_PARAMS_FORCE_SHOUTED_CLEAR",
      "SPEECH_PARAMS_FORCE_SHOUTED_CRITICAL",
      "SPEECH_PARAMS_FORCE_PRELOAD_ONLY",
      "SPEECH_PARAMS_MEGAPHONE",
      "SPEECH_PARAMS_HELI",
      "SPEECH_PARAMS_FORCE_MEGAPHONE",
      "SPEECH_PARAMS_FORCE_HELI",
      "SPEECH_PARAMS_INTERRUPT",
      "SPEECH_PARAMS_INTERRUPT_SHOUTED",
      "SPEECH_PARAMS_INTERRUPT_SHOUTED_CLEAR",
      "SPEECH_PARAMS_INTERRUPT_SHOUTED_CRITICAL",
      "SPEECH_PARAMS_INTERRUPT_NO_FORCE",
      "SPEECH_PARAMS_INTERRUPT_FRONTEND",
      "SPEECH_PARAMS_INTERRUPT_NO_FORCE_FRONTEND",
      "SPEECH_PARAMS_ADD_BLIP",
      "SPEECH_PARAMS_ADD_BLIP_ALLOW_REPEAT",
      "SPEECH_PARAMS_ADD_BLIP_FORCE",
      "SPEECH_PARAMS_ADD_BLIP_SHOUTED",
      "SPEECH_PARAMS_ADD_BLIP_SHOUTED_FORCE",
      "SPEECH_PARAMS_ADD_BLIP_INTERRUPT",
      "SPEECH_PARAMS_ADD_BLIP_INTERRUPT_FORCE",
      "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED",
      "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CLEAR",
      "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CRITICAL",
      "SPEECH_PARAMS_SHOUTED",
      "SPEECH_PARAMS_SHOUTED_CLEAR",
      "SPEECH_PARAMS_SHOUTED_CRITICAL"
    };

    public Ped(int handle)
      : base(handle)
    {
    }

    public int Money
    {
      get => Function.Call<int>(Hash.GET_PED_MONEY, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PED_MONEY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public Gender Gender => !Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument) this.Handle) ? Gender.Female : Gender.Male;

    public int Armor
    {
      get => Function.Call<int>(Hash.GET_PED_ARMOUR, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PED_ARMOUR, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float ArmorFloat
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5236 : 5220;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5280 : num1;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5296 : num2));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5236 : 5220;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5280 : num1;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5296 : num2), value);
      }
    }

    public int Accuracy
    {
      get => Function.Call<int>(Hash.GET_PED_ACCURACY, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PED_ACCURACY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public Tasks Task
    {
      get
      {
        if (this._tasks == null)
          this._tasks = new Tasks(this);
        return this._tasks;
      }
    }

    public int TaskSequenceProgress => Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, (InputArgument) this.Handle);

    public Euphoria Euphoria
    {
      get
      {
        if (this._euphoria == null)
          this._euphoria = new Euphoria(this);
        return this._euphoria;
      }
    }

    public WeaponCollection Weapons
    {
      get
      {
        if (this._weapons == null)
          this._weapons = new WeaponCollection(this);
        return this._weapons;
      }
    }

    public Style Style
    {
      get
      {
        if (this._style == null)
          this._style = new Style(this);
        return this._style;
      }
    }

    public VehicleWeaponHash VehicleWeapon
    {
      get
      {
        OutputArgument outputArgument = new OutputArgument();
        return Function.Call<bool>(Hash.GET_CURRENT_PED_VEHICLE_WEAPON, (InputArgument) this.Handle, (InputArgument) outputArgument) ? outputArgument.GetResult<VehicleWeaponHash>() : VehicleWeaponHash.Invalid;
      }
    }

    public Vehicle LastVehicle
    {
      get
      {
        Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_IN, (InputArgument) this.Handle, (InputArgument) true));
        return !vehicle.Exists() ? (Vehicle) null : vehicle;
      }
    }

    public Vehicle CurrentVehicle
    {
      get
      {
        Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_IN, (InputArgument) this.Handle, (InputArgument) false));
        return !vehicle.Exists() ? (Vehicle) null : vehicle;
      }
    }

    public Vehicle VehicleTryingToEnter
    {
      get
      {
        Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_TRYING_TO_ENTER, (InputArgument) this.Handle));
        return !vehicle.Exists() ? (Vehicle) null : vehicle;
      }
    }

    public PedGroup PedGroup
    {
      get
      {
        if (!this.IsInGroup)
          return (PedGroup) null;
        return new PedGroup(Function.Call<int>(Hash.GET_PED_GROUP_INDEX, (InputArgument) this.Handle, (InputArgument) false));
      }
    }

    public float Sweat
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num = Game.Version >= GameVersion.v1_0_877_1_Steam ? 4512 : 4464;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 4528 : num));
      }
      set
      {
        if ((double) value < 0.0)
          value = 0.0f;
        if ((double) value > 100.0)
          value = 100f;
        Function.Call(Hash.SET_PED_SWEAT, (InputArgument) this.Handle, (InputArgument) value);
      }
    }

    public float WetnessHeight
    {
      set
      {
        if ((double) value == 0.0)
        {
          Function.Call(Hash.CLEAR_PED_WETNESS, (InputArgument) this.Handle);
        }
        else
        {
          double num = (double) Function.Call<float>(Hash.SET_PED_WETNESS_HEIGHT, (InputArgument) this.Handle, (InputArgument) value);
        }
      }
    }

    public string Voice
    {
      set => Function.Call(Hash.SET_AMBIENT_VOICE_NAME, (InputArgument) this.Handle, (InputArgument) value);
    }

    public int ShootRate
    {
      set => Function.Call(Hash.SET_PED_SHOOT_RATE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool WasKilledByStealth => Function.Call<bool>(Hash.WAS_PED_KILLED_BY_STEALTH, (InputArgument) this.Handle);

    public bool WasKilledByTakedown => Function.Call<bool>(Hash.WAS_PED_KILLED_BY_TAKEDOWN, (InputArgument) this.Handle);

    public VehicleSeat SeatIndex
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return VehicleSeat.None;
        int num1 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5514 : 5442;
        int num2 = (int) MemoryAccess.ReadSByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5530 : num1));
        return num2 == -1 || !this.IsInVehicle() ? VehicleSeat.None : (VehicleSeat) (num2 - 1);
      }
    }

    public bool IsJumpingOutOfVehicle => Function.Call<bool>(Hash.IS_PED_JUMPING_OUT_OF_VEHICLE, (InputArgument) this.Handle);

    public bool StaysInVehicleWhenJacked
    {
      set => Function.Call(Hash.SET_PED_STAY_IN_VEHICLE_WHEN_JACKED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float MaxDrivingSpeed
    {
      set => Function.Call(Hash.SET_DRIVE_TASK_MAX_CRUISE_SPEED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float InjuryHealthThreshold
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5248 : 5232;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5320 : num1;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5336 : num2));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5248 : 5232;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5320 : num1;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5336 : num2), value);
      }
    }

    public float FatalInjuryHealthThreshold
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return 0.0f;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5252 : 5236;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5324 : num1;
        return MemoryAccess.ReadFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5340 : num2));
      }
      set
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5252 : 5236;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5324 : num1;
        MemoryAccess.WriteFloat(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5340 : num2), value);
      }
    }

    public bool IsHuman => Function.Call<bool>(Hash.IS_PED_HUMAN, (InputArgument) this.Handle);

    public bool IsEnemy
    {
      set => Function.Call(Hash.SET_PED_AS_ENEMY, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsPriorityTargetForEnemies
    {
      set => Function.Call(Hash.SET_ENTITY_IS_TARGET_PRIORITY, (InputArgument) this.Handle, (InputArgument) value, (InputArgument) 0);
    }

    public bool IsPlayer => Function.Call<bool>(Hash.IS_PED_A_PLAYER, (InputArgument) this.Handle);

    public bool IsCuffed => Function.Call<bool>(Hash.IS_PED_CUFFED, (InputArgument) this.Handle);

    public bool IsWearingHelmet => Function.Call<bool>(Hash.IS_PED_WEARING_HELMET, (InputArgument) this.Handle);

    public bool IsRagdoll => Function.Call<bool>(Hash.IS_PED_RAGDOLL, (InputArgument) this.Handle);

    public bool IsIdle
    {
      get
      {
        if (this.IsInjured || this.IsRagdoll || (this.IsInAir || this.IsOnFire) || (this.IsDucking || this.IsGettingIntoAVehicle || (this.IsInCombat || this.IsInMeleeCombat)))
          return false;
        return !this.IsInVehicle() || this.IsSittingInVehicle();
      }
    }

    public bool IsProne => Function.Call<bool>(Hash.IS_PED_PRONE, (InputArgument) this.Handle);

    public bool IsDucking
    {
      get => Function.Call<bool>(Hash.IS_PED_DUCKING, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PED_DUCKING, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsGettingUp => Function.Call<bool>(Hash.IS_PED_GETTING_UP, (InputArgument) this.Handle);

    public bool IsClimbing => Function.Call<bool>(Hash.IS_PED_CLIMBING, (InputArgument) this.Handle);

    public bool IsJumping => Function.Call<bool>(Hash.IS_PED_JUMPING, (InputArgument) this.Handle);

    public bool IsFalling => Function.Call<bool>(Hash.IS_PED_FALLING, (InputArgument) this.Handle);

    public bool IsStopped => Function.Call<bool>(Hash.IS_PED_STOPPED, (InputArgument) this.Handle);

    public bool IsWalking => Function.Call<bool>(Hash.IS_PED_WALKING, (InputArgument) this.Handle);

    public bool IsRunning => Function.Call<bool>(Hash.IS_PED_RUNNING, (InputArgument) this.Handle);

    public bool IsSprinting => Function.Call<bool>(Hash.IS_PED_SPRINTING, (InputArgument) this.Handle);

    public bool IsDiving => Function.Call<bool>(Hash.IS_PED_DIVING, (InputArgument) this.Handle);

    public bool IsInParachuteFreeFall => Function.Call<bool>(Hash.IS_PED_IN_PARACHUTE_FREE_FALL, (InputArgument) this.Handle);

    public bool IsSwimming => Function.Call<bool>(Hash.IS_PED_SWIMMING, (InputArgument) this.Handle);

    public bool IsSwimmingUnderWater => Function.Call<bool>(Hash.IS_PED_SWIMMING_UNDER_WATER, (InputArgument) this.Handle);

    public bool IsVaulting => Function.Call<bool>(Hash.IS_PED_VAULTING, (InputArgument) this.Handle);

    public bool IsOnBike => Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument) this.Handle);

    public bool IsOnFoot => Function.Call<bool>(Hash.IS_PED_ON_FOOT, (InputArgument) this.Handle);

    public bool IsInSub => Function.Call<bool>(Hash.IS_PED_IN_ANY_SUB, (InputArgument) this.Handle);

    public bool IsInTaxi => Function.Call<bool>(Hash.IS_PED_IN_ANY_TAXI, (InputArgument) this.Handle);

    public bool IsInTrain => Function.Call<bool>(Hash.IS_PED_IN_ANY_TRAIN, (InputArgument) this.Handle);

    public bool IsInHeli => Function.Call<bool>(Hash.IS_PED_IN_ANY_HELI, (InputArgument) this.Handle);

    public bool IsInPlane => Function.Call<bool>(Hash.IS_PED_IN_ANY_PLANE, (InputArgument) this.Handle);

    public bool IsInFlyingVehicle => Function.Call<bool>(Hash.IS_PED_IN_FLYING_VEHICLE, (InputArgument) this.Handle);

    public bool IsInBoat => Function.Call<bool>(Hash.IS_PED_IN_ANY_BOAT, (InputArgument) this.Handle);

    public bool IsInPoliceVehicle => Function.Call<bool>(Hash.IS_PED_IN_ANY_POLICE_VEHICLE, (InputArgument) this.Handle);

    public bool IsJacking => Function.Call<bool>(Hash.IS_PED_JACKING, (InputArgument) this.Handle);

    public bool IsBeingJacked => Function.Call<bool>(Hash.IS_PED_BEING_JACKED, (InputArgument) this.Handle);

    public bool IsGettingIntoAVehicle => Function.Call<bool>(Hash.IS_PED_GETTING_INTO_A_VEHICLE, (InputArgument) this.Handle);

    public bool IsTryingToEnterALockedVehicle => Function.Call<bool>(Hash.IS_PED_TRYING_TO_ENTER_A_LOCKED_VEHICLE, (InputArgument) this.Handle);

    public bool IsInjured => Function.Call<bool>(Hash.IS_PED_INJURED, (InputArgument) this.Handle);

    public bool IsFleeing => Function.Call<bool>(Hash.IS_PED_FLEEING, (InputArgument) this.Handle);

    public bool IsInCombat => Function.Call<bool>(Hash.IS_PED_IN_COMBAT, (InputArgument) this.Handle);

    public bool IsInMeleeCombat => Function.Call<bool>(Hash.IS_PED_IN_MELEE_COMBAT, (InputArgument) this.Handle);

    public bool IsInStealthMode => Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, (InputArgument) this.Handle);

    public bool IsAmbientSpeechplaying => Function.Call<bool>(Hash.IS_AMBIENT_SPEECH_PLAYING, (InputArgument) this.Handle);

    public bool IsScriptedSpeechplaying => Function.Call<bool>(Hash.IS_SCRIPTED_SPEECH_PLAYING, (InputArgument) this.Handle);

    public bool IsAnySpeechplaying => Function.Call<bool>(Hash.IS_ANY_SPEECH_PLAYING, (InputArgument) this.Handle);

    public bool IsAmbientSpeechEnabled => !Function.Call<bool>(Hash.IS_AMBIENT_SPEECH_DISABLED, (InputArgument) this.Handle);

    public bool IsPainAudioEnabled
    {
      set => Function.Call(Hash.DISABLE_PED_PAIN_AUDIO, (InputArgument) this.Handle, (InputArgument) !value);
    }

    public bool IsPlantingBomb => Function.Call<bool>(Hash.IS_PED_PLANTING_BOMB, (InputArgument) this.Handle);

    public bool IsShooting => Function.Call<bool>(Hash.IS_PED_SHOOTING, (InputArgument) this.Handle);

    public bool IsAiming => this.GetConfigFlag(78);

    public bool IsReloading => Function.Call<bool>(Hash.IS_PED_RELOADING, (InputArgument) this.Handle);

    public bool IsDoingDriveBy => Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument) this.Handle);

    public bool IsGoingIntoCover => Function.Call<bool>(Hash.IS_PED_GOING_INTO_COVER, (InputArgument) this.Handle);

    public bool IsBeingStunned => Function.Call<bool>(Hash.IS_PED_BEING_STUNNED, (InputArgument) this.Handle);

    public bool IsBeingStealthKilled => Function.Call<bool>(Hash.IS_PED_BEING_STEALTH_KILLED, (InputArgument) this.Handle);

    public bool IsPerformingStealthKill => Function.Call<bool>(Hash.IS_PED_PERFORMING_STEALTH_KILL, (InputArgument) this.Handle);

    public bool IsAimingFromCover => Function.Call<bool>(Hash.IS_PED_AIMING_FROM_COVER, (InputArgument) this.Handle);

    public Vector3 GetBoneCoord(Bone boneID) => this.GetBoneCoord(boneID, Vector3.Zero);

    public Vector3 GetBoneCoord(Bone boneID, Vector3 offset) => Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument) this.Handle, (InputArgument) (Enum) boneID, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z);

    public bool IsInCover() => this.IsInCover(false);

    public bool IsInCover(bool expectUseWeapon) => Function.Call<bool>(Hash.IS_PED_IN_COVER, (InputArgument) this.Handle, (InputArgument) expectUseWeapon);

    public bool IsInCoverFacingLeft => Function.Call<bool>(Hash.IS_PED_IN_COVER_FACING_LEFT, (InputArgument) this.Handle);

    public string MovementAnimationSet
    {
      set
      {
        if (value == null)
        {
          Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, (InputArgument) 0.25f);
          this.Task.ClearAll();
        }
        else
        {
          if (Function.Call<bool>(Hash.DOES_ANIM_DICT_EXIST, (InputArgument) value))
          {
            Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument) value);
            DateTime dateTime = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 1000);
            do
            {
              if (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, (InputArgument) value))
                Script.Yield();
              else
                goto label_11;
            }
            while (!(DateTime.UtcNow >= dateTime));
            return;
          }
          Function.Call(Hash.REQUEST_ANIM_SET, (InputArgument) value);
          DateTime dateTime1 = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 1000);
          do
          {
            if (!Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, (InputArgument) value))
              Script.Yield();
            else
              goto label_11;
          }
          while (!(DateTime.UtcNow >= dateTime1));
          return;
label_11:
          Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, (InputArgument) value, (InputArgument) 0.25f);
        }
      }
    }

    public FiringPattern FiringPattern
    {
      set => Function.Call(Hash.SET_PED_FIRING_PATTERN, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public ParachuteLandingType ParachuteLandingType => Function.Call<ParachuteLandingType>(Hash.GET_PED_PARACHUTE_LANDING_TYPE, (InputArgument) this.Handle);

    public ParachuteState ParachuteState => Function.Call<ParachuteState>(Hash.GET_PED_PARACHUTE_STATE, (InputArgument) this.Handle);

    public bool DropsWeaponsOnDeath
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5093 : 5053;
        return ((int) MemoryAccess.ReadByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5109 : num)) & 64) == 0;
      }
      set => Function.Call(Hash.SET_PED_DROPS_WEAPONS_WHEN_DEAD, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float DrivingSpeed
    {
      set => Function.Call(Hash.SET_DRIVE_TASK_CRUISE_SPEED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public DrivingStyle DrivingStyle
    {
      set => Function.Call(Hash.SET_DRIVE_TASK_DRIVING_STYLE, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public VehicleDrivingFlags VehicleDrivingFlags
    {
      set => Function.Call(Hash.SET_DRIVE_TASK_DRIVING_STYLE, (InputArgument) this.Handle, (InputArgument) (Enum) value);
    }

    public bool CanRagdoll
    {
      get => Function.Call<bool>(Hash.CAN_PED_RAGDOLL, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_PED_CAN_RAGDOLL, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanPlayGestures
    {
      set => Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanSwitchWeapons
    {
      set => Function.Call(Hash.SET_PED_CAN_SWITCH_WEAPON, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanWearHelmet
    {
      set => Function.Call(Hash.SET_PED_HELMET, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanBeTargetted
    {
      set => Function.Call(Hash.SET_PED_CAN_BE_TARGETTED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanBeShotInVehicle
    {
      set => Function.Call(Hash.SET_PED_CAN_BE_SHOT_IN_VEHICLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanBeDraggedOutOfVehicle
    {
      set => Function.Call(Hash.SET_PED_CAN_BE_DRAGGED_OUT, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanBeKnockedOffBike
    {
      set => Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanFlyThroughWindscreen
    {
      get => Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, (InputArgument) this.Handle, (InputArgument) 32, (InputArgument) true);
      set => Function.Call(Hash.SET_PED_CONFIG_FLAG, (InputArgument) this.Handle, (InputArgument) 32, (InputArgument) value);
    }

    public bool CanSufferCriticalHits
    {
      get
      {
        if (this.MemoryAddress == IntPtr.Zero)
          return false;
        int num1 = Game.Version >= GameVersion.v1_0_372_2_Steam ? 5052 : 5036;
        int num2 = Game.Version >= GameVersion.v1_0_877_1_Steam ? 5092 : num1;
        return ((int) MemoryAccess.ReadByte(this.MemoryAddress + (Game.Version >= GameVersion.v1_0_944_2_Steam ? 5108 : num2)) & 4) == 0;
      }
      set => Function.Call(Hash.SET_PED_SUFFERS_CRITICAL_HITS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool CanWrithe
    {
      get => !this.GetConfigFlag(281);
      set => this.SetConfigFlag(281, !value);
    }

    public bool BlockPermanentEvents
    {
      set => Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool AlwaysKeepTask
    {
      set => Function.Call(Hash.SET_PED_KEEP_TASK, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool AlwaysDiesOnLowHealth
    {
      set => Function.Call(Hash.SET_PED_DIES_WHEN_INJURED, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool DrownsInWater
    {
      set => Function.Call(Hash.SET_PED_DIES_IN_WATER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool DrownsInSinkingVehicle
    {
      set => Function.Call(Hash.SET_PED_DIES_IN_SINKING_VEHICLE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool DiesInstantlyInWater
    {
      set => Function.Call(Hash.SET_PED_DIES_INSTANTLY_IN_WATER, (InputArgument) this.Handle, (InputArgument) value);
    }

    public bool IsInVehicle() => Function.Call<bool>(Hash.IS_PED_IN_ANY_VEHICLE, (InputArgument) this.Handle, (InputArgument) 0);

    public bool IsInVehicle(Vehicle vehicle) => Function.Call<bool>(Hash.IS_PED_IN_VEHICLE, (InputArgument) this.Handle, (InputArgument) vehicle.Handle, (InputArgument) 0);

    public bool IsSittingInVehicle() => Function.Call<bool>(Hash.IS_PED_SITTING_IN_ANY_VEHICLE, (InputArgument) this.Handle);

    public bool IsSittingInVehicle(Vehicle vehicle) => Function.Call<bool>(Hash.IS_PED_SITTING_IN_VEHICLE, (InputArgument) this.Handle, (InputArgument) vehicle.Handle);

    public void SetIntoVehicle(Vehicle vehicle, VehicleSeat seat) => Function.Call(Hash.SET_PED_INTO_VEHICLE, (InputArgument) this.Handle, (InputArgument) vehicle.Handle, (InputArgument) (Enum) seat);

    public Relationship GetRelationshipWithPed(Ped ped) => (Relationship) Function.Call<int>(Hash.GET_RELATIONSHIP_BETWEEN_PEDS, (InputArgument) this.Handle, (InputArgument) ped.Handle);

    public bool IsHeadtracking(Entity entity) => Function.Call<bool>(Hash.IS_PED_HEADTRACKING_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle);

    public bool IsInCombatAgainst(Ped target) => Function.Call<bool>(Hash.IS_PED_IN_COMBAT, (InputArgument) this.Handle, (InputArgument) target.Handle);

    public Ped GetJacker() => new Ped(Function.Call<int>(Hash.GET_PEDS_JACKER, (InputArgument) this.Handle));

    public Ped GetJackTarget() => new Ped(Function.Call<int>(Hash.GET_JACK_TARGET, (InputArgument) this.Handle));

    public Ped GetMeleeTarget() => new Ped(Function.Call<int>(Hash.GET_MELEE_TARGET_FOR_PED, (InputArgument) this.Handle));

    public Entity GetKiller() => Entity.FromHandle(Function.Call<int>(Hash.GET_PED_SOURCE_OF_DEATH, (InputArgument) this.Handle));

    public void Kill() => this.Health = -1;

    public void Resurrect()
    {
      int maxHealth = this.MaxHealth;
      bool collisionEnabled = this.IsCollisionEnabled;
      Function.Call(Hash.RESURRECT_PED, (InputArgument) this.Handle);
      this.MaxHealth = maxHealth;
      this.Health = maxHealth;
      this.IsCollisionEnabled = collisionEnabled;
      Function.Call(Hash.CLEAR_PED_TASKS_IMMEDIATELY, (InputArgument) this.Handle);
    }

    public void ResetVisibleDamage() => Function.Call(Hash.RESET_PED_VISIBLE_DAMAGE, (InputArgument) this.Handle);

    public void ClearBloodDamage() => Function.Call(Hash.CLEAR_PED_BLOOD_DAMAGE, (InputArgument) this.Handle);

    public RelationshipGroup RelationshipGroup
    {
      get => new RelationshipGroup(Function.Call<int>(Hash.GET_PED_RELATIONSHIP_GROUP_HASH, (InputArgument) this.Handle));
      set => Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, (InputArgument) this.Handle, (InputArgument) value.Hash);
    }

    public bool IsInGroup => Function.Call<bool>(Hash.IS_PED_IN_GROUP, (InputArgument) this.Handle);

    public bool NeverLeavesGroup
    {
      set => Function.Call(Hash.SET_PED_NEVER_LEAVES_GROUP, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void LeaveGroup() => Function.Call(Hash.REMOVE_PED_FROM_GROUP, (InputArgument) this.Handle);

    public void PlayAmbientSpeech(string speechName, SpeechModifier modifier = SpeechModifier.Standard)
    {
      if (modifier >= SpeechModifier.Standard && modifier < (SpeechModifier) Ped._speechModifierNames.Length)
      {
        Function.Call(Hash._PLAY_AMBIENT_SPEECH1, (InputArgument) this.Handle, (InputArgument) speechName, (InputArgument) Ped._speechModifierNames[(int) modifier]);
      }
      else
      {
        ArgumentOutOfRangeException ofRangeException = new ArgumentOutOfRangeException(nameof (modifier));
      }
    }

    public void PlayAmbientSpeech(string voiceName, string speechName, SpeechModifier modifier = SpeechModifier.Standard)
    {
      if (modifier >= SpeechModifier.Standard && modifier < (SpeechModifier) Ped._speechModifierNames.Length)
      {
        Function.Call(Hash._PLAY_AMBIENT_SPEECH_WITH_VOICE, (InputArgument) this.Handle, (InputArgument) speechName, (InputArgument) voiceName, (InputArgument) Ped._speechModifierNames[(int) modifier], (InputArgument) 0);
      }
      else
      {
        ArgumentOutOfRangeException ofRangeException = new ArgumentOutOfRangeException(nameof (modifier));
      }
    }

    public void ApplyDamage(int damageAmount) => Function.Call(Hash.APPLY_DAMAGE_TO_PED, (InputArgument) this.Handle, (InputArgument) damageAmount, (InputArgument) true);

    public override bool HasBeenDamagedBy(WeaponHash weapon) => Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) (Enum) weapon, (InputArgument) 0);

    public override bool HasBeenDamagedByAnyWeapon() => Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) 0, (InputArgument) 2);

    public override bool HasBeenDamagedByAnyMeleeWeapon() => Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, (InputArgument) this.Handle, (InputArgument) 0, (InputArgument) 1);

    public override void ClearLastWeaponDamage() => Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument) this.Handle);

    public PedBoneCollection Bones
    {
      get
      {
        if (this._pedBones == null)
          this._pedBones = new PedBoneCollection(this);
        return this._pedBones;
      }
    }

    public Vector3 GetLastWeaponImpactPosition()
    {
      OutputArgument outputArgument = new OutputArgument();
      return Function.Call<bool>(Hash.GET_PED_LAST_WEAPON_IMPACT_COORD, (InputArgument) this.Handle, (InputArgument) outputArgument) ? outputArgument.GetResult<Vector3>() : Vector3.Zero;
    }

    public void Ragdoll(int duration = -1, RagdollType ragdollType = RagdollType.Normal)
    {
      this.CanRagdoll = true;
      Function.Call(Hash.SET_PED_TO_RAGDOLL, (InputArgument) this.Handle, (InputArgument) duration, (InputArgument) duration, (InputArgument) (Enum) ragdollType, (InputArgument) false, (InputArgument) false, (InputArgument) false);
    }

    public void CancelRagdoll() => Function.Call(Hash.SET_PED_TO_RAGDOLL, (InputArgument) this.Handle, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1, (InputArgument) false, (InputArgument) false, (InputArgument) false);

    public void GiveHelmet(bool canBeRemovedByPed, HelmetType helmetType, int textureIndex) => Function.Call(Hash.GIVE_PED_HELMET, (InputArgument) this.Handle, (InputArgument) !canBeRemovedByPed, (InputArgument) (Enum) helmetType, (InputArgument) textureIndex);

    public void RemoveHelmet(bool instantly) => Function.Call(Hash.REMOVE_PED_HELMET, (InputArgument) this.Handle, (InputArgument) instantly);

    public void OpenParachute() => Function.Call(Hash.FORCE_PED_TO_OPEN_PARACHUTE, (InputArgument) this.Handle);

    public bool GetConfigFlag(int flagID) => Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, (InputArgument) this.Handle, (InputArgument) flagID, (InputArgument) true);

    public void SetConfigFlag(int flagID, bool value) => Function.Call(Hash.SET_PED_CONFIG_FLAG, (InputArgument) this.Handle, (InputArgument) flagID, (InputArgument) value);

    public void ResetConfigFlag(int flagID) => Function.Call(Hash.SET_PED_RESET_FLAG, (InputArgument) this.Handle, (InputArgument) flagID, (InputArgument) true);

    public Ped Clone(float heading = 0.0f) => new Ped(Function.Call<int>(Hash.CLONE_PED, (InputArgument) this.Handle, (InputArgument) heading, (InputArgument) false, (InputArgument) false));

    public new bool Exists() => Function.Call<int>(Hash.GET_ENTITY_TYPE, (InputArgument) this.Handle) == 1;

    public static bool Exists(Ped ped) => ped != null && ped.Exists();
  }
}
