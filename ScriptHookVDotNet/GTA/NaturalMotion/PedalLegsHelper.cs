// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.PedalLegsHelper
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

namespace GTA.NaturalMotion
{
  public sealed class PedalLegsHelper : CustomHelper
  {
    public PedalLegsHelper(Ped ped)
      : base(ped, "pedalLegs")
    {
    }

    public bool PedalLeftLeg
    {
      set => this.SetArgument("pedalLeftLeg", value);
    }

    public bool PedalRightLeg
    {
      set => this.SetArgument("pedalRightLeg", value);
    }

    public bool BackPedal
    {
      set => this.SetArgument("backPedal", value);
    }

    public float Radius
    {
      set
      {
        if ((double) value > 2.0)
          value = 2f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("radius", value);
      }
    }

    public float AngularSpeed
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angularSpeed", value);
      }
    }

    public float LegStiffness
    {
      set
      {
        if ((double) value > 16.0)
          value = 16f;
        if ((double) value < 6.0)
          value = 6f;
        this.SetArgument("legStiffness", value);
      }
    }

    public float PedalOffset
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("pedalOffset", value);
      }
    }

    public int RandomSeed
    {
      set
      {
        if (value < 0)
          value = 0;
        this.SetArgument("randomSeed", value);
      }
    }

    public float SpeedAsymmetry
    {
      set
      {
        if ((double) value > 10.0)
          value = 10f;
        if ((double) value < -10.0)
          value = -10f;
        this.SetArgument("speedAsymmetry", value);
      }
    }

    public bool AdaptivePedal4Dragging
    {
      set => this.SetArgument("adaptivePedal4Dragging", value);
    }

    public float AngSpeedMultiplier4Dragging
    {
      set
      {
        if ((double) value > 100.0)
          value = 100f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("angSpeedMultiplier4Dragging", value);
      }
    }

    public float RadiusVariance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("radiusVariance", value);
      }
    }

    public float LegAngleVariance
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("legAngleVariance", value);
      }
    }

    public float CentreSideways
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("centreSideways", value);
      }
    }

    public float CentreForwards
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("centreForwards", value);
      }
    }

    public float CentreUp
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("centreUp", value);
      }
    }

    public float Ellipse
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("ellipse", value);
      }
    }

    public float DragReduction
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < 0.0)
          value = 0.0f;
        this.SetArgument("dragReduction", value);
      }
    }

    public float Spread
    {
      set
      {
        if ((double) value > 1.0)
          value = 1f;
        if ((double) value < -1.0)
          value = -1f;
        this.SetArgument("spread", value);
      }
    }

    public bool Hula
    {
      set => this.SetArgument("hula", value);
    }
  }
}
