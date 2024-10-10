using FluentNHibernate;
using FluentNHibernate.Mapping;
using MyExec.DataAccess.Entity;

namespace MyExec.DataAccess.Mapping
{
    internal class StudentMap : ClassMap<Student>
    {
        public StudentMap() {
            
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Age);
            Map(x => x.Department);
            
        }
    }
}
