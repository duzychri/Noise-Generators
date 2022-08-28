namespace Noise_Generators;

internal class RandomNumberGenerator
{
    public double Seed { get; set; }

    private readonly double floatMutator;
    private readonly double2 float2Mutator;

    public RandomNumberGenerator(double seed)
    {
        Seed = seed;
        floatMutator = GetInternalRandomDouble(seed, 96456.34365f, -99999.99999f, 99999.99999f) + 76875.50835f;
        float2Mutator = new double2(
            GetInternalRandomDouble(seed, 16745.93698f, -99999.99999f, 99999.99999f),
            GetInternalRandomDouble(seed, 45678.73415f, -99999.99999f, 99999.99999f))
            + new double2(26059.89236f, 37069.34521f);
    }

    #region Random Methods

    public double GetRandomDouble(double value)
    {
        return GetInternalRandomDouble(value, floatMutator, 0f, 1f);
    }

    public double GetRandomDouble(double value, double min, double max)
    {
        return GetInternalRandomDouble(value, floatMutator, min, max);
    }

    public double GetRandomDouble(double2 position)
    {
        return GetInternalRandomDouble(position, float2Mutator, 0f, 1f);
    }

    public double GetRandomDouble(double2 position, double min, double max)
    {
        return GetInternalRandomDouble(position, float2Mutator, min, max);
    }

    #endregion Random Methods

    #region Double2 Methods

    public double2 GetRandomDouble2(double position)
    {
        return new double2(
            GetInternalRandomDouble(position, floatMutator + 13451.33546f, 0f, 1f),
            GetInternalRandomDouble(position, floatMutator + 72348.98529f, 0f, 1f)
        );
    }

    public double2 GetRandomDouble2(double position, double min, double max)
    {
        return new double2(
            GetInternalRandomDouble(position, floatMutator + 26882.13293f, min, max),
            GetInternalRandomDouble(position, floatMutator + 34648.18354f, min, max)
        );
    }

    public double2 GetRandomDouble2(double2 position)
    {
        return new double2(
            GetInternalRandomDouble(position, float2Mutator + new double2(342351.13835f, 33459.34866f), 0f, 1f),
            GetInternalRandomDouble(position, float2Mutator + new double2(723458.23873f, 23553.92489f), 0f, 1f)
        );
    }

    public double2 GetRandomDouble2(double2 position, double2 min, double2 max)
    {
        return new double2(
            GetInternalRandomDouble(position, float2Mutator + new double2(10623.98909f, 78634.23373f), min.x, max.x),
            GetInternalRandomDouble(position, float2Mutator + new double2(32379.33946f, 82344.14535f), min.y, max.y)
        );
    }

    #endregion Double2 Methods

    #region Utility Methods

    private double GetInternalRandomDouble(double value, double mutator, double min, double max)
    {
        //// Make value smaller incase of overflows.
        //value = Sin(value);
        if (value == 0)
        { value += 96351.12723f; }
        // Randomize value based on mutator.
        value = Fract(Sin(value * mutator) * 16131.75663f);
        // Make sure the value is not negative.
        value = Abs(value);
        // Clamp value to the min and max.
        value = value * (max - min) + min;
        // Return value.
        return value;
    }

    private double GetInternalRandomDouble(double2 value, double2 mutator, double min, double max)
    {
        //// Make value smaller incase of overflows.
        //value = Sin(value);
        // Add value incase of 0 value.
        if (value.x == 0 && value.y == 0)
        { value += new double2(68454.68835f, 33749.34356f); }
        // Randomize value based on mutator.
        double random = Dot(value, mutator);
        random = Sin(random);
        random = random * 9761.8642f;
        random = Fract(random);
        // Make sure the value is not negative.
        random = Abs(random);
        // Clamp value to the min and max.
        random = random * (max - min) + min;
        // Return value.
        return random;
    }

    private double GetInternalRandomDouble(double3 value, double3 mutator, double min, double max)
    {
        //// Make value smaller incase of overflows.
        //value = Sin(value);
        // Add value incase of 0 value.
        if (value.x == 0 && value.y == 0 && value.z == 0)
        { value += new double3(68454.33749f, 68835.34356f, 34356.33749f); }
        // Randomize value based on mutator.
        double random = Fract(Sin(Dot(value, mutator)) * 5824.98761f);
        // Make sure the value is not negative.
        random = Abs(random);
        // Clamp value to the min and max.
        random = random * (max - min) + min;
        // Return value.
        return random;
    }

    #endregion Utility Methods
}
