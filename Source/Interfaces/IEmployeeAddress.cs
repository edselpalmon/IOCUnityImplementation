using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface IEmployeeAddress
    {
        Int64 AddressId { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string Province { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        IEmployeeInformation EmployeeInformation { get; set; }
    }
}
