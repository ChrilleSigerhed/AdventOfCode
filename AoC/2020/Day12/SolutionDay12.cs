using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class SolutionDay12
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\chris\Source\Repos\AdventOfCode\AoC\2020\Day12\Input.txt");
    public List<char> Directions { get; set; } = new List<char>();
    public List<int> Values { get; set; } = new List<int>();
    public Dictionary<char, int> BoatPosition { get; set; } = new Dictionary<char, int>();
    public int Solution1()
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
                    int rotation = 0;
                    while(Values[i] != 0)
                    {
                        Values[i] -= 90;
                        rotation++;
                    }
                    lastBoatDirection = GetDirectionRight(lastBoatDirection, rotation);

                }
                if(Directions[i] == 'L')
                {
                    int rotation = 0;
                    while (Values[i] != 0)
                    {
                        Values[i] -= 90;
                        rotation++;
                    }
                    lastBoatDirection = GetDirectionLeft(lastBoatDirection, rotation);
                }
            }
        }
        var ManhattanDistance = Math.Abs(BoatPosition['N'] - BoatPosition['S']) + Math.Abs(BoatPosition['W'] - BoatPosition['E']);
        return ManhattanDistance;
    }
    private char GetDirectionRight(char lastBoatDirection, int rotation)
    {
        if (lastBoatDirection == 'N')
        {
            if (rotation == 1)
            {
                return 'E';
            }
            if (rotation == 2)
            {
                return 'S';
            }
            if (rotation == 3)
            {
                return 'W';
            }
        }
        if (lastBoatDirection == 'S')
        {
            if (rotation == 1)
            {
                return 'W';
            }
            if (rotation == 2)
            {
                return 'N';
            }
            if (rotation == 3)
            {
                return 'E';
            }
        }
        if (lastBoatDirection == 'W')
        {
            if (rotation == 1)
            {
                return 'N';
            }
            if (rotation == 2)
            {
                return 'E';
            }
            if (rotation == 3)
            {
                return 'S';
            }
        }
        if (lastBoatDirection == 'E')
        {
            if (rotation == 1)
            {
                return 'S';
            }
            if (rotation == 2)
            {
                return 'W';
            }
            if (rotation == 3)
            {
                return 'N';
            }
        }
        return ' ';
    }
    private char GetDirectionLeft(char lastBoatDirection, int rotation)
    {
        if (lastBoatDirection == 'N')
        {
            if (rotation == 1)
            {
                return 'W';
            }
            if (rotation == 2)
            {
                return 'S';
            }
            if (rotation == 3)
            {
                return 'E';
            }
        }
        if (lastBoatDirection == 'S')
        {
            if (rotation == 1)
            {
                return 'E';
            }
            if (rotation == 2)
            {
                return 'N';
            }
            if (rotation == 3)
            {
                return 'W';
            }
        }
        if (lastBoatDirection == 'W')
        {
            if (rotation == 1)
            {
                return 'S';
            }
            if (rotation == 2)
            {
                return 'E';
            }
            if (rotation == 3)
            {
                return 'N';
            }
        }
        if (lastBoatDirection == 'E')
        {
            if (rotation == 1)
            {
                return 'N';
            }
            if (rotation == 2)
            {
                return 'W';
            }
            if (rotation == 3)
            {
                return 'S';
            }
        }
        return ' ';
    }

}

