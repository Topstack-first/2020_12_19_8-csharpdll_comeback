// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.Message
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System.Collections.Generic;

namespace GTA.NaturalMotion
{
  public class Message
  {
    private readonly string _message;
    private readonly Dictionary<string, object> _arguments;
    private static readonly Dictionary<string, object> _stopArgument = new Dictionary<string, object>()
    {
      {
        "start",
        (object) false
      }
    };

    public Message(string message)
    {
      this._message = message;
      this._arguments = new Dictionary<string, object>();
    }

    public void Abort(Ped target) => MemoryAccess.SendEuphoriaMessage(target.Handle, this._message, Message._stopArgument);

    public void SendTo(Ped target)
    {
      if (!target.IsRagdoll)
      {
        if (!target.CanRagdoll)
          target.CanRagdoll = true;
        Function.Call(Hash.SET_PED_TO_RAGDOLL, (InputArgument) target.Handle, (InputArgument) 10000, (InputArgument) -1, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0);
      }
      this.SetArgument("start", true);
      MemoryAccess.SendEuphoriaMessage(target.Handle, this._message, this._arguments);
    }

    public void SendTo(Ped target, int duration)
    {
      if (!target.CanRagdoll)
        target.CanRagdoll = true;
      Function.Call(Hash.SET_PED_TO_RAGDOLL, (InputArgument) target.Handle, (InputArgument) 10000, (InputArgument) duration, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0);
      this.SendTo(target);
    }

    public void SetArgument(string argName, bool value) => this._arguments[argName] = (object) value;

    public void SetArgument(string argName, int value) => this._arguments[argName] = (object) value;

    public void SetArgument(string argName, float value) => this._arguments[argName] = (object) value;

    public void SetArgument(string argName, string value) => this._arguments[argName] = (object) value;

    public void SetArgument(string argName, Vector3 value) => this._arguments[argName] = (object) value;

    public void ResetArguments() => this._arguments.Clear();

    public override string ToString() => this._message;
  }
}
