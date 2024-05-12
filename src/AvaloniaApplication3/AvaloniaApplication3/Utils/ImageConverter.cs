using System.Runtime.InteropServices;
namespace AvaloniaApplication3.Utils;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

public class ImageConverter
{
    public static byte[] PreprocessImage(string imagePath)
    {
        // Load image
        Mat image = CvInvoke.Imread(imagePath);
        
        // Convert image to grayscale
        Mat gray = new Mat();
        CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

        // Resize to 96x103
        Mat resized = new Mat();
        CvInvoke.Resize(gray, resized, new Size(96, 103));

        // Convert to binary
        Mat binary = new Mat();
        CvInvoke.Threshold(resized, binary, 127, 255, ThresholdType.Binary);

        // Convert Mat to byte array
        byte[] imageData = new byte[binary.Width * binary.Height];
        Marshal.Copy(binary.DataPointer, imageData, 0, imageData.Length);

        return imageData;
    }
}