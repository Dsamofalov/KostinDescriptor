﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostinDescriptor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            do
            {
                do
                {
                    menu.MenuKey = menu.InitMenu();
                    if ((menu.MenuKey < 1) || (menu.MenuKey > 5))
                    {
                        Console.WriteLine("Неверный выбор в меню. Повторите попытку");
                    }
                } while ((menu.MenuKey < 1) || (menu.MenuKey > 5));

                switch (menu.MenuKey)
                {
                    case 1:
                        menu.CreateArray.GetInfoAboutArray();
                        break;
                    case 2:
                        menu.CreateArray.InitArrayMembers();
                        break;
                    case 3:
                        menu.CreateArray.ReadMemberAdress();
                        break;
                    case 4:
                        menu.CreateArray.WriteMemberAdress();
                        break;
                    case 5: break;
                }
            } while (menu.MenuKey != 5);
            Console.WriteLine("Вы вышли из приложения");
            Console.ReadLine();
        }
    }
    class ArrayInfo
    {
        private int[] CustomArray { get; set; }
        public string Name = null;
        public int Size=-1;
        public int HighBound { get; set; }
        public int LowBound { get; set; }
        public void GetInfoAboutArray()
        {
            HighBound = CustomArray.Max();
            LowBound = CustomArray.Min();
            if (Name==null)
            {
                Console.WriteLine("Массив не инициализирован. Выберите 2 в меню для инициализации ");
            }
            else
            {

                Console.WriteLine("Название массива: {0}", Name);
                Console.WriteLine("Размер массива: {0}",Size.ToString());
                Console.WriteLine("Наибольшее значение массива: {0}", HighBound.ToString());
                Console.WriteLine("Наименьшее значение массива: {0}", LowBound.ToString());
            }
        }
        public void InitArrayMembers()
        {
            if (Size < 1)
            {
                do
                {
                    Console.WriteLine("Введите размер массива числом");
                    string s = Console.ReadLine();
                    int.TryParse(s, out Size);
                    if (Size < 1)
                    {
                        Console.WriteLine("Ошибка. Повторите попытку");
                    }
                } while (Size < 0);
                CustomArray = new int[Size];
                Name = "CustomArray";
                HighBound = CustomArray.Max();
                LowBound = CustomArray.Min();
                Console.WriteLine("Массив успешно инициализирован");
            }
            else
            {
                Console.WriteLine("Массив уже был инициализирован");
            }
        }
        public void ReadMemberAdress()
        {
            if (Size > 0)
            {
                Console.WriteLine("Введите номер элемента массива");
                int number;
                string s = Console.ReadLine();
                int.TryParse(s, out number);
                if ((number >= 0)  &&(number<Size))
                {
                    Console.WriteLine("Значение = {0}", CustomArray.GetValue(number));
                }
                else Console.WriteLine("Неправильный номер");
            }
            else Console.WriteLine("Массив не инициализирован. Выберите 2 в меню для инициализации");
        }
        public void WriteMemberAdress()
        {
            if (Size > 0)
            {
                Console.WriteLine("Введите номер элемента массива");
                int number;
                string s = Console.ReadLine();
                int.TryParse(s, out number);
                if ((number >= 0) && (number < Size))
                {
                    Console.WriteLine("Введите значение элемента массива");
                    int val;
                    string s2 = Console.ReadLine();
                    int.TryParse(s2, out val);
                    CustomArray[number] = val;
                    Console.WriteLine("Записанное значение = {0}", val);
                }
                else Console.WriteLine("Неправильный номер элемента");
            }
            else Console.WriteLine("Массив не инициализирован. Выберите 2 в меню для инициализации");
        }
    }
    class Menu
    {
        public int MenuKey { get; set; }
        public ArrayInfo CreateArray;
        public int InitMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("Введите 1 для вывода информации о массиве");
            Console.WriteLine("Введите 2 для инициализации массива");
            Console.WriteLine("Введите 3 для просмотра  элемента массива");
            Console.WriteLine("Введите 4 для ввода элемента массива");
            Console.WriteLine("Введите 5 для выхода из приложения");
            int key;
            string s = Console.ReadLine();
            int.TryParse(s, out key);
            return key;
        }
        public Menu()
        {
            CreateArray = new ArrayInfo();
        }
    }
}
