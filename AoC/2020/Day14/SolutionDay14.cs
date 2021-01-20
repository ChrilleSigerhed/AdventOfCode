using MoreLinq;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SolutionDay14
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day14\Input.txt");

    public int Part1()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i].StartsWith("mask"))
            {
                List<string> section = new List<string>();
                int counter = 1;
                while (Input[i + counter].StartsWith("mem"))
                {
                    section.Add(Input[i + counter]);
                    counter++;
                }

            }
        }
        return 0;
    }
}

