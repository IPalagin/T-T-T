using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace T_T_T
{
    internal class Program
    {
        static void DrawCross(int x, int y, int size)
        {
            for (int i = x;  i <= x + size; i++) 
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("█");
                    }
                }
            }
        }

        static void DrawRectangle(int x, int y,int size) 
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.WriteLine("█");
                    }
                }
            }
        }

        static void DrawField(int wight, int height, int cellSize)
        {
            for (int y = 0; y <= height; y += cellSize)
            {
                for (int x = 0; x < wight; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("█");
                }
            }
            
            for (int x = 0; x <= wight; x += cellSize)
            {
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("█");
                }
            }
        }

        static void DrawNumberCell(int wight, int height, int cellSize)
        {
            int number = 1;
            for (int y = 0; y < height; y += cellSize)
            {
                for (int x = 0; x < wight; x += cellSize)
                {
                    Console.SetCursorPosition(x + 5 , y + 1);
                    Console.WriteLine(number++);
                }
            }
        }

        static void Main(string[] args)
        {
           // Console.SetWindowSize(90, 34);
           // Console.SetBufferSize(90, 34);

            DrawField(33, 33, 11);
            DrawNumberCell(33, 33, 11);

            int win = -1;
            int input;
            int c1, c2, c3, c4, c5, c6, c7, c8, c9;
            c1 = -1; c2 = -2; c3= -3; c4 = -4; c5 = -5; c6 = -6; c7 = -7; c8 = -8; c9 = -9;


            for (int i = 0; i < 9; i++) 
            {
                Console.SetCursorPosition(35, 0);
                Console.Write("");
                Console.SetCursorPosition(35, 0);
                Console.Write("Введите номер клетки:");

                bool errorInput = !int.TryParse(Console.ReadLine(), out input);

                if (input < 1 || input > 9) errorInput = true;
                if (input == 1 && c1 >= 0) errorInput = true;
                if (input == 2 && c2 >= 0) errorInput = true;
                if (input == 3 && c3 >= 0) errorInput = true;
                if (input == 4 && c4 >= 0) errorInput = true;
                if (input == 5 && c5 >= 0) errorInput = true;
                if (input == 6 && c6 >= 0) errorInput = true;
                if (input == 7 && c7 >= 0) errorInput = true;
                if (input == 8 && c8 >= 0) errorInput = true;
                if (input == 9 && c9 >= 0) errorInput = true;

                if (errorInput == true)
                {
                    i--;
                    continue;
                }

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                int x = (input - 1) % 3 * 11 + 2;
                int y = (input - 1) / 3 * 11 + 2;

                if (i % 2 == 0)
                {
                    DrawCross(x, y, 7);
                    Console.SetCursorPosition(35, 4 + i);
                    Console.WriteLine($"Ход {i + 1}: Крестик в клетку {input}");
                }
                else
                {
                    DrawRectangle(x, y, 7);
                    Console.SetCursorPosition(35, 4 + i);
                    Console.WriteLine($"Ход {i + 1}: Нолик в клетку {input}");
                }

                if (c1 == c2 && c2 == c3) win = c1;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c1 == c4 && c4 == c7) win = c3;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c3 == c5 && c5 == c7) win = c3;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;

                if (win == 0)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победели крестики");
                    break;
                }
                if (win == 1)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победели нолики");
                    break;
                }
            }
            if (win == -1)
            {
                Console.SetCursorPosition(35, 2);
                Console.WriteLine("Ничья");
            }
        }
    }
}