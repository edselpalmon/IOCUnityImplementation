using EntityInterfaces;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using HRMSService.DataContracts;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {


        public string GetEmployeeByIdX(int EmployeeId)
        {

            var employee = Global.DAL.GetRecordById<IEmployeeInformation>(EmployeeId);


            // Serialize the results as JSON
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(employee.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, employee);

            // Return the results serialized as JSON
            string json = Encoding.Default.GetString(memoryStream.ToArray());
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