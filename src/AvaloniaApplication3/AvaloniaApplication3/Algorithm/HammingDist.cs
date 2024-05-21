using System;
using System.Collections.Generic;
using Avalonia.Controls;
using AvaloniaApplication3.Struct;
using System.Text;
using AvaloniaApplication3.Utils;
using static AvaloniaApplication3.Algorithm.MyRegex;
using static AvaloniaApplication3.Utils.Result;
using System.Linq;
using Emgu.CV;

namespace AvaloniaApplication3.Algorithm;



public class HammingDist
{
    public static void findMatch(string pattern)
    {
        Console.WriteLine("LVHS findMatch called");
        DateTime startTime = DateTime.Now;
        
        List<SidikJari> sidikJariList = new List<SidikJari>(Database.SIDIK_JARI);
        List<int> lvhsDistanceList = new List<int>();

        int loop = 0;
        foreach (SidikJari sidikJari in sidikJariList)
        {
            int lvhsDistance = lvhs(sidikJari.berkas_citra, pattern, sidikJari.berkas_citra.Length, pattern.Length);
            lvhsDistanceList.Add(lvhsDistance);
            
            int percentage_ = (int) ((1 - (double)lvhsDistance / pattern.Length) * 100);
            if (percentage_ > 50)
            {
                Console.WriteLine(percentage_);
            }
        }
        
        // find min distance

        int minIdx = 0;
        for (int i = 0; i < lvhsDistanceList.Count; i++)
        {
            if (lvhsDistanceList[i] < lvhsDistanceList[minIdx])
            {
                minIdx = i;
            }
        }
        int percentage = (int) (1 - (double)lvhsDistanceList[minIdx] / pattern.Length) * 100;
        
        foreach (Utils.People biodata in Database.BIODATA){
            try {
                if (MyRegex.match(biodata.Nama, sidikJariList[minIdx].nama)) {
                    
                    Result._image = Utils.Utils.ConvertToBitmap(Encoding.GetEncoding("iso-8859-1").GetBytes(sidikJariList[minIdx].berkas_citra));

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

    public static int lvhs(string a, string b, int m, int n)
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
}



