// Подается текст
// Определить кол-во четных цифр в строке
// Определить является ли строка палиндромом
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string Str = Console.ReadLine();

        int evenCount = CountEvenDigits(Str);
        Console.WriteLine($"Количество четных цифр в строке: {evenCount}");

        bool isPalindrome = IsPalindrome(Str);
        Console.WriteLine($"Является ли строка палиндромом: {isPalindrome}");
    }

    static int CountEvenDigits(string str)
    {
        int count = 0;
        foreach (char c in str)
        {
            if (char.IsDigit(c) && (c - '0') % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }

    static bool IsPalindrome(string str)
    {
        string cleanedString = str.Replace(" ", "").ToLower(); 
        int left = 0;
        int right = cleanedString.Length - 1;

        while (left < right)
        {
            if (cleanedString[left] != cleanedString[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
