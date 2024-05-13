using System;
using System.Linq;
using AvaloniaApplication3.Struct;
using System.Collections.Generic;
using System.Text;
using AvaloniaApplication3.Utils;
using static AvaloniaApplication3.Algorithm.MyRegex;

namespace AvaloniaApplication3.Algorithm;

public class KMP
{
    
    public static void findMatch(string pattern)
    {
        // // Harusnya gk pake Database.SIDIK_JARI.Count langsung sih
        //
        // bool notFound = false;
        
        // start time
        DateTime startTime = DateTime.Now;
        
        List<SidikJari> sidikJariList = new List<SidikJari>(Database.SIDIK_JARI);
        
        int patternLength = pattern.Length;
        int setSize = 30;
        
        int prevLen = sidikJariList.Count;
        int newLen = 0;
        
        int loop = 0;
        
        while (sidikJariList.Count != 1 && prevLen != newLen && loop*setSize < patternLength/2)
        {   
            string currentSet = pattern.Substring(patternLength/2+loop*setSize, setSize);
            prevLen = sidikJariList.Count;

            sidikJariList = sidikJariList.Where(sidikJari => match(sidikJari.berkas_citra, currentSet)).ToList();
            
            newLen = sidikJariList.Count;
            patternLength = newLen;
            loop++;
        }
        
        // Console.WriteLine("input len: " + pattern.Length);
        // Console.WriteLine("pattern: " + pattern);

        int countMatch = 0;
        int countCompare = 0;
        
        // for (int i = 0; i < pattern.Length - setSize; i = i + setSize)
        // {  
        //     countCompare++;
        //     string currentSet = pattern.Substring(i, setSize);
        //     bool isFound = match(sidikJariList[0].berkas_citra, currentSet);
        //     if (isFound)
        //     {
        //         // Console.WriteLine("source idx: " + i + " - " + (i+setSize));
        //         countMatch++;
        //     }
        // }
        Console.WriteLine(sidikJariList.Count);
        Result._image = Utils.Utils.ConvertToBitmap(Encoding.GetEncoding("iso-8859-1").GetBytes(sidikJariList[0].berkas_citra));
        
        // Console.WriteLine("Compared: " + countCompare + " times");
        // Console.WriteLine("Matched: " + countMatch + " times");
        // Console.WriteLine("Similarity: " + (countMatch*100/countCompare) + "%");
        
        // Console.WriteLine(sidikJari.berkas_citra.Length);
        
        // end time
        DateTime endTime = DateTime.Now;
        TimeSpan timeDiff = endTime - startTime;
        
        Result.timeDiff = timeDiff;
        // Result.percentage = countMatch*100/countCompare;
        Result.percentage = 0;
        
        Console.WriteLine("Time elapsed: " + timeDiff.TotalMilliseconds + " ms");
        // System.Console.WriteLine("Name: " + sidikJariList[0].nama);
        foreach (Utils.People biodata in Database.BIODATA)
        {
            try
            {
                if (MyRegex.match(biodata.Nama, sidikJariList[0].nama))
                {
                    biodata.Nama = sidikJariList[0].nama;
                    biodata.print();
                    break;
                }
            } catch (Exception e){
                // Console.WriteLine(e.Message);
                // Console.WriteLine(biodata.Nama);
            }
           
        }
    }
    public static bool match(string t, string p)
    {   
        // Console.WriteLine("String Matching using KMP Algorithm");

        // t = "RAFiasidoasodoFIndfjnsasdRAFjsnidnaRAFoodoasd";
        // p = "RAFI";
        
        char[] text = t.ToCharArray();
        char[] pattern = p.ToCharArray();

        int n = text.Length;
        int m = pattern.Length;
        
        // Console.WriteLine("text length: "+ n);
        // Console.WriteLine("pattern length: "+ m);
        
        int[] b = computeBorder(pattern);

        int i = 0;
        int j = 0;
        
        while (i < n)
        {
            if (pattern[j] == text[i])
            {
                if (j == m - 1)
                {
                    // Console.WriteLine("Pattern found at index " + (i - m + 1));
                    return true;
                }
                i++;
                j++;
            }
            else if (j > 0)
            {
                j = b[j - 1];
            }
            else
            {
                i++;
            }
        }
        
        // Console.WriteLine("Pattern not found");
        return false;
    }

    private static int[] computeBorder(char[] pattern)
    {
        int[] b = new int[pattern.Length];
        b[0] = 0;

        int m = pattern.Length;
        int j = 0;
        int i = 1;

        while (i < m)
        {
            if (pattern[i] == pattern[j])
            {
                b[i] = j + 1;
                i++;
                j++;
            }
            else if (j > 0)
            {
                j = b[j - 1];
            }
            else
            {
                b[i] = 0;
                i++;
            }
        }

        return b;
    }
}