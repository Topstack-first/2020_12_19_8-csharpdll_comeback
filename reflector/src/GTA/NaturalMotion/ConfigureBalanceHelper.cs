namespace GTA.NaturalMotion
{
    using GTA;
    using System;

    public sealed class ConfigureBalanceHelper : CustomHelper
    {
        public ConfigureBalanceHelper(Ped ped) : base(ped, "configureBalance")
        {
        }

        public float StepHeight
        {
            set
            {
                if (value > 0.4f)
                {
                    value = 0.4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stepHeight", value);
            }
        }

        public float StepHeightInc4Step
        {
            set
            {
                if (value > 0.4f)
                {
                    value = 0.4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stepHeightInc4Step", value);
            }
        }

        public float LegsApartRestep
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legsApartRestep", value);
            }
        }

        public float LegsTogetherRestep
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legsTogetherRestep", value);
            }
        }

        public float LegsApartMax
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("legsApartMax", value);
            }
        }

        public bool TaperKneeStrength
        {
            set => 
                base.SetArgument("taperKneeStrength", value);
        }

        public float LegStiffness
        {
            set
            {
                if (value > 16f)
                {
                    value = 16f;
                }
                if (value < 6f)
                {
                    value = 6f;
                }
                base.SetArgument("legStiffness", value);
            }
        }

        public float LeftLegSwingDamping
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0.2f)
                {
                    value = 0.2f;
                }
                base.SetArgument("leftLegSwingDamping", value);
            }
        }

        public float RightLegSwingDamping
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0.2f)
                {
                    value = 0.2f;
                }
                base.SetArgument("rightLegSwingDamping", value);
            }
        }

        public float OpposeGravityLegs
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("opposeGravityLegs", value);
            }
        }

        public float OpposeGravityAnkles
        {
            set
            {
                if (value > 4f)
                {
                    value = 4f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("opposeGravityAnkles", value);
            }
        }

        public float LeanAcc
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanAcc", value);
            }
        }

        public float HipLeanAcc
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("hipLeanAcc", value);
            }
        }

        public float LeanAccMax
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanAccMax", value);
            }
        }

        public float ResistAcc
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("resistAcc", value);
            }
        }

        public float ResistAccMax
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("resistAccMax", value);
            }
        }

        public bool FootSlipCompOnMovingFloor
        {
            set => 
                base.SetArgument("footSlipCompOnMovingFloor", value);
        }

        public float AnkleEquilibrium
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("ankleEquilibrium", value);
            }
        }

        public float ExtraFeetApart
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("extraFeetApart", value);
            }
        }

        public float DontStepTime
        {
            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("dontStepTime", value);
            }
        }

        public float BalanceAbortThreshold
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("balanceAbortThreshold", value);
            }
        }

        public float GiveUpHeight
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("giveUpHeight", value);
            }
        }

        public float StepClampScale
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stepClampScale", value);
            }
        }

        public float StepClampScaleVariance
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("stepClampScaleVariance", value);
            }
        }

        public float PredictionTimeHip
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("predictionTimeHip", value);
            }
        }

        public float PredictionTime
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("predictionTime", value);
            }
        }

        public float PredictionTimeVariance
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("predictionTimeVariance", value);
            }
        }

        public int MaxSteps
        {
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                base.SetArgument("maxSteps", value);
            }
        }

        public float MaxBalanceTime
        {
            set
            {
                if (value < 1f)
                {
                    value = 1f;
                }
                base.SetArgument("maxBalanceTime", value);
            }
        }

        public int ExtraSteps
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("extraSteps", value);
            }
        }

        public float ExtraTime
        {
            set
            {
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("extraTime", value);
            }
        }

        public GTA.NaturalMotion.FallType FallType
        {
            set => 
                base.SetArgument("fallType", (int) value);
        }

        public float FallMult
        {
            set
            {
                if (value > 100f)
                {
                    value = 100f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("fallMult", value);
            }
        }

        public bool FallReduceGravityComp
        {
            set => 
                base.SetArgument("fallReduceGravityComp", value);
        }

        public bool RampHipPitchOnFail
        {
            set => 
                base.SetArgument("rampHipPitchOnFail", value);
        }

        public float StableLinSpeedThresh
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stableLinSpeedThresh", value);
            }
        }

        public float StableRotSpeedThresh
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stableRotSpeedThresh", value);
            }
        }

        public bool FailMustCollide
        {
            set => 
                base.SetArgument("failMustCollide", value);
        }

        public bool IgnoreFailure
        {
            set => 
                base.SetArgument("ignoreFailure", value);
        }

        public float ChangeStepTime
        {
            set
            {
                if (value > 5f)
                {
                    value = 5f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("changeStepTime", value);
            }
        }

        public bool BalanceIndefinitely
        {
            set => 
                base.SetArgument("balanceIndefinitely", value);
        }

        public bool MovingFloor
        {
            set => 
                base.SetArgument("movingFloor", value);
        }

        public bool AirborneStep
        {
            set => 
                base.SetArgument("airborneStep", value);
        }

        public float UseComDirTurnVelThresh
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("useComDirTurnVelThresh", value);
            }
        }

        public float MinKneeAngle
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < -0.5f)
                {
                    value = -0.5f;
                }
                base.SetArgument("minKneeAngle", value);
            }
        }

        public bool FlatterSwingFeet
        {
            set => 
                base.SetArgument("flatterSwingFeet", value);
        }

        public bool FlatterStaticFeet
        {
            set => 
                base.SetArgument("flatterStaticFeet", value);
        }

        public bool AvoidLeg
        {
            set => 
                base.SetArgument("avoidLeg", value);
        }

        public float AvoidFootWidth
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("avoidFootWidth", value);
            }
        }

        public float AvoidFeedback
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("avoidFeedback", value);
            }
        }

        public float LeanAgainstVelocity
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanAgainstVelocity", value);
            }
        }

        public float StepDecisionThreshold
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("stepDecisionThreshold", value);
            }
        }

        public bool StepIfInSupport
        {
            set => 
                base.SetArgument("stepIfInSupport", value);
        }

        public bool AlwaysStepWithFarthest
        {
            set => 
                base.SetArgument("alwaysStepWithFarthest", value);
        }

        public bool StandUp
        {
            set => 
                base.SetArgument("standUp", value);
        }

        public float DepthFudge
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("depthFudge", value);
            }
        }

        public float DepthFudgeStagger
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("depthFudgeStagger", value);
            }
        }

        public float FootFriction
        {
            set
            {
                if (value > 40f)
                {
                    value = 40f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("footFriction", value);
            }
        }

        public float FootFrictionStagger
        {
            set
            {
                if (value > 40f)
                {
                    value = 40f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("footFrictionStagger", value);
            }
        }

        public float BackwardsLeanCutoff
        {
            set
            {
                if (value > 2f)
                {
                    value = 2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("backwardsLeanCutoff", value);
            }
        }

        public float GiveUpHeightEnd
        {
            set
            {
                if (value > 1.5f)
                {
                    value = 1.5f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("giveUpHeightEnd", value);
            }
        }

        public float BalanceAbortThresholdEnd
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("balanceAbortThresholdEnd", value);
            }
        }

        public float GiveUpRampDuration
        {
            set
            {
                if (value > 10f)
                {
                    value = 10f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("giveUpRampDuration", value);
            }
        }

        public float LeanToAbort
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("leanToAbort", value);
            }
        }
    }
}

