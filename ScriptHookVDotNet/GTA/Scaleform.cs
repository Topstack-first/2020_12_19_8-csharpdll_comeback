// Decompiled with JetBrains decompiler
// Type: GTA.Scaleform
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using GTA.Math;
using GTA.Native;
using System;
using System.Drawing;

namespace GTA
{
  public sealed class Scaleform : IDisposable, INativeValue
  {
    private int _handle;

    public Scaleform(string scaleformID) => this._handle = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, (InputArgument) scaleformID);

    public unsafe void Dispose()
    {
      if (this.IsLoaded)
      {
        fixed (int* numPtr = &this._handle)
          Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, (InputArgument) (void*) numPtr);
      }
      GC.SuppressFinalize((object) this);
    }

    public int Handle => this._handle;

    public ulong NativeValue
    {
      get => (ulong) this.Handle;
      set => this._handle = (int) value;
    }

    public bool IsValid => (uint) this.Handle > 0U;

    public bool IsLoaded => Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, (InputArgument) this.Handle);

    public void CallFunction(string function, params object[] arguments)
    {
      this.CallFunctionHead(function, arguments);
      Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID, (InputArgument[]) Array.Empty<InputArgument>());
    }

    public int CallFunctionReturn(string function, params object[] arguments)
    {
      this.CallFunctionHead(function, arguments);
      return Function.Call<int>(Hash._POP_SCALEFORM_MOVIE_FUNCTION, (InputArgument[]) Array.Empty<InputArgument>());
    }

    internal void CallFunctionHead(string function, params object[] arguments)
    {
      Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, (InputArgument) this.Handle, (InputArgument) function);
      foreach (object obj in arguments)
      {
        switch (obj)
        {
          case int num:
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, (InputArgument) num);
            break;
          case string _:
            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, (InputArgument) MemoryAccess.StringPtr);
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) (string) obj);
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING, (InputArgument[]) Array.Empty<InputArgument>());
            break;
          case char _:
            Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, (InputArgument) MemoryAccess.StringPtr);
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (InputArgument) obj.ToString());
            Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING, (InputArgument[]) Array.Empty<InputArgument>());
            break;
          case float num:
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, (InputArgument) num);
            break;
          case double num:
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, (InputArgument) (float) num);
            break;
          case bool flag:
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, (InputArgument) flag);
            break;
          case ScaleformArgumentTXD _:
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, (InputArgument) ((ScaleformArgumentTXD) obj)._txd);
            break;
          default:
            throw new ArgumentException(string.Format("Unknown argument type {0} passed to scaleform with handle {1}.", (object) obj.GetType().Name, (object) this.Handle), nameof (arguments));
        }
      }
    }

    public void Render2D() => Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, (InputArgument) this.Handle, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);

    public void Render2DScreenSpace(PointF location, PointF size)
    {
      float num1 = location.X / 1280f;
      float num2 = location.Y / 720f;
      float num3 = size.X / 1280f;
      float num4 = size.Y / 720f;
      Function.Call(Hash.DRAW_SCALEFORM_MOVIE, (InputArgument) this.Handle, (InputArgument) (num1 + num3 / 2f), (InputArgument) (num2 + num4 / 2f), (InputArgument) num3, (InputArgument) num4, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue);
    }

    public void Render3D(Vector3 position, Vector3 rotation, Vector3 scale) => Function.Call(Hash._DRAW_SCALEFORM_MOVIE_3D_NON_ADDITIVE, (InputArgument) this.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) 2f, (InputArgument) 2f, (InputArgument) 1f, (InputArgument) scale.X, (InputArgument) scale.Y, (InputArgument) scale.Z, (InputArgument) 2);

    public void Render3DAdditive(Vector3 position, Vector3 rotation, Vector3 scale) => Function.Call(Hash.DRAW_SCALEFORM_MOVIE_3D, (InputArgument) this.Handle, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) rotation.X, (InputArgument) rotation.Y, (InputArgument) rotation.Z, (InputArgument) 2f, (InputArgument) 2f, (InputArgument) 1f, (InputArgument) scale.X, (InputArgument) scale.Y, (InputArgument) scale.Z, (InputArgument) 2);
  }
}
