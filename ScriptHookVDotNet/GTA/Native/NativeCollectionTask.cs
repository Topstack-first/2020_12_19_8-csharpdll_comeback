// Decompiled with JetBrains decompiler
// Type: GTA.Native.NativeCollectionTask
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System.Collections.Generic;

namespace GTA.Native
{
  internal class NativeCollectionTask : IScriptTask
  {
    public NativeCollection _collection;

    public virtual unsafe void Run()
    {
      List<NativeCollectionItem>.Enumerator enumerator = this._collection.GetEnumerator();
      if (!enumerator.MoveNext())
        return;
      do
      {
        NativeCollectionItem current = enumerator.Current;
        _Module_.nativeInit(current.Hash);
        InputArgument[] arguments = current.Arguments;
        int index = 0;
        if (0 < arguments.Length)
        {
          do
          {
            _Module_.nativePush64(arguments[index]._data);
            ++index;
          }
          while (index < arguments.Length);
        }
        _Module_.nativeCall();
      }
      while (enumerator.MoveNext());
    }
  }
}
