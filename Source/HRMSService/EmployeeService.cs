using EntityInterfaces;
using HRMSService.DataContracts;
using Newtonsoft.Json;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {


        public string GetEmployeeByIdX(int EmployeeId)
        {

            var employee = Global.DAL.GetRecordById<IEmployeeInformation>(EmployeeId);
           
            var json = JsonConvert.SerializeObject(employee);
            return json;

        }


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

    }
}