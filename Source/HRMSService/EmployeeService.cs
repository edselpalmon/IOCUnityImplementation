using AutoMapper;
using EntityInterfaces;
using HRMSService.DataContracts;
using System.Collections.Generic;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {
    
        public User Authenticate()  //fake auth
        {
            var userinfo = new User { UserName="edselle23", UserRole="Admin", FirstName="Edsel", LastName="Palmon" };
            return userinfo;
        }

        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {

            var employee = Global.DAL.GetRecordById<IEmployeeInformation>(EmployeeId);

            if (employee == null) //when no records found
            {
                return new EmployeeInformation();
            }

            var employeeInfo = Global.Mapper.Map<EmployeeInformation>(employee);

            return employeeInfo;
        }

        public IList<EmployeeInformation> GetEmployees()
        {

            var employees = Global.DAL.GetRecords<IEmployeeInformation>();

            if (employees == null) //when no records found
            {
                return new List<EmployeeInformation>();
            }

            var listOfEmployees = Global.Mapper.Map<List<EmployeeInformation>>(employees);
            
            return listOfEmployees;
        }

    }
    
}