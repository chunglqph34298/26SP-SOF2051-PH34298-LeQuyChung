using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }

        // SQL của m đang là BIT: (0: Nu, 1: Nam)
        public string GioiTinh { get; set; }

        // ✅ Nếu m đã ALTER qua NVARCHAR "Nam/Nữ" thì đổi dòng trên thành:
        // public string? GioiTinh { get; set; }

        public string? SDT { get; set; }
        public string? Email { get; set; }
        public DateTime? NgayVaoLam { get; set; }

        public int? MaPB { get; set; }   // FK -> Phong_Ban
        public int? MaCV { get; set; }   // FK -> Chuc_vu
    }
}
