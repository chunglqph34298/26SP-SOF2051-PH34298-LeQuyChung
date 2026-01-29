using Quan_Ly_Nhan_Su.BLL;
using Quan_Ly_Nhan_Su.DAL;
using Quan_Ly_Nhan_Su.DAO;
namespace Quan_Ly_Nhan_Su
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WireEvents();
            SelectAll();
        }
        private void WireEvents()
        {
            // Nhan Vien tab
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            dgvDsNhanVien.CellClick += dgvDsNhanVien_CellClick;
        }
        public void SelectAll()
        {
            dgvDsNhanVien.DataSource = NhanVienDAL.SelectAll();
        }
        private void dgvDsNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dgvDsNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDsNhanVien.Rows[e.RowIndex].DataBoundItem == null) return;

            // NOTE: designer đang để tên control hơi "auto" (textBox1..4)
            // Map:
            // tbMaNV = Ma_NV
            // textBox1 = Ten_NV
            // dateTimePicker1 = Ngay_Sinh
            // textBox3 = Gioi_Tinh
            // textBox2 = SDT
            // textBox4 = Email
            // dateTimePicker2 = Ngay_Vao_Lam

            var row = dgvDsNhanVien.Rows[e.RowIndex];
            tbMaNV.Text = row.Cells["Ma_NV"].Value?.ToString() ?? "";
            textBox1.Text = row.Cells["Ten_NV"].Value?.ToString() ?? "";
            textBox2.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            textBox4.Text = row.Cells["Email"].Value?.ToString() ?? "";

            // Gioi_Tinh (bit) => show Nam/Nu cho dễ
            var gt = row.Cells["Gioi_Tinh"].Value;
            bool isNam = false;
            if (gt is bool b) isNam = b;
            else bool.TryParse(gt?.ToString(), out isNam);
            textBox3.Text = isNam ? "Nam" : "Nữ";

            // Date columns
            if (DateTime.TryParse(row.Cells["Ngay_Sinh"].Value?.ToString(), out var ns))
                dateTimePicker1.Value = ns;

            if (DateTime.TryParse(row.Cells["Ngay_Vao_Lam"].Value?.ToString(), out var nvl))
                dateTimePicker2.Value = nvl;
        }
        private static bool ParseGioiTinh(string? input)
        {
            var s = (input ?? "").Trim().ToLowerInvariant();

            // Cho phép người dùng gõ: Nam/Nu/Nữ/true/false/1/0
            if (s == "nam" || s == "male" || s == "m" || s == "1" || s == "true") return true;
            if (s == "nu" || s == "nữ" || s == "female" || s == "f" || s == "0" || s == "false") return false;

            // fallback: false
            return false;
        }
        private NhanVien ReadNhanVienFromForm()
        {
            var ma = (tbMaNV.Text ?? "").Trim();
            var ten = (textBox1.Text ?? "").Trim();
            var sdt = (textBox2.Text ?? "").Trim();
            var email = (textBox4.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(ma))
                throw new InvalidOperationException("Mã nhân viên không được để trống.");
            if (string.IsNullOrWhiteSpace(ten))
                throw new InvalidOperationException("Tên nhân viên không được để trống.");

            return new NhanVien
            {
                Ma_NV = ma,
                Ten_NV = ten,
                Ngay_Sinh = DateOnly.FromDateTime(dateTimePicker1.Value.Date),
                Gioi_Tinh = ParseGioiTinh(textBox3.Text),
                SDT = sdt,
                Email = email,
                Ngay_Vao_Lam = DateOnly.FromDateTime(dateTimePicker2.Value.Date)
            };
        }
        private void ClearNhanVienForm()
        {
            tbMaNV.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            tbMaNV.Focus();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = ReadNhanVienFromForm();
                var rows = NhanVienDAL.Insert(nv);
                MessageBox.Show(rows > 0 ? "Thêm nhân viên OK." : "Không thêm được (0 rows).", "Thông báo");
                SelectAll();
                ClearNhanVienForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = ReadNhanVienFromForm();
                var rows = NhanVienDAL.Update(nv);
                MessageBox.Show(rows > 0 ? "Sửa nhân viên OK." : "Không sửa được (0 rows).", "Thông báo");
                SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var ma = (tbMaNV.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Chọn nhân viên cần xóa (hoặc nhập Mã NV).", "Thiếu dữ liệu");
                return;
            }

            var ok = MessageBox.Show($"Xóa nhân viên {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            try
            {
                var rows = NhanVienDAL.Delete(ma);
                MessageBox.Show(rows > 0 ? "Xóa nhân viên OK." : "Không xóa được (0 rows).", "Thông báo");
                SelectAll();
                ClearNhanVienForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearNhanVienForm();
            SelectAll();
        }
    }
}
