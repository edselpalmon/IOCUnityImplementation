using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmployeeAddress : IEmployeeAddress
    {
        public virtual Int64 AddressId { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual string PostalCode { get; set; }

        public virtual IEmployeeInformation EmployeeInformation { get; set; } 
    }
}
