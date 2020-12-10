using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay10
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day10\Input.txt");
    List<int> ChangedIndex = new List<int>();
    public List<int> JoltageRating { get; set; } = new List<int>();

    public int Solution1()
    {
        foreach (string number in Input)
        {
            int num = int.Parse(number);
            JoltageRating.Add(num);
        }
        JoltageRating.Sort();
        int plusOne = 1;
        int plusThree = 1;
        for (int i = 0; i < JoltageRating.Count-1; i++)
        {
            if(JoltageRating[i] + 1 == JoltageRating[i + 1])
            {
                plusOne++;
            }
            if (JoltageRating[i] + 3 == JoltageRating[i + 1])
            {
                plusThree++;
            }
        }
        int result = plusOne * plusThree;
        return result;
    }
    public long Solution2()
    {
        JoltageRating.Add(0);
        foreach (string number in Input)
        {
            int num = int.Parse(number);
            JoltageRating.Add(num);
        }
        JoltageRating.Sort();
        int topIndex = JoltageRating.Count - 1;
        int topValue = JoltageRating[topIndex];
        JoltageRating.Add(topValue);
        long changedIndex = FindCombination(topIndex);
        long result = changedIndex + 1;
        return result;
    }
    private long FindCombination(int index)
    {
        int counter = 0;
        long result = 0;
        if(index != 0)
        {
            if (JoltageRating[index] - 1 == JoltageRating[index - 1]) counter++;
            if (JoltageRating[index] - 2 == JoltageRating[index - 1]) counter++;
            if (JoltageRating[index] - 3 == JoltageRating[index - 1]) counter++;
            if (index > 1)
            {
                if (JoltageRating[index] - 1 == JoltageRating[index - 2]) counter++;
                if (JoltageRating[index] - 2 == JoltageRating[index - 2]) counter++;
                if (JoltageRating[index] - 3 == JoltageRating[index - 2]) counter++;
            }
            if(index > 2)
            {
                if (JoltageRating[index] - 1 == JoltageRating[index - 3]) counter++;
                if (JoltageRating[index] - 2 == JoltageRating[index - 3]) counter++;
                if (JoltageRating[index] - 3 == JoltageRating[index - 3]) counter++;
            }
            if (counter > 1)
            {
                result += counter;
            }
            result += FindCombination(index - 1);
        }
        return result;
    }
}

