namespace GTA
{
    using GTA.Math;
    using GTA.Native;
    using System;
    using System.Drawing;

    public sealed class Scaleform : IDisposable, INativeValue
    {
        private int _handle;

        public Scaleform(string scaleformID)
        {
            InputArgument[] arguments = new InputArgument[] { scaleformID };
            this._handle = Function.Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, arguments);
        }

        public void CallFunction(string function, params object[] arguments)
        {
            this.CallFunctionHead(function, arguments);
            Function.Call(Hash._POP_SCALEFORM_MOVIE_FUNCTION_VOID, Array.Empty<InputArgument>());
        }

        internal void CallFunctionHead(string function, params object[] arguments)
        {
            InputArgument[] argumentArray1 = new InputArgument[] { this.Handle, function };
            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION, argumentArray1);
            foreach (object obj2 in arguments)
            {
                switch (obj2)
                {
                    case (int _):
                    {
                        InputArgument[] argumentArray2 = new InputArgument[] { (int) obj2 };
                        Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_INT, argumentArray2);
                        break;
                    }
                    case (string _):
                    {
                        InputArgument[] argumentArray3 = new InputArgument[] { MemoryAccess.StringPtr };
                        Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, argumentArray3);
                        InputArgument[] argumentArray4 = new InputArgument[] { (string) obj2 };
                        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray4);
                        Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING, Array.Empty<InputArgument>());
                        break;
                    }
                    case (char _):
                    {
                        InputArgument[] argumentArray5 = new InputArgument[] { MemoryAccess.StringPtr };
                        Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, argumentArray5);
                        InputArgument[] argumentArray6 = new InputArgument[] { obj2.ToString() };
                        Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argumentArray6);
                        Function.Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING, Array.Empty<InputArgument>());
                        break;
                    }
                    case (float _):
                    {
                        InputArgument[] argumentArray7 = new InputArgument[] { (float) obj2 };
                        Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray7);
                        break;
                    }
                    case (double _):
                    {
                        InputArgument[] argumentArray8 = new InputArgument[] { (float) ((double) obj2) };
                        Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_FLOAT, argumentArray8);
                        break;
                    }
                    default:
                        if (obj2 as bool)
                        {
                            InputArgument[] argumentArray9 = new InputArgument[] { (bool) obj2 };
                            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_BOOL, argumentArray9);
                        }
                        else
                        {
                            if (!(obj2 is ScaleformArgumentTXD))
                            {
                                throw new ArgumentException($"Unknown argument type {obj2.GetType().Name} passed to scaleform with handle {this.Handle}.", "arguments");
                            }
                            InputArgument[] argumentArray10 = new InputArgument[] { ((ScaleformArgumentTXD) obj2)._txd };
                            Function.Call(Hash._PUSH_SCALEFORM_MOVIE_FUNCTION_PARAMETER_STRING, argumentArray10);
                        }
                        break;
                }
            }
        }

        public int CallFunctionReturn(string function, params object[] arguments)
        {
            this.CallFunctionHead(function, arguments);
            return Function.Call<int>(Hash._POP_SCALEFORM_MOVIE_FUNCTION, Array.Empty<InputArgument>());
        }

        public unsafe void Dispose()
        {
            if (this.IsLoaded)
            {
                fixed (int* numRef = ((int*) this._handle))
                {
                    InputArgument[] arguments = new InputArgument[] { numRef };
                    Function.Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, arguments);
                }
            }
            GC.SuppressFinalize(this);
        }

        public void Render2D()
        {
            InputArgument[] arguments = new InputArgument[] { this.Handle, 0xff, 0xff, 0xff, 0xff, 0 };
            Function.Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, arguments);
        }

        public void Render2DScreenSpace(PointF location, PointF size)
        {
            float num4 = location.X / 1280f;
            float num3 = location.Y / 720f;
            float num2 = size.X / 1280f;
            float num = size.Y / 720f;
            InputArgument[] arguments = new InputArgument[9];
            arguments[0] = this.Handle;
            arguments[1] = num4 + (num2 / 2f);
            arguments[2] = num3 + (num / 2f);
            arguments[3] = num2;
            arguments[4] = num;
            arguments[5] = 0xff;
            arguments[6] = 0xff;
            arguments[7] = 0xff;
            arguments[8] = 0xff;
            Function.Call(Hash.DRAW_SCALEFORM_MOVIE, arguments);
        }

        public void Render3D(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = this.Handle;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = rotation.X;
            arguments[5] = rotation.Y;
            arguments[6] = rotation.Z;
            arguments[7] = 2f;
            arguments[8] = 2f;
            arguments[9] = 1f;
            arguments[10] = scale.X;
            arguments[11] = scale.Y;
            arguments[12] = scale.Z;
            arguments[13] = 2;
            Function.Call(Hash._DRAW_SCALEFORM_MOVIE_3D_NON_ADDITIVE, arguments);
        }

        public void Render3DAdditive(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            InputArgument[] arguments = new InputArgument[14];
            arguments[0] = this.Handle;
            arguments[1] = position.X;
            arguments[2] = position.Y;
            arguments[3] = position.Z;
            arguments[4] = rotation.X;
            arguments[5] = rotation.Y;
            arguments[6] = rotation.Z;
            arguments[7] = 2f;
            arguments[8] = 2f;
            arguments[9] = 1f;
            arguments[10] = scale.X;
            arguments[11] = scale.Y;
            arguments[12] = scale.Z;
            arguments[13] = 2;
            Function.Call(Hash.DRAW_SCALEFORM_MOVIE_3D, arguments);
        }

        public int Handle =>
            this._handle;

        public ulong NativeValue
        {
            get => 
                (ulong) this.Handle;
            set => 
                this._handle = (int) value;
        }

        public bool IsValid =>
            this.Handle != 0;

        public bool IsLoaded
        {
            get
            {
                InputArgument[] arguments = new InputArgument[] { this.Handle };
                return Function.Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, arguments);
            }
        }
    }
}

