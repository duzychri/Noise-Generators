namespace Noise_Generators;

internal static class MathHelper
{
    #region InverseLerp

    public static float InverseLerp(float a, float b, float v) => (v - a) / (b - a);
    public static float2 InverseLerp(float2 a, float2 b, float t) => new float2(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t));
    public static float3 InverseLerp(float3 a, float3 b, float t) => new float3(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t), InverseLerp(a.z, b.z, t));

    public static double InverseLerp(double a, double b, double v) => (v - a) / (b - a);
    public static double2 InverseLerp(double2 a, double2 b, float t) => new double2(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t));
    public static double3 InverseLerp(double3 a, double3 b, float t) => new double3(InverseLerp(a.x, b.x, t), InverseLerp(a.y, b.y, t), InverseLerp(a.z, b.z, t));

    #endregion InverseLerp

    #region Lerp

    public static float Lerp(float a, float b, float t) => a * (1 - t) + b * t;
    public static float2 Lerp(float2 a, float2 b, float t) => new float2(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t));
    public static float3 Lerp(float3 a, float3 b, float t) => new float3(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t));

    public static double Lerp(double a, double b, double t) => a * (1 - t) + b * t;
    public static double2 Lerp(double2 a, double2 b, float t) => new double2(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t));
    public static double3 Lerp(double3 a, double3 b, float t) => new double3(Lerp(a.x, b.x, t), Lerp(a.y, b.y, t), Lerp(a.z, b.z, t));

    #endregion Lerp

    #region Ease

    public static float Ease(float v) => ((6 * v - 15) * v + 10) * v * v * v;
    public static float2 Ease(float2 a) => new float2(Ease(a.x), Ease(a.y));
    public static float3 Ease(float3 a) => new float3(Ease(a.x), Ease(a.y), Ease(a.z));

    public static double Ease(double v) => ((6 * v - 15) * v + 10) * v * v * v;
    public static double2 Ease(double2 a) => new double2(Ease(a.x), Ease(a.y));
    public static double3 Ease(double3 a) => new double3(Ease(a.x), Ease(a.y), Ease(a.z));

    #endregion Ease

    #region Sin

    public static float Sin(float value) => MathF.Sin(value);
    public static float2 Sin(float2 value) => new float2(Sin(value.x), Sin(value.y));
    public static float3 Sin(float3 value) => new float3(Sin(value.x), Sin(value.y), Sin(value.z));

    public static double Sin(double value) => Math.Sin(value);
    public static double2 Sin(double2 value) => new double2(Sin(value.x), Sin(value.y));
    public static double3 Sin(double3 value) => new double3(Sin(value.x), Sin(value.y), Sin(value.z));

    #endregion Sin

    #region Abs

    public static float Abs(float value) => MathF.Abs(value);
    public static float2 Abs(float2 value) => new float2(Abs(value.x), Abs(value.y));
    public static float3 Abs(float3 value) => new float3(Abs(value.x), Abs(value.y), Abs(value.z));

    public static double Abs(double value) => Math.Abs(value);
    public static double2 Abs(double2 value) => new double2(Abs(value.x), Abs(value.y));
    public static double3 Abs(double3 value) => new double3(Abs(value.x), Abs(value.y), Abs(value.z));

    #endregion Abs

    #region Dot

    public static float Dot(float2 a, float2 b) => a.x * b.x + a.y * b.y;
    public static float Dot(float3 a, float3 b) => a.x * b.x + a.y * b.y + a.z * a.z;

    public static double Dot(double2 a, double2 b) => a.x * b.x + a.y * b.y;
    public static double Dot(double3 a, double3 b) => a.x * b.x + a.y * b.y + a.z * a.z;

    #endregion Dot

    #region Ceil

    public static float Ceil(float value) => MathF.Ceiling(value);
    public static float2 Ceil(float2 value) => new float2(Ceil(value.x), Ceil(value.y));
    public static float3 Ceil(float3 value) => new float3(Ceil(value.x), Ceil(value.y), Ceil(value.z));

    public static double Ceil(double value) => Math.Ceiling(value);
    public static double2 Ceil(double2 value) => new double2(Ceil(value.x), Ceil(value.y));
    public static double3 Ceil(double3 value) => new double3(Ceil(value.x), Ceil(value.y), Ceil(value.z));

    #endregion Ceil

    #region Floor

    public static float Floor(float value) => MathF.Floor(value);
    public static float2 Floor(float2 value) => new float2(Floor(value.x), Floor(value.y));
    public static float3 Floor(float3 value) => new float3(Floor(value.x), Floor(value.y), Floor(value.z));

    public static double Floor(double value) => Math.Floor(value);
    public static double2 Floor(double2 value) => new double2(Floor(value.x), Floor(value.y));
    public static double3 Floor(double3 value) => new double3(Floor(value.x), Floor(value.y), Floor(value.z));

    #endregion Floor

    #region Fract

    public static float Fract(float value) => value - MathF.Truncate(value);
    public static float2 Fract(float2 value) => new float2(Fract(value.x), Fract(value.y));
    public static float3 Fract(float3 value) => new float3(Fract(value.x), Fract(value.y), Fract(value.z));

    public static double Fract(double value) => value - Math.Truncate(value);
    public static double2 Fract(double2 value) => new double2(Fract(value.x), Fract(value.y));
    public static double3 Fract(double3 value) => new double3(Fract(value.x), Fract(value.y), Fract(value.z));

    #endregion Fract
}
