using StudyCRUD.DAL.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCRUD.UI.Study.Create
{
    public partial class Create : Form
    {
        ConnectionDB connectionDB = new ConnectionDB();
        public string ID { get; set; }
        public Create()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ID))
            {
                connectionDB.Insert(txtNameSurname.Text, txtPhone.Text, txtAddress.Text, txtBirthDate.Text);
                MessageBox.Show("Kayıt başarıyla eklenmiştir.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                connectionDB.Update(txtNameSurname.Text, txtPhone.Text, txtAddress.Text, txtBirthDate.Text,ID);
                MessageBox.Show("Kayıt başarıyla güncellenmiştir.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            List.List list = new List.List();
            list.dataGrid.DataSource = connectionDB.GetAllUsers();
            list.dataGrid.Refresh();
            list.dataGrid.Update();
            list.RefreshGridView();
            txtNameSurname.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtBirthDate.Text = "";
            this.Hide();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ID))
            {
                DataTable dt = connectionDB.GetUserByID(ID);
                txtNameSurname.Text = dt.Rows[0]["AD_SOYAD"].ToString();
                txtPhone.Text = dt.Rows[0]["TELEFON_NUMARASI"].ToString();
                txtAddress.Text = dt.Rows[0]["ADRES"].ToString();
                txtBirthDate.Text = dt.Rows[0]["DOGUM_TARIHI"].ToString();
                button1.Text = "Güncelle";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
