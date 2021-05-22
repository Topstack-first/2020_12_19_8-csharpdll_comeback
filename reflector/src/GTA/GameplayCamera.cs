namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;

    public static class GameplayCamera
    {
        public static void ClampPitch(float min, float max)
        {
            InputArgument[] arguments = new InputArgument[] { min, max };
            Function.Call(Hash._CLAMP_GAMEPLAY_CAM_PITCH, arguments);
        }

        public static void ClampYaw(float min, float max)
        {
            InputArgument[] arguments = new InputArgument[] { min, max };
            Function.Call(Hash._CLAMP_GAMEPLAY_CAM_YAW, arguments);
        }

        public static Vector3 GetOffsetPosition(Vector3 offset) => 
            Matrix.TransformPoint(offset);

        public static Vector3 GetPositionOffset(Vector3 worldCoords) => 
            Matrix.InverseTransformPoint(worldCoords);

        public static void Shake(CameraShake shakeType, float amplitude)
        {
            InputArgument[] arguments = new InputArgument[] { Camera._shakeNames[(int) shakeType], amplitude };
            Function.Call(Hash.SHAKE_GAMEPLAY_CAM, arguments);
        }

        public static void StopShaking()
        {
            InputArgument[] arguments = new InputArgument[] { true };
            Function.Call(Hash.STOP_GAMEPLAY_CAM_SHAKING, arguments);
        }

        public static IntPtr MemoryAddress =>
            MemoryAccess.GetGameplayCameraAddress();

        public static Vector3 Position =>
            Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD, Array.Empty<InputArgument>());

        public static Vector3 Rotation
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { 2 };
                return Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT, arguments);
            }
        }

        public static Vector3 Direction =>
            ForwardVector;

        public static Vector3 UpVector =>
            MemoryAccess.ReadVector3(MemoryAddress + 0x210);

        public static Vector3 ForwardVector =>
            MemoryAccess.ReadVector3(MemoryAddress + 0x200);

        public static Vector3 RightVector =>
            MemoryAccess.ReadVector3(MemoryAddress + 0x1f0);

        public static GTA.Math.Matrix Matrix =>
            MemoryAccess.ReadMatrix(MemoryAddress + 0x1f0);

        public static float RelativePitch
        {
            get => 
                Function.Call<float>(Hash.GET_GAMEPLAY_CAM_RELATIVE_PITCH, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, arguments);
            }
        }

        public static float RelativeHeading
        {
            get => 
                Function.Call<float>(Hash.GET_GAMEPLAY_CAM_RELATIVE_HEADING, Array.Empty<InputArgument>());
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_HEADING, arguments);
            }
        }

        public static float Zoom =>
            Function.Call<float>(Hash._GET_GAMEPLAY_CAM_ZOOM, Array.Empty<InputArgument>());

        public static float FieldOfView =>
            Function.Call<float>(Hash.GET_GAMEPLAY_CAM_FOV, Array.Empty<InputArgument>());

        public static bool IsRendering =>
            Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_RENDERING, Array.Empty<InputArgument>());

        public static bool IsAimCamActive =>
            Function.Call<bool>(Hash.IS_AIM_CAM_ACTIVE, Array.Empty<InputArgument>());

        public static bool IsFirstPersonAimCamActive =>
            Function.Call<bool>(Hash.IS_FIRST_PERSON_AIM_CAM_ACTIVE, Array.Empty<InputArgument>());

        public static bool IsLookingBehind =>
            Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_LOOKING_BEHIND, Array.Empty<InputArgument>());

        public static bool IsShaking =>
            Function.Call<bool>(Hash.IS_GAMEPLAY_CAM_SHAKING, Array.Empty<InputArgument>());

        public static float ShakeAmplitude
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { value };
                Function.Call(Hash.SET_GAMEPLAY_CAM_SHAKE_AMPLITUDE, arguments);
            }
        }
    }
}

