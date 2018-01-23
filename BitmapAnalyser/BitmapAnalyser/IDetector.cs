using Windows.Graphics.Imaging;

namespace BitmapAnalyser
{
    public interface IDetector
    {
        IResult Detect(SoftwareBitmap image);
    }
}
