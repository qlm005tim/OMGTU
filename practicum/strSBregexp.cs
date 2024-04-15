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


using System;
using System.Text.RegularExpressions;
class Program
{
string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
var data = new string[]
{
    "tom@gmail.com",
    "+12345678999",
    "bob@yahoo.com",
    "+13435465566",
    "sam@yandex.ru",
    "+43743989393"
};
 
Console.WriteLine("Email List");
for(int i = 0; i < data.Length; i++)
{
    if (Regex.IsMatch(data[i], pattern, RegexOptions.IgnoreCase))
    {
        Console.WriteLine(data[i]);
    }
}



string s = "456-435-2318";
Regex regex = new Regex("[0-9]{3}-[0-9]{3}-[0-9]{4}");