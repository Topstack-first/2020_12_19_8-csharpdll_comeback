// Decompiled with JetBrains decompiler
// Type: GTA.TaskSequence
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Native;
using System;

namespace GTA
{
  public sealed class TaskSequence : IDisposable
  {
    private static Ped _nullPed;

    public unsafe TaskSequence()
    {
      int num;
      Function.Call(Hash.OPEN_SEQUENCE_TASK, (InputArgument) (void*) &num);
      this.Handle = num;
      if (TaskSequence._nullPed != null)
        return;
      TaskSequence._nullPed = new Ped(0);
    }

    public TaskSequence(int handle)
    {
      this.Handle = handle;
      if (TaskSequence._nullPed != null)
        return;
      TaskSequence._nullPed = new Ped(0);
    }

    public unsafe void Dispose()
    {
      int handle = this.Handle;
      Function.Call(Hash.CLEAR_SEQUENCE_TASK, (InputArgument) (void*) &handle);
      this.Handle = handle;
      GC.SuppressFinalize((object) this);
    }

    public int Handle { get; private set; }

    public int Count { get; private set; }

    public bool IsClosed { get; private set; }

    public Tasks AddTask
    {
      get
      {
        if (this.IsClosed)
          throw new Exception("You can't add tasks to a closed sequence!");
        ++this.Count;
        return TaskSequence._nullPed.Task;
      }
    }

    public void Close() => this.Close(false);

    public void Close(bool repeat)
    {
      if (this.IsClosed)
        return;
      Function.Call(Hash.SET_SEQUENCE_TO_REPEAT, (InputArgument) this.Handle, (InputArgument) repeat);
      Function.Call(Hash.CLOSE_SEQUENCE_TASK, (InputArgument) this.Handle);
      this.IsClosed = true;
    }
  }
}
