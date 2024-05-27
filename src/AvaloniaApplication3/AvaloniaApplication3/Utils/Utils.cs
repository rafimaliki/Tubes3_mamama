using System;
using System.Text;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication3.Utils;
using System.IO;

public class Utils
{
    public static byte[] ConvertToBinary(string filePath)
    {
        string path = filePath.Replace("file:///", "");

        // if (path[0] != '/')
        // {
        //     path = "/" + path;
        // }

        byte[] b = File.ReadAllBytes(path);

        return b;
    }
    
    public static Bitmap ConvertToBitmap(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            return new Bitmap(ms);
        }
    }
}