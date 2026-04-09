using System.Diagnostics.CodeAnalysis;
using System.Net;

class Csharp
{
    private static void Init()
    {
        System.Console.Clear();
        System.Console.WriteLine("Для начала работы введите что-либо...");
        System.Console.ReadKey();
        System.Console.Clear();
        while (true)
        {
            double[] initializedArray = ArrayInitialization();
            bool isContinues = true;
            TextMessage(initializedArray);
            while (isContinues)
            {
                string userChoice = System.Console.ReadLine();
                Console.Clear();
                if (int.TryParse(userChoice, out int parsedChoice))
                {
                    if (parsedChoice < 7 && parsedChoice > 0 && parsedChoice != 4 && parsedChoice != 6 && parsedChoice != 3)
                    {
                        ArrayOperations(parsedChoice, initializedArray);
                        continue;
                    }
                    else if (parsedChoice == 4) initializedArray = RedactedArray(initializedArray);
                    else if (parsedChoice == 6) initializedArray = SortedArray(initializedArray);
                    else if (parsedChoice == 3) initializedArray = ArrayChoiceThree(initializedArray);
                    else if (parsedChoice == 0)
                    {
                        System.Console.WriteLine("\nПреобразования над массивом завершены");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Введено невеное число");
                        continue;
                    }
                }
                else
                {
                    System.Console.WriteLine("Данные введены неверно");
                    continue;
                }
            }
            System.Console.WriteLine("Для продолжения введите что-либо, для выхода из программы нажмите ENTER");
            if (System.Console.ReadLine() == "")
            {
                System.Console.WriteLine("Программа завершена");
                break;
            }
            System.Console.Clear();
        }
    }
    private static unsafe double[] ArrayInitialization()
    {
        Random randomNumber = new Random();
        int randomNumberOfElems = randomNumber.Next(1, 50);
        double[] array = new double[randomNumberOfElems];
        fixed (double* ptr = array)
        {
            double* current = ptr;
            for (int i = 0; i < randomNumberOfElems; i++)
            {
                *current = Math.Round(randomNumber.NextDouble() * 20 - 10, 1);
                current++;
            }
        }
        return array;
    }
    private static void ArrayOperations(int numberOfChoice, double[] array)
    {
        switch (numberOfChoice)
        {
            case 1:
                {
                    List<double> listOfFloats = new List<double>(); 
                    foreach (double elem in array)
                    {
                        
                        if ((elem >= -5.0 && elem <= -2.0)  || (elem >= 2.0 && elem <= 5.0))
                        {
                            listOfFloats.Add(elem);
                        }
                    }
                    System.Console.WriteLine("Нахождение элементов массива, принадлежащих интервалам [–2; –5] или [2; 5]");
                    System.Console.WriteLine($"\nЭлементов массива, принадлежащих данным интервалам: {listOfFloats.Count}");
                    System.Console.WriteLine("\nВведите номер следующего преобразования: ");
                    TextMessage(array);
                    return;
                }
            case 2:
                {
                    System.Console.WriteLine("Нахождение суммы элементов массива, не принадлежащих интервалам [–2; –5] или [2; 5]");
                    List<double> listOfFloats = new List<double>(); 
                    foreach (double elem in array)
                    {
                        if (!((elem >= -5.0 && elem <= -2.0) || (elem >= 2 && elem <= 5)))
                        {
                            listOfFloats.Add(elem);
                        }
                    }
                    System.Console.WriteLine($"\nСумма элементов массива, не принадлежащих данным интервалам: {listOfFloats.Sum()}");
                    System.Console.WriteLine("\nВведите номер следующего преобразования: ");
                    TextMessage(array);
                    return;
                }
            case 5:
                {
                    bool isGood = true;
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (array[i - 1] > array[i]) isGood = false; 
                    }
                    switch (isGood)
                    {
                        case true:
                            System.Console.WriteLine("Массив является упорядоченным по возрастанию");
                            System.Console.WriteLine("\nВведите номер следующего преобразования: ");
                            TextMessage(array);
                            return;
                        case false:
                            System.Console.WriteLine("Массив не является упорядоченным по возрастанию");
                            System.Console.WriteLine("\nВведите номер следующего преобразования: ");
                            TextMessage(array);
                            return;
                    }
                }
        }
    }
    private static void TextMessage(double[] array)
    {
        System.Console.WriteLine($"Ваш массив: {string.Join("  ", array)}");
        System.Console.WriteLine(" - введите 1 для нахождения элементов массива, принадлежащих интервалам [–2; –5] или [2; 5]");
        System.Console.WriteLine(" - введите 2 для нахождения суммы элементов массива, не входящих в интервалы [–2; –5] или [2; 5]");
        System.Console.WriteLine(" - введите 3 чтобы сохранить в новом массиве только те элементы исходного, которые принадлежат интервалам [–2; –5] или [2; 5]");
        System.Console.WriteLine(" - введите 4 для ввода и вывода элементов массива");
        System.Console.WriteLine(" - введите 5 для проверки, является ли массив упорядоченным по возрастанию");
        System.Console.WriteLine(" - введите 6 чтобы выполнить вставку в упорядоченный массив некоторого произвольного значения таким образом, чтобы упорядоченность не была нарушена");
        System.Console.WriteLine(" - введите 0 для прекращения действий над массивом");
    }
    private static double[] RedactedArray(double[] array)
    {
        while (true)
            {
                System.Console.WriteLine("Ввод и вывод элементов массива");
                System.Console.WriteLine($"Введите порядковый номер элемента, который хотите поменять, всего в массиве {array.Length} элементов: ");
                if (int.TryParse(System.Console.ReadLine(), out int number))
                {
                    if (number > 0 && number <= array.Length)
                    {
                        double beforeOperation = array[number - 1];
                        Random randomNum = new Random();
                        array[number - 1] = Math.Round(randomNum.NextDouble() * 20 - 10, 1);
                        System.Console.WriteLine($"Вы заменили {number} по счету элемент массива {beforeOperation} на сгенерированное число {array[number - 1]}");
                        System.Console.WriteLine($"Новый массив: {string.Join("  ", array)}");
                        System.Console.WriteLine("Желаете продолжить ввод? Введите ENTER чтобы выйти");
                        if (System.Console.ReadLine() == "")
                        {
                            System.Console.WriteLine("Выполнение завершено");
                            System.Console.WriteLine($"\nВведите номер следующего преобразования: ");
                            TextMessage(array);
                            return array;
                        }
                        continue;
                    }
                    else
                    {
                        System.Console.WriteLine($"Введите число от 1 до {array.Length}");
                        continue;
                    }
                }
                else
                {
                    System.Console.WriteLine("Данные введены неверно");
                    continue;
                }
            }
    }
    private static double[] SortedArray(double[] array)
    {
        System.Console.WriteLine("Выполнение вставки в упорядоченный массив некоторого произвольного значения таким образом, чтобы упорядоченность не была нарушена");
        Array.Sort(array);
        System.Console.WriteLine($"Отсортированный массив: {string.Join("  ", array)}");
        while (true)
        {
            System.Console.WriteLine("Введите число для вставки:");
            if (double.TryParse(System.Console.ReadLine(), out double value))
            {
                double[] newArray = new double[array.Length + 1];
                int pos = 0;
                while (pos < array.Length && array[pos] < value) pos++;
                for (int i = 0; i < pos; i++) newArray[i] = array[i];
                newArray[pos] = value;
                for (int i = pos; i < array.Length; i++) newArray[i + 1] = array[i];
                System.Console.WriteLine($"Новый массив: {string.Join("  ", newArray)}");
                System.Console.WriteLine("Желаете продолжить ввод? Введите ENTER чтобы выйти");
                if (System.Console.ReadLine() == "")
                {
                    System.Console.WriteLine("Выполнение завершено");
                    System.Console.WriteLine($"\nВведите номер следующего преобразования: ");
                    TextMessage(newArray);
                    return newArray;
                }
                array = newArray;
                continue;
            }
            else
            {
                System.Console.WriteLine("Данные введены неверно");
                continue;
            }
        }
    }
    private static double[] ArrayChoiceThree(double[] array)
    {
        System.Console.WriteLine("Cохранить в новом массиве только те элементы исходного, которые принадлежат интервалам [–2; –5] или [2; 5]");
        List<double> listOfNums = new List<double>(); 
        foreach (double elem in array)
        {
            
            if ((elem >= -5.0 && elem <= -2.0) || (elem >= 2 && elem <= 5))
            {
                listOfNums.Add(elem);
            }
        }
        System.Console.WriteLine($"\nНовый массив: {string.Join("  ", listOfNums)}");
        System.Console.WriteLine("\nВведите номер следующего преобразования: ");
        array = listOfNums.ToArray();
        TextMessage(array);
        return array;
    }
    static void Main()
    {
        Init();
    }
}
