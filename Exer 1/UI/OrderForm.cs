using DAL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderForm : Form
    {

        private OrderService _orderService = new OrderService();
        private AgentService _agentService = new AgentService();
        private ItemService _itemService = new ItemService();
        private DataTable _dtDetail = new DataTable();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Load ComboBox Agent
            cboAgent.DataSource = _agentService.GetAllAgents();
            cboAgent.DisplayMember = "AgentName";
            cboAgent.ValueMember = "AgentID";

            // Load ComboBox Item
            cboItem.DataSource = _itemService.GetAllItems();
            cboItem.DisplayMember = "ItemName";
            cboItem.ValueMember = "ItemID";

            // Khởi tạo DataTable cho chi tiết
            _dtDetail.Columns.Add("ItemID", typeof(int));
            _dtDetail.Columns.Add("ItemName", typeof(string));
            _dtDetail.Columns.Add("Quantity", typeof(int));
            _dtDetail.Columns.Add("Total", typeof(decimal));
            dgvDetail.DataSource = _dtDetail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int itemId = (int)cboItem.SelectedValue;
            string name = cboItem.Text;
            int qty = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtUnitAmount.Text);

            _dtDetail.Rows.Add(itemId, name, qty, price, qty * price);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = _dtDetail.AsEnumerable()
                                     .Sum(r => r.Field<decimal>("Total"));
            textBox3.Text = total.ToString("N0") + " VNĐ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                OrderDate = dtpOrderDate.Value,
                AgentID = (int)cboAgent.SelectedValue
            };

            foreach (DataRow row in _dtDetail.Rows)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ItemID = (int)row["ItemID"],
                    Quantity = (int)row["Quantity"],
                    UnitAmount = (decimal)row["UnitAmount"]
                });
            }

            _orderService.AddOrder(order);
            MessageBox.Show("Lưu đơn hàng thành công!");
        }

    }
}
