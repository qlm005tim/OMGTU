using System;
    public class Car {
        public string Name;
        public int Year;
        public string[] Owners;
        public int[] TOyears;
        public string Color;
        public int Engnumber;

        public Car(string name, int year, string[] owners, int[] toyears, string color, int engnumber) {
            this.Name = name;
            this.Year = year;
            this.Owners = owners;
            this.TOyears = toyears;
            this.Color = color;
            this.Engnumber = engnumber;

        }
    }

    class Program {

        static void Main(string[] args) {
            Car[] CarArr = new Car[5] {
                new Car("mersedes", 2003, new string[] {
                        "Bob",
                        "Rachel"
                        }, new int[] {
                        2000,
                        2004
                        }, "black", 1),
                    new Car("tesla", 2003, new string[] {
                            "Ben",
                            "Lisa",
                            "Rodger"
                            }, new int[] {
                            1999,
                            2004,
                            2002
                            }, "blue", 2),
                    new Car("bmw", 2008, new string[] {
                            "Tom"
                            }, new int[] {
                            2019
                            }, "white", 3),
                    new Car("toyota", 2014, new string[] {
                            "Sarah",
                            "Rachel"
                            }, new int[] {
                            2015,
                            2017
                            }, "green", 4),
                    new Car("lexus", 1997, new string[] {
                            "Colin"
                            }, new int[] {
                            2005
                            }, "purple", 5),
            };

            Console.WriteLine("Введите номер двигателя:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Владельцы машины:");

            for (int i = 0; i < CarArr.Length; i++) {
                if (CarArr[i].Engnumber == number) {
                    for (int j = 0; j < CarArr[i].Owners.Length; j++) {
                        Console.WriteLine(CarArr[i].Owners[j]);
                    }
                }

            }

            Console.WriteLine();

            Console.WriteLine("Введите год тех. осмотра:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Машины:");
            for (int i = 0; i < CarArr.Length; i++) {
                for (int j = 0; j < CarArr[i].TOyears.Length; j++) {
                    if (CarArr[i].TOyears[j] == year) {
                        Console.WriteLine(CarArr[i].Name);
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine("Машины с одним владельцем:");
            for (int i = 0; i < CarArr.Length; i++) {
                if (CarArr[i].Owners.Length == 1) {
                    Console.WriteLine(CarArr[i].Name);
                }
            }

        }
    }
}