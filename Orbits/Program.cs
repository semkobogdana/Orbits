using System;

namespace Program;

class Orbits
{
    static void Main()
    {
        Console.WriteLine("Привіт юний досліднику! Сьогодні ми з тобою будемо досліджувати орбіти.");
        int rows = Read("Рядки: ", 7), cols = Read("Стовпчики: ", 4);
        int[,] grid = new int[rows, cols];
        Random rnd = new Random();
        long maxProduct = -1;
        int maxRow = 0;
        for (int i = 0; i < rows; i++)
        {
            long product = 1;
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = Read($"Сітка [{i},{j}] (Enter — випадкове число): ", rnd.Next(-5, 6));
                Console.Write($"{grid[i, j],4} ");
                product *= grid[i, j];
            }
            long absProd = Math.Abs(product);
            Console.WriteLine($" | Рядок {i} |добуток| = {absProd}");

            if (i == 0 || absProd > maxProduct)
            {
                maxProduct = absProd;
                maxRow = i;
            }
        }
        Console.WriteLine($"\nІндекс рядка з найбільшим за модулем добутком: {maxRow}");
    }
    static int Read(string msg, int def)
    {
        Console.Write(msg);
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return def;
            if (int.TryParse(input, out int res)) return res;
            Console.Write("Вибач, юний досліднику. Спробуй знову: ");
        }
    }
}