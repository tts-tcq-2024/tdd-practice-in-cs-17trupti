using System;
using System.Collections.Generic;
using Xunit;

public class StringCalculatorAddTests
{
    [Fact]
    public void Add_ShouldReturnZero_WhenInputIsEmpty()
    {
        int expectedResult = 0;
        string input = "";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void Add_ShouldReturnZero_WhenInputIsSingleZero()
    {
        int expectedResult = 0;
        string input = "0";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

        Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void Add_ShouldReturnSumOfTwoNumbers_WhenInputHasTwoNumbersSeparatedByComma()
    {
        int expectedResult = 3;
        string input = "1,2";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldThrowException_WhenInputContainsNegativeNumbers()
    {
        Assert.Throws<Exception>(() =>
        {
            string input = "-1,2";
            StringCalculator objUnderTest = new StringCalculator();
            objUnderTest.Add(input);
        });
    }

    [Fact]
    public void Add_ShouldIgnoreNumbersGreaterThan1000_WhenInputContainsLargeNumbers()
    {
        int expectedResult = 1;
        string input = "1,1001";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

  [Fact]
    public void Add_ShouldReturnSumWithNewlineDelimiter_WhenInputHasNewlines()
    {
        int expectedResult = 6;
        string input = "1\n2,3";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Add_ShouldReturnSumWithCustomDelimiter_WhenInputHasCustomDelimiter()
    {
        int expectedResult = 3;
        string input = "//;\n1;2";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

       Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnSingleNumber_WhenInputIsSingleNumber()
    {
        int expectedResult = 5;
        string input = "5";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

        Assert.Equal(expectedResult, result);
    }
    /*
    [Fact]
    public void Add_ShouldReturnSumWithMultipleCharacterCustomDelimiter_WhenInputHasMultipleCharacterDelimiter()
    {
        int expectedResult = 6;
        string input = "//[***]\n1***2***3";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Add_ShouldReturnSumWithMixedDelimiters_WhenInputHasMixedDelimiters()
    {
        int expectedResult = 6;
        string input = "//;\n1;2\n3";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

        Assert.Equal(expectedResult, result);
    }
    */
    [Fact]
    public void Add_ShouldReturnSumWithMultipleCustomDelimiters_WhenInputHasMultipleCustomDelimiters()
    {
        int expectedResult = 6;
        string input = "//[;][%]\n1;2%3";
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.Add(input);

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Add_ShouldThrowExceptionForNegativeNumbersWithCustomDelimiters_WhenInputContainsNegativeNumbersWithCustomDelimiter()
    {
        Assert.Throws<Exception>(() =>
                                 {
                                     string input = "//;\n-1;2";
                                     StringCalculator objUnderTest = new StringCalculator();
                                     objUnderTest.Add(input);
                                 });
    }

}
