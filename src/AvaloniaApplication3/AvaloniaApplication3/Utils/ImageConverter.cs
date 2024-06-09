using System;
using System.Runtime.InteropServices;
namespace AvaloniaApplication3.Utils;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Text;

using Avalonia.Media.Imaging;

using System.IO;

public class ImageConverter
{
    public static byte[] PreprocessImage(string imagePath)
    {
        // Load image
        // Console.WriteLine(imagePath);
        // console current directory
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            imagePath = imagePath.Replace("file:///", "");
        }
        else
        {
            imagePath = imagePath.Replace("file://", "");
        }
        
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
        
        // Save binary image
        CvInvoke.Imwrite("binary.BMP", binary);
        
        // Read all bytes from binary image
        byte[] binaryData = File.ReadAllBytes("binary.BMP");
        

        return binaryData;
    }
    
    //  black and white img path to binary string
    public static string ImgPathToString(string imagePath)
    {   

        byte[] binaryData = File.ReadAllBytes(imagePath);
        String encoding = Encoding.GetEncoding("iso-8859-1").GetString(binaryData);
        
        return encoding;
    }
}