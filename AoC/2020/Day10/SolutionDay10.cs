using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class SolutionDay10
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day10\Input.txt");
    List<int> ChangedIndex = new List<int>();
    public List<int> JoltageRating { get; set; } = new List<int>();
    public Dictionary<int, long> checkedIndex = new Dictionary<int, long>();

    public int Part1()
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
    public long Part2()
    {
        JoltageRating.Add(0);
        foreach (string number in Input)
        {
            int num = int.Parse(number);
            JoltageRating.Add(num);
        }
        JoltageRating.Sort();
        long result = FindCombination(0);


        return result;
    }

    private long FindCombination(int index)
    {
        long counter = 0;
        if(index == JoltageRating.Count -1)
        {
            return 1;
        }
        if (checkedIndex.ContainsKey(index))
        {
            return checkedIndex[index];
        }
        for (int i = index + 1; i < JoltageRating.Count; i++)
        {
            if (JoltageRating[i] - JoltageRating[index] <= 3)
            {
                counter += FindCombination(i);
            }
        }
        checkedIndex.Add(index, counter);
        
        return counter;

    }
}

