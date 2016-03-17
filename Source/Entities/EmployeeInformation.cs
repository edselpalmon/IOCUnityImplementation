using ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class EmployeeInformation : IEmployeeInformation
    {
        public virtual Int64 EmployeeId { get; set; }
        public virtual string EmployeeNumber { get; set; }
        public virtual string Salutation { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Suffix { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Gender { get; set; }
        public virtual string CivilStatus { get; set; }
        public virtual string EducationalAttainment { get; set; }
        public virtual IList<IEmployeeAddress> EmployeeAddresses { get; set; }
    }
}
