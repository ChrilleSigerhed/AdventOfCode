using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class SolutionDay6
{
    public string[] Input { get; set; } = File.ReadAllLines(@"C:\Users\ChrillE\source\repos\AoC\AoC\2020\Day6\Input.txt");

    public int Solution1()
    {
        string[] allQuestions = new string[480];
        List<string> countedQuestions = new List<string>();
        int totalQuestions = 0;
        int counter = 0;

        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i] != "")
            {
                allQuestions[counter] += Input[i];
            }
            else
            {
                counter++;
            }
        }
        for (int i = 0; i < allQuestions.Length; i++)
        {
            char s = allQuestions[i][0];
            countedQuestions.Add(s.ToString());
            for (int j = 0; j < allQuestions[i].Length; j++)
            {
                if (!countedQuestions[i].Contains(allQuestions[i][j]))
                {
                    countedQuestions[i] += allQuestions[i][j];
                }
            }
            totalQuestions += countedQuestions[i].Length;
        }
        return totalQuestions;
    }
    public int Solution2()
    {
        string[] allQuestions = new string[960];
        List<string> countedQuestions = new List<string>();
        int allYes = 0;
        int counter = 0;
        int peopleVoting = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i] != "")
            {
                allQuestions[counter] += Input[i];
                peopleVoting++;
            }
            else
            {
                counter++;
                allQuestions[counter] += peopleVoting.ToString();
                peopleVoting = 0;
                counter++;
            }
        }
        allQuestions[959] = "3";
        int everyoneSaidYes = 0;
        for (int i = 0; i < countedQuestions.Count; i+=2)
        {
            for (int j = 0; j < countedQuestions[i].Length; j++)
            {
                foreach (var letter in allQuestions[i])
                {
                    if(countedQuestions[i][j] == letter)
                    {
                        allYes++;
                    }
                }
                if(allYes == int.Parse(countedQuestions[i + 1]))
                {
                    everyoneSaidYes++;
                }
                allYes = 0;
            }
        }
        return allYes;
    }


}
