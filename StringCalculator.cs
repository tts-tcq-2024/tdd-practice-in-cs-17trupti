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

        if (numbers.StartsWith("//"))
        {
            return CalculateSumWithCustomDelimiter(numbers);
        }

        return CalculateSum(numbers);
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
        // Extract custom delimiters
        int delimiterEndIndex = numbers.IndexOf('\n');
        string delimiterPart = numbers.Substring(2, delimiterEndIndex - 2);

        // Handle multiple delimiters
        string[] delimiters = ExtractDelimiters(delimiterPart);
        string numberPart = numbers.Substring(delimiterEndIndex + 1);

        // Create regex pattern to split input by multiple custom delimiters
        string delimiterPattern = string.Join("|", delimiters.Select(d => Regex.Escape(d)));
        string[] numArray = numberPart.Split(new[] { delimiterPattern }, StringSplitOptions.None);

        List<int> negativeNumbers = new List<int>();

        int sum = numArray
            .Select(num => ParseNumber(num, negativeNumbers))
            .Where(num => num <= 1000)
            .Sum();

        CheckForNegatives(negativeNumbers);

        return sum;
    }

    private string[] ExtractDelimiters(string delimiterPart)
    {
        if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
        {
            return Regex.Matches(delimiterPart, @"\[(.*?)\]")
                .Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToArray();
        }
        else
        {
            return new[] { delimiterPart };
        }
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
