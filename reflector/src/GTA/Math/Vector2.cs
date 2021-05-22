namespace GTA.Math
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X;
        public float Y;
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2 Normalized
        {
            get
            {
                Vector2 vector2;
                vector2.X = this.X;
                vector2.Y = this.Y;
                Vector2 vector = vector2;
                vector.Normalize();
                return vector;
            }
        }
        public static Vector2 Zero =>
            new Vector2(0f, 0f);
        public static Vector2 Up =>
            new Vector2(0f, 1f);
        public static Vector2 Down =>
            new Vector2(0f, -1f);
        public static Vector2 Right =>
            new Vector2(1f, 0f);
        public static Vector2 Left =>
            new Vector2(-1f, 0f);
        public float this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.X;
                }
                if (index != 1)
                {
                    throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
                }
                return this.Y;
            }
            set
            {
                if (index == 0)
                {
                    this.X = value;
                }
                else
                {
                    if (index != 1)
                    {
                        throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
                    }
                    this.Y = value;
                }
            }
        }
        public float Length()
        {
            double num;
            double y = this.Y;
            return (float) Math.Sqrt((this.X * num) + (y * y));
        }

        public float LengthSquared()
        {
            double num;
            double y = this.Y;
            return (float) ((this.X * num) + (y * y));
        }

        public static Vector2 Normalize(Vector2 vector)
        {
            vector.Normalize();
            return vector;
        }

        public void Normalize()
        {
            float num2 = this.Length();
            if (num2 != 0f)
            {
                float num = (float) (1.0 / ((double) num2));
                this.X *= num;
                this.Y *= num;
            }
        }

        public float DistanceTo(Vector2 position) => 
            (position - this).Length();

        public float DistanceToSquared(Vector2 position)
        {
            Vector2 vector = this;
            return (position - vector).LengthSquared();
        }

        public static float Distance(Vector2 position1, Vector2 position2) => 
            (position1 - position2).Length();

        public static float DistanceSquared(Vector2 position1, Vector2 position2) => 
            (position1 - position2).LengthSquared();

        public static float Angle(Vector2 from, Vector2 to) => 
            Math.Abs(SignedAngle(from, to));

        public static float SignedAngle(Vector2 from, Vector2 to) => 
            (float) ((Math.Atan2((double) to.Y, (double) to.X) - Math.Atan2((double) from.Y, (double) from.X)) * 57.295779513082323);

        public float ToHeading() => 
            (float) ((Math.Atan2((double) this.X, (double) -this.Y) + 3.1415926535897931) * 57.295779513082323);

        public static Vector2 RandomXY()
        {
            Vector2 vector = new Vector2();
            double d = (GTA.Math.Random.Instance.NextDouble() * 2.0) * 3.1415926535897931;
            vector.X = (float) Math.Cos(d);
            vector.Y = (float) Math.Sin(d);
            vector.Normalize();
            return vector;
        }

        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            Vector2 vector;
            vector.X = left.X + right.X;
            vector.Y = left.Y + right.Y;
            return vector;
        }

        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            Vector2 vector;
            vector.X = left.X - right.X;
            vector.Y = left.Y - right.Y;
            return vector;
        }

        public static Vector2 Multiply(Vector2 value, float scale)
        {
            Vector2 vector;
            vector.X = value.X * scale;
            vector.Y = value.Y * scale;
            return vector;
        }

        public static Vector2 Modulate(Vector2 left, Vector2 right)
        {
            Vector2 vector;
            vector.X = left.X * right.X;
            vector.Y = left.Y * right.Y;
            return vector;
        }

        public static Vector2 Divide(Vector2 value, float scale)
        {
            Vector2 vector;
            vector.X = (float) (((double) value.X) / ((double) scale));
            vector.Y = (float) (((double) value.Y) / ((double) scale));
            return vector;
        }

        public static Vector2 Negate(Vector2 value)
        {
            Vector2 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            return vector;
        }

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            Vector2 vector;
            float x = value.X;
            float num9 = max.X;
            float num2 = (x <= num9) ? x : num9;
            float num8 = min.X;
            float num7 = (num2 >= num8) ? num2 : num8;
            float y = value.Y;
            float num5 = max.Y;
            float num = (y <= num5) ? y : num5;
            float num4 = min.Y;
            float num3 = (num >= num4) ? num : num4;
            vector.X = num7;
            vector.Y = num3;
            return vector;
        }

        public static Vector2 Lerp(Vector2 start, Vector2 end, float amount)
        {
            Vector2 vector = new Vector2();
            float x = start.X;
            vector.X = ((end.X - x) * amount) + x;
            float y = start.Y;
            vector.Y = ((end.Y - y) * amount) + y;
            return vector;
        }

        public static float Dot(Vector2 left, Vector2 right) => 
            (left.Y * right.Y) + (left.X * right.X);

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 vector2 = new Vector2();
            float y = vector.Y;
            float num4 = normal.Y;
            float x = vector.X;
            float num2 = normal.X;
            double num = ((num2 * x) + (num4 * y)) * 2.0;
            vector2.X = x - ((float) (num2 * num));
            vector2.Y = y - ((float) (num4 * num));
            return vector2;
        }

        public static Vector2 Minimize(Vector2 value1, Vector2 value2)
        {
            Vector2 vector = new Vector2();
            float x = value1.X;
            float num5 = value2.X;
            float num4 = (x >= num5) ? num5 : x;
            vector.X = num4;
            float y = value1.Y;
            float num2 = value2.Y;
            float num = (y >= num2) ? num2 : y;
            vector.Y = num;
            return vector;
        }

        public static Vector2 Maximize(Vector2 value1, Vector2 value2)
        {
            Vector2 vector = new Vector2();
            float x = value1.X;
            float num5 = value2.X;
            float num4 = (x <= num5) ? num5 : x;
            vector.X = num4;
            float y = value1.Y;
            float num2 = value2.Y;
            float num = (y <= num2) ? num2 : y;
            vector.Y = num;
            return vector;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            Vector2 vector;
            vector.X = left.X + right.X;
            vector.Y = left.Y + right.Y;
            return vector;
        }

        public static Vector2 operator -(Vector2 value)
        {
            Vector2 vector;
            vector.X = -value.X;
            vector.Y = -value.Y;
            return vector;
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            Vector2 vector;
            vector.X = left.X - right.X;
            vector.Y = left.Y - right.Y;
            return vector;
        }

        public static Vector2 operator *(float scale, Vector2 vector) => 
            vector * scale;

        public static Vector2 operator *(Vector2 vector, float scale)
        {
            Vector2 vector2;
            vector2.X = vector.X * scale;
            vector2.Y = vector.Y * scale;
            return vector2;
        }

        public static Vector2 operator /(Vector2 vector, float scale)
        {
            Vector2 vector2;
            vector2.X = (float) (((double) vector.X) / ((double) scale));
            vector2.Y = (float) (((double) vector.Y) / ((double) scale));
            return vector2;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator ==(Vector2 left, Vector2 right) => 
            Equals(ref left, ref right);

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator !=(Vector2 left, Vector2 right) => 
            (bool) ((byte) !Equals(ref left, ref right));

        public sealed override string ToString()
        {
            float y;
            float x;
            object[] args = new object[] { x.ToString(), y.ToString() };
            x = this.X;
            y = this.Y;
            return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1}", args);
        }

        public sealed override int GetHashCode()
        {
            float x = this.X;
            return (this.Y.GetHashCode() ^ x.GetHashCode());
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool Equals(ref Vector2 value1, ref Vector2 value2)
        {
            int num = ((value1.X != value2.X) || (value1.Y != value2.Y)) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool Equals(Vector2 other)
        {
            int num = ((this.X != other.X) || (this.Y != other.Y)) ? 0 : 1;
            return (bool) ((byte) num);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public sealed override unsafe bool Equals(object obj) => 
            (obj != null) && ((obj.GetType() == this.GetType()) && this.Equals(*((Vector2*) obj)));
    }
}

