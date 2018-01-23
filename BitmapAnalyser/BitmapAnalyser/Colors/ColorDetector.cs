using BitmapAnalyser.Results;
using System;
using Windows.Graphics.Imaging;
using Windows.UI;

namespace BitmapAnalyser.Colors
{
    public class ColorDetector : IDetector
    {
        public Color Color { get; set; }
        public double Delta { get; set; }
        public ColorDetector()
        {
            Color = Windows.UI.Colors.White;
            Delta = 100;
        }
        public unsafe IResult Detect(SoftwareBitmap image)
        {
            CounterResult result = new CounterResult()
            {
                Count = 0,
                Image = new SoftwareBitmap(image.BitmapPixelFormat, image.PixelWidth, image.PixelHeight)
            };

            image.CopyTo(result.Image);

            using (BitmapBuffer buffer = result.Image.LockBuffer(BitmapBufferAccessMode.Write))
            {
                using (var reference = buffer.CreateReference())
                {
                    ((IMemoryBufferByteAccess)reference).GetBuffer(out byte* dataInBytes, out uint capacity);

                    // Fill-in the BGRA plane
                    BitmapPlaneDescription bufferLayout = buffer.GetPlaneDescription(0);
                    for (int i = 0; i < bufferLayout.Height; i++)
                    {
                        for (int j = 0; j < bufferLayout.Width; j++)
                        {
                            int b = dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 0] - Color.B;
                            int g = dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 1] - Color.G;
                            int r = dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 2] - Color.R;

                            if (b * b + g * g + r * r < Delta * Delta)
                            {
                                result.Count ++;
                                dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 0] = 0;
                                dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 1] = 0;
                                dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 2] = 255;
                                dataInBytes[bufferLayout.StartIndex + bufferLayout.Stride * i + 4 * j + 3] = (byte)255;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
