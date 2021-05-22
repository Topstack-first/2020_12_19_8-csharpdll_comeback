// Decompiled with JetBrains decompiler
// Type: GTA.PoolObject
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;

namespace GTA
{
  public abstract class PoolObject : INativeValue, IDeletable, IExistable
  {
    protected PoolObject(int handle) => this.Handle = handle;

    public int Handle { get; protected set; }

    public ulong NativeValue
    {
      get => (ulong) this.Handle;
      set => this.Handle = (int) value;
    }

    public abstract bool Exists();

    public abstract void Delete();
  }
}
