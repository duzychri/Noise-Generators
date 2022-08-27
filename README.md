# Noise-Generators
A white, value and perlin noise generator written in pure C#.

## How to use

To use the generator initialize it with some seed (and for perlin and white noise also the cell counts).
Then call the generate noise method either with one or two dimensional inputs in the range [0, 1] to get the values for your texture.

```csharp
const int width = 512;
var pixels = new double[width];
var generator = new PerlinNoiseGenerator(18493.29312, CellCount, CellCount);
for (int x = 0; x < width; x++)
{
    double position = (double)x / width;
    pixels[x] = generator.GenerateNoise(position);
}
```

The **GeneratorHelper** class can also be used as a shortcut to accomplish the same thing.


```csharp
const int width = 512;
var generator = new PerlinNoiseGenerator(18493.29312, CellCount, CellCount);
var pixels = GeneratorHelper.GenerateFloatTexture(generator, width);
```