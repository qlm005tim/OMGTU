using System;
using System.Linq;

class TrapezoidalRule
{
    static void Main()
    {
        Func<double, double> f = (double x) => -x * x + 9;
        var answ = TrapezoidalRule.Solve(f, -3, 3, 0.1);
        Console.WriteLine(answ); //answer

        Console.WriteLine(f(2.9)); //it is function no answer
    }

    public static double Solve(Func<double, double> f, double a, double b, double dx)
    {
        double eps = 1E-7;
        if ((Math.Abs(b - a) >= -eps || dx <= eps || (a + b + dx) % 1 != 0))
        {
            throw new ArgumentException("Неверные данные");
        }

        double s_trap = Enumerable.Range(0, (int)((b - a) / dx))
            .Select(i => (f(a + i * dx) + f(a + (i + 1) * dx)) * 0.5 * dx)
            .Sum();

        return s_trap;
    }
}
```
В этом примере мы используем LINQ для замены цикла `for` и вычисления суммы трапеций. Мы генерируем последовательность чисел от 0 до количества интервалов, используя `Enumerable.Range`, затем вычисляем площадь каждой трапеции с помощью `Select`, и, наконец, суммируем все площади с помощью `Sum`.





 Вот пример программы на C#, которая использует библиотеку Newtonsoft.Json для работы с JSON и LINQ для выполнения запросов. Программа вычисляет средний балл по каждому предмету, определяет студентов с максимальным средним баллом и группы с лучшим средним баллом по каждому предмету.
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string jsonInput = File.ReadAllText("input.json");
        var inputData = JsonConvert.DeserializeObject<InputData>(jsonInput);

        var gpaByDiscipline = CalculateGPAByDiscipline(inputData.Data);
        var studentsWithHighestGPA = GetStudentsWithHighestGPA(inputData.Data);
        var bestGroupsByDiscipline = GetBestGroupsByDiscipline(inputData.Data);

        var outputData = new OutputData
        {
            Response = new List<object>
            {
                new { taskName = "CalculateGPAByDiscipline", data = gpaByDiscipline },
                new { taskName = "GetStudentsWithHighestGPA", data = studentsWithHighestGPA },
                new { taskName = "GetBestGroupsByDiscipline", data = bestGroupsByDiscipline }
            }
        };

        string jsonOutput = JsonConvert.SerializeObject(outputData, Formatting.Indented);
        File.WriteAllText("output.json", jsonOutput);
    }

    static Dictionary<string, double> CalculateGPAByDiscipline(List<DataItem> data)
    {
        return data
            .GroupBy(d => d.Discipline)
            .ToDictionary(
                g => g.Key,
                g => g.Average(d => d.Mark)
            );
    }

    static List<string> GetStudentsWithHighestGPA(List<DataItem> data)
    {
        var studentsGPA = data
            .GroupBy(d => d.Name)
            .ToDictionary(
                g => g.Key,
                g => g.Average(d => d.Mark)
            );

        var maxGPA = studentsGPA.Max(sg => sg.Value);
        return studentsGPA
            .Where(sg => Math.Abs(sg.Value - maxGPA) < 1e-9)
            .Select(sg => sg.Key)
            .ToList();
    }

    static Dictionary<string, string> GetBestGroupsByDiscipline(List<DataItem> data)
    {
        return data
            .GroupBy(d => d.Discipline)
            .ToDictionary(
                g => g.Key,
                g => g
                    .GroupBy(d => d.Group)
                    .OrderByDescending(gg => gg.Average(d => d.Mark))
                    .First()
                    .Key
            );
    }
}

class InputData
{
    public string TaskName { get; set; }
    public List<DataItem> Data { get; set; }
}

class DataItem
{
    public string Name { get; set; }
    public string Group { get; set; }
    public string Discipline { get; set; }
    public double Mark { get; set; }
}

class OutputData
{
    public List<object> Response { get; set; }
}
```
В этой программе предполагается, что входной JSON-файл называется "input.json", и результаты будут сохранены в файл "output.json". Вы можете изменить имена файлов в соответствии с вашими потребностями.