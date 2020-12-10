using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay5
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day5\Input.txt");

    public int Solution()
    {
        int[] seatID = new int[Input.Length];
        
        List<int> list = new List<int> {64,32,16,8,4,2,1};
        List<int> seat = new List<int> { 0,0,0,0,0,0,0,4,2,1};
        for (int i = 0; i < Input.Length; i++)
        {
            int TotalRows = 127;
            int FirstRow = 0;
            int firstseat = 0;
            int lastseat = 7;
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == 'F')
                {
                    TotalRows -= list[j];
                }
                if (Input[i][j] == 'B')
                {
                    FirstRow += list[j];
                }
                if (Input[i][j] == 'R')
                {
                    firstseat += seat[j];
                }
                if (Input[i][j] == 'L')
                {
                    lastseat -= seat[j];
                }
            }
            seatID[i] = TotalRows * 8 + firstseat;
        }
        int highestID = 0;
        for (int i = 0; i < seatID.Length; i++)
        {
            if(seatID[i] >= highestID)
            {
                highestID = seatID[i];
            }
        }
        int counter = 0;
        int[] seats = new int[10];

        Array.Sort(seatID);
        for (int i = 0; i < seatID.Length-1; i++)
        {
            if(seatID[i] + 1 != seatID[i + 1])
            {
                seats[counter] = seatID[i];
                counter++;
            }
        }

        return highestID ;
    }
}
