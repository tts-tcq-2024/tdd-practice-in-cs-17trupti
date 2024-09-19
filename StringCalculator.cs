using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers) || numbers == "0")
        {
            return 0;
        }

        return numbers.StartsWith("//") 
            ? CalculateSumWithCustomDelimiter(numbers) 
            : CalculateSum(numbers);
    }

    private int CalculateSum(string numbers)
    {
        string[] numArray = numbers.Split(new[] { ',', '\n' }, StringSplitOptions.None);
        List<int> negativeNumbers = new List<int>();

        int sum = numArray
            .Select(num => ParseNumber(num, negativeNumbers))
            .Where(num => num <= 1000)
            .Sum();

        CheckForNegatives(negativeNumbers);

        return sum;
    }

    private int CalculateSumWithCustomDelimiter(string numbers)
    {
        // Extract custom delimiter
        int delimiterEndIndex = numbers.IndexOf('\n');
        string delimiter = numbers.Substring(2, delimiterEndIndex - 2);
        string numberPart = numbers.Substring(delimiterEndIndex + 1);

        // Split input by custom delimiter
        string[] numArray = numberPart.Split(new[] { delimiter }, StringSplitOptions.None);
        List<int> negativeNumbers = new List<int>();

        int sum = numArray
            .Select(num => ParseNumber(num, negativeNumbers))
            .Where(num => num <= 1000)
            .Sum();

        CheckForNegatives(negativeNumbers);

        return sum;
    }

    private int ParseNumber(string num, List<int> negativeNumbers)
    {
        int parsedNum = int.Parse(num);
        if (parsedNum < 0)
        {
            negativeNumbers.Add(parsedNum);
        }
        return parsedNum;
    }

    private void CheckForNegatives(List<int> negativeNumbers)
    {
        if (negativeNumbers.Count > 0)
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }
    }
}
