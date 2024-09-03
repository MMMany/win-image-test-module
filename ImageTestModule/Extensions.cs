using OpenCvSharp;
using CvSize = OpenCvSharp.Size;

namespace ImageTestModule;

public static class Extensions
{
    public static Mat ToFloat32(this Mat img)
    {
        Mat ret = new();
        img.ConvertTo(ret, MatType.CV_32F);
        return ret;
    }

    public static Mat Resize(this Mat img, CvSize size)
    {
        Mat ret = new();
        Cv2.Resize(img, ret, size, interpolation: InterpolationFlags.Linear);
        return ret;
    }

    public static Mat ToGrayScale(this Mat img)
    {
        if (img.Channels() == 1) return img.Clone();
        Mat ret = new();
        Cv2.CvtColor(img, ret, ColorConversionCodes.BGR2GRAY);
        return ret;
    }

    public static Mat GaussianBlur(this Mat img, int ksize = 11, double sigmaX = 1.5)
    {
        Mat ret = new();
        Cv2.GaussianBlur(img, ret, new CvSize(ksize, ksize), sigmaX);
        return ret;
    }

    public static Mat BilateralFilter(this Mat img, int d = 5, double sigmaColor = 25, double sigmaSpace = 25)
    {
        Mat ret = new();
        Cv2.BilateralFilter(img, ret, d, sigmaColor, sigmaSpace);
        return ret;
    }
}