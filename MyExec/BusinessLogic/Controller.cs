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

        public void AddData(string FirstName, string LastName, int age, string Department)
        {
            
            Student student = new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = age,
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
