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

        return CalculateTotalSum(ExtractNumberStrings(numbers));
    }

    private IEnumerable<string> ExtractNumberStrings(string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            return SplitByCustomDelimiter(numbers);
        }
        
        // Split input by default delimiters (comma and newline)
        return numbers.Split(new[] { ',', '\n' }, StringSplitOptions.None);
    }

    private IEnumerable<string> SplitByCustomDelimiter(string numbers)
    {
        // Extract custom delimiter
        int delimiterEndIndex = numbers.IndexOf('\n');
        string delimiter = numbers.Substring(2, delimiterEndIndex - 2);
        string numberPart = numbers.Substring(delimiterEndIndex + 1);
        
        // Split input by custom delimiter
        return numberPart.Split(new[] { delimiter }, StringSplitOptions.None);
    }

    private int CalculateTotalSum(IEnumerable<string> numbers)
    {
        List<int> negativeNumbers = new List<int>();

        int sum = numbers
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
