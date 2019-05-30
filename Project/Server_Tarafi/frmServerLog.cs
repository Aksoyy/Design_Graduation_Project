using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Tarafi
{
    public partial class frmServerLog : Form
    {
        public frmServerLog()
        {
            InitializeComponent();
        }

        public void writeLog(string mesg)
        {
            txtLog.AppendText(string.Format("[{0}] : {1}{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), mesg, Environment.NewLine));
        }
    }
}
