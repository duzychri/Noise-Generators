namespace Noise_Generators;

/// <summary>
/// A perlin noise generator.
/// </summary>
public class PerlinNoiseGenerator : INoiseGenerator, ICoherentNoiseGenerator
{
    private readonly double maxSize1d;
    private readonly double maxSize2d;
    private readonly double2 cellCount;
    private readonly RandomNumberGenerator rng;

    /// <summary>
    /// Creates a new <see cref="PerlinNoiseGenerator"/>.
    /// </summary>
    /// <param name="seed">The seed to initialize the random number generator with.</param>
    /// <param name="cellCountX">The amount of cells on the x-axis.</param>
    /// <param name="cellCountY">The amount of cells on the y-axis.</param>
    public PerlinNoiseGenerator(double seed, double cellCountX, double cellCountY)
    {
        cellCount = new double2(cellCountX, cellCountY);
        rng = new RandomNumberGenerator(seed);

        // https://stackoverflow.com/questions/18261982/output-range-of-perlin-noise
        maxSize1d = Math.Sqrt(1) / 2f;
        maxSize2d = Math.Sqrt(2) / 2f;
    }

    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <returns>The noise at the specified <paramref name="position"/>.</returns>
    public double GenerateNoise(double position)
    {
        return GenerateCoherentNoise(position, cellCount.x);
    }

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the x-axis to get the noise at.</param>
    /// <returns>The noise at the specified position in the range [0, 1].</returns>
    public double GenerateNoise(double positionX, double positionY)
    {
        return GenerateCoherentNoise(positionX, positionY, cellCount.x, cellCount.y);
    }

    /// <summary>
    /// Generates the noise at the specified <paramref name="position"/>.
    /// </summary>
    /// <param name="position">The position to get the noise at.</param>
    /// <param name="frequency">The frequency or 'cell count'.</param>
    /// <returns>The noise at the specified <paramref name="position"/>.</returns>
    public double GenerateCoherentNoise(double position, double frequency)
    {
        position *= frequency;

        double cellIndex = Floor(position);
        double cellPosition = Fract(position);

        double leftCellIndex = cellIndex + 0;
        double rightCellIndex = cellIndex + 1;

        double leftCellValue = rng.GetRandomDouble(leftCellIndex, -1, 1);
        double rightCellValue = rng.GetRandomDouble(rightCellIndex, -1, 1);

        double leftCellLinePoint = leftCellValue * cellPosition;
        double rightCellLinePoint = rightCellValue * (cellPosition - 1);
        double value = Lerp(leftCellLinePoint, rightCellLinePoint, cellPosition);

        value = InverseLerp(-maxSize1d, +maxSize1d, value);
        return value;
    }

    /// <summary>
    /// Generates the noise at the specified position.
    /// </summary>
    /// <param name="positionX">The position on the x-axis to get the noise at.</param>
    /// <param name="positionY">The position on the y-axis to get the noise at.</param>
    /// <param name="frequencyX">The frequency or 'cell count' in the x-axis.</param>
    /// <param name="frequencyY">The frequency or 'cell count' in the y-axis.</param>
    /// <returns>The noise at the specified position.</returns>
    public double GenerateCoherentNoise(double positionX, double positionY, double frequencyX, double frequencyY)
    {
        double2 position = new double2(positionX, positionY);
        position *= new double2(frequencyX, frequencyY);

        double2 cellIndex = Floor(position);
        double2 cellPosition = Fract(position);

        double2 topLeftCellIndex = cellIndex + new double2(0, 1);
        double2 topRightCellIndex = cellIndex + new double2(1, 1);
        double2 bottomLeftCellIndex = cellIndex + new double2(0, 0);
        double2 bottomRightCellIndex = cellIndex + new double2(1, 0);

        double2 topLeftCellDirection = rng.GetRandomDouble2(topLeftCellIndex, new double2(-1, -1), new double2(1, 1));
        double2 topRightCellDirection = rng.GetRandomDouble2(topRightCellIndex, new double2(-1, -1), new double2(1, 1));
        double2 bottomLeftCellDirection = rng.GetRandomDouble2(bottomLeftCellIndex, new double2(-1, -1), new double2(1, 1));
        double2 bottomRightCellDirection = rng.GetRandomDouble2(bottomRightCellIndex, new double2(-1, -1), new double2(1, 1));

        double topLeftCellValue = Dot(topLeftCellDirection, cellPosition - new double2(0, 1));
        double topRightCellValue = Dot(topRightCellDirection, cellPosition - new double2(1, 1));
        double bottomLeftCellValue = Dot(bottomLeftCellDirection, cellPosition - new double2(0, 0));
        double bottomRightCellValue = Dot(bottomRightCellDirection, cellPosition - new double2(1, 0));

        double interpolatorX = Ease(cellPosition.x);
        double interpolatorY = Ease(cellPosition.y);

        double topValue = Lerp(topLeftCellValue, topRightCellValue, interpolatorX);
        double bottomValue = Lerp(bottomLeftCellValue, bottomRightCellValue, interpolatorX);
        double value = Lerp(bottomValue, topValue, interpolatorY);

        value = InverseLerp(-maxSize2d, +maxSize2d, value);
        return value;
    }
}

