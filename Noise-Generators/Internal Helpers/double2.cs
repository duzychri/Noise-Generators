#pragma warning disable IDE1006 // Naming Styles
namespace Noise_Generators;

[DebuggerDisplay("({x}, {y})")]
internal struct double2 : IEquatable<double2>
{
    public double x;
    public double y;

    public double2() : this(0, 0)
    { }

    public double2(double v) : this(v, v)
    { }

    public double2(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString() => $"({x}, {y})";

    #region Operators

    public static double2 operator +(double2 left, double2 right) => new double2(left.x + right.x, left.y + right.y);
    public static double2 operator -(double2 left, double2 right) => new double2(left.x - right.x, left.y - right.y);
    public static double2 operator *(double2 left, double2 right) => new double2(left.x * right.x, left.y * right.y);

    #endregion Operators

    #region IEquatable

    public bool Equals(double2 other) => x == other.x && y == other.y;
    public override bool Equals(object other) => other is double2 @float && Equals(@float);

    public static bool operator ==(double2 left, double2 right) => left.Equals(right);
    public static bool operator !=(double2 left, double2 right) => !left.Equals(right);

    public override int GetHashCode() => HashCode.Combine(x, y);

    #endregion IEquatable
}
