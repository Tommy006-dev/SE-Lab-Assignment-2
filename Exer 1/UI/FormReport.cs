using BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class FormReport : Form
    {
        private ReportService _reportService = new ReportService();
        private AgentService _agentService = new AgentService();
        private ItemService _itemService = new ItemService();
        public FormReport()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboItem.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int itemId = (int)cboItem.SelectedValue;
            var data = _reportService.GetAgentsByItem(itemId);

            dgvItemAgent.DataSource = data;

            if (dgvItemAgent.Columns.Count > 0)
            {
                dgvItemAgent.Columns["OrderID"].HeaderText = "Mã đơn";
                dgvItemAgent.Columns["OrderDate"].HeaderText = "Ngày đặt";
                dgvItemAgent.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvItemAgent.Columns["AgentName"].HeaderText = "Tên đại lý";
                dgvItemAgent.Columns["Address"].HeaderText = "Địa chỉ";
                dgvItemAgent.Columns["Quantity"].HeaderText = "Số lượng";
                dgvItemAgent.Columns["UnitAmount"].HeaderText = "Đơn giá";
                dgvItemAgent.Columns["UnitAmount"].DefaultCellStyle.Format = "N0";
                dgvItemAgent.Columns["UnitAmount"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvItemAgent.Columns["Total"].HeaderText = "Thành tiền";
                dgvItemAgent.Columns["Total"].DefaultCellStyle.Format = "N0";
                dgvItemAgent.Columns["Total"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            LoadAgentCombo();
            LoadItemCombo();
            // Load Tab 1 mặc định ngay khi mở
            LoadBestSellingItems();
        }

        public void LoadAgentCombo()
        {
            cboAgent.DataSource = _agentService.GetAllAgents();
            cboAgent.DisplayMember = "AgentName";
            cboAgent.ValueMember = "AgentID";
        }

        public void LoadItemCombo()
        {
            cboItem.DataSource = _itemService.GetAllItems();
            cboItem.DisplayMember = "ItemName";
            cboItem.ValueMember = "ItemID";
        }

        public void LoadBestSellingItems()
        {
            var data = _reportService.GetBestSellingItems()
                .Take((int)nudTop.Value)
                .ToList();

            dgvBestItem.DataSource = data;

            if (dgvBestItem.Columns.Count > 0)
            {
                dgvBestItem.Columns["ItemID"].Visible = false;
                dgvBestItem.Columns["ItemName"].HeaderText = "Tên sản phẩm";
                dgvBestItem.Columns["TotalQty"].HeaderText = "Tổng SL bán";
                dgvBestItem.Columns["TotalAmount"].HeaderText = "Doanh thu (VNĐ)";
                dgvBestItem.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvBestItem.Columns["TotalAmount"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvBestItem.Columns["TotalQty"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void btnFilterBest_Click(object sender, EventArgs e)
        {
            LoadBestSellingItems();
        }

        private void btnFilterAgent_Click(object sender, EventArgs e)
        {
            if (cboAgent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đại lý!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int agentId = (int)cboAgent.SelectedValue;
            var data = _reportService.GetItemsByAgent(agentId);

            dgvAgentItem.DataSource = data;

            if (dgvAgentItem.Columns.Count > 0)
            {
                dgvAgentItem.Columns["OrderID"].HeaderText = "Mã đơn";
                dgvAgentItem.Columns["OrderDate"].HeaderText = "Ngày đặt";
                dgvAgentItem.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvAgentItem.Columns["ItemName"].HeaderText = "Tên sản phẩm";
                dgvAgentItem.Columns["Size"].HeaderText = "Size";
                dgvAgentItem.Columns["Quantity"].HeaderText = "Số lượng";
                dgvAgentItem.Columns["UnitAmount"].HeaderText = "Đơn giá";
                dgvAgentItem.Columns["UnitAmount"].DefaultCellStyle.Format = "N0";
                dgvAgentItem.Columns["UnitAmount"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
                dgvAgentItem.Columns["Total"].HeaderText = "Thành tiền";
                dgvAgentItem.Columns["Total"].DefaultCellStyle.Format = "N0";
                dgvAgentItem.Columns["Total"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}
