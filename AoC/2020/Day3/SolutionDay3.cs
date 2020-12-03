using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay3
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day3\Input.txt");
    public char Trees { get; set; } = '#';

    public int Solution1()
    {
        int slope = 2;
        int result = SlopesWithoutJump(slope);
        return result;
    }
    public int Solution2()
    {
        int slope = 0;
        int result = 0;
        for (int i = 0; i < 8; i+=2)
        {
            if(result != 0)
            {
                result *= SlopesWithoutJump(i);
            }
            else
            {
                result = SlopesWithoutJump(i);
            }
        }
        result *= SlopesWithJumps(slope);
        
        return result;
    }
    private int SlopesWithoutJump(int slope)
    {
        int slopecounter = slope;
        int treeCounter = 0;
        for (int i = 1; i < Input.Length; i++)
        {
            while (Input[i].Length <= slopecounter+2)
            {
                Input[i] += Input[i];
            }
            if (Input[i][slopecounter + 1] == Trees)
            {
                treeCounter++;
            }
            slopecounter += slope + 1;
        }
        return treeCounter;
    }
    private int SlopesWithJumps(int slope)
    {
        int slopecounter = slope;
        int treeCounter = 0;
        for (int i = 2; i < Input.Length; i+=2)
        {
            while (Input[i].Length <= slopecounter + 2)
            {
                Input[i] += Input[i];
            }
            if (Input[i][slopecounter + 1] == Trees)
            {
                treeCounter++;
            }
            slopecounter += slope + 1;
        }
        return treeCounter;
    }
}

