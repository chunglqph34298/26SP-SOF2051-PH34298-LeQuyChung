using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class NghiPhep
    {
        public int MaNP { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public string? LyDo { get; set; }
        public string? TrangThai { get; set; }
        public int? MaNV { get; set; } // FK -> nhan_vien
    }
}
