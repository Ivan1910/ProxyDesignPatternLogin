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

    // Proxy Object
    public class ProxyUser : IUser
    {
        private UserInfo user;
        private IUser realUser;

        public ProxyUser(UserInfo user)
        {
            this.user = user;
            this.realUser = new User();
        }

        public void AllowAccess(Form form)
        {
            if (!user.HasAccess)
            {
                form.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
                form.Close();
            }
            else
            {
                this.realUser.AllowAccess(form);
            }
        }
    }
}
