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
            InitUI();
            LoadCombos();
            LoadGrid();
            LoadGridChucVu();
        }
        private void InitUI()
        {
            tbMaNV.ReadOnly = true;

            // giới tính dạng string
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cbGioiTinh.SelectedIndex = -1;

            cbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgayVaoLam.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            tbMaCV.ReadOnly = true;
            tbMaCV.Enabled = false;

        }

        // ================== LOAD COMBO ==================
        private void LoadCombos()
        {
            // ===== Chức vụ =====
            cbChucVu.DataSource = null;
            cbChucVu.DisplayMember = "Ten_CV";
            cbChucVu.ValueMember = "Ma_CV";
            cbChucVu.DataSource = ChucVuBLL.GetAll();
            cbChucVu.SelectedIndex = -1;

            // ===== Phòng ban =====
            cbPhongBan.DataSource = null;
            cbPhongBan.DisplayMember = "Ten_PB";
            cbPhongBan.ValueMember = "Ma_PB";
            cbPhongBan.DataSource = PhongBanBLL.GetAll();
            cbPhongBan.SelectedIndex = -1;
        }

        // ================== GRID ==================
        private void LoadGrid()
        {
            dgvDsNhanVien.AutoGenerateColumns = true;
            dgvDsNhanVien.DataSource = NhanVienBLL.GetAll();

            // Tuỳ chọn UI grid
            dgvDsNhanVien.ReadOnly = true;
            dgvDsNhanVien.AllowUserToAddRows = false;
            dgvDsNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDsNhanVien.MultiSelect = false;

            // Đặt header cho dễ nhìn
            RenameGridHeaders();

            // Ẩn cột mã CV/PB (vì đã có Ten_CV, Ten_PB)
            if (dgvDsNhanVien.Columns["Ma_CV"] != null) dgvDsNhanVien.Columns["Ma_CV"].Visible = false;
            if (dgvDsNhanVien.Columns["Ma_PB"] != null) dgvDsNhanVien.Columns["Ma_PB"].Visible = false;
        }

        private void RenameGridHeaders()
        {
            if (dgvDsNhanVien.Columns["Ma_NV"] != null) dgvDsNhanVien.Columns["Ma_NV"].HeaderText = "Mã NV";
            if (dgvDsNhanVien.Columns["Ten_NV"] != null) dgvDsNhanVien.Columns["Ten_NV"].HeaderText = "Tên nhân viên";
            if (dgvDsNhanVien.Columns["Ngay_Sinh"] != null) dgvDsNhanVien.Columns["Ngay_Sinh"].HeaderText = "Ngày sinh";
            if (dgvDsNhanVien.Columns["Gioi_Tinh"] != null) dgvDsNhanVien.Columns["Gioi_Tinh"].HeaderText = "Giới tính";
            if (dgvDsNhanVien.Columns["SDT"] != null) dgvDsNhanVien.Columns["SDT"].HeaderText = "SĐT";
            if (dgvDsNhanVien.Columns["Email"] != null) dgvDsNhanVien.Columns["Email"].HeaderText = "Email";
            if (dgvDsNhanVien.Columns["Ten_CV"] != null) dgvDsNhanVien.Columns["Ten_CV"].HeaderText = "Chức vụ";
            if (dgvDsNhanVien.Columns["Ten_PB"] != null) dgvDsNhanVien.Columns["Ten_PB"].HeaderText = "Phòng ban";
        }

        // ================== MAPPING FORM <-> OBJECT ==================
        private NhanVien GetNhanVienFromForm(bool includeId)
        {
            var nv = new NhanVien
            {
                TenNV = tbTenNV.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                NgayVaoLam = dtpNgayVaoLam.Value,
                GioiTinh = cbGioiTinh.Text, // có thể rỗng, BLL sẽ bắt
                SDT = tbSDT.Text.Trim(),
                Email = tbEmail.Text.Trim(),

                // tránh lỗi null -> để 0 cho BLL bắt
                MaCV = cbChucVu.SelectedValue == null ? 0 : Convert.ToInt32(cbChucVu.SelectedValue),
                MaPB = cbPhongBan.SelectedValue == null ? 0 : Convert.ToInt32(cbPhongBan.SelectedValue)
            };

            if (includeId)
            {
                if (string.IsNullOrWhiteSpace(tbMaNV.Text))
                    throw new Exception("Chưa chọn nhân viên để sửa/xóa");

                nv.MaNV = int.Parse(tbMaNV.Text);
            }

            return nv;
        }

        private void FillFormFromGridRow(DataGridViewRow row)
        {
            tbMaNV.Text = row.Cells["Ma_NV"].Value?.ToString();
            tbTenNV.Text = row.Cells["Ten_NV"].Value?.ToString();
            tbSDT.Text = row.Cells["SDT"].Value?.ToString();
            tbEmail.Text = row.Cells["Email"].Value?.ToString();

            // Ngày sinh
            if (row.Cells["Ngay_Sinh"].Value != null && DateTime.TryParse(row.Cells["Ngay_Sinh"].Value.ToString(), out var d))
                dtpNgaySinh.Value = d;
            if (row.Cells["Ngay_Vao_Lam"].Value != null
                 && DateTime.TryParse(row.Cells["Ngay_Vao_Lam"].Value.ToString(), out var vl))
                dtpNgayVaoLam.Value = vl;

            // Giới tính string
            cbGioiTinh.Text = row.Cells["Gioi_Tinh"].Value?.ToString();

            // SelectedValue cần Ma_CV/Ma_PB
            if (row.Cells["Ma_CV"].Value != null)
                cbChucVu.SelectedValue = Convert.ToInt32(row.Cells["Ma_CV"].Value);

            if (row.Cells["Ma_PB"].Value != null)
                cbPhongBan.SelectedValue = Convert.ToInt32(row.Cells["Ma_PB"].Value);

        }

        private void ClearForm()
        {
            tbMaNV.Clear();
            tbTenNV.Clear();
            tbSDT.Clear();
            tbEmail.Clear();

            cbGioiTinh.SelectedIndex = -1;
            cbChucVu.SelectedIndex = -1;
            cbPhongBan.SelectedIndex = -1;

            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            tbTenNV.Focus();
        }

        // ================== EVENTS ==================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = GetNhanVienFromForm(includeId: false);

                if (NhanVienBLL.Insert(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadGrid();
                    ClearForm();
                }
                else MessageBox.Show("Thêm thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = GetNhanVienFromForm(includeId: true);

                if (NhanVienBLL.Update(nv))
                {
                    MessageBox.Show("Sửa nhân viên thành công!");
                    LoadGrid();
                    ClearForm();
                }
                else MessageBox.Show("Sửa thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMaNV.Text))
                    throw new Exception("Chưa chọn nhân viên để xóa");

                int maNV = int.Parse(tbMaNV.Text);

                var ok = MessageBox.Show("Xóa nhân viên này luôn nha?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    if (NhanVienBLL.Delete(maNV))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGrid();
                        ClearForm();
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadGrid();
        }

        private void dgvDsNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDsNhanVien.Rows[e.RowIndex];
            FillFormFromGridRow(row);
        }
        private void LoadGridChucVu()
        {
            dgvChucVu.AutoGenerateColumns = true;
            dgvChucVu.DataSource = ChucVuBLL.GetAll();

            dgvChucVu.ReadOnly = true;
            dgvChucVu.AllowUserToAddRows = false;
            dgvChucVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChucVu.MultiSelect = false;

            if (dgvChucVu.Columns["Ma_CV"] != null) dgvChucVu.Columns["Ma_CV"].HeaderText = "Mã chức vụ";
            if (dgvChucVu.Columns["Ten_CV"] != null) dgvChucVu.Columns["Ten_CV"].HeaderText = "Tên chức vụ";
        }

        private void dgvChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvChucVu.Rows[e.RowIndex];

            tbMaCV.Text = row.Cells["Ma_CV"].Value?.ToString();
            tbTenCV.Text = row.Cells["Ten_CV"].Value?.ToString();
        }
        private void ClearChucVu()
        {
            tbMaCV.Clear();
            tbTenCV.Clear();
            tbTenCV.Focus();
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            try
            {
                var cv = new ChucVu { TenCV = tbTenCV.Text.Trim() };

                if (ChucVuBLL.Insert(cv))
                {
                    MessageBox.Show("Thêm chức vụ thành công!");
                    LoadGridChucVu();
                    ClearChucVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {

            try
            {
                var cv = new ChucVu
                {
                    MaCV = string.IsNullOrWhiteSpace(tbMaCV.Text) ? 0 : int.Parse(tbMaCV.Text),
                    TenCV = tbTenCV.Text.Trim()
                };

                if (ChucVuBLL.Update(cv))
                {
                    MessageBox.Show("Sửa chức vụ thành công!");
                    LoadGridChucVu();
                    ClearChucVu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = string.IsNullOrWhiteSpace(tbMaCV.Text) ? 0 : int.Parse(tbMaCV.Text);

                var ok = MessageBox.Show("Xóa chức vụ này luôn nha?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    if (ChucVuBLL.Delete(ma))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGridChucVu();
                        ClearChucVu();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoiCV_Click(object sender, EventArgs e)
        {
            ClearChucVu();
            LoadGridChucVu();
        }
    }
}
