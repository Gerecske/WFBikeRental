using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFBikeRental.Properties;

namespace WFBikeRental
{
    public partial class frmBike : Form
    {
        public frmBike(int CostumerID)
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(Resources.ConString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Costumer where id = " + CostumerID, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Costumer costumer = new Costumer(reader["name"].ToString(), reader["phone"].ToString(), reader["email"].ToString(), reader["address"].ToString());
                    lblWelcome.Text = "Welcome " + costumer.Name + " !";
                }
            }
            conn.Close();
        }
    }
}
