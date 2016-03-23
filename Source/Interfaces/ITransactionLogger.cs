using System;

namespace ServiceInterfaces
{
    public interface ITransactionLogger
    {
        void CreateErrorLog(string sourceClassName, string sourceMethodName, Exception error);
        void CreateInfoLog(string sourceClassName, string sourceMethodName, string messageInformationLog);
        void CreateWarningLog(string sourceClassName, string sourceMethodName, string messageInformationLog);
    }
}
