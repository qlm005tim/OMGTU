using System;
using System.Text;
class Program
{
    public static string ReplaceCharInStr(string inpStr,int index, char newChar)
    {
        if (index >=inpStr.Length || index < 0)
        {
            return inpStr;
        }
        char[] chArr = inpStr.ToCharArray();
        chArr[index] = newChar;
        return new string(chArr);
    }
  
    static char GetRandChar()
    {
        Random random = new Random();
        string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int index = random.Next(0, str.Length);
        return str[index];
    }
  
    static void Main()
    {
        string a = "0123456789";
        var startTime = System.Diagnostics.Stopwatch.StartNew();
        string res = a;
        for (int i = 0; i < 1000000; i++)
        {
            string r = ReplaceCharInStr(res, i % 10, GetRandChar());
            res = r;
        }
        Console.WriteLine(res);
        startTime.Stop();
        var resTime = startTime.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:000}",resTime.Minutes, resTime.Seconds, resTime.Milliseconds);
        Console.WriteLine(elapsedTime);


        StringBuilder sb = new StringBuilder("0123456789");
        var startTime1 = System.Diagnostics.Stopwatch.StartNew();
        for (int i=0; i < 1000000; i++)
        {
            sb.Insert(i%10,GetRandChar());
            sb.Remove((i%10)+1, 1);
        }
        Console.WriteLine(sb);
        startTime1.Stop();
        var resTime1 = startTime1.Elapsed;
        string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:000}", resTime1.Minutes, resTime1.Seconds, resTime1.Milliseconds);
        Console.WriteLine(elapsedTime1);
        }
    }
