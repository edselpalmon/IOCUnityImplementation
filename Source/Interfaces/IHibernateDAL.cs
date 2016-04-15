using EntityInterfaces;
using System;
using System.Collections.Generic;

namespace ServiceInterfaces
{
    public interface IHibernateDAL
    {
        IChannel GetChannelById(int channelId);
        void SaveChannel(IChannel channel);
        IEmployeeInformation GetEmployeeById(Int64 employeeId);
        Int64 SaveEmployeeInformation(IEmployeeInformation employeeInformation);

        T OpenHibernateSession<T>(string connectionName);

        //generic methods
        T GetRecordById<T>(Int64 recordId);
        T SaveRecord<T>(T recordInformation);
        void DeleteRecord<T>(T recordInformation);
        T LoadRecordInfo<T>(Int64 recordId);
        IList<T> GetRecords<T>();
    }
}
