using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers) || numbers == "0")
        {
            return 0;
        }

        return CalculateSum(PrepareNumbers(numbers));
    }

    private IEnumerable<string> PrepareNumbers(string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            return GetNumbersWithCustomDelimiters(numbers);
        }
        
        return numbers.Split(new[] { ',', '\n' }, StringSplitOptions.None);
    }

    private IEnumerable<string> GetNumbersWithCustomDelimiters(string numbers)
    {
        // Extract custom delimiters
        int delimiterEndIndex = numbers.IndexOf('\n');
        string delimiterPart = numbers.Substring(2, delimiterEndIndex - 2);
        
        // Extract delimiters using regex
        var delimiters = new List<string> { ",", "\n" }; // Default delimiters
        var matches = Regex.Matches(delimiterPart, @"\[(.*?)\]");
        foreach (Match match in matches)
        {
            delimiters.Add(Regex.Escape(match.Groups[1].Value));
        }
        
        // Extract numbers part
        string numberPart = numbers.Substring(delimiterEndIndex + 1);

        // Join delimiters for regex pattern
        string delimiterPattern = string.Join("|", delimiters);
        
        // Split input by custom delimiters
        return numberPart.Split(new[] { delimiterPattern }, StringSplitOptions.None);
    }

    private int CalculateSum(IEnumerable<string> numbers)
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
