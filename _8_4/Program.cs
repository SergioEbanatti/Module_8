using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _8_4
{
    internal class Program
    {

        static private XElement _person = new XElement("Person");
        static private XElement _address = new XElement("Address");
        static private XElement _street = new XElement("Street");
        static private XElement _houseNumber = new XElement("HouseNumber");
        static private XElement _flatNumber = new XElement("FlatNumber");
        static private XElement _phones = new XElement("Phones");
        static private XElement _mobilePhone = new XElement("MobilePhone");
        static private XElement _flatPhone = new XElement("FlatPhone");
        static private XAttribute _fullName = new XAttribute("name", "");

        static private void Main()
        {
            Console.WriteLine("\t\t\tЗаписная книжка\n\n");

            CreateDocHierarchy();       //Создаем иерархию документа
            CreateNote();       //Формируем запись
            SaveDoc("_personInfo.xml");     //Сохраняем
            ReadXML("_personInfo.xml");     //Выводим

            Console.ReadKey();
        }

        /// <summary>
        /// Создает иерархию документа xml
        /// </summary>
        static private void CreateDocHierarchy()
        {
            _address.Add(_street, _houseNumber, _flatNumber);
            _phones.Add(_mobilePhone, _flatPhone);
            _person.Add(_address, _phones, _fullName);
        }

        /// <summary>
        /// Создает запись из пользовательского ввода
        /// </summary>
        static private void CreateNote()
        {
            var dictionaryLineNames = FillOutDictionary(); //Формируем коллекцию Dictionary из наименований и значений XElement

            Console.Write("Создание новой записи " +
                "(необходимо заполнить следующие данные):\n\n" +
                "ФИО: ");
            _fullName.Value = Console.ReadLine();       //Отдельно заполняем _fullName т.к. это не XElement, а XAttribute

            foreach (var item in dictionaryLineNames)   //Циклом заполняем остальные данные XElement
            {
                Console.Write($"{item.Key}");     //Выводим на экран наименование заполняемого поля
                item.Value.Value = Console.ReadLine();      //Заполняем значение XElement пользовательским вводом
            }
        }

        /// <summary>
        /// Создает Dictionary, где ключ - наименование, а значение - соответствующий XElement
        /// </summary>
        /// <returns>Коллекция Dictionary</returns>
        static private Dictionary<string, XElement> FillOutDictionary()
        {
            Dictionary<string, XElement> dictionaryLineNames = new Dictionary<string, XElement>()       //Создаем и заполняем коллекцию из наименований и значений XElement
            {
                { "Улица: ", _street},
                { "Номер дома: ", _houseNumber},
                { "Номер квартиры: ", _flatNumber},
                { "Мобильный телефон: ", _mobilePhone},
                { "Домашний телефон: ", _flatPhone},
            };
            return dictionaryLineNames;
        }

        /// <summary>
        /// Сохраняет документ на диске
        /// </summary>
        /// <param name="docPathName">Путь и имя сохраняемого файла</param>
        static private void SaveDoc(string docPathName)
        {
            _person.Save(docPathName);
        }

        /// <summary>
        /// Считывает XML файл и выводит результат на экран
        /// </summary>
        /// <param name="docPathName">путь и имя файла, который нужно считать</param>
        static private void ReadXML(string docPathName)
        {
            string xml = System.IO.File.ReadAllText(docPathName);       //Считываем файл на диске и помещаем в строку
            Console.WriteLine("\n\n\t\t\tРезультат:\n\n" + xml);        //Выводим результат на экран
        }
    }
}
