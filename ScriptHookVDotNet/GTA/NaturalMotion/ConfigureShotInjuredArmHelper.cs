// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ConfigureShotInjuredArmHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ConfigureShotInjuredArmHelper : CustomHelper
  {
    public ConfigureShotInjuredArmHelper(Ped ped)
      : base(ped, "configureShotInjuredArm")
    {
    }

    public float InjuredArmTime
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("injuredArmTime", value);
      }
    }

    public float HipYaw
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("hipYaw", value);
      }
    }

    public float HipRoll
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < -2.0)
          value = -2f;
        this.SetArgument("hipRoll", value);
      }
    }

    public float ForceStepExtraHeight
    {
      set
      {
        if ((double) value > 0.699999988079071)
          value = 0.7f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("forceStepExtraHeight", value);
      }
    }

    public bool ForceStep
    {
      set => this.SetArgument("forceStep", value);
    }

    public bool StepTurn
    {
      set => this.SetArgument("stepTurn", value);
    }

    public float VelMultiplierStart
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("velMultiplierStart", value);
      }
    }

    public float VelMultiplierEnd
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 1.0)
          value = 1f;
        this.SetArgument("velMultiplierEnd", value);
      }
    }

    public float VelForceStep
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("velForceStep", value);
      }
    }

    public float VelStepTurn
    {
      set
      {
        if ((double) value > 20.0)
          value = 20f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("velStepTurn", value);
      }
    }

    public bool VelScales
    {
      set => this.SetArgument("velScales", value);
    }
  }
}
