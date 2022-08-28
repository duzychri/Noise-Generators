namespace Noise_Generators;

/// <summary>
/// A helper for the creation of texture content using the noise generators.
/// </summary>
public static class GeneratorHelper
{
    /// <summary>
    /// Generates the content of a one-dimensional texture with the specified <paramref name="width"/>.
    /// </summary>
    /// <param name="generator">The generator to use.</param>
    /// <param name="width">The width of the texture content.</param>
    /// <param name="useParallel">Uses the <see cref="Parallel.For(int, int, Action{int})"/> method to parallelize the generation of pixel values.</param>
    /// <returns>The content of a one-dimensional texture.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="generator"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="width"/> is smaller or equal to 0.</exception>
    public static double[] GenerateDoubleTexture(INoiseGenerator generator, int width, bool useParallel = false)
    {
        if (generator is null) { throw new ArgumentNullException(nameof(generator)); }
        if (width <= 0) { throw new ArgumentException($"Parameter '{nameof(width)}' needs to be larger than 0.", nameof(width)); }

        double[] pixels = new double[width];

        if (useParallel)
        {
            Parallel.For(0, width, x =>
            {
                double position = (double)x / width;
                pixels[x] = generator.GenerateNoise(position);
            });
        }
        else
        {
            for (int x = 0; x < width; x++)
            {
                double position = (double)x / width;
                pixels[x] = generator.GenerateNoise(position);
            }
        }

        return pixels;
    }

    /// <summary>
    /// Generates the content of a two-dimensional texture with the specified <paramref name="width"/> and <paramref name="height"/>.
    /// </summary>
    /// <param name="generator">The generator to use.</param>
    /// <param name="width">The width of the texture content.</param>
    /// <param name="height">The height of the texture content.</param>
    /// <param name="useParallel">Uses the <see cref="Parallel.For(int, int, Action{int})"/> method to parallelize the generation of pixel values.</param>
    /// <returns>The content of a two-dimensional texture.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="generator"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="width"/> or <paramref name="width"/> is smaller or equal to 0.</exception>
    public static double[,] GenerateDoubleTexture(INoiseGenerator generator, int width, int height, bool useParallel = false)
    {
        if (generator is null) { throw new ArgumentNullException(nameof(generator)); }
        if (width <= 0) { throw new ArgumentException($"Parameter '{nameof(width)}' needs to be larger than 0.", nameof(width)); }
        if (height <= 0) { throw new ArgumentException($"Parameter '{nameof(height)}' needs to be larger than 0.", nameof(height)); }

        double[,] pixels = new double[width, height];

        if (useParallel)
        {
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    double2 position = new double2((float)x / width, (float)y / height);
                    pixels[x, y] = generator.GenerateNoise(position.x, position.y);
                }
            });
        }
        else
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double2 position = new double2((float)x / width, (float)y / height);
                    pixels[x, y] = generator.GenerateNoise(position.x, position.y);
                }
            }
        }

        return pixels;
    }

    /// <summary>
    /// Generates the content of a one-dimensional texture with the specified <paramref name="width"/>.
    /// </summary>
    /// <param name="generator">The generator to use.</param>
    /// <param name="width">The width of the texture content.</param>
    /// <param name="useParallel">Uses the <see cref="Parallel.For(int, int, Action{int})"/> method to parallelize the generation of pixel values.</param>
    /// <returns>The content of a one-dimensional texture.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="generator"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="width"/> is smaller or equal to 0.</exception>
    public static float[] GenerateFloatTexture(INoiseGenerator generator, int width, bool useParallel = false)
    {
        if (generator is null) { throw new ArgumentNullException(nameof(generator)); }
        if (width <= 0) { throw new ArgumentException($"Parameter '{nameof(width)}' needs to be larger than 0.", nameof(width)); }

        double[] doublePixels = GenerateDoubleTexture(generator, width, useParallel);
        float[] floatPixels = doublePixels.Select(p => (float)p).ToArray();

        return floatPixels;
    }

    /// <summary>
    /// Generates the content of a two-dimensional texture with the specified <paramref name="width"/> and <paramref name="height"/>.
    /// </summary>
    /// <param name="generator">The generator to use.</param>
    /// <param name="width">The width of the texture content.</param>
    /// <param name="height">The height of the texture content.</param>
    /// <param name="useParallel">Uses the <see cref="Parallel.For(int, int, Action{int})"/> method to parallelize the generation of pixel values.</param>
    /// <returns>The content of a two-dimensional texture.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="generator"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="width"/> or <paramref name="width"/> is smaller or equal to 0.</exception>
    public static float[,] GenerateFloatTexture(INoiseGenerator generator, int width, int height, bool useParallel = false)
    {
        if (generator is null) { throw new ArgumentNullException(nameof(generator)); }
        if (width <= 0) { throw new ArgumentException($"Parameter '{nameof(width)}' needs to be larger than 0.", nameof(width)); }
        if (height <= 0) { throw new ArgumentException($"Parameter '{nameof(height)}' needs to be larger than 0.", nameof(height)); }

        double[,] doublePixels = GenerateDoubleTexture(generator, width, height, useParallel);
        float[,] floatPixels = new float[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                floatPixels[x, y] = (float)doublePixels[x, y];
            }
        }

        return floatPixels;
    }
}
