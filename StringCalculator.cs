public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers) || numbers == "0")
        {
            return 0;
        }

        string[] numArray = numbers.Split(',');
        int sum = 0;

        foreach (string num in numArray)
        {
            sum += int.Parse(num);
        }

        return sum;
    }
}


