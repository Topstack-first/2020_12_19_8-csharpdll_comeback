namespace GTA.Math
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential, Pack=4)]
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
                if (row > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
                }
                if (column > 3)
                {
                    throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");
                }
                switch (((row * 4) + column))
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
                }
                return 0f;
            }
            set
            {
                if (row > 3)
                {
                    throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
                }
                if (column > 3)
                {
                    throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");
                }
                switch (((row * 4) + column))
                {
                    case 0:
                        this.M11 = value;
                        break;

                    case 1:
                        this.M12 = value;
                        break;

                    case 2:
                        this.M13 = value;
                        break;

                    case 3:
                        this.M14 = value;
                        break;

                    case 4:
                        this.M21 = value;
                        break;

                    case 5:
                        this.M22 = value;
                        break;

                    case 6:
                        this.M23 = value;
                        break;

                    case 7:
                        this.M24 = value;
                        break;

                    case 8:
                        this.M31 = value;
                        break;

                    case 9:
                        this.M32 = value;
                        break;

                    case 10:
                        this.M33 = value;
                        break;

                    case 11:
                        this.M34 = value;
                        break;

                    case 12:
                        this.M41 = value;
                        break;

                    case 13:
                        this.M42 = value;
                        break;

                    case 14:
                        this.M43 = value;
                        break;

                    case 15:
                        this.M44 = value;
                        break;

                    default:
                        break;
                }
            }
        }
        public static Matrix Identity =>
            new Matrix { 
                M11=1f,
                M22=1f,
                M33=1f,
                M44=1f
            };
        [Browsable(false)]
        public bool IsIdentity =>
            (this.M11 == 1f) && ((this.M22 == 1f) && ((this.M33 == 1f) && ((this.M44 == 1f) && ((this.M12 == 0f) && ((this.M13 == 0f) && ((this.M14 == 0f) && ((this.M21 == 0f) && ((this.M23 == 0f) && ((this.M24 == 0f) && ((this.M31 == 0f) && ((this.M32 == 0f) && ((this.M34 == 0f) && ((this.M41 == 0f) && ((this.M42 == 0f) && (this.M43 == 0f)))))))))))))));
        public bool HasInverse =>
            (this.Determinant() == 0f) ? ((bool) ((byte) 0)) : ((bool) ((byte) 1));
        public static unsafe Matrix FromArray(float[] floatArray)
        {
            if (floatArray.Length != 0x10)
            {
                throw new Exception("Array must contain 16 items to be converted to a 4*4 Matrix");
            }
            Matrix matrix = new Matrix();
            IntPtr destination = new IntPtr((void*) &matrix);
            Marshal.Copy(floatArray, 0, destination, 0x10);
            return matrix;
        }

        public float Determinant()
        {
            float num12 = this.M44;
            float num11 = this.M33;
            float num10 = this.M43;
            float num9 = this.M34;
            float num18 = (num11 * num12) - (num9 * num10);
            float num8 = this.M32;
            float num7 = this.M42;
            float num17 = (num8 * num12) - (num7 * num9);
            float num16 = (num8 * num10) - (num7 * num11);
            float num6 = this.M31;
            float num5 = this.M41;
            float num15 = (num6 * num12) - (num5 * num9);
            float num14 = (num6 * num10) - (num5 * num11);
            float num13 = (num6 * num7) - (num5 * num8);
            float num4 = this.M22;
            float num3 = this.M23;
            float num2 = this.M24;
            float num = this.M21;
            return ((((this.M11 * (((num4 * num18) - (num3 * num17)) + (num2 * num16))) - (this.M12 * (((num * num18) - (num3 * num15)) + (num2 * num14)))) + (this.M13 * (((num * num17) - (num4 * num15)) + (num2 * num13)))) - (this.M14 * (((num * num16) - (num4 * num14)) + (num3 * num13))));
        }

        public static Matrix Inverse(Matrix matrix)
        {
            matrix.Inverse();
            return matrix;
        }

        public void Inverse()
        {
            float num114 = this.Determinant();
            if (num114 != 0f)
            {
                float num = (float) (1.0 / ((double) num114));
                float num17 = this.M44;
                float num113 = num17;
                float num16 = this.M43;
                float num112 = num16;
                float num15 = this.M42;
                float num111 = num15;
                float num14 = this.M34;
                float num110 = num14;
                float num13 = this.M33;
                float num109 = num13;
                float num12 = this.M32;
                float num108 = num12;
                float num11 = this.M24;
                float num162 = num11;
                float num10 = this.M23;
                float num161 = num10;
                float num9 = this.M22;
                float num160 = num9;
                float num107 = num17;
                float num106 = num16;
                float num8 = this.M41;
                float num105 = num8;
                float num104 = num14;
                float num103 = num13;
                float num7 = this.M31;
                float num102 = num7;
                float num159 = num11;
                float num158 = num10;
                float num6 = this.M21;
                float num157 = num6;
                float num101 = num17;
                float num100 = num15;
                float num99 = num8;
                float num98 = num14;
                float num97 = num12;
                float num96 = num7;
                float num156 = num11;
                float num155 = num9;
                float num154 = num6;
                float num95 = num16;
                float num94 = num15;
                float num93 = num8;
                float num92 = num13;
                float num91 = num12;
                float num90 = num7;
                float num153 = num10;
                float num152 = num9;
                float num151 = num6;
                float num89 = num17;
                float num88 = num16;
                float num87 = num15;
                float num86 = num14;
                float num85 = num13;
                float num84 = num12;
                float num5 = this.M14;
                float num150 = num5;
                float num4 = this.M13;
                float num149 = num4;
                float num3 = this.M12;
                float num148 = num3;
                float num83 = num17;
                float num82 = num16;
                float num81 = num8;
                float num80 = num14;
                float num79 = num13;
                float num78 = num7;
                float num147 = num5;
                float num146 = num4;
                float num2 = this.M11;
                float num145 = num2;
                float num77 = num17;
                float num76 = num15;
                float num75 = num8;
                float num74 = num14;
                float num73 = num12;
                float num72 = num7;
                float num144 = num5;
                float num143 = num3;
                float num142 = num2;
                float num71 = num16;
                float num70 = num15;
                float num69 = num8;
                float num68 = num13;
                float num67 = num12;
                float num66 = num7;
                float num141 = num4;
                float num140 = num3;
                float num139 = num2;
                float num65 = num17;
                float num64 = num16;
                float num63 = num15;
                float num62 = num11;
                float num61 = num10;
                float num60 = num9;
                float num138 = num5;
                float num137 = num4;
                float num136 = num3;
                float num59 = num17;
                float num58 = num16;
                float num57 = num8;
                float num56 = num11;
                float num55 = num10;
                float num54 = num6;
                float num135 = num5;
                float num134 = num4;
                float num133 = num2;
                float num53 = num17;
                float num52 = num15;
                float num51 = num8;
                float num50 = num11;
                float num49 = num9;
                float num48 = num6;
                float num132 = num5;
                float num131 = num3;
                float num130 = num2;
                float num47 = num16;
                float num46 = num15;
                float num45 = num8;
                float num44 = num10;
                float num43 = num9;
                float num42 = num6;
                float num129 = num4;
                float num128 = num3;
                float num127 = num2;
                float num41 = num14;
                float num40 = num13;
                float num39 = num12;
                float num38 = num11;
                float num37 = num10;
                float num36 = num9;
                float num126 = num5;
                float num125 = num4;
                float num124 = num3;
                float num35 = num14;
                float num34 = num13;
                float num33 = num7;
                float num32 = num11;
                float num31 = num10;
                float num30 = num6;
                float num123 = num5;
                float num122 = num4;
                float num121 = num2;
                float num29 = num14;
                float num28 = num12;
                float num27 = num7;
                float num26 = num11;
                float num25 = num9;
                float num24 = num6;
                float num120 = num5;
                float num119 = num3;
                float num118 = num2;
                float num23 = num13;
                float num22 = num12;
                float num21 = num7;
                float num20 = num10;
                float num19 = num9;
                float num18 = num6;
                float num117 = num4;
                float num116 = num3;
                float num115 = num2;
                this.M11 = (((((num113 * num109) - (num112 * num110)) * num160) - (((num113 * num108) - (num111 * num110)) * num161)) + (((num112 * num108) - (num111 * num109)) * num162)) * num;
                this.M12 = -(((((num85 * num89) - (num86 * num88)) * num148) - (((num84 * num89) - (num86 * num87)) * num149)) + (((num84 * num88) - (num85 * num87)) * num150)) * num;
                this.M13 = (((((num61 * num65) - (num62 * num64)) * num136) - (((num60 * num65) - (num62 * num63)) * num137)) + (((num60 * num64) - (num61 * num63)) * num138)) * num;
                this.M14 = -(((((num37 * num41) - (num38 * num40)) * num124) - (((num36 * num41) - (num38 * num39)) * num125)) + (((num36 * num40) - (num37 * num39)) * num126)) * num;
                this.M21 = -(((((num103 * num107) - (num104 * num106)) * num157) - (((num102 * num107) - (num104 * num105)) * num158)) + (((num102 * num106) - (num103 * num105)) * num159)) * num;
                this.M22 = (((((num79 * num83) - (num80 * num82)) * num145) - (((num78 * num83) - (num80 * num81)) * num146)) + (((num78 * num82) - (num79 * num81)) * num147)) * num;
                this.M23 = -(((((num55 * num59) - (num56 * num58)) * num133) - (((num54 * num59) - (num56 * num57)) * num134)) + (((num54 * num58) - (num55 * num57)) * num135)) * num;
                this.M24 = (((((num31 * num35) - (num32 * num34)) * num121) - (((num30 * num35) - (num32 * num33)) * num122)) + (((num30 * num34) - (num31 * num33)) * num123)) * num;
                this.M31 = (((((num97 * num101) - (num98 * num100)) * num154) - (((num96 * num101) - (num98 * num99)) * num155)) + (((num96 * num100) - (num97 * num99)) * num156)) * num;
                this.M32 = -(((((num73 * num77) - (num74 * num76)) * num142) - (((num72 * num77) - (num74 * num75)) * num143)) + (((num72 * num76) - (num73 * num75)) * num144)) * num;
                this.M33 = (((((num49 * num53) - (num50 * num52)) * num130) - (((num48 * num53) - (num50 * num51)) * num131)) + (((num48 * num52) - (num49 * num51)) * num132)) * num;
                this.M34 = -(((((num25 * num29) - (num26 * num28)) * num118) - (((num24 * num29) - (num26 * num27)) * num119)) + (((num24 * num28) - (num25 * num27)) * num120)) * num;
                this.M41 = -(((((num91 * num95) - (num92 * num94)) * num151) - (((num90 * num95) - (num92 * num93)) * num152)) + (((num90 * num94) - (num91 * num93)) * num153)) * num;
                this.M42 = (((((num67 * num71) - (num68 * num70)) * num139) - (((num66 * num71) - (num68 * num69)) * num140)) + (((num66 * num70) - (num67 * num69)) * num141)) * num;
                this.M43 = -(((((num43 * num47) - (num44 * num46)) * num127) - (((num42 * num47) - (num44 * num45)) * num128)) + (((num42 * num46) - (num43 * num45)) * num129)) * num;
                this.M44 = (((((num19 * num23) - (num20 * num22)) * num115) - (((num18 * num23) - (num20 * num21)) * num116)) + (((num18 * num22) - (num19 * num21)) * num117)) * num;
            }
        }

        public unsafe Vector3 TransformPoint(Vector3 point)
        {
            mtransform_point_sse((float modopt(IsConst)*) this, point.X, point.Y, point.Z, (float*) &point);
            return point;
        }

        public unsafe Vector3 InverseTransformPoint(Vector3 point)
        {
            minvtransform_point_sse((float modopt(IsConst)*) this, point.X, point.Y, point.Z, (float*) &point);
            return point;
        }

        public static unsafe Matrix Add(Matrix left, Matrix right)
        {
            madd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix Subtract(Matrix left, Matrix right)
        {
            msub_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix Multiply(Matrix left, float right)
        {
            mmul_sse((float modopt(IsConst)*) &left, right, (float*) &left);
            return left;
        }

        public static unsafe Matrix Multiply(Matrix left, Matrix right)
        {
            matrixmul_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix Divide(Matrix left, float right)
        {
            mmul_sse((float modopt(IsConst)*) &left, (float) (1.0 / ((double) right)), (float*) &left);
            return left;
        }

        public static unsafe Matrix Divide(Matrix left, Matrix right)
        {
            mdiv_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix Negate(Matrix matrix)
        {
            mneg_sse((float modopt(IsConst)*) &matrix, (float*) &matrix);
            return matrix;
        }

        public static unsafe Matrix Lerp(Matrix start, Matrix end, float amount)
        {
            mlerp_sse((float modopt(IsConst)*) &start, (float modopt(IsConst)*) &end, amount, (float*) &start);
            return start;
        }

        public static Matrix RotationX(float angle)
        {
            Matrix matrix = new Matrix();
            double d = angle;
            float num2 = (float) Math.Cos(d);
            float num = (float) Math.Sin(d);
            matrix.M11 = 1f;
            matrix.M12 = 0f;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = num2;
            matrix.M23 = num;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = -num;
            matrix.M33 = num2;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix RotationY(float angle)
        {
            Matrix matrix = new Matrix();
            double d = angle;
            float num2 = (float) Math.Cos(d);
            float num = (float) Math.Sin(d);
            matrix.M11 = num2;
            matrix.M12 = 0f;
            matrix.M13 = -num;
            matrix.M14 = 0f;
            matrix.M21 = 0f;
            matrix.M22 = 1f;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = num;
            matrix.M32 = 0f;
            matrix.M33 = num2;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix RotationZ(float angle)
        {
            Matrix matrix = new Matrix();
            double d = angle;
            float num2 = (float) Math.Cos(d);
            float num = (float) Math.Sin(d);
            matrix.M11 = num2;
            matrix.M12 = num;
            matrix.M13 = 0f;
            matrix.M14 = 0f;
            matrix.M21 = -num;
            matrix.M22 = num2;
            matrix.M23 = 0f;
            matrix.M24 = 0f;
            matrix.M31 = 0f;
            matrix.M32 = 0f;
            matrix.M33 = 1f;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix RotationAxis(Vector3 axis, float angle)
        {
            double num22;
            double num23;
            double num24;
            if (axis.LengthSquared() != 1f)
            {
                axis.Normalize();
            }
            Matrix matrix = new Matrix();
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            double d = angle;
            float num = (float) Math.Cos(d);
            float num5 = (float) Math.Sin(d);
            float num17 = (float) (x * num24);
            float num16 = (float) (y * num23);
            float num15 = (float) (z * num22);
            float num21 = y * x;
            float num20 = z * x;
            float num19 = z * y;
            matrix.M11 = ((float) ((1.0 - num17) * num)) + num17;
            double num14 = num21;
            double num13 = num14 - (num * num14);
            double num12 = num5 * z;
            matrix.M12 = (float) (num12 + num13);
            double num11 = num20;
            double num10 = num11 - (num * num11);
            double num9 = num5 * y;
            matrix.M13 = (float) (num10 - num9);
            matrix.M14 = 0f;
            matrix.M21 = (float) (num13 - num12);
            matrix.M22 = ((float) ((1.0 - num16) * num)) + num16;
            double num8 = num19;
            double num7 = num8 - (num * num8);
            double num6 = num5 * x;
            matrix.M23 = (float) (num6 + num7);
            matrix.M24 = 0f;
            matrix.M31 = (float) (num9 + num10);
            matrix.M32 = (float) (num7 - num6);
            matrix.M33 = ((float) ((1.0 - num15) * num)) + num15;
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix RotationQuaternion(Quaternion rotation)
        {
            double num14;
            double num15;
            double num16;
            Matrix matrix = new Matrix();
            float x = rotation.X;
            float num13 = (float) (x * num16);
            float y = rotation.Y;
            float num12 = (float) (y * num15);
            float z = rotation.Z;
            float num11 = (float) (z * num14);
            float num10 = y * x;
            float w = rotation.W;
            float num9 = w * z;
            float num8 = z * x;
            float num7 = w * y;
            float num6 = z * y;
            float num5 = w * x;
            matrix.M11 = (float) (1.0 - ((num11 + num12) * 2.0));
            matrix.M12 = (float) ((num9 + num10) * 2.0);
            matrix.M13 = (float) ((num8 - num7) * 2.0);
            matrix.M14 = 0f;
            matrix.M21 = (float) ((num10 - num9) * 2.0);
            matrix.M22 = (float) (1.0 - ((num11 + num13) * 2.0));
            matrix.M23 = (float) ((num5 + num6) * 2.0);
            matrix.M24 = 0f;
            matrix.M31 = (float) ((num7 + num8) * 2.0);
            matrix.M32 = (float) ((num6 - num5) * 2.0);
            matrix.M33 = (float) (1.0 - ((num12 + num13) * 2.0));
            matrix.M34 = 0f;
            matrix.M41 = 0f;
            matrix.M42 = 0f;
            matrix.M43 = 0f;
            matrix.M44 = 1f;
            return matrix;
        }

        public static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll) => 
            RotationQuaternion(Quaternion.RotationYawPitchRoll(yaw, pitch, roll));

        public static Matrix Scaling(Vector3 scale) => 
            new Matrix { 
                M11 = scale.X,
                M12 = 0f,
                M13 = 0f,
                M14 = 0f,
                M21 = 0f,
                M22 = scale.Y,
                M23 = 0f,
                M24 = 0f,
                M31 = 0f,
                M32 = 0f,
                M33 = scale.Z,
                M34 = 0f,
                M41 = 0f,
                M42 = 0f,
                M43 = 0f,
                M44 = 1f
            };

        public static Matrix Scaling(float x, float y, float z) => 
            new Matrix { 
                M11 = x,
                M12 = 0f,
                M13 = 0f,
                M14 = 0f,
                M21 = 0f,
                M22 = y,
                M23 = 0f,
                M24 = 0f,
                M31 = 0f,
                M32 = 0f,
                M33 = z,
                M34 = 0f,
                M41 = 0f,
                M42 = 0f,
                M43 = 0f,
                M44 = 1f
            };

        public static Matrix Translation(Vector3 amount) => 
            new Matrix { 
                M11 = 1f,
                M12 = 0f,
                M13 = 0f,
                M14 = 0f,
                M21 = 0f,
                M22 = 1f,
                M23 = 0f,
                M24 = 0f,
                M31 = 0f,
                M32 = 0f,
                M33 = 1f,
                M34 = 0f,
                M41 = amount.X,
                M42 = amount.Y,
                M43 = amount.Z,
                M44 = 1f
            };

        public static Matrix Translation(float x, float y, float z) => 
            new Matrix { 
                M11 = 1f,
                M12 = 0f,
                M13 = 0f,
                M14 = 0f,
                M21 = 0f,
                M22 = 1f,
                M23 = 0f,
                M24 = 0f,
                M31 = 0f,
                M32 = 0f,
                M33 = 1f,
                M34 = 0f,
                M41 = x,
                M42 = y,
                M43 = z,
                M44 = 1f
            };

        public static unsafe Matrix Transpose(Matrix matrix)
        {
            mtranspose_sse((float modopt(IsConst)*) &matrix, (float*) &matrix);
            return matrix;
        }

        public static unsafe Matrix operator -(Matrix left, Matrix right)
        {
            msub_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix operator -(Matrix matrix)
        {
            mneg_sse((float modopt(IsConst)*) &matrix, (float*) &matrix);
            return matrix;
        }

        public static unsafe Matrix operator +(Matrix left, Matrix right)
        {
            madd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix operator /(Matrix left, float right)
        {
            mmul_sse((float modopt(IsConst)*) &left, (float) (1.0 / ((double) right)), (float*) &left);
            return left;
        }

        public static unsafe Matrix operator /(Matrix left, Matrix right)
        {
            mdiv_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Matrix operator *(float left, Matrix right)
        {
            Matrix matrix = right;
            mmul_sse((float modopt(IsConst)*) &matrix, left, (float*) &matrix);
            return matrix;
        }

        public static unsafe Matrix operator *(Matrix left, float right)
        {
            mmul_sse((float modopt(IsConst)*) &left, right, (float*) &left);
            return left;
        }

        public static unsafe Matrix operator *(Matrix left, Matrix right)
        {
            matrixmul_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator ==(Matrix left, Matrix right) => 
            Equals(ref left, ref right);

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator !=(Matrix left, Matrix right) => 
            (bool) ((byte) !Equals(ref left, ref right));

        public unsafe float[] ToArray()
        {
            float[] destination = new float[0x10];
            IntPtr source = new IntPtr((void*) this);
            Marshal.Copy(source, destination, 0, 0x10);
            return destination;
        }

        public sealed override string ToString()
        {
            float num8;
            float num9;
            float num10;
            float num11;
            float num12;
            float num13;
            float num14;
            float num15;
            float num16;
            object[] args = new object[] { num16.ToString(CultureInfo.CurrentCulture), num15.ToString(CultureInfo.CurrentCulture), num14.ToString(CultureInfo.CurrentCulture), num13.ToString(CultureInfo.CurrentCulture), num12.ToString(CultureInfo.CurrentCulture), num11.ToString(CultureInfo.CurrentCulture), num10.ToString(CultureInfo.CurrentCulture), num9.ToString(CultureInfo.CurrentCulture), num8.ToString(CultureInfo.CurrentCulture) };
            num16 = this.M11;
            num15 = this.M12;
            num14 = this.M13;
            num13 = this.M14;
            num12 = this.M21;
            num11 = this.M22;
            num10 = this.M23;
            num9 = this.M24;
            num8 = this.M31;
            args[9] = this.M32.ToString(CultureInfo.CurrentCulture);
            args[10] = this.M33.ToString(CultureInfo.CurrentCulture);
            args[11] = this.M34.ToString(CultureInfo.CurrentCulture);
            args[12] = this.M41.ToString(CultureInfo.CurrentCulture);
            args[13] = this.M42.ToString(CultureInfo.CurrentCulture);
            args[14] = this.M43.ToString(CultureInfo.CurrentCulture);
            args[15] = this.M44.ToString(CultureInfo.CurrentCulture);
            return string.Format(CultureInfo.CurrentCulture, "[[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]]", args);
        }

        public sealed override int GetHashCode()
        {
            float num30 = this.M11;
            float num29 = this.M12;
            float num28 = this.M13;
            float num27 = this.M14;
            float num26 = this.M21;
            float num25 = this.M22;
            float num24 = this.M23;
            float num23 = this.M24;
            float num22 = this.M31;
            float num21 = this.M32;
            float num20 = this.M33;
            float num19 = this.M34;
            float num18 = this.M41;
            float num17 = this.M42;
            float num16 = this.M43;
            int num14 = this.M44.GetHashCode() + num16.GetHashCode();
            int num13 = num17.GetHashCode() + num14;
            int num12 = num18.GetHashCode() + num13;
            int num11 = num19.GetHashCode() + num12;
            int num10 = num20.GetHashCode() + num11;
            int num9 = num21.GetHashCode() + num10;
            int num8 = num22.GetHashCode() + num9;
            int num7 = num23.GetHashCode() + num8;
            int num6 = num24.GetHashCode() + num7;
            int num5 = num25.GetHashCode() + num6;
            int num4 = num26.GetHashCode() + num5;
            int num3 = num27.GetHashCode() + num4;
            int num2 = num28.GetHashCode() + num3;
            int num = num29.GetHashCode() + num2;
            return (num30.GetHashCode() + num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool Equals(ref Matrix value1, ref Matrix value2)
        {
            int num = ((value1.M11 != value2.M11) || ((value1.M12 != value2.M12) || ((value1.M13 != value2.M13) || ((value1.M14 != value2.M14) || ((value1.M21 != value2.M21) || ((value1.M22 != value2.M22) || ((value1.M23 != value2.M23) || ((value1.M24 != value2.M24) || ((value1.M31 != value2.M31) || ((value1.M32 != value2.M32) || ((value1.M33 != value2.M33) || ((value1.M34 != value2.M34) || ((value1.M41 != value2.M41) || ((value1.M42 != value2.M42) || ((value1.M43 != value2.M43) || (value1.M44 != value2.M44)))))))))))))))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Equals(Matrix other)
        {
            int num = ((this.M11 != other.M11) || ((this.M12 != other.M12) || ((this.M13 != other.M13) || ((this.M14 != other.M14) || ((this.M21 != other.M21) || ((this.M22 != other.M22) || ((this.M23 != other.M23) || ((this.M24 != other.M24) || ((this.M31 != other.M31) || ((this.M32 != other.M32) || ((this.M33 != other.M33) || ((this.M34 != other.M34) || ((this.M41 != other.M41) || ((this.M42 != other.M42) || ((this.M43 != other.M43) || (this.M44 != other.M44)))))))))))))))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public sealed override unsafe bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == this.GetType()) && this.Equals(*((Matrix*) obj)));
    }
}

