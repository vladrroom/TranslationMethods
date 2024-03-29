﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace EpsilonRemovalRules
{
    public class Rules
    {
        public Char leftSide;
        public string rightSide;
        public bool isGenerating;
        public int counter;
        public static int counterLowerChars;

        public Rules(Char c, string s)
        {
            leftSide = c;
            rightSide = s;
            counter = s.Length;
            isGenerating = false;
        }
        
        public static bool CheckLowerChars(string s)
        {
            for (int i = 0; i < s.Length; i++) 
                if(!Char.IsUpper(s[i]))
                    counterLowerChars++;

            if (counterLowerChars == s.Length)
                return true;

            return false;
        }

        public static bool CheckEps(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] == 'E')
                    return true;

            return false;
        }

        public static List<Rules> ReadRulesInTxt()
        {
            string path = @"D:\text1.txt";
            var CurLine = "";
            List<Rules> Grammar = new List<Rules>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        CurLine = sr.ReadLine();
                        Grammar.Add(new Rules(CurLine[0], CurLine.Substring(1, CurLine.Length -1)));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Grammar;
        }
    }
}
