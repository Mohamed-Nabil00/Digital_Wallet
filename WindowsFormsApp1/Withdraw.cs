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
    public partial class Withdraw : Form
    {
        private static decimal c;
        
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            form2 form = new form2();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            label2.Parent = panel1;
            label2.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string b = textBox1.Text;
            try { c = Convert.ToDecimal(b); }
            catch (System.FormatException )
            {
                label3.Show();
                label3.Text = "Invalid";
                label4.Hide();
                label5.Hide(); 
            }
            
          
            if (c<=0)
            {
                label3.Show();
                label3.Text = "Invalid";
                label4.Hide();
                label5.Hide();
            }
            else
            {
                decimal y = Convert.ToDecimal(SignIn.bala);
                var z = y - c;
                if (z < 0)
                {
                    label5.Show();
                    label5.Text = "Not enough money";
                    label4.Hide();
                    label3.Hide();
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Table1 set Balance=@Balance where MobileNumber='" + SignIn.mobilenumber + "'", con);
                    cmd1.Parameters.AddWithValue("@Balance", z);
                    SqlDataReader srd1;
                    srd1 = cmd1.ExecuteReader();
                    con.Close();
                    Random rand = new Random();
                    int a;
                    a = rand.Next(100000, 1000000);
                    label4.Show();
                    label4.Text = Convert.ToString(a);
                    label3.Hide();
                    label5.Hide();
                    button1.Visible = false;
                    textBox1.Visible = false;
                    label1.Visible = false;


                }
                
            }
            
        }

        private void Withdraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
