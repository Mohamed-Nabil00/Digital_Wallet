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
    public partial class InternetBill : Form
    {
        public InternetBill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select phonenum,value from internet where phonenum ='" + textBox1.Text.Trim() + "'", con);
            cmd1.Parameters.AddWithValue("phonenum", textBox1.Text);
            SqlDataReader srd;
            srd = cmd1.ExecuteReader();
            if (srd.Read())
            {
                label4.Show();
                label4.Text = srd["value"].ToString();
                if (label4.Text == "0.0000")
                {
                    label6.Show();
                    label6.Text = "There is no bill";
                    Pay.Visible = false;
                    label2.Hide();
                    label5.Hide();
                    label4.Hide();
                }
                else
                {
                    label4.Show();
                    Pay.Visible = true;
                    label2.Hide();
                    label5.Hide();
                    label6.Hide();
                }



            }
            else
            {
                label2.Show();
                label2.Text = "Check your telephone number";
                Pay.Visible = false;
                label4.Hide();
                label5.Hide();
                label6.Hide();

            }
            con.Close();

        }

        private void Back_Click(object sender, EventArgs e)
        {
            form2 form = new form2();
            form.Show();
            this.Hide();
        }

        private void InternetBill_Load(object sender, EventArgs e)
        {
            label3.Parent = panel1;
            label3.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;

        }

        private void InternetBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            double x = double.Parse(label4.Text);
            double y = Convert.ToDouble(form2.balance);
            var z = y - x;
            if (z < 0)
            {
                label5.Show();
                label5.Text = "Not enough money";
                label2.Hide();
                label6.Hide();
                label4.Hide();
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Update Table1 set Balance=@Balance where MobileNumber='" + form2.number.Trim() + "'", con);
                cmd1.Parameters.AddWithValue("@Balance", z);
                SqlDataReader srd1;
                srd1 = cmd1.ExecuteReader();
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Update internet set value=@value where phonenum='" + textBox1.Text.Trim() + "'", con);
                cmd2.Parameters.AddWithValue("@value", 0);
                SqlDataReader srd2;
                srd2 = cmd2.ExecuteReader();
                Pay.Visible = false;
                label6.Hide();
                label5.Hide();
                label2.Hide();
                label4.Hide();
                MessageBox.Show("Bill was paid successfully ");
                con.Close();
                form2 form = new form2();
                form.Show();
                this.Hide();

            }
        }
    }
}
