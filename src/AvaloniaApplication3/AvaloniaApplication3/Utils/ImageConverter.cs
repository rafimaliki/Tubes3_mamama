using System;

namespace AvaloniaApplication3.Utils;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;


public class ImageConverter
{
    public static byte[] PreprocessImage(string imagePath)
    {
        string path = imagePath.Replace("file:///", "");
        
        // Handle for macOS
        if (path[0] != '/' && Environment.OSVersion.Platform == PlatformID.Unix)
        {
            path = "/" + path;
        }
        // Load image
        Mat image = CvInvoke.Imread(path);
        
        // Convert image to grayscale
        Mat gray = new Mat();
        CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);

        // Resize to 96x103
        Mat resized = new Mat();
        CvInvoke.Resize(gray, resized, new Size(96, 103));

        // Convert to binary
        Mat binary = new Mat();
        CvInvoke.Threshold(resized, binary, 127, 255, ThresholdType.Binary);
        
        // Save the image
        CvInvoke.Imwrite("test.bmp", binary);
        
        // Convert the image to byte array
        byte[] imageData = System.IO.File.ReadAllBytes("test.bmp");
        
        // Delete the image
        System.IO.File.Delete("test.bmp");
        
        return imageData;
    }
}