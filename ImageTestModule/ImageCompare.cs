using OpenCvSharp;
using CvSize = OpenCvSharp.Size;

namespace ImageTestModule;

public static class ImageCompare
{
    public static Mat GrayScale(Mat img)
    {
        if (img.Channels() == 1) return img.Clone();
        Mat ret = new();
        Cv2.CvtColor(img, ret, ColorConversionCodes.BGR2GRAY);
        return ret;
    }

    public static Mat ConvertTo(Mat img, MatType? type = null, double alpha = 1, double beta = 0)
    {
        Mat ret = new();
        img.ConvertTo(ret, type ?? MatType.CV_32F, alpha, beta);
        return ret;
    }

    public static Mat GaussianBlur(Mat img, int ksize = 11, double sigmaX = 1.5)
    {
        Mat ret = new();
        Cv2.GaussianBlur(img, ret, new CvSize(ksize, ksize), sigmaX);
        return ret;
    }

    public static Mat BilateralFilter(Mat img, int d = 5, double sigmaColor = 25, double sigmaSpace = 25)
    {
        Mat ret = new();
        Cv2.BilateralFilter(img, ret, d, sigmaColor, sigmaSpace);
        return ret;
    }

    public static double Run(Mat img1, Mat img2)
    {
        return RunAsync(img1, img2).Result;
    }

    public static Task<double> RunAsync(Mat img1, Mat img2, CancellationToken token = default)
    {
        return SSIM(img1, img2, token);
    }

    private static Task<double> SSIM(Mat img1, Mat img2, CancellationToken token = default)
    {
        return Task.Run(() =>
        {
            if (img1.Empty() || img2.Empty())
            {
                throw new ArgumentException("image is empty");
            }
            if (img1.Size() != img2.Size())
            {
                throw new ArgumentException("image size must be same");
            }

            // gray-scale
            Mat img1Gray = img1.ToGrayScale().ToFloat32();
            Mat img2Gray = img2.ToGrayScale().ToFloat32();

            // calculate mean & sigma
            Mat mu1 = img1Gray.GaussianBlur();
            Mat mu2 = img2Gray.GaussianBlur();
            Mat mu1Sq = mu1.Pow(2);
            Mat mu2Sq = mu2.Pow(2);
            Mat mu1mu2 = mu1.Mul(mu2);

            Mat sigma1Sq = img1Gray.Pow(2).GaussianBlur() - mu1Sq;
            Mat sigma2Sq = img2Gray.Pow(2).GaussianBlur() - mu2Sq;
            Mat sigma12 = GaussianBlur(img1Gray.Mul(img2Gray)) - mu1mu2;

            // calculate SSIM
            /** [SSIM Fomula]
             *              (2 * mu1mu2 + C1)  *  (2 * sigma12 + C2)
             * SSIM  =  -----------------------------------------------------
             *           (mu1Sq + mu2Sq + C1)  *  (sigma1Sq + sigma2Sq + C2)
             */
            const double k1 = 0.01;
            const double k2 = 0.03;
            double C1 = Math.Pow(k1 * (Math.Pow(2, 8) - 1), 2);
            double C2 = Math.Pow(k2 * (Math.Pow(2, 8) - 1), 2);
            Mat t1 = mu1mu2.Mul(2) + Scalar.All(C1);
            Mat t2 = sigma12.Mul(2) + Scalar.All(C2);
            Mat t3 = mu1Sq + mu2Sq + Scalar.All(C1);
            Mat t4 = sigma1Sq + sigma2Sq + Scalar.All(C2);

            Mat ssimMap = new();
            Cv2.Divide(t1.Mul(t2), t3.Mul(t4), ssimMap);
            var score = ssimMap.Mean();
            return score.Val0;
        }, token);
    }
}
