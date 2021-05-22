// Decompiled with JetBrains decompiler
// Type: GTA.RequireScript
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;

namespace GTA
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class RequireScript : Attribute
  {
    internal Type _dependency;

    public RequireScript(Type dependency)
    {
      this._dependency = dependency;
      // ISSUE: explicit constructor call
      base.__2Ector();
    }
  }
}
