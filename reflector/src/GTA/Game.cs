namespace GTA
{
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class Game
    {
        internal static readonly string[] _radioNames;
        private static GTA.Player _cachedPlayer;

        static Game()
        {
            string[] textArray1 = new string[20];
            textArray1[0] = "RADIO_01_CLASS_ROCK";
            textArray1[1] = "RADIO_02_POP";
            textArray1[2] = "RADIO_03_HIPHOP_NEW";
            textArray1[3] = "RADIO_04_PUNK";
            textArray1[4] = "RADIO_05_TALK_01";
            textArray1[5] = "RADIO_06_COUNTRY";
            textArray1[6] = "RADIO_07_DANCE_01";
            textArray1[7] = "RADIO_08_MEXICAN";
            textArray1[8] = "RADIO_09_HIPHOP_OLD";
            textArray1[9] = "RADIO_11_TALK_02";
            textArray1[10] = "RADIO_12_REGGAE";
            textArray1[11] = "RADIO_13_JAZZ";
            textArray1[12] = "RADIO_14_DANCE_02";
            textArray1[13] = "RADIO_15_MOTOWN";
            textArray1[14] = "RADIO_16_SILVERLAKE";
            textArray1[15] = "RADIO_17_FUNK";
            textArray1[0x10] = "RADIO_18_90S_ROCK";
            textArray1[0x11] = "RADIO_19_USER";
            textArray1[0x12] = "RADIO_20_THELAB";
            textArray1[0x13] = "RADIO_OFF";
            _radioNames = textArray1;
            Version = (GameVersion) MemoryAccess.GetGameVersion();
        }

        public static void DisableAllControlsThisFrame(int index)
        {
            InputArgument[] arguments = new InputArgument[] { index };
            Function.Call(Hash.DISABLE_ALL_CONTROL_ACTIONS, arguments);
        }

        public static void DisableControlThisFrame(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control, true };
            Function.Call(Hash.DISABLE_CONTROL_ACTION, arguments);
        }

        public static void DoAutoSave()
        {
            Function.Call(Hash.DO_AUTO_SAVE, Array.Empty<InputArgument>());
        }

        public static bool DoesGXTEntryExist(string entry)
        {
            InputArgument[] arguments = new InputArgument[] { entry };
            return Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, arguments);
        }

        public static void EnableAllControlsThisFrame(int index)
        {
            InputArgument[] arguments = new InputArgument[] { index };
            Function.Call(Hash.ENABLE_ALL_CONTROL_ACTIONS, arguments);
        }

        public static void EnableControlThisFrame(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control, true };
            Function.Call(Hash.ENABLE_CONTROL_ACTION, arguments);
        }

        public static int GenerateHash(string input) => 
            !string.IsNullOrEmpty(input) ? ((int) MemoryAccess.GetHashKey(input)) : 0;

        public static float GetControlNormal(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<float>(Hash.GET_CONTROL_NORMAL, arguments);
        }

        public static int GetControlValue(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<int>(Hash.GET_CONTROL_VALUE, arguments);
        }

        public static float GetDisabledControlNormal(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<float>(Hash.GET_DISABLED_CONTROL_NORMAL, arguments);
        }

        public static string GetGXTEntry(string entry)
        {
            InputArgument[] arguments = new InputArgument[] { entry };
            if (!Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, arguments))
            {
                return string.Empty;
            }
            InputArgument[] argumentArray2 = new InputArgument[] { entry };
            return Function.Call<string>(Hash._GET_LABEL_TEXT, argumentArray2);
        }

        public static string GetUserInput(int maxLength) => 
            GetUserInput(WindowTitle.FMMC_KEY_TIP8, string.Empty, maxLength);

        public static string GetUserInput(WindowTitle windowTitle, int maxLength) => 
            GetUserInput(windowTitle, string.Empty, maxLength);

        public static string GetUserInput(string defaultText, int maxLength) => 
            GetUserInput(WindowTitle.FMMC_KEY_TIP8, defaultText, maxLength);

        public static string GetUserInput(WindowTitle windowTitle, string defaultText, int maxLength)
        {
            ScriptDomain.CurrentDomain.PauseKeyboardEvents(true);
            InputArgument[] arguments = new InputArgument[] { true, windowTitle.ToString(), string.Empty, defaultText, string.Empty, string.Empty, string.Empty, maxLength + 1 };
            Function.Call(Hash.DISPLAY_ONSCREEN_KEYBOARD, arguments);
            while (Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD, Array.Empty<InputArgument>()) == 0)
            {
                Script.Yield();
            }
            ScriptDomain.CurrentDomain.PauseKeyboardEvents(false);
            return Function.Call<string>(Hash.GET_ONSCREEN_KEYBOARD_RESULT, Array.Empty<InputArgument>());
        }

        public static bool IsControlEnabled(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_CONTROL_ENABLED, arguments);
        }

        public static bool IsControlJustPressed(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, arguments);
        }

        public static bool IsControlJustReleased(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, arguments);
        }

        public static bool IsControlPressed(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, arguments);
        }

        public static bool IsDisabledControlJustPressed(int index, GTA.Control control) => 
            IsControlJustPressed(index, control) && !IsControlEnabled(index, control);

        public static bool IsDisabledControlJustReleased(int index, GTA.Control control) => 
            IsControlJustReleased(index, control) && !IsControlEnabled(index, control);

        public static bool IsDisabledControlPressed(int index, GTA.Control control) => 
            IsControlPressed(index, control) && !IsControlEnabled(index, control);

        public static bool IsEnabledControlJustPressed(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, arguments);
        }

        public static bool IsEnabledControlJustReleased(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, arguments);
        }

        public static bool IsEnabledControlPressed(int index, GTA.Control control)
        {
            InputArgument[] arguments = new InputArgument[] { index, control };
            return Function.Call<bool>(Hash.IS_CONTROL_PRESSED, arguments);
        }

        public static bool IsKeyPressed(Keys key) => 
            ScriptDomain.CurrentDomain.IsKeyPressed(key);

        public static void Pause(bool value)
        {
            InputArgument[] arguments = new InputArgument[] { value };
            Function.Call(Hash.SET_GAME_PAUSED, arguments);
        }

        public static void PauseClock(bool value)
        {
            InputArgument[] arguments = new InputArgument[] { value };
            Function.Call(Hash.PAUSE_CLOCK, arguments);
        }

        public static void PlayMusic(string musicFile)
        {
            InputArgument[] arguments = new InputArgument[] { musicFile };
            Function.Call(Hash.TRIGGER_MUSIC_EVENT, arguments);
        }

        public static void PlaySound(string soundFile, string soundSet)
        {
            Audio.ReleaseSound(Audio.PlaySoundFrontend(soundFile, soundSet));
        }

        public static void SetControlNormal(int index, GTA.Control control, float value)
        {
            InputArgument[] arguments = new InputArgument[] { index, control, value };
            Function.Call(Hash._SET_CONTROL_NORMAL, arguments);
        }

        public static void ShowSaveMenu()
        {
            InputArgument[] arguments = new InputArgument[] { true };
            Function.Call(Hash.SET_SAVE_MENU_ACTIVE, arguments);
        }

        public static void StopMusic(string musicFile)
        {
            InputArgument[] arguments = new InputArgument[] { musicFile };
            Function.Call(Hash.CANCEL_MUSIC_EVENT, arguments);
        }

        public static bool WasButtonCombinationJustEntered(ButtonCombination combination)
        {
            InputArgument[] arguments = new InputArgument[] { combination.Hash, combination.Length };
            return Function.Call<bool>(Hash._HAS_BUTTON_COMBINATION_JUST_BEEN_ENTERED, arguments);
        }

        public static GameVersion Version { get; private set; }

        public static GTA.Language Language =>
            Function.Call<int>(Hash._GET_CURRENT_LANGUAGE_ID, Array.Empty<InputArgument>());

        public static int GameTime =>
            Function.Call<int>(Hash.GET_GAME_TIMER, Array.Empty<InputArgument>());

        public static float TimeScale
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_TIME_SCALE, arguments);
            }
        }

        public static int FrameCount =>
            Function.Call<int>(Hash.GET_FRAME_COUNT, Array.Empty<InputArgument>());

        public static float FPS =>
            1f / LastFrameTime;

        public static float LastFrameTime =>
            Function.Call<float>(Hash.GET_FRAME_TIME, Array.Empty<InputArgument>());

        public static int MaxWantedLevel
        {
            get => 
                Function.Call<int>(Hash.GET_MAX_WANTED_LEVEL, Array.Empty<InputArgument>());
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > 5)
                {
                    value = 5;
                }
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_MAX_WANTED_LEVEL, arguments);
            }
        }

        public static float WantedMultiplier
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_WANTED_LEVEL_MULTIPLIER, arguments);
            }
        }

        public static int RadarZoom
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_RADAR_ZOOM, arguments);
            }
        }

        public static bool ShowsPoliceBlipsOnRadar
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_POLICE_RADAR_BLIPS, arguments);
            }
        }

        public static GTA.RadioStation RadioStation
        {
            get
            {
                string str = Function.Call<string>(Hash.GET_PLAYER_RADIO_STATION_NAME, Array.Empty<InputArgument>());
                return (!string.IsNullOrEmpty(str) ? ((GTA.RadioStation) Array.IndexOf<string>(_radioNames, str)) : GTA.RadioStation.RadioOff);
            }
            set
            {
                if (Enum.IsDefined(typeof(GTA.RadioStation), value) && (value != GTA.RadioStation.RadioOff))
                {
                    InputArgument[] arguments = new InputArgument[] { _radioNames[(int) value] };
                    Function.Call(Hash.SET_RADIO_TO_STATION_NAME, arguments);
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { string.Empty };
                    Function.Call(Hash.SET_RADIO_TO_STATION_NAME, arguments);
                }
            }
        }

        public static GTA.Player Player
        {
            get
            {
                int handle = Function.Call<int>(Hash.PLAYER_ID, Array.Empty<InputArgument>());
                if ((_cachedPlayer == null) || (handle != _cachedPlayer.Handle))
                {
                    _cachedPlayer = new GTA.Player(handle);
                }
                return _cachedPlayer;
            }
        }

        public static Ped PlayerPed =>
            Player.Character;

        public static bool Nightvision
        {
            get => 
                Function.Call<bool>(Hash._IS_NIGHTVISION_ACTIVE, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_NIGHTVISION, arguments);
            }
        }

        public static bool ThermalVision
        {
            get => 
                Function.Call<bool>(Hash._IS_SEETHROUGH_ACTIVE, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_SEETHROUGH, arguments);
            }
        }

        public static bool IsMissionActive
        {
            get => 
                Function.Call<bool>(Hash.GET_MISSION_FLAG, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_MISSION_FLAG, arguments);
            }
        }

        public static bool IsRandomEventActive
        {
            get => 
                Function.Call<bool>(Hash.GET_RANDOM_EVENT_FLAG, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_RANDOM_EVENT_FLAG, arguments);
            }
        }

        public static bool IsCutsceneActive =>
            Function.Call<bool>(Hash.IS_CUTSCENE_ACTIVE, Array.Empty<InputArgument>());

        public static bool IsWaypointActive =>
            Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE, Array.Empty<InputArgument>());

        public static bool IsPaused
        {
            get => 
                Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, arguments);
            }
        }

        public static bool IsLoading =>
            Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE, Array.Empty<InputArgument>());

        public static InputMode CurrentInputMode
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { 2 };
                return (Function.Call<bool>(Hash._IS_INPUT_DISABLED, arguments) ? InputMode.MouseAndKeyboard : InputMode.GamePad);
            }
        }
    }
}

