using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using WFBikeRental.Properties;

namespace WFBikeRental
{
    internal class Costumer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private int id;

        public int GetId()
        {
            return id;
        }

        public Costumer(string name, string phone, string email, string address)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public bool AddToDB(int id)
        {
            if (Name.Length<1 || Address.Length<1 || Phone.Length<1 || Email.Length<1)
            {
                MessageBox.Show("Please fill in all fields", "Error");
                return false;
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(Resources.ConString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Customer (name, phone, email, address) VALUES (@Name, @Phone, @Email, @Address)", conn);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Error");
                    return false;
                }
            }
        }
    }
}
