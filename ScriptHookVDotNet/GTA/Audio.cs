// Decompiled with JetBrains decompiler
// Type: GTA.Audio
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public static class Audio
  {
    internal static readonly string[] _audioFlags = new string[35]
    {
      "ActivateSwitchWheelAudio",
      "AllowCutsceneOverScreenFade",
      "AllowForceRadioAfterRetune",
      "AllowPainAndAmbientSpeechToPlayDuringCutscene",
      "AllowPlayerAIOnMission",
      "AllowPoliceScannerWhenPlayerHasNoControl",
      "AllowRadioDuringSwitch",
      "AllowRadioOverScreenFade",
      "AllowScoreAndRadio",
      "AllowScriptedSpeechInSlowMo",
      "AvoidMissionCompleteDelay",
      "DisableAbortConversationForDeathAndInjury",
      "DisableAbortConversationForRagdoll",
      "DisableBarks",
      "DisableFlightMusic",
      "DisableReplayScriptStreamRecording",
      "EnableHeadsetBeep",
      "ForceConversationInterrupt",
      "ForceSeamlessRadioSwitch",
      "ForceSniperAudio",
      "FrontendRadioDisabled",
      "HoldMissionCompleteWhenPrepared",
      "IsDirectorModeActive",
      "IsPlayerOnMissionForSpeech",
      "ListenerReverbDisabled",
      "LoadMPData",
      "MobileRadioInGame",
      "OnlyAllowScriptTriggerPoliceScanner",
      "PlayMenuMusic",
      "PoliceScannerDisabled",
      "ScriptedConvListenerMaySpeak",
      "SpeechDucksScore",
      "SuppressPlayerScubaBreathing",
      "WantedMusicDisabled",
      "WantedMusicOnMission"
    };

    public static int PlaySoundAt(Vector3 position, string sound, string set)
    {
      Function.Call(Hash.PLAY_SOUND_FROM_COORD, (InputArgument) -1, (InputArgument) sound, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) set, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static int PlaySoundAt(Vector3 position, string sound)
    {
      Function.Call(Hash.PLAY_SOUND_FROM_COORD, (InputArgument) -1, (InputArgument) sound, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static int PlaySoundFromEntity(Entity entity, string sound, string set)
    {
      Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, (InputArgument) -1, (InputArgument) sound, (InputArgument) entity.Handle, (InputArgument) set, (InputArgument) 0, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static int PlaySoundFromEntity(Entity entity, string sound)
    {
      Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, (InputArgument) -1, (InputArgument) sound, (InputArgument) entity.Handle, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static int PlaySoundFrontend(string sound, string set)
    {
      Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument) -1, (InputArgument) sound, (InputArgument) set, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static int PlaySoundFrontend(string sound)
    {
      Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument) -1, (InputArgument) sound, (InputArgument) 0, (InputArgument) 0);
      return Function.Call<int>(Hash.GET_SOUND_ID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public static void StopSound(int id) => Function.Call(Hash.STOP_SOUND, (InputArgument) id);

    public static void ReleaseSound(int id) => Function.Call(Hash.RELEASE_SOUND_ID, (InputArgument) id);

    public static bool HasSoundFinished(int id) => Function.Call<bool>(Hash.HAS_SOUND_FINISHED, (InputArgument) id);

    public static void SetAudioFlag(string flag, bool toggle) => Function.Call(Hash.SET_AUDIO_FLAG, (InputArgument) flag, (InputArgument) toggle);

    public static void SetAudioFlag(AudioFlag flag, bool toggle) => Audio.SetAudioFlag(Audio._audioFlags[(int) flag], toggle);
  }
}
