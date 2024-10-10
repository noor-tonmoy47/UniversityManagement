using FluentNHibernate.Mapping;
using UniManagement.DataAccess.Entity;

namespace UniManagement.DataAccess.Mapping
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
