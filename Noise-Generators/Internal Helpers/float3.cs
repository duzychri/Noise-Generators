#pragma warning disable IDE1006 // Naming Styles
namespace Noise_Generators;

[DebuggerDisplay("({x}, {y}, {z})")]
internal struct float3 : IEquatable<float3>
{
    public float x;
    public float y;
    public float z;

    public float3() : this(0, 0, 0)
    { }

    public float3(float v) : this(v, v, v)
    { }

    public float3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString() => $"({x}, {y}, {z})";

    #region Operators

    public static float3 operator +(float3 left, float3 right) => new float3(left.x + right.x, left.y + right.y, left.y + right.y);
    public static float3 operator -(float3 left, float3 right) => new float3(left.x - right.x, left.y - right.y, left.y - right.y);
    public static float3 operator *(float3 left, float3 right) => new float3(left.x * right.x, left.y * right.y, left.y * right.y);

    #endregion Operators

    #region IEquatable

    public bool Equals(float3 other) => x == other.x && y == other.y && z == other.z;
    public override bool Equals(object other) => other is float3 @float && Equals(@float);

    public static bool operator ==(float3 left, float3 right) => left.Equals(right);
    public static bool operator !=(float3 left, float3 right) => !left.Equals(right);

    public override int GetHashCode() => HashCode.Combine(x, y, z);

    #endregion IEquatable
}
