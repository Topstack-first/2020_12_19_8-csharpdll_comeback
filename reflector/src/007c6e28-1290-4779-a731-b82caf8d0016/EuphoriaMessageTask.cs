namespace GTA.Native._A0x50a72c60
{
    using GTA;
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

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
        }

        public virtual unsafe void Run()
        {
            long giveNmMessageFunc;
            long createNmMessageFunc = (long) MemoryAccess.CreateNmMessageFunc;
            long num2 = *(createNmMessageFunc + createNmMessageFunc[(int) 0x22]) + 0x26(0x1218L);
            if (num2 == 0)
            {
                return;
            }
            else
            {
                *(createNmMessageFunc + createNmMessageFunc[(int) 60]) + 0x40(num2, num2 + 0x18, 0x40);
                Dictionary<string, object>.Enumerator enumerator = this._arguments.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    do
                    {
                        KeyValuePair<string, object> current = enumerator.Current;
                        IntPtr ptr4 = ScriptDomain.CurrentDomain.PinString(current.Key);
                        if (current.Value.GetType() == typeof(bool))
                        {
                            int num16 = ((bool) current.Value) ? 1 : 0;
                            *MemoryAccess.SetNmBoolAddress(num2, ptr4.ToInt64(), (byte) num16);
                        }
                        if (current.Value.GetType() == typeof(int))
                        {
                            *MemoryAccess.SetNmIntAddress(num2, ptr4.ToInt64(), (int) current.Value);
                        }
                        if (current.Value.GetType() == typeof(float))
                        {
                            *MemoryAccess.SetNmFloatAddress(num2, ptr4.ToInt64(), (float) current.Value);
                        }
                        if (current.Value.GetType() == typeof(Vector3))
                        {
                            Vector3 vector = current.Value[0];
                            *MemoryAccess.SetNmVec3Address(num2, ptr4.ToInt64(), vector.X, vector.Y, vector.Z);
                        }
                        if (current.Value.GetType() == typeof(string))
                        {
                            IntPtr ptr3 = ScriptDomain.CurrentDomain.PinString((string) current.Value);
                            *MemoryAccess.SetNmStringAddress(num2, ptr4.ToInt64(), ptr3.ToInt64());
                        }
                    }
                    while (enumerator.MoveNext());
                }
                giveNmMessageFunc = (long) MemoryAccess.GiveNmMessageFunc;
                long num13 = (giveNmMessageFunc + giveNmMessageFunc[0xbcL]) + 0xc0L;
                long num12 = (giveNmMessageFunc + giveNmMessageFunc[0xceL]) + 210L;
                long num3 = MemoryAccess.GetEntityAddress(this._targetHandle).ToInt64();
                bool flag = false;
                if ((num3 == 0) || (num3[(int) 0x30] == 0))
                {
                    return;
                }
                else
                {
                    long num6 = *num3[0][(int) 0x58](num3);
                    int num11 = (getGameVersion() >= 0x1a) ? ((int) (giveNmMessageFunc + giveNmMessageFunc[0x4c])[0x9dL]) : ((int) giveNmMessageFunc[(int) 0x4e]);
                    if ((num3[(int) 0x30] != num6) || ((((long) num11)[(int) num3] > num3[640L]) || (*num6[0][0x98L](num6) == -1)))
                    {
                        return;
                    }
                    else
                    {
                        long num5 = giveNmMessageFunc[0x93L][(int) num3];
                        if (*((giveNmMessageFunc + giveNmMessageFunc[0xa2L]) + 0xa6L)(num5[0x360L])[(int) 0x34] != 0x191)
                        {
                            sbyte modopt(IsSignUnspecifiedByte) num8 = *((sbyte modopt(IsSignUnspecifiedByte)*) num13);
                            if (num8 != null)
                            {
                                *(giveNmMessageFunc + giveNmMessageFunc[0xd3L]) + 0xd7L(num12);
                                num8 = *((sbyte modopt(IsSignUnspecifiedByte)*) num13);
                            }
                            int num10 = *((int*) (num5 + 0x428L));
                            if (num8 != null)
                            {
                                *(giveNmMessageFunc + giveNmMessageFunc[240L]) + 0xf4L(num12);
                            }
                            int num4 = 0;
                            if (0 >= num10)
                            {
                                goto TR_0001;
                            }
                            else
                            {
                                long num15 = num5 + 0x424L;
                                while (true)
                                {
                                    long num7 = (num5 + ((((num15[0] + num4) + 1) % 0x10) * 8))[0x3a0L];
                                    if ((num7 != 0) && (*num7[0][(int) 0x18](num7) == 0x84))
                                    {
                                        long num9 = num7[(int) 40];
                                        if (num9 != 0)
                                        {
                                            flag = (num9[(int) 0x34] == 0x191) || flag;
                                        }
                                    }
                                    num4++;
                                    if (num4 >= num10)
                                    {
                                        if (flag)
                                        {
                                            break;
                                        }
                                        goto TR_0001;
                                    }
                                }
                            }
                        }
                        if (*num6[0][0x98L](num6) != -1)
                        {
                            IntPtr ptr = ScriptDomain.CurrentDomain.PinString(this._message);
                            *(giveNmMessageFunc + giveNmMessageFunc[0x1aaL]) + 430L(num6, ptr.ToInt64(), num2);
                        }
                    }
                }
            }
        TR_0001:
            *(giveNmMessageFunc + giveNmMessageFunc[0x1bbL]) + 0x1bfL(num2);
        }
    }
}

