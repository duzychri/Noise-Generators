#pragma warning disable IDE1006 // Naming Styles
namespace Noise_Generators;

[DebuggerDisplay("({x}, {y})")]
internal struct float2 : IEquatable<float2>
{
    public float x;
    public float y;

    public float2() : this(0, 0)
    { }

    public float2(float v) : this(v, v)
    { }

    public float2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString() => $"({x}, {y})";

    #region Operators

    public static float2 operator +(float2 left, float2 right) => new float2(left.x + right.x, left.y + right.y);
    public static float2 operator -(float2 left, float2 right) => new float2(left.x - right.x, left.y - right.y);
    public static float2 operator *(float2 left, float2 right) => new float2(left.x * right.x, left.y * right.y);

    #endregion Operators

    #region IEquatable

    public bool Equals(float2 other) => x == other.x && y == other.y;
    public override bool Equals(object other) => other is float2 @float && Equals(@float);

    public static bool operator ==(float2 left, float2 right) => left.Equals(right);
    public static bool operator !=(float2 left, float2 right) => !left.Equals(right);

    public override int GetHashCode() => HashCode.Combine(x, y);

    #endregion IEquatable
}
