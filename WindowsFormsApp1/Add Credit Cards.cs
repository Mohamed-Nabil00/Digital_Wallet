using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class CreditCard : Form
    {
        public CreditCard()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Parent = panel1;
            label3.BackColor = Color.Transparent;
            Back.Parent = panel1;
            Back.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            form2 form = new form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            if (a.Length>16||a.Length<16||b.Length<3||b.Length>3)
            {
                label4.Text = "Invalid";
            }
            else
            {
                Random rand = new Random();
                int c;                
                c = rand.Next(5000, 10001);
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");
                con.Open();
                string query = "INSERT INTO credit (creditnum , cvv , mobilenum,money) VALUES (@creditnum , @cvv , @mobilenum,@money)";
                SqlCommand cmd = new SqlCommand(query, con);
                try {
                    cmd.Parameters.AddWithValue("@creditnum", textBox1.Text);
                    
                }
                catch (DuplicateNameException)
                {
                    label4.Text = "Error";
                }
                cmd.Parameters.AddWithValue("@cvv", textBox2.Text);
                cmd.Parameters.AddWithValue("@mobilenum", form2.number);
                cmd.Parameters.AddWithValue("@money", c);
                cmd.ExecuteNonQuery(); 
                
                con.Close();
                form2 form = new form2();
                form.Show();
                this.Hide();
            }
        }

        private void CreditCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
