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
            LoadGridPhongBan();
            LoadGridHopDong();
            LoadGridBangLuong();
            WireBangLuongTinhThucLinh();
            // ===== NHÂN VIÊN =====
            dgvDsNhanVien.CellClick -= dgvDsNhanVien_CellContentClick;
            dgvDsNhanVien.CellClick += dgvDsNhanVien_CellContentClick;

            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Click -= btnLamMoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            // ===== CHỨC VỤ =====
            dgvChucVu.CellClick -= dgvChucVu_CellContentClick;
            dgvChucVu.CellClick += dgvChucVu_CellContentClick;

            btnThemCV.Click -= btnThemCV_Click;
            btnThemCV.Click += btnThemCV_Click;

            btnSuaCV.Click -= btnSuaCV_Click;
            btnSuaCV.Click += btnSuaCV_Click;

            btnXoaCV.Click -= btnXoaCV_Click;
            btnXoaCV.Click += btnXoaCV_Click;

            btnLamMoiCV.Click -= btnLamMoiCV_Click;
            btnLamMoiCV.Click += btnLamMoiCV_Click;

            // ===== PHÒNG BAN =====
            dgvPB.CellClick -= dgvPhongBan_CellClick;
            dgvPB.CellClick += dgvPhongBan_CellClick;

            btnThemPB.Click -= btnThemPB_Click;
            btnThemPB.Click += btnThemPB_Click;

            btnSuaPB.Click -= btnSuaPB_Click;
            btnSuaPB.Click += btnSuaPB_Click;

            btnXoaPB.Click -= btnXoaPB_Click;
            btnXoaPB.Click += btnXoaPB_Click;

            btnLamMoiPB.Click -= btnLamMoiPB_Click;
            btnLamMoiPB.Click += btnLamMoiPB_Click;

            // =========Hợp ĐỒng==========
            dgvHopDong.CellClick -= dgvHopDong_CellClick;
            dgvHopDong.CellClick += dgvHopDong_CellClick;

            btnThemHD.Click += btnThemHD_Click;
            btnSuaHD.Click += btnSuaHD_Click;
            btnXoaHD.Click += btnXoaHD_Click;
            btnLamMoiHD.Click += btnLamMoiHD_Click;

            //=========BANG LUONG=========
            dgvBangLuong.CellClick -= dgvBangLuong_CellClick;
            dgvBangLuong.CellClick += dgvBangLuong_CellClick;

            btnThemBL.Click -= btnThemBL_Click;
            btnThemBL.Click += btnThemBL_Click;

            btnSuaBL.Click -= btnSuaBL_Click;
            btnSuaBL.Click += btnSuaBL_Click;

            btnXoaBL.Click -= btnXoaBL_Click;
            btnXoaBL.Click += btnXoaBL_Click;

            btnLamMoiBL.Click -= btnLamMoiBL_Click;
            btnLamMoiBL.Click += btnLamMoiBL_Click;

            
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

            //PhongBan
            tbMaPB.ReadOnly = true;
            tbMaPB.Enabled = false;

            dtpNgayThanhLap.Format = DateTimePickerFormat.Custom;
            dtpNgayThanhLap.CustomFormat = "dd/MM/yyyy";

            tbMaHD.ReadOnly = true;
            tbMaHD.Enabled = false;

            //HOP DONG
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";

            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";

            cbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhanVien.DisplayMember = "Ten_NV";
            cbNhanVien.ValueMember = "Ma_NV";
            cbNhanVien.DataSource = NhanVienBLL.GetAll();
            cbNhanVien.SelectedIndex = -1;

            //Bang Luong
            tbMaBL.ReadOnly = true;
            tbMaBL.Enabled = false;

            tbThucTinh.ReadOnly = true; // vì BLL auto tính
            tbThucTinh.Enabled = false;

            cbNhanVienLuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhanVienLuong.DisplayMember = "Ten_NV";
            cbNhanVienLuong.ValueMember = "Ma_NV";
            cbNhanVienLuong.DataSource = NhanVienBLL.GetAll();
            cbNhanVienLuong.SelectedIndex = -1;

            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Value = DateTime.Now.Month;

            nudNam.Minimum = 1900;
            nudNam.Maximum = 3000;
            nudNam.Value = DateTime.Now.Year;

            
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
                    RefreshNhanVienCombos();
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
                    RefreshNhanVienCombos();
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
                        RefreshNhanVienCombos();
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
        private void LoadGridPhongBan()
        {
            dgvPB.AutoGenerateColumns = true;
            dgvPB.DataSource = PhongBanBLL.GetAll();

            dgvPB.ReadOnly = true;
            dgvPB.AllowUserToAddRows = false;
            dgvPB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPB.MultiSelect = false;

            if (dgvPB.Columns["Ma_PB"] != null) dgvPB.Columns["Ma_PB"].HeaderText = "Mã PB";
            if (dgvPB.Columns["Ten_PB"] != null) dgvPB.Columns["Ten_PB"].HeaderText = "Tên phòng ban";
            if (dgvPB.Columns["Mo_Ta"] != null) dgvPB.Columns["Mo_Ta"].HeaderText = "Mô tả";
            if (dgvPB.Columns["Ngay_Thanh_Lap"] != null) dgvPB.Columns["Ngay_Thanh_Lap"].HeaderText = "Ngày thành lập";
        }
        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPB.Rows[e.RowIndex];

            tbMaPB.Text = row.Cells["Ma_PB"].Value?.ToString();
            tbTenPB.Text = row.Cells["Ten_PB"].Value?.ToString();
            tbMoTaPB.Text = row.Cells["Mo_Ta"].Value?.ToString();

            if (row.Cells["Ngay_Thanh_Lap"].Value != null &&
                DateTime.TryParse(row.Cells["Ngay_Thanh_Lap"].Value.ToString(), out var d))
                dtpNgayThanhLap.Value = d;
        }
        private void ClearPhongBan()
        {
            tbMaPB.Clear();
            tbTenPB.Clear();
            tbMoTaPB.Clear();
            dtpNgayThanhLap.Value = DateTime.Now;
            tbTenPB.Focus();
        }
        private PhongBan GetPhongBanFromForm(bool includeId)
        {
            var pb = new PhongBan
            {
                TenPB = tbTenPB.Text.Trim(),
                MoTa = tbMoTaPB.Text.Trim(),
                NgayThanhLap = dtpNgayThanhLap.Value
            };

            if (includeId)
            {
                if (string.IsNullOrWhiteSpace(tbMaPB.Text))
                    throw new Exception("Chưa chọn phòng ban để sửa/xóa");

                pb.MaPB = int.Parse(tbMaPB.Text);
            }

            return pb;
        }
        private void btnThemPB_Click(object sender, EventArgs e)
        {
            try
            {
                var pb = GetPhongBanFromForm(false);

                if (PhongBanBLL.Insert(pb))
                {
                    MessageBox.Show("Thêm phòng ban thành công!");
                    LoadGridPhongBan();
                    ClearPhongBan();
                    RefreshNhanVienCombos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSuaPB_Click(object sender, EventArgs e)
        {
            try
            {
                var pb = GetPhongBanFromForm(true);

                if (PhongBanBLL.Update(pb))
                {
                    MessageBox.Show("Sửa phòng ban thành công!");
                    LoadGridPhongBan();
                    ClearPhongBan();
                    RefreshNhanVienCombos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnXoaPB_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMaPB.Text))
                    throw new Exception("Chưa chọn phòng ban để xóa");

                int ma = int.Parse(tbMaPB.Text);

                var ok = MessageBox.Show("Xóa phòng ban này luôn nha?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    if (PhongBanBLL.Delete(ma))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGridPhongBan();
                        ClearPhongBan();
                        RefreshNhanVienCombos();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnLamMoiPB_Click(object sender, EventArgs e)
        {
            ClearPhongBan();
            LoadGridPhongBan();
        }
        private void RefreshNhanVienCombos()
        {
            // Lưu lại lựa chọn hiện tại để refresh không bị reset ngáo
            var oldCV = cbChucVu.SelectedValue;
            var oldPB = cbPhongBan.SelectedValue;

            // Reload nguồn dữ liệu
            cbChucVu.DataSource = null;
            cbChucVu.DisplayMember = "Ten_CV";
            cbChucVu.ValueMember = "Ma_CV";
            cbChucVu.DataSource = ChucVuBLL.GetAll();

            cbPhongBan.DataSource = null;
            cbPhongBan.DisplayMember = "Ten_PB";
            cbPhongBan.ValueMember = "Ma_PB";
            cbPhongBan.DataSource = PhongBanBLL.GetAll();

            // Set lại lựa chọn cũ (nếu còn tồn tại)
            if (oldCV != null) cbChucVu.SelectedValue = oldCV;
            else cbChucVu.SelectedIndex = -1;

            if (oldPB != null) cbPhongBan.SelectedValue = oldPB;
            else cbPhongBan.SelectedIndex = -1;
        }
        private void LoadGridHopDong()
        {
            dgvHopDong.AutoGenerateColumns = true;
            dgvHopDong.DataSource = HopDongBLL.GetAll();

            dgvHopDong.ReadOnly = true;
            dgvHopDong.AllowUserToAddRows = false;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.MultiSelect = false;

            if (dgvHopDong.Columns["Ma_HD"] != null) dgvHopDong.Columns["Ma_HD"].HeaderText = "Mã HĐ";
            if (dgvHopDong.Columns["Loai_HD"] != null) dgvHopDong.Columns["Loai_HD"].HeaderText = "Loại hợp đồng";
            if (dgvHopDong.Columns["Ngay_Bat_Dau"] != null) dgvHopDong.Columns["Ngay_Bat_Dau"].HeaderText = "Ngày bắt đầu";
            if (dgvHopDong.Columns["Ngay_Ket_Thuc"] != null) dgvHopDong.Columns["Ngay_Ket_Thuc"].HeaderText = "Ngày kết thúc";
            if (dgvHopDong.Columns["Ten_NV"] != null) dgvHopDong.Columns["Ten_NV"].HeaderText = "Nhân viên";
        }
        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvHopDong.Rows[e.RowIndex];

            tbMaHD.Text = row.Cells["Ma_HD"].Value?.ToString();
            tbLoaiHD.Text = row.Cells["Loai_HD"].Value?.ToString();

            if (row.Cells["Ngay_Bat_Dau"].Value != null)
                dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["Ngay_Bat_Dau"].Value);

            if (row.Cells["Ngay_Ket_Thuc"].Value != null)
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["Ngay_Ket_Thuc"].Value);

            if (row.Cells["Ma_NV"].Value != null)
                cbNhanVien.SelectedValue = Convert.ToInt32(row.Cells["Ma_NV"].Value);
        }
        private HopDong GetHopDongFromForm(bool includeId)
        {
            var hd = new HopDong
            {
                LoaiHD = tbLoaiHD.Text.Trim(),
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value,
                MaNV = cbNhanVien.SelectedValue == null
                    ? null
                    : Convert.ToInt32(cbNhanVien.SelectedValue)
            };

            if (includeId)
            {
                if (string.IsNullOrWhiteSpace(tbMaHD.Text))
                    throw new Exception("Chưa chọn hợp đồng");

                hd.MaHD = int.Parse(tbMaHD.Text);
            }

            return hd;
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = GetHopDongFromForm(false);

                if (HopDongBLL.Insert(hd))
                {
                    MessageBox.Show("Thêm hợp đồng thành công!");
                    LoadGridHopDong();
                    ClearHopDong();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = GetHopDongFromForm(true);

                if (HopDongBLL.Update(hd))
                {
                    MessageBox.Show("Sửa hợp đồng thành công!");
                    LoadGridHopDong();
                    ClearHopDong();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMaHD.Text))
                    throw new Exception("Chưa chọn hợp đồng để xóa");

                int ma = int.Parse(tbMaHD.Text);

                var ok = MessageBox.Show("Xóa hợp đồng này luôn nha?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    if (HopDongBLL.Delete(ma))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGridHopDong();
                        ClearHopDong();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            ClearHopDong();
            LoadGridHopDong();
        }
        private void ClearHopDong()
        {
            tbMaHD.Clear();
            tbLoaiHD.Clear();
            cbNhanVien.SelectedIndex = -1;

            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;

            tbLoaiHD.Focus();
        }
        private void LoadGridBangLuong()
        {
            dgvBangLuong.AutoGenerateColumns = true;
            dgvBangLuong.DataSource = BangLuongBLL.GetAll();

            dgvBangLuong.ReadOnly = true;
            dgvBangLuong.AllowUserToAddRows = false;
            dgvBangLuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangLuong.MultiSelect = false;

            if (dgvBangLuong.Columns["Ma_BL"] != null) dgvBangLuong.Columns["Ma_BL"].HeaderText = "Mã BL";
            if (dgvBangLuong.Columns["Thang"] != null) dgvBangLuong.Columns["Thang"].HeaderText = "Tháng";
            if (dgvBangLuong.Columns["Nam"] != null) dgvBangLuong.Columns["Nam"].HeaderText = "Năm";
            if (dgvBangLuong.Columns["Luong_Co_Ban"] != null) dgvBangLuong.Columns["Luong_Co_Ban"].HeaderText = "Lương cơ bản";
            if (dgvBangLuong.Columns["Phu_Cap"] != null) dgvBangLuong.Columns["Phu_Cap"].HeaderText = "Phụ cấp";
            if (dgvBangLuong.Columns["Khau_Tru"] != null) dgvBangLuong.Columns["Khau_Tru"].HeaderText = "Khấu trừ";
            if (dgvBangLuong.Columns["Thuc_Tinh"] != null) dgvBangLuong.Columns["Thuc_Tinh"].HeaderText = "Thực lĩnh";
            if (dgvBangLuong.Columns["Ten_NV"] != null) dgvBangLuong.Columns["Ten_NV"].HeaderText = "Nhân viên";

            // ẩn FK
            if (dgvBangLuong.Columns["Ma_NV"] != null) dgvBangLuong.Columns["Ma_NV"].Visible = false;
        }

        private double ParseMoney(string s)
        {
            s = (s ?? "").Trim();
            if (string.IsNullOrWhiteSpace(s)) return 0;

            // cho nhập 1.000.000 hoặc 1,000,000 hoặc 1000000
            s = s.Replace(" ", "").Replace(",", "");
            if (!double.TryParse(s, out var v))
                throw new Exception("Tiền nhập không hợp lệ");

            return v;
        }
        private BangLuong GetBangLuongFromForm(bool includeId)
        {
            var bl = new BangLuong
            {
                Thang = (int)nudThang.Value,
                Nam = (int)nudNam.Value,
                LuongCoBan = ParseMoney(tbLuongCoBan.Text),
                PhuCap = ParseMoney(tbPhuCap.Text),
                KhauTru = ParseMoney(tbKhauTru.Text),
                MaNV = cbNhanVienLuong.SelectedValue == null
                    ? null
                    : Convert.ToInt32(cbNhanVienLuong.SelectedValue)
            };

            if (includeId)
            {
                if (string.IsNullOrWhiteSpace(tbMaBL.Text))
                    throw new Exception("Chưa chọn bảng lương");
                bl.MaBL = int.Parse(tbMaBL.Text);
            }

            return bl;
        }
        private void dgvBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvBangLuong.Rows[e.RowIndex];

            tbMaBL.Text = row.Cells["Ma_BL"].Value?.ToString();

            nudThang.Value = Convert.ToDecimal(row.Cells["Thang"].Value ?? 1);
            nudNam.Value = Convert.ToDecimal(row.Cells["Nam"].Value ?? DateTime.Now.Year);

            tbLuongCoBan.Text = row.Cells["Luong_Co_Ban"].Value?.ToString();
            tbPhuCap.Text = row.Cells["Phu_Cap"].Value?.ToString();
            tbKhauTru.Text = row.Cells["Khau_Tru"].Value?.ToString();
            tbThucTinh.Text = row.Cells["Thuc_Tinh"].Value?.ToString();

            if (row.Cells["Ma_NV"].Value != null)
                cbNhanVienLuong.SelectedValue = Convert.ToInt32(row.Cells["Ma_NV"].Value);
        }
        private void btnThemBL_Click(object sender, EventArgs e)
        {
            try
            {
                var bl = GetBangLuongFromForm(false);
                if (BangLuongBLL.Insert(bl))
                {
                    MessageBox.Show("Thêm bảng lương thành công!");
                    LoadGridBangLuong();
                    ClearBangLuong();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSuaBL_Click(object sender, EventArgs e)
        {
            try
            {
                var bl = GetBangLuongFromForm(true);
                if (BangLuongBLL.Update(bl))
                {
                    MessageBox.Show("Sửa bảng lương thành công!");
                    LoadGridBangLuong();
                    ClearBangLuong();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXoaBL_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMaBL.Text))
                    throw new Exception("Chưa chọn bảng lương để xóa");

                int ma = int.Parse(tbMaBL.Text);

                var ok = MessageBox.Show("Xóa bảng lương này luôn nha?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    if (BangLuongBLL.Delete(ma))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadGridBangLuong();
                        ClearBangLuong();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLamMoiBL_Click(object sender, EventArgs e)
        {
            ClearBangLuong();
            LoadGridBangLuong();
        }
        private void ClearBangLuong()
        {
            tbMaBL.Clear();
            cbNhanVienLuong.SelectedIndex = -1;

            nudThang.Value = DateTime.Now.Month;
            nudNam.Value = DateTime.Now.Year;

            tbLuongCoBan.Clear();
            tbPhuCap.Clear();
            tbKhauTru.Clear();
            tbThucTinh.Clear();
        }
        private void WireBangLuongTinhThucLinh()
        {
            tbLuongCoBan.TextChanged += (_, __) => UpdateThucLinhPreview();
            tbPhuCap.TextChanged += (_, __) => UpdateThucLinhPreview();
            tbKhauTru.TextChanged += (_, __) => UpdateThucLinhPreview();
        }

        private void UpdateThucLinhPreview()
        {
            try
            {
                var lcb = ParseMoney(tbLuongCoBan.Text);
                var pc = ParseMoney(tbPhuCap.Text);
                var kt = ParseMoney(tbKhauTru.Text);
                tbThucTinh.Text = (lcb + pc - kt).ToString();
            }
            catch
            {
                tbThucTinh.Text = "";
            }
        }

    }
}
