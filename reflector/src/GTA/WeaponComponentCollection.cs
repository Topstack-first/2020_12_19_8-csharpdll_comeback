namespace GTA
{
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class WeaponComponentCollection
    {
        private readonly Ped _owner;
        private readonly Weapon _weapon;
        private readonly Dictionary<WeaponComponentHash, WeaponComponent> _weaponComponents = new Dictionary<WeaponComponentHash, WeaponComponent>();
        private readonly WeaponComponentHash[] _components;
        private static readonly InvalidWeaponComponent _invalidComponent = new InvalidWeaponComponent();

        internal WeaponComponentCollection(Ped owner, Weapon weapon)
        {
            this._owner = owner;
            this._weapon = weapon;
            this._components = GetComponentsFromHash(weapon.Hash);
        }

        public WeaponComponent GetClipComponent(int index)
        {
            WeaponComponent component2;
            using (IEnumerator<WeaponComponent> enumerator = this.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        WeaponComponent current = enumerator.Current;
                        if ((current.AttachmentPoint != ((ComponentAttachmentPoint) (-571619404))) && (current.AttachmentPoint != ComponentAttachmentPoint.Clip2))
                        {
                            continue;
                        }
                        if (index-- != 0)
                        {
                            continue;
                        }
                        component2 = current;
                    }
                    else
                    {
                        return _invalidComponent;
                    }
                    break;
                }
            }
            return component2;
        }

        public static unsafe WeaponComponentHash[] GetComponentsFromHash(WeaponHash hash)
        {
            if (hash <= ((WeaponHash) (-2084633992)))
            {
                if (hash <= WeaponHash.APPistol)
                {
                    if (hash <= WeaponHash.HeavySniper)
                    {
                        if (hash == WeaponHash.SniperRifle)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.SniperRifleClip01, WeaponComponentHash.AtScopeLarge, WeaponComponentHash.AtScopeMax, WeaponComponentHash.AtArSupp02, WeaponComponentHash.SniperRifleVarmodLuxe };
                        }
                        if (hash == WeaponHash.CombatPDW)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.CombatPDWClip01, WeaponComponentHash.CombatPDWClip02, WeaponComponentHash.CombatPDWClip03, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeSmall, WeaponComponentHash.AtArAfGrip };
                        }
                        if (hash == WeaponHash.HeavySniper)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.HeavySniperClip01, WeaponComponentHash.AtScopeLarge, WeaponComponentHash.AtScopeMax };
                        }
                    }
                    else if (hash <= WeaponHash.Pistol)
                    {
                        if (hash == WeaponHash.MicroSMG)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.MicroSMGClip01, WeaponComponentHash.MicroSMGClip02, WeaponComponentHash.AtPiFlsh, WeaponComponentHash.AtScopeMacro, WeaponComponentHash.AtArSupp02, WeaponComponentHash.MicroSMGVarmodLuxe };
                        }
                        if (hash == WeaponHash.Pistol)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.PistolClip01, WeaponComponentHash.PistolClip02, WeaponComponentHash.AtPiFlsh, WeaponComponentHash.AtPiSupp02, WeaponComponentHash.PistolVarmodLuxe };
                        }
                    }
                    else
                    {
                        if (hash == WeaponHash.PumpShotgun)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.AtSrSupp, WeaponComponentHash.AtArFlsh, WeaponComponentHash.PumpShotgunVarmodLowrider };
                        }
                        if (hash == WeaponHash.APPistol)
                        {
                            return new WeaponComponentHash[] { WeaponComponentHash.APPistolClip01, WeaponComponentHash.APPistolClip02, WeaponComponentHash.AtPiFlsh, WeaponComponentHash.AtPiSupp, WeaponComponentHash.APPistolVarmodLuxe };
                        }
                    }
                }
                else if (hash <= WeaponHash.CombatPistol)
                {
                    if (hash == WeaponHash.SMG)
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.SMGClip01, WeaponComponentHash.SMGClip02, WeaponComponentHash.SMGClip03, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtPiSupp, WeaponComponentHash.AtScopeMacro02, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.SMGVarmodLuxe };
                    }
                    if (hash == WeaponHash.Minigun)
                    {
                        return new WeaponComponentHash[] { ((WeaponComponentHash) (-924946682)) };
                    }
                    if (hash == WeaponHash.CombatPistol)
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.CombatPistolClip01, WeaponComponentHash.CombatPistolClip02, WeaponComponentHash.AtPiFlsh, WeaponComponentHash.AtPiSupp, WeaponComponentHash.CombatPistolVarmodLowrider };
                    }
                }
                else if (hash > WeaponHash.BullpupRifle)
                {
                    if (hash == WeaponHash.CombatMG)
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.CombatMGClip01, WeaponComponentHash.CombatMGClip02, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtScopeMedium, WeaponComponentHash.CombatMGVarmodLowrider };
                    }
                    if (hash == ((WeaponHash) (-2084633992)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.CarbineRifleClip01, WeaponComponentHash.CarbineRifleClip02, WeaponComponentHash.CarbineRifleClip03, WeaponComponentHash.AtRailCover01, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeMedium, WeaponComponentHash.AtArSupp, WeaponComponentHash.CarbineRifleVarmodLuxe };
                    }
                }
                else
                {
                    if (hash == WeaponHash.SawnOffShotgun)
                    {
                        return new WeaponComponentHash[] { ((WeaponComponentHash) (-2052698631)) };
                    }
                    if (hash == WeaponHash.BullpupRifle)
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.BullpupRifleClip01, WeaponComponentHash.BullpupRifleClip02, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeSmall, WeaponComponentHash.AtArSupp, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.BullpupRifleVarmodLow };
                    }
                }
            }
            else if (hash <= ((WeaponHash) (-1074790547)))
            {
                if (hash <= ((WeaponHash) (-1654528753)))
                {
                    if (hash == ((WeaponHash) (-1716589765)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.Pistol50Clip01, WeaponComponentHash.Pistol50Clip02, WeaponComponentHash.AtPiFlsh, WeaponComponentHash.AtArSupp02, WeaponComponentHash.Pistol50VarmodLuxe };
                    }
                    if (hash == ((WeaponHash) (-1660422300)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.MGClip01, WeaponComponentHash.MGClip02, WeaponComponentHash.AtScopeSmall02, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.MGVarmodLowrider };
                    }
                    if (hash == ((WeaponHash) (-1654528753)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtArSupp02 };
                    }
                }
                else if (hash <= ((WeaponHash) (-1357824103)))
                {
                    if (hash == ((WeaponHash) (-1568386805)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeSmall };
                    }
                    if (hash == ((WeaponHash) (-1357824103)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.AdvancedRifleClip01, WeaponComponentHash.AdvancedRifleClip02, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeSmall, WeaponComponentHash.AtArSupp, WeaponComponentHash.AdvancedRifleVarmodLuxe };
                    }
                }
                else
                {
                    if (hash == ((WeaponHash) (-1076751822)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.SNSPistolClip01, WeaponComponentHash.SNSPistolClip02, WeaponComponentHash.SNSPistolVarmodLowrider };
                    }
                    if (hash == ((WeaponHash) (-1074790547)))
                    {
                        return new WeaponComponentHash[] { WeaponComponentHash.AssaultRifleClip01, WeaponComponentHash.AssaultRifleClip02, WeaponComponentHash.AssaultRifleClip03, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeMacro, WeaponComponentHash.AtArSupp02, WeaponComponentHash.AssaultRifleVarmodLuxe };
                    }
                }
            }
            else if (hash <= ((WeaponHash) (-656458692)))
            {
                if (hash == ((WeaponHash) (-1063057011)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.SpecialCarbineClip01, WeaponComponentHash.SpecialCarbineClip02, WeaponComponentHash.SpecialCarbineClip03, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeMedium, WeaponComponentHash.AtArSupp02, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.SpecialCarbineVarmodLowrider };
                }
                if (hash == ((WeaponHash) (-1045183535)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.RevolverClip01, WeaponComponentHash.RevolverVarmodBoss, WeaponComponentHash.RevolverVarmodGoon };
                }
                if (hash == ((WeaponHash) (-656458692)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.KnuckleVarmodPimp, WeaponComponentHash.KnuckleVarmodBallas, WeaponComponentHash.KnuckleVarmodDollar, WeaponComponentHash.KnuckleVarmodDiamond, WeaponComponentHash.KnuckleVarmodHate, WeaponComponentHash.KnuckleVarmodLove, WeaponComponentHash.KnuckleVarmodPlayer, WeaponComponentHash.KnuckleVarmodKing, WeaponComponentHash.KnuckleVarmodVagos };
                }
            }
            else if (hash > ((WeaponHash) (-538741184)))
            {
                if (hash == ((WeaponHash) (-494615257)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.AssaultShotgunClip01, WeaponComponentHash.AssaultShotgunClip02, WeaponComponentHash.AtArAfGrip, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtArSupp };
                }
                if (hash == ((WeaponHash) (-270015777)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.AssaultSMGClip01, WeaponComponentHash.AssaultSMGClip02, WeaponComponentHash.AtArFlsh, WeaponComponentHash.AtScopeMacro, WeaponComponentHash.AtArSupp02, WeaponComponentHash.AssaultSMGVarmodLowrider };
                }
            }
            else
            {
                if (hash == ((WeaponHash) (-619010992)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.MachinePistolClip01, WeaponComponentHash.MachinePistolClip02, WeaponComponentHash.MachinePistolClip03, WeaponComponentHash.AtPiSupp };
                }
                if (hash == ((WeaponHash) (-538741184)))
                {
                    return new WeaponComponentHash[] { WeaponComponentHash.SwitchbladeVarmodVar1, ((WeaponComponentHash) (-409758110)) };
                }
            }
            WeaponComponentHash[] hashArray = null;
            int num2 = 0;
            int num3 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, Array.Empty<InputArgument>());
            while (num2 < num3)
            {
                DlcWeaponData data2;
                InputArgument[] arguments = new InputArgument[] { num2, (IntPtr) &data2 };
                if (Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, arguments) && (data2.Hash == hash))
                {
                    InputArgument[] argumentArray2 = new InputArgument[] { num2 };
                    hashArray = new WeaponComponentHash[Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, argumentArray2)];
                    for (int i = 0; i < hashArray.Length; i++)
                    {
                        DlcWeaponComponentData data;
                        InputArgument[] argumentArray3 = new InputArgument[] { num2, i, (IntPtr) &data };
                        hashArray[i] = !Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, argumentArray3) ? ((WeaponComponentHash) (-1)) : data.Hash;
                    }
                    return hashArray;
                }
                num2++;
            }
            return new WeaponComponentHash[0];
        }

        public IEnumerator<WeaponComponent> GetEnumerator()
        {
            WeaponComponent[] componentArray = new WeaponComponent[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                componentArray[i] = this[this._components[i]];
            }
            return componentArray.GetEnumerator();
        }

        public WeaponComponent GetFlashLightComponent()
        {
            WeaponComponent component2;
            using (IEnumerator<WeaponComponent> enumerator = this.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        WeaponComponent current = enumerator.Current;
                        if ((current.AttachmentPoint != ComponentAttachmentPoint.FlashLaser) && (current.AttachmentPoint != ((ComponentAttachmentPoint) (-1572840598))))
                        {
                            continue;
                        }
                        component2 = current;
                    }
                    else
                    {
                        return _invalidComponent;
                    }
                    break;
                }
            }
            return component2;
        }

        public WeaponComponent GetLuxuryFinishComponent()
        {
            WeaponComponent component2;
            using (IEnumerator<WeaponComponent> enumerator = this.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        WeaponComponent current = enumerator.Current;
                        if (current.AttachmentPoint != ComponentAttachmentPoint.GunRoot)
                        {
                            continue;
                        }
                        component2 = current;
                    }
                    else
                    {
                        return _invalidComponent;
                    }
                    break;
                }
            }
            return component2;
        }

        public WeaponComponent GetScopeComponent(int index)
        {
            WeaponComponent component2;
            using (IEnumerator<WeaponComponent> enumerator = this.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        WeaponComponent current = enumerator.Current;
                        if ((current.AttachmentPoint != ComponentAttachmentPoint.Scope) && (current.AttachmentPoint != ComponentAttachmentPoint.Scope2))
                        {
                            continue;
                        }
                        if (index-- != 0)
                        {
                            continue;
                        }
                        component2 = current;
                    }
                    else
                    {
                        return _invalidComponent;
                    }
                    break;
                }
            }
            return component2;
        }

        public WeaponComponent GetSuppressorComponent()
        {
            WeaponComponent component2;
            using (IEnumerator<WeaponComponent> enumerator = this.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        WeaponComponent current = enumerator.Current;
                        if ((current.AttachmentPoint != ComponentAttachmentPoint.Supp) && (current.AttachmentPoint != ComponentAttachmentPoint.Supp2))
                        {
                            continue;
                        }
                        component2 = current;
                    }
                    else
                    {
                        return _invalidComponent;
                    }
                    break;
                }
            }
            return component2;
        }

        public WeaponComponent this[WeaponComponentHash componentHash]
        {
            get
            {
                if (!this._components.Contains<WeaponComponentHash>(componentHash))
                {
                    return _invalidComponent;
                }
                WeaponComponent component = null;
                if (!this._weaponComponents.TryGetValue(componentHash, out component))
                {
                    component = new WeaponComponent(this._owner, this._weapon, componentHash);
                    this._weaponComponents.Add(componentHash, component);
                }
                return component;
            }
        }

        public WeaponComponent this[int index]
        {
            get
            {
                WeaponComponent component = null;
                if ((index < 0) || (index >= this.Count))
                {
                    return _invalidComponent;
                }
                WeaponComponentHash key = this._components[index];
                if (!this._weaponComponents.TryGetValue(key, out component))
                {
                    component = new WeaponComponent(this._owner, this._weapon, key);
                    this._weaponComponents.Add(key, component);
                }
                return component;
            }
        }

        public int Count =>
            this._components.Length;

        public int ClipVariationsCount
        {
            get
            {
                int num = 0;
                foreach (WeaponComponent component in this)
                {
                    if ((component.AttachmentPoint == ((ComponentAttachmentPoint) (-571619404))) || (component.AttachmentPoint == ComponentAttachmentPoint.Clip2))
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int ScopeVariationsCount
        {
            get
            {
                int num = 0;
                foreach (WeaponComponent component in this)
                {
                    if ((component.AttachmentPoint == ComponentAttachmentPoint.Scope) || (component.AttachmentPoint == ComponentAttachmentPoint.Scope2))
                    {
                        num++;
                    }
                }
                return num;
            }
        }
    }
}

