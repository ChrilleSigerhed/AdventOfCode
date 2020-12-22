using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay12
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day12\Input.txt");
    public List<char> Directions { get; set; } = new List<char>();
    public List<int> Values { get; set; } = new List<int>();
    public Dictionary<char, int> BoatPosition { get; set; } = new Dictionary<char, int>();
    public Dictionary<char, int> WayPoint { get; set; } = new Dictionary<char, int>();
    public int Part1()
    {
        foreach (var instruction in Input)
        {
            char direction = instruction[0];
            int values = Convert.ToInt32(instruction.Substring(1));
            Directions.Add(direction);
            Values.Add(values);
        }
        BoatPosition.Add('S', 0);
        BoatPosition.Add('N', 0);
        BoatPosition.Add('W', 0);
        BoatPosition.Add('E', 0);
        char[] boatDirections = new char[4] { 'N', 'E', 'S', 'W' };
        char lastBoatDirection = 'E';
        for (int i = 0; i < Directions.Count; i++)
        {
            if (BoatPosition.ContainsKey(Directions[i]))
            {
                BoatPosition[Directions[i]] += Values[i];
            }
            if(Directions[i] == 'F')
            {
                BoatPosition[lastBoatDirection] += Values[i];
            }
            if(Directions[i] == 'L' || Directions[i] == 'R')
            {
                if(Directions[i] == 'R')
                {
                    int index = Array.IndexOf(boatDirections, lastBoatDirection);
                    while (Values[i] != 0)
                    {
                        index++;
                        if (index == 4)
                        {
                            index = 0;
                        }
                        lastBoatDirection = boatDirections[index];
                        Values[i] -= 90;
                    }

                }
                if(Directions[i] == 'L')
                {
                    int index = Array.IndexOf(boatDirections, lastBoatDirection);
                    index -= 1;
                    while (Values[i] != 0)
                    {
                        if (index < 0)
                        {
                            index = 3;
                        }
                        lastBoatDirection = boatDirections[index];
                        index--;
                        Values[i] -= 90;
                    }
                }
            }
        }
        var ManhattanDistance = Math.Abs(BoatPosition['N'] - BoatPosition['S']) + Math.Abs(BoatPosition['W'] - BoatPosition['E']);
        return ManhattanDistance;
    }
    public int Part2()
    {
        foreach (var instruction in Input)
        {
            char direction = instruction[0];
            int values = Convert.ToInt32(instruction.Substring(1));
            Directions.Add(direction);
            Values.Add(values);
        }
        int manhattanDistanceX = 0;
        int manhattanDistanceY = 0;
        int x = 10;
        int y = 1;

        for (int i = 0; i < Directions.Count; i++)
        {
            if(Directions[i] == 'N')
            {
                y += Values[i];
            }
            if(Directions[i] == 'S')
            {
                y -= Values[i];
            }
            if(Directions[i] == 'W')
            {
                x -= Values[i];
            }
            if(Directions[i] == 'E')
            {
                x += Values[i];
            }
            if(Directions[i] == 'F')
            {
                manhattanDistanceX += Values[i] * x;
                manhattanDistanceY += Values[i] * y;
            }
            if(Directions[i] == 'L')
            {
                while(Values[i] != 0)
                {
                    Values[i] -= 90;
                    int wayPointX = x;
                    int wayPointY = y;
                    x = -wayPointY;
                    y = wayPointX;
                }
               

            }
            if (Directions[i] == 'R')
            {
                while (Values[i] != 0)
                {
                    Values[i] -= 90;
                    int wayPointX = x;
                    int wayPointY = y;
                    x = wayPointY;
                    y = -wayPointX;
                }
            }
        }
        var result = Math.Abs(manhattanDistanceX) + Math.Abs(manhattanDistanceY);
        return result;
    }
}

