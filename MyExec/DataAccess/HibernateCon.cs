using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using UniManagement.DataAccess.Entity;
using UniManagement.DataAccess.Mapping;
namespace UniManagement.DataAccess
{
    public class HibernateCon
    {

        private static readonly string ConString = "Data Source=OATHKEEPER;Initial Catalog=University;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        private ISessionFactory sessionFactory;

        public HibernateCon()
        {
            this.sessionFactory = ConnectDB();
            
        }

        private static ISessionFactory ConnectDB()
        {
           
            return Fluently.Configure()
                .Database
                (MsSqlConfiguration.MsSql2012
                    .Driver<NHibernate.Driver.SqlClientDriver>()
                    .ConnectionString(ConString)
                        .ShowSql()
                )
                
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                
                .BuildSessionFactory();
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

                    Console.WriteLine("Data Successfully Created");
                    tx.Commit();
                }

            }
        }


        public void ShowStudentData() {


            using (var session = this.sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    Console.WriteLine("Database Connected");


                    var students = session.CreateCriteria<Student>().List<Student>();

                    Console.WriteLine("\n");
                    foreach (var st in students)
                    {
                        Console.WriteLine($"{st.ID}. {st.FirstName} {st.LastName}");
                    }

                    tx.Commit();
                }
            }
        }
    }
}
