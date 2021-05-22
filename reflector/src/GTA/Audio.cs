namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public static class Audio
    {
        internal static readonly string[] _audioFlags;

        static Audio()
        {
            string[] textArray1 = new string[0x23];
            textArray1[0] = "ActivateSwitchWheelAudio";
            textArray1[1] = "AllowCutsceneOverScreenFade";
            textArray1[2] = "AllowForceRadioAfterRetune";
            textArray1[3] = "AllowPainAndAmbientSpeechToPlayDuringCutscene";
            textArray1[4] = "AllowPlayerAIOnMission";
            textArray1[5] = "AllowPoliceScannerWhenPlayerHasNoControl";
            textArray1[6] = "AllowRadioDuringSwitch";
            textArray1[7] = "AllowRadioOverScreenFade";
            textArray1[8] = "AllowScoreAndRadio";
            textArray1[9] = "AllowScriptedSpeechInSlowMo";
            textArray1[10] = "AvoidMissionCompleteDelay";
            textArray1[11] = "DisableAbortConversationForDeathAndInjury";
            textArray1[12] = "DisableAbortConversationForRagdoll";
            textArray1[13] = "DisableBarks";
            textArray1[14] = "DisableFlightMusic";
            textArray1[15] = "DisableReplayScriptStreamRecording";
            textArray1[0x10] = "EnableHeadsetBeep";
            textArray1[0x11] = "ForceConversationInterrupt";
            textArray1[0x12] = "ForceSeamlessRadioSwitch";
            textArray1[0x13] = "ForceSniperAudio";
            textArray1[20] = "FrontendRadioDisabled";
            textArray1[0x15] = "HoldMissionCompleteWhenPrepared";
            textArray1[0x16] = "IsDirectorModeActive";
            textArray1[0x17] = "IsPlayerOnMissionForSpeech";
            textArray1[0x18] = "ListenerReverbDisabled";
            textArray1[0x19] = "LoadMPData";
            textArray1[0x1a] = "MobileRadioInGame";
            textArray1[0x1b] = "OnlyAllowScriptTriggerPoliceScanner";
            textArray1[0x1c] = "PlayMenuMusic";
            textArray1[0x1d] = "PoliceScannerDisabled";
            textArray1[30] = "ScriptedConvListenerMaySpeak";
            textArray1[0x1f] = "SpeechDucksScore";
            textArray1[0x20] = "SuppressPlayerScubaBreathing";
            textArray1[0x21] = "WantedMusicDisabled";
            textArray1[0x22] = "WantedMusicOnMission";
            _audioFlags = textArray1;
        }

        public static bool HasSoundFinished(int id)
        {
            InputArgument[] arguments = new InputArgument[] { id };
            return Function.Call<bool>(Hash.HAS_SOUND_FINISHED, arguments);
        }

        public static int PlaySoundAt(Vector3 position, string sound)
        {
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = -1;
            arguments[1] = sound;
            arguments[2] = position.X;
            arguments[3] = position.Y;
            arguments[4] = position.Z;
            arguments[5] = 0;
            arguments[6] = 0;
            arguments[7] = 0;
            arguments[8] = 0;
            Function.Call(Hash.PLAY_SOUND_FROM_COORD, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static int PlaySoundAt(Vector3 position, string sound, string set)
        {
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = -1;
            arguments[1] = sound;
            arguments[2] = position.X;
            arguments[3] = position.Y;
            arguments[4] = position.Z;
            arguments[5] = set;
            arguments[6] = 0;
            arguments[7] = 0;
            arguments[8] = 0;
            Function.Call(Hash.PLAY_SOUND_FROM_COORD, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static int PlaySoundFromEntity(Entity entity, string sound)
        {
            InputArgument[] arguments = new InputArgument[] { -1, sound, entity.Handle, 0, 0, 0 };
            Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static int PlaySoundFromEntity(Entity entity, string sound, string set)
        {
            InputArgument[] arguments = new InputArgument[] { -1, sound, entity.Handle, set, 0, 0 };
            Function.Call(Hash.PLAY_SOUND_FROM_ENTITY, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static int PlaySoundFrontend(string sound)
        {
            InputArgument[] arguments = new InputArgument[] { -1, sound, 0, 0 };
            Function.Call(Hash.PLAY_SOUND_FRONTEND, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static int PlaySoundFrontend(string sound, string set)
        {
            InputArgument[] arguments = new InputArgument[] { -1, sound, set, 0 };
            Function.Call(Hash.PLAY_SOUND_FRONTEND, arguments);
            return Function.Call<int>(Hash.GET_SOUND_ID, Array.Empty<InputArgument>());
        }

        public static void ReleaseSound(int id)
        {
            InputArgument[] arguments = new InputArgument[] { id };
            Function.Call(Hash.RELEASE_SOUND_ID, arguments);
        }

        public static void SetAudioFlag(AudioFlag flag, bool toggle)
        {
            SetAudioFlag(_audioFlags[(int) flag], toggle);
        }

        public static void SetAudioFlag(string flag, bool toggle)
        {
            InputArgument[] arguments = new InputArgument[] { flag, toggle };
            Function.Call(Hash.SET_AUDIO_FLAG, arguments);
        }

        public static void StopSound(int id)
        {
            InputArgument[] arguments = new InputArgument[] { id };
            Function.Call(Hash.STOP_SOUND, arguments);
        }
    }
}

