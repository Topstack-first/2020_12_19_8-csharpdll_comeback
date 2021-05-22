// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.CustomHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public abstract class CustomHelper
  {
    private readonly Ped _ped;
    private readonly Message _message;

    protected CustomHelper(Ped target, string message)
    {
      this._ped = target;
      this._message = new Message(message);
    }

    public void Start()
    {
      this._message.SendTo(this._ped);
      this._message.ResetArguments();
    }

    public void Start(int duration)
    {
      this._message.SendTo(this._ped, duration);
      this._message.ResetArguments();
    }

    public void Stop() => this._message.Abort(this._ped);

    public void SetArgument(string argName, bool value) => this._message.SetArgument(argName, value);

    public void SetArgument(string argName, int value) => this._message.SetArgument(argName, value);

    public void SetArgument(string argName, float value) => this._message.SetArgument(argName, value);

    public void SetArgument(string argName, string value) => this._message.SetArgument(argName, value);

    public void SetArgument(string argName, Vector3 value) => this._message.SetArgument(argName, value);

    public void ResetArguments() => this._message.ResetArguments();

    public override string ToString() => this._message.ToString();
  }
}
