using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_1
{
    internal class Program
    {
        private static int listCapacity = 100;      //Размер коллекции.


        private static void Main()
        {
            int randomizeMinValue = 0;      //Минимальное значение значение для рандомайзера.
            int randomizeMaxValue = 100;        //Максимальное значение значение для рандомайзера.
            int deleteMinValue = 25;        //Миниальное значение для удаления.
            int deleteMaxValue = 50;        //Максимальное значение для удаления.

            List<int> numbersList = new List<int>();
            FillListNumbers(numbersList, randomizeMinValue, randomizeMaxValue);
            PrintList(numbersList);
            DeleteNumbersFromList(numbersList, deleteMinValue, deleteMaxValue);
            PrintList(numbersList);
            Console.ReadKey();
        }

        /// <summary>
        /// Заполняет коллекции случайными значениями в заданном диапазоне чисел.
        /// </summary>
        /// <param name="randomizeNumbersList">Заполняемая коллекция.</param>
        /// <param name="minValue">Минмальное значение диапазона.</param>
        /// <param name="maxValue">Максимальное значение диапазона.</param>
        private static void FillListNumbers(List<int> randomizeNumbersList, int minValue, int maxValue)
        {
            Random rnd = new Random();      //Создаем генератор рандомных чисел.

            for (int i = 0; i < listCapacity; i++)
            {
                randomizeNumbersList.Add(rnd.Next(minValue, maxValue + 1));     /*Заполняем коллекцию значениями. maxValue + 1,
                                                                                чтобы верхний предел был включен в рандомайзер.*/
            }
        }

        /// <summary>
        /// Удаляет числа из коллекции в заданном диапазоне.
        /// </summary>
        /// <param name="formattedList">Коллекция, которую необходимо отформатировать</param>
        /// <param name="minValue">Минимальное значение диапазона.</param>
        /// <param name="maxValue">Максимальное значение диапазона.</param>
        private static void DeleteNumbersFromList(List<int> formattedList, int minValue, int maxValue)
        {
            for (int i = 0; i < formattedList.Count; i++)
            {
                if (formattedList[i] > minValue && formattedList[i] < maxValue)
                {
                    formattedList.RemoveAt(i);
                    i--;        //Минусуем i т.к. после удаления элемента, индексы смещаются.
                }
            }
        }

        /// <summary>
        /// Вывод на экран коллекции.
        /// </summary>
        /// <param name="ListToPrint">Коллекция для вывода.</param>
        private static void PrintList(List<int> ListToPrint)
        {
            Console.Write("\n\n\n\t");

            for (int i = 0; i < ListToPrint.Count; i++)
            {
                Console.Write($"{ListToPrint[i]}\t");
            }
        }

    }
}
