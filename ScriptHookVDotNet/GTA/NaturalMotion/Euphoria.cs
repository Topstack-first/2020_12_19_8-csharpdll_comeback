// Decompiled with JetBrains decompiler
// Type: GTA.NaturalMotion.Euphoria
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Collections.Generic;

namespace GTA.NaturalMotion
{
  public sealed class Euphoria
  {
    private readonly Ped _ped;
    private readonly Dictionary<string, CustomHelper> _helperCache;

    internal Euphoria(Ped ped)
    {
      this._ped = ped;
      this._helperCache = new Dictionary<string, CustomHelper>();
    }

    internal T GetHelper<T>(string message) where T : CustomHelper
    {
      CustomHelper instance;
      if (!this._helperCache.TryGetValue(message, out instance))
      {
        instance = (CustomHelper) Activator.CreateInstance(typeof (T), (object) this._ped);
        this._helperCache.Add(message, instance);
      }
      return (T) instance;
    }

    public ActivePoseHelper ActivePose => this.GetHelper<ActivePoseHelper>("activePose");

    public ApplyImpulseHelper ApplyImpulse => this.GetHelper<ApplyImpulseHelper>("applyImpulse");

    public ApplyBulletImpulseHelper ApplyBulletImpulse => this.GetHelper<ApplyBulletImpulseHelper>("applyBulletImpulse");

    public BodyRelaxHelper BodyRelax => this.GetHelper<BodyRelaxHelper>("bodyRelax");

    public ConfigureBalanceHelper ConfigureBalance => this.GetHelper<ConfigureBalanceHelper>("configureBalance");

    public ConfigureBalanceResetHelper ConfigureBalanceReset => this.GetHelper<ConfigureBalanceResetHelper>("configureBalanceReset");

    public ConfigureSelfAvoidanceHelper ConfigureSelfAvoidance => this.GetHelper<ConfigureSelfAvoidanceHelper>("configureSelfAvoidance");

    public ConfigureBulletsHelper ConfigureBullets => this.GetHelper<ConfigureBulletsHelper>("configureBullets");

    public ConfigureBulletsExtraHelper ConfigureBulletsExtra => this.GetHelper<ConfigureBulletsExtraHelper>("configureBulletsExtra");

    public ConfigureLimitsHelper ConfigureLimits => this.GetHelper<ConfigureLimitsHelper>("configureLimits");

    public ConfigureSoftLimitHelper ConfigureSoftLimit => this.GetHelper<ConfigureSoftLimitHelper>("configureSoftLimit");

    public ConfigureShotInjuredArmHelper ConfigureShotInjuredArm => this.GetHelper<ConfigureShotInjuredArmHelper>("configureShotInjuredArm");

    public ConfigureShotInjuredLegHelper ConfigureShotInjuredLeg => this.GetHelper<ConfigureShotInjuredLegHelper>("configureShotInjuredLeg");

    public DefineAttachedObjectHelper DefineAttachedObject => this.GetHelper<DefineAttachedObjectHelper>("defineAttachedObject");

    public ForceToBodyPartHelper ForceToBodyPart => this.GetHelper<ForceToBodyPartHelper>("forceToBodyPart");

    public LeanInDirectionHelper LeanInDirection => this.GetHelper<LeanInDirectionHelper>("leanInDirection");

    public LeanRandomHelper LeanRandom => this.GetHelper<LeanRandomHelper>("leanRandom");

    public LeanToPositionHelper LeanToPosition => this.GetHelper<LeanToPositionHelper>("leanToPosition");

    public LeanTowardsObjectHelper LeanTowardsObject => this.GetHelper<LeanTowardsObjectHelper>("leanTowardsObject");

    public HipsLeanInDirectionHelper HipsLeanInDirection => this.GetHelper<HipsLeanInDirectionHelper>("hipsLeanInDirection");

    public HipsLeanRandomHelper HipsLeanRandom => this.GetHelper<HipsLeanRandomHelper>("hipsLeanRandom");

    public HipsLeanToPositionHelper HipsLeanToPosition => this.GetHelper<HipsLeanToPositionHelper>("hipsLeanToPosition");

    public HipsLeanTowardsObjectHelper HipsLeanTowardsObject => this.GetHelper<HipsLeanTowardsObjectHelper>("hipsLeanTowardsObject");

    public ForceLeanInDirectionHelper ForceLeanInDirection => this.GetHelper<ForceLeanInDirectionHelper>("forceLeanInDirection");

    public ForceLeanRandomHelper ForceLeanRandom => this.GetHelper<ForceLeanRandomHelper>("forceLeanRandom");

    public ForceLeanToPositionHelper ForceLeanToPosition => this.GetHelper<ForceLeanToPositionHelper>("forceLeanToPosition");

    public ForceLeanTowardsObjectHelper ForceLeanTowardsObject => this.GetHelper<ForceLeanTowardsObjectHelper>("forceLeanTowardsObject");

    public SetStiffnessHelper SetStiffness => this.GetHelper<SetStiffnessHelper>("setStiffness");

    public SetMuscleStiffnessHelper SetMuscleStiffness => this.GetHelper<SetMuscleStiffnessHelper>("setMuscleStiffness");

    public SetWeaponModeHelper SetWeaponMode => this.GetHelper<SetWeaponModeHelper>("setWeaponMode");

    public RegisterWeaponHelper RegisterWeapon => this.GetHelper<RegisterWeaponHelper>("registerWeapon");

    public ShotRelaxHelper ShotRelax => this.GetHelper<ShotRelaxHelper>("shotRelax");

    public FireWeaponHelper FireWeapon => this.GetHelper<FireWeaponHelper>("fireWeapon");

    public ConfigureConstraintsHelper ConfigureConstraints => this.GetHelper<ConfigureConstraintsHelper>("configureConstraints");

    public StayUprightHelper StayUpright => this.GetHelper<StayUprightHelper>("stayUpright");

    public StopAllBehavioursHelper StopAllBehaviours => this.GetHelper<StopAllBehavioursHelper>("stopAllBehaviours");

    public SetCharacterStrengthHelper SetCharacterStrength => this.GetHelper<SetCharacterStrengthHelper>("setCharacterStrength");

    public SetCharacterHealthHelper SetCharacterHealth => this.GetHelper<SetCharacterHealthHelper>("setCharacterHealth");

    public SetFallingReactionHelper SetFallingReaction => this.GetHelper<SetFallingReactionHelper>("setFallingReaction");

    public SetCharacterUnderwaterHelper SetCharacterUnderwater => this.GetHelper<SetCharacterUnderwaterHelper>("setCharacterUnderwater");

    public SetCharacterCollisionsHelper SetCharacterCollisions => this.GetHelper<SetCharacterCollisionsHelper>("setCharacterCollisions");

    public SetCharacterDampingHelper SetCharacterDamping => this.GetHelper<SetCharacterDampingHelper>("setCharacterDamping");

    public SetFrictionScaleHelper SetFrictionScale => this.GetHelper<SetFrictionScaleHelper>("setFrictionScale");

    public AnimPoseHelper AnimPose => this.GetHelper<AnimPoseHelper>("animPose");

    public ArmsWindmillHelper ArmsWindmill => this.GetHelper<ArmsWindmillHelper>("armsWindmill");

    public ArmsWindmillAdaptiveHelper ArmsWindmillAdaptive => this.GetHelper<ArmsWindmillAdaptiveHelper>("armsWindmillAdaptive");

    public BalancerCollisionsReactionHelper BalancerCollisionsReaction => this.GetHelper<BalancerCollisionsReactionHelper>("balancerCollisionsReaction");

    public BodyBalanceHelper BodyBalance => this.GetHelper<BodyBalanceHelper>("bodyBalance");

    public BodyFoetalHelper BodyFoetal => this.GetHelper<BodyFoetalHelper>("bodyFoetal");

    public BodyRollUpHelper BodyRollUp => this.GetHelper<BodyRollUpHelper>("bodyRollUp");

    public BodyWritheHelper BodyWrithe => this.GetHelper<BodyWritheHelper>("bodyWrithe");

    public BraceForImpactHelper BraceForImpact => this.GetHelper<BraceForImpactHelper>("braceForImpact");

    public BuoyancyHelper Buoyancy => this.GetHelper<BuoyancyHelper>("buoyancy");

    public CatchFallHelper CatchFall => this.GetHelper<CatchFallHelper>("catchFall");

    public ElectrocuteHelper Electrocute => this.GetHelper<ElectrocuteHelper>("electrocute");

    public FallOverWallHelper FallOverWall => this.GetHelper<FallOverWallHelper>("fallOverWall");

    public GrabHelper Grab => this.GetHelper<GrabHelper>("grab");

    public HeadLookHelper HeadLook => this.GetHelper<HeadLookHelper>("headLook");

    public HighFallHelper HighFall => this.GetHelper<HighFallHelper>("highFall");

    public IncomingTransformsHelper IncomingTransforms => this.GetHelper<IncomingTransformsHelper>("incomingTransforms");

    public InjuredOnGroundHelper InjuredOnGround => this.GetHelper<InjuredOnGroundHelper>("injuredOnGround");

    public CarriedHelper Carried => this.GetHelper<CarriedHelper>("carried");

    public DangleHelper Dangle => this.GetHelper<DangleHelper>("dangle");

    public OnFireHelper OnFire => this.GetHelper<OnFireHelper>("onFire");

    public PedalLegsHelper PedalLegs => this.GetHelper<PedalLegsHelper>("pedalLegs");

    public PointArmHelper PointArm => this.GetHelper<PointArmHelper>("pointArm");

    public PointGunHelper PointGun => this.GetHelper<PointGunHelper>("pointGun");

    public PointGunExtraHelper PointGunExtra => this.GetHelper<PointGunExtraHelper>("pointGunExtra");

    public RollDownStairsHelper RollDownStairs => this.GetHelper<RollDownStairsHelper>("rollDownStairs");

    public ShotHelper Shot => this.GetHelper<ShotHelper>("shot");

    public ShotNewBulletHelper ShotNewBullet => this.GetHelper<ShotNewBulletHelper>("shotNewBullet");

    public ShotSnapHelper ShotSnap => this.GetHelper<ShotSnapHelper>("shotSnap");

    public ShotShockSpinHelper ShotShockSpin => this.GetHelper<ShotShockSpinHelper>("shotShockSpin");

    public ShotFallToKneesHelper ShotFallToKnees => this.GetHelper<ShotFallToKneesHelper>("shotFallToKnees");

    public ShotFromBehindHelper ShotFromBehind => this.GetHelper<ShotFromBehindHelper>("shotFromBehind");

    public ShotInGutsHelper ShotInGuts => this.GetHelper<ShotInGutsHelper>("shotInGuts");

    public ShotHeadLookHelper ShotHeadLook => this.GetHelper<ShotHeadLookHelper>("shotHeadLook");

    public ShotConfigureArmsHelper ShotConfigureArms => this.GetHelper<ShotConfigureArmsHelper>("shotConfigureArms");

    public SmartFallHelper SmartFall => this.GetHelper<SmartFallHelper>("smartFall");

    public StaggerFallHelper StaggerFall => this.GetHelper<StaggerFallHelper>("staggerFall");

    public TeeterHelper Teeter => this.GetHelper<TeeterHelper>("teeter");

    public UpperBodyFlinchHelper UpperBodyFlinch => this.GetHelper<UpperBodyFlinchHelper>("upperBodyFlinch");

    public YankedHelper Yanked => this.GetHelper<YankedHelper>("yanked");
  }
}
