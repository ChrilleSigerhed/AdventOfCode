using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay9
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day9\Input.txt");

    public long Solution()
    {
        List<long> XMAS = new List<long>();
        foreach (string number in Input)
        {
            long fromStringToNumber = long.Parse(number);
            XMAS.Add(fromStringToNumber);
        }
        long result = 29221323;
        int counter = 0;
        int startPosition = 0;
        int lastPosition = 24;
        for (int i = 0; i < Input.Length; i++)
        {
            
            for (int j = startPosition; j < lastPosition + 1 ; j++)
            {
                for (int k = startPosition ; k < lastPosition + 1 ; k++)
                {
                    if(XMAS[j] + XMAS[k] == XMAS[lastPosition+1] && XMAS[j] != XMAS[k])
                    {
                        counter++;
                    }
                }
            }
            if(counter > 0)
            {
                startPosition++;
                lastPosition++;
                counter = 0;
            }
            else
            {
                result = XMAS[lastPosition + 1];
            }
        }
        long[] answer = new long[2];
        long bigValue = 0;
        counter = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            counter = i;
            bigValue = 0;
            List<long> checkedValues = new List<long>();
            while(bigValue < result)
            {
                bigValue += XMAS[counter];
                checkedValues.Add(XMAS[counter]);
                if (bigValue == result)
                {
                    answer[0] = checkedValues[0];
                    answer[1] = checkedValues[checkedValues.Count - 1];
                    long high = 0;
                    long low = result;
                    for (int j = 0; j < checkedValues.Count; j++)
                    {
                        if(checkedValues[j] >= high)
                        {
                            high = checkedValues[j];
                        }
                        if(checkedValues[j] <= low)
                        {
                            low = checkedValues[j];
                        }
                    }
                    bigValue = low + high;
                }
                counter++;
            }
        }
        return 0;
    }
}

