using ServiceInterfaces;
using System;

namespace Entities
{
    public class EmployementHistory : IEmployementHistory
    {
        public virtual Int64 EmployementHistoryId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string LastPositionHeld { get; set; }
        public virtual string Industry { get; set; }

        public virtual IEmployeeInformation EmployeeInformation { get; set; }

    }
}
