using System;
using DataAccessLayer;
using System.Windows.Forms;
using DataAccessClass;

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
            var db = new HibernateDAL();
            txtDisplayChannel.Clear();
            var tmpText = "User login ID Returned:";
            this.txtDisplayChannel.Text = tmpText + db.GetChannelById(286).Username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = new HibernateDAL();
            var channel = new Channel
            {
                 ChannelId = 199
                 ,DateCreated = DateTime.Now
                 ,Initialized = false
                 ,Password = "MyPassxx5"
                 ,Status = true
                 ,Username = "EdselPxxx5"
            };

            db.SaveChannel(channel);
            var tmpText = "User login ID Returned:";
            this.txtDisplayChannel.Text = tmpText + db.GetChannelById(channel.ChannelId).Username;

        }
    }
}
