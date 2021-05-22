// Decompiled with JetBrains decompiler
// Type: GTA.Tasks
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public class Tasks
  {
    private Ped _ped;

    internal Tasks(Ped ped) => this._ped = ped;

    public void AchieveHeading(float heading, int timeout = 0) => Function.Call(Hash.TASK_ACHIEVE_HEADING, (InputArgument) this._ped.Handle, (InputArgument) heading, (InputArgument) timeout);

    public void AimAt(Entity target, int duration) => Function.Call(Hash.TASK_AIM_GUN_AT_ENTITY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) duration, (InputArgument) 0);

    public void AimAt(Vector3 target, int duration) => Function.Call(Hash.TASK_AIM_GUN_AT_COORD, (InputArgument) this._ped.Handle, (InputArgument) target.X, (InputArgument) target.Y, (InputArgument) target.Z, (InputArgument) duration, (InputArgument) 0, (InputArgument) 0);

    public void Arrest(Ped ped) => Function.Call(Hash.TASK_ARREST_PED, (InputArgument) this._ped.Handle, (InputArgument) ped.Handle);

    public void ChatTo(Ped ped) => Function.Call(Hash.TASK_CHAT_TO_PED, (InputArgument) this._ped.Handle, (InputArgument) ped.Handle, (InputArgument) 16, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f);

    public void Jump() => Function.Call(Hash.TASK_JUMP, (InputArgument) this._ped.Handle, (InputArgument) true);

    public void Climb() => Function.Call(Hash.TASK_CLIMB, (InputArgument) this._ped.Handle, (InputArgument) true);

    public void ClimbLadder() => Function.Call(Hash.TASK_CLIMB_LADDER, (InputArgument) this._ped.Handle, (InputArgument) 1);

    public void Cower(int duration) => Function.Call(Hash.TASK_COWER, (InputArgument) this._ped.Handle, (InputArgument) duration);

    public void ChaseWithGroundVehicle(Ped target) => Function.Call(Hash.TASK_VEHICLE_CHASE, (InputArgument) this._ped.Handle, (InputArgument) target.Handle);

    public void ChaseWithHelicopter(Ped target, Vector3 offset) => Function.Call(Hash.TASK_HELI_CHASE, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z);

    public void ChaseWithPlane(Ped target, Vector3 offset) => Function.Call(Hash.TASK_PLANE_CHASE, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z);

    public void CruiseWithVehicle(Vehicle vehicle, float speed, DrivingStyle style = DrivingStyle.Normal) => Function.Call(Hash.TASK_VEHICLE_DRIVE_WANDER, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) speed, (InputArgument) (Enum) style);

    public void DriveTo(
      Vehicle vehicle,
      Vector3 target,
      float radius,
      float speed,
      DrivingStyle style = DrivingStyle.Normal)
    {
      Function.Call(Hash.TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) target.X, (InputArgument) target.Y, (InputArgument) target.Z, (InputArgument) speed, (InputArgument) (Enum) style, (InputArgument) radius);
    }

    public void EnterAnyVehicle(
      VehicleSeat seat = VehicleSeat.Any,
      int timeout = -1,
      float speed = 1f,
      EnterVehicleFlags flag = EnterVehicleFlags.None)
    {
      Function.Call(Hash.TASK_ENTER_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) 0, (InputArgument) timeout, (InputArgument) (Enum) seat, (InputArgument) speed, (InputArgument) (Enum) flag, (InputArgument) 0);
    }

    public void EnterVehicle(
      Vehicle vehicle,
      VehicleSeat seat = VehicleSeat.Any,
      int timeout = -1,
      float speed = 1f,
      EnterVehicleFlags flag = EnterVehicleFlags.None)
    {
      Function.Call(Hash.TASK_ENTER_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) timeout, (InputArgument) (Enum) seat, (InputArgument) speed, (InputArgument) (Enum) flag, (InputArgument) 0);
    }

    public static void EveryoneLeaveVehicle(Vehicle vehicle) => Function.Call(Hash.TASK_EVERYONE_LEAVE_VEHICLE, (InputArgument) vehicle.Handle);

    public void FightAgainst(Ped target) => Function.Call(Hash.TASK_COMBAT_PED, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) 0, (InputArgument) 16);

    public void FightAgainst(Ped target, int duration) => Function.Call(Hash.TASK_COMBAT_PED_TIMED, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) duration, (InputArgument) 0);

    public void FightAgainstHatedTargets(float radius) => Function.Call(Hash.TASK_COMBAT_HATED_TARGETS_AROUND_PED, (InputArgument) this._ped.Handle, (InputArgument) radius, (InputArgument) 0);

    public void FightAgainstHatedTargets(float radius, int duration) => Function.Call(Hash.TASK_COMBAT_HATED_TARGETS_AROUND_PED_TIMED, (InputArgument) this._ped.Handle, (InputArgument) radius, (InputArgument) duration, (InputArgument) 0);

    public void FleeFrom(Ped ped, int duration = -1) => Function.Call(Hash.TASK_SMART_FLEE_PED, (InputArgument) this._ped.Handle, (InputArgument) ped.Handle, (InputArgument) 100f, (InputArgument) duration, (InputArgument) 0, (InputArgument) 0);

    public void FleeFrom(Vector3 position, int duration = -1) => Function.Call(Hash.TASK_SMART_FLEE_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 100f, (InputArgument) duration, (InputArgument) 0, (InputArgument) 0);

    public void FollowPointRoute(params Vector3[] points) => this.FollowPointRoute(1f, points);

    public void FollowPointRoute(float movementSpeed, params Vector3[] points)
    {
      Function.Call(Hash.TASK_FLUSH_ROUTE, (InputArgument[]) Array.Empty<InputArgument>());
      foreach (Vector3 point in points)
        Function.Call(Hash.TASK_EXTEND_ROUTE, (InputArgument) point.X, (InputArgument) point.Y, (InputArgument) point.Z);
      Function.Call(Hash.TASK_FOLLOW_POINT_ROUTE, (InputArgument) this._ped.Handle, (InputArgument) movementSpeed, (InputArgument) 0);
    }

    public void FollowToOffsetFromEntity(
      Entity target,
      Vector3 offset,
      float movementSpeed,
      int timeout = -1,
      float distanceToFollow = 10f,
      bool persistFollowing = true)
    {
      Function.Call(Hash.TASK_FOLLOW_TO_OFFSET_OF_ENTITY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) movementSpeed, (InputArgument) timeout, (InputArgument) distanceToFollow, (InputArgument) persistFollowing);
    }

    public void GoTo(Entity target, Vector3 offset = default (Vector3), int timeout = -1) => Function.Call(Hash.TASK_GOTO_ENTITY_OFFSET_XY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) timeout, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) 1f, (InputArgument) true);

    public void GoTo(Vector3 position, bool ignorePaths = false, int timeout = -1)
    {
      if (ignorePaths)
        Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 1f, (InputArgument) timeout, (InputArgument) 0.0f, (InputArgument) 0.0f);
      else
        Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 1f, (InputArgument) timeout, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0.0f);
    }

    public void GuardCurrentPosition() => Function.Call(Hash.TASK_GUARD_CURRENT_POSITION, (InputArgument) this._ped.Handle, (InputArgument) 15f, (InputArgument) 10f, (InputArgument) true);

    public void HandsUp(int duration) => Function.Call(Hash.TASK_HANDS_UP, (InputArgument) this._ped.Handle, (InputArgument) duration, (InputArgument) 0, (InputArgument) -1, (InputArgument) false);

    public void LandPlane(Vector3 startPosition, Vector3 touchdownPosition, Vehicle plane = null)
    {
      if ((Entity) plane == (Entity) null)
        plane = this._ped.CurrentVehicle;
      Function.Call(Hash.TASK_PLANE_LAND, (InputArgument) this._ped.Handle, (InputArgument) (INativeValue) plane, (InputArgument) startPosition.X, (InputArgument) startPosition.Y, (InputArgument) startPosition.Z, (InputArgument) touchdownPosition.X, (InputArgument) touchdownPosition.Y, (InputArgument) touchdownPosition.Z);
    }

    public void LeaveVehicle(LeaveVehicleFlags flags = LeaveVehicleFlags.None) => Function.Call(Hash.TASK_LEAVE_ANY_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) 0, (InputArgument) (Enum) flags);

    public void LeaveVehicle(Vehicle vehicle, bool closeDoor) => this.LeaveVehicle(vehicle, closeDoor ? LeaveVehicleFlags.None : LeaveVehicleFlags.LeaveDoorOpen);

    public void LeaveVehicle(Vehicle vehicle, LeaveVehicleFlags flags) => Function.Call(Hash.TASK_LEAVE_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) (Enum) flags);

    public void LookAt(Entity target, int duration = -1) => Function.Call(Hash.TASK_LOOK_AT_ENTITY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) duration, (InputArgument) 0, (InputArgument) 2);

    public void LookAt(Vector3 position, int duration = -1) => Function.Call(Hash.TASK_LOOK_AT_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) duration, (InputArgument) 0, (InputArgument) 2);

    public void ParachuteTo(Vector3 position) => Function.Call(Hash.TASK_PARACHUTE_TO_TARGET, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);

    public void ParkVehicle(
      Vehicle vehicle,
      Vector3 position,
      float heading,
      float radius = 20f,
      bool keepEngineOn = false)
    {
      Function.Call(Hash.TASK_VEHICLE_PARK, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) heading, (InputArgument) 1, (InputArgument) radius, (InputArgument) keepEngineOn);
    }

    public void PerformSequence(TaskSequence sequence)
    {
      if (!sequence.IsClosed)
        sequence.Close(false);
      this.ClearAll();
      Function.Call(Hash.TASK_PERFORM_SEQUENCE, (InputArgument) this._ped.Handle, (InputArgument) sequence.Handle);
    }

    public void PlayAnimation(string animDict, string animName) => this.PlayAnimation(animDict, animName, 8f, -8f, -1, AnimationFlags.None, 0.0f);

    public void PlayAnimation(
      string animDict,
      string animName,
      float speed,
      int duration,
      float playbackRate)
    {
      this.PlayAnimation(animDict, animName, speed, -speed, duration, AnimationFlags.None, playbackRate);
    }

    public void PlayAnimation(
      string animDict,
      string animName,
      float blendInSpeed,
      int duration,
      AnimationFlags flags)
    {
      this.PlayAnimation(animDict, animName, blendInSpeed, -8f, duration, flags, 0.0f);
    }

    public void PlayAnimation(
      string animDict,
      string animName,
      float blendInSpeed,
      float blendOutSpeed,
      int duration,
      AnimationFlags flags,
      float playbackRate)
    {
      Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument) animDict);
      DateTime dateTime = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 1000);
      do
      {
        if (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, (InputArgument) animDict))
          Script.Yield();
        else
          goto label_3;
      }
      while (!(DateTime.UtcNow >= dateTime));
      return;
label_3:
      Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument) this._ped.Handle, (InputArgument) animDict, (InputArgument) animName, (InputArgument) blendInSpeed, (InputArgument) blendOutSpeed, (InputArgument) duration, (InputArgument) (Enum) flags, (InputArgument) playbackRate, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
    }

    public void RappelFromHelicopter() => Function.Call(Hash.TASK_RAPPEL_FROM_HELI, (InputArgument) this._ped.Handle, (InputArgument) 1092616192);

    public void ReactAndFlee(Ped ped) => Function.Call(Hash.TASK_REACT_AND_FLEE_PED, (InputArgument) this._ped.Handle, (InputArgument) ped.Handle);

    public void ReloadWeapon() => Function.Call(Hash.TASK_RELOAD_WEAPON, (InputArgument) this._ped.Handle, (InputArgument) true);

    public void RunTo(Vector3 position, bool ignorePaths = false, int timeout = -1)
    {
      if (ignorePaths)
        Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 4f, (InputArgument) timeout, (InputArgument) 0.0f, (InputArgument) 0.0f);
      else
        Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 4f, (InputArgument) timeout, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0.0f);
    }

    public void ShootAt(Ped target, int duration = -1, FiringPattern pattern = FiringPattern.Default) => Function.Call(Hash.TASK_SHOOT_AT_ENTITY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) duration, (InputArgument) (Enum) pattern);

    public void ShootAt(Vector3 position, int duration = -1, FiringPattern pattern = FiringPattern.Default) => Function.Call(Hash.TASK_SHOOT_AT_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) duration, (InputArgument) (Enum) pattern);

    public void ShuffleToNextVehicleSeat(Vehicle vehicle = null)
    {
      if ((Entity) vehicle == (Entity) null)
        vehicle = this._ped.CurrentVehicle;
      Function.Call(Hash.TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT, (InputArgument) this._ped.Handle, (InputArgument) (INativeValue) vehicle);
    }

    public void Skydive() => Function.Call(Hash.TASK_SKY_DIVE, (InputArgument) this._ped.Handle);

    public void SlideTo(Vector3 position, float heading) => Function.Call(Hash.TASK_PED_SLIDE_TO_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) heading, (InputArgument) 0.7f);

    public void StandStill(int duration) => Function.Call(Hash.TASK_STAND_STILL, (InputArgument) this._ped.Handle, (InputArgument) duration);

    public void StartScenario(string name, Vector3 position) => Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, (InputArgument) this._ped.Handle, (InputArgument) name, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);

    public void SwapWeapon() => Function.Call(Hash.TASK_SWAP_WEAPON, (InputArgument) this._ped.Handle, (InputArgument) false);

    public void TurnTo(Entity target, int duration = -1) => Function.Call(Hash.TASK_TURN_PED_TO_FACE_ENTITY, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) duration);

    public void TurnTo(Vector3 position, int duration = -1) => Function.Call(Hash.TASK_TURN_PED_TO_FACE_COORD, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) duration);

    public void UseParachute() => Function.Call(Hash.TASK_PARACHUTE, (InputArgument) this._ped.Handle, (InputArgument) true);

    public void UseMobilePhone() => Function.Call(Hash.TASK_USE_MOBILE_PHONE, (InputArgument) this._ped.Handle, (InputArgument) true);

    public void UseMobilePhone(int duration) => Function.Call(Hash.TASK_USE_MOBILE_PHONE_TIMED, (InputArgument) this._ped.Handle, (InputArgument) duration);

    public void PutAwayParachute() => Function.Call(Hash.TASK_PARACHUTE, (InputArgument) this._ped.Handle, (InputArgument) false);

    public void PutAwayMobilePhone() => Function.Call(Hash.TASK_USE_MOBILE_PHONE, (InputArgument) this._ped.Handle, (InputArgument) false);

    public void VehicleChase(Ped target) => Function.Call(Hash.TASK_VEHICLE_CHASE, (InputArgument) this._ped.Handle, (InputArgument) target.Handle);

    public void VehicleShootAtPed(Ped target) => Function.Call(Hash.TASK_VEHICLE_SHOOT_AT_PED, (InputArgument) this._ped.Handle, (InputArgument) target.Handle, (InputArgument) 20f);

    public void Wait(int duration) => Function.Call(Hash.TASK_PAUSE, (InputArgument) this._ped.Handle, (InputArgument) duration);

    public void WanderAround() => Function.Call(Hash.TASK_WANDER_STANDARD, (InputArgument) this._ped.Handle, (InputArgument) 0, (InputArgument) 0);

    public void WanderAround(Vector3 position, float radius) => Function.Call(Hash.TASK_WANDER_IN_AREA, (InputArgument) this._ped.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) radius, (InputArgument) 0, (InputArgument) 0);

    public void WarpIntoVehicle(Vehicle vehicle, VehicleSeat seat) => Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) (Enum) seat);

    public void WarpOutOfVehicle(Vehicle vehicle) => Function.Call(Hash.TASK_LEAVE_VEHICLE, (InputArgument) this._ped.Handle, (InputArgument) vehicle.Handle, (InputArgument) 16);

    public void ClearAll() => Function.Call(Hash.CLEAR_PED_TASKS, (InputArgument) this._ped.Handle);

    public void ClearAllImmediately() => Function.Call(Hash.CLEAR_PED_TASKS_IMMEDIATELY, (InputArgument) this._ped.Handle);

    public void ClearLookAt() => Function.Call(Hash.TASK_CLEAR_LOOK_AT, (InputArgument) this._ped.Handle);

    public void ClearSecondary() => Function.Call(Hash.CLEAR_PED_SECONDARY_TASK, (InputArgument) this._ped.Handle);

    public void ClearAnimation(string animSet, string animName) => Function.Call(Hash.STOP_ANIM_TASK, (InputArgument) this._ped.Handle, (InputArgument) animSet, (InputArgument) animName, (InputArgument) -4f);
  }
}
