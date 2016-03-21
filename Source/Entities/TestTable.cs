using System;
using ServiceInterfaces;

namespace Entities
{
    public class TestTable : ITestTable
    {
        public virtual Int64 TestId { get; set; }
        public virtual string TestName { get; set; }
        public virtual string TestDesc { get; set; }

    }
}
