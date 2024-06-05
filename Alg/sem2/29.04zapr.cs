//Алгоритмизация

//Дан массив или список, состоящий из элементов типа string, необходимо составить и выполнить запрос на отбор элементов четной длины.
//После выполнения запроса, необходимо удалить каждый второй элемент и выполнить запрос еще раз.
using System;
using System.Linq;
using System.Collections.Generic;

class Program {
  static void Main() {
      
    List<string> strs = new List<string>() {
      "hffh",
      "kflflggg",
      "tu",
      "49jf",
      "899",
      "l;f",
      "stroka",
      "jkflejfoerjf",
      "udiuwefyheriufgyrieye",
      "uyhfuehf8iu"
    };

    Console.WriteLine("Исходный список строк:");

    foreach (string str in strs) 
    {
      Console.Write("{0} ", str);
    }
    Console.WriteLine();
    var q1 = from str in strs where (str.Length % 2 == 0) select str;

    Console.WriteLine("элементы с четной длиной:");

    foreach (string str in q1) 
    {
      Console.Write("{0} ", str);
    }

    strs = strs.Where((x, i) => i % 2 == 0).ToList();//каждый второй элемент списка удаляется to list немедленно вычис запрос и возвращает лист с резтом

    q1 = from str in strs where (str.Length % 2 == 0) select str;
    Console.WriteLine();
    Console.WriteLine("элементы с четной длиной, запрос по измененному списку :");

    foreach (string str in q1) {
      Console.Write("{0} ", str);
    }
  }
}
