namespace Quan_Ly_Nhan_Su.DAO
{
    public class BangLuong
    {
        public int MaBL { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }

        public double? LuongCoBan { get; set; }
        public double? PhuCap { get; set; }
        public double? KhauTru { get; set; }
        public double? ThucTinh { get; set; }

        public int? MaNV { get; set; } // FK -> nhan_vien
    }
}
