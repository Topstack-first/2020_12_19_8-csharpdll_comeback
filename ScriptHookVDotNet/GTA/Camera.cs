// Decompiled with JetBrains decompiler
// Type: GTA.Camera
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;

namespace GTA
{
  public sealed class Camera : PoolObject, IEquatable<Camera>, ISpatial
  {
    internal static readonly string[] _shakeNames = new string[11]
    {
      "HAND_SHAKE",
      "SMALL_EXPLOSION_SHAKE",
      "MEDIUM_EXPLOSION_SHAKE",
      "LARGE_EXPLOSION_SHAKE",
      "JOLT_SHAKE",
      "VIBRATE_SHAKE",
      "ROAD_VIBRATION_SHAKE",
      "DRUNK_SHAKE",
      "SKY_DIVING_SHAKE",
      "FAMILY5_DRUG_TRIP_SHAKE",
      "DEATH_FAIL_IN_EFFECT_SHAKE"
    };

    public Camera(int handle)
      : base(handle)
    {
    }

    public IntPtr MemoryAddress => MemoryAccess.GetCameraAddress(this.Handle);

    private IntPtr MatrixAddress
    {
      get
      {
        IntPtr memoryAddress = this.MemoryAddress;
        if (memoryAddress == IntPtr.Zero)
          return IntPtr.Zero;
        return ((int) MemoryAccess.ReadByte(memoryAddress + 544) & 1) != 0 ? memoryAddress + 272 : memoryAddress + 48;
      }
    }

    public bool IsActive
    {
      get => Function.Call<bool>(Hash.IS_CAM_ACTIVE, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_ACTIVE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public Vector3 Position
    {
      get => Function.Call<Vector3>(Hash.GET_CAM_COORD, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_COORD, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z);
    }

    public Vector3 Rotation
    {
      get => Function.Call<Vector3>(Hash.GET_CAM_ROT, (InputArgument) this.Handle, (InputArgument) 2);
      set => Function.Call(Hash.SET_CAM_ROT, (InputArgument) this.Handle, (InputArgument) value.X, (InputArgument) value.Y, (InputArgument) value.Z, (InputArgument) 2);
    }

    public Vector3 Direction
    {
      get => this.ForwardVector;
      set
      {
        value.Normalize();
        Vector3 vector3_1 = new Vector3(value.X, value.Y, 0.0f);
        Vector3 vector3_2 = Vector3.Normalize(new Vector3(value.Z, vector3_1.Length(), 0.0f));
        this.Rotation = new Vector3((float) (System.Math.Atan2((double) vector3_2.X, (double) vector3_2.Y) * (180.0 / System.Math.PI)), this.Rotation.Y, (float) (System.Math.Atan2((double) value.X, (double) value.Y) * (-180.0 / System.Math.PI)));
      }
    }

    public Vector3 UpVector
    {
      get
      {
        IntPtr matrixAddress = this.MatrixAddress;
        return matrixAddress == IntPtr.Zero ? Vector3.RelativeTop : MemoryAccess.ReadVector3(matrixAddress + 32);
      }
    }

    public Vector3 ForwardVector
    {
      get
      {
        IntPtr matrixAddress = this.MatrixAddress;
        return matrixAddress == IntPtr.Zero ? Vector3.RelativeFront : MemoryAccess.ReadVector3(matrixAddress + 16);
      }
    }

    public Vector3 RightVector
    {
      get
      {
        IntPtr matrixAddress = this.MatrixAddress;
        return matrixAddress == IntPtr.Zero ? Vector3.RelativeRight : MemoryAccess.ReadVector3(matrixAddress);
      }
    }

    public Matrix Matrix
    {
      get
      {
        IntPtr matrixAddress = this.MatrixAddress;
        return !(matrixAddress == IntPtr.Zero) ? MemoryAccess.ReadMatrix(matrixAddress) : new Matrix();
      }
    }

    public Vector3 GetOffsetPosition(Vector3 offset) => this.Matrix.TransformPoint(offset);

    public Vector3 GetPositionOffset(Vector3 worldCoords) => this.Matrix.InverseTransformPoint(worldCoords);

    public float FieldOfView
    {
      get => Function.Call<float>(Hash.GET_CAM_FOV, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_FOV, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float NearClip
    {
      get => Function.Call<float>(Hash.GET_CAM_NEAR_CLIP, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_NEAR_CLIP, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float FarClip
    {
      get => Function.Call<float>(Hash.GET_CAM_FAR_CLIP, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_FAR_CLIP, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float NearDepthOfField
    {
      set => Function.Call(Hash.SET_CAM_NEAR_DOF, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float FarDepthOfField
    {
      get => Function.Call<float>(Hash.GET_CAM_FAR_DOF, (InputArgument) this.Handle);
      set => Function.Call(Hash.SET_CAM_FAR_DOF, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float DepthOfFieldStrength
    {
      set => Function.Call(Hash.SET_CAM_DOF_STRENGTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public float MotionBlurStrength
    {
      set => Function.Call(Hash.SET_CAM_MOTION_BLUR_STRENGTH, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void Shake(CameraShake shakeType, float amplitude) => Function.Call(Hash.SHAKE_CAM, (InputArgument) this.Handle, (InputArgument) Camera._shakeNames[(int) shakeType], (InputArgument) amplitude);

    public void StopShaking() => Function.Call(Hash.STOP_CAM_SHAKING, (InputArgument) this.Handle, (InputArgument) true);

    public bool IsShaking => Function.Call<bool>(Hash.IS_CAM_SHAKING, (InputArgument) this.Handle);

    public float ShakeAmplitude
    {
      set => Function.Call(Hash.SET_CAM_SHAKE_AMPLITUDE, (InputArgument) this.Handle, (InputArgument) value);
    }

    public void PointAt(Entity target, Vector3 offset = default (Vector3)) => Function.Call(Hash.POINT_CAM_AT_ENTITY, (InputArgument) this.Handle, (InputArgument) target.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) true);

    public void PointAt(PedBone target, Vector3 offset = default (Vector3)) => Function.Call(Hash.POINT_CAM_AT_PED_BONE, (InputArgument) this.Handle, (InputArgument) target.Owner.Handle, (InputArgument) (EntityBone) target, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) true);

    public void PointAt(Vector3 target) => Function.Call(Hash.POINT_CAM_AT_COORD, (InputArgument) this.Handle, (InputArgument) target.X, (InputArgument) target.Y, (InputArgument) target.Z);

    public void StopPointing() => Function.Call(Hash.STOP_CAM_POINTING, (InputArgument) this.Handle);

    public void InterpTo(Camera to, int duration, bool easePosition, bool easeRotation) => Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, (InputArgument) to.Handle, (InputArgument) this.Handle, (InputArgument) duration, (InputArgument) easePosition, (InputArgument) easeRotation);

    public bool IsInterpolating => Function.Call<bool>(Hash.IS_CAM_INTERPOLATING, (InputArgument) this.Handle);

    public void AttachTo(Entity entity, Vector3 offset) => Function.Call(Hash.ATTACH_CAM_TO_ENTITY, (InputArgument) this.Handle, (InputArgument) entity.Handle, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) true);

    public void AttachTo(PedBone pedBone, Vector3 offset) => Function.Call(Hash.ATTACH_CAM_TO_PED_BONE, (InputArgument) this.Handle, (InputArgument) pedBone.Owner.Handle, (InputArgument) (EntityBone) pedBone, (InputArgument) offset.X, (InputArgument) offset.Y, (InputArgument) offset.Z, (InputArgument) true);

    public void Detach() => Function.Call(Hash.DETACH_CAM, (InputArgument) this.Handle);

    public override void Delete() => Function.Call(Hash.DESTROY_CAM, (InputArgument) this.Handle, (InputArgument) 0);

    public override bool Exists() => Function.Call<bool>(Hash.DOES_CAM_EXIST, (InputArgument) this.Handle);

    public static bool Exists(Camera camera) => (object) camera != null && camera.Exists();

    public bool Equals(Camera camera) => (object) camera != null && this.Handle == camera.Handle;

    public override bool Equals(object obj) => obj != null && obj.GetType() == this.GetType() && this.Equals((Camera) obj);

    public override int GetHashCode() => this.Handle;

    public static bool operator ==(Camera left, Camera right) => (object) left != null ? left.Equals(right) : (object) right == null;

    public static bool operator !=(Camera left, Camera right) => !(left == right);
  }
}
