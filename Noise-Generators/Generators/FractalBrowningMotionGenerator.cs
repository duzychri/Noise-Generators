namespace Noise_Generators;

/// <summary>
/// Settings for the <see cref="FractalBrowningMotionGenerator"/>.
/// </summary>
public struct FractalBrowningMotionSettings
{
    /// <summary>
    /// The amount of octaves that the generator should take.
    /// </summary>
    public int Octaves { get; set; }
    /// <summary>
    /// The amount by which the frequency should be multiplied in each octave.
    /// </summary>
    public double Lacunarity { get; set; }
    /// <summary>
    /// The amount by which the amplitude should be multiplied in each octave.
    /// </summary>
    public double Gain { get; set; }

    /// <summary>
    /// The inital frequency or 'cell count'.
    /// </summary>
    public double InitalFrequency { get; set; }
    /// <summary>
    /// The inital amplitude or 'range of values'.
    /// </summary>
    public double InitalAmplitude { get; set; }
}

/// <summary>
/// A fractal Browning motion generator.
/// </summary>
public class FractalBrowningMotionGenerator : INoiseGenerator
{
    private readonly ICoherentNoiseGenerator noiseGenerator;
    private readonly FractalBrowningMotionSettings settings;

    /// <summary>
    /// Creates a new <see cref="FractalBrowningMotionGenerator"/>.
    /// </summary>
    /// <param name="noiseGenerator">The generator to use in the octaves of this generator.</param>
    /// <param name="settings">The settings to apply to the octaves.</param>
    public FractalBrowningMotionGenerator(ICoherentNoiseGenerator noiseGenerator, FractalBrowningMotionSettings settings)
    {
        this.noiseGenerator = noiseGenerator;
        this.settings = settings;
    }

    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <returns>The noise at the specified <paramref name="position"/>.</returns>
    public double GenerateNoise(double position)
    {
        double value = 0.0;
        double amplitude = settings.InitalAmplitude;
        double frequency = settings.InitalFrequency;

        for (int n = 0; n < settings.Octaves; n++)
        {
            value += Lerp(-amplitude, +amplitude, noiseGenerator.GenerateCoherentNoise(position, frequency));
            frequency *= settings.Lacunarity;
            amplitude *= settings.Gain;
        }

        return value;
    }

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the y-axis to get the noise at.</param>
    /// <returns>The noise at the specified position.</returns>
    public double GenerateNoise(double positionX, double positionY)
    {
        double value = 0.0;
        double amplitude = settings.InitalAmplitude;
        double frequency = settings.InitalFrequency;

        for (int n = 0; n < settings.Octaves; n++)
        {
            value += Lerp(-amplitude, +amplitude, noiseGenerator.GenerateCoherentNoise(positionX, positionY, frequency, frequency));
            frequency *= settings.Lacunarity;
            amplitude *= settings.Gain;
        }

        return value;
    }
}