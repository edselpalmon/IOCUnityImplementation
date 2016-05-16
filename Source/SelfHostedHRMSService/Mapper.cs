using AutoMapper;
using EntityInterfaces;
using IOCFactory;
using NHibernate;
using SelfHostedHRMSService.DataContracts;
using ServiceInterfaces;

namespace SelfHostedHRMSService
{
    public static class Mapper
    {
        public static IMapper GetMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEmployeeAddress, EmployeeAddress>();
                cfg.CreateMap<IEducationalBackground, EducationalBackground>();
                cfg.CreateMap<IEmployementHistory, EmployementHistory>();
                cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
            });

            return config.CreateMapper();
        }
    }
}
