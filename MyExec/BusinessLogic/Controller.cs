using UniManagement.DataAccess;
using UniManagement.DataAccess.Entity;
namespace UniManagement.BusinessLogic
{
    public class Controller
    {
        // create\

        private HibernateCon hCon;

        public Controller()
        {
            hCon = new HibernateCon();
        }
        public void AddData(string FirstName, string LastName, string StringAge, string Department)
        {
            int ageInt;

            while (true)
            {

                try
                {
                    ageInt = Int32.Parse(StringAge);
                } catch (Exception e){
                    Console.WriteLine("invalid input");
                    continue;
                }

                break;
            }

            Student student = new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = ageInt,
                Department = Department
            };
            
            this.hCon.CreateData(student);

        }
        //delete

        //show all
        public void ShowStudentData()
        {
            this.hCon.ShowStudentData();
        }

    }
}
