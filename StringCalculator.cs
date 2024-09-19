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
            return GetNumbersWithCustomDelimiter(numbers);
        }
        
        return numbers.Split(new[] { ',', '\n' }, StringSplitOptions.None);
    }

    private IEnumerable<string> GetNumbersWithCustomDelimiter(string numbers)
    {
        // Extract custom delimiters
        int delimiterEndIndex = numbers.IndexOf('\n');
        string delimiterPart = numbers.Substring(2, delimiterEndIndex - 2);
        string numberPart = numbers.Substring(delimiterEndIndex + 1);

        // Handle multiple delimiters and delimiters of arbitrary length
        string[] delimiters = ExtractDelimiters(delimiterPart);

        // Create regex pattern to split input by multiple custom delimiters
        string delimiterPattern = string.Join("|", delimiters.Select(d => Regex.Escape(d)));
        return numberPart.Split(new[] { delimiterPattern }, StringSplitOptions.None);
    }

    private string[] ExtractDelimiters(string delimiterPart)
    {
        // If delimiters are enclosed in brackets, extract them
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
