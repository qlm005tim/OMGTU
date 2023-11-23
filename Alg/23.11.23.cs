//описать класс студент, сделать конструкторы, свойства, в головной программе создать массив экземпляров класса, в классе написать методы, выводящие на экран поля экземпляра класса, поиск по году и группе.
using System;
public class Student
{
string fullName;
int yearOfBirth;
string groupName;

public string FullName
{
get { return fullName; }
set { fullName = value; }
}

public int YearOfBirth
{
get { return yearOfBirth; }
set { yearOfBirth = value; }
}

public string GroupName
{
get { return groupName; }
set { groupName = value; }
}

public Student(string fullName, int yearOfBirth, string groupName)
{
FullName = fullName;
YearOfBirth = yearOfBirth;
GroupName = groupName;
}

public void Printcl()
{
Console.WriteLine($"ФИО: {FullName}, Год рождения: {YearOfBirth}, Название группы: {GroupName}");
}

public void PrintByYear(int year)
{
if (YearOfBirth == year)
{
Printcl();
}
}

public void PrintByGroup(string group)
{
if (GroupName == group)
{
Printcl();
}
}
}

class Program
{
static void Main()
{
Student[] students = new Student[3];
students[0] = new Student("Иванов И. И.", 2001, "Группа 1");
students[1] = new Student("Петров П. П.", 2004, "Группа 2");
students[2] = new Student("Сидоров С. С.", 2001, "Группа 1");

foreach (Student student in students)
{
student.Printcl();
}

Console.WriteLine("Студенты, родившиеся в 2004 году:");
foreach (Student student in students)
{
student.PrintByYear(2004);
}

Console.WriteLine("Студенты из группы 1:");
foreach (Student student in students)
{
student.PrintByGroup("Группа 1");
}
}
}
