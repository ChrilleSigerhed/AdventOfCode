using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



public class SolutionDay1
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day1\Input.txt");

    public int[] Solution1()
    {
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
        return result;
    }
    public int[] Solution2()
    {
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
        return result;
    }
}


