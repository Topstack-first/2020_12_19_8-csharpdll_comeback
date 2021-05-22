// Decompiled with JetBrains decompiler
// Type: <Module>
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using _CppImplementationDetails_;
using _CrtImplementationDetails_;
using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class _Module_
{
  internal static unsafe _MEMORY_BLOCK* g_pMemoryBlocks;
  internal static __24ArrayType__24__24__24BY0CAE__40E hde32_table;
  internal static __24ArrayType__24__24__24BY0CBB__40E hde64_table;
  internal static volatile int g_isLocked;
  internal static _unnamed__2Dtype__2Dg_hooks_ g_hooks;
  internal static unsafe void* g_hHeap;
  internal static __24ArrayType__24__24__24BY0BB__40__24__24CBD __3F__3F_C__40_0BB__40JNBKCINE__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BB__40__24__24CBD __3F__3F_C__40_0BB__40OMHJHBLA__40H__3F__24ID__3F__24DN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24II__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AAu__3F__24AL__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0CL__40__24__24CBD __3F__3F_C__40_0CL__40MIHKIDKM__40x__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxxxxxxxxxxxxxxx__40;
  internal static __24ArrayType__24__24__24BY0CL__40__24__24CBD __3F__3F_C__40_0CL__40DBAFPMPE__40__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IL__3F__24AN__3F__24IMh__3Ft__3F__24ABeH__3F__24IL__3F__24AE__3F__24CFX__3F__24AA__3F__24AA__3F__24AA__3F__24LK__3F__24LE__3F__24AA__3F__24AA__3F__24AAH__3F__24IL__3F__24AE__3FH__3F__24IL__3F__24AM__3F__24AC__40;
  internal static __24ArrayType__24__24__24BY0BC__40__24__24CBD __3F__3F_C__40_0BC__40DPHJABEC__40LOADING_SPLAYER_L__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0CA__40__24__24CBD __3F__3F_C__40_0CA__40LNDFLCFC__40Loading__3F5Grand__3F5Theft__3F5Multiplayer__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40PADMHPJN__40LOADING_SPLAYER__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BI__40__24__24CBD __3F__3F_C__40_0BI__40JBPGAIJO__40Grand__3F5Theft__3F5Multiplayer__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40GNLCNEJP__400x8CC30479__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BG__40__24__24CBD __3F__3F_C__40_0BG__40MBFILFHN__40LEGAL_MAIN_DISK_USAGE__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0CG__40__24__24CBD __3F__3F_C__40_0CG__40GJFBKDGI__40Grand__3F5Theft__3F5Multiplayer__3F5is__3F5loadi__40;
  internal static __24ArrayType__24__24__24BY0BJ__40__24__24CBD __3F__3F_C__40_0BJ__40PBLEBFBJ__40LEGAL_MAIN_LOADING_USAGE__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0EF__40__24__24CBD __3F__3F_C__40_0EF__40NBDDBAGA__40GT__3F9MP__3F4net__3F5is__3F5a__3F5GTA__3F5V__3F5alternative__40;
  internal static __24ArrayType__24__24__24BY0BH__40__24__24CBD __3F__3F_C__40_0BH__40JABDINEC__40LEGAL_MAIN_CLOUD_USAGE__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0GK__40__24__24CBD __3F__3F_C__40_0GK__40KCOAFOKJ__40GT__3F9MP__3F4net__3F5is__3F5in__3F5no__3F5way__3F5affiliate__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40KPKEJNPP__40PM_QUIT_WARN2__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0DI__40__24__24CBD __3F__3F_C__40_0DI__40BLNMEOKA__40Are__3F5you__3F5sure__3F5you__3F5want__3F5to__3F5quit__3F5Gr__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40KKLCKOAF__400x5C07FE10__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40FCFEFCMK__400x9A094B65__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40NKGHMDCM__400xA7303DAC__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0DB__40__24__24CBD __3F__3F_C__40_0DB__40DLILAPM__40Quitting__3F5Grand__3F5Theft__3F5Multiplayer__40;
  internal static __FnPtr<sbyte* (long, byte*, long)> o_GetGameText;
  public static __FnPtr<ulong ()> __m2mep__40__3FGetOfflinePatchAddr__40__40__24__24FYA_KXZ;
  public static __FnPtr<ulong ()> __m2mep__40__3FGetGameTextHookAddr__40__40__24__24FYA_KXZ;
  internal static unsafe void* sScriptFib;
  internal static bool sGameReloaded;
  internal static unsafe void* sMainFib;
  public static __FnPtr<bool ()> __m2mep__40__3FManagedInit__40__40__24__24FYA_NXZ;
  public static __FnPtr<bool ()> __m2mep__40__3FManagedTick__40__40__24__24FYA_NXZ;
  public static __FnPtr<void (int, bool, bool, bool, bool)> __m2mep__40__3FManagedKeyboardMessage__40__40__24__24FYAXH_N000__40Z;
  public static __FnPtr<void (void*)> __m2mep__40__3FManagedD3DCall__40__40__24__24FYAXPEAX__40Z;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40BMKHLODJ__40CELL_EMAIL_BCON__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY06__24__24CBD __3F__3F_C__40_06IGECGLFO__40STRING__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY00__24__24CBD __3F__3F_C__40_00CNPNBAHC__40__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40CBDBHGDD__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40CMANEFCO__403__3F__24PP__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IF__3F__24MAtX__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40PAAJFKBO__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40LKNCCJCG__40__3F__24LC__3F__24AB__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA3__3FIH__3F__24IF__3F__24MAt__3F__24DL__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40BKAJBOPO__40xxxxxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40NCABKLLK__40t__3F__24CBH__3F__24ILH__3F5H__3F__24IF__3FIt__3F__24BIH__3F__24IL__3FV__3Fh__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BE__40__24__24CBD __3F__3F_C__40_0BE__40IGIMEELG__40xxxxxxxxxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BE__40__24__24CBD __3F__3F_C__40_0BE__40JGGPNEIB__40H__3Fw__3FyI__3F__24ILH__3F__24AIHc__3FP__3FA__3F__24OA__3F__24AI__3F__24AP__3F__24LG__3F__24BM__3F__24BB__3F__24AD__3FX__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BI__40__24__24CBD __3F__3F_C__40_0BI__40OGBHKGAL__40xxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24DPxxxxx__3F__24DPxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BI__40__24__24CBD __3F__3F_C__40_0BI__40EFGANGLN__40H__3F__24IL__3FH__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24AP__3F__24BAT__24__3F__24AA__3Fs__3F__24AP__3F__24BAL__24__3F__24AA__3Fs__3F__24AP__3F__24BA__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BE__40__24__24CBD __3F__3F_C__40_0BE__40OCONLGKC__40xxxxxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BE__40__24__24CBD __3F__3F_C__40_0BE__40JOEJLPBH__40__3F__24CF__3F__24PP__3F__24PP__3F__24PP__3F__24DP__3F__24IJD__248__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IF__3F__24MAt__3F__24AD__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40HANEDAD__40L__3F__24IL__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAD__3F__24IL__3FAI__3F__24ILA__3F__24AI__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40OMHKLNMH__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24APY__3FvH__3F__24IL__3F__24AI__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40BNBJMHMH__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40JMKPBFMD__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AAA__3F__24AP__3F__24LP__3FH__3F__24AP__3F__24LP__3F__24EA__3F__24BA__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40OOBBKAIE__40H__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24ILx__3F__24BA__3F__24IF__3F__24PP__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40EIPDMCAI__40xxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40KGLNKOK__40__3F__24IL__3FpH__3F__24IL__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24APY__3Fv__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0M__40__24__24CBD __3F__3F_C__40_0M__40KOOHDONN__40xxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0M__40__24__24CBD __3F__3F_C__40_0M__40BPBMEDDI__403__3F__24NLH__3F__24IJ__3F__24BN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IF__3F__24PP__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0CK__40__24__24CBD __3F__3F_C__40_0CK__40BHGDFKPH__40xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx__3F__24DP__3F__24DP__40;
  internal static __24ArrayType__24__24__24BY0CK__40__24__24CBD __3F__3F_C__40_0CK__40MIGBMEDM__40H__3F__24IL__3FDH__3F__24IJX__3F__24AIH__3F__24IJh__3F__24BAH__3F__24IJp__3F__24BIH__3F__24IJx__3F5AUAVAWH__3F__24ID__3Fl__3F5__3Fh__3F__24AA__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BF__40__24__24CBD __3F__3F_C__40_0BF__40LILGHALM__40xxxx__3F__24DPxxxxxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BF__40__24__24CBD __3F__3F_C__40_0BF__40IDDOKFMA__40H__3F__24IJ__3F2__24__3F__24AAWH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMA__3F__24IK__3Fx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40ECKJBGBB__40xxxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40NHIIANFK__40__3F__24EASH__3F__24ID__3Fl0H__3F__24IL__3FYHcI__3F__24AM__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BF__40__24__24CBD __3F__3F_C__40_0BF__40ICPMMPPH__40H__3F__24IJ__3F2__24__3F__24AAWH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMA__3F__24IL__3Fx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BA__40__24__24CBD __3F__3F_C__40_0BA__40KAGDKLL__40WH__3F__24ID__3Fl__3F5H__3F__24IL__3FYHcI__3F__24AMI__3F__24IL__3Fh__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0O__40__24__24CBD __3F__3F_C__40_0O__40CHCLMOIP__40__3F__24EASH__3F__24ID__3Fl__3F__24EAH__3F__24IL__3FYHcI__3F__24AM__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BH__40__24__24CBD __3F__3F_C__40_0BH__40KCEHIFEL__40xxxxxxxxxxxxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BH__40__24__24CBD __3F__3F_C__40_0BH__40MOLJKDBK__40H__3F__24IJ__3F2__24__3F__24AIH__3F__24IJl__24__3F__24BI__3F__24IJT__24__3F__24BAVWAVH__3F__24ID__3Fl__3F5__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40NHGOEEJE__40xxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40NEJFOFJJ__40__3F__24IE__3F__24MAt4H__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAH__3F__24IL__3FS__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40ODBCCLKK__40xxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40MBJEDNLD__40__3F__24IKL__24__3F__24GA__3F__24ILP__3F__24BAD__3F__24IK__3FN__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40DKLBBBNJ__40xxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40JLIKKIN__40H__3F__24IL__3F__24AL3__3FR__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IJ__3F__24AD__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BI__40__24__24CBD __3F__3F_C__40_0BI__40IELNJDGK__40xxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DP__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0BI__40__24__24CBD __3F__3F_C__40_0BI__40BAACPAIC__40Hc__3FAH__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3Fs__3F__24AP__3F__24BA__3F__24AE__3F__24IB__3Fs__3F__24AP__3F__24BB__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0P__40__24__24CBD __3F__3F_C__40_0P__40BACJMEDO__40t__3F__24BB__3F__24IL__3FQH__3F__24IN__3F__24AN__3F__24AA__3F__24AA__3F__24AA__3F__24AAE3__3F__24MA__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY07__24__24CBD __3F__3F_C__40_07HLDFCDI__40xxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY07__24__24CBD __3F__3F_C__40_07BICGIOCM__40H__3F__24IL__3FG__3Fs__3F__24AP__3F__24BA__3F__24AN__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40EFFAIECH__40xxxxxxxxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0N__40__24__24CBD __3F__3F_C__40_0N__40KPGHPIGB__40H__3F__24IL__3FH__3Fk__3F__24AC3__3FIH__3F__24IF__3FIt__3F__24CG__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40EBOGKLKJ__40xxx__3F__24DP__3F__24DPxxxxx__3F__24AA__40;
  internal static __24ArrayType__24__24__24BY0L__40__24__24CBD __3F__3F_C__40_0L__40KKKCFDAG__40f__3F__24IB__3Fy__3F__24AA__3F__24AAt__3F__24BAM__3F__24IF__3F__24MA__3F__24AA__40;
  internal static unsafe sbyte* __3FA0x50a72c60__2E_cellEmailBcon;
  internal static unsafe sbyte* __3FA0x50a72c60__2E_nullStr;
  internal static unsafe sbyte* __3FA0x50a72c60__2E_string;
  public static __FnPtr<ulong (ulong)> __m2mep__40__3F_getCheckpointAddress__40Native__40GTA__40__40__24__24FYA_K_K__40Z;
  public static __FnPtr<ulong (ulong)> __m2mep__40__3F_getCheckpoinHandles__40Native__40GTA__40__40__24__24FYA_K_K__40Z;
  public static unsafe int** __unep__40__3F_getCheckpointAddress__40Native__40GTA__40__40__24__24FYA_K_K__40Z;
  public static unsafe int** __unep__40__3F_getCheckpoinHandles__40Native__40GTA__40__40__24__24FYA_K_K__40Z;
  internal static __24ArrayType__24__24__24BY03M _negXor;
  internal static __s_GUID _GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e;
  internal static __s_GUID _GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e;
  internal static __s_GUID _GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02;
  internal static __s_GUID _GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02;
  internal static int __3FUninitialized__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2HA;
  internal static Progress __3FInitializedPerAppDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A;
  internal static bool __3FEntered__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;
  internal static TriBool __3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A;
  internal static bool __3FInitializedPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;
  internal static int __3FCount__40AllDomains__40_CrtImplementationDetails___40__402HA;
  internal static int __3FInitialized__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2HA;
  internal static Progress __3FInitializedNative__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A;
  internal static bool __3FInitializedNativeFromCCTOR__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;
  internal static bool __3FIsDefaultDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2_NA;
  internal static Progress __3FInitializedVtables__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A;
  internal static bool __3FInitializedNative__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;
  internal static Progress __3FInitializedPerProcess__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A;
  internal static TriBool __3FhasPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xc_mp_z;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xi_vt_z;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xc_ma_a;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xc_ma_z;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xi_vt_a;
  internal static __24ArrayType__24__24__24BY00Q6MPEBXXZ __xc_mp_a;
  public static __FnPtr<int (void*)> __m2mep__40__3FDoNothing__40DefaultDomain__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z;
  public static __FnPtr<int (void*)> __m2mep__40__3F_UninitializeDefaultDomain__40LanguageSupport__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z;
  public static unsafe int** __unep__40__3FDoNothing__40DefaultDomain__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z;
  public static unsafe int** __unep__40__3F_UninitializeDefaultDomain__40LanguageSupport__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z;
  internal static unsafe __FnPtr<void ()>* __3FA0x8481b400__2E__onexitbegin_m;
  internal static ulong __3FA0x8481b400__2E__exit_list_size;
  [FixedAddressValueType]
  internal static unsafe __FnPtr<void ()>* __onexitend_app_domain;
  internal static unsafe void* __3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA;
  internal static int __3F_ref_count__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0HA;
  internal static unsafe __FnPtr<void ()>* __3FA0x8481b400__2E__onexitend_m;
  [FixedAddressValueType]
  internal static ulong __exit_list_size_app_domain;
  [FixedAddressValueType]
  internal static unsafe __FnPtr<void ()>* __onexitbegin_app_domain;
  internal static __24ArrayType__24__24__24BY0A__40P6AHXZ __xi_z;
  internal static __scrt_native_startup_state __scrt_current_native_startup_state;
  internal static unsafe void* __scrt_native_startup_lock;
  internal static __24ArrayType__24__24__24BY0A__40P6AXXZ __xc_a;
  internal static __24ArrayType__24__24__24BY0A__40P6AHXZ __xi_a;
  internal static uint __scrt_native_dllmain_reason;
  internal static __24ArrayType__24__24__24BY0A__40P6AXXZ __xc_z;

  internal static unsafe ulong GetOfflinePatchAddr() => MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0BB__40OMHJHBLA__40H__3F__24ID__3F__24DN__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24II__3F__24AF__3F__24AA__3F__24AA__3F__24AA__3F__24AAu__3F__24AL__3F__24AA__40, (sbyte*) &_Module_.__3F__3F_C__40_0BB__40JNBKCINE__40xxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24AA__40);

  internal static unsafe ulong GetGameTextHookAddr() => MemoryAccess.FindPattern((sbyte*) &_Module_.__3F__3F_C__40_0CL__40DBAFPMPE__40__3Fh__3F__24AA__3F__24AA__3F__24AA__3F__24AA__3F__24IL__3F__24AN__3F__24IMh__3Ft__3F__24ABeH__3F__24IL__3F__24AE__3F__24CFX__3F__24AA__3F__24AA__3F__24AA__3F__24LK__3F__24LE__3F__24AA__3F__24AA__3F__24AAH__3F__24IL__3F__24AE__3FH__3F__24IL__3F__24AM__3F__24AC__40, (sbyte*) &_Module_.__3F__3F_C__40_0CL__40MIHKIDKM__40x__3F__24DP__3F__24DP__3F__24DP__3F__24DPxx__3F__24DP__3F__24DP__3F__24DP__3F__24DPxxxxxxxxxxxxxxxxxxxxx__40);

  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool ManagedInit()
  {
    if (!object.ReferenceEquals((object) ScriptHook.Domain, (object) null))
      ScriptDomain.Unload(ref ScriptHook.Domain);
    string location = Assembly.GetExecutingAssembly().Location;
    ScriptSettings scriptSettings = ScriptSettings.Load(Path.ChangeExtension(location, ".ini"));
    ScriptHook.Domain = ScriptDomain.Load(Path.Combine(Path.GetDirectoryName(location), scriptSettings.GetValue(string.Empty, "ScriptsLocation", "scripts")));
    ScriptHook.ReloadKey = scriptSettings.GetValue<Keys>(string.Empty, "ReloadKey", Keys.F24);
    if (object.ReferenceEquals((object) ScriptHook.Domain, (object) null))
      return false;
    ScriptHook.Domain.Start();
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool ManagedTick()
  {
    if (ScriptHook.Domain.IsKeyPressed(ScriptHook.ReloadKey))
      return false;
    ScriptHook.Domain.DoTick();
    return true;
  }

  internal static void ManagedKeyboardMessage(
    int key,
    [MarshalAs(UnmanagedType.U1)] bool status,
    [MarshalAs(UnmanagedType.U1)] bool statusCtrl,
    [MarshalAs(UnmanagedType.U1)] bool statusShift,
    [MarshalAs(UnmanagedType.U1)] bool statusAlt)
  {
    if (object.ReferenceEquals((object) ScriptHook.Domain, (object) null))
      return;
    ScriptHook.Domain.DoKeyboardMessage((Keys) key, status, statusCtrl, statusShift, statusAlt);
  }

  internal static unsafe void ManagedD3DCall(void* swapchain)
  {
    if (object.ReferenceEquals((object) ScriptHook.Domain, (object) null))
      return;
    ScriptHook.Domain.DoD3DCall(swapchain);
  }

  internal static ulong GTA__2ENative__2EObjectToNative(object value)
  {
    if (object.ReferenceEquals(value, (object) null))
      return 0;
    System.Type type = value.GetType();
    if (type.IsEnum)
    {
      type = Enum.GetUnderlyingType(type);
      value = Convert.ChangeType(value, type);
    }
    if (type == typeof (bool))
      return (bool) value ? 1UL : 0UL;
    if (type == typeof (int))
      return (ulong) (int) value;
    if (type == typeof (uint))
      return (ulong) (uint) value;
    if (type == typeof (long))
      return (ulong) (long) value;
    if (type == typeof (ulong))
      return (ulong) value;
    if (type == typeof (float))
      return (ulong) BitConverter.ToUInt32(BitConverter.GetBytes((float) value), 0);
    if (type == typeof (double))
      return (ulong) BitConverter.ToUInt32(BitConverter.GetBytes((float) (double) value), 0);
    if (type == typeof (string))
      return (ulong) ScriptDomain.CurrentDomain.PinString((string) value).ToInt64();
    if (type == typeof (IntPtr))
      return (ulong) ((IntPtr) value).ToInt64();
    if (typeof (INativeValue).IsAssignableFrom(type))
      return ((INativeValue) value).NativeValue;
    throw new InvalidCastException("Unable to cast object of type '" + type.FullName + "' to native value");
  }

  internal static unsafe object GTA__2ENative__2EObjectFromNative(System.Type type, ulong* value)
  {
    if (type.IsEnum)
      type = Enum.GetUnderlyingType(type);
    if (type == typeof (bool))
      return (object) (*(int*) value != 0);
    if (type == typeof (int))
      return (object) *(int*) value;
    if (type == typeof (uint))
      return (object) (uint) *(int*) value;
    if (type == typeof (long))
      return (object) (long) *value;
    if (type == typeof (ulong))
      return (object) *value;
    if (type == typeof (float))
      return (object) *(float*) value;
    if (type == typeof (double))
      return (object) (double) *(float*) value;
    if (type == typeof (string))
    {
      sbyte* numPtr1 = (sbyte*) *value;
      if ((IntPtr) numPtr1 == IntPtr.Zero)
        return (object) string.Empty;
      sbyte* numPtr2 = numPtr1;
      if (*numPtr1 != (sbyte) 0)
      {
        do
        {
          ++numPtr2;
        }
        while (*numPtr2 != (sbyte) 0);
      }
      int length = (int) ((IntPtr) numPtr2 - (IntPtr) numPtr1);
      if (length == 0)
        return (object) string.Empty;
      byte[] numArray = new byte[length];
      Marshal.Copy(new IntPtr((void*) numPtr1), numArray, 0, numArray.Length);
      return (object) Encoding.UTF8.GetString(numArray);
    }
    if (type == typeof (IntPtr))
      return (object) new IntPtr((long) *value);
    if (type == typeof (Vector2))
    {
      ValueType valueType = (ValueType) new Vector2();
      (Vector2) valueType = new Vector2(*(float*) value, *(float*) ((IntPtr) value + 8L));
      return (object) valueType;
    }
    if (type == typeof (Vector3))
    {
      ValueType valueType = (ValueType) new Vector3();
      (Vector3) valueType = new Vector3(*(float*) value, *(float*) ((IntPtr) value + 8L), *(float*) ((IntPtr) value + 16L));
      return (object) valueType;
    }
    INativeValue nativeValue = typeof (INativeValue).IsAssignableFrom(type) ? (INativeValue) FormatterServices.GetUninitializedObject(type) : throw new InvalidCastException("Unable to cast native value to object of type '" + type.FullName + "'");
    nativeValue.NativeValue = *value;
    return (object) nativeValue;
  }

  internal static unsafe ulong GTA__2ENative__2E_getCheckpointAddress(ulong Data)
  {
    int num1 = (int) Data;
    // ISSUE: function pointer call
    long num2 = (long) __calli(MemoryAccess.CheckpointBaseAddr)();
    int num3 = num1;
    // ISSUE: function pointer call
    ulong num4 = __calli(MemoryAccess.CheckpointHandleAddr)((int) num2, (ulong) num3);
    return num4 != 0UL ? (ulong) ((IntPtr) MemoryAccess.checkpointPoolAddress + (long) (*(int*) ((long) num4 + 16L) * 96)) : 0UL;
  }

  internal static unsafe ulong GTA__2ENative__2E_getCheckpoinHandles(ulong ArrayPtr)
  {
    ulong num = 0;
    // ISSUE: function pointer call
    checkpoint* checkpointPtr = (checkpoint*) *(long*) ((long) __calli(MemoryAccess.CheckpointBaseAddr)() + 48L);
    if ((IntPtr) checkpointPtr != IntPtr.Zero)
    {
      while (num < 64UL)
      {
        *(int*) ((long) num * 4L + (long) ArrayPtr) = *(int*) ((IntPtr) checkpointPtr + 12L);
        ++num;
        checkpointPtr = (checkpoint*) *(long*) ((IntPtr) checkpointPtr + 24L);
        if ((IntPtr) checkpointPtr == IntPtr.Zero)
          break;
      }
    }
    return num;
  }

  internal static unsafe void GTA__2ELog(string logLevel, params string[] message)
  {
    // ISSUE: untyped stack allocation
    long num1 = (long) __untypedstackalloc(_Module_.__CxxQueryExceptionSize());
    DateTime now = DateTime.Now;
    string str1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\logs\\ScriptHookVDotNet.log");
    string path = str1.Insert(str1.IndexOf(".log"), "-" + now.ToString("yyyy-MM-dd"));
    try
    {
      FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
      try
      {
        string[] strArray = new string[5]
        {
          "[",
          now.ToString("HH:mm:ss"),
          "] ",
          logLevel,
          " "
        };
        streamWriter.Write(string.Concat(strArray));
        foreach (string str2 in message)
          streamWriter.Write(str2);
        streamWriter.WriteLine();
      }
      finally
      {
        streamWriter.Close();
        fileStream.Close();
      }
    }
    catch (Exception ex1) when (
    {
      // ISSUE: unable to correctly present filter
      uint exceptionCode = (uint) Marshal.GetExceptionCode();
      if (_Module_.__CxxExceptionFilter((void*) Marshal.GetExceptionPointers(), (void*) 0L, 0, (void*) 0L) != 0)
      {
        SuccessfulFiltering;
      }
      else
        throw;
    }
    )
    {
      uint num2 = 0;
      _Module_.__CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num1);
      try
      {
        try
        {
        }
        catch (Exception ex2) when (
        {
          // ISSUE: unable to correctly present filter
          num2 = (uint) _Module_.__CxxDetectRethrow((void*) Marshal.GetExceptionPointers());
          if (num2 != 0U)
          {
            SuccessfulFiltering;
          }
          else
            throw;
        }
        )
        {
        }
        return;
        if (num2 == 0U)
          return;
        throw;
      }
      finally
      {
        _Module_.__CxxUnregisterExceptionObject((void*) num1, (int) num2);
      }
    }
  }

  internal static Assembly GTA__2EHandleResolve(object sender, ResolveEventArgs args)
  {
    Assembly assembly = typeof (Script).Assembly;
    AssemblyName assemblyName = new AssemblyName(args.Name);
    if (!assemblyName.Name.StartsWith("ScriptHookVDotNet", StringComparison.CurrentCultureIgnoreCase))
      return (Assembly) null;
    if (assemblyName.Version.Major != assembly.GetName().Version.Major)
      _Module_.GTA__2ELog("[WARNING]", "A script references v", assemblyName.Version.ToString(3), " which may not be compatible with the current v" + assembly.GetName().Version.ToString(3), ".");
    return assembly;
  }

  internal static void GTA__2EHandleUnhandledException(
    object sender,
    UnhandledExceptionEventArgs args)
  {
    if (!args.IsTerminating)
      _Module_.GTA__2ELog("[ERROR]", "Caught unhandled exception:", Environment.NewLine, args.ExceptionObject.ToString());
    else
      _Module_.GTA__2ELog("[ERROR]", "Caught fatal unhandled exception:", Environment.NewLine, args.ExceptionObject.ToString());
  }

  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool GTA__2ESortScripts(ref List<Tuple<string, System.Type>> scriptTypes)
  {
    Dictionary<Tuple<string, System.Type>, List<System.Type>> dictionary = new Dictionary<Tuple<string, System.Type>, List<System.Type>>();
    List<Tuple<string, System.Type>>.Enumerator enumerator1 = scriptTypes.GetEnumerator();
    if (enumerator1.MoveNext())
    {
      do
      {
        Tuple<string, System.Type> current = enumerator1.Current;
        List<System.Type> typeList = new List<System.Type>();
        object[] customAttributes = current.Item2.GetCustomAttributes(typeof (RequireScript), true);
        int index = 0;
        if (0 < customAttributes.Length)
        {
          do
          {
            RequireScript requireScript = (RequireScript) customAttributes[index];
            typeList.Add(requireScript._dependency);
            ++index;
          }
          while (index < customAttributes.Length);
        }
        dictionary.Add(current, typeList);
      }
      while (enumerator1.MoveNext());
    }
    List<Tuple<string, System.Type>> tupleList = new List<Tuple<string, System.Type>>(dictionary.Count);
    if (dictionary.Count > 0)
    {
      do
      {
        Tuple<string, System.Type> key = (Tuple<string, System.Type>) null;
        Dictionary<Tuple<string, System.Type>, List<System.Type>>.Enumerator enumerator2 = dictionary.GetEnumerator();
        if (enumerator2.MoveNext())
        {
          KeyValuePair<Tuple<string, System.Type>, List<System.Type>> current;
          do
          {
            current = enumerator2.Current;
            if (current.Value.Count == 0)
              goto label_8;
          }
          while (enumerator2.MoveNext());
          goto label_9;
label_8:
          key = current.Key;
        }
label_9:
        if (key != null)
        {
          tupleList.Add(key);
          dictionary.Remove(key);
          Dictionary<Tuple<string, System.Type>, List<System.Type>>.Enumerator enumerator3 = dictionary.GetEnumerator();
          if (enumerator3.MoveNext())
          {
            do
            {
              enumerator3.Current.Value.Remove(key.Item2);
            }
            while (enumerator3.MoveNext());
          }
        }
        else
          goto label_13;
      }
      while (dictionary.Count > 0);
      goto label_14;
label_13:
      _Module_.GTA__2ELog("[ERROR]", "Detected a circular script dependency. Aborting ...");
      return false;
    }
label_14:
    scriptTypes = tupleList;
    return true;
  }

  internal static void _CrtImplementationDetails___2EThrowNestedModuleLoadException(
    Exception innerException,
    Exception nestedException)
  {
    throw new ModuleLoadExceptionHandlerException("A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n", innerException, nestedException);
  }

  internal static void _CrtImplementationDetails___2EThrowModuleLoadException(
    string errorMessage)
  {
    throw new ModuleLoadException(errorMessage);
  }

  internal static void _CrtImplementationDetails___2EThrowModuleLoadException(
    string errorMessage,
    Exception innerException)
  {
    throw new ModuleLoadException(errorMessage, innerException);
  }

  internal static void _CrtImplementationDetails___2ERegisterModuleUninitializer(
    EventHandler handler)
  {
    ModuleUninitializer._ModuleUninitializer.AddHandler(handler);
  }

  [SecuritySafeCritical]
  internal static unsafe Guid _CrtImplementationDetails___2EFromGUID(_GUID* guid) => new Guid((uint) *(int*) guid, *(ushort*) ((IntPtr) guid + 4L), *(ushort*) ((IntPtr) guid + 6L), *(byte*) ((IntPtr) guid + 8L), *(byte*) ((IntPtr) guid + 9L), *(byte*) ((IntPtr) guid + 10L), *(byte*) ((IntPtr) guid + 11L), *(byte*) ((IntPtr) guid + 12L), *(byte*) ((IntPtr) guid + 13L), *(byte*) ((IntPtr) guid + 14L), *(byte*) ((IntPtr) guid + 15L));

  [SecurityCritical]
  internal static unsafe int __get_default_appdomain(IUnknown** ppUnk)
  {
    ICorRuntimeHost* icorRuntimeHostPtr1 = (ICorRuntimeHost*) 0L;
    int num1;
    try
    {
      Guid riid = _Module_._CrtImplementationDetails___2EFromGUID((_GUID*) &_Module_._GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e);
      icorRuntimeHostPtr1 = (ICorRuntimeHost*) RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(_Module_._CrtImplementationDetails___2EFromGUID((_GUID*) &_Module_._GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e), riid).ToPointer();
      goto label_4;
    }
    catch (Exception ex)
    {
      num1 = Marshal.GetHRForException(ex);
    }
    if (num1 < 0)
      goto label_5;
label_4:
    ICorRuntimeHost* icorRuntimeHostPtr2 = icorRuntimeHostPtr1;
    IUnknown** iunknownPtr = ppUnk;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    num1 = __calli((__FnPtr<int (IntPtr, IUnknown**)>) *(long*) (*(long*) icorRuntimeHostPtr1 + 104L))((IUnknown**) icorRuntimeHostPtr2, (IntPtr) iunknownPtr);
    ICorRuntimeHost* icorRuntimeHostPtr3 = icorRuntimeHostPtr1;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num2 = (int) __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) icorRuntimeHostPtr3 + 16L))((IntPtr) icorRuntimeHostPtr3);
label_5:
    return num1;
  }

  internal static unsafe void __release_appdomain(IUnknown* ppUnk)
  {
    IUnknown* iunknownPtr = ppUnk;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num = (int) __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) iunknownPtr + 16L))((IntPtr) iunknownPtr);
  }

  [SecurityCritical]
  internal static unsafe AppDomain _CrtImplementationDetails___2EGetDefaultDomain()
  {
    IUnknown* ppUnk = (IUnknown*) 0L;
    int defaultAppdomain = _Module_.__get_default_appdomain(&ppUnk);
    if (defaultAppdomain >= 0)
    {
      try
      {
        return (AppDomain) Marshal.GetObjectForIUnknown(new IntPtr((void*) ppUnk));
      }
      finally
      {
        _Module_.__release_appdomain(ppUnk);
      }
    }
    else
    {
      Marshal.ThrowExceptionForHR(defaultAppdomain);
      return (AppDomain) null;
    }
  }

  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2EDoCallBackInDefaultDomain(
    __FnPtr<int (void*)> function,
    void* cookie)
  {
    Guid riid = _Module_._CrtImplementationDetails___2EFromGUID((_GUID*) &_Module_._GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02);
    ICLRRuntimeHost* pointer = (ICLRRuntimeHost*) RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(_Module_._CrtImplementationDetails___2EFromGUID((_GUID*) &_Module_._GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02), riid).ToPointer();
    try
    {
      AppDomain defaultDomain = _Module_._CrtImplementationDetails___2EGetDefaultDomain();
      ICLRRuntimeHost* iclrRuntimeHostPtr = pointer;
      int id = defaultDomain.Id;
      __FnPtr<int (void*)> local = function;
      void* voidPtr = cookie;
      // ISSUE: cast to a function pointer type
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int errorCode = __calli((__FnPtr<int (IntPtr, uint, __FnPtr<int (void*)>, void*)>) *(long*) (*(long*) pointer + 64L))((void*) iclrRuntimeHostPtr, (__FnPtr<int (void*)>) id, (uint) local, (IntPtr) voidPtr);
      if (errorCode >= 0)
        return;
      Marshal.ThrowExceptionForHR(errorCode);
    }
    finally
    {
      ICLRRuntimeHost* iclrRuntimeHostPtr = pointer;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int num = (int) __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) iclrRuntimeHostPtr + 16L))((IntPtr) iclrRuntimeHostPtr);
    }
  }

  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool __scrt_is_safe_for_managed_code() => _Module_.__scrt_native_dllmain_reason > 1U;

  [SecuritySafeCritical]
  internal static unsafe int _CrtImplementationDetails___2EDefaultDomain__2EDoNothing(
    void* cookie)
  {
    GC.KeepAlive((object) int.MaxValue);
    return 0;
  }

  [SecuritySafeCritical]
  [return: MarshalAs(UnmanagedType.U1)]
  internal static unsafe bool _CrtImplementationDetails___2EDefaultDomain__2EHasPerProcess()
  {
    if (_Module_.__3FhasPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A != (TriBool) 2)
      return _Module_.__3FhasPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A == (TriBool) -1;
    void** voidPtr = (void**) &_Module_.__xc_mp_a;
    if (ref _Module_.__xc_mp_a < ref _Module_.__xc_mp_z)
    {
      while (*(long*) voidPtr == 0L)
      {
        voidPtr += 8L;
        if ((IntPtr) voidPtr >= ref _Module_.__xc_mp_z)
          goto label_5;
      }
      _Module_.__3FhasPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A = (TriBool) -1;
      return true;
    }
label_5:
    _Module_.__3FhasPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A = (TriBool) 0;
    return false;
  }

  [SecuritySafeCritical]
  [return: MarshalAs(UnmanagedType.U1)]
  internal static unsafe bool _CrtImplementationDetails___2EDefaultDomain__2EHasNative()
  {
    if (_Module_.__3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A != (TriBool) 2)
      return _Module_.__3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A == (TriBool) -1;
    void** voidPtr1 = (void**) &_Module_.__xi_a;
    if (ref _Module_.__xi_a < ref _Module_.__xi_z)
    {
      while (*(long*) voidPtr1 == 0L)
      {
        voidPtr1 += 8L;
        if ((IntPtr) voidPtr1 >= ref _Module_.__xi_z)
          goto label_5;
      }
      _Module_.__3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A = (TriBool) -1;
      return true;
    }
label_5:
    void** voidPtr2 = (void**) &_Module_.__xc_a;
    if (ref _Module_.__xc_a < ref _Module_.__xc_z)
    {
      while (*(long*) voidPtr2 == 0L)
      {
        voidPtr2 += 8L;
        if ((IntPtr) voidPtr2 >= ref _Module_.__xc_z)
          goto label_9;
      }
      _Module_.__3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A = (TriBool) -1;
      return true;
    }
label_9:
    _Module_.__3FhasNative__40DefaultDomain__40_CrtImplementationDetails___40__400W4TriBool__402__40A = (TriBool) 0;
    return false;
  }

  [SecuritySafeCritical]
  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool _CrtImplementationDetails___2EDefaultDomain__2ENeedsInitialization() => _Module_._CrtImplementationDetails___2EDefaultDomain__2EHasPerProcess() && !_Module_.__3FInitializedPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__402_NA || _Module_._CrtImplementationDetails___2EDefaultDomain__2EHasNative() && !_Module_.__3FInitializedNative__40DefaultDomain__40_CrtImplementationDetails___40__402_NA && _Module_.__scrt_current_native_startup_state == (__scrt_native_startup_state) 0;

  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool _CrtImplementationDetails___2EDefaultDomain__2ENeedsUninitialization() => _Module_.__3FEntered__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;

  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2EDefaultDomain__2EInitialize() => _Module_._CrtImplementationDetails___2EDoCallBackInDefaultDomain((__FnPtr<int (void*)>) (IntPtr) _Module_.__unep__40__3FDoNothing__40DefaultDomain__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z, (void*) 0L);

  [SecuritySafeCritical]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializeVtables(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load during vtable initialization.\n");
    _Module_.__3FInitializedVtables__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 1;
    _Module_._initterm_m((__FnPtr<void* ()>*) &_Module_.__xi_vt_a, (__FnPtr<void* ()>*) &_Module_.__xi_vt_z);
    _Module_.__3FInitializedVtables__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 2;
  }

  [SecuritySafeCritical]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializeDefaultAppDomain(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load while attempting to initialize the default appdomain.\n");
    _Module_._CrtImplementationDetails___2EDefaultDomain__2EInitialize();
  }

  [DebuggerStepThrough]
  [SecuritySafeCritical]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializeNative(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load during native initialization.\n");
    _Module_.__security_init_cookie();
    _Module_.__3FInitializedNative__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = true;
    if (!_Module_.__scrt_is_safe_for_managed_code())
      _Module_.abort();
    if (_Module_.__scrt_current_native_startup_state == (__scrt_native_startup_state) 1)
      _Module_.abort();
    if (_Module_.__scrt_current_native_startup_state != (__scrt_native_startup_state) 0)
      return;
    _Module_.__3FInitializedNative__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 1;
    _Module_.__scrt_current_native_startup_state = (__scrt_native_startup_state) 1;
    if (_Module_._initterm_e((__FnPtr<int ()>*) &_Module_.__xi_a, (__FnPtr<int ()>*) &_Module_.__xi_z) != 0)
      _Module_._CrtImplementationDetails___2EThrowModuleLoadException(_Module_.gcroot_System__3A__3AString__20__5E___2E__2EPE__24AAVString__40System__40__40((gcroot_System__3A__3AString__20__5E_*) obj0));
    _Module_._initterm((__FnPtr<void ()>*) &_Module_.__xc_a, (__FnPtr<void ()>*) &_Module_.__xc_z);
    _Module_.__scrt_current_native_startup_state = (__scrt_native_startup_state) 2;
    _Module_.__3FInitializedNativeFromCCTOR__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = true;
    _Module_.__3FInitializedNative__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 2;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializePerProcess(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load during process initialization.\n");
    _Module_.__3FInitializedPerProcess__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 1;
    _Module_._initatexit_m();
    _Module_._initterm_m((__FnPtr<void* ()>*) &_Module_.__xc_mp_a, (__FnPtr<void* ()>*) &_Module_.__xc_mp_z);
    _Module_.__3FInitializedPerProcess__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 2;
    _Module_.__3FInitializedPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = true;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializePerAppDomain(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load during appdomain initialization.\n");
    _Module_.__3FInitializedPerAppDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 1;
    _Module_._initatexit_app_domain();
    _Module_._initterm_m((__FnPtr<void* ()>*) &_Module_.__xc_ma_a, (__FnPtr<void* ()>*) &_Module_.__xc_ma_z);
    _Module_.__3FInitializedPerAppDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2W4Progress__402__40A = (Progress) 2;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitializeUninitializer(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load during registration for the unload events.\n");
    _Module_._CrtImplementationDetails___2ERegisterModuleUninitializer(new EventHandler(_Module_._CrtImplementationDetails___2ELanguageSupport__2EDomainUnload));
  }

  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2E_Initialize(
    [In] LanguageSupport* obj0)
  {
    _Module_.__3FIsDefaultDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2_NA = AppDomain.CurrentDomain.IsDefaultAppDomain();
    _Module_.__3FEntered__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = _Module_.__3FIsDefaultDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2_NA || _Module_.__3FEntered__40DefaultDomain__40_CrtImplementationDetails___40__402_NA;
    void* fiberPtrId = _Module_._getFiberPtrId();
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    RuntimeHelpers.PrepareConstrainedRegions();
    try
    {
      while (num2 == 0)
      {
        try
        {
        }
        finally
        {
          // ISSUE: cast to a reference type
          void* voidPtr = (void*) Interlocked.CompareExchange((long&) ref _Module_.__scrt_native_startup_lock, (long) fiberPtrId, 0L);
          if ((IntPtr) voidPtr == IntPtr.Zero)
            num2 = 1;
          else if (voidPtr == fiberPtrId)
          {
            num1 = 1;
            num2 = 1;
          }
        }
        if (num2 == 0)
          _Module_.Sleep(1000U);
      }
      _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializeVtables(obj0);
      if (_Module_.__3FIsDefaultDomain__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2_NA)
      {
        _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializeNative(obj0);
        _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializePerProcess(obj0);
      }
      else
        num3 = _Module_._CrtImplementationDetails___2EDefaultDomain__2ENeedsInitialization() ? 1 : num3;
    }
    finally
    {
      if (num1 == 0)
      {
        // ISSUE: cast to a reference type
        Interlocked.Exchange((long&) ref _Module_.__scrt_native_startup_lock, 0L);
      }
    }
    if (num3 != 0)
      _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializeDefaultAppDomain(obj0);
    _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializePerAppDomain(obj0);
    _Module_.__3FInitialized__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2HA = 1;
    _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitializeUninitializer(obj0);
  }

  [SecurityCritical]
  internal static void _CrtImplementationDetails___2ELanguageSupport__2EUninitializeAppDomain() => _Module_._app_exit_callback();

  [SecurityCritical]
  internal static unsafe int _CrtImplementationDetails___2ELanguageSupport__2E_UninitializeDefaultDomain(
    void* cookie)
  {
    _Module_._exit_callback();
    _Module_.__3FInitializedPerProcess__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = false;
    if (_Module_.__3FInitializedNativeFromCCTOR__40DefaultDomain__40_CrtImplementationDetails___40__402_NA)
    {
      _Module_._cexit();
      _Module_.__scrt_current_native_startup_state = (__scrt_native_startup_state) 0;
      _Module_.__3FInitializedNativeFromCCTOR__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = false;
    }
    _Module_.__3FInitializedNative__40DefaultDomain__40_CrtImplementationDetails___40__402_NA = false;
    return 0;
  }

  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EUninitializeDefaultDomain()
  {
    if (!_Module_._CrtImplementationDetails___2EDefaultDomain__2ENeedsUninitialization())
      return;
    if (AppDomain.CurrentDomain.IsDefaultAppDomain())
    {
      _Module_._CrtImplementationDetails___2ELanguageSupport__2E_UninitializeDefaultDomain((void*) 0L);
    }
    else
    {
      // ISSUE: cast to a function pointer type
      _Module_._CrtImplementationDetails___2EDoCallBackInDefaultDomain((__FnPtr<int (void*)>) (IntPtr) _Module_.__unep__40__3F_UninitializeDefaultDomain__40LanguageSupport__40_CrtImplementationDetails___40__40__24__24FCAJPEAX__40Z, (void*) 0L);
    }
  }

  [PrePrepareMethod]
  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  internal static void _CrtImplementationDetails___2ELanguageSupport__2EDomainUnload(
    object A_0,
    EventArgs A_1)
  {
    if (_Module_.__3FInitialized__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2HA == 0 || Interlocked.Exchange(ref _Module_.__3FUninitialized__40CurrentDomain__40_CrtImplementationDetails___40__40__24__24Q2HA, 1) != 0)
      return;
    int num = Interlocked.Decrement(ref _Module_.__3FCount__40AllDomains__40_CrtImplementationDetails___40__402HA) == 0 ? 1 : 0;
    _Module_._CrtImplementationDetails___2ELanguageSupport__2EUninitializeAppDomain();
    if ((byte) num == (byte) 0)
      return;
    _Module_._CrtImplementationDetails___2ELanguageSupport__2EUninitializeDefaultDomain();
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2ECleanup(
    [In] LanguageSupport* obj0,
    Exception innerException)
  {
    try
    {
      bool flag = Interlocked.Decrement(ref _Module_.__3FCount__40AllDomains__40_CrtImplementationDetails___40__402HA) == 0;
      _Module_._CrtImplementationDetails___2ELanguageSupport__2EUninitializeAppDomain();
      if (!flag)
        return;
      _Module_._CrtImplementationDetails___2ELanguageSupport__2EUninitializeDefaultDomain();
    }
    catch (Exception ex)
    {
      _Module_._CrtImplementationDetails___2EThrowNestedModuleLoadException(innerException, ex);
    }
    catch
    {
      _Module_._CrtImplementationDetails___2EThrowNestedModuleLoadException(innerException, (Exception) null);
    }
  }

  [SecurityCritical]
  internal static unsafe LanguageSupport* _CrtImplementationDetails___2ELanguageSupport__2E__7Bctor__7D(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__7Bctor__7D((gcroot_System__3A__3AString__20__5E_*) obj0);
    return obj0;
  }

  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2E__7Bdtor__7D(
    [In] LanguageSupport* obj0)
  {
    _Module_.gcroot_System__3A__3AString__20__5E___2E__7Bdtor__7D((gcroot_System__3A__3AString__20__5E_*) obj0);
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  internal static unsafe void _CrtImplementationDetails___2ELanguageSupport__2EInitialize(
    [In] LanguageSupport* obj0)
  {
    bool flag = false;
    RuntimeHelpers.PrepareConstrainedRegions();
    try
    {
      _Module_.gcroot_System__3A__3AString__20__5E___2E__3D((gcroot_System__3A__3AString__20__5E_*) obj0, "The C++ module failed to load.\n");
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
      }
      finally
      {
        Interlocked.Increment(ref _Module_.__3FCount__40AllDomains__40_CrtImplementationDetails___40__402HA);
        flag = true;
      }
      _Module_._CrtImplementationDetails___2ELanguageSupport__2E_Initialize(obj0);
    }
    catch (Exception ex)
    {
      if (flag)
        _Module_._CrtImplementationDetails___2ELanguageSupport__2ECleanup(obj0, ex);
      _Module_._CrtImplementationDetails___2EThrowModuleLoadException(_Module_.gcroot_System__3A__3AString__20__5E___2E__2EPE__24AAVString__40System__40__40((gcroot_System__3A__3AString__20__5E_*) obj0), ex);
    }
    catch
    {
      if (flag)
        _Module_._CrtImplementationDetails___2ELanguageSupport__2ECleanup(obj0, (Exception) null);
      _Module_._CrtImplementationDetails___2EThrowModuleLoadException(_Module_.gcroot_System__3A__3AString__20__5E___2E__2EPE__24AAVString__40System__40__40((gcroot_System__3A__3AString__20__5E_*) obj0), (Exception) null);
    }
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  static unsafe _Module_()
  {
    LanguageSupport languageSupport;
    _Module_._CrtImplementationDetails___2ELanguageSupport__2E__7Bctor__7D(&languageSupport);
    // ISSUE: fault handler
    try
    {
      _Module_._CrtImplementationDetails___2ELanguageSupport__2EInitialize(&languageSupport);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      _Module_.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(_CrtImplementationDetails___2ELanguageSupport__2E__7Bdtor__7D), (void*) &languageSupport);
    }
    _Module_._CrtImplementationDetails___2ELanguageSupport__2E__7Bdtor__7D(&languageSupport);
  }

  [SecuritySafeCritical]
  internal static unsafe string gcroot_System__3A__3AString__20__5E___2E__2EPE__24AAVString__40System__40__40(
    [In] gcroot_System__3A__3AString__20__5E_* obj0)
  {
    return (string) ((GCHandle) new IntPtr((void*) *(long*) obj0)).Target;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe gcroot_System__3A__3AString__20__5E_* gcroot_System__3A__3AString__20__5E___2E__3D(
    [In] gcroot_System__3A__3AString__20__5E_* obj0,
    string t)
  {
    ((GCHandle) new IntPtr((void*) *(long*) obj0)).Target = (object) t;
    return obj0;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void gcroot_System__3A__3AString__20__5E___2E__7Bdtor__7D(
    [In] gcroot_System__3A__3AString__20__5E_* obj0)
  {
    ((GCHandle) new IntPtr((void*) *(long*) obj0)).Free();
    *(long*) obj0 = 0L;
  }

  [SecuritySafeCritical]
  [DebuggerStepThrough]
  internal static unsafe gcroot_System__3A__3AString__20__5E_* gcroot_System__3A__3AString__20__5E___2E__7Bctor__7D(
    [In] gcroot_System__3A__3AString__20__5E_* obj0)
  {
    IntPtr num = (IntPtr) GCHandle.Alloc((object) null);
    *(long*) obj0 = (long) num.ToPointer();
    return obj0;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe ValueType _CrtImplementationDetails___2EAtExitLock__2E_handle() => (IntPtr) _Module_.__3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA != IntPtr.Zero ? (ValueType) GCHandle.FromIntPtr(new IntPtr(_Module_.__3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA)) : (ValueType) null;

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void _CrtImplementationDetails___2EAtExitLock__2E_lock_Construct(
    object value)
  {
    _Module_.__3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA = (void*) 0L;
    _Module_._CrtImplementationDetails___2EAtExitLock__2E_lock_Set(value);
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2EAtExitLock__2E_lock_Set(
    object value)
  {
    ValueType valueType = _Module_._CrtImplementationDetails___2EAtExitLock__2E_handle();
    if (valueType == null)
      _Module_.__3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA = GCHandle.ToIntPtr(GCHandle.Alloc(value)).ToPointer();
    else
      ((GCHandle) valueType).Target = value;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static object _CrtImplementationDetails___2EAtExitLock__2E_lock_Get()
  {
    ValueType valueType = _Module_._CrtImplementationDetails___2EAtExitLock__2E_handle();
    return valueType != null ? ((GCHandle) valueType).Target : (object) null;
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe void _CrtImplementationDetails___2EAtExitLock__2E_lock_Destruct()
  {
    ValueType valueType = _Module_._CrtImplementationDetails___2EAtExitLock__2E_handle();
    if (valueType == null)
      return;
    ((GCHandle) valueType).Free();
    _Module_.__3F_lock__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0PEAXEA = (void*) 0L;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool _CrtImplementationDetails___2EAtExitLock__2EIsInitialized() => _Module_._CrtImplementationDetails___2EAtExitLock__2E_lock_Get() != null;

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static void _CrtImplementationDetails___2EAtExitLock__2EAddRef()
  {
    if (!_Module_._CrtImplementationDetails___2EAtExitLock__2EIsInitialized())
    {
      _Module_._CrtImplementationDetails___2EAtExitLock__2E_lock_Construct(new object());
      _Module_.__3F_ref_count__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0HA = 0;
    }
    ++_Module_.__3F_ref_count__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0HA;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static void _CrtImplementationDetails___2EAtExitLock__2ERemoveRef()
  {
    _Module_.__3F_ref_count__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0HA += -1;
    if (_Module_.__3F_ref_count__40AtExitLock__40_CrtImplementationDetails___40__40__24__24Q0HA != 0)
      return;
    _Module_._CrtImplementationDetails___2EAtExitLock__2E_lock_Destruct();
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  [return: MarshalAs(UnmanagedType.U1)]
  internal static bool __3FA0x8481b400__2E__alloc_global_lock()
  {
    _Module_._CrtImplementationDetails___2EAtExitLock__2EAddRef();
    return _Module_._CrtImplementationDetails___2EAtExitLock__2EIsInitialized();
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static void __3FA0x8481b400__2E__dealloc_global_lock() => _Module_._CrtImplementationDetails___2EAtExitLock__2ERemoveRef();

  [SecurityCritical]
  internal static unsafe void _exit_callback()
  {
    if (_Module_.__3FA0x8481b400__2E__exit_list_size == 0UL)
      return;
    __FnPtr<void ()>* local1 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__3FA0x8481b400__2E__onexitbegin_m);
    __FnPtr<void ()>* local2 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__3FA0x8481b400__2E__onexitend_m);
    if ((IntPtr) local1 != -1L && (IntPtr) local1 != IntPtr.Zero && (IntPtr) local2 != IntPtr.Zero)
    {
      __FnPtr<void ()>* local3 = local1;
      __FnPtr<void ()>* local4 = local2;
      while (true)
      {
        __FnPtr<void ()>* local5;
        __FnPtr<void ()>* local6;
        do
        {
          do
          {
            local2 -= 8L;
            if (local2 < local1)
              goto label_7;
          }
          while (*(long*) local2 == (IntPtr) _Module_.EncodePointer((void*) 0L));
          void* voidPtr = _Module_.DecodePointer((void*) *(long*) local2);
          *(long*) local2 = (long) _Module_.EncodePointer((void*) 0L);
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void ()>) (IntPtr) voidPtr)();
          local5 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__3FA0x8481b400__2E__onexitbegin_m);
          local6 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__3FA0x8481b400__2E__onexitend_m);
        }
        while (local3 == local5 && local4 == local6);
        local3 = local5;
        local1 = local5;
        local4 = local6;
        local2 = local6;
      }
label_7:
      Marshal.FreeHGlobal(new IntPtr((void*) local1));
    }
    _Module_.__3FA0x8481b400__2E__dealloc_global_lock();
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe int _initatexit_m()
  {
    if (!_Module_.__3FA0x8481b400__2E__alloc_global_lock())
      return 0;
    _Module_.__3FA0x8481b400__2E__onexitbegin_m = (__FnPtr<void ()>*) _Module_.EncodePointer(Marshal.AllocHGlobal(256).ToPointer());
    _Module_.__3FA0x8481b400__2E__onexitend_m = _Module_.__3FA0x8481b400__2E__onexitbegin_m;
    _Module_.__3FA0x8481b400__2E__exit_list_size = 32UL;
    return 1;
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe int _initatexit_app_domain()
  {
    if (_Module_.__3FA0x8481b400__2E__alloc_global_lock())
    {
      _Module_.__onexitbegin_app_domain = (__FnPtr<void ()>*) _Module_.EncodePointer(Marshal.AllocHGlobal(256).ToPointer());
      _Module_.__onexitend_app_domain = _Module_.__onexitbegin_app_domain;
      _Module_.__exit_list_size_app_domain = 32UL;
    }
    return 1;
  }

  [HandleProcessCorruptedStateExceptions]
  [SecurityCritical]
  internal static unsafe void _app_exit_callback()
  {
    if (_Module_.__exit_list_size_app_domain == 0UL)
      return;
    __FnPtr<void ()>* local1 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__onexitbegin_app_domain);
    __FnPtr<void ()>* local2 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__onexitend_app_domain);
    try
    {
      if ((IntPtr) local1 == -1L || (IntPtr) local1 == IntPtr.Zero || (IntPtr) local2 == IntPtr.Zero)
        return;
      __FnPtr<void ()>* local3 = local1;
      __FnPtr<void ()>* local4 = local2;
      while (true)
      {
        __FnPtr<void ()>* local5;
        __FnPtr<void ()>* local6;
        do
        {
          do
          {
            local2 -= 8L;
          }
          while (local2 >= local1 && *(long*) local2 == (IntPtr) _Module_.EncodePointer((void*) 0L));
          if (local2 >= local1)
          {
            // ISSUE: cast to a function pointer type
            __FnPtr<void ()> local7 = (__FnPtr<void ()>) (IntPtr) _Module_.DecodePointer((void*) *(long*) local2);
            *(long*) local2 = (long) _Module_.EncodePointer((void*) 0L);
            // ISSUE: function pointer call
            __calli(local7)();
            local5 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__onexitbegin_app_domain);
            local6 = (__FnPtr<void ()>*) _Module_.DecodePointer((void*) _Module_.__onexitend_app_domain);
          }
          else
            goto label_12;
        }
        while (local3 == local5 && local4 == local6);
        local3 = local5;
        local1 = local5;
        local4 = local6;
        local2 = local6;
      }
label_12:;
    }
    finally
    {
      Marshal.FreeHGlobal(new IntPtr((void*) local1));
      _Module_.__3FA0x8481b400__2E__dealloc_global_lock();
    }
  }

  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  [SuppressUnmanagedCodeSecurity]
  [DllImport("KERNEL32.dll")]
  public static extern unsafe void* DecodePointer(void* _Ptr);

  [SecurityCritical]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  [SuppressUnmanagedCodeSecurity]
  [DllImport("KERNEL32.dll")]
  public static extern unsafe void* EncodePointer(void* _Ptr);

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe int _initterm_e(__FnPtr<int ()>* pfbegin, __FnPtr<int ()>* pfend)
  {
    int num1 = 0;
    if (pfbegin < pfend)
    {
      while (num1 == 0)
      {
        ulong num2 = (ulong) *(long*) pfbegin;
        if (num2 != 0UL)
        {
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          num1 = __calli((__FnPtr<int ()>) (long) num2)();
        }
        pfbegin += 8L;
        if (pfbegin >= pfend)
          break;
      }
    }
    return num1;
  }

  [SecurityCritical]
  [DebuggerStepThrough]
  internal static unsafe void _initterm(__FnPtr<void ()>* pfbegin, __FnPtr<void ()>* pfend)
  {
    if (pfbegin >= pfend)
      return;
    do
    {
      ulong num = (ulong) *(long*) pfbegin;
      if (num != 0UL)
      {
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void ()>) (long) num)();
      }
      pfbegin += 8L;
    }
    while (pfbegin < pfend);
  }

  [DebuggerStepThrough]
  internal static ModuleHandle _CrtImplementationDetails___2EThisModule__2EHandle() => typeof (ThisModule).Module.ModuleHandle;

  [SecurityCritical]
  [DebuggerStepThrough]
  [SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
  internal static unsafe void _initterm_m(__FnPtr<void* ()>* pfbegin, __FnPtr<void* ()>* pfend)
  {
    if (pfbegin >= pfend)
      return;
    do
    {
      ulong num = (ulong) *(long*) pfbegin;
      if (num != 0UL)
      {
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        void* voidPtr = __calli(_Module_._CrtImplementationDetails___2EThisModule__2EResolveMethod_void__20const__20__2A__20__clrcall__28void__29_((__FnPtr<void* ()>) (long) num))();
      }
      pfbegin += 8L;
    }
    while (pfbegin < pfend);
  }

  [DebuggerStepThrough]
  [SecurityCritical]
  internal static unsafe __FnPtr<void* ()> _CrtImplementationDetails___2EThisModule__2EResolveMethod_void__20const__20__2A__20__clrcall__28void__29_(
    __FnPtr<void* ()> methodToken)
  {
    // ISSUE: cast to a function pointer type
    return (__FnPtr<void* ()>) (IntPtr) _Module_._CrtImplementationDetails___2EThisModule__2EHandle().ResolveMethodHandle((int) methodToken).GetFunctionPointer().ToPointer();
  }

  [SecurityCritical]
  [HandleProcessCorruptedStateExceptions]
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
  [SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
  internal static unsafe void ___CxxCallUnwindDtor(__FnPtr<void (void*)> pDtor, void* pThis)
  {
    try
    {
      void* voidPtr = pThis;
      // ISSUE: function pointer call
      __calli(pDtor)(voidPtr);
    }
    catch (Exception ex) when (_Module_.__FrameUnwindFilter((_EXCEPTION_POINTERS*) Marshal.GetExceptionPointers()) != 0)
    {
    }
  }

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void* new__5B__5D([In] ulong obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe ulong* getGlobalPtr([In] int obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void nativePush64([In] ulong obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe ulong* nativeCall();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void nativeInit([In] ulong obj0);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void delete__5B__5D([In] void* obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern eGameVersion getGameVersion();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe HINSTANCE__* GetModuleHandleW([In] char* obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int createTexture([In] sbyte* obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int K32GetModuleInformation(
    [In] void* obj0,
    [In] HINSTANCE__* obj1,
    [In] _MODULEINFO* obj2,
    [In] uint obj3);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void drawTexture(
    [In] int obj0,
    [In] int obj1,
    [In] int obj2,
    [In] int obj3,
    [In] float obj4,
    [In] float obj5,
    [In] float obj6,
    [In] float obj7,
    [In] float obj8,
    [In] float obj9,
    [In] float obj10,
    [In] float obj11,
    [In] float obj12,
    [In] float obj13,
    [In] float obj14,
    [In] float obj15);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void* GetCurrentProcess();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern int __CxxQueryExceptionSize();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int __CxxDetectRethrow([In] void* obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void __CxxUnregisterExceptionObject([In] void* obj0, [In] int obj1);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int __CxxExceptionFilter(
    [In] void* obj0,
    [In] void* obj1,
    [In] int obj2,
    [In] void* obj3);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int __CxxRegisterExceptionObject([In] void* obj0, [In] void* obj1);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void matrixmul_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mdiv_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mmul_sse([In] float* obj0, [In] float obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void madd_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void msub_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mlerp_sse([In] float* obj0, [In] float* obj1, [In] float obj2, [In] float* obj3);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mneg_sse([In] float* obj0, [In] float* obj1);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mtranspose_sse([In] float* obj0, [In] float* obj1);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void mtransform_point_sse(
    [In] float* obj0,
    [In] float obj1,
    [In] float obj2,
    [In] float obj3,
    [In] float* obj4);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void minvtransform_point_sse(
    [In] float* obj0,
    [In] float obj1,
    [In] float obj2,
    [In] float obj3,
    [In] float* obj4);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vmul_sse([In] float* obj0, [In] float obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vdiv_sse([In] float* obj0, [In] float obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vadd_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vsub_sse([In] float* obj0, [In] float* obj1, [In] float* obj2);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vneg_sse([In] float* obj0, [In] float* obj1);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void vclamp_sse(
    [In] float* obj0,
    [In] float* obj1,
    [In] float* obj2,
    [In] float* obj3);

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe void* _getFiberPtrId();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void _cexit();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void Sleep([In] uint obj0);

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern void abort();

  [SuppressUnmanagedCodeSecurity]
  [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
  internal static extern void __security_init_cookie();

  [SuppressUnmanagedCodeSecurity]
  [DllImport("", EntryPoint = "", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
  [MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
  internal static extern unsafe int __FrameUnwindFilter([In] _EXCEPTION_POINTERS* obj0);
}
