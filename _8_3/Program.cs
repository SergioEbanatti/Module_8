using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_3
{
    internal class Program
    {
        static private HashSet<int> _hashSet;       //Коллекция из уникальных элементов
        static private int _userNumber;             //Текущее введенное пользовательское число
        static private char _key = 'н';

        static private void Main()
        {
            _hashSet = new HashSet<int>();      //Инициализация коллекции

            Console.WriteLine("\t\t\tПроверка повторов");
            UserInput();        //Добавляем элементы в коллекцию
            Console.WriteLine("\t\t\tВывод полученной коллекции:\n\n");
            ShowHashSet();      //Выводим коллекцию на экран
            Console.ReadKey();
        }

        /// <summary>
        /// Обрабатывает пользователский ввод
        /// </summary>
        static private void UserInput()
        {
            do
            {
                Console.WriteLine("\n\nВведите число:");
                string userInput = Console.ReadLine();

                if (UserInputCheck(userInput))      //Проверяем введено ли число
                {
                    if (AddNumber(_userNumber))     //Добавляем элемент в коллекцию
                        TextNKey("Число добавлено в коллекцию. Добавить ещё одно число? н/д");

                    else TextNKey("Число уже вводилось ранее, попробовать ещё раз? н/д");
                }

                else TextNKey("Некорректный ввод, попробовать ещё раз? н/д");
                Console.Clear();

            } while (char.ToLower(_key) == 'д');
        }

        /// <summary>
        /// Проверяет корректен ли пользовательский ввод
        /// </summary>
        /// <param name="userInput">Пользовательская строка</param>
        /// <returns>true, если строка преобразовывается в int, иначе false</returns>
        static private bool UserInputCheck(string userInput)
        {
            if (Int32.TryParse(userInput, out _userNumber)) return true;        //Проверка на преобразование string в int и запись в переменную
            return false;
        }

        /// <summary>
        /// Выводит полученную коллекцию на экран
        /// </summary>
        static private void ShowHashSet()
        {
            foreach (var e in _hashSet)
                Console.Write($"{e} ");
        }

        /// <summary>
        /// Выполняет проверку на уникальность и добавляет значение в коллекцию
        /// </summary>
        /// <param name="numberToAdd">число, которое нужно добавить</param>
        /// <returns>true, если число добавлен, иначе false</returns>
        static private bool AddNumber(int numberToAdd)
        {
            if (_hashSet.Add(numberToAdd)) return true;     //Проверяем значение на уникальность и добавляем в коллекцию
            return false;
        }

        /// <summary>
        /// Выводит текст на экран и меняет значение key
        /// </summary>
        /// <param name="text"></param>
        static private void TextNKey(string text)
        {
            Console.Write(text);
            _key = Console.ReadKey(true).KeyChar;
        }

    }
}
