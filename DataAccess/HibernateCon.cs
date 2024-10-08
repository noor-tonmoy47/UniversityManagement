using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace DataAccess
{
    internal class HibernateCon
    {

        private static readonly string conString = "Data Source=OATHKEEPER;Initial Catalog=University;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        

        private static ISessionFactory ConnectDB()
        {
            var conf = new Configuration();

            conf.DataBaseIntegration(x =>
            {
                x.ConnectionString = conString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });

            conf.AddAssembly(Assembly.GetExecutingAssembly());

            return conf.BuildSessionFactory();

        }

        private static void CreateSession(ISessionFactory sessionFactory) {
            using (var session = sessionFactory.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {

                    //CRUD operations

                    if(Prompt() == 1)
                    {
                        // Registration Logic
                    }
                    else
                    {
                        // Data Presenting Logic
                    }
                    tx.Commit();
                }
            }
        }


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

        private void Create()
        {

        }
        static void Main(string[] args)
        {
            

            var sessionFactory = ConnectDB();


            //open session

            CreateSession(sessionFactory);

        }

    }
}
