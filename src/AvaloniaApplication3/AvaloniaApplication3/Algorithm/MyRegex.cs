using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AvaloniaApplication3.Algorithm;

public class MyRegex
{
    private static List<char> vocals = new List<char> {'a', 'i', 'u', 'e', 'o'};

    private static Dictionary<char, char> alay = new Dictionary<char, char>()
    {
        { 'o', '0' },
        { 'i', '1' },
        { 'z', '2' },
        { 'e', '3' },
        { 'a', '4' },
        { 's', '5' },
        { 'g', '6' },
    };
        
        
    public static bool match(string text1, string  text2)
    {   
        // Console.WriteLine(text1);
        // Console.WriteLine(text2);
        
        Regex nameRegex = new Regex(getPattern(text2));
        Match match = nameRegex.Match(text1);

        return match.Success;
    }
    
    public static string getPattern(string text)
    {
        string pattern = @"\b";
        
        foreach (char c in text)
        {   
            pattern += "[";
            if (char.IsLetter(c))
            {
                pattern += char.ToLower(c);
                pattern += char.ToUpper(c);
            }

            if (alay.ContainsKey(char.ToLower(c)))
            {
                pattern += alay[char.ToLower(c)];
            }
            
            if (c == ' ')
            { 
                pattern += @"\s";
            }

            pattern += "]";
            
            if (vocals.Contains(char.ToLower(c)))
            {
                pattern += "?";
            }
        }
        
        pattern += @"\b";
        
        // Console.WriteLine(text);
        // Console.WriteLine(pattern);
        return @pattern;
    }
} 