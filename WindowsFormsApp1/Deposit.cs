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
    public partial class Deposit : Form
    {
        private static double c;
        public static string money;
        public Deposit()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            form2 form = new form2();
            form.Show();
            this.Hide();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            label3.Parent = panel1;
            label3.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double d;
            
            string a,b;
            a = textBox1.Text;
            b = textBox2.Text;
            try {  c = Convert.ToDouble(b); }
            catch (System.FormatException)
            {
                label5.Show();
                label5.Text = "Invalid";
                label4.Hide();
                label6.Hide();

            }
            if (a.Length>16||a.Length<16)
            {
                label4.Show();
                label4.Text = "Wrong credit card number";
                label5.Hide();
                label6.Hide();
            }
            else if (c<=0)
            {
                label5.Show();
                label5.Text = "Invalid";
                label4.Hide();
                label6.Hide();
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''");
                
                con.Open();
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = con;
                //cmd.CommandText = "select money from credit where creditnum='1234123412341234'";
                //cmd.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select money from credit where creditnum='" + textBox1.Text.Trim() + "'and mobilenum='" + form2.number + "'",con);
                cmd.Parameters.AddWithValue("creditnum", textBox1.Text);                
                SqlDataReader srd;
                srd =cmd.ExecuteReader();
            //    MessageBox.Show(srd.Read().ToString());
                if (srd.HasRows)
                {
                  
                        string s = srd["money"].ToString();
                  
                    
                        MessageBox.Show(s);          
                }
               
                d = Convert.ToDouble(money);
                //MessageBox.Show( Convert.ToString(money));
                con.Close();
                //double x = double.Parse(textBox2.Text);
                double y = Convert.ToDouble(form2.balance);
                if (c < d)
                {
                    label6.Show();
                    label6.Text = "Not enough money";
                    label3.Hide();
                    label4.Hide();
                }
                else
                {
                    var z = y + c;
                    var w = d - c;
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Table1 set Balance=@Balance where MobileNumber='" + form2.number + "'", con);
                    cmd1.Parameters.AddWithValue("@Balance", z);
                    SqlDataReader srd1;
                    srd1 = cmd1.ExecuteReader();
                    con.Close();
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("Update credit set money=@money where creditnum='" + textBox1.Text.Trim() + "'and mobilenum='"+form2.number+"'", con);
                    cmd2.Parameters.AddWithValue("@money", w);
                    SqlDataReader srd2;
                    srd2 = cmd2.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Money paid successfully ");
                    form2 form = new form2();
                    form.Show();
                    this.Hide();
                }
                
            }
        }

        private void Deposit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
