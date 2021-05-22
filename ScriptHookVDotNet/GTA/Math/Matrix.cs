// Decompiled with JetBrains decompiler
// Type: GTA.Math.Matrix
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace GTA.Math
{
  [Serializable]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  public struct Matrix : IEquatable<Matrix>
  {
    public float M11;
    public float M12;
    public float M13;
    public float M14;
    public float M21;
    public float M22;
    public float M23;
    public float M24;
    public float M31;
    public float M32;
    public float M33;
    public float M34;
    public float M41;
    public float M42;
    public float M43;
    public float M44;

    [Browsable(false)]
    public float this[int row, int column]
    {
      get
      {
        switch (row)
        {
          case 0:
          case 1:
          case 2:
          case 3:
            switch (column)
            {
              case 0:
              case 1:
              case 2:
              case 3:
                switch (row * 4 + column)
                {
                  case 0:
                    return this.M11;
                  case 1:
                    return this.M12;
                  case 2:
                    return this.M13;
                  case 3:
                    return this.M14;
                  case 4:
                    return this.M21;
                  case 5:
                    return this.M22;
                  case 6:
                    return this.M23;
                  case 7:
                    return this.M24;
                  case 8:
                    return this.M31;
                  case 9:
                    return this.M32;
                  case 10:
                    return this.M33;
                  case 11:
                    return this.M34;
                  case 12:
                    return this.M41;
                  case 13:
                    return this.M42;
                  case 14:
                    return this.M43;
                  case 15:
                    return this.M44;
                  default:
                    return 0.0f;
                }
              default:
                throw new ArgumentOutOfRangeException(nameof (column), "Rows and columns for matrices run from 0 to 3, inclusive.");
            }
          default:
            throw new ArgumentOutOfRangeException(nameof (row), "Rows and columns for matrices run from 0 to 3, inclusive.");
        }
      }
      set
      {
        switch (row)
        {
          case 0:
          case 1:
          case 2:
          case 3:
            switch (column)
            {
              case 0:
              case 1:
              case 2:
              case 3:
                switch (row * 4 + column)
                {
                  case 0:
                    this.M11 = value;
                    return;
                  case 1:
                    this.M12 = value;
                    return;
                  case 2:
                    this.M13 = value;
                    return;
                  case 3:
                    this.M14 = value;
                    return;
                  case 4:
                    this.M21 = value;
                    return;
                  case 5:
                    this.M22 = value;
                    return;
                  case 6:
                    this.M23 = value;
                    return;
                  case 7:
                    this.M24 = value;
                    return;
                  case 8:
                    this.M31 = value;
                    return;
                  case 9:
                    this.M32 = value;
                    return;
                  case 10:
                    this.M33 = value;
                    return;
                  case 11:
                    this.M34 = value;
                    return;
                  case 12:
                    this.M41 = value;
                    return;
                  case 13:
                    this.M42 = value;
                    return;
                  case 14:
                    this.M43 = value;
                    return;
                  case 15:
                    this.M44 = value;
                    return;
                  default:
                    return;
                }
              default:
                throw new ArgumentOutOfRangeException(nameof (column), "Rows and columns for matrices run from 0 to 3, inclusive.");
            }
          default:
            throw new ArgumentOutOfRangeException(nameof (row), "Rows and columns for matrices run from 0 to 3, inclusive.");
        }
      }
    }

    public static Matrix Identity => new Matrix()
    {
      M11 = 1f,
      M22 = 1f,
      M33 = 1f,
      M44 = 1f
    };

    [Browsable(false)]
    public bool IsIdentity
    {
      [return: MarshalAs(UnmanagedType.U1)] get => (double) this.M11 == 1.0 && (double) this.M22 == 1.0 && ((double) this.M33 == 1.0 && (double) this.M44 == 1.0) && ((double) this.M12 == 0.0 && (double) this.M13 == 0.0 && ((double) this.M14 == 0.0 && (double) this.M21 == 0.0)) && ((double) this.M23 == 0.0 && (double) this.M24 == 0.0 && ((double) this.M31 == 0.0 && (double) this.M32 == 0.0) && ((double) this.M34 == 0.0 && (double) this.M41 == 0.0 && ((double) this.M42 == 0.0 && (double) this.M43 == 0.0)));
    }

    public bool HasInverse
    {
      [return: MarshalAs(UnmanagedType.U1)] get => (double) this.Determinant() != 0.0;
    }

    public static unsafe Matrix FromArray(float[] floatArray)
    {
      if (floatArray.Length != 16)
        throw new Exception("Array must contain 16 items to be converted to a 4*4 Matrix");
      Matrix matrix = new Matrix();
      IntPtr destination = new IntPtr((void*) &matrix);
      Marshal.Copy(floatArray, 0, destination, 16);
      return matrix;
    }

    public float Determinant()
    {
      float m44 = this.M44;
      float m33 = this.M33;
      float m43 = this.M43;
      float m34 = this.M34;
      float num1 = (float) ((double) m33 * (double) m44 - (double) m34 * (double) m43);
      float m32 = this.M32;
      float m42 = this.M42;
      float num2 = (float) ((double) m32 * (double) m44 - (double) m42 * (double) m34);
      float num3 = (float) ((double) m32 * (double) m43 - (double) m42 * (double) m33);
      float m31 = this.M31;
      float m41 = this.M41;
      float num4 = (float) ((double) m31 * (double) m44 - (double) m41 * (double) m34);
      float num5 = (float) ((double) m31 * (double) m43 - (double) m41 * (double) m33);
      float num6 = (float) ((double) m31 * (double) m42 - (double) m41 * (double) m32);
      float m22 = this.M22;
      float m23 = this.M23;
      float m24 = this.M24;
      float m21 = this.M21;
      return (float) ((double) this.M11 * ((double) m22 * (double) num1 - (double) m23 * (double) num2 + (double) m24 * (double) num3) - (double) this.M12 * ((double) m21 * (double) num1 - (double) m23 * (double) num4 + (double) m24 * (double) num5) + (double) this.M13 * ((double) m21 * (double) num2 - (double) m22 * (double) num4 + (double) m24 * (double) num6) - (double) this.M14 * ((double) m21 * (double) num3 - (double) m22 * (double) num5 + (double) m23 * (double) num6));
    }

    public static Matrix Inverse(Matrix matrix)
    {
      matrix.Inverse();
      return matrix;
    }

    public void Inverse()
    {
      float num1 = this.Determinant();
      if ((double) num1 == 0.0)
        return;
      float num2 = 1f / num1;
      float m44 = this.M44;
      float num3 = m44;
      float m43 = this.M43;
      float num4 = m43;
      float m42 = this.M42;
      float num5 = m42;
      float m34 = this.M34;
      float num6 = m34;
      float m33 = this.M33;
      float num7 = m33;
      float m32 = this.M32;
      float num8 = m32;
      float m24 = this.M24;
      float num9 = m24;
      float m23 = this.M23;
      float num10 = m23;
      float m22 = this.M22;
      float num11 = m22;
      float num12 = m44;
      float num13 = m43;
      float m41 = this.M41;
      float num14 = m41;
      float num15 = m34;
      float num16 = m33;
      float m31 = this.M31;
      float num17 = m31;
      float num18 = m24;
      float num19 = m23;
      float m21 = this.M21;
      float num20 = m21;
      float num21 = m44;
      float num22 = m42;
      float num23 = m41;
      float num24 = m34;
      float num25 = m32;
      float num26 = m31;
      float num27 = m24;
      float num28 = m22;
      float num29 = m21;
      float num30 = m43;
      float num31 = m42;
      float num32 = m41;
      float num33 = m33;
      float num34 = m32;
      float num35 = m31;
      float num36 = m23;
      float num37 = m22;
      float num38 = m21;
      float num39 = m44;
      float num40 = m43;
      float num41 = m42;
      float num42 = m34;
      float num43 = m33;
      float num44 = m32;
      float m14 = this.M14;
      float num45 = m14;
      float m13 = this.M13;
      float num46 = m13;
      float m12 = this.M12;
      float num47 = m12;
      float num48 = m44;
      float num49 = m43;
      float num50 = m41;
      float num51 = m34;
      float num52 = m33;
      float num53 = m31;
      float num54 = m14;
      float num55 = m13;
      float m11 = this.M11;
      float num56 = m11;
      float num57 = m44;
      float num58 = m42;
      float num59 = m41;
      float num60 = m34;
      float num61 = m32;
      float num62 = m31;
      float num63 = m14;
      float num64 = m12;
      float num65 = m11;
      float num66 = m43;
      float num67 = m42;
      float num68 = m41;
      float num69 = m33;
      float num70 = m32;
      float num71 = m31;
      float num72 = m13;
      float num73 = m12;
      float num74 = m11;
      float num75 = m44;
      float num76 = m43;
      float num77 = m42;
      float num78 = m24;
      float num79 = m23;
      float num80 = m22;
      float num81 = m14;
      float num82 = m13;
      float num83 = m12;
      float num84 = m44;
      float num85 = m43;
      float num86 = m41;
      float num87 = m24;
      float num88 = m23;
      float num89 = m21;
      float num90 = m14;
      float num91 = m13;
      float num92 = m11;
      float num93 = m44;
      float num94 = m42;
      float num95 = m41;
      float num96 = m24;
      float num97 = m22;
      float num98 = m21;
      float num99 = m14;
      float num100 = m12;
      float num101 = m11;
      float num102 = m43;
      float num103 = m42;
      float num104 = m41;
      float num105 = m23;
      float num106 = m22;
      float num107 = m21;
      float num108 = m13;
      float num109 = m12;
      float num110 = m11;
      float num111 = m34;
      float num112 = m33;
      float num113 = m32;
      float num114 = m24;
      float num115 = m23;
      float num116 = m22;
      float num117 = m14;
      float num118 = m13;
      float num119 = m12;
      float num120 = m34;
      float num121 = m33;
      float num122 = m31;
      float num123 = m24;
      float num124 = m23;
      float num125 = m21;
      float num126 = m14;
      float num127 = m13;
      float num128 = m11;
      float num129 = m34;
      float num130 = m32;
      float num131 = m31;
      float num132 = m24;
      float num133 = m22;
      float num134 = m21;
      float num135 = m14;
      float num136 = m12;
      float num137 = m11;
      float num138 = m33;
      float num139 = m32;
      float num140 = m31;
      float num141 = m23;
      float num142 = m22;
      float num143 = m21;
      float num144 = m13;
      float num145 = m12;
      float num146 = m11;
      this.M11 = (float) (((double) num3 * (double) num7 - (double) num4 * (double) num6) * (double) num11 - ((double) num3 * (double) num8 - (double) num5 * (double) num6) * (double) num10 + ((double) num4 * (double) num8 - (double) num5 * (double) num7) * (double) num9) * num2;
      this.M12 = (float) -(((double) num43 * (double) num39 - (double) num42 * (double) num40) * (double) num47 - ((double) num44 * (double) num39 - (double) num42 * (double) num41) * (double) num46 + ((double) num44 * (double) num40 - (double) num43 * (double) num41) * (double) num45) * num2;
      this.M13 = (float) (((double) num79 * (double) num75 - (double) num78 * (double) num76) * (double) num83 - ((double) num80 * (double) num75 - (double) num78 * (double) num77) * (double) num82 + ((double) num80 * (double) num76 - (double) num79 * (double) num77) * (double) num81) * num2;
      this.M14 = (float) -(((double) num115 * (double) num111 - (double) num114 * (double) num112) * (double) num119 - ((double) num116 * (double) num111 - (double) num114 * (double) num113) * (double) num118 + ((double) num116 * (double) num112 - (double) num115 * (double) num113) * (double) num117) * num2;
      this.M21 = (float) -(((double) num16 * (double) num12 - (double) num15 * (double) num13) * (double) num20 - ((double) num17 * (double) num12 - (double) num15 * (double) num14) * (double) num19 + ((double) num17 * (double) num13 - (double) num16 * (double) num14) * (double) num18) * num2;
      this.M22 = (float) (((double) num52 * (double) num48 - (double) num51 * (double) num49) * (double) num56 - ((double) num53 * (double) num48 - (double) num51 * (double) num50) * (double) num55 + ((double) num53 * (double) num49 - (double) num52 * (double) num50) * (double) num54) * num2;
      this.M23 = (float) -(((double) num88 * (double) num84 - (double) num87 * (double) num85) * (double) num92 - ((double) num89 * (double) num84 - (double) num87 * (double) num86) * (double) num91 + ((double) num89 * (double) num85 - (double) num88 * (double) num86) * (double) num90) * num2;
      this.M24 = (float) (((double) num124 * (double) num120 - (double) num123 * (double) num121) * (double) num128 - ((double) num125 * (double) num120 - (double) num123 * (double) num122) * (double) num127 + ((double) num125 * (double) num121 - (double) num124 * (double) num122) * (double) num126) * num2;
      this.M31 = (float) (((double) num25 * (double) num21 - (double) num24 * (double) num22) * (double) num29 - ((double) num26 * (double) num21 - (double) num24 * (double) num23) * (double) num28 + ((double) num26 * (double) num22 - (double) num25 * (double) num23) * (double) num27) * num2;
      this.M32 = (float) -(((double) num61 * (double) num57 - (double) num60 * (double) num58) * (double) num65 - ((double) num62 * (double) num57 - (double) num60 * (double) num59) * (double) num64 + ((double) num62 * (double) num58 - (double) num61 * (double) num59) * (double) num63) * num2;
      this.M33 = (float) (((double) num97 * (double) num93 - (double) num96 * (double) num94) * (double) num101 - ((double) num98 * (double) num93 - (double) num96 * (double) num95) * (double) num100 + ((double) num98 * (double) num94 - (double) num97 * (double) num95) * (double) num99) * num2;
      this.M34 = (float) -(((double) num133 * (double) num129 - (double) num132 * (double) num130) * (double) num137 - ((double) num134 * (double) num129 - (double) num132 * (double) num131) * (double) num136 + ((double) num134 * (double) num130 - (double) num133 * (double) num131) * (double) num135) * num2;
      this.M41 = (float) -(((double) num34 * (double) num30 - (double) num33 * (double) num31) * (double) num38 - ((double) num35 * (double) num30 - (double) num33 * (double) num32) * (double) num37 + ((double) num35 * (double) num31 - (double) num34 * (double) num32) * (double) num36) * num2;
      this.M42 = (float) (((double) num70 * (double) num66 - (double) num69 * (double) num67) * (double) num74 - ((double) num71 * (double) num66 - (double) num69 * (double) num68) * (double) num73 + ((double) num71 * (double) num67 - (double) num70 * (double) num68) * (double) num72) * num2;
      this.M43 = (float) -(((double) num106 * (double) num102 - (double) num105 * (double) num103) * (double) num110 - ((double) num107 * (double) num102 - (double) num105 * (double) num104) * (double) num109 + ((double) num107 * (double) num103 - (double) num106 * (double) num104) * (double) num108) * num2;
      this.M44 = (float) (((double) num142 * (double) num138 - (double) num141 * (double) num139) * (double) num146 - ((double) num143 * (double) num138 - (double) num141 * (double) num140) * (double) num145 + ((double) num143 * (double) num139 - (double) num142 * (double) num140) * (double) num144) * num2;
    }

    public unsafe Vector3 TransformPoint(Vector3 point)
    {
      fixed (Matrix* matrixPtr = &this)
      {
        _Module_.mtransform_point_sse((float*) matrixPtr, point.X, point.Y, point.Z, (float*) &point);
        return point;
      }
    }

    public unsafe Vector3 InverseTransformPoint(Vector3 point)
    {
      fixed (Matrix* matrixPtr = &this)
      {
        _Module_.minvtransform_point_sse((float*) matrixPtr, point.X, point.Y, point.Z, (float*) &point);
        return point;
      }
    }

    public static unsafe Matrix Add(Matrix left, Matrix right)
    {
      _Module_.madd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Subtract(Matrix left, Matrix right)
    {
      _Module_.msub_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Multiply(Matrix left, float right)
    {
      _Module_.mmul_sse((float*) &left, right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Multiply(Matrix left, Matrix right)
    {
      _Module_.matrixmul_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Divide(Matrix left, float right)
    {
      _Module_.mmul_sse((float*) &left, 1f / right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Divide(Matrix left, Matrix right)
    {
      _Module_.mdiv_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix Negate(Matrix matrix)
    {
      _Module_.mneg_sse((float*) &matrix, (float*) &matrix);
      return matrix;
    }

    public static unsafe Matrix Lerp(Matrix start, Matrix end, float amount)
    {
      _Module_.mlerp_sse((float*) &start, (float*) &end, amount, (float*) &start);
      return start;
    }

    public static Matrix RotationX(float angle)
    {
      Matrix matrix = new Matrix();
      double num1 = (double) angle;
      float num2 = (float) System.Math.Cos(num1);
      float num3 = (float) System.Math.Sin(num1);
      matrix.M11 = 1f;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = num2;
      matrix.M23 = num3;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = -num3;
      matrix.M33 = num2;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static Matrix RotationY(float angle)
    {
      Matrix matrix = new Matrix();
      double num1 = (double) angle;
      float num2 = (float) System.Math.Cos(num1);
      float num3 = (float) System.Math.Sin(num1);
      matrix.M11 = num2;
      matrix.M12 = 0.0f;
      matrix.M13 = -num3;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = 1f;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = num3;
      matrix.M32 = 0.0f;
      matrix.M33 = num2;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static Matrix RotationZ(float angle)
    {
      Matrix matrix = new Matrix();
      double num1 = (double) angle;
      float num2 = (float) System.Math.Cos(num1);
      float num3 = (float) System.Math.Sin(num1);
      matrix.M11 = num2;
      matrix.M12 = num3;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = -num3;
      matrix.M22 = num2;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = 1f;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static Matrix RotationAxis(Vector3 axis, float angle)
    {
      if ((double) axis.LengthSquared() != 1.0)
        axis.Normalize();
      Matrix matrix = new Matrix();
      float x = axis.X;
      float y = axis.Y;
      float z = axis.Z;
      double num1 = (double) angle;
      float num2 = (float) System.Math.Cos(num1);
      float num3 = (float) System.Math.Sin(num1);
      double num4 = (double) x;
      float num5 = (float) (num4 * num4);
      double num6 = (double) y;
      float num7 = (float) (num6 * num6);
      double num8 = (double) z;
      float num9 = (float) (num8 * num8);
      float num10 = y * x;
      float num11 = z * x;
      float num12 = z * y;
      matrix.M11 = (1f - num5) * num2 + num5;
      double num13 = (double) num10;
      double num14 = num13 - (double) num2 * num13;
      double num15 = (double) num3 * (double) z;
      matrix.M12 = (float) (num15 + num14);
      double num16 = (double) num11;
      double num17 = num16 - (double) num2 * num16;
      double num18 = (double) num3 * (double) y;
      matrix.M13 = (float) (num17 - num18);
      matrix.M14 = 0.0f;
      matrix.M21 = (float) (num14 - num15);
      matrix.M22 = (1f - num7) * num2 + num7;
      double num19 = (double) num12;
      double num20 = num19 - (double) num2 * num19;
      double num21 = (double) num3 * (double) x;
      matrix.M23 = (float) (num21 + num20);
      matrix.M24 = 0.0f;
      matrix.M31 = (float) (num18 + num17);
      matrix.M32 = (float) (num20 - num21);
      matrix.M33 = (1f - num9) * num2 + num9;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static Matrix RotationQuaternion(Quaternion rotation)
    {
      Matrix matrix = new Matrix();
      float x = rotation.X;
      double num1 = (double) x;
      float num2 = (float) (num1 * num1);
      float y = rotation.Y;
      double num3 = (double) y;
      float num4 = (float) (num3 * num3);
      float z = rotation.Z;
      double num5 = (double) z;
      float num6 = (float) (num5 * num5);
      float num7 = y * x;
      float w = rotation.W;
      float num8 = w * z;
      float num9 = z * x;
      float num10 = w * y;
      float num11 = z * y;
      float num12 = w * x;
      matrix.M11 = (float) (1.0 - ((double) num6 + (double) num4) * 2.0);
      matrix.M12 = (float) (((double) num8 + (double) num7) * 2.0);
      matrix.M13 = (float) (((double) num9 - (double) num10) * 2.0);
      matrix.M14 = 0.0f;
      matrix.M21 = (float) (((double) num7 - (double) num8) * 2.0);
      matrix.M22 = (float) (1.0 - ((double) num6 + (double) num2) * 2.0);
      matrix.M23 = (float) (((double) num12 + (double) num11) * 2.0);
      matrix.M24 = 0.0f;
      matrix.M31 = (float) (((double) num10 + (double) num9) * 2.0);
      matrix.M32 = (float) (((double) num11 - (double) num12) * 2.0);
      matrix.M33 = (float) (1.0 - ((double) num4 + (double) num2) * 2.0);
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll) => Matrix.RotationQuaternion(Quaternion.RotationYawPitchRoll(yaw, pitch, roll));

    public static Matrix Scaling(Vector3 scale) => new Matrix()
    {
      M11 = scale.X,
      M12 = 0.0f,
      M13 = 0.0f,
      M14 = 0.0f,
      M21 = 0.0f,
      M22 = scale.Y,
      M23 = 0.0f,
      M24 = 0.0f,
      M31 = 0.0f,
      M32 = 0.0f,
      M33 = scale.Z,
      M34 = 0.0f,
      M41 = 0.0f,
      M42 = 0.0f,
      M43 = 0.0f,
      M44 = 1f
    };

    public static Matrix Scaling(float x, float y, float z) => new Matrix()
    {
      M11 = x,
      M12 = 0.0f,
      M13 = 0.0f,
      M14 = 0.0f,
      M21 = 0.0f,
      M22 = y,
      M23 = 0.0f,
      M24 = 0.0f,
      M31 = 0.0f,
      M32 = 0.0f,
      M33 = z,
      M34 = 0.0f,
      M41 = 0.0f,
      M42 = 0.0f,
      M43 = 0.0f,
      M44 = 1f
    };

    public static Matrix Translation(Vector3 amount) => new Matrix()
    {
      M11 = 1f,
      M12 = 0.0f,
      M13 = 0.0f,
      M14 = 0.0f,
      M21 = 0.0f,
      M22 = 1f,
      M23 = 0.0f,
      M24 = 0.0f,
      M31 = 0.0f,
      M32 = 0.0f,
      M33 = 1f,
      M34 = 0.0f,
      M41 = amount.X,
      M42 = amount.Y,
      M43 = amount.Z,
      M44 = 1f
    };

    public static Matrix Translation(float x, float y, float z) => new Matrix()
    {
      M11 = 1f,
      M12 = 0.0f,
      M13 = 0.0f,
      M14 = 0.0f,
      M21 = 0.0f,
      M22 = 1f,
      M23 = 0.0f,
      M24 = 0.0f,
      M31 = 0.0f,
      M32 = 0.0f,
      M33 = 1f,
      M34 = 0.0f,
      M41 = x,
      M42 = y,
      M43 = z,
      M44 = 1f
    };

    public static unsafe Matrix Transpose(Matrix matrix)
    {
      _Module_.mtranspose_sse((float*) &matrix, (float*) &matrix);
      return matrix;
    }

    public static unsafe Matrix operator -(Matrix left, Matrix right)
    {
      _Module_.msub_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix operator -(Matrix matrix)
    {
      _Module_.mneg_sse((float*) &matrix, (float*) &matrix);
      return matrix;
    }

    public static unsafe Matrix operator +(Matrix left, Matrix right)
    {
      _Module_.madd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix operator /(Matrix left, float right)
    {
      _Module_.mmul_sse((float*) &left, 1f / right, (float*) &left);
      return left;
    }

    public static unsafe Matrix operator /(Matrix left, Matrix right)
    {
      _Module_.mdiv_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Matrix operator *(float left, Matrix right)
    {
      Matrix matrix = right;
      _Module_.mmul_sse((float*) &matrix, left, (float*) &matrix);
      return matrix;
    }

    public static unsafe Matrix operator *(Matrix left, float right)
    {
      _Module_.mmul_sse((float*) &left, right, (float*) &left);
      return left;
    }

    public static unsafe Matrix operator *(Matrix left, Matrix right)
    {
      _Module_.matrixmul_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static bool operator ==(Matrix left, Matrix right) => Matrix.Equals(ref left, ref right);

    public static bool operator !=(Matrix left, Matrix right) => !Matrix.Equals(ref left, ref right);

    public unsafe float[] ToArray()
    {
      float[] destination = new float[16];
      fixed (Matrix* matrixPtr = &this)
      {
        Marshal.Copy(new IntPtr((void*) matrixPtr), destination, 0, 16);
        return destination;
      }
    }

    public override sealed string ToString()
    {
      object[] objArray = new object[16];
      float m11 = this.M11;
      objArray[0] = (object) m11.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m12 = this.M12;
      objArray[1] = (object) m12.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m13 = this.M13;
      objArray[2] = (object) m13.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m14 = this.M14;
      objArray[3] = (object) m14.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m21 = this.M21;
      objArray[4] = (object) m21.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m22 = this.M22;
      objArray[5] = (object) m22.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m23 = this.M23;
      objArray[6] = (object) m23.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m24 = this.M24;
      objArray[7] = (object) m24.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m31 = this.M31;
      objArray[8] = (object) m31.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m32 = this.M32;
      objArray[9] = (object) m32.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m33 = this.M33;
      objArray[10] = (object) m33.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m34 = this.M34;
      objArray[11] = (object) m34.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m41 = this.M41;
      objArray[12] = (object) m41.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m42 = this.M42;
      objArray[13] = (object) m42.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m43 = this.M43;
      objArray[14] = (object) m43.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      float m44 = this.M44;
      objArray[15] = (object) m44.ToString((IFormatProvider) CultureInfo.CurrentCulture);
      return string.Format((IFormatProvider) CultureInfo.CurrentCulture, "[[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]]", objArray);
    }

    public override sealed int GetHashCode()
    {
      float m11 = this.M11;
      float m12 = this.M12;
      float m13 = this.M13;
      float m14 = this.M14;
      float m21 = this.M21;
      float m22 = this.M22;
      float m23 = this.M23;
      float m24 = this.M24;
      float m31 = this.M31;
      float m32 = this.M32;
      float m33 = this.M33;
      float m34 = this.M34;
      float m41 = this.M41;
      float m42 = this.M42;
      float m43 = this.M43;
      int num1 = this.M44.GetHashCode() + m43.GetHashCode();
      int num2 = m42.GetHashCode() + num1;
      int num3 = m41.GetHashCode() + num2;
      int num4 = m34.GetHashCode() + num3;
      int num5 = m33.GetHashCode() + num4;
      int num6 = m32.GetHashCode() + num5;
      int num7 = m31.GetHashCode() + num6;
      int num8 = m24.GetHashCode() + num7;
      int num9 = m23.GetHashCode() + num8;
      int num10 = m22.GetHashCode() + num9;
      int num11 = m21.GetHashCode() + num10;
      int num12 = m14.GetHashCode() + num11;
      int num13 = m13.GetHashCode() + num12;
      int num14 = m12.GetHashCode() + num13;
      return m11.GetHashCode() + num14;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static bool Equals(ref Matrix value1, ref Matrix value2) => (double) value1.M11 == (double) value2.M11 && (double) value1.M12 == (double) value2.M12 && ((double) value1.M13 == (double) value2.M13 && (double) value1.M14 == (double) value2.M14) && ((double) value1.M21 == (double) value2.M21 && (double) value1.M22 == (double) value2.M22 && ((double) value1.M23 == (double) value2.M23 && (double) value1.M24 == (double) value2.M24)) && ((double) value1.M31 == (double) value2.M31 && (double) value1.M32 == (double) value2.M32 && ((double) value1.M33 == (double) value2.M33 && (double) value1.M34 == (double) value2.M34) && ((double) value1.M41 == (double) value2.M41 && (double) value1.M42 == (double) value2.M42 && ((double) value1.M43 == (double) value2.M43 && (double) value1.M44 == (double) value2.M44)));

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Equals(Matrix other) => (double) this.M11 == (double) other.M11 && (double) this.M12 == (double) other.M12 && ((double) this.M13 == (double) other.M13 && (double) this.M14 == (double) other.M14) && ((double) this.M21 == (double) other.M21 && (double) this.M22 == (double) other.M22 && ((double) this.M23 == (double) other.M23 && (double) this.M24 == (double) other.M24)) && ((double) this.M31 == (double) other.M31 && (double) this.M32 == (double) other.M32 && ((double) this.M33 == (double) other.M33 && (double) this.M34 == (double) other.M34) && ((double) this.M41 == (double) other.M41 && (double) this.M42 == (double) other.M42 && ((double) this.M43 == (double) other.M43 && (double) this.M44 == (double) other.M44)));

    [return: MarshalAs(UnmanagedType.U1)]
    public override sealed bool Equals(object obj) => obj != null && !(obj.GetType() != this.GetType()) && this.Equals((Matrix) obj);
  }
}
