// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ShotRelaxHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class ShotRelaxHelper : CustomHelper
  {
    public ShotRelaxHelper(Ped ped)
      : base(ped, "shotRelax")
    {
    }

    public float RelaxPeriodUpper
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("relaxPeriodUpper", value);
      }
    }

    public float RelaxPeriodLower
    {
      set
      {
        if ((double) value > 40.0)
          value = 40f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("relaxPeriodLower", value);
      }
    }
  }
}
