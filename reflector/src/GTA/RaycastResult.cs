namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RaycastResult
    {
        public unsafe RaycastResult(int handle)
        {
            int num;
            NativeVector3 vector;
            NativeVector3 vector2;
            bool flag;
            this = new RaycastResult();
            InputArgument[] arguments = new InputArgument[] { handle, (IntPtr) &flag, (IntPtr) &vector2, (IntPtr) &vector, (IntPtr) &num };
            this.Result = Function.Call<int>(Hash.GET_SHAPE_TEST_RESULT, arguments);
            this.DitHit = flag;
            this.HitPosition = (Vector3) vector2;
            this.SurfaceNormal = (Vector3) vector;
            this.HitEntity = Entity.FromHandle(num);
        }

        public Entity HitEntity { get; private set; }
        public Vector3 HitPosition { get; private set; }
        public Vector3 SurfaceNormal { get; private set; }
        public bool DitHit { get; private set; }
        public bool DitHitEntity =>
            this.HitEntity != null;
        public int Result { get; private set; }
    }
}

