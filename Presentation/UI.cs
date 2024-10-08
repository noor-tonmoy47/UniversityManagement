using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class UI
    {


        private static int Prompt()
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. View Data");
            Console.WriteLine("\n");


            string input;
            int choice = 0;

            while (true)
            {
                try
                {
                    input = Console.ReadLine();

                    if (!input.Equals("1") && !input.Equals("2"))
                    {
                        throw new Exception();
                    }

                    choice = Int32.Parse(input);

                }
                catch (Exception)
                {

                    Console.WriteLine("Please input 1 or 2");
                    continue;
                }

                break;
            }


            return choice;
        }
        static void Main(string[] args)
        {
            int choice = Prompt();

        }

    }
}
