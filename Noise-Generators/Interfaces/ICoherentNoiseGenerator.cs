namespace Noise_Generators;

/// <summary>
/// Defines a generator for coherent noise.
/// </summary>
public interface ICoherentNoiseGenerator
{
    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <returns>The noise at the specified <paramref name="position"/>.</returns>
    double GenerateCoherentNoise(double position, double frequency);

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the x-axis to get the noise at.</param>
    /// <returns>The noise at the specified position.</returns>
    double GenerateCoherentNoise(double positionX, double positionY, double frequencyX, double frequencyY);
}