using System;
using System.Reflection;
using System.Data.SqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using MyExec.DataAccess.Entity;
namespace DataAccess
{
    public class HibernateCon
    {

        private static readonly string conString = "Data Source=OATHKEEPER;Initial Catalog=University;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        private ISessionFactory sessionFactory;

        public HibernateCon()
        {
            this.sessionFactory = ConnectDB();
            
        }

        private static ISessionFactory ConnectDB()
        {
            var conf = new Configuration();

            conf.DataBaseIntegration(x =>
            {
                x.ConnectionString = conString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });

            //conf.AddAssembly(Assembly.GetExecutingAssembly());

            return conf.BuildSessionFactory();
        }

        public void CreateData(Student student)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    Console.WriteLine("Database Connected");

                    //create student
                    session.Save(student);


                    tx.Commit();
                }

            }
        }
      
    }
}
