namespace GTA.Math
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Quaternion(Vector3 value, float w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public Quaternion(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public static Quaternion Identity =>
            new Quaternion(0f, 0f, 0f, 1f);
        public Vector3 Axis
        {
            get
            {
                Vector3 vector = new Vector3();
                float num2 = this.Length();
                if (num2 == 0f)
                {
                    vector.X = 1f;
                    vector.Y = 0f;
                    vector.Z = 0f;
                }
                else
                {
                    float num = (float) (1.0 / ((double) num2));
                    vector.X = this.X * num;
                    vector.Y = this.Y * num;
                    vector.Z = this.Z * num;
                }
                return vector;
            }
        }
        public float Angle =>
            (Math.Abs(this.W) > 1f) ? ((float) 0.0) : ((float) (((float) Math.Acos((double) this.W)) * 2.0));
        public float Length()
        {
            double num3;
            double y = this.Y;
            double z = this.Z;
            double w = this.W;
            return (float) Math.Sqrt((((this.X * num3) + (y * y)) + (z * z)) + (w * w));
        }

        public float LengthSquared()
        {
            double num3;
            double y = this.Y;
            double z = this.Z;
            double w = this.W;
            return (float) ((((this.X * num3) + (y * y)) + (z * z)) + (w * w));
        }

        public static Quaternion Normalize(Quaternion quaternion)
        {
            quaternion.Normalize();
            return quaternion;
        }

        public void Normalize()
        {
            float num = (float) (1.0 / ((double) this.Length()));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }

        public void Conjugate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        public static Quaternion Invert(Quaternion quaternion)
        {
            double num8;
            Quaternion quaternion2 = new Quaternion();
            float y = quaternion.Y;
            double num9 = y;
            float x = quaternion.X;
            float z = quaternion.Z;
            double num7 = z;
            float w = quaternion.W;
            double num6 = w;
            float num = (float) (1.0 / ((((x * num8) + (num9 * num9)) + (num7 * num7)) + (num6 * num6)));
            quaternion2.X = -x * num;
            quaternion2.Y = -y * num;
            quaternion2.Z = -z * num;
            quaternion2.W = w * num;
            return quaternion2;
        }

        public void Invert()
        {
            double num8;
            float y = this.Y;
            double num9 = y;
            float x = this.X;
            float z = this.Z;
            double num7 = z;
            float w = this.W;
            double num6 = w;
            float num = (float) (1.0 / ((((x * num8) + (num9 * num9)) + (num7 * num7)) + (num6 * num6)));
            this.X = -x * num;
            this.Y = -y * num;
            this.Z = -z * num;
            this.W = w * num;
        }

        public static Quaternion Add(Quaternion left, Quaternion right) => 
            new Quaternion { 
                X = left.X + right.X,
                Y = left.Y + right.Y,
                Z = left.Z + right.Z,
                W = left.W + right.W
            };

        public static Quaternion Divide(Quaternion left, Quaternion right) => 
            new Quaternion { 
                X = (float) (((double) left.X) / ((double) right.X)),
                Y = (float) (((double) left.Y) / ((double) right.Y)),
                Z = (float) (((double) left.Z) / ((double) right.Z)),
                W = (float) (((double) left.W) / ((double) right.W))
            };

        public static float Dot(Quaternion left, Quaternion right) => 
            (((left.Y * right.Y) + (left.X * right.X)) + (left.Z * right.Z)) + (left.W * right.W);

        public static Quaternion Lerp(Quaternion start, Quaternion end, float amount)
        {
            Quaternion quaternion = new Quaternion();
            float num = ((float) 1.0) - amount;
            float y = start.Y;
            float num9 = end.Y;
            float x = start.X;
            float num7 = end.X;
            float z = start.Z;
            float num5 = end.Z;
            float w = start.W;
            float num3 = end.W;
            if (((((num7 * x) + (num9 * y)) + (num5 * z)) + (num3 * w)) >= 0f)
            {
                quaternion.X = (x * num) + (num7 * amount);
                quaternion.Y = (y * num) + (num9 * amount);
                quaternion.Z = (z * num) + (num5 * amount);
                quaternion.W = (w * num) + (num3 * amount);
            }
            else
            {
                quaternion.X = (x * num) - (num7 * amount);
                quaternion.Y = (y * num) - (num9 * amount);
                quaternion.Z = (z * num) - (num5 * amount);
                quaternion.W = (w * num) - (num3 * amount);
            }
            float num2 = (float) (1.0 / ((double) quaternion.Length()));
            quaternion.X *= num2;
            quaternion.Y *= num2;
            quaternion.Z *= num2;
            quaternion.W *= num2;
            return quaternion;
        }

        public static Quaternion Slerp(Quaternion start, Quaternion end, float amount)
        {
            float num;
            float num2;
            Quaternion quaternion = new Quaternion();
            float num3 = Dot(start, end);
            if (Math.Abs(num3) > 0.9999999f)
            {
                num2 = ((float) 1.0) - amount;
                num = Math.Sign(num3) * amount;
            }
            else
            {
                float num4 = (float) Math.Acos((double) Math.Abs(num3));
                float num5 = (float) (1.0 / Math.Sin((double) num4));
                num2 = (float) (Math.Sin((1.0 - amount) * num4) * num5);
                double num6 = Math.Sin(num4 * amount) * num5;
                num = (float) (Math.Sign(num3) * num6);
            }
            quaternion.X = (end.X * num) + (start.X * num2);
            quaternion.Y = (end.Y * num) + (start.Y * num2);
            quaternion.Z = (end.Z * num) + (start.Z * num2);
            quaternion.W = (end.W * num) + (start.W * num2);
            return quaternion;
        }

        public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t)
        {
            float num2;
            float num3;
            if (a.LengthSquared() == 0f)
            {
                return ((b.LengthSquared() != 0f) ? b : Identity);
            }
            if (b.LengthSquared() == 0f)
            {
                return a;
            }
            Vector3 axis = b.Axis;
            double num6 = Vector3.Dot(a.Axis, axis);
            float num = (a.W * b.W) + ((float) num6);
            if ((num >= 1f) || (num <= -1f))
            {
                return a;
            }
            if (num < 0f)
            {
                b.X = -b.X;
                b.Y = -b.Y;
                b.Z = -b.Z;
                b.W = -b.W;
                num = -num;
            }
            if (num >= 0.99f)
            {
                num3 = ((float) 1.0) - t;
                num2 = t;
            }
            else
            {
                float num4 = (float) Math.Acos((double) num);
                float num5 = (float) (1.0 / ((double) ((float) Math.Sin((double) num4))));
                num3 = ((float) Math.Sin((1.0 - t) * num4)) * num5;
                num2 = ((float) Math.Sin(num4 * t)) * num5;
            }
            Vector3 vector3 = (Vector3) (num2 * b.Axis);
            Quaternion quaternion2 = new Quaternion(((Vector3) (num3 * a.Axis)) + vector3, (b.W * num2) + (a.W * num3));
            if (quaternion2.LengthSquared() <= 0f)
            {
                return Identity;
            }
            Quaternion quaternion = quaternion2;
            quaternion.Normalize();
            return quaternion;
        }

        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            double num8 = fromDirection.LengthSquared();
            float num2 = (float) Math.Sqrt(fromDirection.LengthSquared() * num8);
            float w = Vector3.Dot(fromDirection, toDirection) + num2;
            Quaternion quaternion = new Quaternion();
            if (w >= (num2 * 9.9999999747524271E-07))
            {
                quaternion = new Quaternion(Vector3.Cross(fromDirection, toDirection), w);
            }
            else
            {
                Quaternion quaternion1;
                if (Math.Abs(fromDirection.X) > Math.Abs(fromDirection.Y))
                {
                    Quaternion quaternion3;
                    quaternion3.X = -fromDirection.Z;
                    quaternion3.Y = 0f;
                    quaternion3.Z = fromDirection.X;
                    quaternion3.W = 0f;
                    quaternion1 = quaternion3;
                }
                else
                {
                    Quaternion quaternion2;
                    quaternion2.X = 0f;
                    quaternion2.Y = -fromDirection.Z;
                    quaternion2.Z = fromDirection.Y;
                    quaternion2.W = 0f;
                    quaternion1 = quaternion2;
                }
                quaternion = quaternion1;
            }
            quaternion.Normalize();
            return quaternion;
        }

        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta)
        {
            float num = AngleBetween(from, to);
            if (num == 0f)
            {
                return to;
            }
            float t = Math.Min(1f, (float) (((double) maxDegreesDelta) / ((double) num)));
            return SlerpUnclamped(from, to, t);
        }

        public static Quaternion Multiply(Quaternion quaternion, float scale) => 
            new Quaternion { 
                X = quaternion.X * scale,
                Y = quaternion.Y * scale,
                Z = quaternion.Z * scale,
                W = quaternion.W * scale
            };

        public static Quaternion Multiply(Quaternion left, Quaternion right)
        {
            Quaternion quaternion = new Quaternion();
            float x = left.X;
            float y = left.Y;
            float z = left.Z;
            float w = left.W;
            float num4 = right.X;
            float num3 = right.Y;
            float num2 = right.Z;
            float num = right.W;
            quaternion.X = (((num4 * w) + (num * x)) + (num2 * y)) - (num3 * z);
            quaternion.Y = (((num3 * w) + (num * y)) + (num4 * z)) - (num2 * x);
            quaternion.Z = (((num2 * w) + (num * z)) + (num3 * x)) - (num4 * y);
            quaternion.W = (num * w) - (((num3 * y) + (num4 * x)) + (num2 * z));
            return quaternion;
        }

        public static Quaternion Negate(Quaternion quaternion) => 
            new Quaternion { 
                X = -quaternion.X,
                Y = -quaternion.Y,
                Z = -quaternion.Z,
                W = -quaternion.W
            };

        public static float AngleBetween(Quaternion a, Quaternion b) => 
            (float) ((Math.Acos((double) Math.Min(Math.Abs(Dot(a, b)), 1f)) * 2.0) * 57.295779513082323);

        public static Quaternion Euler(Vector3 euler)
        {
            Vector3 modopt(IsConst) vector = euler * 0.01745329f;
            return RotationYawPitchRoll(vector.X, vector.Y, vector.Z);
        }

        public static Quaternion Euler(float x, float y, float z) => 
            RotationYawPitchRoll(x * 0.01745329f, y * 0.01745329f, z * 0.01745329f);

        public static Quaternion RotationAxis(Vector3 axis, float angle)
        {
            Quaternion quaternion = new Quaternion();
            axis = Vector3.Normalize(axis);
            double a = angle * 0.5f;
            float num = (float) Math.Sin(a);
            quaternion.X = axis.X * num;
            quaternion.Y = axis.Y * num;
            quaternion.Z = axis.Z * num;
            quaternion.W = (float) Math.Cos(a);
            return quaternion;
        }

        public static Quaternion RotationMatrix(Matrix matrix)
        {
            Quaternion quaternion = new Quaternion();
            float num4 = matrix.M22;
            float num3 = matrix.M11;
            float num2 = matrix.M33;
            float num11 = (num3 + num4) + num2;
            if (num11 > 0f)
            {
                float num = (float) Math.Sqrt(num11 + 1.0);
                quaternion.W = num * 0.5f;
                num = (float) (0.5 / ((double) num));
                quaternion.X = (matrix.M23 - matrix.M32) * num;
                quaternion.Y = (matrix.M31 - matrix.M13) * num;
                quaternion.Z = (matrix.M12 - matrix.M21) * num;
                return quaternion;
            }
            if ((num3 >= num4) && (num3 >= num2))
            {
                float num10 = (float) Math.Sqrt(((num3 + 1.0) - num4) - num2);
                float num7 = (float) (0.5 / ((double) num10));
                quaternion.X = num10 * 0.5f;
                quaternion.Y = (matrix.M21 + matrix.M12) * num7;
                quaternion.Z = (matrix.M13 + matrix.M31) * num7;
                quaternion.W = (matrix.M23 - matrix.M32) * num7;
                return quaternion;
            }
            if (num4 > num2)
            {
                float num9 = (float) Math.Sqrt(((num4 + 1.0) - num3) - num2);
                float num6 = (float) (0.5 / ((double) num9));
                quaternion.X = (matrix.M21 + matrix.M12) * num6;
                quaternion.Y = num9 * 0.5f;
                quaternion.Z = (matrix.M32 + matrix.M23) * num6;
                quaternion.W = (matrix.M31 - matrix.M13) * num6;
                return quaternion;
            }
            float num8 = (float) Math.Sqrt(((num2 + 1.0) - num3) - num4);
            float num5 = (float) (0.5 / ((double) num8));
            quaternion.X = (matrix.M13 + matrix.M31) * num5;
            quaternion.Y = (matrix.M32 + matrix.M23) * num5;
            quaternion.Z = num8 * 0.5f;
            quaternion.W = (matrix.M12 - matrix.M21) * num5;
            return quaternion;
        }

        public static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion quaternion = new Quaternion();
            double a = roll * 0.5f;
            float num2 = (float) Math.Sin(a);
            float num = (float) Math.Cos(a);
            double num12 = pitch * 0.5f;
            float num11 = (float) Math.Sin(num12);
            float num10 = (float) Math.Cos(num12);
            double num9 = yaw * 0.5f;
            float num8 = (float) Math.Sin(num9);
            float num7 = (float) Math.Cos(num9);
            double num6 = num7 * num11;
            double num5 = num8 * num10;
            quaternion.X = (float) ((num2 * num5) + (num * num6));
            quaternion.Y = (float) ((num * num5) - (num2 * num6));
            double num4 = num7 * num10;
            double num3 = num8 * num11;
            quaternion.Z = (float) ((num2 * num4) - (num * num3));
            quaternion.W = (float) ((num2 * num3) + (num * num4));
            return quaternion;
        }

        public static Quaternion Subtract(Quaternion left, Quaternion right) => 
            new Quaternion { 
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z = left.Z - right.Z,
                W = left.W - right.W
            };

        public static Quaternion operator *(float scale, Quaternion quaternion) => 
            new Quaternion { 
                X = quaternion.X * scale,
                Y = quaternion.Y * scale,
                Z = quaternion.Z * scale,
                W = quaternion.W * scale
            };

        public static Quaternion operator *(Quaternion quaternion, float scale) => 
            new Quaternion { 
                X = quaternion.X * scale,
                Y = quaternion.Y * scale,
                Z = quaternion.Z * scale,
                W = quaternion.W * scale
            };

        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            Vector3 left = new Vector3(rotation.X, rotation.Y, rotation.Z);
            Vector3 right = (Vector3) (2f * Vector3.Cross(left, point));
            Vector3 vector4 = Vector3.Cross(left, right);
            Vector3 vector3 = (Vector3) (rotation.W * right);
            return ((point + vector3) + vector4);
        }

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Quaternion quaternion = new Quaternion();
            float x = left.X;
            float y = left.Y;
            float z = left.Z;
            float w = left.W;
            float num4 = right.X;
            float num3 = right.Y;
            float num2 = right.Z;
            float num = right.W;
            quaternion.X = (((num4 * w) + (num * x)) + (num2 * y)) - (num3 * z);
            quaternion.Y = (((num3 * w) + (num * y)) + (num4 * z)) - (num2 * x);
            quaternion.Z = (((num2 * w) + (num * z)) + (num3 * x)) - (num4 * y);
            quaternion.W = (num * w) - (((num3 * y) + (num4 * x)) + (num2 * z));
            return quaternion;
        }

        public static Quaternion operator /(Quaternion left, float right)
        {
            Quaternion quaternion = new Quaternion();
            float num = (float) (1.0 / ((double) right));
            quaternion.X = left.X * num;
            quaternion.Y = left.Y * num;
            quaternion.Z = left.Z * num;
            quaternion.W = left.W * num;
            return quaternion;
        }

        public static Quaternion operator +(Quaternion left, Quaternion right) => 
            new Quaternion { 
                X = left.X + right.X,
                Y = left.Y + right.Y,
                Z = left.Z + right.Z,
                W = left.W + right.W
            };

        public static Quaternion operator -(Quaternion quaternion) => 
            new Quaternion { 
                X = -quaternion.X,
                Y = -quaternion.Y,
                Z = -quaternion.Z,
                W = -quaternion.W
            };

        public static Quaternion operator -(Quaternion left, Quaternion right) => 
            new Quaternion { 
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z = left.Z - right.Z,
                W = left.W - right.W
            };

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator ==(Quaternion left, Quaternion right) => 
            Equals(ref left, ref right);

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator !=(Quaternion left, Quaternion right) => 
            (bool) ((byte) !Equals(ref left, ref right));

        public sealed override string ToString()
        {
            float w;
            float z;
            float y;
            float x;
            object[] args = new object[] { x.ToString(), y.ToString(), z.ToString(), w.ToString() };
            x = this.X;
            y = this.Y;
            z = this.Z;
            w = this.W;
            return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2} W:{2}", args);
        }

        public sealed override int GetHashCode()
        {
            float x = this.X;
            float y = this.Y;
            float z = this.Z;
            float w = this.W;
            int num3 = z.GetHashCode() >> 2;
            int num2 = (y.GetHashCode() << 2) ^ num3;
            int num = w.GetHashCode() ^ num2;
            return (x.GetHashCode() ^ num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool Equals(ref Quaternion value1, ref Quaternion value2)
        {
            int num = ((value1.X != value2.X) || ((value1.Y != value2.Y) || ((value1.Z != value2.Z) || (value1.W != value2.W)))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Equals(Quaternion other)
        {
            int num = ((this.X != other.X) || ((this.Y != other.Y) || ((this.Z != other.Z) || (this.W != other.W)))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public sealed override unsafe bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == this.GetType()) && this.Equals(*((Quaternion*) obj)));
    }
}

