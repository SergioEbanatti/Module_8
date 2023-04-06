using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _8_2
{
    internal class Program
    {
        static private Dictionary<ulong, string> _phoneBook;     //Коллекция из номеров телефонов и ФИО владельцев
        static private char _key = 'н';
        static private ulong _phoneNumber;      //Номер телефона
        static private string _userInput;       //Пользовательский ввод
        static private string _ownerFullName;   //ФИО владельца телефона

        static private void Main()
        {
            Console.WriteLine("\t\t\tТелефонная книга\n\n");
            Console.WriteLine("Заполнение телефонной книги:");
            CreatePhoneBook();      //Создаем телефонную книгу и заполняем данными
            SearchOwnerByNumber();      //Ищем владельца по номеру телефона
            Console.ReadKey();
        }

        /// <summary>
        /// Создает коллецию и заполняет значениями
        /// </summary>
        static private void CreatePhoneBook()
        {

            _phoneBook = new Dictionary<ulong, string>();        //Инициализируем коллекцию

            do
            {
                if (PhoneNumberCheck())
                {

                    if (!_phoneBook.ContainsKey(_phoneNumber))        //Проверяем номер на уникальность
                    {
                        Console.Write("Введите ФИО владельца: ");
                        _ownerFullName = Console.ReadLine();
                        _phoneBook.Add(_phoneNumber, _ownerFullName);      //Добавляем новую запись в коллекцию

                        TextNKey("Запись создана. Добавить ещё одну запись? н/д\n");
                    }
                    else TextNKey($"Номер {_phoneNumber} уже есть в телефонной книге," +
                        $" нельзя добавить такой же номер.\nПопробовать снова? н/д\n");
                }
                else _key = 'н';

                Console.Clear();

            } while (char.ToLower(_key) == 'д');

        }


        /// <summary>
        /// Поиск владельца в телефонной книге по номеру телефона
        /// </summary>
        static private void SearchOwnerByNumber()
        {

            Console.WriteLine("\nПоиск по номеру телефона\n");
            do
            {
                if (PhoneNumberCheck())
                {
                    if (_phoneBook.TryGetValue(_phoneNumber, out _ownerFullName))      //Выполняем поиск по номеру и возвращаем ФИО владельца
                        TextNKey($"Запись найдена, это {_ownerFullName}. Выполнить ещё один поиск? н/д\n");
                    else
                        TextNKey("Запись не найдена, попробовать снова? н/д\n");
                }
                else _key = 'н';

            } while (char.ToLower(_key) == 'д');
            Console.Clear();


        }

        /// <summary>
        /// Проверяет номер на соответствие ulong
        /// </summary>
        /// <returns></returns>
        static bool PhoneNumberCheck()
        {
            do
            {
                Console.Write("\n\nВведите номер телефона: +7");
                _userInput = Console.ReadLine();

                if (ulong.TryParse(_userInput, out _phoneNumber))     //Проверяем преобразуется ли строка в ulong, если да, то записываем результат
                    return true;
                else
                    TextNKey("Вы ввели некорректные данные, попробовать снова? н/д\n");

            } while (char.ToLower(_key) == 'д');

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
