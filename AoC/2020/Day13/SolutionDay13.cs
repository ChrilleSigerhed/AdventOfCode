using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class SolutionDay13
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day13\Input.txt");
    public List<string> busID = new List<string>();
    public List<int> busIntervall = new List<int>();
    public int Part1()
    {
        int timestamp = int.Parse(Input[0]);
        string[] input = Input[1].Split(",");
        Dictionary<int, int> TimeToWait = new Dictionary<int, int>();
        foreach (string budId in input)
        {
            if(budId != "x")
            {
                busID.Add("");
                int intervall = int.Parse(budId);
                busIntervall.Add(intervall);
                TimeToWait.Add(intervall, 0);
            }
        }
        for (int i = 0; i < busID.Count; i++)
        {
            busID[i] = DepartTimes(busID[i], timestamp, busIntervall[i]);
        }
        for (int i = 0; i < TimeToWait.Count; i++)
        {
            bool depart = false;
            int time = timestamp;
            int counter = 0;
            while (depart == false)
            {
                if(busID[i][time] == 'D')
                {
                    counter++;
                    depart = true;
                    TimeToWait[busIntervall[i]] = counter;
                }
                else
                {
                    counter++;
                    time++;
                }
            }
        }
        int lowestWaitTime = 100000000;
        int buss = 0;
        for (int i = 0; i < TimeToWait.Count; i++)
        {
            if(TimeToWait.ElementAt(i).Value < lowestWaitTime)
            {
                lowestWaitTime = TimeToWait.ElementAt(i).Value;
                buss = busIntervall[i];
            }
        }
        int result = buss * lowestWaitTime;
        return result;
    }
    public string DepartTimes(string busID, int timestamp, int busIntervall)
    {
        int buss = busIntervall - 1;
        for (int i = 0; i < busIntervall; i++)
        {
            if (i == buss)
            {
                busID += "D";
            }
            else
            {
                busID += ".";
            }
        }
        while(busID.Length < timestamp)
        {
            busID += busID;
        }
        return busID;
    }
}

