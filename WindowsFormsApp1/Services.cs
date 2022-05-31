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
    public partial class form2 : Form
    {
        public static string balance;
        public static string number;
        static string sql = "Data Source=DESKTOP-PQN5CEB;Initial Catalog=userdb;Integrated Security=True ; User ID ='' ; Password = ''";
        SqlConnection con = new SqlConnection(sql);
        public form2()
        {
            InitializeComponent();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            label4.Text = SignIn.mobilenumber;

            label1.Parent = panel1;
            label1.BackColor = Color.Transparent;

            label4.Parent = panel1;
            label4.BackColor = Color.Transparent;


            label15.Parent = panel1;
            label15.BackColor = Color.Transparent;

            pictureBox1.Parent = panel1;
            pictureBox1.BackColor = Color.Transparent;

            pictureBox2.Parent = panel1;
            pictureBox2.BackColor = Color.Transparent;

            label3.Parent = panel1;
            label3.BackColor = Color.Transparent;
            label15.Parent = panel1;
            label15.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreditCard form = new CreditCard();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deposit form = new Deposit();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw form = new Withdraw();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transfer form = new Transfer();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recharge form = new Recharge();
            form.Show();
            this.Hide();
        }



        private void button7_Click_1(object sender, EventArgs e)
        {
            ElectricityBill form = new ElectricityBill();
            form.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GasBill form = new GasBill();
            form.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            WaterBill form = new WaterBill();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            InternetBill form = new InternetBill();
            form.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Balance from Table1 where MobileNumber = '" + label4.Text.Trim() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    label15.Text = dr[0].ToString();
                    balance = label15.Text;
                    number = label4.Text;
                }
            }
            con.Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}