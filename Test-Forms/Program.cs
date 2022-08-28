using Noise_Generators;

namespace Test_Forms
{
    internal static class Program
    {
        const int CellCount = 8;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            WhiteNoiseGenerator whiteNoiseGenerator = new WhiteNoiseGenerator(18493.29312f);
            //Open1dForm("White Noise", whiteNoiseGenerator);
            Open2dForm("White Noise", whiteNoiseGenerator);
            ValueNoiseGenerator valueNoiseGenerator = new ValueNoiseGenerator(18493.29312f, CellCount, CellCount);
            //Open1dForm("Value Noise", valueNoiseGenerator);
            Open2dForm("Value Noise", valueNoiseGenerator);
            PerlinNoiseGenerator perlinNoiseGenerator = new PerlinNoiseGenerator(18493.29312f, CellCount, CellCount);
            //Open1dForm("Perlin Noise", perlinNoiseGenerator);
            Open2dForm("Perlin Noise", perlinNoiseGenerator);
            FractalBrowningMotionSettings settings = new FractalBrowningMotionSettings
            {
                Octaves = 5,
                Lacunarity = 2.0,
                Gain = 0.5,

                InitalAmplitude = 0.5,
                InitalFrequency = 1.0,
            };
            FractalBrowningMotionGenerator fractalBrowningMotionGenerator = new FractalBrowningMotionGenerator(perlinNoiseGenerator, settings);
            //Open1dForm("FBM Noise", fractalBrowningMotionGenerator);
            Open2dForm("FBM Noise", fractalBrowningMotionGenerator);
        }

        private static void Open1dForm(string name, INoiseGenerator generator)
        {
            const int width = 512;
            float[] pixels = GeneratorHelper.GenerateFloatTexture(generator, width);

            Bitmap image = new Bitmap(width, 512);

            for (int y = 0; y < 512; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float pixel = pixels[x];
                    int pixelValue = (int)(pixel * 255);
                    Color color = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                    image.SetPixel(x, y, color);
                }
            }

            CreateFormWithImage(name, image);
        }

        private static void Open2dForm(string name, INoiseGenerator generator)
        {
            float[,] pixels = GeneratorHelper.GenerateFloatTexture(generator, 512, 512, false);
            Image image = PixelsToImage(pixels);
            CreateFormWithImage(name, image);
        }

        private static Bitmap PixelsToImage(float[,] pixels)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            Bitmap bmp = new Bitmap(width, height);

            var max = AsEnumerable(pixels).Max();
            var min = AsEnumerable(pixels).Min();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double pixel = InverseLerp(min, max, pixels[x, y]);
                    int pixelValue = (int)(pixel * 255);
                    Color color = Color.FromArgb(pixelValue, pixelValue, pixelValue);
                    bmp.SetPixel(x, y, color);
                }
            }

            return bmp;
        }

        private static void CreateFormWithImage(string name, Image image)
        {
            Form form = new Form();
            form.Width = 525;
            form.Height = 550;
            form.Text = name;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            form.Controls.Add(pictureBox);
            pictureBox.Width = pictureBox.Height = 512;
            Application.Run(form);
        }

        private static IEnumerable<T> AsEnumerable<T>(T[,] source)
        {
            int width = source.GetLength(0);
            int height = source.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    yield return source[x, y];
                }
            }
        }

        private static double Lerp(double a, double b, double t) => a * (1 - t) + b * t;
        private static double InverseLerp(double a, double b, double v) => (v - a) / (b - a);
    }
}