// Decompiled with JetBrains decompiler
// Type: GTA.GameplayCamera
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public static class GameplayCamera
  {
    public static IntPtr MemoryAddress => MemoryAccess.GetGameplayCameraAddress();

    public static Vector3 Position => Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD, (InputArgument[]) Array.Empty<InputArgument>());

    public static Vector3 Rotation => Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT, (InputArgument) 2);

    public static Vector3 Direction => GameplayCamera.ForwardVector;

    public static Vector3 UpVector => MemoryAccess.ReadVector3(GameplayCamera.MemoryAddress + 528);

    public static Vector3 ForwardVector => MemoryAccess.ReadVector3(GameplayCamera.MemoryAddress + 512);

    public static Vector3 RightVector => MemoryAccess.ReadVector3(GameplayCamera.MemoryAddress + 496);

    public static Matrix Matrix => MemoryAccess.ReadMatrix(GameplayCamera.MemoryAddress + 496);

    public static Vector3 GetOffsetPosition(Vector3 offset) => GameplayCamera.Matrix.TransformPoint(offset);

    public static Vector3 GetPositionOffset(Vector3 worldCoords) => GameplayCamera.Matrix.InverseTransformPoint(worldCoords);

    public static float RelativePitch
    {
      get => Function.Call<float>(Hash.GET_GAMEPLAY_CAM_RELATIVE_PITCH, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, (InputArgument) value);
    }

    public static float RelativeHeading
    {
      get => Function.Call<float>(Hash.GET_GAMEPLAY_CAM_RELATIVE_HEADING, (InputArgument[]) Array.Empty<InputArgument>());
      set => Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_HEADING, (InputArgument) value);
    }

    public static void ClampYaw(float min, float max) => Function.Call(Hash._CLAMP_GAMEPLAY_CAM_YAW, (InputArgument) min, (InputArgument) max);

    public static void ClampPitch(float min, float max) => Function.Call(Hash._CLAMP_GAMEPLAY_CAM_PITCH, (InputArgument) min, (InputArgument) max);

    public static float Zoom => Function.Call<float>(Hash._GET_GAMEPLAY_CAM_ZOOM, (InputArgument[]) Array.Empty<InputArgument>());

    public static float FieldOfView => Function.Call<float>(Hash.GET_GAMEPLAY_CAM_FOV, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsRendering => Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_RENDERING, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsAimCamActive => Function.Call<bool>(Hash.IS_AIM_CAM_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsFirstPersonAimCamActive => Function.Call<bool>(Hash.IS_FIRST_PERSON_AIM_CAM_ACTIVE, (InputArgument[]) Array.Empty<InputArgument>());

    public static bool IsLookingBehind => Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_LOOKING_BEHIND, (InputArgument[]) Array.Empty<InputArgument>());

    public static void Shake(CameraShake shakeType, float amplitude) => Function.Call(Hash.SHAKE_GAMEPLAY_CAM, (InputArgument) Camera._shakeNames[(int) shakeType], (InputArgument) amplitude);

    public static void StopShaking() => Function.Call(Hash.STOP_GAMEPLAY_CAM_SHAKING, (InputArgument) true);

    public static bool IsShaking => Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_SHAKING, (InputArgument[]) Array.Empty<InputArgument>());

    public static float ShakeAmplitude
    {
      set => Function.Call(Hash.SET_GAMEPLAY_CAM_SHAKE_AMPLITUDE, (InputArgument) value);
    }
  }
}
