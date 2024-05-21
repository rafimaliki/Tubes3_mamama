using System;
using System.Linq;
using AvaloniaApplication3.Struct;
using System.Collections.Generic;
using System.Text;
using AvaloniaApplication3.Utils;
using static AvaloniaApplication3.Algorithm.MyRegex;
using static AvaloniaApplication3.Utils.Result;

namespace AvaloniaApplication3.Algorithm;

public class KMP
{
    public static bool findMatch(string pattern)
    {
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
        foreach (Utils.People biodata in Database.BIODATA){
            try {
                if (MyRegex.match(biodata.Nama, sidikJariList[0].nama)) {
                    
                    Result._image = Utils.Utils.ConvertToBitmap(Encoding.GetEncoding("iso-8859-1").GetBytes(sidikJariList[0].berkas_citra));

                    DateTime endTime = DateTime.Now;
                    TimeSpan timeDiff = endTime - startTime;
        
                    Result.timeDiff = timeDiff;
                    Result.percentage = 0;
                    
                    Result.createNewPeople(biodata);
                    Result.setName(sidikJariList[0].nama);
                    Result.percentage = 100;

                    return true;
                    
                    break;
                }
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
           
        }

        return false;
    }
    public static bool match(string t, string p) {   
        char[] text = t.ToCharArray();
        char[] pattern = p.ToCharArray();

        int n = text.Length;
        int m = pattern.Length;
        
        int[] b = computeBorder(pattern);

        int i = 0;
        int j = 0;

        while (i < n) {
            if (pattern[j] == text[i]) {
                if (j == m - 1) {
                    return true;
                }
                i++;
                j++;
            } else if (j > 0) {
                j = b[j - 1];
            } else {
                i++;
            }
        }
        return false;
    }

    private static int[] computeBorder(char[] pattern) {
        int[] b = new int[pattern.Length];
        b[0] = 0;

        int m = pattern.Length;
        int j = 0;
        int i = 1;

        while (i < m) {
            if (pattern[i] == pattern[j]) {
                b[i] = j + 1;
                i++;
                j++;
            } else if (j > 0) {
                j = b[j - 1];
            } else {
                b[i] = 0;
                i++;
            }
        }
        return b;
    }
}