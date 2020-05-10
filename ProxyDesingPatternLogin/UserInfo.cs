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
    public class UserInfo
    {
        public string Username { get; set; }
        public bool HasAccess { get; private set; }

        public UserInfo(string username,string password)
        {
            this.Username = username;
                if (CheckIfUserIsRegistered(username,password))
                {
                    this.HasAccess = true;
                }
                else
                {
                    this.HasAccess = false;
                }
        }

        private Boolean CheckIfUserIsRegistered(string username,string password)
        {
            Boolean userFound;
            using (SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-0DTMDR1\SQLEXPRESS;Server=DESKTOP-0DTMDR1\SQLEXPRESS;
            Initial Catalog = seminarskiRadDB; User ID = dbowner; Password = 12345678"))
            {
                SqlCommand cmd = new SqlCommand("login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@user_found";
                outputParameter.SqlDbType = System.Data.SqlDbType.Bit;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                userFound = Convert.ToBoolean(outputParameter.Value);
            }
            return userFound;
        }
    }
}