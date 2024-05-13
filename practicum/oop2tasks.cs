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




// Класс для данных студента
public class StudentData
{
    public string name { get; set; }
    public string group { get; set; }
    public string discipline { get; set; }
    public int mark { get; set; }
}


// Класс для входных данных
public class InputData
{
    public string taskName { get; set; }
    public List<StudentData> data { get; set; }
}


public class OutputData
{
    public List<Dictionary<string, object>> Response { get; set; }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
// Путь к входному и выходному файлам
        string inputFilePath = "input.json";
        string outputFilePath = "output.json";

        // Чтение входных данных из файла
        string inputJson = File.ReadAllText(inputFilePath);
        InputData inputData = JsonConvert.DeserializeObject<InputData>(inputJson);

        // Вычисление среднего балла для каждого студента
        var studentGPAs = inputData.data
            .GroupBy(s => s.name)
            .Select(g => new 
            {
                Cadet = g.Key,
                GPA = g.Average(s => s.mark)
            });

        // Выбор студентов с наивысшим средним баллом
        var highestGPA = studentGPAs.Max(s => s.GPA);
        var bestStudents = studentGPAs.Where(s => s.GPA == highestGPA);

        // Формирование выходных данных
        OutputData outputData = new OutputData
        {
            Response = bestStudents.Select(s => new Dictionary<string, object>
            {
                { "Cadet", s.Cadet },
                { "GPA", s.GPA }
            }).ToList()
        };

        // Запись выходных данных в файл
        string outputJson = JsonConvert.SerializeObject(outputData, Formatting.Indented);
        File.WriteAllText(outputFilePath, outputJson);

        Console.WriteLine("Результат сохранен в файл: " + outputFilePath);


using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
// Пути к входному и выходному файлам (измените при необходимости)
        string inputFilePath = "input2.json";
        string outputFilePath = "output2.json";
            // Чтение входных данных из файла
            string inputJson = File.ReadAllText(inputFilePath);
            InputData inputData = JsonConvert.DeserializeObject<InputData>(inputJson);

            // Вычисление среднего балла для каждой дисциплины
            var disciplineAverages = inputData.data
                .GroupBy(s => s.discipline)
                .Select(g => new Dictionary<string, double>
                {
                    { g.Key, g.Average(s => s.mark) }
                });

            // Формирование выходных данных
            OutputData outputData = new OutputData
            {
                Response = disciplineAverages.ToList()
            };

            // Запись выходных данных в файл
            string outputJson = JsonConvert.SerializeObject(outputData, Formatting.Indented);
            File.WriteAllText(outputFilePath, outputJson);

            Console.WriteLine("Результат сохранен в файл: " + outputFilePath);


using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
// Пути к входному и выходному файлам (измените при необходимости)
        string inputFilePath = "input3.json";
        string outputFilePath = "output3.json";
            // Чтение входных данных из файла
            string inputJson = File.ReadAllText(inputFilePath);
            InputData inputData = JsonConvert.DeserializeObject<InputData>(inputJson);

            // Вычисление среднего балла для каждой группы по каждой дисциплине
            var groupDisciplineAverages = inputData.data
                .GroupBy(s => new { s.discipline, s.group })
                .Select(g => new
                {
                    Discipline = g.Key.discipline,
                    Group = g.Key.group,
                    GPA = g.Average(s => s.mark)
                });

            // Выбор групп с наивысшим средним баллом для каждой дисциплины
            var bestGroups = groupDisciplineAverages
                .GroupBy(g => g.Discipline)
                .Select(g => g.OrderByDescending(x => x.GPA).First());

            // Формирование выходных данных
            OutputData outputData = new OutputData
            {
                Response = bestGroups.Select(g => new Dictionary<string, object>
                {
                    { "Discipline", g.Discipline },
                    { "Group", g.Group },
                    { "GPA", g.GPA }
                }).ToList()
            };

            // Запись выходных данных в файл
            string outputJson = JsonConvert.SerializeObject(outputData, Formatting.Indented);
            File.WriteAllText(outputFilePath, outputJson);

            Console.WriteLine("Результат сохранен в файл: " + outputFilePath);


using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
// Пути к входному и выходному файлам
        string inputFilePath = "input2.json";
        string outputFilePath = "output2.json";
            // Чтение входных данных из файла
            string inputJson = File.ReadAllText(inputFilePath);
            InputData inputData = JsonConvert.DeserializeObject<InputData>(inputJson);

            // Вычисление среднего балла для каждой дисциплины
            var disciplineAverages = inputData.data
                .GroupBy(s => s.discipline)
                .Select(g => new Dictionary<string, double>
                {
                    { g.Key, g.Average(s => s.mark) }
                });

            // Формирование выходных данных
            OutputData outputData = new OutputData
            {
                Response = disciplineAverages.ToList()
            };

            // Запись выходных данных в файл
            string outputJson = JsonConvert.SerializeObject(outputData, Formatting.Indented);
            File.WriteAllText(outputFilePath, outputJson);

            Console.WriteLine("Результат сохранен в файл: " + outputFilePath);