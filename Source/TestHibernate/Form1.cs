using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHibernate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccessLayer.HibernateDAL db = new DataAccessLayer.HibernateDAL();
            textBox1.Clear();
            string tmpText = "User login ID Returned:";
            this.textBox1.Text = tmpText + db.GetChannelById(286).Username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
