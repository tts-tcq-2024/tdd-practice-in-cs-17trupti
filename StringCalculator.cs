public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers) || numbers == "0")
        {
            return 0;
        }

        return CalculateSum(numbers);
    }

    private int CalculateSum(string numbers)
    {
        string[] numArray = numbers.Split(',');
        int sum = 0;
        List<int> negativeNumbers = new List<int>();

        foreach (string num in numArray)
        {
            int parsedNum = int.Parse(num);
            if (parsedNum < 0)
            {
                negativeNumbers.Add(parsedNum);
            }
            else if (parsedNum <= 1000)
            {
                sum += parsedNum;
            }
        }

        if (negativeNumbers.Count > 0)
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }

        return sum;
    }
}

