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
        bool change = true;
        while (change)
        {
            change = false;
            string[] input = new string[Input.Length];
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (Input[i][j] == emptySeat)
                    {
                        if (CheckIfPeopleCanSitEmptyChair(i, j))
                        {
                            input[i] += seat;
                            change = true;
                        }
                        else
                        {
                            input[i] += emptySeat;
                        }
                    }
                    if (Input[i][j] == floor)
                    {
                        input[i] += floor;
                    }
                    if (Input[i][j] == seat)
                    {
                        if (CheckIfPeopleCanSit(i, j))
                        {
                            input[i] += seat;
                        }
                        else
                        {
                            input[i] += emptySeat;
                            change = true;
                        }
                    }
                }
            }
            Input = input;
        }
        int counter = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input[i].Length; j++)
            {
                if(Input[i][j] == seat)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
    public int Solution2()
    {
        char seat = '#';
        char emptySeat = 'L';
        char floor = '.';
        bool change = true;
        while (change)
        {
            change = false;
            string[] input = new string[Input.Length];
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (Input[i][j] == emptySeat)
                    {
                        if (CheckAllRotesEmptyChair(i, j))
                        {
                            input[i] += seat;
                            change = true;
                        }
                        else
                        {
                            input[i] += emptySeat;
                        }
                    }
                    if (Input[i][j] == floor)
                    {
                        input[i] += floor;
                    }
                    if (Input[i][j] == seat)
                    {
                        if (CheckAllRotesFilledChair(i, j))
                        {
                            input[i] += seat;
                        }
                        else
                        {
                            input[i] += emptySeat;
                            change = true;
                        }
                    }
                }
            }
            Input = input;
        }
        int counter = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == seat)
                {
                    counter++;
                }
            }
        }
        return counter;
    }
    private bool CheckAllRotesFilledChair(int ind, int position)
    {
        int index = ind;
        int pos = position;
        int counter = 0;
        while (index != Input.Length - 1)
        {
            index++;
            if (Input[index][pos] == '#') // check all down
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (pos != Input[index].Length - 1) // check all right
        {
            pos++;
            if (Input[index][pos] == '#') // check all down
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }

        }
        index = ind;
        pos = position;
        while (pos > 0) // check all left
        {
            pos--;
            if (Input[index][pos] == '#') // check all down
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }

        }
        index = ind;
        pos = position;
        while (index != 0)
        {
            index--;
            if (Input[index][pos] == '#') // check all down
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }

        }
        index = ind;
        pos = position;
        while (index != 0 && pos != 0) // check diagonal up left
        {
            index--;
            pos--;
            if (Input[index][pos] == '#')
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }

        }
        index = ind;
        pos = position;
        while (index != 0 && pos != Input[index].Length - 1) // check diagonal up right
        {
            index--;
            pos++;
            if (Input[index][pos] == '#')
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (index != Input.Length - 1 && pos != 0) // check digonal down left
        {
            index++;
            pos--;
            if (Input[index][pos] == '#')
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (index != Input.Length - 1 && pos != Input[index].Length - 1)
        {
            index++;
            pos++;
            if (Input[index][pos] == '#')
            {
                counter++;
                break;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        if(counter >= 5)
        {
            return false;
        }
        return true;
    }
    private bool CheckAllRotesEmptyChair(int ind, int position)
    {
       
        int index = ind;
        int pos = position;
        while(index != Input.Length -1)
        {
            index++;
            if (Input[index][pos] == '#') // check all down
            {
                return false;
            }
            if(Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (pos != Input[index].Length - 1) // check all right
        {
            pos++;
            if (Input[index][pos] == '#') // check all down
            {
                return false;
            }
            if ( Input[index][pos] == 'L')
            {
                break;
            }

        }
        index = ind;
        pos = position;
        while (pos > 0) // check all left
        {
            pos--;
            if (Input[index][pos] == '#') // check all down
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
            
        }
        index = ind;
        pos = position;
        while (index != 0)  
        {
            index--;
            if (Input[index][pos] == '#') // check all down
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
            
        }
        index = ind;
        pos = position;
        while (index != 0 && pos != 0) // check diagonal up left
        {
            index--;
            pos--;
            if (Input[index][pos] == '#') 
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
            
        }
        index = ind;
        pos = position;
        while (index != 0 && pos != Input[index].Length - 1) // check diagonal up right
        {
            index--;
            pos++;
            if (Input[index][pos] == '#')
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (index != Input.Length - 1 && pos != 0) // check digonal down left
        {
            index++;
            pos--;
            if (Input[index][pos] == '#')
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        index = ind;
        pos = position;
        while (index != Input.Length - 1 && pos != Input[index].Length - 1)
        {
            index++;
            pos++;
            if (Input[index][pos] == '#')
            {
                return false;
            }
            if (Input[index][pos] == 'L')
            {
                break;
            }
        }
        return true;
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
    private bool CheckIfPeopleCanSitEmptyChair(int index, int position)
    {
        int counter = 0;
        if (index == 0)
        {
            if (position > 0 && position < Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }
            if (position == Input[index].Length - 1)
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
        if (index == Input.Length - 1)
        {
            if (position > 0 && position < Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
            }
            if (position == Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
            }
            if (position == 0)
            {
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
            }

        }
        if (index != Input.Length - 1 && index != 0)
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
            if (position == Input[index].Length - 1)
            {
                if (Input[index][position - 1] == '#') counter++;
                if (Input[index - 1][position - 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index + 1][position - 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
            }
            if (position == 0)
            {
                if (Input[index][position + 1] == '#') counter++;
                if (Input[index - 1][position] == '#') counter++;
                if (Input[index - 1][position + 1] == '#') counter++;
                if (Input[index + 1][position] == '#') counter++;
                if (Input[index + 1][position + 1] == '#') counter++;
            }

        }
        if (counter >= 1) return false;
        return true;
    }
}

