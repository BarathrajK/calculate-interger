using System;
namespace ConsoleApp10
{
    class Program
    {
        static string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] hundreds = { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };
        static string[] thousandsGroups = { "", "thousand", "lakh", "crore" };

        static void Main(string[] args)
        {
            long num = 9902509228181;
            Console.WriteLine(NumberToWords(num));
        }

        static string NumberToWords(long num)
        {
            if (num == 0)
                return "zero";

            if (num < 0)
                return "minus " + NumberToWords(Math.Abs(num));

            string words = "";

            int groupIndex = 0;
            while (num > 0)
            {
                long group = num % 1000;
                num /= 1000;

                if (group > 0)
                {
                    string groupWords = "";

                    int onesDigit = (int)(group % 10);
                    int tensDigit = (int)((group % 100) / 10);
                    int hundredsDigit = (int)(group / 100);

                    if (hundredsDigit > 0)
                    {
                        groupWords += hundreds[hundredsDigit] + " ";
                    }

                    if (tensDigit > 0 || onesDigit > 0)
                    {
                        if (tensDigit == 0)
                        {
                            groupWords += ones[onesDigit] + " ";
                        }
                        else if (tensDigit == 1)
                        {
                            groupWords += tens[onesDigit] + " ";
                        }
                        else
                        {
                            groupWords += tens[tensDigit] + " ";
                            if (onesDigit > 0)
                            {
                                groupWords += ones[onesDigit] + " ";
                            }
                        }
                    }

                    groupWords += thousandsGroups[groupIndex];

                    if (words == "")
                    {
                        words = groupWords;
                    }
                    else
                    {
                        words = groupWords + " " + words;
                    }
                }

                groupIndex++;
            }

            return words;
        }
    }
}

