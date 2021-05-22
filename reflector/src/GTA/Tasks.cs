namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    public class Tasks
    {
        private Ped _ped;

        internal Tasks(Ped ped)
        {
            this._ped = ped;
        }

        public void AchieveHeading(float heading, int timeout = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, heading, timeout };
            Function.Call(Hash.TASK_ACHIEVE_HEADING, arguments);
        }

        public void AimAt(Entity target, int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, duration, 0 };
            Function.Call(Hash.TASK_AIM_GUN_AT_ENTITY, arguments);
        }

        public void AimAt(Vector3 target, int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.X, target.Y, target.Z, duration, 0, 0 };
            Function.Call(Hash.TASK_AIM_GUN_AT_COORD, arguments);
        }

        public void Arrest(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, ped.Handle };
            Function.Call(Hash.TASK_ARREST_PED, arguments);
        }

        public void ChaseWithGroundVehicle(Ped target)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle };
            Function.Call(Hash.TASK_VEHICLE_CHASE, arguments);
        }

        public void ChaseWithHelicopter(Ped target, Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, offset.X, offset.Y, offset.Z };
            Function.Call(Hash.TASK_HELI_CHASE, arguments);
        }

        public void ChaseWithPlane(Ped target, Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, offset.X, offset.Y, offset.Z };
            Function.Call(Hash.TASK_PLANE_CHASE, arguments);
        }

        public void ChatTo(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, ped.Handle, 0x10, 0f, 0f, 0f, 0f, 0f };
            Function.Call(Hash.TASK_CHAT_TO_PED, arguments);
        }

        public void ClearAll()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.CLEAR_PED_TASKS, arguments);
        }

        public void ClearAllImmediately()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.CLEAR_PED_TASKS_IMMEDIATELY, arguments);
        }

        public void ClearAnimation(string animSet, string animName)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, animSet, animName, -4f };
            Function.Call(Hash.STOP_ANIM_TASK, arguments);
        }

        public void ClearLookAt()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.TASK_CLEAR_LOOK_AT, arguments);
        }

        public void ClearSecondary()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.CLEAR_PED_SECONDARY_TASK, arguments);
        }

        public void Climb()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, true };
            Function.Call(Hash.TASK_CLIMB, arguments);
        }

        public void ClimbLadder()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 1 };
            Function.Call(Hash.TASK_CLIMB_LADDER, arguments);
        }

        public void Cower(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, duration };
            Function.Call(Hash.TASK_COWER, arguments);
        }

        public void CruiseWithVehicle(Vehicle vehicle, float speed, DrivingStyle style = 0xc00ab)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, speed, style };
            Function.Call(Hash.TASK_VEHICLE_DRIVE_WANDER, arguments);
        }

        public void DriveTo(Vehicle vehicle, Vector3 target, float radius, float speed, DrivingStyle style = 0xc00ab)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, target.X, target.Y, target.Z, speed, style, radius };
            Function.Call(Hash.TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE, arguments);
        }

        public void EnterAnyVehicle(VehicleSeat seat = -2, int timeout = -1, float speed = 1f, EnterVehicleFlags flag = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 0, timeout, seat, speed, flag, 0 };
            Function.Call(Hash.TASK_ENTER_VEHICLE, arguments);
        }

        public void EnterVehicle(Vehicle vehicle, VehicleSeat seat = -2, int timeout = -1, float speed = 1f, EnterVehicleFlags flag = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, timeout, seat, speed, flag, 0 };
            Function.Call(Hash.TASK_ENTER_VEHICLE, arguments);
        }

        public static void EveryoneLeaveVehicle(Vehicle vehicle)
        {
            InputArgument[] arguments = new InputArgument[] { vehicle.Handle };
            Function.Call(Hash.TASK_EVERYONE_LEAVE_VEHICLE, arguments);
        }

        public void FightAgainst(Ped target)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, 0, 0x10 };
            Function.Call(Hash.TASK_COMBAT_PED, arguments);
        }

        public void FightAgainst(Ped target, int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, duration, 0 };
            Function.Call(Hash.TASK_COMBAT_PED_TIMED, arguments);
        }

        public void FightAgainstHatedTargets(float radius)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, radius, 0 };
            Function.Call(Hash.TASK_COMBAT_HATED_TARGETS_AROUND_PED, arguments);
        }

        public void FightAgainstHatedTargets(float radius, int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, radius, duration, 0 };
            Function.Call(Hash.TASK_COMBAT_HATED_TARGETS_AROUND_PED_TIMED, arguments);
        }

        public void FleeFrom(Vector3 position, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, 100f, duration, 0, 0 };
            Function.Call(Hash.TASK_SMART_FLEE_COORD, arguments);
        }

        public void FleeFrom(Ped ped, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, ped.Handle, 100f, duration, 0, 0 };
            Function.Call(Hash.TASK_SMART_FLEE_PED, arguments);
        }

        public void FollowPointRoute(params Vector3[] points)
        {
            this.FollowPointRoute(1f, points);
        }

        public void FollowPointRoute(float movementSpeed, params Vector3[] points)
        {
            Function.Call(Hash.TASK_FLUSH_ROUTE, Array.Empty<InputArgument>());
            foreach (Vector3 vector in points)
            {
                InputArgument[] argumentArray1 = new InputArgument[] { vector.X, vector.Y, vector.Z };
                Function.Call(Hash.TASK_EXTEND_ROUTE, argumentArray1);
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, movementSpeed, 0 };
            Function.Call(Hash.TASK_FOLLOW_POINT_ROUTE, arguments);
        }

        public void FollowToOffsetFromEntity(Entity target, Vector3 offset, float movementSpeed, int timeout = -1, float distanceToFollow = 10f, bool persistFollowing = true)
        {
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = this._ped.Handle;
            arguments[1] = target.Handle;
            arguments[2] = offset.X;
            arguments[3] = offset.Y;
            arguments[4] = offset.Z;
            arguments[5] = movementSpeed;
            arguments[6] = timeout;
            arguments[7] = distanceToFollow;
            arguments[8] = persistFollowing;
            Function.Call(Hash.TASK_FOLLOW_TO_OFFSET_OF_ENTITY, arguments);
        }

        public void GoTo(Entity target, Vector3 offset = new Vector3(), int timeout = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, timeout, offset.X, offset.Y, offset.Z, 1f, true };
            Function.Call(Hash.TASK_GOTO_ENTITY_OFFSET_XY, arguments);
        }

        public void GoTo(Vector3 position, bool ignorePaths = false, int timeout = -1)
        {
            if (ignorePaths)
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, 1f, timeout, 0f, 0f };
                Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, arguments);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[9];
                arguments[0] = this._ped.Handle;
                arguments[1] = position.X;
                arguments[2] = position.Y;
                arguments[3] = position.Z;
                arguments[4] = 1f;
                arguments[5] = timeout;
                arguments[6] = 0f;
                arguments[7] = 0;
                arguments[8] = 0f;
                Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, arguments);
            }
        }

        public void GuardCurrentPosition()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 15f, 10f, true };
            Function.Call(Hash.TASK_GUARD_CURRENT_POSITION, arguments);
        }

        public void HandsUp(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, duration, 0, -1, false };
            Function.Call(Hash.TASK_HANDS_UP, arguments);
        }

        public void Jump()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, true };
            Function.Call(Hash.TASK_JUMP, arguments);
        }

        public void LandPlane(Vector3 startPosition, Vector3 touchdownPosition, Vehicle plane = null)
        {
            if (plane == null)
            {
                plane = this._ped.CurrentVehicle;
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, plane, startPosition.X, startPosition.Y, startPosition.Z, touchdownPosition.X, touchdownPosition.Y, touchdownPosition.Z };
            Function.Call(Hash.TASK_PLANE_LAND, arguments);
        }

        public void LeaveVehicle(LeaveVehicleFlags flags = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 0, flags };
            Function.Call(Hash.TASK_LEAVE_ANY_VEHICLE, arguments);
        }

        public void LeaveVehicle(Vehicle vehicle, LeaveVehicleFlags flags)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, flags };
            Function.Call(Hash.TASK_LEAVE_VEHICLE, arguments);
        }

        public void LeaveVehicle(Vehicle vehicle, bool closeDoor)
        {
            this.LeaveVehicle(vehicle, closeDoor ? LeaveVehicleFlags.None : LeaveVehicleFlags.LeaveDoorOpen);
        }

        public void LookAt(Entity target, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, duration, 0, 2 };
            Function.Call(Hash.TASK_LOOK_AT_ENTITY, arguments);
        }

        public void LookAt(Vector3 position, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, duration, 0, 2 };
            Function.Call(Hash.TASK_LOOK_AT_COORD, arguments);
        }

        public void ParachuteTo(Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z };
            Function.Call(Hash.TASK_PARACHUTE_TO_TARGET, arguments);
        }

        public void ParkVehicle(Vehicle vehicle, Vector3 position, float heading, float radius = 20f, bool keepEngineOn = false)
        {
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = this._ped.Handle;
            arguments[1] = vehicle.Handle;
            arguments[2] = position.X;
            arguments[3] = position.Y;
            arguments[4] = position.Z;
            arguments[5] = heading;
            arguments[6] = 1;
            arguments[7] = radius;
            arguments[8] = keepEngineOn;
            Function.Call(Hash.TASK_VEHICLE_PARK, arguments);
        }

        public void PerformSequence(TaskSequence sequence)
        {
            if (!sequence.IsClosed)
            {
                sequence.Close(false);
            }
            this.ClearAll();
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, sequence.Handle };
            Function.Call(Hash.TASK_PERFORM_SEQUENCE, arguments);
        }

        public void PlayAnimation(string animDict, string animName)
        {
            this.PlayAnimation(animDict, animName, 8f, -8f, -1, AnimationFlags.None, 0f);
        }

        public void PlayAnimation(string animDict, string animName, float blendInSpeed, int duration, AnimationFlags flags)
        {
            this.PlayAnimation(animDict, animName, blendInSpeed, -8f, duration, flags, 0f);
        }

        public void PlayAnimation(string animDict, string animName, float speed, int duration, float playbackRate)
        {
            this.PlayAnimation(animDict, animName, speed, -speed, duration, AnimationFlags.None, playbackRate);
        }

        public void PlayAnimation(string animDict, string animName, float blendInSpeed, float blendOutSpeed, int duration, AnimationFlags flags, float playbackRate)
        {
            InputArgument[] arguments = new InputArgument[] { animDict };
            Function.Call(Hash.REQUEST_ANIM_DICT, arguments);
            DateTime time = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 0x3e8);
            while (true)
            {
                InputArgument[] argumentArray2 = new InputArgument[] { animDict };
                if (Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, argumentArray2))
                {
                    InputArgument[] argumentArray3 = new InputArgument[11];
                    argumentArray3[0] = this._ped.Handle;
                    argumentArray3[1] = animDict;
                    argumentArray3[2] = animName;
                    argumentArray3[3] = blendInSpeed;
                    argumentArray3[4] = blendOutSpeed;
                    argumentArray3[5] = duration;
                    argumentArray3[6] = flags;
                    argumentArray3[7] = playbackRate;
                    argumentArray3[8] = 0;
                    argumentArray3[9] = 0;
                    argumentArray3[10] = 0;
                    Function.Call(Hash.TASK_PLAY_ANIM, argumentArray3);
                    return;
                }
                Script.Yield();
                if (DateTime.UtcNow >= time)
                {
                    return;
                }
            }
        }

        public void PutAwayMobilePhone()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, false };
            Function.Call(Hash.TASK_USE_MOBILE_PHONE, arguments);
        }

        public void PutAwayParachute()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, false };
            Function.Call(Hash.TASK_PARACHUTE, arguments);
        }

        public void RappelFromHelicopter()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 0x41200000 };
            Function.Call(Hash.TASK_RAPPEL_FROM_HELI, arguments);
        }

        public void ReactAndFlee(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, ped.Handle };
            Function.Call(Hash.TASK_REACT_AND_FLEE_PED, arguments);
        }

        public void ReloadWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, true };
            Function.Call(Hash.TASK_RELOAD_WEAPON, arguments);
        }

        public void RunTo(Vector3 position, bool ignorePaths = false, int timeout = -1)
        {
            if (ignorePaths)
            {
                InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, 4f, timeout, 0f, 0f };
                Function.Call(Hash.TASK_GO_STRAIGHT_TO_COORD, arguments);
            }
            else
            {
                InputArgument[] arguments = new InputArgument[9];
                arguments[0] = this._ped.Handle;
                arguments[1] = position.X;
                arguments[2] = position.Y;
                arguments[3] = position.Z;
                arguments[4] = 4f;
                arguments[5] = timeout;
                arguments[6] = 0f;
                arguments[7] = 0;
                arguments[8] = 0f;
                Function.Call(Hash.TASK_FOLLOW_NAV_MESH_TO_COORD, arguments);
            }
        }

        public void ShootAt(Vector3 position, int duration = -1, FiringPattern pattern = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, duration, pattern };
            Function.Call(Hash.TASK_SHOOT_AT_COORD, arguments);
        }

        public void ShootAt(Ped target, int duration = -1, FiringPattern pattern = 0)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, duration, pattern };
            Function.Call(Hash.TASK_SHOOT_AT_ENTITY, arguments);
        }

        public void ShuffleToNextVehicleSeat(Vehicle vehicle = null)
        {
            if (vehicle == null)
            {
                vehicle = this._ped.CurrentVehicle;
            }
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle };
            Function.Call(Hash.TASK_SHUFFLE_TO_NEXT_VEHICLE_SEAT, arguments);
        }

        public void Skydive()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle };
            Function.Call(Hash.TASK_SKY_DIVE, arguments);
        }

        public void SlideTo(Vector3 position, float heading)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, heading, 0.7f };
            Function.Call(Hash.TASK_PED_SLIDE_TO_COORD, arguments);
        }

        public void StandStill(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, duration };
            Function.Call(Hash.TASK_STAND_STILL, arguments);
        }

        public void StartScenario(string name, Vector3 position)
        {
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = this._ped.Handle;
            arguments[1] = name;
            arguments[2] = position.X;
            arguments[3] = position.Y;
            arguments[4] = position.Z;
            arguments[5] = 0f;
            arguments[6] = 0;
            arguments[7] = 0;
            arguments[8] = 1;
            Function.Call(Hash.TASK_START_SCENARIO_AT_POSITION, arguments);
        }

        public void SwapWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, false };
            Function.Call(Hash.TASK_SWAP_WEAPON, arguments);
        }

        public void TurnTo(Entity target, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, duration };
            Function.Call(Hash.TASK_TURN_PED_TO_FACE_ENTITY, arguments);
        }

        public void TurnTo(Vector3 position, int duration = -1)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, duration };
            Function.Call(Hash.TASK_TURN_PED_TO_FACE_COORD, arguments);
        }

        public void UseMobilePhone()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, true };
            Function.Call(Hash.TASK_USE_MOBILE_PHONE, arguments);
        }

        public void UseMobilePhone(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, duration };
            Function.Call(Hash.TASK_USE_MOBILE_PHONE_TIMED, arguments);
        }

        public void UseParachute()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, true };
            Function.Call(Hash.TASK_PARACHUTE, arguments);
        }

        public void VehicleChase(Ped target)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle };
            Function.Call(Hash.TASK_VEHICLE_CHASE, arguments);
        }

        public void VehicleShootAtPed(Ped target)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, target.Handle, 20f };
            Function.Call(Hash.TASK_VEHICLE_SHOOT_AT_PED, arguments);
        }

        public void Wait(int duration)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, duration };
            Function.Call(Hash.TASK_PAUSE, arguments);
        }

        public void WanderAround()
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, 0, 0 };
            Function.Call(Hash.TASK_WANDER_STANDARD, arguments);
        }

        public void WanderAround(Vector3 position, float radius)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, position.X, position.Y, position.Z, radius, 0, 0 };
            Function.Call(Hash.TASK_WANDER_IN_AREA, arguments);
        }

        public void WarpIntoVehicle(Vehicle vehicle, VehicleSeat seat)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, seat };
            Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, arguments);
        }

        public void WarpOutOfVehicle(Vehicle vehicle)
        {
            InputArgument[] arguments = new InputArgument[] { this._ped.Handle, vehicle.Handle, 0x10 };
            Function.Call(Hash.TASK_LEAVE_VEHICLE, arguments);
        }
    }
}

