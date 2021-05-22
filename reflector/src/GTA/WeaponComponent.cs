namespace GTA
{
    using GTA.Native;
    using System;

    public class WeaponComponent
    {
        protected readonly Ped _owner;
        protected readonly Weapon _weapon;
        protected readonly WeaponComponentHash _component;

        internal WeaponComponent(Ped owner, Weapon weapon, WeaponComponentHash component)
        {
            this._owner = owner;
            this._weapon = weapon;
            this._component = component;
        }

        public static unsafe ComponentAttachmentPoint GetAttachmentPoint(WeaponHash hash, WeaponComponentHash componentHash)
        {
            int num;
            if (hash > WeaponHash.SawnOffShotgun)
            {
                if (hash > ((WeaponHash) (-1654528753)))
                {
                    if (hash > ((WeaponHash) (-1357824103)))
                    {
                        if (hash == ((WeaponHash) (-1074790547)))
                        {
                            if (componentHash > ((WeaponComponentHash) (-1657815255)))
                            {
                                if (componentHash > ((WeaponComponentHash) (-1323216997)))
                                {
                                    if ((componentHash == ((WeaponComponentHash) (-1101075946))) || (componentHash == ((WeaponComponentHash) (-604986051))))
                                    {
                                        goto TR_00EA;
                                    }
                                }
                                else
                                {
                                    if (componentHash == ((WeaponComponentHash) (-1489156508)))
                                    {
                                        return ComponentAttachmentPoint.Supp;
                                    }
                                    if (componentHash == ((WeaponComponentHash) (-1323216997)))
                                    {
                                        goto TR_00EA;
                                    }
                                }
                                goto TR_00E0;
                            }
                            else
                            {
                                if (componentHash <= WeaponComponentHash.AssaultRifleVarmodLuxe)
                                {
                                    if (componentHash == WeaponComponentHash.AtArAfGrip)
                                    {
                                        return (ComponentAttachmentPoint) (-1322016827);
                                    }
                                    if (componentHash == WeaponComponentHash.AssaultRifleVarmodLuxe)
                                    {
                                        return ComponentAttachmentPoint.GunRoot;
                                    }
                                }
                                else
                                {
                                    if (componentHash == WeaponComponentHash.AtArFlsh)
                                    {
                                        return ComponentAttachmentPoint.FlashLaser;
                                    }
                                    if (componentHash == ((WeaponComponentHash) (-1657815255)))
                                    {
                                        return ComponentAttachmentPoint.Scope;
                                    }
                                }
                                goto TR_00E0;
                            }
                            goto TR_00EA;
                        }
                        else
                        {
                            if (hash == ((WeaponHash) (-494615257)))
                            {
                                if (componentHash <= WeaponComponentHash.AtArFlsh)
                                {
                                    if (componentHash == WeaponComponentHash.AtArAfGrip)
                                    {
                                        return (ComponentAttachmentPoint) (-1322016827);
                                    }
                                    if (componentHash == WeaponComponentHash.AtArFlsh)
                                    {
                                        return ComponentAttachmentPoint.FlashLaser;
                                    }
                                }
                                else
                                {
                                    if (componentHash == ((WeaponComponentHash) (-2089531990)))
                                    {
                                        return ComponentAttachmentPoint.Supp;
                                    }
                                    if ((componentHash == ((WeaponComponentHash) (-2034401422))) || (componentHash == ((WeaponComponentHash) (-1796727865))))
                                    {
                                        return (ComponentAttachmentPoint) (-571619404);
                                    }
                                }
                                return (ComponentAttachmentPoint) (-1);
                            }
                            if (hash == ((WeaponHash) (-270015777)))
                            {
                                if (componentHash > ((WeaponComponentHash) (-1928132688)))
                                {
                                    if (componentHash == ((WeaponComponentHash) (-1657815255)))
                                    {
                                        return ComponentAttachmentPoint.Scope;
                                    }
                                    if (componentHash == ((WeaponComponentHash) (-1489156508)))
                                    {
                                        return ComponentAttachmentPoint.Supp;
                                    }
                                    if (componentHash != ((WeaponComponentHash) (-1152981993)))
                                    {
                                        goto TR_00C7;
                                    }
                                }
                                else
                                {
                                    if (componentHash == WeaponComponentHash.AssaultSMGVarmodLowrider)
                                    {
                                        return ComponentAttachmentPoint.GunRoot;
                                    }
                                    if (componentHash == WeaponComponentHash.AtArFlsh)
                                    {
                                        return ComponentAttachmentPoint.FlashLaser;
                                    }
                                    if (componentHash != ((WeaponComponentHash) (-1928132688)))
                                    {
                                        goto TR_00C7;
                                    }
                                }
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                        }
                    }
                    else
                    {
                        if (hash == ((WeaponHash) (-1568386805)))
                        {
                            if (componentHash <= WeaponComponentHash.GrenadeLauncherClip01)
                            {
                                if (componentHash == WeaponComponentHash.AtArAfGrip)
                                {
                                    return (ComponentAttachmentPoint) (-1322016827);
                                }
                                if (componentHash == WeaponComponentHash.GrenadeLauncherClip01)
                                {
                                    return (ComponentAttachmentPoint) (-1322016827);
                                }
                            }
                            else
                            {
                                if (componentHash == WeaponComponentHash.AtArFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == ((WeaponComponentHash) (-1439939148)))
                                {
                                    return ComponentAttachmentPoint.Scope;
                                }
                            }
                            return (ComponentAttachmentPoint) (-1);
                        }
                        if (hash == ((WeaponHash) (-1357824103)))
                        {
                            if (componentHash > ((WeaponComponentHash) (-2089531990)))
                            {
                                if (componentHash != ((WeaponComponentHash) (-1899902599)))
                                {
                                    if (componentHash == ((WeaponComponentHash) (-1439939148)))
                                    {
                                        return ComponentAttachmentPoint.Scope;
                                    }
                                    if (componentHash != ((WeaponComponentHash) (-91250417)))
                                    {
                                        goto TR_00AE;
                                    }
                                }
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                            else
                            {
                                if (componentHash == WeaponComponentHash.AdvancedRifleVarmodLuxe)
                                {
                                    return ComponentAttachmentPoint.GunRoot;
                                }
                                if (componentHash == WeaponComponentHash.AtArFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == ((WeaponComponentHash) (-2089531990)))
                                {
                                    return ComponentAttachmentPoint.Supp;
                                }
                            }
                            goto TR_00AE;
                        }
                    }
                }
                else if (hash > ((WeaponHash) (-2084633992)))
                {
                    if (hash == ((WeaponHash) (-1716589765)))
                    {
                        if (componentHash > WeaponComponentHash.AtPiFlsh)
                        {
                            if (componentHash == WeaponComponentHash.Pistol50VarmodLuxe)
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            if (componentHash == ((WeaponComponentHash) (-1489156508)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                            if (componentHash != ((WeaponComponentHash) (-640439150)))
                            {
                                goto TR_00A1;
                            }
                        }
                        else if (componentHash != WeaponComponentHash.Pistol50Clip01)
                        {
                            if (componentHash == WeaponComponentHash.AtPiFlsh)
                            {
                                return ComponentAttachmentPoint.FlashLaser;
                            }
                            goto TR_00A1;
                        }
                        return (ComponentAttachmentPoint) (-571619404);
                    }
                    else if (hash == ((WeaponHash) (-1660422300)))
                    {
                        if (componentHash > ((WeaponComponentHash) (-2112517305)))
                        {
                            if (componentHash == ((WeaponComponentHash) (-690308418)))
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            if (componentHash != ((WeaponComponentHash) (-197857404)))
                            {
                                goto TR_0097;
                            }
                        }
                        else
                        {
                            if (componentHash == WeaponComponentHash.AtScopeSmall02)
                            {
                                return ComponentAttachmentPoint.Scope;
                            }
                            if (componentHash != ((WeaponComponentHash) (-2112517305)))
                            {
                                goto TR_0097;
                            }
                        }
                        return (ComponentAttachmentPoint) (-571619404);
                    }
                    else if (hash == ((WeaponHash) (-1654528753)))
                    {
                        if (componentHash <= WeaponComponentHash.AtArFlsh)
                        {
                            if (componentHash == WeaponComponentHash.AtArAfGrip)
                            {
                                return (ComponentAttachmentPoint) (-1322016827);
                            }
                            if (componentHash == WeaponComponentHash.AtArFlsh)
                            {
                                return ComponentAttachmentPoint.FlashLaser;
                            }
                        }
                        else
                        {
                            if (componentHash == ((WeaponComponentHash) (-1489156508)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                            if (componentHash == ((WeaponComponentHash) (-917613298)))
                            {
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                        }
                        return (ComponentAttachmentPoint) (-1);
                    }
                }
                else
                {
                    if (hash == WeaponHash.CombatMG)
                    {
                        if (componentHash <= ((WeaponComponentHash) (-1828795171)))
                        {
                            if (componentHash == WeaponComponentHash.AtArAfGrip)
                            {
                                return (ComponentAttachmentPoint) (-1322016827);
                            }
                            if (componentHash == ((WeaponComponentHash) (-1828795171)))
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                        }
                        else
                        {
                            if (componentHash == ((WeaponComponentHash) (-1596416958)))
                            {
                                return ComponentAttachmentPoint.Scope;
                            }
                            if ((componentHash == ((WeaponComponentHash) (-691692330))) || (componentHash == ((WeaponComponentHash) (-503336118))))
                            {
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                        }
                        return (ComponentAttachmentPoint) (-1);
                    }
                    if (hash == ((WeaponHash) (-2084633992)))
                    {
                        if (componentHash > ((WeaponComponentHash) (-2089531990)))
                        {
                            if (componentHash > ((WeaponComponentHash) (-1614924820)))
                            {
                                if (componentHash == ((WeaponComponentHash) (-1596416958)))
                                {
                                    return ComponentAttachmentPoint.Scope;
                                }
                                if (componentHash == ((WeaponComponentHash) (-1167922891)))
                                {
                                    goto TR_0077;
                                }
                                else if (componentHash == ((WeaponComponentHash) (-660892072)))
                                {
                                    return ComponentAttachmentPoint.GunRoot;
                                }
                            }
                            else if ((componentHash == ((WeaponComponentHash) (-1861183855))) || (componentHash == ((WeaponComponentHash) (-1614924820))))
                            {
                                goto TR_0077;
                            }
                            goto TR_006D;
                        }
                        else
                        {
                            if (componentHash <= WeaponComponentHash.AtRailCover01)
                            {
                                if (componentHash == WeaponComponentHash.AtArAfGrip)
                                {
                                    return (ComponentAttachmentPoint) (-1322016827);
                                }
                                if (componentHash == WeaponComponentHash.AtRailCover01)
                                {
                                    return (ComponentAttachmentPoint) (-1843287667);
                                }
                            }
                            else
                            {
                                if (componentHash == WeaponComponentHash.AtArFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == ((WeaponComponentHash) (-2089531990)))
                                {
                                    return ComponentAttachmentPoint.Supp;
                                }
                            }
                            goto TR_006D;
                        }
                        goto TR_0077;
                    }
                }
                goto TR_000D;
            }
            else if (hash > WeaponHash.PumpShotgun)
            {
                if (hash > WeaponHash.SMG)
                {
                    if (hash == WeaponHash.Minigun)
                    {
                        return ((componentHash != ((WeaponComponentHash) (-924946682))) ? ((ComponentAttachmentPoint) (-1)) : ((ComponentAttachmentPoint) (-571619404)));
                    }
                    if (hash == WeaponHash.CombatPistol)
                    {
                        if (componentHash > WeaponComponentHash.AtPiFlsh)
                        {
                            if (componentHash == ((WeaponComponentHash) (-1023114086)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                            if (componentHash == ((WeaponComponentHash) (-966439566)))
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            if (componentHash != ((WeaponComponentHash) (-696561875)))
                            {
                                goto TR_005D;
                            }
                        }
                        else if (componentHash != WeaponComponentHash.CombatPistolClip01)
                        {
                            if (componentHash == WeaponComponentHash.AtPiFlsh)
                            {
                                return ComponentAttachmentPoint.FlashLaser;
                            }
                            goto TR_005D;
                        }
                        return (ComponentAttachmentPoint) (-571619404);
                    }
                    else if (hash == WeaponHash.SawnOffShotgun)
                    {
                        return ((componentHash == ((WeaponComponentHash) (-2052698631))) ? ComponentAttachmentPoint.GunRoot : ((componentHash != ((WeaponComponentHash) (-942267867))) ? ((ComponentAttachmentPoint) (-1)) : ((ComponentAttachmentPoint) (-571619404))));
                    }
                }
                else
                {
                    if (hash == WeaponHash.APPistol)
                    {
                        if (componentHash <= WeaponComponentHash.APPistolClip01)
                        {
                            if ((componentHash == WeaponComponentHash.APPistolClip02) || (componentHash == WeaponComponentHash.APPistolClip01))
                            {
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                        }
                        else
                        {
                            if (componentHash == WeaponComponentHash.AtPiFlsh)
                            {
                                return ComponentAttachmentPoint.FlashLaser;
                            }
                            if (componentHash == ((WeaponComponentHash) (-1686714580)))
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            if (componentHash == ((WeaponComponentHash) (-1023114086)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                        }
                        return (ComponentAttachmentPoint) (-1);
                    }
                    if (hash == WeaponHash.SMG)
                    {
                        if (componentHash > WeaponComponentHash.SMGClip02)
                        {
                            if (componentHash > WeaponComponentHash.SMGClip03)
                            {
                                if (componentHash == WeaponComponentHash.AtArFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == ((WeaponComponentHash) (-1023114086)))
                                {
                                    return ComponentAttachmentPoint.Supp;
                                }
                                goto TR_0040;
                            }
                            else
                            {
                                if (componentHash == WeaponComponentHash.AtScopeMacro02)
                                {
                                    return ComponentAttachmentPoint.Scope;
                                }
                                if (componentHash != WeaponComponentHash.SMGClip03)
                                {
                                    goto TR_0040;
                                }
                            }
                            goto TR_0041;
                        }
                        else
                        {
                            if (componentHash != WeaponComponentHash.SMGClip01)
                            {
                                if (componentHash == WeaponComponentHash.SMGVarmodLuxe)
                                {
                                    return ComponentAttachmentPoint.GunRoot;
                                }
                                if (componentHash != WeaponComponentHash.SMGClip02)
                                {
                                    goto TR_0040;
                                }
                            }
                            goto TR_0041;
                        }
                        goto TR_0040;
                    }
                }
                goto TR_000D;
            }
            else
            {
                if (hash > WeaponHash.HeavySniper)
                {
                    if (hash == WeaponHash.MicroSMG)
                    {
                        if (componentHash > WeaponComponentHash.MicroSMGVarmodLuxe)
                        {
                            if (componentHash == ((WeaponComponentHash) (-1657815255)))
                            {
                                return ComponentAttachmentPoint.Scope;
                            }
                            if (componentHash == ((WeaponComponentHash) (-1489156508)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                            if (componentHash != ((WeaponComponentHash) (-884429072)))
                            {
                                goto TR_0031;
                            }
                        }
                        else if (componentHash != WeaponComponentHash.MicroSMGClip02)
                        {
                            if (componentHash == WeaponComponentHash.AtPiFlsh)
                            {
                                return ComponentAttachmentPoint.FlashLaser;
                            }
                            if (componentHash == WeaponComponentHash.MicroSMGVarmodLuxe)
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            goto TR_0031;
                        }
                        return (ComponentAttachmentPoint) (-571619404);
                    }
                    else
                    {
                        if (hash == WeaponHash.Pistol)
                        {
                            if (componentHash <= WeaponComponentHash.AtPiSupp02)
                            {
                                if (componentHash == WeaponComponentHash.AtPiFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == WeaponComponentHash.AtPiSupp02)
                                {
                                    return ComponentAttachmentPoint.Supp;
                                }
                            }
                            else
                            {
                                if (componentHash == ((WeaponComponentHash) (-684126074)))
                                {
                                    return ComponentAttachmentPoint.GunRoot;
                                }
                                if ((componentHash == ((WeaponComponentHash) (-316253668))) || (componentHash == ((WeaponComponentHash) (-19858063))))
                                {
                                    return (ComponentAttachmentPoint) (-571619404);
                                }
                            }
                            return (ComponentAttachmentPoint) (-1);
                        }
                        if (hash == WeaponHash.PumpShotgun)
                        {
                            if (componentHash <= ((WeaponComponentHash) (-2089531990)))
                            {
                                if (componentHash == WeaponComponentHash.AtArFlsh)
                                {
                                    return ComponentAttachmentPoint.FlashLaser;
                                }
                                if (componentHash == ((WeaponComponentHash) (-2089531990)))
                                {
                                    return ComponentAttachmentPoint.Supp;
                                }
                            }
                            else
                            {
                                if (componentHash == ((WeaponComponentHash) (-1562927653)))
                                {
                                    return ComponentAttachmentPoint.GunRoot;
                                }
                                if (componentHash == ((WeaponComponentHash) (-781249480)))
                                {
                                    return (ComponentAttachmentPoint) (-571619404);
                                }
                            }
                            return (ComponentAttachmentPoint) (-1);
                        }
                    }
                }
                else
                {
                    if (hash == WeaponHash.SniperRifle)
                    {
                        if (componentHash <= ((WeaponComponentHash) (-1681506167)))
                        {
                            if (componentHash == WeaponComponentHash.SniperRifleVarmodLuxe)
                            {
                                return ComponentAttachmentPoint.GunRoot;
                            }
                            if (componentHash == ((WeaponComponentHash) (-1681506167)))
                            {
                                return (ComponentAttachmentPoint) (-571619404);
                            }
                        }
                        else
                        {
                            if (componentHash == ((WeaponComponentHash) (-1489156508)))
                            {
                                return ComponentAttachmentPoint.Supp;
                            }
                            if ((componentHash == ((WeaponComponentHash) (-1135289737))) || (componentHash == ((WeaponComponentHash) (-767279652))))
                            {
                                return ComponentAttachmentPoint.Scope;
                            }
                        }
                        return (ComponentAttachmentPoint) (-1);
                    }
                    if (hash == WeaponHash.HeavySniper)
                    {
                        return ((componentHash == WeaponComponentHash.HeavySniperClip01) ? ((ComponentAttachmentPoint) (-571619404)) : (((componentHash == ((WeaponComponentHash) (-1135289737))) || (componentHash == ((WeaponComponentHash) (-767279652)))) ? ComponentAttachmentPoint.Scope : ((ComponentAttachmentPoint) (-1))));
                    }
                }
                goto TR_000D;
            }
            goto TR_0040;
        TR_000D:
            num = 0;
            int num4 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, Array.Empty<InputArgument>());
            while (true)
            {
                if (num < num4)
                {
                    DlcWeaponData data2;
                    InputArgument[] arguments = new InputArgument[] { num, (IntPtr) &data2 };
                    if (!Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, arguments) || (data2.Hash != hash))
                    {
                        num++;
                        continue;
                    }
                    InputArgument[] argumentArray2 = new InputArgument[] { num };
                    int num3 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, argumentArray2);
                    for (int i = 0; i < num3; i++)
                    {
                        DlcWeaponComponentData data;
                        InputArgument[] argumentArray3 = new InputArgument[] { num, i, (IntPtr) &data };
                        if (Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, argumentArray3) && (data.Hash == componentHash))
                        {
                            return data.AttachPoint;
                        }
                    }
                }
                return (ComponentAttachmentPoint) (-1);
            }
        TR_0031:
            return (ComponentAttachmentPoint) (-1);
        TR_0040:
            return (ComponentAttachmentPoint) (-1);
        TR_0041:
            return (ComponentAttachmentPoint) (-571619404);
        TR_005D:
            return (ComponentAttachmentPoint) (-1);
        TR_006D:
            return (ComponentAttachmentPoint) (-1);
        TR_0077:
            return (ComponentAttachmentPoint) (-571619404);
        TR_0097:
            return (ComponentAttachmentPoint) (-1);
        TR_00A1:
            return (ComponentAttachmentPoint) (-1);
        TR_00AE:
            return (ComponentAttachmentPoint) (-1);
        TR_00C7:
            return (ComponentAttachmentPoint) (-1);
        TR_00E0:
            return (ComponentAttachmentPoint) (-1);
        TR_00EA:
            return (ComponentAttachmentPoint) (-571619404);
        }

        public static unsafe string GetComponentDisplayNameFromHash(WeaponHash hash, WeaponComponentHash component)
        {
            string str;
            if (hash != ((WeaponHash) (-656458692)))
            {
                if (component > ((WeaponComponentHash) (-1861183855)))
                {
                    if (component > ((WeaponComponentHash) (-890514874)))
                    {
                        if (component > ((WeaponComponentHash) (-604986051)))
                        {
                            if (component > ((WeaponComponentHash) (-316253668)))
                            {
                                if (component > ((WeaponComponentHash) (-124428919)))
                                {
                                    if ((component == ((WeaponComponentHash) (-91250417))) || (component == ((WeaponComponentHash) (-19858063))))
                                    {
                                        goto TR_0027;
                                    }
                                    else if (component == ((WeaponComponentHash) (-1)))
                                    {
                                        return "WCT_INVALID";
                                    }
                                }
                                else if ((component == ((WeaponComponentHash) (-197857404))) || ((component == ((WeaponComponentHash) (-125817127))) || (component == ((WeaponComponentHash) (-124428919)))))
                                {
                                    goto TR_0027;
                                }
                            }
                            else if (component > ((WeaponComponentHash) (-435637410)))
                            {
                                if (component == ((WeaponComponentHash) (-409758110)))
                                {
                                    return "WCT_SB_VAR2";
                                }
                                if (component == ((WeaponComponentHash) (-377062173)))
                                {
                                    return "WCT_CLIP1";
                                }
                                if (component == ((WeaponComponentHash) (-316253668)))
                                {
                                    goto TR_002D;
                                }
                            }
                            else if (component == ((WeaponComponentHash) (-507117574)))
                            {
                                goto TR_002D;
                            }
                            else if (component == ((WeaponComponentHash) (-503336118)))
                            {
                                goto TR_0027;
                            }
                            else if (component == ((WeaponComponentHash) (-435637410)))
                            {
                                goto TR_0062;
                            }
                        }
                        else if (component > ((WeaponComponentHash) (-691692330)))
                        {
                            if (component > ((WeaponComponentHash) (-667205311)))
                            {
                                if (component == ((WeaponComponentHash) (-660892072)))
                                {
                                    goto TR_002B;
                                }
                                else if (component == ((WeaponComponentHash) (-640439150)))
                                {
                                    goto TR_002D;
                                }
                                else if (component == ((WeaponComponentHash) (-604986051)))
                                {
                                    goto TR_0057;
                                }
                            }
                            else if ((component == ((WeaponComponentHash) (-690308418))) || (component == ((WeaponComponentHash) (-684126074))))
                            {
                                goto TR_002B;
                            }
                            else if (component == ((WeaponComponentHash) (-667205311)))
                            {
                                goto TR_0027;
                            }
                        }
                        else if (component > ((WeaponComponentHash) (-855823675)))
                        {
                            if (component == ((WeaponComponentHash) (-767279652)))
                            {
                                return "WCT_SCOPE_LRG";
                            }
                            if ((component == ((WeaponComponentHash) (-696561875))) || (component == ((WeaponComponentHash) (-691692330))))
                            {
                                goto TR_002D;
                            }
                        }
                        else if ((component == ((WeaponComponentHash) (-884429072))) || (component == ((WeaponComponentHash) (-878820883))))
                        {
                            goto TR_0027;
                        }
                        else if (component == ((WeaponComponentHash) (-855823675)))
                        {
                            goto TR_002D;
                        }
                    }
                    else if (component > ((WeaponComponentHash) (-1489156508)))
                    {
                        if (component > ((WeaponComponentHash) (-1152981993)))
                        {
                            if (component > ((WeaponComponentHash) (-1023114086)))
                            {
                                if (component == ((WeaponComponentHash) (-966439566)))
                                {
                                    goto TR_002B;
                                }
                                else if (component == ((WeaponComponentHash) (-924946682)))
                                {
                                    goto TR_002D;
                                }
                                else if (component == ((WeaponComponentHash) (-890514874)))
                                {
                                    goto TR_0027;
                                }
                            }
                            else
                            {
                                if (component == ((WeaponComponentHash) (-1135289737)))
                                {
                                    return "WCT_SCOPE_MAX";
                                }
                                if (component == ((WeaponComponentHash) (-1101075946)))
                                {
                                    goto TR_0027;
                                }
                                else if (component == ((WeaponComponentHash) (-1023114086)))
                                {
                                    goto TR_0062;
                                }
                            }
                        }
                        else if (component > ((WeaponComponentHash) (-1323216997)))
                        {
                            if (component == ((WeaponComponentHash) (-1188271751)))
                            {
                                goto TR_002D;
                            }
                            else
                            {
                                if (component == ((WeaponComponentHash) (-1167922891)))
                                {
                                    return "WCT_CLIP_BOX";
                                }
                                if (component == ((WeaponComponentHash) (-1152981993)))
                                {
                                    goto TR_002D;
                                }
                            }
                        }
                        else if (component == ((WeaponComponentHash) (-1470645128)))
                        {
                            goto TR_003A;
                        }
                        else
                        {
                            if (component == ((WeaponComponentHash) (-1439939148)))
                            {
                                return "WCT_SCOPE_SML";
                            }
                            if (component == ((WeaponComponentHash) (-1323216997)))
                            {
                                goto TR_002D;
                            }
                        }
                    }
                    else if (component > ((WeaponComponentHash) (-1686714580)))
                    {
                        if (component > ((WeaponComponentHash) (-1614924820)))
                        {
                            if (component == ((WeaponComponentHash) (-1596416958)))
                            {
                                return "WCT_SCOPE_MED";
                            }
                            if (component == ((WeaponComponentHash) (-1562927653)))
                            {
                                goto TR_002B;
                            }
                            else if (component == ((WeaponComponentHash) (-1489156508)))
                            {
                                goto TR_0062;
                            }
                        }
                        else if (component == ((WeaponComponentHash) (-1681506167)))
                        {
                            goto TR_0027;
                        }
                        else
                        {
                            if (component == ((WeaponComponentHash) (-1657815255)))
                            {
                                return "WCT_SCOPE_MAC";
                            }
                            if (component == ((WeaponComponentHash) (-1614924820)))
                            {
                                goto TR_0027;
                            }
                        }
                    }
                    else if (component > ((WeaponComponentHash) (-1802258419)))
                    {
                        if (component == ((WeaponComponentHash) (-1796727865)))
                        {
                            goto TR_0027;
                        }
                        else if (component == ((WeaponComponentHash) (-1759709443)))
                        {
                            goto TR_002D;
                        }
                        else if (component == ((WeaponComponentHash) (-1686714580)))
                        {
                            goto TR_003A;
                        }
                    }
                    else
                    {
                        if (component == ((WeaponComponentHash) (-1858624256)))
                        {
                            return "WCT_SB_BASE";
                        }
                        if (component == ((WeaponComponentHash) (-1828795171)))
                        {
                            goto TR_0052;
                        }
                        else if (component == ((WeaponComponentHash) (-1802258419)))
                        {
                            return "WCT_REV_VARG";
                        }
                    }
                    goto TR_000D;
                }
                else if (component > WeaponComponentHash.VintagePistolClip01)
                {
                    if (component > WeaponComponentHash.SMGClip03)
                    {
                        if (component > ((WeaponComponentHash) (-2089531990)))
                        {
                            if (component > ((WeaponComponentHash) (-2000168365)))
                            {
                                if (component == ((WeaponComponentHash) (-1928132688)))
                                {
                                    goto TR_0027;
                                }
                                else if ((component == ((WeaponComponentHash) (-1899902599))) || (component == ((WeaponComponentHash) (-1861183855))))
                                {
                                    goto TR_002D;
                                }
                            }
                            else if (component == ((WeaponComponentHash) (-2052698631)))
                            {
                                goto TR_003A;
                            }
                            else if (component == ((WeaponComponentHash) (-2034401422)))
                            {
                                goto TR_002D;
                            }
                            else if (component == ((WeaponComponentHash) (-2000168365)))
                            {
                                goto TR_0057;
                            }
                        }
                        else
                        {
                            if (component > WeaponComponentHash.AtArFlsh)
                            {
                                if (component == ((WeaponComponentHash) (-2144080721)))
                                {
                                    goto TR_0046;
                                }
                                else if (component != ((WeaponComponentHash) (-2112517305)))
                                {
                                    if (component == ((WeaponComponentHash) (-2089531990)))
                                    {
                                        goto TR_0062;
                                    }
                                    goto TR_000D;
                                }
                            }
                            else if (component == WeaponComponentHash.HeavyPistolVarmodLuxe)
                            {
                                goto TR_0046;
                            }
                            else if (component != WeaponComponentHash.SNSPistolClip02)
                            {
                                if (component == WeaponComponentHash.AtArFlsh)
                                {
                                    goto TR_003C;
                                }
                                goto TR_000D;
                            }
                            goto TR_002D;
                        }
                        goto TR_000D;
                    }
                    else if (component > WeaponComponentHash.SwitchbladeVarmodVar1)
                    {
                        if (component > WeaponComponentHash.SpecialCarbineVarmodLowrider)
                        {
                            if (component == WeaponComponentHash.AtRailCover01)
                            {
                                return "WCT_RAIL";
                            }
                            if (component == WeaponComponentHash.Pistol50VarmodLuxe)
                            {
                                return "WCT_VAR_SIL";
                            }
                            if (component == WeaponComponentHash.SMGClip03)
                            {
                                goto TR_0057;
                            }
                        }
                        else
                        {
                            if (component == WeaponComponentHash.AtPiSupp02)
                            {
                                return "WCT_SUPP";
                            }
                            if (component == ((WeaponComponentHash) 0x6cbf371b))
                            {
                                goto TR_002D;
                            }
                            else if (component == WeaponComponentHash.SpecialCarbineVarmodLowrider)
                            {
                                goto TR_0052;
                            }
                        }
                        goto TR_000D;
                    }
                    else
                    {
                        if (component > WeaponComponentHash.MicroSMGVarmodLuxe)
                        {
                            if (component == WeaponComponentHash.AssaultRifleVarmodLuxe)
                            {
                                goto TR_002B;
                            }
                            else if (component == ((WeaponComponentHash) 0x5af49386))
                            {
                                goto TR_0027;
                            }
                            else if (component == WeaponComponentHash.SwitchbladeVarmodVar1)
                            {
                                return "WCT_SB_VAR1";
                            }
                        }
                        else if ((component == WeaponComponentHash.MachinePistolClip01) || (component == WeaponComponentHash.HeavySniperClip01))
                        {
                            goto TR_0027;
                        }
                        else if (component == WeaponComponentHash.MicroSMGVarmodLuxe)
                        {
                            goto TR_002B;
                        }
                        goto TR_000D;
                    }
                    goto TR_002D;
                }
                else if (component > WeaponComponentHash.APPistolClip01)
                {
                    if (component > WeaponComponentHash.AdvancedRifleVarmodLuxe)
                    {
                        if (component > ((WeaponComponentHash) 0x3e7e6956))
                        {
                            if (component == WeaponComponentHash.SniperRifleVarmodLuxe)
                            {
                                goto TR_0046;
                            }
                            else if ((component != WeaponComponentHash.CombatPDWClip01) && (component != WeaponComponentHash.VintagePistolClip01))
                            {
                                goto TR_000D;
                            }
                            goto TR_0027;
                        }
                        else
                        {
                            if (component == WeaponComponentHash.AtScopeSmall02)
                            {
                                return "WCT_SCOPE_SML";
                            }
                            if (component == WeaponComponentHash.AtScopeMacro02)
                            {
                                return "WCT_SCOPE_MAC";
                            }
                            if (component != ((WeaponComponentHash) 0x3e7e6956))
                            {
                                goto TR_000D;
                            }
                        }
                    }
                    else if (component > WeaponComponentHash.VintagePistolClip02)
                    {
                        if (component != WeaponComponentHash.SMGClip02)
                        {
                            if (component == WeaponComponentHash.AtPiFlsh)
                            {
                                goto TR_003C;
                            }
                            else if (component == WeaponComponentHash.AdvancedRifleVarmodLuxe)
                            {
                                goto TR_003A;
                            }
                            goto TR_000D;
                        }
                    }
                    else if (component == WeaponComponentHash.HeavyShotgunClip01)
                    {
                        goto TR_0027;
                    }
                    else if ((component != WeaponComponentHash.CombatPDWClip02) && (component != WeaponComponentHash.VintagePistolClip02))
                    {
                        goto TR_000D;
                    }
                    goto TR_002D;
                }
                else
                {
                    if (component > WeaponComponentHash.RevolverVarmodBoss)
                    {
                        if (component > WeaponComponentHash.APPistolClip02)
                        {
                            if ((component == WeaponComponentHash.SMGVarmodLuxe) || (component == WeaponComponentHash.AssaultSMGVarmodLowrider))
                            {
                                goto TR_002B;
                            }
                            else if (component != WeaponComponentHash.APPistolClip01)
                            {
                                goto TR_000D;
                            }
                            goto TR_0027;
                        }
                        else
                        {
                            if (component == WeaponComponentHash.AtScopeLargeFixedZoom)
                            {
                                return "WCT_SCOPE_LRG";
                            }
                            if (component == WeaponComponentHash.Pistol50Clip01)
                            {
                                goto TR_0027;
                            }
                            else if (component != WeaponComponentHash.APPistolClip02)
                            {
                                goto TR_000D;
                            }
                        }
                    }
                    else if (component > WeaponComponentHash.AtArAfGrip)
                    {
                        if (component != WeaponComponentHash.MicroSMGClip02)
                        {
                            if (component == WeaponComponentHash.MarksmanRifleVarmodLuxe)
                            {
                                goto TR_002B;
                            }
                            else if (component == WeaponComponentHash.RevolverVarmodBoss)
                            {
                                return "WCT_REV_VARB";
                            }
                            goto TR_000D;
                        }
                    }
                    else
                    {
                        if ((component != WeaponComponentHash.CombatPistolClip01) && (component != ((WeaponComponentHash) 0xbaab157)))
                        {
                            if (component == WeaponComponentHash.AtArAfGrip)
                            {
                                return "WCT_GRIP";
                            }
                            goto TR_000D;
                        }
                        goto TR_0027;
                    }
                    goto TR_002D;
                }
            }
            else
            {
                if (component <= WeaponComponentHash.KnuckleVarmodHate)
                {
                    if (component <= WeaponComponentHash.KnuckleVarmodLove)
                    {
                        if (component == WeaponComponentHash.KnuckleVarmodPlayer)
                        {
                            return "WCT_KNUCK_PC";
                        }
                        if (component == WeaponComponentHash.KnuckleVarmodLove)
                        {
                            return "WCT_KNUCK_LV";
                        }
                    }
                    else
                    {
                        if (component == WeaponComponentHash.KnuckleVarmodDollar)
                        {
                            return "WCT_KNUCK_DLR";
                        }
                        if (component == WeaponComponentHash.KnuckleVarmodVagos)
                        {
                            return "WCT_KNUCK_VG";
                        }
                        if (component == WeaponComponentHash.KnuckleVarmodHate)
                        {
                            return "WCT_KNUCK_HT";
                        }
                    }
                }
                else if (component <= ((WeaponComponentHash) (-971770235)))
                {
                    if (component == ((WeaponComponentHash) (-1755194916)))
                    {
                        return "WCT_KNUCK_DMD";
                    }
                    if (component == ((WeaponComponentHash) (-971770235)))
                    {
                        return "WCT_KNUCK_02";
                    }
                }
                else
                {
                    if (component == ((WeaponComponentHash) (-494162961)))
                    {
                        return "WCT_KNUCK_SLG";
                    }
                    if (component == ((WeaponComponentHash) (-287703709)))
                    {
                        return "WCT_KNUCK_BG";
                    }
                    if (component == ((WeaponComponentHash) (-213504205)))
                    {
                        return "WT_KNUCKLE";
                    }
                }
                goto TR_000D;
            }
            goto TR_0027;
        TR_000D:
            str = "WCT_INVALID";
            int num = 0;
            int num4 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPONS, Array.Empty<InputArgument>());
            while (true)
            {
                if (num < num4)
                {
                    DlcWeaponData data2;
                    InputArgument[] arguments = new InputArgument[] { num, (IntPtr) &data2 };
                    if (!Function.Call<bool>(Hash.GET_DLC_WEAPON_DATA, arguments) || (data2.Hash != hash))
                    {
                        num++;
                        continue;
                    }
                    InputArgument[] argumentArray2 = new InputArgument[] { num };
                    int num3 = Function.Call<int>(Hash.GET_NUM_DLC_WEAPON_COMPONENTS, argumentArray2);
                    for (int i = 0; i < num3; i++)
                    {
                        DlcWeaponComponentData data;
                        InputArgument[] argumentArray3 = new InputArgument[] { num, i, (IntPtr) &data };
                        if (Function.Call<bool>(Hash.GET_DLC_WEAPON_COMPONENT_DATA, argumentArray3) && (data.Hash == component))
                        {
                            return data.DisplayName;
                        }
                    }
                }
                return str;
            }
        TR_0027:
            return "WCT_CLIP1";
        TR_002B:
            return "WCT_VAR_GOLD";
        TR_002D:
            return "WCT_CLIP2";
        TR_003A:
            return "WCT_VAR_METAL";
        TR_003C:
            return "WCT_FLASH";
        TR_0046:
            return "WCT_VAR_WOOD";
        TR_0052:
            return "WCT_VAR_ETCHM";
        TR_0057:
            return "WCT_CLIP_DRM";
        TR_0062:
            return "WCT_SUPP";
        }

        public static implicit operator WeaponComponentHash(WeaponComponent weaponComponent) => 
            weaponComponent.ComponentHash;

        public WeaponComponentHash ComponentHash =>
            this._component;

        public virtual bool Active
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this._weapon.Hash, this._component };
                return Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, arguments);
            }
            set
            {
                if (value)
                {
                    InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this._weapon.Hash, this._component };
                    Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, arguments);
                }
                else
                {
                    InputArgument[] arguments = new InputArgument[] { this._owner.Handle, this._weapon.Hash, this._component };
                    Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, arguments);
                }
            }
        }

        public virtual string DisplayName =>
            GetComponentDisplayNameFromHash(this._weapon.Hash, this._component);

        public virtual string LocalizedName =>
            Game.GetGXTEntry(this.DisplayName);

        public virtual ComponentAttachmentPoint AttachmentPoint =>
            GetAttachmentPoint(this._weapon.Hash, this._component);
    }
}

