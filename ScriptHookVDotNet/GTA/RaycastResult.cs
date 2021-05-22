// Decompiled with JetBrains decompiler
// Type: GTA.RaycastResult
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;

namespace GTA
{
  public struct RaycastResult
  {
    public unsafe RaycastResult(int handle)
      : this()
    {
      bool flag;
      NativeVector3 nativeVector3_1;
      NativeVector3 nativeVector3_2;
      int handle1;
      this.Result = Function.Call<int>(Hash.GET_SHAPE_TEST_RESULT, (InputArgument) handle, (InputArgument) (void*) &flag, (InputArgument) (void*) &nativeVector3_1, (InputArgument) (void*) &nativeVector3_2, (InputArgument) (void*) &handle1);
      this.DitHit = flag;
      this.HitPosition = (Vector3) nativeVector3_1;
      this.SurfaceNormal = (Vector3) nativeVector3_2;
      this.HitEntity = Entity.FromHandle(handle1);
    }

    public Entity HitEntity { get; private set; }

    public Vector3 HitPosition { get; private set; }

    public Vector3 SurfaceNormal { get; private set; }

    public bool DitHit { get; private set; }

    public bool DitHitEntity => this.HitEntity != null;

    public int Result { get; private set; }
  }
}
