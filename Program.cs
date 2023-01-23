using System;
using System.Collections.Generic;

namespace In_class_ex___one
{
    class Program
    {
        static int getUserInput()
        {
            Console.WriteLine("C# Demos");
            Console.WriteLine("1. Show the pass by reference and pass by value scenario");
            Console.WriteLine("2. Show Hello World on the screen");
            Console.WriteLine("3. Write Hellow World in a file");
            Console.WriteLine("4. Adding two numbers in a linked list");
            Console.WriteLine("5. Quit");
            int option = Int32.Parse(Console.ReadLine());
            return option; 
        }
        static void Main(string[] args)
        {
            int option = getUserInput(); 
            switch (option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break; 
            }
        }
    }
}
