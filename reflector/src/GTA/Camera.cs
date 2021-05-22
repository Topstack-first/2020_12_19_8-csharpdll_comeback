namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Runtime.InteropServices;

    public sealed class Camera : PoolObject, IEquatable<Camera>, ISpatial
    {
        internal static readonly string[] _shakeNames;

        static Camera()
        {
            string[] textArray1 = new string[11];
            textArray1[0] = "HAND_SHAKE";
            textArray1[1] = "SMALL_EXPLOSION_SHAKE";
            textArray1[2] = "MEDIUM_EXPLOSION_SHAKE";
            textArray1[3] = "LARGE_EXPLOSION_SHAKE";
            textArray1[4] = "JOLT_SHAKE";
            textArray1[5] = "VIBRATE_SHAKE";
            textArray1[6] = "ROAD_VIBRATION_SHAKE";
            textArray1[7] = "DRUNK_SHAKE";
            textArray1[8] = "SKY_DIVING_SHAKE";
            textArray1[9] = "FAMILY5_DRUG_TRIP_SHAKE";
            textArray1[10] = "DEATH_FAIL_IN_EFFECT_SHAKE";
            _shakeNames = textArray1;
        }

        public Camera(int handle) : base(handle)
        {
        }

        public void AttachTo(Entity entity, Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, entity.Handle, offset.X, offset.Y, offset.Z, true };
            Function.Call(Hash.ATTACH_CAM_TO_ENTITY, arguments);
        }

        public void AttachTo(PedBone pedBone, Vector3 offset)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, pedBone.Owner.Handle, (InputArgument) pedBone, offset.X, offset.Y, offset.Z, true };
            Function.Call(Hash.ATTACH_CAM_TO_PED_BONE, arguments);
        }

        public override void Delete()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, 0 };
            Function.Call(Hash.DESTROY_CAM, arguments);
        }

        public void Detach()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.DETACH_CAM, arguments);
        }

        public bool Equals(Camera camera) => 
            (camera != null) && (base.Handle == camera.Handle);

        public override bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == base.GetType()) && this.Equals((Camera) obj));

        public override bool Exists()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            return Function.Call<bool>(Hash.DOES_CAM_EXIST, arguments);
        }

        public static bool Exists(Camera camera) => 
            (camera != null) && camera.Exists();

        public override int GetHashCode() => 
            base.Handle;

        public Vector3 GetOffsetPosition(Vector3 offset) => 
            this.Matrix.TransformPoint(offset);

        public Vector3 GetPositionOffset(Vector3 worldCoords) => 
            this.Matrix.InverseTransformPoint(worldCoords);

        public void InterpTo(Camera to, int duration, bool easePosition, bool easeRotation)
        {
            InputArgument[] arguments = new InputArgument[] { to.Handle, base.Handle, duration, easePosition, easeRotation };
            Function.Call(Hash.SET_CAM_ACTIVE_WITH_INTERP, arguments);
        }

        public static bool operator ==(Camera left, Camera right) => 
            (left == null) ? ReferenceEquals(right, null) : left.Equals(right);

        public static bool operator !=(Camera left, Camera right) => 
            !(left == right);

        public void PointAt(Vector3 target)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, target.X, target.Y, target.Z };
            Function.Call(Hash.POINT_CAM_AT_COORD, arguments);
        }

        public void PointAt(Entity target, Vector3 offset = new Vector3())
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, target.Handle, offset.X, offset.Y, offset.Z, true };
            Function.Call(Hash.POINT_CAM_AT_ENTITY, arguments);
        }

        public void PointAt(PedBone target, Vector3 offset = new Vector3())
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, target.Owner.Handle, (InputArgument) target, offset.X, offset.Y, offset.Z, true };
            Function.Call(Hash.POINT_CAM_AT_PED_BONE, arguments);
        }

        public void Shake(CameraShake shakeType, float amplitude)
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, _shakeNames[(int) shakeType], amplitude };
            Function.Call(Hash.SHAKE_CAM, arguments);
        }

        public void StopPointing()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle };
            Function.Call(Hash.STOP_CAM_POINTING, arguments);
        }

        public void StopShaking()
        {
            InputArgument[] arguments = new InputArgument[] { base.Handle, true };
            Function.Call(Hash.STOP_CAM_SHAKING, arguments);
        }

        public IntPtr MemoryAddress =>
            MemoryAccess.GetCameraAddress(base.Handle);

        private IntPtr MatrixAddress
        {
            get
            {
                IntPtr memoryAddress = this.MemoryAddress;
                return (!(memoryAddress == IntPtr.Zero) ? (((MemoryAccess.ReadByte(memoryAddress + 0x220) & 1) == 0) ? (memoryAddress + 0x30) : (memoryAddress + 0x110)) : IntPtr.Zero);
            }
        }

        public bool IsActive
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_CAM_ACTIVE, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_ACTIVE, arguments);
            }
        }

        public Vector3 Position
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<Vector3>(Hash.GET_CAM_COORD, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z };
                Function.Call(Hash.SET_CAM_COORD, arguments);
            }
        }

        public Vector3 Rotation
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, 2 };
                return Function.Call<Vector3>(Hash.GET_CAM_ROT, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value.X, value.Y, value.Z, 2 };
                Function.Call(Hash.SET_CAM_ROT, arguments);
            }
        }

        public Vector3 Direction
        {
            get => 
                this.ForwardVector;
            set
            {
                value.Normalize();
                Vector3 vector2 = new Vector3(value.X, value.Y, 0f);
                Vector3 vector = Vector3.Normalize(new Vector3(value.Z, vector2.Length(), 0f));
                this.Rotation = new Vector3((float) (Math.Atan2((double) vector.X, (double) vector.Y) * 57.295779513082323), this.Rotation.Y, (float) (Math.Atan2((double) value.X, (double) value.Y) * -57.295779513082323));
            }
        }

        public Vector3 UpVector
        {
            get
            {
                IntPtr matrixAddress = this.MatrixAddress;
                return (!(matrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(matrixAddress + 0x20) : Vector3.RelativeTop);
            }
        }

        public Vector3 ForwardVector
        {
            get
            {
                IntPtr matrixAddress = this.MatrixAddress;
                return (!(matrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(matrixAddress + 0x10) : Vector3.RelativeFront);
            }
        }

        public Vector3 RightVector
        {
            get
            {
                IntPtr matrixAddress = this.MatrixAddress;
                return (!(matrixAddress == IntPtr.Zero) ? MemoryAccess.ReadVector3(matrixAddress) : Vector3.RelativeRight);
            }
        }

        public GTA.Math.Matrix Matrix
        {
            get
            {
                IntPtr matrixAddress = this.MatrixAddress;
                if (matrixAddress != IntPtr.Zero)
                {
                    return MemoryAccess.ReadMatrix(matrixAddress);
                }
                return new GTA.Math.Matrix();
            }
        }

        public float FieldOfView
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_CAM_FOV, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_FOV, arguments);
            }
        }

        public float NearClip
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_CAM_NEAR_CLIP, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_NEAR_CLIP, arguments);
            }
        }

        public float FarClip
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_CAM_FAR_CLIP, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_FAR_CLIP, arguments);
            }
        }

        public float NearDepthOfField
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_NEAR_DOF, arguments);
            }
        }

        public float FarDepthOfField
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<float>(Hash.GET_CAM_FAR_DOF, arguments);
            }
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_FAR_DOF, arguments);
            }
        }

        public float DepthOfFieldStrength
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_DOF_STRENGTH, arguments);
            }
        }

        public float MotionBlurStrength
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_MOTION_BLUR_STRENGTH, arguments);
            }
        }

        public bool IsShaking
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_CAM_SHAKING, arguments);
            }
        }

        public float ShakeAmplitude
        {
            set
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle, value };
                Function.Call(Hash.SET_CAM_SHAKE_AMPLITUDE, arguments);
            }
        }

        public bool IsInterpolating
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { base.Handle };
                return Function.Call<bool>(Hash.IS_CAM_INTERPOLATING, arguments);
            }
        }
    }
}

