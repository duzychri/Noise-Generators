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
            Open1dForm("White Noise", whiteNoiseGenerator);
            Open2dForm("White Noise", whiteNoiseGenerator);
            ValueNoiseGenerator valueNoiseGenerator = new ValueNoiseGenerator(18493.29312f, CellCount, CellCount);
            Open1dForm("Value Noise", valueNoiseGenerator);
            Open2dForm("Value Noise", valueNoiseGenerator);
            PerlinNoiseGenerator perlinNoiseGenerator = new PerlinNoiseGenerator(18493.29312f, CellCount, CellCount);
            Open1dForm("Perlin Noise", perlinNoiseGenerator);
            Open2dForm("Perlin Noise", perlinNoiseGenerator);
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
            float[,] pixels = GeneratorHelper.GenerateFloatTexture(generator, 512, 512);
            Image image = PixelsToImage(pixels);
            CreateFormWithImage(name, image);
        }

        private static Bitmap PixelsToImage(float[,] pixels)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float pixel = pixels[x, y];
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
    }
}