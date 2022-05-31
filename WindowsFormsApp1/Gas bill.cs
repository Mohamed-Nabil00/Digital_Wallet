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
    public partial class GasBill : Form
    {
        


        public GasBill()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select subscriber_gas,value from gas where subscriber_gas ='" + textBox1.Text.Trim() + "'", con);
            cmd1.Parameters.AddWithValue("subscriber_gas", textBox1.Text);           
            SqlDataReader srd;
            srd= cmd1.ExecuteReader();            
            if (srd.Read())
            {
                label3.Show();
                label3.Text = srd["value"].ToString();
                if (label3.Text=="0.0000")
                {
                    label6.Show();
                    label6.Text = "There is no bill";
                    Pay.Visible = false;
                    label2.Hide();
                    label5.Hide();
                    label3.Hide();
                }
                else
                {
                    label3.Show();
                    Pay.Visible = true;
                    label2.Hide();
                    label5.Hide();
                    label6.Hide();
                }
                



            }
            
            else
            {
                label2.Show();
                label2.Text = ("Check your subscriber number");
                Pay.Visible = false;
                label3.Hide();
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

        private void Pay_Click(object sender, EventArgs e)
        {
            double x=double.Parse(label3.Text);
            double y = Convert.ToDouble(SignIn.bala);
            var z = y - x;
            if (z<0)
            {
                label5.Show();
                label5.Text = "Not enough money";
                label2.Hide();
                label6.Hide();
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
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Update gas set value=@value where subscriber_gas='" + textBox1.Text.Trim() + "'", con);
                cmd2.Parameters.AddWithValue("@value", 0);
                SqlDataReader srd2;
                srd2 = cmd2.ExecuteReader();
                
                Pay.Visible = false;
                label6.Hide();
                label5.Hide();
                label2.Hide();
                label3.Hide();
                MessageBox.Show( "Bill was paid successfully ");
                
                con.Close();
                
                form2 form = new form2();
                form.Show();
                this.Hide();
                
                
            }
           

         

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GasBill_Load(object sender, EventArgs e)
        {

            label4.Parent = panel1;
            label4.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;


        }

        private void GasBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
