using System;

namespace MatrixProcessorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Обработка квадратной матрицы";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Обработка квадратной матрицы (задание №23)          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            // Ввод размера матрицы
            int n;
            while (true)
            {
                Console.Write("Введите размер квадратной матрицы (n): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Введите положительное целое число.");
                Console.ResetColor();
            }

            // Создаём матрицу
            int[,] matrix = new int[n, n];
            Random rand = new Random();

            // Заполняем матрицу случайными числами от -9 до 9
            Console.WriteLine("\nЗаполнение матрицы случайными числами...\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(-9, 10);
                }
            }

            // Выводим исходную матрицу
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("                     ИСХОДНАЯ МАТРИЦА");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            PrintMatrix(matrix, n);

            // 1. Находим и выводим элементы ВЫШЕ побочной диагонали
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n═══════════════════════════════════════════════════════════");
            Console.WriteLine("         ЭЛЕМЕНТЫ ВЫШЕ ПОБОЧНОЙ ДИАГОНАЛИ");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();

            int countAbove = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Условие: выше побочной диагонали (i + j < n - 1)
                    if (i + j < n - 1)
                    {
                        Console.WriteLine($"  matrix[{i},{j}] = {matrix[i, j]}");
                        countAbove++;
                    }
                }
            }

            if (countAbove == 0)
            {
                Console.WriteLine("  Нет элементов выше побочной диагонали");
            }
            Console.WriteLine($"\n  Всего элементов: {countAbove}");

            // 2. Создаём копию матрицы и заменяем элементы НИЖЕ побочной диагонали на 0
            int[,] processedMatrix = (int[,])matrix.Clone();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Условие: ниже побочной диагонали (i + j > n - 1)
                    if (i + j > n - 1)
                    {
                        processedMatrix[i, j] = 0;
                    }
                }
            }

            // 3. Выводим обработанную матрицу
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n═══════════════════════════════════════════════════════════");
            Console.WriteLine("         МАТРИЦА ПОСЛЕ ЗАМЕНЫ (ниже диагонали → 0)");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            PrintMatrix(processedMatrix, n);

            // Пояснение
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n═══════════════════════════════════════════════════════════");
            Console.WriteLine("                     ПОЯСНЕНИЕ");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine("• Побочная диагональ выделена (i + j = n - 1)");
            Console.WriteLine("• Элементы ВЫШЕ побочной диагонали: i + j < n - 1");
            Console.WriteLine("• Элементы НИЖЕ побочной диагонали: i + j > n - 1");
            Console.WriteLine("• В обработанной матрице элементы НИЖЕ диагонали = 0");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод матрицы на экран с подсветкой побочной диагонали
        /// </summary>
        static void PrintMatrix(int[,] matrix, int n)
        {
            Console.WriteLine();

            // Верхняя граница таблицы
            Console.Write("    ");
            for (int j = 0; j < n; j++)
            {
                Console.Write($"[{j,2}] ");
            }
            Console.WriteLine();

            Console.Write("    ");
            for (int j = 0; j < n; j++)
            {
                Console.Write("─────");
            }
            Console.WriteLine();

            // Вывод строк
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i,2}] ");
                for (int j = 0; j < n; j++)
                {
                    // Подсветка побочной диагонали
                    if (i + j == n - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {matrix[i, j],3} ");
                        Console.ResetColor();
                    }
                    // Подсветка нулей в обработанной матрице
                    else if (matrix[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" {matrix[i, j],3} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($" {matrix[i, j],3} ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}