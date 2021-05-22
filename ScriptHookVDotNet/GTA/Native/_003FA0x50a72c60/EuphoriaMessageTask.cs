// Decompiled with JetBrains decompiler
// Type: GTA.Native.?A0x50a72c60.EuphoriaMessageTask
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using System;
using System.Collections.Generic;

namespace GTA.Native.__3FA0x50a72c60
{
  internal class EuphoriaMessageTask : IScriptTask
  {
    public int _targetHandle;
    public string _message;
    public Dictionary<string, object> _arguments;

    public EuphoriaMessageTask(int target, string message, Dictionary<string, object> arguments)
    {
      this._targetHandle = target;
      this._message = message;
      this._arguments = arguments;
      // ISSUE: explicit constructor call
      base.__2Ector();
    }

    public virtual unsafe void Run()
    {
      long createNmMessageFunc = (long) MemoryAccess.CreateNmMessageFunc;
      long num1 = createNmMessageFunc;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      long num2 = __calli((__FnPtr<long (long)>) (num1 + (long) *(int*) (num1 + 34L) + 38L))(4632L);
      if (num2 == 0L)
        return;
      long num3 = num2;
      long num4 = num3 + 24L;
      long num5 = createNmMessageFunc;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      long num6 = __calli((__FnPtr<long (long, long, int)>) (num5 + (long) *(int*) (num5 + 60L) + 64L))((int) num3, num4, 64L);
      Dictionary<string, object>.Enumerator enumerator = this._arguments.GetEnumerator();
      if (enumerator.MoveNext())
      {
        do
        {
          KeyValuePair<string, object> current = enumerator.Current;
          IntPtr num7 = ScriptDomain.CurrentDomain.PinString(current.Key);
          if (current.Value.GetType() == typeof (bool))
          {
            int num8 = (bool) current.Value ? 1 : 0;
            long num9 = num2;
            long int64 = num7.ToInt64();
            int num10 = (int) (byte) num8;
            // ISSUE: function pointer call
            int num11 = (int) __calli(MemoryAccess.SetNmBoolAddress)((byte) num9, int64, (long) num10);
          }
          if (current.Value.GetType() == typeof (int))
          {
            long num8 = num2;
            long int64 = num7.ToInt64();
            int num9 = (int) current.Value;
            // ISSUE: function pointer call
            int num10 = (int) __calli(MemoryAccess.SetNmIntAddress)((int) num8, int64, (long) num9);
          }
          if (current.Value.GetType() == typeof (float))
          {
            long num8 = num2;
            long int64 = num7.ToInt64();
            double num9 = (double) (float) current.Value;
            // ISSUE: function pointer call
            int num10 = (int) __calli(MemoryAccess.SetNmFloatAddress)((float) num8, int64, (long) num9);
          }
          if (current.Value.GetType() == typeof (Vector3))
          {
            Vector3 vector3 = (Vector3) current.Value;
            long num8 = num2;
            long int64 = num7.ToInt64();
            double x = (double) vector3.X;
            double y = (double) vector3.Y;
            double z = (double) vector3.Z;
            // ISSUE: function pointer call
            int num9 = (int) __calli(MemoryAccess.SetNmVec3Address)((float) num8, (float) int64, (float) x, (long) y, (long) z);
          }
          if (current.Value.GetType() == typeof (string))
          {
            IntPtr num8 = ScriptDomain.CurrentDomain.PinString((string) current.Value);
            long num9 = num2;
            long int64_1 = num7.ToInt64();
            long int64_2 = num8.ToInt64();
            // ISSUE: function pointer call
            int num10 = (int) __calli(MemoryAccess.SetNmStringAddress)(num9, int64_1, int64_2);
          }
        }
        while (enumerator.MoveNext());
      }
      long giveNmMessageFunc = (long) MemoryAccess.GiveNmMessageFunc;
      long num12 = giveNmMessageFunc;
      long num13 = num12 + (long) *(int*) (num12 + 188L) + 192L;
      long num14 = giveNmMessageFunc;
      long num15 = num14 + (long) *(int*) (num14 + 206L) + 210L;
      long int64_3 = MemoryAccess.GetEntityAddress(this._targetHandle).ToInt64();
      bool flag = false;
      if (int64_3 == 0L || *(long*) (int64_3 + 48L) == 0L)
        return;
      long num16 = int64_3;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      long num17 = __calli((__FnPtr<long (long)>) *(long*) (*(long*) num16 + 88L))(num16);
      int num18;
      if (_Module_.getGameVersion() < (eGameVersion) 26)
      {
        num18 = *(int*) (giveNmMessageFunc + 78L);
      }
      else
      {
        long num7 = giveNmMessageFunc;
        num18 = *(int*) (num7 + (long) *(int*) (num7 + 76L) + 157L);
      }
      if (*(long*) (int64_3 + 48L) != num17 || (double) *(float*) ((long) num18 + int64_3) > (double) *(float*) (int64_3 + 640L))
        return;
      long num19 = num17;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if (__calli((__FnPtr<int (long)>) *(long*) (*(long*) num19 + 152L))(num19) == -1)
        return;
      long num20 = *(long*) ((long) *(int*) (giveNmMessageFunc + 147L) + int64_3);
      long num21 = *(long*) (num20 + 864L);
      long num22 = giveNmMessageFunc;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if (*(short*) (__calli((__FnPtr<long (long)>) (num22 + (long) *(int*) (num22 + 162L) + 166L))(num21) + 52L) != (short) 401)
      {
        sbyte num7 = *(sbyte*) num13;
        if (num7 != (sbyte) 0)
        {
          long num8 = num15;
          long num9 = giveNmMessageFunc;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (long)>) (num9 + (long) *(int*) (num9 + 211L) + 215L))(num8);
          num7 = *(sbyte*) num13;
        }
        int num10 = *(int*) (num20 + 1064L);
        if (num7 != (sbyte) 0)
        {
          long num8 = num15;
          long num9 = giveNmMessageFunc;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (long)>) (num9 + (long) *(int*) (num9 + 240L) + 244L))(num8);
        }
        int num11 = 0;
        if (0 < num10)
        {
          long num8 = num20 + 1060L;
          do
          {
            long num9 = *(long*) (num20 + (long) ((*(int*) num8 + num11 + 1) % 16 * 8) + 928L);
            if (num9 != 0L)
            {
              long num23 = num9;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              if (__calli((__FnPtr<int (long)>) *(long*) (*(long*) num23 + 24L))(num23) == 132)
              {
                long num24 = *(long*) (num9 + 40L);
                if (num24 != 0L)
                  flag = *(short*) (num24 + 52L) == (short) 401 || flag;
              }
            }
            ++num11;
          }
          while (num11 < num10);
          if (!flag)
            goto label_34;
        }
        else
          goto label_34;
      }
      long num25 = num17;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if (__calli((__FnPtr<int (long)>) *(long*) (*(long*) num25 + 152L))(num25) != -1)
      {
        IntPtr num7 = ScriptDomain.CurrentDomain.PinString(this._message);
        long num8 = num17;
        long int64_1 = num7.ToInt64();
        long num9 = num2;
        long num10 = giveNmMessageFunc;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (long, long, long)>) (num10 + (long) *(int*) (num10 + 426L) + 430L))(num8, int64_1, num9);
      }
label_34:
      long num26 = num2;
      long num27 = giveNmMessageFunc;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (long)>) (num27 + (long) *(int*) (num27 + 443L) + 447L))(num26);
    }
  }
}
