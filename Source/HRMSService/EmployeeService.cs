using AutoMapper;
using EntityInterfaces;
using HRMSService.DataContracts;
using IOCFactory;
using System.Collections.Generic;

namespace HRMSService
{
    public class EmployeeService : IEmployeeService
    {

        private MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IEmployeeAddress, EmployeeAddress>();
            cfg.CreateMap<IEducationalBackground, EducationalBackground>();
            cfg.CreateMap<IEmployementHistory, EmployementHistory>();
            cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
        });

        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {

            var employee = Global.DAL.GetRecordById<IEmployeeInformation>(EmployeeId);

            if (employee == null) //when no records found
            {
                return new EmployeeInformation();
            }

            //_config.AssertConfigurationIsValid();  this is for verification only

            var mapper = _config.CreateMapper();

            var employeeInfo = mapper.Map<EmployeeInformation>(employee);

            //Mapper.Map<EmployeeInformation, IEmployeeInformation>();

            return employeeInfo;
        }

        public IList<EmployeeInformation> GetEmployees()
        {

            var employees = Global.DAL.GetRecords<IEmployeeInformation>();

            if (employees == null) //when no records found
            {
                return new List<EmployeeInformation>();
            }

            var mapper = _config.CreateMapper();

            var listOfEmployees = mapper.Map<List<EmployeeInformation>>(employees);
            
            return listOfEmployees;
        }


        public void edsel()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
            });
            config.AssertConfigurationIsValid();
        }

    }

    public class Source
    {
        public int frmValue { get; set; }
        public int frmValue2 { get; set; }
    }
    public class Dest
    {
        public int Value { get; set; }
        public int Value2 { get; set; }
    }
    

}