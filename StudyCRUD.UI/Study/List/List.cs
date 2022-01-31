using StudyCRUD.DAL.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCRUD.UI.Study.List
{
    public partial class List : Form
    {
        public DataGridView dataGrid;
        public List()
        {
            InitializeComponent();
            dataGrid = dataGridView1;

        }
        ConnectionDB connectionDB = new ConnectionDB();
        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // 10 seconds / 10000 MillSecs
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connectionDB.GetAllUsers();
        }
        private void List_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connectionDB.GetAllUsers();
            InitTimer();
        }
        public void RefreshGridView()
        {
            dataGridView1.DataSource = connectionDB.GetAllUsers();
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Create.Create su = new Create.Create();
            su.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Create.Create su = new Create.Create();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Herhangi bir seçim yapmadınız.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            su.ID = dataGridView1.SelectedRows[0].Cells[0].EditedFormattedValue.ToString();
            su.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string Id = dataGridView1.SelectedRows[i].Cells[0].EditedFormattedValue.ToString();
                connectionDB.Delete(Id);
            }
            RefreshGridView();
        }
    }
}
