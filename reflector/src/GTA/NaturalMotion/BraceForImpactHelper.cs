namespace GTA.NaturalMotion
{
    using GTA;
    using GTA.Math;
    using System;

    public sealed class BraceForImpactHelper : CustomHelper
    {
        public BraceForImpactHelper(Ped ped) : base(ped, "braceForImpact")
        {
        }

        public float BraceDistance
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
                base.SetArgument("braceDistance", value);
            }
        }

        public float TargetPredictionTime
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
                base.SetArgument("targetPredictionTime", value);
            }
        }

        public float ReachAbsorbtionTime
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
                base.SetArgument("reachAbsorbtionTime", value);
            }
        }

        public int InstanceIndex
        {
            set
            {
                if (value < -1)
                {
                    value = -1;
                }
                base.SetArgument("instanceIndex", value);
            }
        }

        public float BodyStiffness
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
                base.SetArgument("bodyStiffness", value);
            }
        }

        public bool GrabDontLetGo
        {
            set => 
                base.SetArgument("grabDontLetGo", value);
        }

        public float GrabStrength
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < -1f)
                {
                    value = -1f;
                }
                base.SetArgument("grabStrength", value);
            }
        }

        public float GrabDistance
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
                base.SetArgument("grabDistance", value);
            }
        }

        public float GrabReachAngle
        {
            set
            {
                if (value > 3.2f)
                {
                    value = 3.2f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("grabReachAngle", value);
            }
        }

        public float GrabHoldTimer
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
                base.SetArgument("grabHoldTimer", value);
            }
        }

        public float MaxGrabCarVelocity
        {
            set
            {
                if (value > 1000f)
                {
                    value = 1000f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("maxGrabCarVelocity", value);
            }
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

        public float TimeToBackwardsBrace
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
                base.SetArgument("timeToBackwardsBrace", value);
            }
        }

        public Vector3 Look
        {
            set => 
                base.SetArgument("look", value);
        }

        public Vector3 Pos
        {
            set => 
                base.SetArgument("pos", value);
        }

        public float MinBraceTime
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("minBraceTime", value);
            }
        }

        public float HandsDelayMin
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("handsDelayMin", value);
            }
        }

        public float HandsDelayMax
        {
            set
            {
                if (value > 3f)
                {
                    value = 3f;
                }
                if (value < 0f)
                {
                    value = 0f;
                }
                base.SetArgument("handsDelayMax", value);
            }
        }

        public bool MoveAway
        {
            set => 
                base.SetArgument("moveAway", value);
        }

        public float MoveAwayAmount
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
                base.SetArgument("moveAwayAmount", value);
            }
        }

        public float MoveAwayLean
        {
            set
            {
                if (value > 0.5f)
                {
                    value = 0.5f;
                }
                if (value < -0.5f)
                {
                    value = -0.5f;
                }
                base.SetArgument("moveAwayLean", value);
            }
        }

        public float MoveSideways
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
                base.SetArgument("moveSideways", value);
            }
        }

        public bool BbArms
        {
            set => 
                base.SetArgument("bbArms", value);
        }

        public bool NewBrace
        {
            set => 
                base.SetArgument("newBrace", value);
        }

        public bool BraceOnImpact
        {
            set => 
                base.SetArgument("braceOnImpact", value);
        }

        public bool Roll2Velocity
        {
            set => 
                base.SetArgument("roll2Velocity", value);
        }

        public int RollType
        {
            set
            {
                if (value > 3)
                {
                    value = 3;
                }
                if (value < 0)
                {
                    value = 0;
                }
                base.SetArgument("rollType", value);
            }
        }

        public bool SnapImpacts
        {
            set => 
                base.SetArgument("snapImpacts", value);
        }

        public float SnapImpact
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < -20f)
                {
                    value = -20f;
                }
                base.SetArgument("snapImpact", value);
            }
        }

        public float SnapBonnet
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < -20f)
                {
                    value = -20f;
                }
                base.SetArgument("snapBonnet", value);
            }
        }

        public float SnapFloor
        {
            set
            {
                if (value > 20f)
                {
                    value = 20f;
                }
                if (value < -20f)
                {
                    value = -20f;
                }
                base.SetArgument("snapFloor", value);
            }
        }

        public bool DampVel
        {
            set => 
                base.SetArgument("dampVel", value);
        }

        public float DampSpin
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
                base.SetArgument("dampSpin", value);
            }
        }

        public float DampUpVel
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
                base.SetArgument("dampUpVel", value);
            }
        }

        public float DampSpinThresh
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
                base.SetArgument("dampSpinThresh", value);
            }
        }

        public float DampUpVelThresh
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
                base.SetArgument("dampUpVelThresh", value);
            }
        }

        public bool GsHelp
        {
            set => 
                base.SetArgument("gsHelp", value);
        }

        public float GsEndMin
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("gsEndMin", value);
            }
        }

        public float GsSideMin
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("gsSideMin", value);
            }
        }

        public float GsSideMax
        {
            set
            {
                if (value > 1f)
                {
                    value = 1f;
                }
                if (value < -10f)
                {
                    value = -10f;
                }
                base.SetArgument("gsSideMax", value);
            }
        }

        public float GsUpness
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
                base.SetArgument("gsUpness", value);
            }
        }

        public float GsCarVelMin
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
                base.SetArgument("gsCarVelMin", value);
            }
        }

        public bool GsScale1Foot
        {
            set => 
                base.SetArgument("gsScale1Foot", value);
        }

        public float GsFricScale1
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
                base.SetArgument("gsFricScale1", value);
            }
        }

        public string GsFricMask1
        {
            set => 
                base.SetArgument("gsFricMask1", value);
        }

        public float GsFricScale2
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
                base.SetArgument("gsFricScale2", value);
            }
        }

        public string GsFricMask2
        {
            set => 
                base.SetArgument("gsFricMask2", value);
        }
    }
}

