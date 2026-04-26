using DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        public MainForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Xin chào: {_currentUser.UserName}";

            // Bắt đầu đồng hồ
            timer1.Interval = 1000;
            timer1.Start();

            // Tạo menu trái
            BuildLeftMenu();

            // Hiển thị trang chủ mặ
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        }

        private void BuildLeftMenu()
        {
            panelLeft.Controls.Clear();
            panelLeft.BackColor = Color.FromArgb(30, 30, 60);

            // Label tiêu đề menu
            var lblTitle = new Label
            {
                Text = "📋 MENU",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelLeft.Controls.Add(lblTitle);

            // Danh sách nút menu
            var menuItems = new[]
            {
                ("🏠  Trang chủ",       (EventHandler)((s,e) => ShowWelcomePanel())),
                ("📦  Sản phẩm",        (EventHandler)((s,e) => OpenForm(new ItemForm()))),
                ("🏢  Đại lý",          (EventHandler)((s,e) => OpenForm(new AgentForm()))),
                ("📝  Tạo đơn hàng",    (EventHandler)((s,e) => OpenForm(new OrderForm()))),
                ("📊  Báo cáo / Lọc",   (EventHandler)((s,e) => OpenForm(new FormReport()))),
            };

            foreach (var (text, handler) in menuItems)
            {
                var btn = CreateMenuButton(text);
                btn.Click += handler;
                panelLeft.Controls.Add(btn);
            }

            // Nút đăng xuất ở dưới cùng
            var btnLogout = CreateMenuButton("🚪  Đăng xuất");
            btnLogout.BackColor = Color.FromArgb(180, 30, 30);
            btnLogout.Click += btnLogout_Click;
            btnLogout.Dock = DockStyle.Bottom;
            panelLeft.Controls.Add(btnLogout);
        }
        private Button CreateMenuButton(string text)
        {
            return new Button
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(40, 40, 80),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void OpenForm(Form childForm)
        {
            // Đóng form cũ nếu có
            foreach (Control ctrl in panelContent.Controls)
                ctrl.Dispose();
            panelContent.Controls.Clear();

            // Nhúng form con vào panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowWelcomePanel()
        {
            foreach (Control ctrl in panelContent.Controls)
                ctrl.Dispose();
            panelContent.Controls.Clear();

            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };

            var lbl = new Label
            {
                Text = $"👋 Chào mừng, {_currentUser.UserName}!\n\n" +
                             "Chọn chức năng từ menu bên trái để bắt đầu.",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(30, 30, 60),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnl.Controls.Add(lbl);
            panelContent.Controls.Add(pnl);
        }

        private void mnuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemForm());
        }

        private void mnuAgent_Click(object sender, EventArgs e)
        {
            OpenForm(new AgentForm());
        }

        private void mnuCreateOrder_Click(object sender, EventArgs e)
        {
            OpenForm(new OrderForm());
        }

        private void mnuReport_Click(object sender, EventArgs e)
        {
            OpenForm(new FormReport());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                timer1.Stop();
                var login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}
