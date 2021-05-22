// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.UpperBodyFlinchHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;

namespace GTA.NaturalMotion
{
  public sealed class UpperBodyFlinchHelper : CustomHelper
  {
    public UpperBodyFlinchHelper(Ped ped)
      : base(ped, "upperBodyFlinch")
    {
    }

    public float HandDistanceLeftRight
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handDistanceLeftRight", value);
      }
    }

    public float HandDistanceFrontBack
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handDistanceFrontBack", value);
      }
    }

    public float HandDistanceVertical
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("handDistanceVertical", value);
      }
    }

    public float BodyStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("bodyStiffness", value);
      }
    }

    public float BodyDamping
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("bodyDamping", value);
      }
    }

    public float BackBendAmount
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("backBendAmount", value);
      }
    }

    public bool UseRightArm
    {
      set => this.SetArgument("useRightArm", value);
    }

    public bool UseLeftArm
    {
      set => this.SetArgument("useLeftArm", value);
    }

    public float NoiseScale
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("noiseScale", value);
      }
    }

    public bool NewHit
    {
      set => this.SetArgument("newHit", value);
    }

    public bool ProtectHeadToggle
    {
      set => this.SetArgument("protectHeadToggle", value);
    }

    public bool DontBraceHead
    {
      set => this.SetArgument("dontBraceHead", value);
    }

    public bool ApplyStiffness
    {
      set => this.SetArgument("applyStiffness", value);
    }

    public bool HeadLookAwayFromTarget
    {
      set => this.SetArgument("headLookAwayFromTarget", value);
    }

    public bool UseHeadLook
    {
      set => this.SetArgument("useHeadLook", value);
    }

    public int TurnTowards
    {
      set
      {
        if (value > 2)
          value = 2;
        if (value < -2)
          value = -2;
        this.SetArgument("turnTowards", value);
      }
    }

    public Vector3 Pos
    {
      set => this.SetArgument("pos", value);
    }
  }
}
