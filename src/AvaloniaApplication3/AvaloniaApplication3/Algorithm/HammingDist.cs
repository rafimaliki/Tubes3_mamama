using System;
using System.Collections.Generic;
using AvaloniaApplication3.Struct;
using System.Text;
using AvaloniaApplication3.Utils;

namespace AvaloniaApplication3.Algorithm;

public class HammingDist
{
    public static void findMatch(string pattern)
    {
        Console.WriteLine("Hamming Distance Find Match:");
        DateTime startTime = DateTime.Now;
        
        List<SidikJari> sidikJariList = new List<SidikJari>(Database.SIDIK_JARI);
        List<int> hammingDistanceList = new List<int>();

        int loop = 0;
        int match100 = 0;
        foreach (SidikJari sidikJari in sidikJariList)
        {
            int hammingDistance = hamming(ImageConverter.ImgPathToString(sidikJari.berkas_citra), pattern, ImageConverter.ImgPathToString(sidikJari.berkas_citra).Length, pattern.Length);
            hammingDistanceList.Add(hammingDistance);
            
            int percentage_ = (int) ((1 - (double)hammingDistance / pattern.Length) * 100);
            if (percentage_ > 50)
            {  
                if (percentage_ == 100)
                {
                    match100++;
                }
            }
        }
        
        int minIdx = 0;
        for (int i = 0; i < hammingDistanceList.Count; i++)
        {
            if (hammingDistanceList[i] < hammingDistanceList[minIdx])
            {   
                minIdx = i;
            }
        }
        int percentage = (int) ((1 - (double)hammingDistanceList[minIdx] / pattern.Length) * 100);
        
        foreach (Utils.People biodata in Database.BIODATA){
            try {
                if (MyRegex.match(biodata.Nama, sidikJariList[minIdx].nama)) {
                    
                    Result._image = Utils.Utils.ConvertToBitmap(Encoding.GetEncoding("iso-8859-1").GetBytes(ImageConverter.ImgPathToString(sidikJariList[minIdx].berkas_citra)));

                    DateTime endTime = DateTime.Now;
                    TimeSpan timeDiff = endTime - startTime;
        
                    Result.timeDiff = timeDiff;
                    Result.percentage = percentage;
                    
                    Result.createNewPeople(biodata);
                    Result.setName(sidikJariList[minIdx].nama);
                    
                    break;
                }
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
           
        }
    }

    public static int hamming(string a, string b, int m, int n)
    {
        int countDiff = 0;
        for (int i = 0; i < Math.Min(m,n); i++)
        {
            if (a[i] != b[i])
            {
                countDiff++;
            }
        }

        return countDiff;
    }

    public static int getPecentage(string a, string b)
    {
        int countDiff = hamming(a, b, a.Length, b.Length);
        return (int) ((1 - (double)countDiff / a.Length) * 100);
    }
}



