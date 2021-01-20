using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AoC;
using System.IO;

public class Day1Tests
{
    [Theory]
    [InlineData("1721", "979", "366", "299", "675", "1456")]
    public void Part1_ReturnValueThatSumsTo2020(params string[] array)
    {
        int result = new SolutionDay1().Part1(array);
        int expected = 514579;
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1721", "979", "366", "299", "675", "1456")]
    public void Part2_ReturnValueThatSumsTo2020(params string[] array)
    {
        int expected = 241861950;
        int result = new SolutionDay1().Part2(array);
        Assert.Equal(expected, result);
    }
}

