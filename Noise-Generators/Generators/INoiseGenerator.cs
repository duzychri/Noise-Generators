namespace Noise_Generators;

/// <summary>
/// Defines a generator for noise.
/// </summary>
public interface INoiseGenerator
{
    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <returns>The noise at the specified <paramref name="position"/>.</returns>
    double GenerateNoise(double position);

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the x-axis to get the noise at.</param>
    /// <returns>The noise at the specified position.</returns>
    double GenerateNoise(double positionX, double positionY);
}

