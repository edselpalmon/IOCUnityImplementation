using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface IHibernateDAL
    {
        IChannel GetChannelById(int channelId);
        void SaveChannel(IChannel channel);
        IEmployeeInformation GetEmployeeById(Int64 employeeId);
        Int64 SaveEmployeeInformation(IEmployeeInformation employeeInformation);

        //generic methods
        T GetRecordsById<T>(Int64 recordId);
        T SaveInformation<T>(T recordInformation);
        void DeleteRecords<T>(T recordInformation);
    }
}
