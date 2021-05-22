// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureSoftLimitHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureSoftLimitHelper : CustomHelper
  {
    public ConfigureSoftLimitHelper(Ped ped)
      : base(ped, "configureSoftLimit")
    {
    }

    public int Index
    {
      set
      {
        if (value > 3)
          value = 3;
        if (value < 0)
          value = 0;
        this.SetArgument("index", value);
      }
    }

    public float Stiffness
    {
      set
      {
        if ((double) value > 30.0)
          value = 30f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("stiffness", value);
      }
    }

    public float Damping
    {
      set
      {
        if ((double) value > 1.10000002384186)
          value = 1.1f;
        if ((double) value < 0.899999976158142)
          value = 0.9f;
        this.SetArgument("damping", value);
      }
    }

    public float LimitAngle
    {
      set
      {
        if ((double) value > 6.30000019073486)
          value = 6.3f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("limitAngle", value);
      }
    }

    public int ApproachDirection
    {
      set
      {
        if (value > 1)
          value = 1;
        if (value < -1)
          value = -1;
        this.SetArgument("approachDirection", value);
      }
    }

    public bool VelocityScaled
    {
      set => this.SetArgument("velocityScaled", value);
    }
  }
}
