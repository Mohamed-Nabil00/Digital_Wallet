using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        private static decimal x;
        static string sql = "Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''";
        SqlConnection con = new SqlConnection(sql);
        public SignUp()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string a, b, c,d;
            a = textBox1.Text;
            b = textBox2.Text;
            c = textBox3.Text;
            d = textBox4.Text;
            try {  x = Convert.ToDecimal(b); }
            catch(System.FormatException)
            {
                label9.Show();
                label9.Text = "Wrong number";
                label8.Hide();
                label11.Hide();
                label12.Hide();
                label13.Hide();
                label14.Hide();
            }
            if (a != "" && b != "" && c != "" && d != "")
            {
                con.Open();
                string query = "INSERT INTO Table1 (FullName , MobileNumber , Password) VALUES (@FullName , @MobileNumber , @Password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", textBox1.Text);


                cmd.Parameters.AddWithValue("@MobileNumber", textBox2.Text);


                cmd.Parameters.AddWithValue("@Password", textBox3.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                SignIn form = new SignIn();
                form.Show();
                this.Hide();
            }
           
            else if (a.Length == 0)
            {
                label8.Show();
                label8.Text = "Enter your full name ";
                label9.Hide();
                label11.Hide();
                label12.Hide();
                label14.Hide();
                label13.Hide();


            }
            else if (b.Length != 11|| x <0)
            {
                label9.Show();
                label9.Text = "Invalid number";
                label8.Hide();
                label11.Hide();
                label12.Hide();
                label13.Hide();
                label14.Hide();

            }
            else if (c.Length ==0)
            {
                label11.Show();
                label11.Text = "Enter your password";
                label9.Hide();
                label8.Hide();
                label12.Hide();
                label13.Hide();
                label14.Hide();

            }
            else if (c.Length < 8)
            {
                label14.Show();
                label14.Text = "Your Password must be at least 8 characters long. \n                          Please try another. ";
                label9.Hide();
                label8.Hide();
                label12.Hide();
                label13.Hide();
            }
            else if (d != c)
            {
                label12.Show();
                label12.Text = "Confirm your password";
                label9.Hide();
                label11.Hide();
                label8.Hide();
                label13.Hide();
                label14.Hide();

            }
            /*else if (a == "" && b == "" && c == "" && d == "")
            {
                label13.Show();
                label13.Text = "Fill the data";
                label9.Hide();
                label11.Hide();
                label8.Hide();
                label12.Hide();
            }
            */
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            /*
            string c;
            c = textBox3.Text;
            if (c.Length < 8)
            {
                label9.Hide();
                label7.Show();
                label7.Text = "Password is weak";
                
            }
            else
            {
                label7.Hide();
            }
            */
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn form = new SignIn();
            form.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*
            string b;
            b = textBox2.Text;
            if (b.Length < 11 || b.Length > 11)
            {
                label8.Text = "Wrong Number";
            }
            else
            {
                label8.Text = "";
            }
            */
        }

        


       

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
