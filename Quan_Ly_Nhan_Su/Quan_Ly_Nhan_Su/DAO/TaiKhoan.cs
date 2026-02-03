namespace Quan_Ly_Nhan_Su.DAO
{
    public class TaiKhoan
    {
        public int MaTK { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool TrangThai { get; set; } = true;

        public int MaNV { get; set; }  // UNIQUE FK -> nhan_vien
    }
}
