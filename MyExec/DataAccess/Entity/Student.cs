using System;
namespace MyExec.DataAccess.Entity
{
    public class Student
    {
        public virtual int ID { get; protected set; }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual int Age { get; set; }

        public virtual string Department { get; set; }



    }
}
