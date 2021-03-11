using System;
using System.Text;

namespace Lab_2
{
    class Task3
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---Start of task with Random objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            string dataString = "oashfgsdhfadcfniwhfvuicinugweycrmfe" +
                "yrarxhmFFDUAHGCGCIHCUGFVSCHJB" +
                "JVDJFHSDSPVdibvsdinvsbfdasfcgbfcnsjkvcvxhGCOHCGCGBWVGOHOJ" +
                "dhsycgnwrxfidmcgeucgjoifdkgdsdzgbdvahszqwkfx" +
                "hmcgregFFDSKNXBFGUWNMUINGFYMWGFGFNYg" +
                "fcunygeiwmfewiotacnyYUGHUGKFYWBNTXMUFWGMYGIUFGfdhkfgdsf"; 

            Console.WriteLine("The string you want is: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Random randomiser = new Random();

            for (int i = 0; i < 30; i++)
            {
                Console.Write(dataString[randomiser.Next(0, 256)] + " ");
            }
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---End of task with Random objects---\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();
        }
    }
}