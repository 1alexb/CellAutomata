using System;

class Program
{
    static void Main()
    {
        const int width = 61;
        const int height = 30;

        bool[] cells = new bool[width];
        cells[width / 2] = true; // Initialize middle cell

        for (int i = 0; i < height; i++)
        {
            PrintGeneration(cells);
            cells = NextGeneration(cells);
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static bool[] NextGeneration(bool[] current)
    {
        bool[] next = new bool[current.Length];

        for (int i = 0; i < current.Length; i++)
        {
            bool left = i > 0 ? current[i - 1] : false;
            bool center = current[i];
            bool right = i < current.Length - 1 ? current[i + 1] : false;

            next[i] = Rule30(left, center, right);
        }

        return next;
    }

    static bool Rule30(bool left, bool center, bool right)
    {
        // Implement Rule 30: a cell is "on" if either the cell to its left or the cell to its right was "on" in the previous generation, but not both.
        return left ^ (center || right);
    }

    static void PrintGeneration(bool[] cells)
    {
        foreach (var cell in cells)
        {
            Console.Write(cell ? 'O' : '.');
        }
        Console.WriteLine();
    }
}
