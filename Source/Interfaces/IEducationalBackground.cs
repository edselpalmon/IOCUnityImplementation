using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface IEducationalBackground
    {
        Int64 EducationId { get; set; }
        string SchoolCode { get; set; }
        string SchoolName { get; set; }
        string SchoolAddress { get; set; }
        DateTime DateAttended { get; set; }
        DateTime DateGraduated { get; set; }
        string Degree { get; set; }
        IEmployeeInformation EmployeeInformation { get; set; }
    }
}
