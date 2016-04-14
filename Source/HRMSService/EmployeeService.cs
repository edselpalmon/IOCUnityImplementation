using EntityInterfaces;
using IOCFactory;
using ServiceInterfaces;
using System.Collections.Generic;
using NHibernate;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using HRMSService.DataContracts;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {

        private IHibernateDAL _dal = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
        private ISession _dbSession;
        private ITransactionLogger _logger = DependencyFactory.Resolve<ITransactionLogger>("TransactionLogger");
        private IList<IEmployeeInformation> _employees;

        public EmployeeService()
        {
            _dbSession = _dal.OpenHibernateSession<ISession>("HRMSDB");
        }

       
        public string GetEmployeeByIdX(int EmployeeId)
        {

            var employee = _dal.GetRecordById<IEmployeeInformation>(EmployeeId);


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

            var employee = _dal.GetRecordById<IEmployeeInformation>(EmployeeId);

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