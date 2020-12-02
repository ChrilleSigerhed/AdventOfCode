using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay2
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day2\Input.txt");

    public int Solution1()
    {
        int maxValue;
        int minValue;
        int counter;
        int correctPassword = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            counter = 0;
            string[] sortedInput = Input[i].Split(" ");
            string[] range = sortedInput[0].Split("-");
            minValue = int.Parse(range[0]); maxValue = int.Parse(range[1]);
            for (int j  = 0; j < sortedInput[2].Length; j++)
            {
                if (sortedInput[2][j] == sortedInput[1][0])
                {
                    counter++;
                }
            }
            if (counter >= minValue && counter <= maxValue)
            {
                correctPassword++;
            }
        }
        return correctPassword;
    }
    public int Solution2()
    {
        int maxValue;
        int minValue;
        int counter;
        int correctPassword = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            counter = 0;
            string[] sortedInput = Input[i].Split(" ");
            string[] range = sortedInput[0].Split("-");
            minValue = int.Parse(range[0]); maxValue = int.Parse(range[1]);
            if (sortedInput[2][minValue-1] == sortedInput[1][0])
            {
                counter++;
            }
            if (sortedInput[2][maxValue-1] == sortedInput[1][0])
            {
                counter++;
            }
            if(counter == 1)
            {
                correctPassword++;
            }
        }
        return correctPassword;
    }
}

