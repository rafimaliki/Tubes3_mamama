using System;
using System.Linq;
using AvaloniaApplication3.Struct;
using System.Collections.Generic;
using System.Text;
using AvaloniaApplication3.Utils;

namespace AvaloniaApplication3.Algorithm;

public class BoyerMoore
{
     public static bool findMatch(string pattern)
    {
        DateTime startTime = DateTime.Now;
        
        List<SidikJari> sidikJariList = new List<SidikJari>(Database.SIDIK_JARI);
        
        int patternLength = pattern.Length;
        int setSize = 60;
        Console.WriteLine("Pattern Length: " + patternLength);
        
        int prevLen = sidikJariList.Count;
        int newLen = 0;
        
        int loop = 0;
        
        while (sidikJariList.Count != 1 && prevLen != newLen && loop*setSize < patternLength/2)
        {   
            string currentSet = pattern.Substring(patternLength/2+loop*setSize, setSize);
            prevLen = sidikJariList.Count;

            sidikJariList = sidikJariList.Where(sidikJari => BmMatch(ImageConverter.ImgPathToString(sidikJari.berkas_citra), currentSet)).ToList();
            
            newLen = sidikJariList.Count;
            patternLength = newLen;
            loop++;
            Console.WriteLine(sidikJariList.Count);
        }
            
        if (sidikJariList.Count == 0) {
            Console.WriteLine("No match found using BM!");
            return false;
        }
        
        foreach (Utils.People biodata in Database.BIODATA){
            try {
                if (MyRegex.match(biodata.Nama, sidikJariList[0].nama)) {
                    
                    Result._image = Utils.Utils.ConvertToBitmap(Encoding.GetEncoding("iso-8859-1").GetBytes(ImageConverter.ImgPathToString(sidikJariList[0].berkas_citra)));

                    DateTime endTime = DateTime.Now;
                    TimeSpan timeDiff = endTime - startTime;
        
                    Result.timeDiff = timeDiff;
                    Result.percentage = 0;
                    
                    Result.createNewPeople(biodata);
                    Result.setName(sidikJariList[0].nama);
                    Result.percentage = 100;
                    
                    Console.WriteLine("Match found using BM!");
                    return true;
                }
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
           
        }

        return false;
    }
    public static bool BmMatch(string text, string pattern)
    {
        int[] last = BuildLast(pattern);
        int n = text.Length;
        int m = pattern.Length;
        int i = m - 1;

        if (i > n - 1)
            return false;
        
        int j = m - 1;
        do
        {
            if (pattern[j] == text[i])
            {
                if (j == 0)
                    return true;
                else
                {
                    i--;
                    j--;
                }
            }
            else
            { 
                int lo = last[text[i]]; //last occ
                i = i + m - Math.Min(j, 1 + lo);
                j = m - 1;
            }
        } while (i <= n - 1);

        return false;
    }

    public static int[] BuildLast(string pattern)
    {
        int[] last = new int[256]; // ASCII 8-bit char set
        for (int i = 0; i < 128; i++)
            last[i] = -1; // initialize array
        for (int i = 0; i < pattern.Length; i++)
            last[pattern[i]] = i;
        return last;
    }
}