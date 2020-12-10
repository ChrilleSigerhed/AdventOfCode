using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SolutionDay4
{

    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day4\Input.txt");
    public string abc { get; set; } = "abcdef";
    public string[] EyeColour { get; set; } = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
    public string[] Solution1()
    {
        int counter = 0;
        string[] sortedInput = new string[291];
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i] != "")
            {
                sortedInput[counter] += Input[i] + " ";
            }
            else
            {
                counter++;
            }
        }
        counter = 0;
        string[] validString = new string[235];
        for (int i = 0; i < sortedInput.Length; i++)
        {
            if (sortedInput[i].Contains("byr") && sortedInput[i].Contains("iyr") && sortedInput[i].Contains("eyr") && sortedInput[i].Contains("hgt") && sortedInput[i].Contains("hcl") && sortedInput[i].Contains("ecl") && sortedInput[i].Contains("pid"))
            {
                validString[counter] = sortedInput[i];
                counter++;
            }
        }
        return validString;
    }
    public int Solution2()
    {
        string[] sortedList = Solution1();
        int goodPassword = 0;
        for (int i = 0; i < sortedList.Length; i++)
        {
            int correftInfo = 0;
            string[] passwordString = sortedList[i].Split(" ");
            for (int j = 0; j < passwordString.Length-1; j++)
            {
                if (passwordString[j].Contains("byr"))
                {
                    string digit = "";
                    for (int k = 4; k < passwordString[j].Length; k++)
                    {
                        digit += passwordString[j][k];
                    }
                    int digits = int.Parse(digit);
                    if(digits <= 2020 && digits >= 1920)
                    {
                        correftInfo++;
                    }
                }
                else if (passwordString[j].Contains("iyr"))
                {
                    string digit = "";
                    for (int k = 4; k < passwordString[j].Length; k++)
                    {
                        digit += passwordString[j][k];
                    }
                    int digits = int.Parse(digit);
                    if (digits <= 2020 && digits >= 2010)
                    {
                        correftInfo++;
                    }
                }
                else if (passwordString[j].Contains("eyr"))
                {
                    string digit = "";
                    for (int k = 4; k < passwordString[j].Length; k++)
                    {
                        digit += passwordString[j][k];
                    }
                    int digits = int.Parse(digit);
                    if (digits <= 2030 && digits >= 2020)
                    {
                        correftInfo++;
                    }
                }
                else if (passwordString[j].Contains("hgt"))
                {
                    if (passwordString[j].Contains("cm"))
                    {
                        string digit = "";
                        for (int k = 0; k < passwordString[j].Length; k++)
                        {
                            if (Char.IsDigit(passwordString[j][k]))
                            {
                                digit += passwordString[j][k];
                            }
                        }
                        int digits = int.Parse(digit);
                        if (digits <= 193 && digits >= 150)
                        {
                            correftInfo++;
                        }
                    }
                    else if (passwordString[j].Contains("in"))
                    {
                        string digit = "";
                        for (int k = 0; k < passwordString[j].Length; k++)
                        {
                            if (Char.IsDigit(passwordString[j][k]))
                            {
                                digit += passwordString[j][k];
                            }
                        }
                        int digits = int.Parse(digit);
                        if (digits <= 76 && digits >= 59)
                        {
                            correftInfo++;
                        }
                    }
                }
                else if (passwordString[j].Contains("hcl"))
                {
                    if (passwordString[j][4] == '#')
                    {
                        string digit = "";
                        for (int k = 5; k < passwordString[j].Length; k++)
                        {
                            digit += passwordString[j][k];
                        }
                        if (digit.Length == 6)
                        {
                            correftInfo++;
                        }
                    }
                }
                else if (passwordString[j].Contains("ecl"))
                {
                    string eyecolour = "";
                    for (int k  = 0; k < EyeColour.Length; k++)
                    {
                        if (passwordString[j].Contains(EyeColour[k]))
                        {
                            eyecolour += EyeColour[k];
                        }
                    }
                    if(eyecolour.Length == 3)
                    {
                        correftInfo++;
                    }
                }
                else if (passwordString[j].Contains("pid"))
                {
                    string digits = "";
                    for (int k = 0; k < passwordString[j].Length; k++)
                    {
                        if (Char.IsDigit(passwordString[j][k]))
                        {
                            digits += passwordString[j][k];
                        }
                    }
                    if(digits.Length == 9)
                    {
                        correftInfo++;
                    }
                }
            }
            if(correftInfo == 7)
            {
                goodPassword++;
            }
        }
        return goodPassword;
        
    }

    
}

