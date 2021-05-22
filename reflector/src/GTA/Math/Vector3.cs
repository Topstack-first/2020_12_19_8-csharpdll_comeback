namespace GTA.Math
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Explicit, Pack=4)]
    public struct Vector3 : IEquatable<Vector3>
    {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float Z;
        [FieldOffset(12)]
        private float _padding;

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static unsafe Vector3 Add(Vector3 left, Vector3 right)
        {
            vadd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static float Angle(Vector3 from, Vector3 to)
        {
            Vector3 normalized = to.Normalized;
            return (float) (Math.Acos((double) Dot(from.Normalized, normalized)) * 57.295779513082323);
        }

        public unsafe Vector3 Around(float distance)
        {
            Vector3 vector2 = RandomXY();
            vmul_sse((float modopt(IsConst)*) &vector2, distance, (float*) &vector2);
            Vector3 vector3 = vector2;
            Vector3 vector = this;
            vadd_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector3, (float*) &vector);
            return vector;
        }

        public static unsafe Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            vclamp_sse((float modopt(IsConst)*) &value, (float*) &min, (float*) &max, (float*) &value);
            return value;
        }

        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 vector = new Vector3();
            float z = right.Z;
            float y = left.Y;
            float num4 = left.Z;
            float num3 = right.Y;
            vector.X = (y * z) - (num3 * num4);
            float x = right.X;
            float num = left.X;
            vector.Y = (x * num4) - (num * z);
            vector.Z = (num * num3) - (x * y);
            return vector;
        }

        public static unsafe float Distance(Vector3 position1, Vector3 position2)
        {
            Vector3 vector3 = position2;
            Vector3 vector = position1;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector3, (float*) &vector);
            return vector.Length();
        }

        public static unsafe float Distance2D(Vector3 position1, Vector3 position2)
        {
            Vector3 vector2;
            Vector3 vector3;
            vector3.X = position1.X;
            vector3.Y = position1.Y;
            vector3.Z = 0f;
            vector2.X = position2.X;
            vector2.Y = position2.Y;
            vector2.Z = 0f;
            Vector3 vector5 = vector2;
            Vector3 vector = vector3;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector5, (float*) &vector);
            return vector.Length();
        }

        public static unsafe float DistanceSquared(Vector3 position1, Vector3 position2)
        {
            Vector3 vector3 = position2;
            Vector3 vector = position1;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector3, (float*) &vector);
            return vector.LengthSquared();
        }

        public static unsafe float DistanceSquared2D(Vector3 position1, Vector3 position2)
        {
            Vector3 vector2;
            Vector3 vector3;
            vector3.X = position1.X;
            vector3.Y = position1.Y;
            vector3.Z = 0f;
            vector2.X = position2.X;
            vector2.Y = position2.Y;
            vector2.Z = 0f;
            Vector3 vector5 = vector2;
            Vector3 vector = vector3;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector5, (float*) &vector);
            return vector.LengthSquared();
        }

        public unsafe float DistanceTo(Vector3 position)
        {
            Vector3 vector3 = this;
            Vector3 vector = position;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector3, (float*) &vector);
            return vector.Length();
        }

        public unsafe float DistanceTo2D(Vector3 position)
        {
            Vector3 vector2;
            Vector3 vector3;
            vector3.X = this.X;
            vector3.Y = this.Y;
            vector3.Z = 0f;
            vector2.X = position.X;
            vector2.Y = position.Y;
            vector2.Z = 0f;
            Vector3 vector5 = vector2;
            Vector3 vector = vector3;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector5, (float*) &vector);
            return vector.Length();
        }

        public unsafe float DistanceToSquared(Vector3 position)
        {
            Vector3 vector4 = this;
            Vector3 vector = position;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector4, (float*) &vector);
            return vector.LengthSquared();
        }

        public unsafe float DistanceToSquared2D(Vector3 position)
        {
            Vector3 vector2;
            Vector3 vector3;
            vector3.X = this.X;
            vector3.Y = this.Y;
            vector3.Z = 0f;
            vector2.X = position.X;
            vector2.Y = position.Y;
            vector2.Z = 0f;
            Vector3 vector5 = vector2;
            Vector3 vector = vector3;
            vsub_sse((float modopt(IsConst)*) &vector, (float modopt(IsConst)*) &vector5, (float*) &vector);
            return vector.LengthSquared();
        }

        public static unsafe Vector3 Divide(Vector3 value, float scale)
        {
            vdiv_sse((float modopt(IsConst)*) &value, scale, (float*) &value);
            return value;
        }

        public static float Dot(Vector3 left, Vector3 right) => 
            ((left.Y * right.Y) + (left.X * right.X)) + (left.Z * right.Z);

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Equals(Vector3 other)
        {
            int num = ((this.X != other.X) || ((this.Y != other.Y) || (this.Z != other.Z))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public sealed override unsafe bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == this.GetType()) && this.Equals(*((Vector3*) obj)));

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool Equals(ref Vector3 value1, ref Vector3 value2)
        {
            int num = ((value1.X != value2.X) || ((value1.Y != value2.Y) || (value1.Z != value2.Z))) ? 0 : 1;
            return (bool) ((byte) num);
        }

        public sealed override int GetHashCode()
        {
            float x = this.X;
            float y = this.Y;
            int num2 = this.Z.GetHashCode() >> 2;
            int num = (y.GetHashCode() << 2) ^ num2;
            return (x.GetHashCode() ^ num);
        }

        public float Length()
        {
            double num2;
            double y = this.Y;
            double z = this.Z;
            return (float) Math.Sqrt(((this.X * num2) + (y * y)) + (z * z));
        }

        public float LengthSquared()
        {
            double num2;
            double y = this.Y;
            double z = this.Z;
            return (float) (((this.X * num2) + (y * y)) + (z * z));
        }

        public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
        {
            Vector3 vector = new Vector3();
            float x = start.X;
            vector.X = ((end.X - x) * amount) + x;
            float y = start.Y;
            vector.Y = ((end.Y - y) * amount) + y;
            float z = start.Z;
            vector.Z = ((end.Z - z) * amount) + z;
            return vector;
        }

        public static Vector3 Maximize(Vector3 value1, Vector3 value2)
        {
            Vector3 vector = new Vector3();
            float x = value1.X;
            float num8 = value2.X;
            float num7 = (x <= num8) ? num8 : x;
            vector.X = num7;
            float y = value1.Y;
            float num5 = value2.Y;
            float num4 = (y <= num5) ? num5 : y;
            vector.Y = num4;
            float z = value1.Z;
            float num2 = value2.Z;
            float num = (z <= num2) ? num2 : z;
            vector.Z = num;
            return vector;
        }

        public static Vector3 Minimize(Vector3 value1, Vector3 value2)
        {
            Vector3 vector = new Vector3();
            float x = value1.X;
            float num8 = value2.X;
            float num7 = (x >= num8) ? num8 : x;
            vector.X = num7;
            float y = value1.Y;
            float num5 = value2.Y;
            float num4 = (y >= num5) ? num5 : y;
            vector.Y = num4;
            float z = value1.Z;
            float num2 = value2.Z;
            float num = (z >= num2) ? num2 : z;
            vector.Z = num;
            return vector;
        }

        public static unsafe Vector3 Modulate(Vector3 left, Vector3 right)
        {
            vadd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Vector3 Multiply(Vector3 value, float scale)
        {
            vdiv_sse((float modopt(IsConst)*) &value, scale, (float*) &value);
            return value;
        }

        public static unsafe Vector3 Negate(Vector3 value)
        {
            vneg_sse((float modopt(IsConst)*) &value, (float*) &value);
            return value;
        }

        public void Normalize()
        {
            float num = this.Length();
            if (num != 0f)
            {
                ref Vector3 modopt(IsExplicitlyDereferenced) pinned vectorRef = ref (ref Vector3 modopt(IsExplicitlyDereferenced)) this;
                vdiv_sse(vectorRef, num, vectorRef);
            }
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            vector.Normalize();
            return vector;
        }

        public static unsafe Vector3 operator +(Vector3 left, Vector3 right)
        {
            vadd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Vector3 operator /(Vector3 vector, float scale)
        {
            vdiv_sse((float modopt(IsConst)*) &vector, scale, (float*) &vector);
            return vector;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator ==(Vector3 left, Vector3 right) => 
            Equals(ref left, ref right);

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator !=(Vector3 left, Vector3 right) => 
            (bool) ((byte) !Equals(ref left, ref right));

        public static unsafe Vector3 operator *(Vector3 vector, float scale)
        {
            vmul_sse((float modopt(IsConst)*) &vector, scale, (float*) &vector);
            return vector;
        }

        public static unsafe Vector3 operator *(float scale, Vector3 vector)
        {
            vmul_sse((float modopt(IsConst)*) &vector, scale, (float*) &vector);
            return vector;
        }

        public static unsafe Vector3 operator -(Vector3 left, Vector3 right)
        {
            vsub_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public static unsafe Vector3 operator -(Vector3 value)
        {
            vneg_sse((float modopt(IsConst)*) &value, (float*) &value);
            return value;
        }

        public static unsafe Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            Vector3 vector3 = onNormal;
            vmul_sse((float modopt(IsConst)*) &vector3, Dot(vector, onNormal), (float*) &vector3);
            Vector3 vector2 = vector3;
            vdiv_sse((float modopt(IsConst)*) &vector2, Dot(onNormal, onNormal), (float*) &vector2);
            return vector2;
        }

        public static unsafe Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
        {
            Vector3 vector3 = Project(vector, planeNormal);
            Vector3 vector2 = vector;
            vsub_sse((float modopt(IsConst)*) &vector2, (float modopt(IsConst)*) &vector3, (float*) &vector2);
            return vector2;
        }

        public static Vector3 RandomXY()
        {
            Vector3 vector = new Vector3();
            double d = (GTA.Math.Random.Instance.NextDouble() * 2.0) * 3.1415926535897931;
            vector.X = (float) Math.Cos(d);
            vector.Y = (float) Math.Sin(d);
            vector.Normalize();
            return vector;
        }

        public static Vector3 RandomXYZ()
        {
            Vector3 vector = new Vector3();
            double d = (GTA.Math.Random.Instance.NextDouble() * 2.0) * 3.1415926535897931;
            double a = Math.Acos((GTA.Math.Random.Instance.NextDouble() * 2.0) - 1.0);
            vector.X = (float) (Math.Sin(a) * Math.Cos(d));
            vector.Y = (float) (Math.Sin(a) * Math.Sin(d));
            vector.Z = (float) Math.Cos(a);
            vector.Normalize();
            return vector;
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            Vector3 vector2 = new Vector3();
            float y = vector.Y;
            float num6 = normal.Y;
            float x = vector.X;
            float num4 = normal.X;
            float z = vector.Z;
            float num2 = normal.Z;
            float num = ((float) (((num4 * x) + (num6 * y)) * 2.0)) + (num2 * z);
            vector2.X = x - (num4 * num);
            vector2.Y = y - (num6 * num);
            vector2.Z = z - (num2 * num);
            return vector2;
        }

        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 planeNormal)
        {
            double num = Angle(from, to);
            if (Dot(Cross(planeNormal, from), to) < 0f)
            {
                num *= -1.0;
            }
            return (float) num;
        }

        public static unsafe Vector3 Subtract(Vector3 left, Vector3 right)
        {
            vadd_sse((float modopt(IsConst)*) &left, (float modopt(IsConst)*) &right, (float*) &left);
            return left;
        }

        public float ToHeading() => 
            (float) ((Math.Atan2((double) this.X, (double) -this.Y) + 3.1415926535897931) * 57.295779513082323);

        public sealed override string ToString()
        {
            float z;
            float y;
            float x;
            object[] args = new object[] { x.ToString(), y.ToString(), z.ToString() };
            x = this.X;
            y = this.Y;
            z = this.Z;
            return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2}", args);
        }

        public string ToString(string numberFormat)
        {
            float z;
            float y;
            float x;
            object[] args = new object[] { x.ToString(numberFormat), y.ToString(numberFormat), z.ToString(numberFormat) };
            x = this.X;
            y = this.Y;
            z = this.Z;
            return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2}", args);
        }

        public float this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.X;
                }
                if (index == 1)
                {
                    return this.Y;
                }
                if (index != 2)
                {
                    throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
                }
                return this.Z;
            }
            set
            {
                if (index == 0)
                {
                    this.X = value;
                }
                else if (index == 1)
                {
                    this.Y = value;
                }
                else
                {
                    if (index != 2)
                    {
                        throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
                    }
                    this.Z = value;
                }
            }
        }

        public static Vector3 RelativeBottom =>
            new Vector3(0f, 0f, -1f);

        public static Vector3 RelativeTop =>
            new Vector3(0f, 0f, 1f);

        public static Vector3 RelativeBack =>
            new Vector3(0f, -1f, 0f);

        public static Vector3 RelativeFront =>
            new Vector3(0f, 1f, 0f);

        public static Vector3 RelativeLeft =>
            new Vector3(-1f, 0f, 0f);

        public static Vector3 RelativeRight =>
            new Vector3(1f, 0f, 0f);

        public static Vector3 WorldWest =>
            new Vector3(-1f, 0f, 0f);

        public static Vector3 WorldEast =>
            new Vector3(1f, 0f, 0f);

        public static Vector3 WorldSouth =>
            new Vector3(0f, -1f, 0f);

        public static Vector3 WorldNorth =>
            new Vector3(0f, 1f, 0f);

        public static Vector3 WorldDown =>
            new Vector3(0f, 0f, -1f);

        public static Vector3 WorldUp =>
            new Vector3(0f, 0f, 1f);

        public static Vector3 Zero =>
            new Vector3(0f, 0f, 0f);

        public Vector3 Normalized
        {
            get
            {
                Vector3 vector = new Vector3();
                float num = this.Length();
                if (num != 0f)
                {
                    vdiv_sse((float modopt(IsConst)*) this, num, (float*) &vector);
                }
                return vector;
            }
        }
    }
}

