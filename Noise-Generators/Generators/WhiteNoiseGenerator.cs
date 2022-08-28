namespace Noise_Generators;

/// <summary>
/// A white noise generator.
/// </summary>
public class WhiteNoiseGenerator : INoiseGenerator
{
    private readonly RandomNumberGenerator rng;

    /// <summary>
    /// Creates a new <see cref="WhiteNoiseGenerator"/>.
    /// </summary>
    /// <param name="seed">The seed to initialize the random number generator with.</param>
    public WhiteNoiseGenerator(double seed)
    {
        rng = new RandomNumberGenerator(seed);
    }

    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <returns>The noise at the specified position in the range [0, 1].</returns>
    public double GenerateNoise(double position)
    {
        return rng.GetRandomDouble(position);
    }

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the x-axis to get the noise at.</param>
    /// <returns>The noise at the specified position in the range [0, 1].</returns>
    public double GenerateNoise(double positionX, double positionY)
    {
        double2 position = new double2(positionX, positionY);
        return rng.GetRandomDouble(position);
    }
}
