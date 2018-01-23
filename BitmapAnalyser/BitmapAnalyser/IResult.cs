using Windows.Graphics.Imaging;

namespace BitmapAnalyser
{
    public interface IResult
    {
        SoftwareBitmap Image { get; set; }
    }
}
