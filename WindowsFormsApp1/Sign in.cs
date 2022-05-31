using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SignIn : Form
    {
        public static string bala;
        //public static string balan;
        public static string mobilenumber;
        static string sql = "Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''";
        SqlConnection con = new SqlConnection(sql);
        public SignIn()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a;
            string b;
            a = textBox1.Text;
            b = textBox2.Text;
           
            con.Open();    
            string que = "select MobileNumber , Password from Table1 where MobileNumber ='" + textBox1.Text.Trim() + "'and Password='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);        
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count==1)
            {
                mobilenumber = textBox1.Text;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Balance from Table1 where MobileNumber = '" + textBox1.Text.Trim() + "'";
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        label6.Text = dr[0].ToString();
                        //balan=dr[0].ToString();
                        bala = label6.Text;

                    }
                }
                form2 form = new form2();
                this.Hide();
                form.Show();
                
            }
            else
            {
               label5.Text = ("Wrong mobile number or password");

            }
            
            
            
            con.Close();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                button3.BringToFront();
                button2.Visible = false;
                button3.Visible = true;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar== false)
            {
                button2.BringToFront();
                button3.Visible = false; 
                button2.Visible = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp form = new SignUp();
            form.Show();
            this.Hide();
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
