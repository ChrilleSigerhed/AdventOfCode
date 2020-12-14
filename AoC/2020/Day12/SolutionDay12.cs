using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay12
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day12\Input.txt");
    public List<char> Directions { get; set; } = new List<char>();
    public List<int> Values { get; set; } = new List<int>();
    public List<char> BoatPosition { get; set; } = new List<char>();
    public int Solution1()
    {
        foreach (var instruction in Input)
        {
            char direction = instruction[0];
            int values = Convert.ToInt32(instruction.Substring(1));
            Directions.Add(direction);
            Values.Add(values);
        }

       
     


        return 1;
    }
   
}

