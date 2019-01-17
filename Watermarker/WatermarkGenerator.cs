using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarker
{
    class WatermarkGenerator
    {
        public static void AddWatermark(Image source, Image watermark, Point pos, bool fill)
        {
            using (watermark)
            using (Graphics imageGraphics = Graphics.FromImage(source))
            using (Brush watermarkBrush = new TextureBrush(watermark))
            {
                if(fill)
                    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(0, 0), source.Size));
                else
                    imageGraphics.DrawImage(watermark, pos);
            }
        }
    }
}
