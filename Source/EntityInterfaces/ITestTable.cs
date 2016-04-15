using System;

namespace EntityInterfaces
{
    public interface ITestTable
    {
        Int64 TestId { get; set; }
        string TestName { get; set; }
        string TestDesc { get; set; }
    }
}