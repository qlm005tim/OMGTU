Алгоритмизация: 
"""
Задача на стэк (единственный):
1) Имеется выражение, содержащее 3 вида скобок: () {} [] (Пример - a + b / {f - c}...)
Проверить правильность скобок - исключить )( {(}) и так далее
2) Имеется некоторое выражение: преобразовать его, построив обратную Польскую запись (ручками),
На основе польской записи программа выполняет вычисления, обработать корректность входа
Пример польской записи: ab+3* (сначала 2 операнда, потом знак операции)
"""
using System;
using System.Collections;
using System.Collections.Generic;

class Program {
  public static void Main(string[] args) {
      
    Console.WriteLine("Введите выражение со скобками: ");
    string str = Console.ReadLine();
    
    char[] brekets = new char[] {'(', ')', '[', ']', '{', '}'};//виды скобок

    Stack<char> stack = new Stack<char>();

    foreach (char c in str) {
        
      int index = Array.IndexOf(brekets, c);
      
      if (c == '(' || c == '[' || c == '{') {
        stack.Push(c);
      } 
      
      else if (index != -1) //закрывающая скобка
      {
        if (stack.Count > 0 && stack.Peek() == brekets[index - 1])//найдена парная открывающаяся на вершине стека
        {
          stack.Pop();
        } 
        else {
          stack.Push(c);
        }
      }
    }

    Console.WriteLine();

    if (stack.Count > 0)//в стеке остались непарные скобки
    {
      Console.WriteLine("Скобки расставленны неправильно");
    } 
    else {
      Console.WriteLine("Скобки расставленны правильно");
    }
  }
}


                                              
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Collections;
using System.Threading.Tasks;

class Program
{
    private static int GetPriority(char op)//определение приоритетов операций
    {
        switch (op)
        {

            case '^':
                return 3;
            case '*':
            case '/':
                return 2;
            case '+':
            case '-':
                return 1;
            case '(':
                return 0;
            default:
                return -1;
        }
    }

    

    private static string GetStringNum(string inp_str, ref int pos)//получает число из цифр в строковом виде из исходной строки
    {
        //	Хранит стр число на выход
        string strNum = "";

        //	Перебирает строку начиная с определенной позиции(индекса) 
        for (; pos < inp_str.Length; pos++)
        {
            //	Разбираемый символ строки
            char n = inp_str[pos];

            //	Проверяет, является символ числом
            if (Char.IsDigit(n))
                //	Если да - прибавляет к строке
                strNum += n;
            else
            {
                //	Если нет, то перемещает счётчик к предыдущему символу(цифре)
                pos--;
                //	И выходит из цикла
                break;
            }
        }

        //	Возвращает число
        return strNum;
    }


    private static string InfixToPostfix(string input_str)//преобразует в польскую
    {
        Stack<char> stack = new Stack<char>();
        string output_str = "";// выходная строка с польской записью

        for (int i = 0; i < input_str.Length; i++)//цикл по введенной строке
        {
            char ch = input_str[i];

            if (Char.IsDigit(ch))
            {
                output_str += GetStringNum(input_str, ref i) + " ";
            }

            else if (ch == '(')
            {
                stack.Push(ch);
            }

            else if (ch == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    output_str += stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek() != '(')
                {
                    return "Не согласованы скобки";
                }

                stack.Pop(); // Удаляет '('
            }

            else if ("+-*/^".Contains(ch))//знак операции
            {
                while (stack.Count > 0 && GetPriority(ch) <= GetPriority(stack.Peek()))
                {
                    output_str += stack.Pop();
                }

                stack.Push(ch);
            }
        }

        while (stack.Count > 0)//после прочтения строки
        {
            if (! "+-*/^".Contains(stack.Peek()))
            {
                return "Не согласованы скобки";
            }
            output_str += stack.Pop();//оставшееся в стеке в выходную строку
        }

        return output_str;
    }

    private static double Do_op(char op,double first, double second)//выполнение операции +-*/^
    {
        if (op == '+')
        {
            return first + second;
        }
        else if (op == '-')
        {
            return first - second;
        }
        else if (op == '*')
        {
            return first * second;
        }
        else if (op == '/')
        {
            if (second == 0)//проверка деления на 0
            {
                throw new DivideByZeroException("Деление на ноль!");
            }
            return first / second;
        }
        else if (op == '^')
        {
            return Math.Pow(first, second);
        }
        else { throw new InvalidOperationException("Недопустимая операция"); }
        
    }

    private static double Res_poland(string pol_str)//вычисление построенной польской записи
    {
        Stack<double> nums = new Stack<double>();

        for (int i=0; i<pol_str.Length;i++)
        {
            char c = pol_str[i];
            if (Char.IsDigit(c))//число в стек
            {
                string num = GetStringNum(pol_str, ref i);
                nums.Push(Convert.ToDouble(num));
            }

            else if ("+-*/^".Contains(c))
            {

                if (nums.Count < 2)//обработка отсутствия операнда для бинарной операции
                {
                    throw new InvalidOperationException("Отсутствие чисел для операции");
                }

                double second = nums.Pop();
                double first = nums.Pop();

                nums.Push(Do_op(c, first, second));//результат операции в стек
            }
        }
        
        if (nums.Count != 1)//после прочтения всей польской записи в стеке не только один результат
        {
            throw new InvalidOperationException("В выражении остались необработанные числа или знаки");
        }

        return nums.Peek();//на вершине стека результат
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите команду (1-Вычисление польской записи, 2-Об авторе программы, 3-Описание постановки задачи, 4-Выход, 5-Возврат в главное меню): ");
            string user_inp = Console.ReadLine();
            if (user_inp == "1")
            {
                //string input_str = "(10-15)*3";
                //string input_str = "+-";
                //string input_str = "+-33";
                //string input_str = "3+4*2/(5-5)^3";
                //string input_str = "3+4*(2/(5-5)^3";
                //string input_str = "15/(7-(1+1))3-(2+(1+1))*15/(7-(200+1))*3-(2+(1+1))*(15/(7-(1+1))*3-(2+(1+1))+15/(7-(1+1))*3-(2+(1+1)))";
                string input_str = "15/(7-(1+1))*3-(2+(1+1))*15/(7-(200+1))*3-(2+(1+1))*(15/(7-(1+1))*3-(2+(1+1))+15/(7-(1+1))*3-(2+(1+1)))";

                string output_str = InfixToPostfix(input_str);
                Console.WriteLine("Обратная польская запись " + output_str);

                try
                {
                    double result = Res_poland(output_str);
                    Console.WriteLine("Результат вычисления: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
            else if (user_inp == "2")
            {
                Console.WriteLine("Об авторе программы");
            }
            else if (user_inp=="3")
            {
                Console.WriteLine("Задача: преобразовать выражение, содержащее круглые скобки и знаки операций +-*/^ в обратную польскую запись и вычислить ее значение");
            }
            else if(user_inp=="4")
            {
                Console.WriteLine("Завершение работы");
                break;
            }
            else if (user_inp=="5")
            {
                continue;
            }
            else { Console.WriteLine("Некорректный ввод команды"); break; }
        }
        
    }
}
