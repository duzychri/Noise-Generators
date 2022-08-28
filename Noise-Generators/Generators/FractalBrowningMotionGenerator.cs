namespace Noise_Generators;

public struct FractalBrowningMotionSettings
{
    public int Octaves { get; set; }
    public double Lacunarity { get; set; }
    public double Gain { get; set; }

    public double InitalAmplitude { get; set; }
    public double InitalFrequency { get; set; }
}

public class FractalBrowningMotionGenerator : INoiseGenerator
{
    private readonly ICoherentNoiseGenerator noiseGenerator;
    private readonly FractalBrowningMotionSettings settings;

    public FractalBrowningMotionGenerator(ICoherentNoiseGenerator noiseGenerator, FractalBrowningMotionSettings settings)
    {
        this.noiseGenerator = noiseGenerator;
        this.settings = settings;
    }

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