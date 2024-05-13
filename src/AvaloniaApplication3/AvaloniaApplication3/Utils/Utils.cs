using System;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication3.Utils;
using System.IO;

public class Utils
{
    public static byte[] ConvertToBinary(string filePah)
    {
        string path = filePah.Replace("file:///", "");
        
        // Handle for macOS
        if (path[0] != '/' && Environment.OSVersion.Platform == PlatformID.Unix)
        {
            path = "/" + path;
        }

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