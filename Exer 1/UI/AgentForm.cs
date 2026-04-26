using DAL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AgentForm : Form
    {
        private AgentService _service = new AgentService();
        public AgentForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new Agent
            {
                AgentName = txtItemName.Text,
                Address = txtPrice.Text,
            };
            if (_service.AddAgent(item))
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
                ClearForm();
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvItem.DataSource = _service.GetAllAgents();
        }

        private void ClearForm()
        {
            txtItemName.Clear();
            txtPrice.Clear();
            txtItemName.Focus(); // Đưa con trỏ chuột về lại ô đầu tiên
        }

        private void dgvItem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0) return;
            var row = dgvItem.SelectedRows[0];
            txtItemName.Text = row.Cells["AgentName"].Value?.ToString();
            txtPrice.Text = row.Cells["Address"].Value?.ToString();
        }
    }
}
