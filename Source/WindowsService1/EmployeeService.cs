using AutoMapper;
using EntityInterfaces;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System.Collections.Generic;
using System.ServiceModel;
using WindowsService1.DataContracts;

namespace WindowsService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EmployeeService : IEmployeeService
    {
        private ISession _DBSession;
        private IHibernateDAL _DAL;
        private IMapper _Mapper;

        public EmployeeService()
        {
            _DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
            _DBSession = _DAL.OpenHibernateSession<ISession>("HRMSDB");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEmployeeAddress, EmployeeAddress>();
                cfg.CreateMap<IEducationalBackground, EducationalBackground>();
                cfg.CreateMap<IEmployementHistory, EmployementHistory>();
                cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
            });

           _Mapper = config.CreateMapper();
        }

        public User Authenticate()  //fake auth
        {
            var userinfo = new User { UserName = "edselle23", UserRole = "Admin", FirstName = "Edsel", LastName = "Palmon" };
            return userinfo;
        }

        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {
            var employee = _DAL.GetRecordById<IEmployeeInformation>(EmployeeId);

            if (employee == null) //when no records found
            {
                return new EmployeeInformation();
            }

            var employeeInfo = _Mapper.Map<EmployeeInformation>(employee);

            return employeeInfo;
        }

        public IList<EmployeeInformation> GetEmployees()
        {

            var employees = _DAL.GetRecords<IEmployeeInformation>();

            if (employees == null) //when no records found
            {
                return new List<EmployeeInformation>();
            }

            var listOfEmployees = _Mapper.Map<List<EmployeeInformation>>(employees);

            return listOfEmployees;
        }

    }
}
