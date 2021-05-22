// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.ForceToBodyPartHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class ForceToBodyPartHelper : CustomHelper
  {
    public ForceToBodyPartHelper(Ped ped)
      : base(ped, "forceToBodyPart")
    {
    }

    public int PartIndex
    {
      set
      {
        if (value > 28)
          value = 28;
        if (value < 0)
          value = 0;
        this.SetArgument("partIndex", value);
      }
    }

    public Vector3 Force
    {
      set => this.SetArgument("force", Vector3.Clamp(value, new Vector3(-100000f, -100000f, -100000f), new Vector3(100000f, 100000f, 100000f)));
    }

    public bool ForceDefinedInPartSpace
    {
      set => this.SetArgument("forceDefinedInPartSpace", value);
    }
  }
}
