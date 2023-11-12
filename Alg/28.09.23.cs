/*для 10 вводимых элементов
1 колво отрицательных
2 оканч на 3
3 сумма элементов  с одинаковым окончанием в 3 и 5 сс
4 произведение неотриц чет элементов
для н вводимых элементов 
1 колво элементов значения которых меньше предыдущего 
2 колво эл значения которых меньше всех предыд
3 опред колво смены знаков в последовательности*/
using System;
class HelloWorld {
  static void Main() {
    int count = 0;

        for (int i = 0; i < 10; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < 0) {
                ++count;
            }
        }
        Console.WriteLine(count);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int count = 0;

        for (int i = 0; i < 10; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n % 10==3) {
                ++count;
            }
        }
        Console.WriteLine(count);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int sum = 0;

        for (int i = 0; i < 10; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n%3==n%5) {
                sum+=n;
            }
        }
        Console.WriteLine(sum);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int m = 1;

        for (int i = 0; i < 10; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 0 && n%2==0) {
                m*=n;
            }
        }
        Console.WriteLine(m);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int count = 0;
    int pre_n = 0;
    bool pre_is_exist = false;
    Console.WriteLine("Введите N:");
    int N = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Введите N чисел:");
    for (int i = 0; i < N; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (!pre_is_exist) {
                pre_is_exist = true;
            } 

            if (n < pre_n) ++count;

            if (pre_is_exist) {
                pre_n = n;
            }
        }
        Console.WriteLine(count);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int count = 0;
    int min_n = int.MaxValue;
    Console.WriteLine("Введите N:");
    int N = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Введите N чисел:");
    for (int i = 0; i < N; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n < min_n) ++count;
            if (n < min_n) {
                min_n = n;
            }
     }
        Console.WriteLine(count-1);
    }
}

using System;
class HelloWorld {
  static void Main() {
    int count = 0;
    bool pre_is_positive = false;
    bool pre_is_exist = false;
    Console.WriteLine("Введите N:");
    int N = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Введите N чисел:");
    for (int i = 0; i < N; i++) {
            int n = Convert.ToInt32(Console.ReadLine());
            if (!pre_is_exist) {
                pre_is_exist = true;
            } else {
                if (pre_is_positive ^ n >= 0) ++count;
            }
            pre_is_positive = (n >= 0);
        }
        Console.WriteLine(count);
    }
}
