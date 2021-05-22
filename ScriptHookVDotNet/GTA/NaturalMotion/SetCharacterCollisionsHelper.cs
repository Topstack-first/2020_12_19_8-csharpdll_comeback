// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetCharacterCollisionsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetCharacterCollisionsHelper : CustomHelper
  {
    public SetCharacterCollisionsHelper(Ped ped)
      : base(ped, "setCharacterCollisions")
    {
    }

    public float Spin
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("spin", value);
      }
    }

    public float MaxVelocity
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("maxVelocity", value);
      }
    }

    public bool ApplyToAll
    {
      set => this.SetArgument("applyToAll", value);
    }

    public bool ApplyToSpine
    {
      set => this.SetArgument("applyToSpine", value);
    }

    public bool ApplyToThighs
    {
      set => this.SetArgument("applyToThighs", value);
    }

    public bool ApplyToClavicles
    {
      set => this.SetArgument("applyToClavicles", value);
    }

    public bool ApplyToUpperArms
    {
      set => this.SetArgument("applyToUpperArms", value);
    }

    public bool FootSlip
    {
      set => this.SetArgument("footSlip", value);
    }

    public int VehicleClass
    {
      set
      {
        if (value > 100)
          value = 100;
        if (value < 0)
          value = 0;
        this.SetArgument("vehicleClass", value);
      }
    }
  }
}
