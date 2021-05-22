// Decompiled with JetBrains decompiler
// Type: GTA.UI.Notification
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;

namespace GTA.UI
{
  public sealed class Notification
  {
    private int _handle;

    internal Notification(int handle) => this._handle = handle;

    public void Hide() => Function.Call(Hash._REMOVE_NOTIFICATION, (InputArgument) this._handle);
  }
}
