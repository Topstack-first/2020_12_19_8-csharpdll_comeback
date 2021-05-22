// Decompiled with JetBrains decompiler
// Type: GTA.Game
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;
using System.Windows.Forms;

namespace GTA
{
  public static class Game
  {
    internal static readonly string[] _radioNames = new string[20]
    {
      "RADIO_01_CLASS_ROCK",
      "RADIO_02_POP",
      "RADIO_03_HIPHOP_NEW",
      "RADIO_04_PUNK",
      "RADIO_05_TALK_01",
      "RADIO_06_COUNTRY",
      "RADIO_07_DANCE_01",
      "RADIO_08_MEXICAN",
      "RADIO_09_HIPHOP_OLD",
      "RADIO_11_TALK_02",
      "RADIO_12_REGGAE",
      "RADIO_13_JAZZ",
      "RADIO_14_DANCE_02",
      "RADIO_15_MOTOWN",
      "RADIO_16_SILVERLAKE",
      "RADIO_17_FUNK",
      "RADIO_18_90S_ROCK",
      "RADIO_19_USER",
      "RADIO_20_THELAB",
      "RADIO_OFF"
    };
    private static Player _cachedPlayer;

    static Game() => Game.Version = (GameVersion) MemoryAccess.GetGameVersion();

    public static GameVersion Version { get; private set; }

    public static Language Language => (Language) Function.Call<int>(Hash._GET_CURRENT_LANGUAGE_ID, (InputArgument[]) Array.Empty<InputArgument>());

    public static int GameTime => Function.Call<int>(Hash.GET_GAME_TIMER, (InputArgument[]) Array.Empty<InputArgument>());

    public static float TimeScale
    {
      set => Function.Call(Hash.SET_TIME_SCALE, (InputArgument) value);
    }

    public static int FrameCount => Function.Call<int>(Hash.GET_FRAME_COUNT, (InputArgument[]) Array.Empty<InputArgument>());

    public static float FPS => 1f / Game.LastFrameTime;

    public static float LastFrameTime => Function.Call<float>(Hash.GET_FRAME_TIME, (InputArgument[]) Array.Empty<InputArgument>());

    public static int MaxWantedLevel
    {
      get => Function.Call<int>(Hash.GET_MAX_WANTED_LEVEL, (InputArgument[]) Array.Empty<InputArgument>());
      set
      {
        if (value < 0)
          value = 0;
        else if (value > 5)
          value = 5;
        Function.Call(Hash.SET_MAX_WANTED_LEVEL, (InputArgument) value);
      }
    }

    public static float WantedMultiplier
    {
      set => Function.Call(Hash.SET_WANTED_LEVEL_MULTIPLIER, (InputArgument) value);
    }

    public static int RadarZoom
    {
      set => Function.Call(Hash.SET_RADAR_ZOOM, (InputArgument) value);
    }

    public static bool ShowsPoliceBlipsOnRadar
    {
      set => Function.Call(Hash.SET_POLICE_RADAR_BLIPS, (InputArgument) value);
    }

    public static RadioStation RadioStation
    {
      get
      {
        string str = Function.Call<string>(Hash.GET_PLAYER_RADIO_STATION_NAME, (InputArgument[]) Array.Empty<InputArgument>());
        return string.IsNullOrEmpty(str) ? RadioStation.RadioOff : (RadioStation) Array.IndexOf<string>(Game._radioNames, str);
      }
      set
      {
        if (Enum.IsDefined(typeof (RadioStation), (object) value) && value != RadioStation.RadioOff)
          Function.Call(Hash.SET_RADIO_TO_STATION_NAME, (InputArgument) Game._radioNames[(int) value]);
        else
          Function.Call(Hash.SET_RADIO_TO_STATION_NAME, (InputArgument) string.Empty);
      }
    }

    public static Player Player
    {
      get
      {
        int handle = Function.Call<int>(Hash.PLAYER_ID, (InputArgument[]) Array.Empty<InputArgument>());
        if ((object) Game._cachedPlayer == null || handle != Game._cachedPlayer.Handle)
          Game._cachedPlayer = new Player(handle);
        return Game._cachedPlayer;
      }
    }

    public static Ped PlayerPed => Game.Player.Character;

    public static bool Nightvision
    {
      get => Function.Call<bool>(Hash._IS_NIGHTVISION_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_NIGHTVISION, (InputArgument) value);
    }

    public static bool ThermalVision
    {
      get => Function.Call<bool>(Hash._IS_SEETHROUGH_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_SEETHROUGH, (InputArgument) value);
    }

    public static bool IsMissionActive
    {
      get => Function.Call<bool>(Hash.GET_MISSION_FLAG, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_MISSION_FLAG, (InputArgument) value);
    }

    public static bool IsRandomEventActive
    {
      get => Function.Call<bool>(Hash.GET_RANDOM_EVENT_FLAG, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_RANDOM_EVENT_FLAG, (InputArgument) value);
    }

    public static bool IsCutsceneActive => Function.Call<bool>(Hash.IS_CUTSCENE_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsWaypointActive => Function.Call<bool>(Hash.IS_WAYPOINT_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsPaused
    {
      get => Function.Call<bool>(Hash.IS_PAUSE_MENU_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_PAUSE_MENU_ACTIVE, (InputArgument) value);
    }

    public static bool IsLoading => Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static InputMode CurrentInputMode => !Function.Call<bool>(Hash._IS_INPUT_DISABLED, (InputArgument) 2) ? InputMode.GamePad : InputMode.MouseAndKeyboard;

    public static bool IsKeyPressed(Keys key) => ScriptDomain.CurrentDomain.IsKeyPressed(key);

    public static bool WasButtonCombinationJustEntered(ButtonCombination combination) => Function.Call<bool>(Hash._HAS_BUTTON_COMBINATION_JUST_BEEN_ENTERED, (InputArgument) combination.Hash, (InputArgument) combination.Length);

    public static bool IsControlPressed(int index, Control control) => Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsControlJustPressed(int index, Control control) => Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsControlJustReleased(int index, Control control) => Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsEnabledControlPressed(int index, Control control) => Function.Call<bool>(Hash.IS_CONTROL_PRESSED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsEnabledControlJustPressed(int index, Control control) => Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsEnabledControlJustReleased(int index, Control control) => Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument) index, (InputArgument) (Enum) control);

    public static bool IsDisabledControlPressed(int index, Control control) => Game.IsControlPressed(index, control) && !Game.IsControlEnabled(index, control);

    public static bool IsDisabledControlJustPressed(int index, Control control) => Game.IsControlJustPressed(index, control) && !Game.IsControlEnabled(index, control);

    public static bool IsDisabledControlJustReleased(int index, Control control) => Game.IsControlJustReleased(index, control) && !Game.IsControlEnabled(index, control);

    public static bool IsControlEnabled(int index, Control control) => Function.Call<bool>(Hash.IS_CONTROL_ENABLED, (InputArgument) index, (InputArgument) (Enum) control);

    public static void EnableControlThisFrame(int index, Control control) => Function.Call(Hash.ENABLE_CONTROL_ACTION, (InputArgument) index, (InputArgument) (Enum) control, (InputArgument) true);

    public static void DisableControlThisFrame(int index, Control control) => Function.Call(Hash.DISABLE_CONTROL_ACTION, (InputArgument) index, (InputArgument) (Enum) control, (InputArgument) true);

    public static void DisableAllControlsThisFrame(int index) => Function.Call(Hash.DISABLE_ALL_CONTROL_ACTIONS, (InputArgument) index);

    public static void EnableAllControlsThisFrame(int index) => Function.Call(Hash.ENABLE_ALL_CONTROL_ACTIONS, (InputArgument) index);

    public static float GetControlNormal(int index, Control control) => Function.Call<float>(Hash.GET_CONTROL_NORMAL, (InputArgument) index, (InputArgument) (Enum) control);

    public static float GetDisabledControlNormal(int index, Control control) => Function.Call<float>(Hash.GET_DISABLED_CONTROL_NORMAL, (InputArgument) index, (InputArgument) (Enum) control);

    public static int GetControlValue(int index, Control control) => Function.Call<int>(Hash.GET_CONTROL_VALUE, (InputArgument) index, (InputArgument) (Enum) control);

    public static void SetControlNormal(int index, Control control, float value) => Function.Call(Hash._SET_CONTROL_NORMAL, (InputArgument) index, (InputArgument) (Enum) control, (InputArgument) value);

    public static void Pause(bool value) => Function.Call(Hash.SET_GAME_PAUSED, (InputArgument) value);

    public static void PauseClock(bool value) => Function.Call(Hash.PAUSE_CLOCK, (InputArgument) value);

    public static void DoAutoSave() => Function.Call(Hash.DO_AUTO_SAVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static void ShowSaveMenu() => Function.Call(Hash.SET_SAVE_MENU_ACTIVE, (InputArgument) true);

    public static string GetGXTEntry(string entry)
    {
      if (!Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, (InputArgument) entry))
        return string.Empty;
      return Function.Call<string>(Hash._GET_LABEL_TEXT, (InputArgument) entry);
    }

    public static bool DoesGXTEntryExist(string entry) => Function.Call<bool>(Hash.DOES_TEXT_LABEL_EXIST, (InputArgument) entry);

    public static int GenerateHash(string input) => string.IsNullOrEmpty(input) ? 0 : (int) MemoryAccess.GetHashKey(input);

    public static void PlaySound(string soundFile, string soundSet) => Audio.ReleaseSound(Audio.PlaySoundFrontend(soundFile, soundSet));

    public static void PlayMusic(string musicFile) => Function.Call(Hash.TRIGGER_MUSIC_EVENT, (InputArgument) musicFile);

    public static void StopMusic(string musicFile) => Function.Call(Hash.CANCEL_MUSIC_EVENT, (InputArgument) musicFile);

    public static string GetUserInput(int maxLength) => Game.GetUserInput(WindowTitle.FMMC_KEY_TIP8, string.Empty, maxLength);

    public static string GetUserInput(string defaultText, int maxLength) => Game.GetUserInput(WindowTitle.FMMC_KEY_TIP8, defaultText, maxLength);

    public static string GetUserInput(WindowTitle windowTitle, int maxLength) => Game.GetUserInput(windowTitle, string.Empty, maxLength);

    public static string GetUserInput(WindowTitle windowTitle, string defaultText, int maxLength)
    {
      ScriptDomain.CurrentDomain.PauseKeyboardEvents(true);
      Function.Call(Hash.DISPLAY_ONSCREEN_KEYBOARD, (InputArgument) true, (InputArgument) windowTitle.ToString(), (InputArgument) string.Empty, (InputArgument) defaultText, (InputArgument) string.Empty, (InputArgument) string.Empty, (InputArgument) string.Empty, (InputArgument) (maxLength + 1));
      while (Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD, (InputArgument[]) Array.Empty<InputArgument>()) == 0)
        Script.Yield();
      ScriptDomain.CurrentDomain.PauseKeyboardEvents(false);
      return Function.Call<string>(Hash.GET_ONSCREEN_KEYBOARD_RESULT, (InputArgument[]) Array.Empty<InputArgument>());
    }
  }
}
