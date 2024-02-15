using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp5.Program;
namespace ConsoleApp5
{
    internal class Program
    {
        public class Kabinet
        {
            public int Number { get; set; }
            public int Mesto { get; set; }
            public bool Projector { get; set; }
            public bool Koputers { get; set; }
            public Kabinet(int number, int mesto, bool projector, bool koputers)
            {
                Number = number;
                Mesto = mesto;
                Projector = projector;
                Koputers = koputers;
            }
        }
            public class Menu
            {
                List<Kabinet> kabineti = new List<Kabinet>();
                public void Start()
                {
                    while (true)
                    {
                        Console.WriteLine("1. Создание базы, Добавление элементов базы");
                        Console.WriteLine("2. Вывод всей базы.");
                        Console.WriteLine("3. Модификация элементов по номеру кабинета");
                        Console.WriteLine("4. Выборка кабинетов с количеством посадочных мест превышающим или равным заданному");
                        Console.WriteLine("5. Выборка кабинетов с проектором");
                    Console.WriteLine("6. Выборка кабинетов с компьютеров и количеством посадочных мест либо более");
                    Console.WriteLine("7. Выборка аудиторий на заданном этаже");
                    Console.WriteLine("8. Выход");

                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                CreateDatabase();
                                break;
                            case 2:
                                AddClassroom();
                                break;
                            case 3:
                                ModifyClassroom();
                                break;
                            case 4:
                                SelectClassroomsBySeats();
                                break;
                            case 5:
                                SelectClassroomsByEquipment();
                                break;
                            case 6:
                                Komps();
                                break;
                        case 7:
                            SelectClassroomsByFloor();
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                                Console.WriteLine("Неверный выбор.");
                                break;
                        }
                    }
                }

                public void CreateDatabase()
                {
                int i = 0;
                while (true)
                {
                    i++;
                    int i1;
                    int i2;
                    bool i3;
                    bool i4;
                    Console.WriteLine($"Введите адрес {i} кабинета");
                    i1 = Convert.ToInt32(Console.ReadLine());
                    if (i1 <= 0 || i1>=1000)
                    {
                        Console.WriteLine("Неверный формат");
                        break;
                    }

                    Console.WriteLine($"Введите колво мест {i}");
                    i2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"есть проектора в {i} кабинете");
                    i3 = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine($"есть компутеры в {i} кабинете");
                    i4 = Convert.ToBoolean(Console.ReadLine());


                    kabineti.Add(new Kabinet(i1, i2, i3, i4));
                    foreach (Kabinet p in kabineti)
                    {
                        Console.WriteLine("номер каб.\t" + p.Number + "\nКол-во мест\t" + p.Mesto + "\nпрожекторы есть/нет\t" + p.Projector + "\nКомпутеры есть/нет\t" + p.Koputers + '\n');
                    }
                    Console.WriteLine("Для выхода введите '0' ");
                }
            }

            private void AddClassroom()
            {
                foreach(Kabinet p in kabineti)
                {
                    Console.WriteLine("номер каб.\t" + p.Number + "\nКол-во мест\t" + p.Mesto + "\nпрожекторы есть/нет\t" + p.Projector + "\nКомпутеры есть/нет\t" + p.Koputers + '\n');
                }
            }

                private void ModifyClassroom()
                {
                Console.WriteLine("Введите номер кабинета которого вы хотите изменить");
                int otborka_kab;
                otborka_kab=Convert.ToInt32(Console.ReadLine());
                foreach (Kabinet p in kabineti)
                {
                    if (otborka_kab == p.Number)
                    {
                        Console.WriteLine("1)номер каб.\t" + p.Number + "\n2)Кол-во мест\t" + p.Mesto + "\n3)прожекторы есть/нет\t" + p.Projector + "\n4)Компутеры есть/нет\t" + p.Koputers + '\n');
                        Console.WriteLine("Выберите, какой параметр вы хотите изменить (цифра от 1 до 4), если хотите выйти, то 0");
                        int vibor;
                        vibor = Convert.ToInt32(Console.ReadLine());
                        if (vibor == 1)
                        {
                            Console.WriteLine("Изменение номера кабинета для кабинета " + p.Number + ". введите число");
                            p.Number = Convert.ToInt32(Console.ReadLine());
                        }
                        if (vibor == 2)
                        {
                            Console.WriteLine("Изменение количества мест для кабинета " + p.Number + ". введите число");
                            p.Mesto = Convert.ToInt32(Console.ReadLine());
                        }
                        if (vibor == 3)
                        {
                            Console.WriteLine("Изменение статус проектора для кабинета " + p.Number + ". введите True/False");
                            p.Projector = Convert.ToBoolean(Console.ReadLine());
                        }
                        if (vibor == 4)
                        {
                            Console.WriteLine("Изменение статус компьютеров для кабинета " + p.Number + ". введите True/False");
                            p.Koputers = Convert.ToBoolean(Console.ReadLine());
                        }
                        if (vibor == 0)
                        {
                            Menu menu = new Menu();
                            menu.Start();
                        }
                    }
                }
            }

                private void SelectClassroomsBySeats()
                {
                int otborka_mest;
                Console.WriteLine("отборка по количеству мест. Введите количество мест");
                otborka_mest = Convert.ToInt32(Console.ReadLine());
                foreach (Kabinet p in kabineti)
                {
                    if (otborka_mest <= p.Mesto)
                    {
                        Console.WriteLine("1)номер каб.\t" + p.Number + "\n2)Кол-во мест\t" + p.Mesto + "\n3)прожекторы есть/нет\t" + p.Projector + "\n4)Компутеры есть/нет\t" + p.Koputers + '\n');
                    }
                }
            }

                private void SelectClassroomsByEquipment()
                {
                bool otborka_projector;
                Console.WriteLine("отборка по проекторам. Введите True/False");
                otborka_projector = Convert.ToBoolean(Console.ReadLine());
                foreach (Kabinet p in kabineti)
                {
                    if (otborka_projector == p.Projector)
                    {
                        Console.WriteLine("1)номер каб.\t" + p.Number + "\n2)Кол-во мест\t" + p.Mesto + "\n3)прожекторы есть/нет\t" + p.Projector + "\n4)Компутеры есть/нет\t" + p.Koputers + '\n');
                    }
                }
            }

            private void Komps()
            {
                bool otborka_Kompbool;
                Console.WriteLine("отборка по компьютерам. Введите True/False");
                otborka_Kompbool = Convert.ToBoolean(Console.ReadLine());
                int otborka_mest;
                Console.WriteLine("отборка по количеству мест. Введите количество мест");
                otborka_mest = Convert.ToInt32(Console.ReadLine());
                foreach (Kabinet p in kabineti)
                {
                    if (otborka_Kompbool == p.Projector)
                    {
                        if (otborka_mest== p.Mesto) {
                            Console.WriteLine("1)номер каб.\t" + p.Number + "\n2)Кол-во мест\t" + p.Mesto + "\n3)прожекторы есть/нет\t" + p.Projector + "\n4)Компутеры есть/нет\t" + p.Koputers + '\n');
                        }
                    }
                }
            }
            private void SelectClassroomsByFloor()
            {
                int otborka_floor;
                Console.WriteLine("отборка по этажу. Введите этаж от 1 до 9");
                otborka_floor = Convert.ToInt32(Console.ReadLine());
                foreach (Kabinet p in kabineti)
                {
                    if (otborka_floor == p.Number/100)
                    {
                        Console.WriteLine("1)номер каб.\t" + p.Number + "\n2)Кол-во мест\t" + p.Mesto + "\n3)прожекторы есть/нет\t" + p.Projector + "\n4)Компутеры есть/нет\t" + p.Koputers + '\n');
                    }
                }
            }
        }
            static void Main(string[] args)
        {
            /* создаем 2 класса 1) меню (1-создание базы, добавлениие элементов базы, модификация элементов по номеру кабинета, выборка кабинетов с количеством посадочных мест превышающим или равным заданному
             * выборка кабинетов с проектором, с компьютерами и количством посадочных мест равных либо более) выборкам аудиторий на заданном этаже, выход
             * класс кабинетов - номер кабинета, 1 цифра этаж, 2 и 3 - кабинет сам, количество посадочных мест, наличие проектора да нет, наличие компов да/нет, количество посадочных = количество компутеров если они есть
             * предусмотреть возврат на основное мену. предусмотреть проверку данных если база незаполненна то выборку сделать нельзя.
             * когда начинаем модифицировать данные то подменю либо спросить данные, числовые данные это числовые, номер кабинета не превышает 999
             * main - меню, кабинеты хоть как 
             */
            Menu menu = new Menu();
            menu.Start();
            Console.ReadKey();
        }
    }
}
