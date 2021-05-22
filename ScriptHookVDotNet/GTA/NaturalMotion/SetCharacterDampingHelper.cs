// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.SetCharacterDampingHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class SetCharacterDampingHelper : CustomHelper
  {
    public SetCharacterDampingHelper(Ped ped)
      : base(ped, "setCharacterDamping")
    {
    }

    public float SomersaultThresh
    {
      set
      {
        if ((double) value > 200.0)
          value = 200f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("somersaultThresh", value);
      }
    }

    public float SomersaultDamp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("somersaultDamp", value);
      }
    }

    public float CartwheelThresh
    {
      set
      {
        if ((double) value > 200.0)
          value = 200f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cartwheelThresh", value);
      }
    }

    public float CartwheelDamp
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("cartwheelDamp", value);
      }
    }

    public float VehicleCollisionTime
    {
      set
      {
        if ((double) value > 1000.0)
          value = 1000f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("vehicleCollisionTime", value);
      }
    }

    public bool V2
    {
      set => this.SetArgument("v2", value);
    }
  }
}
