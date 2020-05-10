using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProxyDesingPatternLogin
{
    //Real object
    public class User : IUser
    {
        public void AllowAccess(Form form)
        {
            form.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            form.Close();
        }
    }
}
