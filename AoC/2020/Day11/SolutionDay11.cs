using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay11
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day11\Input.txt");

    public int Solution1()
    {
        char seat = '#';
        char emptySeat = 'L';
        char floor = '.';

        return 1;
    }
    private bool CheckIfPeopleCanSit(int index, int position)
    {
        int counter = 0;
        if(index == 0)
        {
            if(position > 0 && position < Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }
            if(position == Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
            }
            if (position == 0)
            {
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }
        }
        if(index == Input.Length - 1)
        {
            if(position > 0 && position < Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
            }
            if(position == Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
            }
            if(position == 0)
            {
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
            }
           
        }
        if(index != Input.Length - 1 && index != 0)
        {
            if (position > 0 && position < Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }
            if(position == Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
            }
            if(position == 0)
            {
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }
            
        }
        if (counter >= 4) return false;
        return true;
    }
}

