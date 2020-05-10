﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesingPatternLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            IUser user = new ProxyUser(new UserInfo(textBox1.Text, textBox2.Text));
            user.AllowAccess(this);
        }

    }
}
