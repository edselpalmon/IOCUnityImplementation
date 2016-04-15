using EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EducationalBackground : IEducationalBackground
    {
        public virtual Int64 EducationId { get; set; }
        public virtual string SchoolCode { get; set; }
        public virtual string SchoolName { get; set; }
        public virtual string SchoolAddress { get; set; }
        public virtual DateTime DateAttended { get; set; }
        public virtual DateTime DateGraduated { get; set; }
        public virtual string Degree { get; set; }
        public virtual IEmployeeInformation EmployeeInformation{ get; set; }
}
}
