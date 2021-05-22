// Decompiled with JetBrains decompiler
// Type: GTA.ISpatial
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA
{
  public interface ISpatial
  {
    Vector3 Position { get; set; }

    Vector3 Rotation { get; set; }
  }
}
