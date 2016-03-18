using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TestTable : ITestTable
    {
        public virtual Int64 TestId { get; set; }
        public virtual string TestName { get; set; }
        public virtual string TestDesc { get; set; }

    }
}
