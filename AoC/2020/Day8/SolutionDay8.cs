using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SolutionDay8
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day8\Input.txt");
    public bool Changed { get; set; } = false;

    public int Part1()
    {
        var jump = "jmp";
        var accelerate = "acc";
        var accumaccumulator = 0;
        List<int> visitedNode = new List<int>();
        var visitedNodes = 0;
        while (!visitedNode.Contains(visitedNodes))
        {
            visitedNode.Add(visitedNodes);
            if (Input[visitedNodes].Contains(accelerate))
            {
                accumaccumulator = Accumacculator(Input[visitedNodes], accumaccumulator);
            }
            if (Input[visitedNodes].Contains(jump))
            {
                visitedNodes = LoopOrder(visitedNodes);
            }
            else
            {
                visitedNodes++;
            }
        }
        return accumaccumulator;
    }
    public int Part2()
    {
        var jump = "jmp";
        var nope = "nop";
        var accelerate = "acc";
        var accumaccumulator = 0;
        List<int> visitedNode = new List<int>();
        List<int> changedNodes = new List<int>();
        var visitedNodes = 0;
        while (visitedNodes != Input.Length)
        {
            
            while (!visitedNode.Contains(visitedNodes))
            {
                visitedNode.Add(visitedNodes);
                if (Input[visitedNodes].Contains(accelerate))
                {
                    accumaccumulator = Accumacculator(Input[visitedNodes], accumaccumulator);
                }
                if (Input[visitedNodes].Contains(nope) || Input[visitedNodes].Contains(jump))
                {
                    if (Input[visitedNodes].Contains(jump))
                    {
                        if (!changedNodes.Contains(visitedNodes) && Changed == false)
                        {
                            changedNodes.Add(visitedNodes);
                            visitedNodes++;
                            Changed = true;
                        }
                        else
                        {
                            visitedNodes = LoopOrder(visitedNodes);
                        }
                    }
                    if (Input[visitedNodes].Contains(nope))
                    {
                        if (!changedNodes.Contains(visitedNodes) && Changed == false)
                        {
                            changedNodes.Add(visitedNodes);
                            Changed = true;
                            visitedNodes = LoopOrder(visitedNodes);
                        }
                        else
                        {
                            visitedNodes++;
                        }
                    }
                }
                else
                {
                    visitedNodes++;
                }
                if(visitedNodes == Input.Length - 1)
                {
                    return accumaccumulator;
                }
            }
            Changed = false;
            accumaccumulator = 0;
            changedNodes.Add(visitedNodes);
            visitedNode = new List<int>();
            visitedNodes = 0;
        }
        return accumaccumulator;
    }
    private int LoopOrder(int index)
    {

        var value = Input[index].Substring(4);
        string values = "";
        foreach (var number in value)
        {
            if (char.IsDigit(number))
            {
                values += number;
            }
        }
        var valueToInt = int.Parse(values);
        if (value[0] == '+')
        {
            index += valueToInt;
        }
        else
        {
           index -= valueToInt;
        }
        return index;
    }
    private int Accumacculator(string value, int currentValue)
    {

        string values = "";
        var plusOrMinus = value.Substring(4);
        foreach (var number in value)
        {
            if (char.IsDigit(number))
            {
                values += number;
            }
        }
        var valueToInt = int.Parse(values);
        if (plusOrMinus[0] == '+')
        {
            currentValue += valueToInt;
        }
        else
        {
            currentValue -= valueToInt;
        }

        return currentValue;
    }
}

