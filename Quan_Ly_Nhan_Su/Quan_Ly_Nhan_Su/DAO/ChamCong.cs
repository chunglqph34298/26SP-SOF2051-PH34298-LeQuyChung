using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class ChamCong
    {
        public int MaCC { get; set; }
        public DateTime? Ngay { get; set; }
        public DateTime? GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public int? MaNV { get; set; } // FK -> nhan_vien
    }
}
