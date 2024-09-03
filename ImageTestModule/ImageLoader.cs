using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ImageTestModule;

public static class ImageLoader
{
    public static Mat Load(string path)
    {
        var finfo = new FileInfo(path);
        if (!finfo.Exists) throw new ArgumentException($"image not exists - {path}");
        return Cv2.ImRead(finfo.FullName);
    }

    public static Mat Load(Bitmap bitmap)
    {
        if (!OperatingSystem.IsWindows()) throw new NotSupportedException("this method only support windows");
        return BitmapConverter.ToMat(bitmap);
    }
}