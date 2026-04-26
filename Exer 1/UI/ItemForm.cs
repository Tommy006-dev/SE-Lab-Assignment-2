using DAL;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class ItemForm : Form
    {
        private ItemService _service = new ItemService();
        public ItemForm()
        {
            InitializeComponent();
        }

        private void Item_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvItem.DataSource = _service.GetAllItems();
        }

        private void ClearForm()
        {
            txtItemName.Clear();
            txtSize.Clear();
            txtPrice.Clear();
            txtItemName.Focus(); // Đưa con trỏ chuột về lại ô đầu tiên
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new Item
            {
                ItemName = txtItemName.Text,
                Size = txtSize.Text,
                Price = decimal.Parse(txtPrice.Text)
            };
            if (_service.AddItem(item))
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
                ClearForm();
            }
        }

        private void dgvItem_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count == 0) return;
            var row = dgvItem.SelectedRows[0];
            txtItemName.Text = row.Cells["ItemName"].Value?.ToString();
            txtSize.Text = row.Cells["Size"].Value?.ToString();
            txtPrice.Text = row.Cells["Price"].Value?.ToString();
        }
    }
}
