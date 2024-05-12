namespace AvaloniaApplication3.Utils;
using System.IO;

public class Utils
{
    public static byte[] ConvertToBinary(Stream input)
    {
        using MemoryStream ms = new MemoryStream();
        input.CopyTo(ms);
        return ms.ToArray();
    }
}