using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarker
{
    class Utility
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static Font[] fontArr = new Font[] { new Font(FontFamily.GenericMonospace, 100.0f), new Font(FontFamily.GenericSansSerif, 100.0f), new Font(FontFamily.GenericSerif, 100.0f) };
        static float minAngle = -15.0f, maxAngle = 15.0f;
        static int minTrans = 30, maxTrans = 70;
        static int minScale = 10, maxScale = 100;
        public static Random rand = new Random();


        public static string getRandText()
        {
            var length = rand.Next(4, 10);
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        public static Font getRandFont()
        {
            return fontArr[rand.Next(0, 3)];
        }

        public static float getRandRotation()
        {
            return rand.Next((int)minAngle, (int)maxAngle);
        }

        public static float getRandScale()
        {
            return rand.Next(minScale, maxScale) / 100.0f;
        }

        public static int getRandTransparency()
        {
            return 255 * rand.Next(minTrans, maxTrans) / 100;
        }

        public static Color getRandColor()
        {
            return Color.FromArgb(getRandTransparency(), rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
        }
    }
}
