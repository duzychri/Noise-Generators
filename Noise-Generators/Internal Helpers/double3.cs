#pragma warning disable IDE1006 // Naming Styles
namespace Noise_Generators;

[DebuggerDisplay("({x}, {y}, {z})")]
internal struct double3 : IEquatable<double3>
{
    public double x;
    public double y;
    public double z;

    public double3() : this(0, 0, 0)
    { }

    public double3(double v) : this(v, v, v)
    { }

    public double3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString() => $"({x}, {y}, {z})";

    #region Operators

    public static double3 operator +(double3 left, double3 right) => new double3(left.x + right.x, left.y + right.y, left.y + right.y);
    public static double3 operator -(double3 left, double3 right) => new double3(left.x - right.x, left.y - right.y, left.y - right.y);
    public static double3 operator *(double3 left, double3 right) => new double3(left.x * right.x, left.y * right.y, left.y * right.y);

    #endregion Operators

    #region IEquatable

    public bool Equals(double3 other) => x == other.x && y == other.y && z == other.z;
    public override bool Equals(object other) => other is double3 @float && Equals(@float);

    public static bool operator ==(double3 left, double3 right) => left.Equals(right);
    public static bool operator !=(double3 left, double3 right) => !left.Equals(right);

    public override int GetHashCode() => HashCode.Combine(x, y, z);

    #endregion IEquatable
}
