using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task2
{
    internal class Program
    {
        static List<string> names = new List<string>() { "Elizabet", "Johann", "Victoria", "Sebastian", "Steven" };

        static void Main(string[] args)
        {
            // descending - нисходящий, вверху списка будут имена с последними буквами(по возрастанию)
            // ascending - восходящий, вверху списка будут имена с первыми буквами(по убыванию)
            UserChoise userChoise = new UserChoise();
            //регистрация события и перехватывание
            userChoise.ChoiseDoneEvent += KeyPressedHandler;
            //вызов метода в классе-подписчике
            userChoise.StartRead();

        }
        // перехватчик события - метод с сигнатурой делегата
        public static void KeyPressedHandler(ConsoleKeyInfo PressedKey)
        {
            // сортировка и вывод
            switch (PressedKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        // сортировка по возрастанию
                        // " из Имя в Именах Упорядочить Имя по Возрастанию, Добавить Имя в collection"
                        var descending = from name in names
                                         orderby name descending
                                         select name;
                        foreach (var item in descending)
                        {
                            WriteLine(item);
                        }
                        WriteLine("Нажмите любую кнопку.");
                        ReadKey();
                    }
                    break;
                case ConsoleKey.D2:
                    {
                        // сортировка по убыванию
                        var ascending = from name in names
                                        orderby name ascending
                                        select name;
                        WriteLine();
                        foreach (var item in ascending)
                        {
                            WriteLine(item);
                        }
                        WriteLine("Нажмите любую кнопку.");
                        ReadKey();
                    }
                    break;
            }
        }

    }
    // класс-подписчик
    class UserChoise
    {
        public delegate void ChoiseDone(ConsoleKeyInfo PressedKey);
        public event ChoiseDone ChoiseDoneEvent;
        static MyException myException = new MyException();
        public static ConsoleKeyInfo PressedKey;
        public void StartRead()
        { 
            // бесконечный цикл, выбираем тип сортировки
            while (true)
            {
                try
                {
                    Clear();
                    WriteLine("Чтобы выбрать сортировку по возрастанию, нажмите клавишу 1. Для сортировки по убыванию нажмите клавишу 2");
                    PressedKey = ReadKey();
                    WriteLine();
                    if ((PressedKey.Key != ConsoleKey.D1) && (PressedKey.Key != ConsoleKey.D2))
                    {
                        throw myException;
                    }
                    // вызываем метод, который в свою очередь запускает событие.
                    OnChoiseDone(ref PressedKey);
                }
                catch (MyException)
                {
                    WriteLine();
                    WriteLine(myException.Message);
                    WriteLine("Нажмите любую кнопку.");
                    ReadKey();
                    Clear();
                }
                
            }


        }
        protected virtual void OnChoiseDone(ref ConsoleKeyInfo PressedKey)
        {
            // запускаем событие
            ChoiseDoneEvent.Invoke(PressedKey);
        }
        
    }
    // собственный тип исключения
    class MyException : Exception
    {
        static string message = "Добрый вечер, не та клавиша.";
        public MyException() : base(message)
        {

        }
    }
}
