using EntityInterfaces;
using HRMSService.DataContracts;
using System.Collections.Generic;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {
        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {

            var employee = Global.DAL.GetRecordById<IEmployeeInformation>(EmployeeId);

            if (employee == null) //when no records found
            {
                return new EmployeeInformation();
            }

            var basicInfo = new EmployeeInformation
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName
            };

            return basicInfo;
        }

        public IList<EmployeeInformation> GetEmployees()
        {

            var employees = Global.DAL.GetRecords<IEmployeeInformation>();

            if (employees == null) //when no records found
            {
                return new List<EmployeeInformation>();
            }


            var listOfEmployees = new List<EmployeeInformation>();
            foreach(var employee in employees)
            {
                listOfEmployees.Add(
                    new EmployeeInformation
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        MiddleName = employee.MiddleName
                    }
                );
            };

            return listOfEmployees;
        }

    }
}