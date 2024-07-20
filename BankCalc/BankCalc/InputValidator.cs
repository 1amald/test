namespace BankCalc;

internal static class InputValidator
{
    public static bool AmountIsValid(string input, out int targetSum)
    {
        if (!int.TryParse(input, out targetSum))
        {
            Console.WriteLine("Не удалось распарсить сумму");
            return false;
        }

        if (targetSum <= 0)
        {
            Console.WriteLine("Введите сумму больше 0");
            return false;
        }

        return true;
    }
}