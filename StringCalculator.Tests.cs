using System;
using System.Collections.Generic;
using Xunit;

public class StringCalculatorAddTests
{
    private readonly StringCalculator _stringCalculator;

    public StringCalculatorAddTests()
    {
        _stringCalculator = new StringCalculator();
    }

    [Fact]
    public void Add_ShouldReturnZero_WhenInputIsEmpty()
    {
        int expectedResult = 0;
        string input = "";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnZero_WhenInputIsSingleZero()
    {
        int expectedResult = 0;
        string input = "0";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnSingleNumber_WhenInputIsSingleNumber()
    {
        int expectedResult = 5;
        string input = "5";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnSumOfTwoNumbers_WhenInputHasTwoNumbersSeparatedByComma()
    {
        int expectedResult = 3;
        string input = "1,2";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnSumWithNewlineDelimiter_WhenInputHasNewlines()
    {
        int expectedResult = 6;
        string input = "1\n2,3";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnSumWithCustomDelimiter_WhenInputHasCustomDelimiter()
    {
        int expectedResult = 3;
        string input = "//;\n1;2";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }


    [Fact]
    public void Add_ShouldThrowException_WhenInputContainsNegativeNumbers()
    {
        string input = "-1,2";

        var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(input));
        Console.WriteLine($"Exception Message: {exception.Message}");
    }

    [Fact]
    public void Add_ShouldThrowExceptionForMultipleNegatives_WhenInputContainsMultipleNegativeNumbers()
    {
        string input = "-1,-2";

        var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(input));

        Assert.Equal("Negatives not allowed: -1,-2", exception.Message);
    }

    [Fact]
    public void Add_ShouldIgnoreNumbersGreaterThan1000_WhenInputContainsLargeNumbers()
    {
        int expectedResult = 1;
        string input = "1,1001";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldHandleMultipleNumbers_WithCustomDelimiter()
    {
        int expectedResult = 6;
        string input = "//[***]\n1***2***3";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Add_ShouldThrowExceptionForNegativeNumbersWithCustomDelimiters_WhenInputContainsNegativeNumbersWithCustomDelimiter()
    {
        string input = "//;\n-1;2";
        
        var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(input));
        
        Console.WriteLine(exception.Message);
        
        Assert.Equal("Negatives not allowed: -1", exception.Message);
    }

    [Fact]
    public void Add_ShouldReturnSumWithUnknownAmountOfNumbers()
    {
        int expectedResult = 15;
        string input = "1,2,3,4,5";
        int result = _stringCalculator.Add(input);

        Assert.Equal(expectedResult, result);
    }

}
