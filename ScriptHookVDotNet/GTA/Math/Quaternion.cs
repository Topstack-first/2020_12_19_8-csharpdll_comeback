// Decompiled with JetBrains decompiler
// Type: GTA.Math.Quaternion
// Assembly: ScriptHookVDotNet, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD9F6FD6-E46D-4D51-9DEA-DEB4B2C6D71F
// Assembly location: E:\projects\fixed\2020_12_19_8(c#dll_comeback)\ScriptHookVDotNet.dll

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace GTA.Math
{
  [Serializable]
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

    public static Quaternion Identity => new Quaternion(0.0f, 0.0f, 0.0f, 1f);

    public Vector3 Axis
    {
      get
      {
        Vector3 vector3 = new Vector3();
        float num1 = this.Length();
        if ((double) num1 != 0.0)
        {
          float num2 = 1f / num1;
          vector3.X = this.X * num2;
          vector3.Y = this.Y * num2;
          vector3.Z = this.Z * num2;
        }
        else
        {
          vector3.X = 1f;
          vector3.Y = 0.0f;
          vector3.Z = 0.0f;
        }
        return vector3;
      }
    }

    public float Angle => (double) System.Math.Abs(this.W) > 1.0 ? 0.0f : (float) System.Math.Acos((double) this.W) * 2f;

    public float Length()
    {
      double y = (double) this.Y;
      double x = (double) this.X;
      double z = (double) this.Z;
      double w = (double) this.W;
      double num1 = x;
      double num2 = num1 * num1;
      double num3 = y;
      double num4 = num3 * num3;
      double num5 = num2 + num4;
      double num6 = z;
      double num7 = num6 * num6;
      double num8 = num5 + num7;
      double num9 = w;
      double num10 = num9 * num9;
      return (float) System.Math.Sqrt(num8 + num10);
    }

    public float LengthSquared()
    {
      double y = (double) this.Y;
      double x = (double) this.X;
      double z = (double) this.Z;
      double w = (double) this.W;
      double num1 = x;
      double num2 = num1 * num1;
      double num3 = y;
      double num4 = num3 * num3;
      double num5 = num2 + num4;
      double num6 = z;
      double num7 = num6 * num6;
      double num8 = num5 + num7;
      double num9 = w;
      double num10 = num9 * num9;
      return (float) (num8 + num10);
    }

    public static Quaternion Normalize(Quaternion quaternion)
    {
      quaternion.Normalize();
      return quaternion;
    }

    public void Normalize()
    {
      float num = 1f / this.Length();
      this.X *= num;
      this.Y *= num;
      this.Z *= num;
      this.W *= num;
    }

    public void Conjugate()
    {
      ref Quaternion local1 = ref this;
      local1.X = -local1.X;
      ref Quaternion local2 = ref this;
      local2.Y = -local2.Y;
      ref Quaternion local3 = ref this;
      local3.Z = -local3.Z;
    }

    public static Quaternion Invert(Quaternion quaternion)
    {
      Quaternion quaternion1 = new Quaternion();
      float y = quaternion.Y;
      double num1 = (double) y;
      float x = quaternion.X;
      double num2 = (double) x;
      float z = quaternion.Z;
      double num3 = (double) z;
      float w = quaternion.W;
      double num4 = (double) w;
      double num5 = num2;
      double num6 = num5 * num5;
      double num7 = num1;
      double num8 = num7 * num7;
      double num9 = num6 + num8;
      double num10 = num3;
      double num11 = num10 * num10;
      double num12 = num9 + num11;
      double num13 = num4;
      double num14 = num13 * num13;
      float num15 = (float) (1.0 / (num12 + num14));
      quaternion1.X = -x * num15;
      quaternion1.Y = -y * num15;
      quaternion1.Z = -z * num15;
      quaternion1.W = w * num15;
      return quaternion1;
    }

    public void Invert()
    {
      float y = this.Y;
      double num1 = (double) y;
      float x = this.X;
      double num2 = (double) x;
      float z = this.Z;
      double num3 = (double) z;
      float w = this.W;
      double num4 = (double) w;
      double num5 = num2;
      double num6 = num5 * num5;
      double num7 = num1;
      double num8 = num7 * num7;
      double num9 = num6 + num8;
      double num10 = num3;
      double num11 = num10 * num10;
      double num12 = num9 + num11;
      double num13 = num4;
      double num14 = num13 * num13;
      float num15 = (float) (1.0 / (num12 + num14));
      this.X = -x * num15;
      this.Y = -y * num15;
      this.Z = -z * num15;
      this.W = w * num15;
    }

    public static Quaternion Add(Quaternion left, Quaternion right) => new Quaternion()
    {
      X = left.X + right.X,
      Y = left.Y + right.Y,
      Z = left.Z + right.Z,
      W = left.W + right.W
    };

    public static Quaternion Divide(Quaternion left, Quaternion right) => new Quaternion()
    {
      X = left.X / right.X,
      Y = left.Y / right.Y,
      Z = left.Z / right.Z,
      W = left.W / right.W
    };

    public static float Dot(Quaternion left, Quaternion right) => (float) ((double) left.Y * (double) right.Y + (double) left.X * (double) right.X + (double) left.Z * (double) right.Z + (double) left.W * (double) right.W);

    public static Quaternion Lerp(Quaternion start, Quaternion end, float amount)
    {
      Quaternion quaternion = new Quaternion();
      float num1 = 1f - amount;
      float y1 = start.Y;
      float y2 = end.Y;
      float x1 = start.X;
      float x2 = end.X;
      float z1 = start.Z;
      float z2 = end.Z;
      float w1 = start.W;
      float w2 = end.W;
      if ((double) x2 * (double) x1 + (double) y2 * (double) y1 + (double) z2 * (double) z1 + (double) w2 * (double) w1 >= 0.0)
      {
        quaternion.X = (float) ((double) x1 * (double) num1 + (double) x2 * (double) amount);
        quaternion.Y = (float) ((double) y1 * (double) num1 + (double) y2 * (double) amount);
        quaternion.Z = (float) ((double) z1 * (double) num1 + (double) z2 * (double) amount);
        quaternion.W = (float) ((double) w1 * (double) num1 + (double) w2 * (double) amount);
      }
      else
      {
        quaternion.X = (float) ((double) x1 * (double) num1 - (double) x2 * (double) amount);
        quaternion.Y = (float) ((double) y1 * (double) num1 - (double) y2 * (double) amount);
        quaternion.Z = (float) ((double) z1 * (double) num1 - (double) z2 * (double) amount);
        quaternion.W = (float) ((double) w1 * (double) num1 - (double) w2 * (double) amount);
      }
      float num2 = 1f / quaternion.Length();
      quaternion.X *= num2;
      quaternion.Y *= num2;
      quaternion.Z *= num2;
      quaternion.W *= num2;
      return quaternion;
    }

    public static Quaternion Slerp(Quaternion start, Quaternion end, float amount)
    {
      Quaternion quaternion = new Quaternion();
      float num1 = Quaternion.Dot(start, end);
      float num2;
      float num3;
      if ((double) System.Math.Abs(num1) > 0.99999988079071)
      {
        num2 = 1f - amount;
        num3 = (float) System.Math.Sign(num1) * amount;
      }
      else
      {
        float num4 = (float) System.Math.Acos((double) System.Math.Abs(num1));
        float num5 = (float) (1.0 / System.Math.Sin((double) num4));
        num2 = (float) System.Math.Sin((1.0 - (double) amount) * (double) num4) * num5;
        double num6 = System.Math.Sin((double) num4 * (double) amount) * (double) num5;
        num3 = (float) System.Math.Sign(num1) * (float) num6;
      }
      quaternion.X = (float) ((double) end.X * (double) num3 + (double) start.X * (double) num2);
      quaternion.Y = (float) ((double) end.Y * (double) num3 + (double) start.Y * (double) num2);
      quaternion.Z = (float) ((double) end.Z * (double) num3 + (double) start.Z * (double) num2);
      quaternion.W = (float) ((double) end.W * (double) num3 + (double) start.W * (double) num2);
      return quaternion;
    }

    public static Quaternion SlerpUnclamped(Quaternion a, Quaternion b, float t)
    {
      if ((double) a.LengthSquared() == 0.0)
        return (double) b.LengthSquared() == 0.0 ? Quaternion.Identity : b;
      if ((double) b.LengthSquared() == 0.0)
        return a;
      Vector3 axis1 = b.Axis;
      double num1 = (double) Vector3.Dot(a.Axis, axis1);
      float num2 = (float) ((double) a.W * (double) b.W + num1);
      if ((double) num2 >= 1.0 || (double) num2 <= -1.0)
        return a;
      if ((double) num2 < 0.0)
      {
        b.X = -b.X;
        b.Y = -b.Y;
        b.Z = -b.Z;
        b.W = -b.W;
        num2 = -num2;
      }
      float num3;
      float num4;
      if ((double) num2 < 0.990000009536743)
      {
        float num5 = (float) System.Math.Acos((double) num2);
        float num6 = 1f / (float) System.Math.Sin((double) num5);
        num3 = (float) System.Math.Sin((1.0 - (double) t) * (double) num5) * num6;
        num4 = (float) System.Math.Sin((double) num5 * (double) t) * num6;
      }
      else
      {
        num3 = 1f - t;
        num4 = t;
      }
      Vector3 axis2 = b.Axis;
      Vector3 vector3 = num4 * axis2;
      Vector3 axis3 = a.Axis;
      Quaternion quaternion1 = new Quaternion(num3 * axis3 + vector3, (float) ((double) b.W * (double) num4 + (double) a.W * (double) num3));
      if ((double) quaternion1.LengthSquared() <= 0.0)
        return Quaternion.Identity;
      Quaternion quaternion2 = quaternion1;
      quaternion2.Normalize();
      return quaternion2;
    }

    public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
    {
      double num1 = (double) fromDirection.LengthSquared();
      float num2 = (float) System.Math.Sqrt((double) fromDirection.LengthSquared() * num1);
      float w = Vector3.Dot(fromDirection, toDirection) + num2;
      Quaternion quaternion1 = new Quaternion();
      Quaternion quaternion2;
      if ((double) w >= (double) num2 * 9.99999997475243E-07)
      {
        quaternion2 = new Quaternion(Vector3.Cross(fromDirection, toDirection), w);
      }
      else
      {
        Quaternion quaternion3;
        if ((double) System.Math.Abs(fromDirection.X) > (double) System.Math.Abs(fromDirection.Y))
        {
          float x = fromDirection.X;
          float num3 = -fromDirection.Z;
          Quaternion quaternion4;
          quaternion4.X = num3;
          quaternion4.Y = 0.0f;
          quaternion4.Z = x;
          quaternion4.W = 0.0f;
          quaternion3 = quaternion4;
        }
        else
        {
          float y = fromDirection.Y;
          float num3 = -fromDirection.Z;
          Quaternion quaternion4;
          quaternion4.X = 0.0f;
          quaternion4.Y = num3;
          quaternion4.Z = y;
          quaternion4.W = 0.0f;
          quaternion3 = quaternion4;
        }
        quaternion2 = quaternion3;
      }
      quaternion2.Normalize();
      return quaternion2;
    }

    public static Quaternion RotateTowards(
      Quaternion from,
      Quaternion to,
      float maxDegreesDelta)
    {
      float num = Quaternion.AngleBetween(from, to);
      if ((double) num == 0.0)
        return to;
      float t = System.Math.Min(1f, maxDegreesDelta / num);
      return Quaternion.SlerpUnclamped(from, to, t);
    }

    public static Quaternion Multiply(Quaternion quaternion, float scale) => new Quaternion()
    {
      X = quaternion.X * scale,
      Y = quaternion.Y * scale,
      Z = quaternion.Z * scale,
      W = quaternion.W * scale
    };

    public static Quaternion Multiply(Quaternion left, Quaternion right)
    {
      Quaternion quaternion = new Quaternion();
      float x1 = left.X;
      float y1 = left.Y;
      float z1 = left.Z;
      float w1 = left.W;
      float x2 = right.X;
      float y2 = right.Y;
      float z2 = right.Z;
      float w2 = right.W;
      quaternion.X = (float) ((double) x2 * (double) w1 + (double) w2 * (double) x1 + (double) z2 * (double) y1 - (double) y2 * (double) z1);
      quaternion.Y = (float) ((double) y2 * (double) w1 + (double) w2 * (double) y1 + (double) x2 * (double) z1 - (double) z2 * (double) x1);
      quaternion.Z = (float) ((double) z2 * (double) w1 + (double) w2 * (double) z1 + (double) y2 * (double) x1 - (double) x2 * (double) y1);
      quaternion.W = (float) ((double) w2 * (double) w1 - ((double) y2 * (double) y1 + (double) x2 * (double) x1 + (double) z2 * (double) z1));
      return quaternion;
    }

    public static Quaternion Negate(Quaternion quaternion) => new Quaternion()
    {
      X = -quaternion.X,
      Y = -quaternion.Y,
      Z = -quaternion.Z,
      W = -quaternion.W
    };

    public static float AngleBetween(Quaternion a, Quaternion b) => (float) (System.Math.Acos((double) System.Math.Min(System.Math.Abs(Quaternion.Dot(a, b)), 1f)) * 2.0 * (180.0 / System.Math.PI));

    public static Quaternion Euler(Vector3 euler)
    {
      Vector3 vector3 = euler * ((float) System.Math.PI / 180f);
      return Quaternion.RotationYawPitchRoll(vector3.X, vector3.Y, vector3.Z);
    }

    public static Quaternion Euler(float x, float y, float z) => Quaternion.RotationYawPitchRoll(x * ((float) System.Math.PI / 180f), y * ((float) System.Math.PI / 180f), z * ((float) System.Math.PI / 180f));

    public static Quaternion RotationAxis(Vector3 axis, float angle)
    {
      Quaternion quaternion = new Quaternion();
      axis = Vector3.Normalize(axis);
      double num1 = (double) (angle * 0.5f);
      float num2 = (float) System.Math.Sin(num1);
      quaternion.X = axis.X * num2;
      quaternion.Y = axis.Y * num2;
      quaternion.Z = axis.Z * num2;
      quaternion.W = (float) System.Math.Cos(num1);
      return quaternion;
    }

    public static Quaternion RotationMatrix(Matrix matrix)
    {
      Quaternion quaternion = new Quaternion();
      float m22 = matrix.M22;
      float m11 = matrix.M11;
      float m33 = matrix.M33;
      float num1 = m11 + m22 + m33;
      if ((double) num1 > 0.0)
      {
        float num2 = (float) System.Math.Sqrt((double) num1 + 1.0);
        quaternion.W = num2 * 0.5f;
        float num3 = 0.5f / num2;
        quaternion.X = (matrix.M23 - matrix.M32) * num3;
        quaternion.Y = (matrix.M31 - matrix.M13) * num3;
        quaternion.Z = (matrix.M12 - matrix.M21) * num3;
        return quaternion;
      }
      if ((double) m11 >= (double) m22 && (double) m11 >= (double) m33)
      {
        float num2 = (float) System.Math.Sqrt((double) m11 + 1.0 - (double) m22 - (double) m33);
        float num3 = 0.5f / num2;
        quaternion.X = num2 * 0.5f;
        quaternion.Y = (matrix.M21 + matrix.M12) * num3;
        quaternion.Z = (matrix.M13 + matrix.M31) * num3;
        quaternion.W = (matrix.M23 - matrix.M32) * num3;
        return quaternion;
      }
      if ((double) m22 > (double) m33)
      {
        float num2 = (float) System.Math.Sqrt((double) m22 + 1.0 - (double) m11 - (double) m33);
        float num3 = 0.5f / num2;
        quaternion.X = (matrix.M21 + matrix.M12) * num3;
        quaternion.Y = num2 * 0.5f;
        quaternion.Z = (matrix.M32 + matrix.M23) * num3;
        quaternion.W = (matrix.M31 - matrix.M13) * num3;
        return quaternion;
      }
      float num4 = (float) System.Math.Sqrt((double) m33 + 1.0 - (double) m11 - (double) m22);
      float num5 = 0.5f / num4;
      quaternion.X = (matrix.M13 + matrix.M31) * num5;
      quaternion.Y = (matrix.M32 + matrix.M23) * num5;
      quaternion.Z = num4 * 0.5f;
      quaternion.W = (matrix.M12 - matrix.M21) * num5;
      return quaternion;
    }

    public static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
    {
      Quaternion quaternion = new Quaternion();
      double num1 = (double) (roll * 0.5f);
      float num2 = (float) System.Math.Sin(num1);
      float num3 = (float) System.Math.Cos(num1);
      double num4 = (double) (pitch * 0.5f);
      float num5 = (float) System.Math.Sin(num4);
      float num6 = (float) System.Math.Cos(num4);
      double num7 = (double) (yaw * 0.5f);
      float num8 = (float) System.Math.Sin(num7);
      float num9 = (float) System.Math.Cos(num7);
      double num10 = (double) num9 * (double) num5;
      double num11 = (double) num8 * (double) num6;
      quaternion.X = (float) ((double) num2 * num11 + (double) num3 * num10);
      quaternion.Y = (float) ((double) num3 * num11 - (double) num2 * num10);
      double num12 = (double) num9 * (double) num6;
      double num13 = (double) num8 * (double) num5;
      quaternion.Z = (float) ((double) num2 * num12 - (double) num3 * num13);
      quaternion.W = (float) ((double) num2 * num13 + (double) num3 * num12);
      return quaternion;
    }

    public static Quaternion Subtract(Quaternion left, Quaternion right) => new Quaternion()
    {
      X = left.X - right.X,
      Y = left.Y - right.Y,
      Z = left.Z - right.Z,
      W = left.W - right.W
    };

    public static Quaternion operator *(float scale, Quaternion quaternion) => new Quaternion()
    {
      X = quaternion.X * scale,
      Y = quaternion.Y * scale,
      Z = quaternion.Z * scale,
      W = quaternion.W * scale
    };

    public static Quaternion operator *(Quaternion quaternion, float scale) => new Quaternion()
    {
      X = quaternion.X * scale,
      Y = quaternion.Y * scale,
      Z = quaternion.Z * scale,
      W = quaternion.W * scale
    };

    public static Vector3 operator *(Quaternion rotation, Vector3 point)
    {
      Vector3 left = new Vector3(rotation.X, rotation.Y, rotation.Z);
      Vector3 right = 2f * Vector3.Cross(left, point);
      Vector3 vector3_1 = Vector3.Cross(left, right);
      Vector3 vector3_2 = rotation.W * right;
      return point + vector3_2 + vector3_1;
    }

    public static Quaternion operator *(Quaternion left, Quaternion right)
    {
      Quaternion quaternion = new Quaternion();
      float x1 = left.X;
      float y1 = left.Y;
      float z1 = left.Z;
      float w1 = left.W;
      float x2 = right.X;
      float y2 = right.Y;
      float z2 = right.Z;
      float w2 = right.W;
      quaternion.X = (float) ((double) x2 * (double) w1 + (double) w2 * (double) x1 + (double) z2 * (double) y1 - (double) y2 * (double) z1);
      quaternion.Y = (float) ((double) y2 * (double) w1 + (double) w2 * (double) y1 + (double) x2 * (double) z1 - (double) z2 * (double) x1);
      quaternion.Z = (float) ((double) z2 * (double) w1 + (double) w2 * (double) z1 + (double) y2 * (double) x1 - (double) x2 * (double) y1);
      quaternion.W = (float) ((double) w2 * (double) w1 - ((double) y2 * (double) y1 + (double) x2 * (double) x1 + (double) z2 * (double) z1));
      return quaternion;
    }

    public static Quaternion operator /(Quaternion left, float right)
    {
      Quaternion quaternion = new Quaternion();
      float num = 1f / right;
      quaternion.X = left.X * num;
      quaternion.Y = left.Y * num;
      quaternion.Z = left.Z * num;
      quaternion.W = left.W * num;
      return quaternion;
    }

    public static Quaternion operator +(Quaternion left, Quaternion right) => new Quaternion()
    {
      X = left.X + right.X,
      Y = left.Y + right.Y,
      Z = left.Z + right.Z,
      W = left.W + right.W
    };

    public static Quaternion operator -(Quaternion quaternion) => new Quaternion()
    {
      X = -quaternion.X,
      Y = -quaternion.Y,
      Z = -quaternion.Z,
      W = -quaternion.W
    };

    public static Quaternion operator -(Quaternion left, Quaternion right) => new Quaternion()
    {
      X = left.X - right.X,
      Y = left.Y - right.Y,
      Z = left.Z - right.Z,
      W = left.W - right.W
    };

    public static bool operator ==(Quaternion left, Quaternion right) => Quaternion.Equals(ref left, ref right);

    public static bool operator !=(Quaternion left, Quaternion right) => !Quaternion.Equals(ref left, ref right);

    public override sealed string ToString()
    {
      object[] objArray = new object[4];
      float x = this.X;
      objArray[0] = (object) x.ToString();
      float y = this.Y;
      objArray[1] = (object) y.ToString();
      float z = this.Z;
      objArray[2] = (object) z.ToString();
      float w = this.W;
      objArray[3] = (object) w.ToString();
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "X:{0} Y:{1} Z:{2} W:{2}", objArray);
    }

    public override sealed int GetHashCode()
    {
      float x = this.X;
      float y = this.Y;
      float z = this.Z;
      float w = this.W;
      int num1 = z.GetHashCode() >> 2;
      int num2 = y.GetHashCode() << 2 ^ num1;
      int num3 = w.GetHashCode() ^ num2;
      return x.GetHashCode() ^ num3;
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public static bool Equals(ref Quaternion value1, ref Quaternion value2) => (double) value1.X == (double) value2.X && (double) value1.Y == (double) value2.Y && ((double) value1.Z == (double) value2.Z && (double) value1.W == (double) value2.W);

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Equals(Quaternion other) => (double) this.X == (double) other.X && (double) this.Y == (double) other.Y && ((double) this.Z == (double) other.Z && (double) this.W == (double) other.W);

    [return: MarshalAs(UnmanagedType.U1)]
    public override sealed bool Equals(object obj) => obj != null && !(obj.GetType() != this.GetType()) && this.Equals((Quaternion) obj);
  }
}
