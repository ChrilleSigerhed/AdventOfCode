using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



public class SolutionDay1
{
    public string[] Inputs { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day1\Input.txt");
    public int Part1(string[] Input)
    {
        if(Input == null)
        {
            Input = Inputs;
        }
        int[] result = new int[2];
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input.Length; j++)
            {
                if (int.Parse(Input[i]) + int.Parse(Input[j]) == 2020)
                {
                    result[0] = int.Parse(Input[i]);
                    result[1] = int.Parse(Input[j]);
                }
            }
        }
        int answer = result[0] * result[1];
        return answer;
    }
    public int Part2(string[] Input)
    {
        if (Input == null)
        {
            Input = Inputs;
        }

        int[] result = new int[3];
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input.Length; j++)
            {
                for (int k = 0; k < Input.Length; k++)
                {
                    if (int.Parse(Input[i]) + int.Parse(Input[j]) + int.Parse(Input[k]) == 2020)
                    {
                        result[0] = int.Parse(Input[i]);
                        result[1] = int.Parse(Input[j]);
                        result[2] = int.Parse(Input[k]);
                    }
                }
            }
        }
        int answer = result[0] * result[1] * result[2];
        return answer;
    }
}


