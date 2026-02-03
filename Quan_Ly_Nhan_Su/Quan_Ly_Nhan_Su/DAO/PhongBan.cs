using System;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class PhongBan
    {
        public int MaPB { get; set; }
        public string TenPB { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public DateTime? NgayThanhLap { get; set; }
    }
}
