using System;

namespace EntityInterfaces
{
    public interface IEmployementHistory
    {

        Int64 EmployementHistoryId { get; set; }
        string CompanyName { get; set; }
        string CompanyAddress { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string LastPositionHeld { get; set; }
        string Industry { get; set; }

        IEmployeeInformation EmployeeInformation { get; set; }
    }
}
