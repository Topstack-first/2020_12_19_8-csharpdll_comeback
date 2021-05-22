namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;

    public sealed class Player : INativeValue, IEquatable<Player>
    {
        private int _handle;
        private Ped _ped;

        public Player(int handle)
        {
            this._handle = handle;
        }

        public bool ChangeModel(Model model)
        {
            if (!model.IsInCdImage || (!model.IsPed || !model.Request(0x3e8)))
            {
                return false;
            }
            InputArgument[] arguments = new InputArgument[] { this.Handle, model.Hash };
            Function.Call(Hash.SET_PLAYER_MODEL, arguments);
            model.MarkAsNoLongerNeeded();
            return true;
        }

        public void ChargeSpecialAbility(int absoluteAmount)
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, absoluteAmount, true };
            Function.Call(Hash.SPECIAL_ABILITY_CHARGE_ABSOLUTE, arguments);
        }

        public void ChargeSpecialAbility(float normalizedRatio)
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, normalizedRatio, true };
            Function.Call(Hash.SPECIAL_ABILITY_CHARGE_NORMALIZED, arguments);
        }

        public void DepleteSpecialAbility()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, 1 };
            Function.Call(Hash.SPECIAL_ABILITY_DEPLETE_METER, arguments);
        }

        public void DisableFiringThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, 0 };
            Function.Call(Hash.DISABLE_PLAYER_FIRING, arguments);
        }

        public bool Equals(Player player) => 
            (player != null) && (this.Handle == player.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Entity) obj));

        public override int GetHashCode() => 
            this.Handle.GetHashCode();

        public unsafe Entity GetTargetedEntity()
        {
            int num;
            InputArgument[] arguments = new InputArgument[] { this.Handle, (IntPtr) &num };
            return (!Function.Call<bool>(Hash.GET_ENTITY_PLAYER_IS_FREE_AIMING_AT, arguments) ? null : Entity.FromHandle(num));
        }

        public bool IsTargetting(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, entity.Handle };
            return Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING_AT_ENTITY, arguments);
        }

        public static bool operator ==(Player left, Player right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Player left, Player right) => 
            !(left == right);

        public void RefillSpecialAbility()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, 1 };
            Function.Call(Hash.SPECIAL_ABILITY_FILL_METER, arguments);
        }

        public void SetExplosiveAmmoThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle };
            Function.Call(Hash.SET_EXPLOSIVE_AMMO_THIS_FRAME, arguments);
        }

        public void SetExplosiveMeleeThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle };
            Function.Call(Hash.SET_EXPLOSIVE_MELEE_THIS_FRAME, arguments);
        }

        public void SetFireAmmoThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle };
            Function.Call(Hash.SET_FIRE_AMMO_THIS_FRAME, arguments);
        }

        public void SetMayNotEnterAnyVehicleThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle };
            Function.Call(Hash.SET_PLAYER_MAY_NOT_ENTER_ANY_VEHICLE, arguments);
        }

        public void SetMayOnlyEnterThisVehicleThisFrame(Vehicle vehicle)
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, vehicle.Handle };
            Function.Call(Hash.SET_PLAYER_MAY_ONLY_ENTER_THIS_VEHICLE, arguments);
        }

        public void SetRunSpeedMultThisFrame(float mult)
        {
            if (mult > 1.499f)
            {
                mult = 1.499f;
            }
            InputArgument[] arguments = new InputArgument[] { this.Handle, mult };
            Function.Call(Hash.SET_RUN_SPRINT_MULTIPLIER_FOR_PLAYER, arguments);
        }

        public void SetSuperJumpThisFrame()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle };
            Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, arguments);
        }

        public void SetSwimSpeedMultThisFrame(float mult)
        {
            if (mult > 1.499f)
            {
                mult = 1.499f;
            }
            InputArgument[] arguments = new InputArgument[] { this.Handle, mult };
            Function.Call(Hash.SET_SWIM_MULTIPLIER_FOR_PLAYER, arguments);
        }

        public int Handle =>
            this._handle;

        public ulong NativeValue
        {
            get => 
                (ulong) this._handle;
            set => 
                this._handle = (int) value;
        }

        public Ped Character
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                int handle = Function.Call<int>(Hash.GET_PLAYER_PED, arguments);
                if ((this._ped == null) || (handle != this._ped.Handle))
                {
                    this._ped = new Ped(handle);
                }
                return this._ped;
            }
        }

        public string Name
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<string>(Hash.GET_PLAYER_NAME, arguments);
            }
        }

        public int Money
        {
            get
            {
                int num;
                int num2;
                PedHash hash = (PedHash) this.Character.Model.Hash;
                if (hash == PedHash.Michael)
                {
                    num = Game.GenerateHash("SP0_TOTAL_CASH");
                }
                else if (hash == ((PedHash) (-1692214353)))
                {
                    num = Game.GenerateHash("SP1_TOTAL_CASH");
                }
                else
                {
                    if (hash != ((PedHash) (-1686040670)))
                    {
                        return 0;
                    }
                    num = Game.GenerateHash("SP2_TOTAL_CASH");
                }
                InputArgument[] arguments = new InputArgument[] { num, (IntPtr) &num2, -1 };
                Function.Call(Hash.STAT_GET_INT, arguments);
                return num2;
            }
            set
            {
                int num;
                PedHash hash = (PedHash) this.Character.Model.Hash;
                if (hash == PedHash.Michael)
                {
                    num = Game.GenerateHash("SP0_TOTAL_CASH");
                }
                else if (hash == ((PedHash) (-1692214353)))
                {
                    num = Game.GenerateHash("SP1_TOTAL_CASH");
                }
                else
                {
                    if (hash != ((PedHash) (-1686040670)))
                    {
                        return;
                    }
                    num = Game.GenerateHash("SP2_TOTAL_CASH");
                }
                InputArgument[] arguments = new InputArgument[] { num, value, 1 };
                Function.Call(Hash.STAT_SET_INT, arguments);
            }
        }

        public int WantedLevel
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<int>(Hash.GET_PLAYER_WANTED_LEVEL, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value, false };
                Function.Call(Hash.SET_PLAYER_WANTED_LEVEL, arguments);
                InputArgument[] argumentArray2 = new InputArgument[] { this.Handle, false };
                Function.Call(Hash.SET_PLAYER_WANTED_LEVEL_NOW, argumentArray2);
            }
        }

        public Vector3 WantedCenterPosition
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<Vector3>(Hash.GET_PLAYER_WANTED_CENTRE_POSITION, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value.X, value.Y, value.Z };
                Function.Call(Hash.SET_PLAYER_WANTED_CENTRE_POSITION, arguments);
            }
        }

        public int MaxArmor
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<int>(Hash.GET_PLAYER_MAX_ARMOUR, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_MAX_ARMOUR, arguments);
            }
        }

        public ParachuteTint PrimaryParachuteTint
        {
            get
            {
                int num;
                InputArgument[] arguments = new InputArgument[] { this.Handle, (IntPtr) &num };
                Function.Call(Hash.GET_PLAYER_PARACHUTE_TINT_INDEX, arguments);
                return (ParachuteTint) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_PARACHUTE_TINT_INDEX, arguments);
            }
        }

        public ParachuteTint ReserveParachuteTint
        {
            get
            {
                int num;
                InputArgument[] arguments = new InputArgument[] { this.Handle, (IntPtr) &num };
                Function.Call(Hash.GET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX, arguments);
                return (ParachuteTint) num;
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_RESERVE_PARACHUTE_TINT_INDEX, arguments);
            }
        }

        public bool CanLeaveParachuteSmokeTrail
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_CAN_LEAVE_PARACHUTE_SMOKE_TRAIL, arguments);
            }
        }

        public Color ParachuteSmokeTrailColor
        {
            get
            {
                int num;
                int num2;
                int num3;
                InputArgument[] arguments = new InputArgument[] { this.Handle, (IntPtr) &num3, (IntPtr) &num2, (IntPtr) &num };
                Function.Call(Hash.GET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR, arguments);
                return Color.FromArgb(num3, num2, num);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value.R, value.G, value.B };
                Function.Call(Hash.SET_PLAYER_PARACHUTE_SMOKE_TRAIL_COLOR, arguments);
            }
        }

        public bool IsAlive =>
            !this.IsDead;

        public bool IsDead
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_DEAD, arguments);
            }
        }

        public bool IsAiming
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, arguments);
            }
        }

        public bool IsClimbing
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_CLIMBING, arguments);
            }
        }

        public bool IsRidingTrain
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_RIDING_TRAIN, arguments);
            }
        }

        public bool IsPressingHorn
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_PRESSING_HORN, arguments);
            }
        }

        public bool IsPlaying
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_PLAYING, arguments);
            }
        }

        public bool IsInvincible
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.GET_PLAYER_INVINCIBLE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_INVINCIBLE, arguments);
            }
        }

        public bool IgnoredByPolice
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_POLICE_IGNORE_PLAYER, arguments);
            }
        }

        public bool IgnoredByEveryone
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, arguments);
            }
        }

        public bool DispatchsCops
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_DISPATCH_COPS_FOR_PLAYER, arguments);
            }
        }

        public bool CanUseCover
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_CAN_USE_COVER, arguments);
            }
        }

        public bool CanStartMission
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.CAN_PLAYER_START_MISSION, arguments);
            }
        }

        public bool CanControlRagdoll
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.GIVE_PLAYER_RAGDOLL_CONTROL, arguments);
            }
        }

        public bool CanControlCharacter
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_CONTROL_ON, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value, 0 };
                Function.Call(Hash.SET_PLAYER_CONTROL, arguments);
            }
        }

        public float RemainingSprintTime
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<float>(Hash.GET_PLAYER_SPRINT_TIME_REMAINING, arguments);
            }
        }

        public float RemainingSprintStamina
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<float>(Hash.GET_PLAYER_SPRINT_STAMINA_REMAINING, arguments);
            }
        }

        public float RemainingUnderwaterTime
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<float>(Hash.GET_PLAYER_UNDERWATER_TIME_REMAINING, arguments);
            }
        }

        public bool IsSpecialAbilityActive
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_ACTIVE, arguments);
            }
        }

        public bool IsSpecialAbilityEnabled
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_ENABLED, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.ENABLE_SPECIAL_ABILITY, arguments);
            }
        }

        public Vehicle LastVehicle
        {
            get
            {
                Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_PLAYERS_LAST_VEHICLE, Array.Empty<InputArgument>()));
                return (vehicle.Exists() ? vehicle : null);
            }
        }

        public bool IsTargettingAnything
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.IS_PLAYER_TARGETTING_ANYTHING, arguments);
            }
        }

        public bool ForcedAim
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle, value };
                Function.Call(Hash.SET_PLAYER_FORCED_AIM, arguments);
            }
        }
    }
}

