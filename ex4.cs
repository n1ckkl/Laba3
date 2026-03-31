using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

class Csharp
{
    // В одномерном массиве, состоящем из n вещественных элементов, вычислить: 2 1)
    // сумму элементов массива с нечетными номерами; 2) сумму элементов массива,
    // расположенных между первым и последним отрицательными элементами; 3)
    // количество элементов массива, равных нулю; 4) сумму элементов массива,
    // расположенных после минимального элемента. Сжать массив, удалив из него все
    // элементы, модуль которых не превышает 1 Освободившиеся в конце массива
    // элементы заполнить нулями.

    private static void Init()
    {
        System.Console.WriteLine("Для выхода из программы введите ПРОБЕЛ или ENTER");
        while (true)
        {
            Console.Clear();
            System.Console.WriteLine("\nВведите число n:");
            string? userInputN = System.Console.ReadLine();
            if (IsSpacePressed(userInputN))
            {
                System.Console.WriteLine("Программа завершена");
                break;
            }
            int numberN = IsNumberNValid(userInputN);
            switch (numberN)
            {
                case 0:
                System.Console.WriteLine("Вы ввели не число");
                continue;
                case -1:
                System.Console.WriteLine("Вы ввели число, меньшее или равное нулю");
                continue;
                case -2:
                System.Console.WriteLine("Вы ввели слишком большое число");
                continue;
                default:
                break;
            }
            List<double> randomGeneratedValues = ListWithRandomNums(numberN);
            System.Console.WriteLine("Ваш массив: " + string.Join(" ", randomGeneratedValues));
            System.Console.WriteLine("Введите номер необходимого действия над массивом: ");
            System.Console.WriteLine("- введите 1 для нахождения суммы элементов с нечетными номерами;");
            System.Console.WriteLine("- введите 2 для нахождения суммы элементов, расположенных между первым и последним отрицательными элементами;");
            System.Console.WriteLine("- введите 3 для нахождения кол-ва элементов, равных нулю;");
            System.Console.WriteLine("- введите 4 для нахождение суммы элементов, расположенных после минимального элемента;");
            System.Console.WriteLine("- введите 5 чтобы упорядочить массив по убыванию;");
            System.Console.WriteLine("- введите 6 чтобы упорядочить массив по возрастанию;");
            System.Console.WriteLine("- введите 7 чтобы сжать массив, удалив из него елементы, по модулю не превышающие единицу;");
            string? userInputChoice = System.Console.ReadLine();
            if (IsSpacePressed(userInputChoice))
            {
                System.Console.WriteLine("Программа завершена");
                break;
            }
            int numberOfChoice = IsNumberOfChoiceValid(userInputChoice);
            if (numberOfChoice == 0)
            {
                System.Console.WriteLine("Вы ввели недопустимое число");
                continue;
            }
            ProcessArray(randomGeneratedValues, numberOfChoice);
            System.Console.WriteLine("\nДля продолжения введите что-либо...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    private static bool IsSpacePressed(string userInput)
    {
        bool isPressed = false;
        switch (userInput)
        {
            case " ":
                {
                    isPressed = true;
                    return isPressed;
                }
            case "": 
                {
                    isPressed = true;
                    return isPressed;
                }
            default:
                {
                    return isPressed;
                }
        }
    }
    private static int IsNumberNValid(string userInputN)
    {
        if (int.TryParse(userInputN, out int parsedN))
        {
            if (parsedN > 0 && parsedN <= 500) return parsedN;
            else if (parsedN > 500) return -2;
            else return -1;  
        }
        return 0;  
    }
    private static int IsNumberOfChoiceValid(string userInputChoice)
    {
        if (int.TryParse(userInputChoice, out int parsedChoice) && parsedChoice > 0 && parsedChoice < 8)
        {
            return parsedChoice;
        }
        else
        {
            return 0;
        }
    }
    private static List<double> ListWithRandomNums(int numberOfValues)
    {
        Random randomNum = new Random();
        List<double> randomValues = new List<double>();
        for (int i = 0; i < numberOfValues; i++)
        {
            randomValues.Add(Math.Round(randomNum.NextDouble() * 20 - 10, 2));
        }
        return randomValues;
    }
    private static void ProcessArray(List<double> list, int choice)
    {
        switch (choice)
        {
            case 1:
                {
                    double sumOfNechet = 0;
                    for (int i = 1; i < list.Count; i += 2)
                    {
                        sumOfNechet += list[i];
                    }
                    System.Console.WriteLine($"Сумма элементов с нечетными номерами: {sumOfNechet}");
                    break;
                }
            case 2:
                {
                    int firstNegative = -1;
                    int lastNegative = -1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] < 0)
                        {
                            if (firstNegative == -1)
                                firstNegative = i;
                            lastNegative = i;
                        }
                    }
                    double sumBetween = 0;
                    if (firstNegative != -1 && lastNegative != -1 && firstNegative + 1 < lastNegative)
                    {
                        for (int i = firstNegative + 1; i < lastNegative; i++)
                        {
                            sumBetween += list[i];
                        }
                    }
                    System.Console.WriteLine($"Сумма элементов между первым и последним отрицательными: {sumBetween}");
                    break;
                }
            case 3:
                {
                    int zeroCount = 0;
                    foreach (double item in list)
                    {
                        if (item == 0) zeroCount++;
                    }
                    System.Console.WriteLine($"Количество нулевых элементов: {zeroCount}");
                    break;
                }
            case 4:
                {
                    double sumAfterMin = list[list.IndexOf(list.Min())..^0].Sum();
                    System.Console.WriteLine($"Сумма элементов массива, расположеных после минимального элемента: {sumAfterMin}");
                    break;
                }
            case 5:
                {
                    // Отсортирую по возрастанию обменом
                    int listLength = list.Count();
                    for (int i = 0; i < listLength - 1; i++)
                    {
                        for (int j = 0; j < listLength - i - 1; j++)
                        {
                            if (list[j] < list[j + 1])
                            {
                                double num = list[j];
                                list[j] = list[j + 1];
                                list[j + 1] = num;
                            }
                        }
                    }
                    System.Console.WriteLine($"Отсортированный по убыванию массив: {string.Join(", ", list)}");
                    break;
                }
            case 6:
                {
                    // Отсортирую по возрастанию выбором
                    int listLength = list.Count();
                    for (int i = 0; i < listLength - 1; i++)
                    {
                        int minIndex = i;
                        for (int j = i + 1; j < listLength; j++)
                        {
                            if (list[j] < list[minIndex]) minIndex = j;
                        }
                        if (minIndex != i)
                        {
                            double num = list[i];
                            list[i] = list[minIndex];
                            list[minIndex] = num;
                        }
                    }
                    System.Console.WriteLine($"Отсортированный по возрастанию массив: {string.Join(", ", list)}");
                    break;
                }
            case 7:
                {
                    double[] array = list.ToArray();
                    int writeIndex = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (Math.Abs(array[i]) > 1)
                        {
                            array[writeIndex] = array[i];
                            writeIndex++;
                        }
                    }
                    for (int i = writeIndex; i < array.Length; i++)
                    {
                        array[i] = 0;
                    }
                    System.Console.WriteLine($"Сжатый массив: {string.Join(", ", array)}");
                    break;
                }
        }
    }
    static void Main()
    {
        Init();
    }
}