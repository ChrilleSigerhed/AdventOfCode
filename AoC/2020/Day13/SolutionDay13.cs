using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



public class SolutionDay13
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\chris\Source\Repos\AdventOfCode\AoC\2020\Day13\Input.txt");
    public List<string> busID = new List<string>();
    public List<int> busIntervall = new List<int>();
    public Dictionary<long,int> MinToWait { get; set; } = new Dictionary<long,int>();
    public long Part1()
    {
        var earliestLeavingTime = long.Parse(Input[0]);
        var busses = Input[1].Split(',').Where(x => x != "x").Select(int.Parse).ToList();

        for (int i = 0; i < busses.Count; i++)
        {
            int waitedMinutes = 0;
            var time = earliestLeavingTime;
            while (time % busses[i] != 0)
            {
                time++;
                waitedMinutes++;
            }
            var waitTime = (time - earliestLeavingTime) * busses[i];
            MinToWait.Add(waitTime, waitedMinutes);
        }
        long lowestWait = MinToWait.Min(x => x.Value);
        var result = MinToWait.FirstOrDefault(x => x.Value == lowestWait).Key;
        return result;
    }
    public long Part2()
    {
        var pattern = Input[1].Split(',').Select(x => x == "x" ? -1 : long.Parse(x)).ToList();
        var time = 0L;
        var inc = pattern[0];
        for (var p = 1; p < pattern.Count; p++)
        {
            if (pattern[p] != -1)
            {
                var newTime = pattern[p];
                while (true)
                {
                    time += inc;
                    if ((time + p) % newTime == 0)
                    {
                        inc *= newTime;
                        break;
                    }
                }
            }
        }
        return time;
    }
}

