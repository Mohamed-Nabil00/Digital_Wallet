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
    public partial class Recharge : Form
    {
        private static decimal c;
        private static decimal x;
        bool f = false;
        bool f2 = false;
        public Recharge()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            form2 form = new form2();
            form.Show();
            this.Hide();
        }

        private void Recharge_Load(object sender, EventArgs e)
        {
            label3.Parent = panel1;
            label3.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f = false;
            f2 = false;
            string a, b;
            a = textBox1.Text;
            b = textBox2.Text;
            try { c = Convert.ToDecimal(b); }
            catch (System.FormatException)
            {
                label4.Show();
                label4.Text = "Invalid";
                label6.Hide();
                label5.Hide();
                f = true;
            }

            if (a.Length > 11 || a.Length < 11)
            {
                label5.Show();
                label5.Text = "Wrong number";
                label4.Hide();
                f = true;
                label6.Hide();
            }
            else if (c <= 0)
            {
                label4.Show();
                label4.Text = "Invalid";
                label5.Hide();
                label6.Hide();
                f = true;
            }
            else
            {
                try { x = decimal.Parse(textBox2.Text); }
                catch (System.FormatException)
                {
                    label4.Show();
                    label4.Text = "Invalid";
                    label6.Hide();
                    label5.Hide();
                    f = true;
                }
                decimal y = Convert.ToDecimal(SignIn.bala);
                var z = y - x;
                if (z < 0)
                {
                    label6.Show();
                    label6.Text = "Not enough money";
                    label4.Hide();
                    label5.Hide();
                    f = true;
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Table1 set Balance=@Balance where MobileNumber='" + SignIn.mobilenumber + "'", con);
                    cmd1.Parameters.AddWithValue("@Balance", z);
                    SqlDataReader srd1;
                    srd1 = cmd1.ExecuteReader();
                    
                    if (f == false)
                    {
                        label4.Hide();
                        label5.Hide();
                        label6.Hide();
                        MessageBox.Show("Bill paid successfully ");
                        f2 = true;


                    }
                    con.Close();

                    if (f2)
                    {
                        form2 form = new form2();
                        form.Show();
                        this.Hide();
                    }

                }
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Recharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
