// Decompiled with JetBrains decompiler
// Type: GTA.Math.Vector3
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace GTA.Math
{
  [Serializable]
  [StructLayout(LayoutKind.Explicit, Pack = 4)]
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

    public unsafe Vector3 Normalized
    {
      get
      {
        Vector3 vector3 = new Vector3();
        float num = this.Length();
        if ((double) num == 0.0)
          return vector3;
        fixed (Vector3* vector3Ptr = &this)
        {
          _Module_.vdiv_sse((float*) vector3Ptr, num, (float*) &vector3);
          return vector3;
        }
      }
    }

    public static Vector3 Zero => new Vector3(0.0f, 0.0f, 0.0f);

    public static Vector3 WorldUp => new Vector3(0.0f, 0.0f, 1f);

    public static Vector3 WorldDown => new Vector3(0.0f, 0.0f, -1f);

    public static Vector3 WorldNorth => new Vector3(0.0f, 1f, 0.0f);

    public static Vector3 WorldSouth => new Vector3(0.0f, -1f, 0.0f);

    public static Vector3 WorldEast => new Vector3(1f, 0.0f, 0.0f);

    public static Vector3 WorldWest => new Vector3(-1f, 0.0f, 0.0f);

    public static Vector3 RelativeRight => new Vector3(1f, 0.0f, 0.0f);

    public static Vector3 RelativeLeft => new Vector3(-1f, 0.0f, 0.0f);

    public static Vector3 RelativeFront => new Vector3(0.0f, 1f, 0.0f);

    public static Vector3 RelativeBack => new Vector3(0.0f, -1f, 0.0f);

    public static Vector3 RelativeTop => new Vector3(0.0f, 0.0f, 1f);

    public static Vector3 RelativeBottom => new Vector3(0.0f, 0.0f, -1f);

    public float this[int index]
    {
      get
      {
        if (index == 0)
          return this.X;
        if (index == 1)
          return this.Y;
        if (index != 2)
          throw new ArgumentOutOfRangeException(nameof (index), "Indices for Vector3 run from 0 to 2, inclusive.");
        return this.Z;
      }
      set
      {
        if (index != 0)
        {
          if (index != 1)
          {
            if (index != 2)
              throw new ArgumentOutOfRangeException(nameof (index), "Indices for Vector3 run from 0 to 2, inclusive.");
            this.Z = value;
          }
          else
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
      double z = (double) this.Z;
      double num1 = x;
      double num2 = num1 * num1;
      double num3 = y;
      double num4 = num3 * num3;
      double num5 = num2 + num4;
      double num6 = z;
      double num7 = num6 * num6;
      return (float) System.Math.Sqrt(num5 + num7);
    }

    public float LengthSquared()
    {
      double y = (double) this.Y;
      double x = (double) this.X;
      double z = (double) this.Z;
      double num1 = x;
      double num2 = num1 * num1;
      double num3 = y;
      double num4 = num3 * num3;
      double num5 = num2 + num4;
      double num6 = z;
      double num7 = num6 * num6;
      return (float) (num5 + num7);
    }

    public static Vector3 Normalize(Vector3 vector)
    {
      vector.Normalize();
      return vector;
    }

    public unsafe void Normalize()
    {
      float num = this.Length();
      if ((double) num == 0.0)
        return;
      fixed (Vector3* vector3Ptr = &this)
        _Module_.vdiv_sse((float*) vector3Ptr, num, (float*) vector3Ptr);
    }

    public unsafe float DistanceTo(Vector3 position)
    {
      Vector3 vector3_1 = this;
      Vector3 vector3_2 = position;
      _Module_.vsub_sse((float*) &vector3_2, (float*) &vector3_1, (float*) &vector3_2);
      return vector3_2.Length();
    }

    public unsafe float DistanceToSquared(Vector3 position)
    {
      Vector3 vector3_1 = this;
      Vector3 vector3_2 = position;
      _Module_.vsub_sse((float*) &vector3_2, (float*) &vector3_1, (float*) &vector3_2);
      return vector3_2.LengthSquared();
    }

    public unsafe float DistanceTo2D(Vector3 position)
    {
      float y1 = this.Y;
      float x1 = this.X;
      Vector3 vector3_1;
      vector3_1.X = x1;
      vector3_1.Y = y1;
      vector3_1.Z = 0.0f;
      float y2 = position.Y;
      float x2 = position.X;
      Vector3 vector3_2;
      vector3_2.X = x2;
      vector3_2.Y = y2;
      vector3_2.Z = 0.0f;
      Vector3 vector3_3 = vector3_2;
      Vector3 vector3_4 = vector3_1;
      _Module_.vsub_sse((float*) &vector3_4, (float*) &vector3_3, (float*) &vector3_4);
      return vector3_4.Length();
    }

    public unsafe float DistanceToSquared2D(Vector3 position)
    {
      float y1 = this.Y;
      float x1 = this.X;
      Vector3 vector3_1;
      vector3_1.X = x1;
      vector3_1.Y = y1;
      vector3_1.Z = 0.0f;
      float y2 = position.Y;
      float x2 = position.X;
      Vector3 vector3_2;
      vector3_2.X = x2;
      vector3_2.Y = y2;
      vector3_2.Z = 0.0f;
      Vector3 vector3_3 = vector3_2;
      Vector3 vector3_4 = vector3_1;
      _Module_.vsub_sse((float*) &vector3_4, (float*) &vector3_3, (float*) &vector3_4);
      return vector3_4.LengthSquared();
    }

    public static unsafe float Distance(Vector3 position1, Vector3 position2)
    {
      Vector3 vector3_1 = position2;
      Vector3 vector3_2 = position1;
      _Module_.vsub_sse((float*) &vector3_2, (float*) &vector3_1, (float*) &vector3_2);
      return vector3_2.Length();
    }

    public static unsafe float DistanceSquared(Vector3 position1, Vector3 position2)
    {
      Vector3 vector3_1 = position2;
      Vector3 vector3_2 = position1;
      _Module_.vsub_sse((float*) &vector3_2, (float*) &vector3_1, (float*) &vector3_2);
      return vector3_2.LengthSquared();
    }

    public static unsafe float Distance2D(Vector3 position1, Vector3 position2)
    {
      float y1 = position1.Y;
      float x1 = position1.X;
      Vector3 vector3_1;
      vector3_1.X = x1;
      vector3_1.Y = y1;
      vector3_1.Z = 0.0f;
      float y2 = position2.Y;
      float x2 = position2.X;
      Vector3 vector3_2;
      vector3_2.X = x2;
      vector3_2.Y = y2;
      vector3_2.Z = 0.0f;
      Vector3 vector3_3 = vector3_2;
      Vector3 vector3_4 = vector3_1;
      _Module_.vsub_sse((float*) &vector3_4, (float*) &vector3_3, (float*) &vector3_4);
      return vector3_4.Length();
    }

    public static unsafe float DistanceSquared2D(Vector3 position1, Vector3 position2)
    {
      float y1 = position1.Y;
      float x1 = position1.X;
      Vector3 vector3_1;
      vector3_1.X = x1;
      vector3_1.Y = y1;
      vector3_1.Z = 0.0f;
      float y2 = position2.Y;
      float x2 = position2.X;
      Vector3 vector3_2;
      vector3_2.X = x2;
      vector3_2.Y = y2;
      vector3_2.Z = 0.0f;
      Vector3 vector3_3 = vector3_2;
      Vector3 vector3_4 = vector3_1;
      _Module_.vsub_sse((float*) &vector3_4, (float*) &vector3_3, (float*) &vector3_4);
      return vector3_4.LengthSquared();
    }

    public static float Angle(Vector3 from, Vector3 to)
    {
      Vector3 normalized = to.Normalized;
      return (float) (System.Math.Acos((double) Vector3.Dot(from.Normalized, normalized)) * (180.0 / System.Math.PI));
    }

    public static float SignedAngle(Vector3 from, Vector3 to, Vector3 planeNormal)
    {
      Vector3 left = Vector3.Cross(planeNormal, from);
      double num = (double) Vector3.Angle(from, to);
      Vector3 right = to;
      if ((double) Vector3.Dot(left, right) < 0.0)
        num *= -1.0;
      return (float) num;
    }

    public float ToHeading() => (float) ((System.Math.Atan2((double) this.X, -(double) this.Y) + System.Math.PI) * (180.0 / System.Math.PI));

    public unsafe Vector3 Around(float distance)
    {
      Vector3 vector3_1 = Vector3.RandomXY();
      _Module_.vmul_sse((float*) &vector3_1, distance, (float*) &vector3_1);
      Vector3 vector3_2 = vector3_1;
      Vector3 vector3_3 = this;
      _Module_.vadd_sse((float*) &vector3_3, (float*) &vector3_2, (float*) &vector3_3);
      return vector3_3;
    }

    public static Vector3 RandomXY()
    {
      Vector3 vector3 = new Vector3();
      double num = Random.Instance.NextDouble() * 2.0 * System.Math.PI;
      vector3.X = (float) System.Math.Cos(num);
      vector3.Y = (float) System.Math.Sin(num);
      vector3.Normalize();
      return vector3;
    }

    public static Vector3 RandomXYZ()
    {
      Vector3 vector3 = new Vector3();
      double num1 = Random.Instance.NextDouble() * 2.0 * System.Math.PI;
      double num2 = System.Math.Acos(Random.Instance.NextDouble() * 2.0 - 1.0);
      vector3.X = (float) (System.Math.Sin(num2) * System.Math.Cos(num1));
      vector3.Y = (float) (System.Math.Sin(num2) * System.Math.Sin(num1));
      vector3.Z = (float) System.Math.Cos(num2);
      vector3.Normalize();
      return vector3;
    }

    public static unsafe Vector3 Add(Vector3 left, Vector3 right)
    {
      _Module_.vadd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Vector3 Subtract(Vector3 left, Vector3 right)
    {
      _Module_.vadd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Vector3 Multiply(Vector3 value, float scale)
    {
      _Module_.vdiv_sse((float*) &value, scale, (float*) &value);
      return value;
    }

    public static unsafe Vector3 Modulate(Vector3 left, Vector3 right)
    {
      _Module_.vadd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Vector3 Divide(Vector3 value, float scale)
    {
      _Module_.vdiv_sse((float*) &value, scale, (float*) &value);
      return value;
    }

    public static unsafe Vector3 Negate(Vector3 value)
    {
      _Module_.vneg_sse((float*) &value, (float*) &value);
      return value;
    }

    public static unsafe Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
    {
      _Module_.vclamp_sse((float*) &value, (float*) &min, (float*) &max, (float*) &value);
      return value;
    }

    public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
    {
      Vector3 vector3 = new Vector3();
      float x = start.X;
      vector3.X = (end.X - x) * amount + x;
      float y = start.Y;
      vector3.Y = (end.Y - y) * amount + y;
      float z = start.Z;
      vector3.Z = (end.Z - z) * amount + z;
      return vector3;
    }

    public static float Dot(Vector3 left, Vector3 right) => (float) ((double) left.Y * (double) right.Y + (double) left.X * (double) right.X + (double) left.Z * (double) right.Z);

    public static Vector3 Cross(Vector3 left, Vector3 right)
    {
      Vector3 vector3 = new Vector3();
      float z1 = right.Z;
      float y1 = left.Y;
      float z2 = left.Z;
      float y2 = right.Y;
      vector3.X = (float) ((double) y1 * (double) z1 - (double) y2 * (double) z2);
      float x1 = right.X;
      float x2 = left.X;
      vector3.Y = (float) ((double) x1 * (double) z2 - (double) x2 * (double) z1);
      vector3.Z = (float) ((double) x2 * (double) y2 - (double) x1 * (double) y1);
      return vector3;
    }

    public static unsafe Vector3 Project(Vector3 vector, Vector3 onNormal)
    {
      float num1 = Vector3.Dot(vector, onNormal);
      Vector3 vector3_1 = onNormal;
      _Module_.vmul_sse((float*) &vector3_1, num1, (float*) &vector3_1);
      Vector3 vector3_2 = onNormal;
      float num2 = Vector3.Dot(vector3_2, vector3_2);
      Vector3 vector3_3 = vector3_1;
      _Module_.vdiv_sse((float*) &vector3_3, num2, (float*) &vector3_3);
      return vector3_3;
    }

    public static unsafe Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
    {
      Vector3 vector3_1 = Vector3.Project(vector, planeNormal);
      Vector3 vector3_2 = vector;
      _Module_.vsub_sse((float*) &vector3_2, (float*) &vector3_1, (float*) &vector3_2);
      return vector3_2;
    }

    public static Vector3 Reflect(Vector3 vector, Vector3 normal)
    {
      Vector3 vector3 = new Vector3();
      float y1 = vector.Y;
      float y2 = normal.Y;
      float x1 = vector.X;
      float x2 = normal.X;
      float z1 = vector.Z;
      float z2 = normal.Z;
      float num = (float) (((double) x2 * (double) x1 + (double) y2 * (double) y1) * 2.0 + (double) z2 * (double) z1);
      vector3.X = x1 - x2 * num;
      vector3.Y = y1 - y2 * num;
      vector3.Z = z1 - z2 * num;
      return vector3;
    }

    public static Vector3 Minimize(Vector3 value1, Vector3 value2)
    {
      Vector3 vector3 = new Vector3();
      float x1 = value1.X;
      float x2 = value2.X;
      float num1 = (double) x1 >= (double) x2 ? x2 : x1;
      vector3.X = num1;
      float y1 = value1.Y;
      float y2 = value2.Y;
      float num2 = (double) y1 >= (double) y2 ? y2 : y1;
      vector3.Y = num2;
      float z1 = value1.Z;
      float z2 = value2.Z;
      float num3 = (double) z1 >= (double) z2 ? z2 : z1;
      vector3.Z = num3;
      return vector3;
    }

    public static Vector3 Maximize(Vector3 value1, Vector3 value2)
    {
      Vector3 vector3 = new Vector3();
      float x1 = value1.X;
      float x2 = value2.X;
      float num1 = (double) x1 <= (double) x2 ? x2 : x1;
      vector3.X = num1;
      float y1 = value1.Y;
      float y2 = value2.Y;
      float num2 = (double) y1 <= (double) y2 ? y2 : y1;
      vector3.Y = num2;
      float z1 = value1.Z;
      float z2 = value2.Z;
      float num3 = (double) z1 <= (double) z2 ? z2 : z1;
      vector3.Z = num3;
      return vector3;
    }

    public static unsafe Vector3 operator +(Vector3 left, Vector3 right)
    {
      _Module_.vadd_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Vector3 operator -(Vector3 value)
    {
      _Module_.vneg_sse((float*) &value, (float*) &value);
      return value;
    }

    public static unsafe Vector3 operator -(Vector3 left, Vector3 right)
    {
      _Module_.vsub_sse((float*) &left, (float*) &right, (float*) &left);
      return left;
    }

    public static unsafe Vector3 operator *(float scale, Vector3 vector)
    {
      _Module_.vmul_sse((float*) &vector, scale, (float*) &vector);
      return vector;
    }

    public static unsafe Vector3 operator *(Vector3 vector, float scale)
    {
      _Module_.vmul_sse((float*) &vector, scale, (float*) &vector);
      return vector;
    }

    public static unsafe Vector3 operator /(Vector3 vector, float scale)
    {
      _Module_.vdiv_sse((float*) &vector, scale, (float*) &vector);
      return vector;
    }

    public static bool operator ==(Vector3 left, Vector3 right) => Vector3.Equals(ref left, ref right);

    public static bool operator !=(Vector3 left, Vector3 right) => !Vector3.Equals(ref left, ref right);

    public string ToString(string numberFormat)
    {
      object[] objArray = new object[3];
      float x = this.X;
      objArray[0] = (object) x.ToString(numberFormat);
      float y = this.Y;
      objArray[1] = (object) y.ToString(numberFormat);
      float z = this.Z;
      objArray[2] = (object) z.ToString(numberFormat);
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2}", objArray);
    }

    public override sealed string ToString()
    {
      object[] objArray = new object[3];
      float x = this.X;
      objArray[0] = (object) x.ToString();
      float y = this.Y;
      objArray[1] = (object) y.ToString();
      float z = this.Z;
      objArray[2] = (object) z.ToString();
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2}", objArray);
    }

    public override sealed int GetHashCode()
    {
      float x = this.X;
      float y = this.Y;
      int num1 = this.Z.GetHashCode() >> 2;
      int num2 = y.GetHashCode() << 2 ^ num1;
      return x.GetHashCode() ^ num2;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static bool Equals(ref Vector3 value1, ref Vector3 value2) => (double) value1.X == (double) value2.X && (double) value1.Y == (double) value2.Y && (double) value1.Z == (double) value2.Z;

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Equals(Vector3 other) => (double) this.X == (double) other.X && (double) this.Y == (double) other.Y && (double) this.Z == (double) other.Z;

    [return: MarshalAs(UnmanagedType.U1)]
    public override sealed bool Equals(object obj) => obj != null && !(obj.GetType() != this.GetType()) && this.Equals((Vector3) obj);
  }
}
