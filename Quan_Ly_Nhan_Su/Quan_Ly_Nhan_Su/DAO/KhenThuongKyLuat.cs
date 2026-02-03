using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class KhenThuongKyLuat
    {
        public int MaKTKL { get; set; }

        // SQL: Loai BIT -- (1: Ky Luat, 0: Khen Thuong)
        public bool? Loai { get; set; }

        public string? HinhThuc { get; set; } // Thuong/Phat/Nhac Nho...
        public string? LyDo { get; set; }
        public DateTime? NgayApDung { get; set; }
        public double? SoTien { get; set; }

        public int? MaNV { get; set; } // FK -> nhan_vien
    }
}
