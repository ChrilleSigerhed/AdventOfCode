using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class Day2Tests
{
    [Theory]
    [InlineData("1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
    public void Part1_ReturnValidPasswords(params string[] Input)
    {
        int expected = 2;
        int actual = new SolutionDay2().Part1(Input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc")]
    public void Part2_ReturnValidPasswordsNewRules(params string[] Input)
    {
        int expected = 1;
        int actual = new SolutionDay2().Part2(Input);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Part1_FullInput()
    {
        int expected = 550;
        int actual = new SolutionDay2().Part1(null);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Part2_FullInput()
    {
        int expected = 634;
        int actual = new SolutionDay2().Part2(null);
        Assert.Equal(expected, actual);
    }
}

