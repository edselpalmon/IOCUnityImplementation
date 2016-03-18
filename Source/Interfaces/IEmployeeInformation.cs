using System;
using System.Collections.Generic;

namespace ServiceInterfaces
{
    public interface IEmployeeInformation
    {
        Int64 EmployeeId { get; set; }
        string EmployeeNumber { get; set; }
        string Salutation { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        DateTime BirthDate { get; set; }
        string Gender { get; set; }
        string CivilStatus { get; set; }
        string EducationalAttainment { get; set; }
        IList<IEmployeeAddress> EmployeeAddresses { get; set; }
        IList<IEmployementHistory> EmployementHistories { get; set; }
    }
}
