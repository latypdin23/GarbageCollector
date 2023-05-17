using GarbageCollector.Model;
using System;

namespace GarbageCollector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Размер памяти в куче в байтах до начала создания объектов
            ShowOnConsoleWithColor(ConsoleColor.Red, $"Размер памяти в управляемой куче в байтах: {GC.GetTotalMemory(false)}");
            ShowOnConsoleWithColor(ConsoleColor.Yellow, $"Количество поколений: {GC.MaxGeneration + 1}");

            //Создали объект типа Employer
            Employer employer = new Employer("Дина", 25);
            Console.WriteLine("\n"+employer.ToString());

            ShowOnConsoleWithColor(ConsoleColor.Red, $"\n Объект employer относится к поколению: {GC.GetGeneration(employer)}");
            ShowOnConsoleWithColor(ConsoleColor.Red, $"Размер памяти в управляемой куче в байтах: {GC.GetTotalMemory(false)}");

            //Создали массив размерности 10000000. Наша цель занять место в памяти.
            object[] array = new object[10000000];

            ShowInfoAboutGCChecking();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new object();
            }
            Console.WriteLine("\n Массив построен.\n");

            ShowOnConsoleWithColor(ConsoleColor.Red, $"Размер памяти в управляемой куче в байтах: {GC.GetTotalMemory(false)}");
            //В стеке убираем ссылку на массив, но объекты в куче остаются
            array = null;
            

            ShowInfoAboutGCChecking();
            var start = DateTime.Now;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\n Сборщик мусора отработал\t" + (DateTime.Now - start).TotalMilliseconds + " \n");
            ShowOnConsoleWithColor(ConsoleColor.Red, $"Размер памяти в управляемой куче в байтах: {GC.GetTotalMemory(false)}");
            ShowOnConsoleWithColor(ConsoleColor.Red, $"Объект employer относится к поколению: {GC.GetGeneration(employer)}");

            ShowInfoAboutGCChecking();

            Console.ReadKey();
        }
        static void ShowInfoAboutGCChecking()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("Поколение 0 проверялось {0} раз", GC.CollectionCount(0));
            Console.WriteLine("Поколение 1 проверялось {0} раз", GC.CollectionCount(1));
            Console.WriteLine("Поколение 2 проверялось {0} раз", GC.CollectionCount(2));
            Console.WriteLine("#############################");
        }
        #region Методы для вывода на экран
        /// <summary>
        /// Выводит на экран текст указанного цвета
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        static void ShowOnConsoleWithColor(ConsoleColor color, String text)
        {
            Console.ForegroundColor = color; // устанавливаем цвет
            Console.WriteLine(text);
            Console.ResetColor(); // сбрасываем в стандартный
        }
        #endregion
    }
}
