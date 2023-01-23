using System;
using System.Collections.Generic;

// Serves as Empty Solution -> overwrite the blank solution
namespace In_class_ex
{
    class Program
    {
        class AngleClass
        {
            private double angleRadians;
            public double AngleDegrees
            {
                get { return angleRadians * 180.0 / Math.PI; }
                set { angleRadians = value / 180.0 * Math.PI; }
            }
        }
        struct AngleStruct
        {
            private double angleRadians;
            public double AngleDegrees
            {
                get { return angleRadians * 180.0 / Math.PI; }
                set { angleRadians = value / 180.0 * Math.PI; }
            }
        }

        class BasicMessageClass
        {
            private string message; 
            public string Message
            {
                get;
                set; 
            }
            public BasicMessageClass(string m = "")
            {
                Message = m; 
            }
            public BasicMessageClass()
            {
                Message = "Default Message"; 
            }
            public void showMessage()
            {
                Console.WriteLine("Showing Message below...");
                Console.WriteLine(message);
            }
        }
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

        static void passByReferenceAndValue()
        {
            AngleClass aClass = new AngleClass();
            aClass.AngleDegrees = 10.0;
            Console.WriteLine("Angle class a degrees value: "); Console.Write(aClass.AngleDegrees);
            AngleClass bclass = aClass;
            bclass.AngleDegrees = 15.0;
            Console.WriteLine("\nAngle class a degress value after creating Angle class b shallow copy: "); Console.Write(aClass.AngleDegrees);

            AngleStruct aStruct = new AngleStruct();
            aStruct.AngleDegrees = 10.0;
            Console.WriteLine("Angle class a degrees value: "); Console.Write(aStruct.AngleDegrees);
            AngleStruct bStruct = aStruct;
            bStruct.AngleDegrees = 15.0;
            Console.WriteLine("\nAngle class a degress value after creating Angle class b shallow copy: "); Console.Write(aStruct.AngleDegrees);
        }

        static void messageOption()
        {
            BasicMessageClass m = new BasicMessageClass();
            m.showMessage(); 
        }

        static void helloWorldOption()
        {
            BasicMessageClass m = new BasicMessageClass("Hello world");

        }
            
        static void linkedListOption()
        {

        }

        static void Main(string[] args)
        {
            int option = getUserInput(); 
            switch (option)
            {
                case 1:
                    passByReferenceAndValue();
                    break;
                case 2:
                    messageOption(); 
                    break;
                case 3:
                    helloWorldOption(); 
                    break;
                case 4:
                    linkedListOption(); 
                    break;
                case 5:
                    break; 
            }
        }
    }
}
