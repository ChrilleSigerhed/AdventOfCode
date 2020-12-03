using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay3
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day3\Input.txt");
   
    public int Solution1()
    {
        char tree = '#';
        int slope = 2;
        int treeCounter = 0;
        for (int i = 1; i < Input.Length; i++)
        {
            while (Input[i].Length <= slope)
            {
                Input[i] += Input[i];
            }
            if (Input[i][slope+1] == tree)
            {
                treeCounter++;
            }
            slope += 3;
        }
        return treeCounter;
    }
    public Int64 Solution2()
    {
        char tree = '#';
        int slope1 = 0;
        int slope2 = 2;
        int slope3 = 4;
        int slope4 = 6;
        int slope5 = 0;
        int treeCounter1 = 0; 
        int treeCounter2 = 0; 
        int treeCounter3 = 0; 
        int treeCounter4 = 0; 
        int treeCounter5 = 0;
        for (int i = 1; i < Input.Length; i++)
        {
            while (Input[i].Length <= slope4)
            {
                Input[i] += Input[i];
            }
            if (Input[i][slope1 + 1] == tree)
            {
                treeCounter1++;
            }
            if (Input[i][slope2 + 1] == tree)
            {
                treeCounter2++;
            }
            if (Input[i][slope3 + 1] == tree)
            {
                treeCounter3++;
            }
            if (Input[i][slope4 + 1] == tree)
            {
                treeCounter4++;
            }
            slope1 += 1;
            slope2 += 3;
            slope3 += 5;
            slope4 += 7;
        }
        for (int i = 2; i < Input.Length; i+=2)
        {
            while (Input[i].Length <= slope5)
            {
                Input[i] += Input[i];
            }
            if (Input[i][slope5 + 1] == tree)
            {
                treeCounter5++;
            }
            slope5++;
        }
        Int64 result = treeCounter1 * treeCounter2 * treeCounter3 * treeCounter4 * treeCounter5;
        return result;
    }
}

