using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace BitmapAnalyser.Results
{
    public class CounterResult:IResult
    {
        public int Count { get; set; }
        public SoftwareBitmap Image { get; set; }
    }
}
