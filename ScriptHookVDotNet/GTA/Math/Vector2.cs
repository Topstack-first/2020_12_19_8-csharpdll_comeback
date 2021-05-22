// Decompiled with JetBrains decompiler
// Type: GTA.Math.Vector2
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace GTA.Math
{
  [Serializable]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
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
        float y = this.Y;
        float x = this.X;
        Vector2 vector2_1;
        vector2_1.X = x;
        vector2_1.Y = y;
        Vector2 vector2_2 = vector2_1;
        vector2_2.Normalize();
        return vector2_2;
      }
    }

    public static Vector2 Zero => new Vector2(0.0f, 0.0f);

    public static Vector2 Up => new Vector2(0.0f, 1f);

    public static Vector2 Down => new Vector2(0.0f, -1f);

    public static Vector2 Right => new Vector2(1f, 0.0f);

    public static Vector2 Left => new Vector2(-1f, 0.0f);

    public float this[int index]
    {
      get
      {
        if (index == 0)
          return this.X;
        if (index != 1)
          throw new ArgumentOutOfRangeException(nameof (index), "Indices for Vector2 run from 0 to 1, inclusive.");
        return this.Y;
      }
      set
      {
        if (index != 0)
        {
          if (index != 1)
            throw new ArgumentOutOfRangeException(nameof (index), "Indices for Vector2 run from 0 to 1, inclusive.");
          this.Y = value;
        }
        else
          this.X = value;
      }
    }

    public float Length()
    {
      double y = (double) this.Y;
      double x = (double) this.X;
      double num1 = x * x;
      double num2 = y;
      double num3 = num2 * num2;
      return (float) System.Math.Sqrt(num1 + num3);
    }

    public float LengthSquared()
    {
      double y = (double) this.Y;
      double x = (double) this.X;
      double num1 = x * x;
      double num2 = y;
      double num3 = num2 * num2;
      return (float) (num1 + num3);
    }

    public static Vector2 Normalize(Vector2 vector)
    {
      vector.Normalize();
      return vector;
    }

    public void Normalize()
    {
      float num1 = this.Length();
      if ((double) num1 == 0.0)
        return;
      float num2 = 1f / num1;
      this.X *= num2;
      this.Y *= num2;
    }

    public float DistanceTo(Vector2 position) => (position - this).Length();

    public float DistanceToSquared(Vector2 position)
    {
      Vector2 vector2 = this;
      return (position - vector2).LengthSquared();
    }

    public static float Distance(Vector2 position1, Vector2 position2) => (position1 - position2).Length();

    public static float DistanceSquared(Vector2 position1, Vector2 position2) => (position1 - position2).LengthSquared();

    public static float Angle(Vector2 from, Vector2 to) => System.Math.Abs(Vector2.SignedAngle(from, to));

    public static float SignedAngle(Vector2 from, Vector2 to) => (float) ((System.Math.Atan2((double) to.Y, (double) to.X) - System.Math.Atan2((double) from.Y, (double) from.X)) * (180.0 / System.Math.PI));

    public float ToHeading() => (float) ((System.Math.Atan2((double) this.X, -(double) this.Y) + System.Math.PI) * (180.0 / System.Math.PI));

    public static Vector2 RandomXY()
    {
      Vector2 vector2 = new Vector2();
      double num = Random.Instance.NextDouble() * 2.0 * System.Math.PI;
      vector2.X = (float) System.Math.Cos(num);
      vector2.Y = (float) System.Math.Sin(num);
      vector2.Normalize();
      return vector2;
    }

    public static Vector2 Add(Vector2 left, Vector2 right)
    {
      Vector2 vector2;
      vector2.X = left.X + right.X;
      vector2.Y = left.Y + right.Y;
      return vector2;
    }

    public static Vector2 Subtract(Vector2 left, Vector2 right)
    {
      Vector2 vector2;
      vector2.X = left.X - right.X;
      vector2.Y = left.Y - right.Y;
      return vector2;
    }

    public static Vector2 Multiply(Vector2 value, float scale)
    {
      Vector2 vector2;
      vector2.X = value.X * scale;
      vector2.Y = value.Y * scale;
      return vector2;
    }

    public static Vector2 Modulate(Vector2 left, Vector2 right)
    {
      Vector2 vector2;
      vector2.X = left.X * right.X;
      vector2.Y = left.Y * right.Y;
      return vector2;
    }

    public static Vector2 Divide(Vector2 value, float scale)
    {
      Vector2 vector2;
      vector2.X = value.X / scale;
      vector2.Y = value.Y / scale;
      return vector2;
    }

    public static Vector2 Negate(Vector2 value)
    {
      float num1 = -value.Y;
      float num2 = -value.X;
      Vector2 vector2;
      vector2.X = num2;
      vector2.Y = num1;
      return vector2;
    }

    public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
    {
      float x1 = value.X;
      float x2 = max.X;
      float num1 = (double) x1 <= (double) x2 ? x1 : x2;
      float x3 = min.X;
      float num2 = (double) num1 >= (double) x3 ? num1 : x3;
      float y1 = value.Y;
      float y2 = max.Y;
      float num3 = (double) y1 <= (double) y2 ? y1 : y2;
      float y3 = min.Y;
      float num4 = (double) num3 >= (double) y3 ? num3 : y3;
      Vector2 vector2;
      vector2.X = num2;
      vector2.Y = num4;
      return vector2;
    }

    public static Vector2 Lerp(Vector2 start, Vector2 end, float amount)
    {
      Vector2 vector2 = new Vector2();
      float x = start.X;
      vector2.X = (end.X - x) * amount + x;
      float y = start.Y;
      vector2.Y = (end.Y - y) * amount + y;
      return vector2;
    }

    public static float Dot(Vector2 left, Vector2 right) => (float) ((double) left.Y * (double) right.Y + (double) left.X * (double) right.X);

    public static Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
      Vector2 vector2 = new Vector2();
      float y1 = vector.Y;
      float y2 = normal.Y;
      float x1 = vector.X;
      float x2 = normal.X;
      double num = ((double) x2 * (double) x1 + (double) y2 * (double) y1) * 2.0;
      vector2.X = x1 - x2 * (float) num;
      vector2.Y = y1 - y2 * (float) num;
      return vector2;
    }

    public static Vector2 Minimize(Vector2 value1, Vector2 value2)
    {
      Vector2 vector2 = new Vector2();
      float x1 = value1.X;
      float x2 = value2.X;
      float num1 = (double) x1 >= (double) x2 ? x2 : x1;
      vector2.X = num1;
      float y1 = value1.Y;
      float y2 = value2.Y;
      float num2 = (double) y1 >= (double) y2 ? y2 : y1;
      vector2.Y = num2;
      return vector2;
    }

    public static Vector2 Maximize(Vector2 value1, Vector2 value2)
    {
      Vector2 vector2 = new Vector2();
      float x1 = value1.X;
      float x2 = value2.X;
      float num1 = (double) x1 <= (double) x2 ? x2 : x1;
      vector2.X = num1;
      float y1 = value1.Y;
      float y2 = value2.Y;
      float num2 = (double) y1 <= (double) y2 ? y2 : y1;
      vector2.Y = num2;
      return vector2;
    }

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
      Vector2 vector2;
      vector2.X = left.X + right.X;
      vector2.Y = left.Y + right.Y;
      return vector2;
    }

    public static Vector2 operator -(Vector2 value)
    {
      float num1 = -value.Y;
      float num2 = -value.X;
      Vector2 vector2;
      vector2.X = num2;
      vector2.Y = num1;
      return vector2;
    }

    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
      Vector2 vector2;
      vector2.X = left.X - right.X;
      vector2.Y = left.Y - right.Y;
      return vector2;
    }

    public static Vector2 operator *(float scale, Vector2 vector) => vector * scale;

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
      vector2.X = vector.X / scale;
      vector2.Y = vector.Y / scale;
      return vector2;
    }

    public static bool operator ==(Vector2 left, Vector2 right) => Vector2.Equals(ref left, ref right);

    public static bool operator !=(Vector2 left, Vector2 right) => !Vector2.Equals(ref left, ref right);

    public override sealed string ToString()
    {
      object[] objArray = new object[2];
      float x = this.X;
      objArray[0] = (object) x.ToString();
      float y = this.Y;
      objArray[1] = (object) y.ToString();
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "X:{0} Y:{1}", objArray);
    }

    public override sealed int GetHashCode()
    {
      float x = this.X;
      return this.Y.GetHashCode() ^ x.GetHashCode();
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static bool Equals(ref Vector2 value1, ref Vector2 value2) => (double) value1.X == (double) value2.X && (double) value1.Y == (double) value2.Y;

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Equals(Vector2 other) => (double) this.X == (double) other.X && (double) this.Y == (double) other.Y;

    [return: MarshalAs(UnmanagedType.U1)]
    public override sealed bool Equals(object obj) => obj != null && !(obj.GetType() != this.GetType()) && this.Equals((Vector2) obj);
  }
}
