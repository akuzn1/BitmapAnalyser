using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace BitmapAnalyser
{
    public class ColorDetector
    {
        public double Tolerance { get; set; }
        public DetectionMode DetectionMode { get; set; }
        public Color DetectionColor { get; set; }
    }
}
