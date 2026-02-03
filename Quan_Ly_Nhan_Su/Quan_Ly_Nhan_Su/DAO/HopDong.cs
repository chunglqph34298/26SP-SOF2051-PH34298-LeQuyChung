using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class HopDong
    {
        public int MaHD { get; set; }
        public string LoaiHD { get; set; } = string.Empty;
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? MaNV { get; set; } // FK -> nhan_vien
    }
}
