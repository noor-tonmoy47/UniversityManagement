using System;
using UniManagement.BusinessLogic;

namespace Presentation
{
    public class UI
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


        private static int inputInteger(string valueToGet)
        {
            int integerValue = -1;
            while (true) { 
            
                Console.Write($"{valueToGet}: ");
                string integerString = Console.ReadLine();

                try
                {
                    integerValue = Int32.Parse(integerString);
                }
                catch (Exception e)
                {
                    Console.WriteLine("invalid input");
                    continue;
                }

                break;
            }

            return integerValue;
        }

        public static void Driver()
        {
            int choice = Prompt();

            if(choice == 1)
            {
                Console.WriteLine("Enter the following information...");

                Console.Write("FirstName: ");
                string FirstName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("LastName: ");
                string LastName = Console.ReadLine();
                Console.WriteLine();


                int age = inputInteger("Age");


                Console.Write("Department: ");
                string Department = Console.ReadLine();
                Console.WriteLine();

                Controller cnt = new Controller();
                cnt.AddData(FirstName, LastName, age, Department);
            }
            else
            {

                Controller cnt = new Controller();
                cnt.ShowStudentData();
                //Console.WriteLine("Feature Coming soon...");
            }
        }

    }
}
