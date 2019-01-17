using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Watermarker.Utility;
using System.IO;

namespace Watermarker
{
    class Program
    {
        private static string watermarkText = "";

        /*static Dictionary<string, string> arguments = new Dictionary<string, string>();
        static string inputPath;
        static string outputPath = "ProcessedImages";
        static bool textBackgroundTransparent;
        static Color textBackgroundColor;
        static Color textColor;
        static Font textFont = new Font(FontFamily.GenericSansSerif, 100.0f);
        static float watermarkAngle;
        static Point textPosition;
        static string watermarkText = "";
        // -i for input file/directory
        // -o to specify the output directory, default is "ProcessedImages"
        // -t to specify text background transparent or not
        // -b to specify background color
        // -c to specify text color, default is white
        // -f to specify font family
        // -s to specify font size
        // -r to specify rotation
        // -p to specify text position
        // */

        static void Main(string[] args)
        {
            if (args.Length < 1)
                return;

            //for (int i = 0; i < args.Length; i++)
            //{
            //    if (!args[i].StartsWith("-"))
            //        continue;
            //    arguments[args[i]] = args[i + 1];
            //    i++;
            //}

            if(args.Length > 1)
                watermarkText = args.Last();

            var dirCount = 0;
            var dirName = "ProcessedImages";
            while (Directory.Exists(dirName))
                dirName = "ProcessedImages" + dirCount++;

            Directory.CreateDirectory(dirName);

            var path = args[0];
            if (!File.Exists(path) && !Directory.Exists(path))
                throw new Exception("Invalid path specified.");

            if (File.Exists(path))
            {
                WatermarkAndSave(path, $"{dirName}\\{path.Split('\\').Last()}");
            }
            else
            {
                int counter = 0;
                var files = Directory.GetFiles(path);
                foreach (var image in files)
                {
                    WatermarkAndSave(image, $"{dirName}\\{image.Split('\\').Last()}.png");
                    Console.WriteLine($"Saved {dirName}\\{image.Split('\\').Last()}.png {counter++}/{files.Length}");
                }
            }

        }

        static void WatermarkAndSave(string imagePath, string saveName)
        {
            var source = Image.FromFile(imagePath);

            Image watermark = null;
            watermark = generateRandomTextImage((rand.Next() & 1) == 1);
            WatermarkGenerator.AddWatermark(source, watermark, new Point(rand.Next(0, source.Width - watermark.Height), rand.Next(0, source.Height - watermark.Height)), false);
            source.Save(saveName);
            source.Dispose();
            watermark.Dispose();
        }

        static Image generateRandomTextImage(bool bgcolor)
        {
            Font font = getRandFont();
            float scale = getRandScale();
            float angle = getRandRotation();
            string waterText = watermarkText;
            if (watermarkText == "")
                waterText = getRandText();
            var img = ImageTextGenerator.Generate(waterText, font, Color.FromArgb(getRandTransparency(), 255, 255, 255), bgcolor ? getRandColor() : Color.Transparent);
            img = ImageManipulator.Resize(img, scale);
            img = ImageManipulator.Rotate(img, angle);
            return img;
        }

    }
}
