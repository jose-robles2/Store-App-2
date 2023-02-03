﻿using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            { 
                try
                {
                    Console.WriteLine("Enter a file name!");
                    string inputFileName = Console.ReadLine();
                    
                    using (TextWriter fs = File.CreateText(inputFileName)) 
                    { 
                        Console.WriteLine("Creating file...");
                        Console.WriteLine("Enter some text to write to the file");
                        string fileContent = Console.ReadLine();                       
                        fs.Write(fileContent);
                    }
                    break; 
                }
                catch (Exception e)
                {

                    Console.WriteLine("ERROR: " + e.Message);
                    Console.Clear();
                    Console.WriteLine("Try again");
                }

            }

        }
    }
}