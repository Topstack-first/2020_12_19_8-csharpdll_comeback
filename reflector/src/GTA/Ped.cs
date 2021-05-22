namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using GTA.NaturalMotion;
    using System;
    using System.Runtime.InteropServices;

    public sealed class Ped : Entity
    {
        private Tasks _tasks;
        private GTA.NaturalMotion.Euphoria _euphoria;
        private WeaponCollection _weapons;
        private GTA.Style _style;
        private PedBoneCollection _pedBones;
        internal static readonly string[] _speechModifierNames;

        static Ped()
        {
            string[] textArray1 = new string[0x25];
            textArray1[0] = "SPEECH_PARAMS_STANDARD";
            textArray1[1] = "SPEECH_PARAMS_ALLOW_REPEAT";
            textArray1[2] = "SPEECH_PARAMS_BEAT";
            textArray1[3] = "SPEECH_PARAMS_FORCE";
            textArray1[4] = "SPEECH_PARAMS_FORCE_FRONTEND";
            textArray1[5] = "SPEECH_PARAMS_FORCE_NO_REPEAT_FRONTEND";
            textArray1[6] = "SPEECH_PARAMS_FORCE_NORMAL";
            textArray1[7] = "SPEECH_PARAMS_FORCE_NORMAL_CLEAR";
            textArray1[8] = "SPEECH_PARAMS_FORCE_NORMAL_CRITICAL";
            textArray1[9] = "SPEECH_PARAMS_FORCE_SHOUTED";
            textArray1[10] = "SPEECH_PARAMS_FORCE_SHOUTED_CLEAR";
            textArray1[11] = "SPEECH_PARAMS_FORCE_SHOUTED_CRITICAL";
            textArray1[12] = "SPEECH_PARAMS_FORCE_PRELOAD_ONLY";
            textArray1[13] = "SPEECH_PARAMS_MEGAPHONE";
            textArray1[14] = "SPEECH_PARAMS_HELI";
            textArray1[15] = "SPEECH_PARAMS_FORCE_MEGAPHONE";
            textArray1[0x10] = "SPEECH_PARAMS_FORCE_HELI";
            textArray1[0x11] = "SPEECH_PARAMS_INTERRUPT";
            textArray1[0x12] = "SPEECH_PARAMS_INTERRUPT_SHOUTED";
            textArray1[0x13] = "SPEECH_PARAMS_INTERRUPT_SHOUTED_CLEAR";
            textArray1[20] = "SPEECH_PARAMS_INTERRUPT_SHOUTED_CRITICAL";
            textArray1[0x15] = "SPEECH_PARAMS_INTERRUPT_NO_FORCE";
            textArray1[0x16] = "SPEECH_PARAMS_INTERRUPT_FRONTEND";
            textArray1[0x17] = "SPEECH_PARAMS_INTERRUPT_NO_FORCE_FRONTEND";
            textArray1[0x18] = "SPEECH_PARAMS_ADD_BLIP";
            textArray1[0x19] = "SPEECH_PARAMS_ADD_BLIP_ALLOW_REPEAT";
            textArray1[0x1a] = "SPEECH_PARAMS_ADD_BLIP_FORCE";
            textArray1[0x1b] = "SPEECH_PARAMS_ADD_BLIP_SHOUTED";
            textArray1[0x1c] = "SPEECH_PARAMS_ADD_BLIP_SHOUTED_FORCE";
            textArray1[0x1d] = "SPEECH_PARAMS_ADD_BLIP_INTERRUPT";
            textArray1[30] = "SPEECH_PARAMS_ADD_BLIP_INTERRUPT_FORCE";
            textArray1[0x1f] = "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED";
            textArray1[0x20] = "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CLEAR";
            textArray1[0x21] = "SPEECH_PARAMS_FORCE_PRELOAD_ONLY_SHOUTED_CRITICAL";
            textArray1[0x22] = "SPEECH_PARAMS_SHOUTED";
            textArray1[0x23] = "SPEECH_PARAMS_SHOUTED_CLEAR";
            textArray1[0x24] = "SPEECH_PARAMS_SHOUTED_CRITICAL";
            _speechModifierNames = textArray1;
        }

        public Ped(int handle) : base(handle)
        {
        }

        public void ApplyDamage(int damageAmount)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, damageAmount, true };
            Function.Call(Hash.APPLY_DAMAGE_TO_PED, arguments);
        }

        public void CancelRagdoll()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 1, 1, 1, false, false, false };
            Function.Call(Hash.SET_PED_TO_RAGDOLL, arguments);
        }

        public void ClearBloodDamage()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.CLEAR_PED_BLOOD_DAMAGE, arguments);
        }

        public override void ClearLastWeaponDamage()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, arguments);
        }

        public Ped Clone(float heading = 0f)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, heading, false, false };
            return new Ped(Function.Call<int>(Hash.CLONE_PED, arguments));
        }

        public bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return (Function.Call<int>(Hash.GET_ENTITY_TYPE, arguments) == 1);
        }

        public static bool Exists(Ped ped) => 
            (ped != null) && ped.Exists();

        public Vector3 GetBoneCoord(Bone boneID) => 
            this.GetBoneCoord(boneID, Vector3.Zero);

        public Vector3 GetBoneCoord(Bone boneID, Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, boneID, offset.X, offset.Y, offset.Z };
            return Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, arguments);
        }

        public bool GetConfigFlag(int flagID)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, flagID, true };
            return Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, arguments);
        }

        public Ped GetJacker()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return new Ped(Function.Call<int>(Hash.GET_PEDS_JACKER, arguments));
        }

        public Ped GetJackTarget()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return new Ped(Function.Call<int>(Hash.GET_JACK_TARGET, arguments));
        }

        public Entity GetKiller()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return FromHandle(Function.Call<int>(Hash.GET_PED_SOURCE_OF_DEATH, arguments));
        }

        public Vector3 GetLastWeaponImpactPosition()
        {
            OutputArgument argument = new OutputArgument();
            InputArgument[] arguments = new InputArgument[] { base.Handle, argument };
            return (!Function.Call<bool>(Hash.GET_PED_LAST_WEAPON_IMPACT_COORD, arguments) ? Vector3.Zero : argument.GetResult<Vector3>());
        }

        public Ped GetMeleeTarget()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return new Ped(Function.Call<int>(Hash.GET_MELEE_TARGET_FOR_PED, arguments));
        }

        public Relationship GetRelationshipWithPed(Ped ped)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, ped.Handle };
            return Function.Call<int>(Hash.GET_RELATIONSHIP_BETWEEN_PEDS, arguments);
        }

        public void GiveHelmet(bool canBeRemovedByPed, HelmetType helmetType, int textureIndex)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, !canBeRemovedByPed, helmetType, textureIndex };
            Function.Call(Hash.GIVE_PED_HELMET, arguments);
        }

        public override bool HasBeenDamagedBy(WeaponHash weapon)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, weapon, 0 };
            return Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public override bool HasBeenDamagedByAnyMeleeWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0, 1 };
            return Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public override bool HasBeenDamagedByAnyWeapon()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0, 2 };
            return Function.Call<bool>(Hash.HAS_PED_BEEN_DAMAGED_BY_WEAPON, arguments);
        }

        public bool IsHeadtracking(Entity entity)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle };
            return Function.Call<bool>(Hash.IS_PED_HEADTRACKING_ENTITY, arguments);
        }

        public bool IsInCombatAgainst(Ped target)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, target.Handle };
            return Function.Call<bool>(Hash.IS_PED_IN_COMBAT, arguments);
        }

        public bool IsInCover() => 
            this.IsInCover(false);

        public bool IsInCover(bool expectUseWeapon)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, expectUseWeapon };
            return Function.Call<bool>(Hash.IS_PED_IN_COVER, arguments);
        }

        public bool IsInVehicle()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0 };
            return Function.Call<bool>(Hash.IS_PED_IN_ANY_VEHICLE, arguments);
        }

        public bool IsInVehicle(Vehicle vehicle)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vehicle.Handle, 0 };
            return Function.Call<bool>(Hash.IS_PED_IN_VEHICLE, arguments);
        }

        public bool IsSittingInVehicle()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.IS_PED_SITTING_IN_ANY_VEHICLE, arguments);
        }

        public bool IsSittingInVehicle(Vehicle vehicle)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vehicle.Handle };
            return Function.Call<bool>(Hash.IS_PED_SITTING_IN_VEHICLE, arguments);
        }

        public void Kill()
        {
            base.Health = -1;
        }

        public void LeaveGroup()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.REMOVE_PED_FROM_GROUP, arguments);
        }

        public void OpenParachute()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.FORCE_PED_TO_OPEN_PARACHUTE, arguments);
        }

        public void PlayAmbientSpeech(string speechName, SpeechModifier modifier = 0)
        {
            if ((modifier < SpeechModifier.Standard) || (modifier >= _speechModifierNames.Length))
            {
                ArgumentOutOfRangeException exception1 = new ArgumentOutOfRangeException("modifier");
            }
            else
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, speechName, _speechModifierNames[(int) modifier] };
                Function.Call(Hash._PLAY_AMBIENT_SPEECH1, arguments);
            }
        }

        public void PlayAmbientSpeech(string voiceName, string speechName, SpeechModifier modifier = 0)
        {
            if ((modifier < SpeechModifier.Standard) || (modifier >= _speechModifierNames.Length))
            {
                ArgumentOutOfRangeException exception1 = new ArgumentOutOfRangeException("modifier");
            }
            else
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, speechName, voiceName, _speechModifierNames[(int) modifier], 0 };
                Function.Call(Hash._PLAY_AMBIENT_SPEECH_WITH_VOICE, arguments);
            }
        }

        public void Ragdoll(int duration = -1, RagdollType ragdollType = 0)
        {
            this.CanRagdoll = true;
            InputArgument[] arguments = new InputArgument[] { base.Handle, duration, duration, ragdollType, false, false, false };
            Function.Call(Hash.SET_PED_TO_RAGDOLL, arguments);
        }

        public void RemoveHelmet(bool instantly)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, instantly };
            Function.Call(Hash.REMOVE_PED_HELMET, arguments);
        }

        public void ResetConfigFlag(int flagID)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, flagID, true };
            Function.Call(Hash.SET_PED_RESET_FLAG, arguments);
        }

        public void ResetVisibleDamage()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.RESET_PED_VISIBLE_DAMAGE, arguments);
        }

        public void Resurrect()
        {
            int maxHealth = base.MaxHealth;
            bool isCollisionEnabled = base.IsCollisionEnabled;
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.RESURRECT_PED, arguments);
            base.MaxHealth = maxHealth;
            base.Health = maxHealth;
            base.IsCollisionEnabled = isCollisionEnabled;
            InputArgument[] argumentArray2 = new InputArgument[] { base.Handle };
            Function.Call(Hash.CLEAR_PED_TASKS_IMMEDIATELY, argumentArray2);
        }

        public void SetConfigFlag(int flagID, bool value)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, flagID, value };
            Function.Call(Hash.SET_PED_CONFIG_FLAG, arguments);
        }

        public void SetIntoVehicle(Vehicle vehicle, VehicleSeat seat)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, vehicle.Handle, seat };
            Function.Call(Hash.SET_PED_INTO_VEHICLE, arguments);
        }

        public int Money
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_PED_MONEY, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_MONEY, arguments);
            }
        }

        public GTA.Gender Gender
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return (Function.Call<bool>(Hash.IS_PED_MALE, arguments) ? GTA.Gender.Male : GTA.Gender.Female);
            }
        }

        public int Armor
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_PED_ARMOUR, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_ARMOUR, arguments);
            }
        }

        public float ArmorFloat
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1474 : 0x1464;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14a0 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14b0 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1474 : 0x1464;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14a0 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14b0 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public int Accuracy
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_PED_ACCURACY, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_ACCURACY, arguments);
            }
        }

        public Tasks Task
        {
            get
            {
                this._tasks ??= new Tasks(this);
                return this._tasks;
            }
        }

        public int TaskSequenceProgress
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<int>(Hash.GET_SEQUENCE_PROGRESS, arguments);
            }
        }

        public GTA.NaturalMotion.Euphoria Euphoria
        {
            get
            {
                this._euphoria ??= new GTA.NaturalMotion.Euphoria(this);
                return this._euphoria;
            }
        }

        public WeaponCollection Weapons
        {
            get
            {
                this._weapons ??= new WeaponCollection(this);
                return this._weapons;
            }
        }

        public GTA.Style Style
        {
            get
            {
                this._style ??= new GTA.Style(this);
                return this._style;
            }
        }

        public VehicleWeaponHash VehicleWeapon
        {
            get
            {
                OutputArgument argument = new OutputArgument();
                InputArgument[] arguments = new InputArgument[] { base.Handle, argument };
                return (!Function.Call<bool>(Hash.GET_CURRENT_PED_VEHICLE_WEAPON, arguments) ? VehicleWeaponHash.Invalid : argument.GetResult<VehicleWeaponHash>());
            }
        }

        public Vehicle LastVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, true };
                Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_IN, arguments));
                return (vehicle.Exists() ? vehicle : null);
            }
        }

        public Vehicle CurrentVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_IN, arguments));
                return (vehicle.Exists() ? vehicle : null);
            }
        }

        public Vehicle VehicleTryingToEnter
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                Vehicle vehicle = new Vehicle(Function.Call<int>(Hash.GET_VEHICLE_PED_IS_TRYING_TO_ENTER, arguments));
                return (vehicle.Exists() ? vehicle : null);
            }
        }

        public GTA.PedGroup PedGroup
        {
            get
            {
                if (!this.IsInGroup)
                {
                    return null;
                }
                InputArgument[] arguments = new InputArgument[] { base.Handle, false };
                return new GTA.PedGroup(Function.Call<int>(Hash.GET_PED_GROUP_INDEX, arguments));
            }
        }

        public float Sweat
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x11a0 : 0x1170;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x11b0 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                if (value > 100f)
                {
                    value = 100f;
                }
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_SWEAT, arguments);
            }
        }

        public float WetnessHeight
        {
            set
            {
                if (value == 0f)
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle };
                    Function.Call(Hash.CLEAR_PED_WETNESS, arguments);
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                    Function.Call<float>(Hash.SET_PED_WETNESS_HEIGHT, arguments);
                }
            }
        }

        public string Voice
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_AMBIENT_VOICE_NAME, arguments);
            }
        }

        public int ShootRate
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_SHOOT_RATE, arguments);
            }
        }

        public bool WasKilledByStealth
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.WAS_PED_KILLED_BY_STEALTH, arguments);
            }
        }

        public bool WasKilledByTakedown
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.WAS_PED_KILLED_BY_TAKEDOWN, arguments);
            }
        }

        public VehicleSeat SeatIndex
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return VehicleSeat.None;
                }
                int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x158a : 0x1542;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x159a : num;
                int num2 = MemoryAccess.ReadSByte(base.MemoryAddress + num);
                return (((num2 == -1) || !this.IsInVehicle()) ? VehicleSeat.None : ((VehicleSeat) (num2 - 1)));
            }
        }

        public bool IsJumpingOutOfVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_JUMPING_OUT_OF_VEHICLE, arguments);
            }
        }

        public bool StaysInVehicleWhenJacked
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_STAY_IN_VEHICLE_WHEN_JACKED, arguments);
            }
        }

        public float MaxDrivingSpeed
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_DRIVE_TASK_MAX_CRUISE_SPEED, arguments);
            }
        }

        public float InjuryHealthThreshold
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1480 : 0x1470;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14c8 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14d8 : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1480 : 0x1470;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14c8 : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14d8 : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public float FatalInjuryHealthThreshold
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return 0f;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1484 : 0x1474;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14cc : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14dc : num;
                return MemoryAccess.ReadFloat(base.MemoryAddress + num);
            }
            set
            {
                if (base.MemoryAddress != IntPtr.Zero)
                {
                    int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x1484 : 0x1474;
                    num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x14cc : num;
                    num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x14dc : num;
                    MemoryAccess.WriteFloat(base.MemoryAddress + num, value);
                }
            }
        }

        public bool IsHuman
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_HUMAN, arguments);
            }
        }

        public bool IsEnemy
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_AS_ENEMY, arguments);
            }
        }

        public bool IsPriorityTargetForEnemies
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value, 0 };
                Function.Call(Hash.SET_ENTITY_IS_TARGET_PRIORITY, arguments);
            }
        }

        public bool IsPlayer
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_A_PLAYER, arguments);
            }
        }

        public bool IsCuffed
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_CUFFED, arguments);
            }
        }

        public bool IsWearingHelmet
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_WEARING_HELMET, arguments);
            }
        }

        public bool IsRagdoll
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_RAGDOLL, arguments);
            }
        }

        public bool IsIdle =>
            !this.IsInjured && (!this.IsRagdoll && (!base.IsInAir && (!base.IsOnFire && (!this.IsDucking && (!this.IsGettingIntoAVehicle && (!this.IsInCombat && (!this.IsInMeleeCombat && (!this.IsInVehicle() || this.IsSittingInVehicle()))))))));

        public bool IsProne
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_PRONE, arguments);
            }
        }

        public bool IsDucking
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_DUCKING, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DUCKING, arguments);
            }
        }

        public bool IsGettingUp
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_GETTING_UP, arguments);
            }
        }

        public bool IsClimbing
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_CLIMBING, arguments);
            }
        }

        public bool IsJumping
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_JUMPING, arguments);
            }
        }

        public bool IsFalling
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_FALLING, arguments);
            }
        }

        public bool IsStopped
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_STOPPED, arguments);
            }
        }

        public bool IsWalking
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_WALKING, arguments);
            }
        }

        public bool IsRunning
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_RUNNING, arguments);
            }
        }

        public bool IsSprinting
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_SPRINTING, arguments);
            }
        }

        public bool IsDiving
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_DIVING, arguments);
            }
        }

        public bool IsInParachuteFreeFall
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_PARACHUTE_FREE_FALL, arguments);
            }
        }

        public bool IsSwimming
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_SWIMMING, arguments);
            }
        }

        public bool IsSwimmingUnderWater
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_SWIMMING_UNDER_WATER, arguments);
            }
        }

        public bool IsVaulting
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_VAULTING, arguments);
            }
        }

        public bool IsOnBike
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, arguments);
            }
        }

        public bool IsOnFoot
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_ON_FOOT, arguments);
            }
        }

        public bool IsInSub
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_SUB, arguments);
            }
        }

        public bool IsInTaxi
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_TAXI, arguments);
            }
        }

        public bool IsInTrain
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_TRAIN, arguments);
            }
        }

        public bool IsInHeli
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_HELI, arguments);
            }
        }

        public bool IsInPlane
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_PLANE, arguments);
            }
        }

        public bool IsInFlyingVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_FLYING_VEHICLE, arguments);
            }
        }

        public bool IsInBoat
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_BOAT, arguments);
            }
        }

        public bool IsInPoliceVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_ANY_POLICE_VEHICLE, arguments);
            }
        }

        public bool IsJacking
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_JACKING, arguments);
            }
        }

        public bool IsBeingJacked
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_BEING_JACKED, arguments);
            }
        }

        public bool IsGettingIntoAVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_GETTING_INTO_A_VEHICLE, arguments);
            }
        }

        public bool IsTryingToEnterALockedVehicle
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_TRYING_TO_ENTER_A_LOCKED_VEHICLE, arguments);
            }
        }

        public bool IsInjured
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_INJURED, arguments);
            }
        }

        public bool IsFleeing
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_FLEEING, arguments);
            }
        }

        public bool IsInCombat
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_COMBAT, arguments);
            }
        }

        public bool IsInMeleeCombat
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_MELEE_COMBAT, arguments);
            }
        }

        public bool IsInStealthMode
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, arguments);
            }
        }

        public bool IsAmbientSpeechplaying
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_AMBIENT_SPEECH_PLAYING, arguments);
            }
        }

        public bool IsScriptedSpeechplaying
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_SCRIPTED_SPEECH_PLAYING, arguments);
            }
        }

        public bool IsAnySpeechplaying
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_ANY_SPEECH_PLAYING, arguments);
            }
        }

        public bool IsAmbientSpeechEnabled
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return !Function.Call<bool>(Hash.IS_AMBIENT_SPEECH_DISABLED, arguments);
            }
        }

        public bool IsPainAudioEnabled
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, !value };
                Function.Call(Hash.DISABLE_PED_PAIN_AUDIO, arguments);
            }
        }

        public bool IsPlantingBomb
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_PLANTING_BOMB, arguments);
            }
        }

        public bool IsShooting
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_SHOOTING, arguments);
            }
        }

        public bool IsAiming =>
            this.GetConfigFlag(0x4e);

        public bool IsReloading
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_RELOADING, arguments);
            }
        }

        public bool IsDoingDriveBy
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, arguments);
            }
        }

        public bool IsGoingIntoCover
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_GOING_INTO_COVER, arguments);
            }
        }

        public bool IsBeingStunned
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_BEING_STUNNED, arguments);
            }
        }

        public bool IsBeingStealthKilled
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_BEING_STEALTH_KILLED, arguments);
            }
        }

        public bool IsPerformingStealthKill
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_PERFORMING_STEALTH_KILL, arguments);
            }
        }

        public bool IsAimingFromCover
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_AIMING_FROM_COVER, arguments);
            }
        }

        public bool IsInCoverFacingLeft
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_COVER_FACING_LEFT, arguments);
            }
        }

        public string MovementAnimationSet
        {
            set
            {
                if (value == null)
                {
                    InputArgument[] arguments = new InputArgument[] { 0.25f };
                    Function.Call(Hash.RESET_PED_MOVEMENT_CLIPSET, arguments);
                    this.Task.ClearAll();
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { value };
                    if (Function.Call<bool>(Hash.DOES_ANIM_DICT_EXIST, arguments))
                    {
                        InputArgument[] argumentArray3 = new InputArgument[] { value };
                        Function.Call(Hash.REQUEST_ANIM_DICT, argumentArray3);
                        DateTime time2 = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 0x3e8);
                        while (true)
                        {
                            InputArgument[] argumentArray4 = new InputArgument[] { value };
                            if (Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, argumentArray4))
                            {
                                break;
                            }
                            Script.Yield();
                            if (DateTime.UtcNow >= time2)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        InputArgument[] argumentArray5 = new InputArgument[] { value };
                        Function.Call(Hash.REQUEST_ANIM_SET, argumentArray5);
                        DateTime time = DateTime.UtcNow + new TimeSpan(0, 0, 0, 0, 0x3e8);
                        while (true)
                        {
                            InputArgument[] argumentArray6 = new InputArgument[] { value };
                            if (Function.Call<bool>(Hash.HAS_ANIM_SET_LOADED, argumentArray6))
                            {
                                break;
                            }
                            Script.Yield();
                            if (DateTime.UtcNow >= time)
                            {
                                return;
                            }
                        }
                    }
                    InputArgument[] argumentArray7 = new InputArgument[] { value, 0.25f };
                    Function.Call(Hash.SET_PED_MOVEMENT_CLIPSET, argumentArray7);
                }
            }
        }

        public GTA.FiringPattern FiringPattern
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_FIRING_PATTERN, arguments);
            }
        }

        public GTA.ParachuteLandingType ParachuteLandingType
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<GTA.ParachuteLandingType>(Hash.GET_PED_PARACHUTE_LANDING_TYPE, arguments);
            }
        }

        public GTA.ParachuteState ParachuteState
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<GTA.ParachuteState>(Hash.GET_PED_PARACHUTE_STATE, arguments);
            }
        }

        public bool DropsWeaponsOnDeath
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x13e5 : 0x13bd;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x13f5 : num;
                return ((MemoryAccess.ReadByte(base.MemoryAddress + num) & 0x40) == 0);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DROPS_WEAPONS_WHEN_DEAD, arguments);
            }
        }

        public float DrivingSpeed
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_DRIVE_TASK_CRUISE_SPEED, arguments);
            }
        }

        public GTA.DrivingStyle DrivingStyle
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_DRIVE_TASK_DRIVING_STYLE, arguments);
            }
        }

        public GTA.VehicleDrivingFlags VehicleDrivingFlags
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_DRIVE_TASK_DRIVING_STYLE, arguments);
            }
        }

        public bool CanRagdoll
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.CAN_PED_RAGDOLL, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_RAGDOLL, arguments);
            }
        }

        public bool CanPlayGestures
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, arguments);
            }
        }

        public bool CanSwitchWeapons
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_SWITCH_WEAPON, arguments);
            }
        }

        public bool CanWearHelmet
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_HELMET, arguments);
            }
        }

        public bool CanBeTargetted
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_BE_TARGETTED, arguments);
            }
        }

        public bool CanBeShotInVehicle
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_BE_SHOT_IN_VEHICLE, arguments);
            }
        }

        public bool CanBeDraggedOutOfVehicle
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_BE_DRAGGED_OUT, arguments);
            }
        }

        public bool CanBeKnockedOffBike
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, arguments);
            }
        }

        public bool CanFlyThroughWindscreen
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 0x20, true };
                return Function.Call<bool>(Hash.GET_PED_CONFIG_FLAG, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 0x20, value };
                Function.Call(Hash.SET_PED_CONFIG_FLAG, arguments);
            }
        }

        public bool CanSufferCriticalHits
        {
            get
            {
                if (base.MemoryAddress == IntPtr.Zero)
                {
                    return false;
                }
                int num = (Game.Version >= GameVersion.v1_0_372_2_Steam) ? 0x13bc : 0x13ac;
                num = (Game.Version >= GameVersion.v1_0_877_1_Steam) ? 0x13e4 : num;
                num = (Game.Version >= GameVersion.v1_0_944_2_Steam) ? 0x13f4 : num;
                return ((MemoryAccess.ReadByte(base.MemoryAddress + num) & 4) == 0);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_SUFFERS_CRITICAL_HITS, arguments);
            }
        }

        public bool CanWrithe
        {
            get => 
                !this.GetConfigFlag(0x119);
            set => 
                this.SetConfigFlag(0x119, !value);
        }

        public bool BlockPermanentEvents
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_BLOCKING_OF_NON_TEMPORARY_EVENTS, arguments);
            }
        }

        public bool AlwaysKeepTask
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_KEEP_TASK, arguments);
            }
        }

        public bool AlwaysDiesOnLowHealth
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DIES_WHEN_INJURED, arguments);
            }
        }

        public bool DrownsInWater
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DIES_IN_WATER, arguments);
            }
        }

        public bool DrownsInSinkingVehicle
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DIES_IN_SINKING_VEHICLE, arguments);
            }
        }

        public bool DiesInstantlyInWater
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_DIES_INSTANTLY_IN_WATER, arguments);
            }
        }

        public GTA.RelationshipGroup RelationshipGroup
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return new GTA.RelationshipGroup(Function.Call<int>(Hash.GET_PED_RELATIONSHIP_GROUP_HASH, arguments));
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.Hash };
                Function.Call(Hash.SET_PED_RELATIONSHIP_GROUP_HASH, arguments);
            }
        }

        public bool IsInGroup
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_PED_IN_GROUP, arguments);
            }
        }

        public bool NeverLeavesGroup
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_PED_NEVER_LEAVES_GROUP, arguments);
            }
        }

        public PedBoneCollection Bones
        {
            get
            {
                this._pedBones ??= new PedBoneCollection(this);
                return this._pedBones;
            }
        }
    }
}

