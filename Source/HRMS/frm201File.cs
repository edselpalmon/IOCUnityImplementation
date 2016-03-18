using Entities;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System;
using System.Windows.Forms;

namespace HRMS
{
    public partial class frm201File : Form
    {
        private IHibernateDAL _db = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");

        public frm201File()
        {
            InitializeComponent();

        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {

            _db.OpenHibernateSession<ISession>("HRMSDB");

            var test = _db.GetRecordsById<ITestTable>(1);

            var employeeInformation = _db.GetRecordsById<IEmployeeInformation>(64);

        }
    }
}
