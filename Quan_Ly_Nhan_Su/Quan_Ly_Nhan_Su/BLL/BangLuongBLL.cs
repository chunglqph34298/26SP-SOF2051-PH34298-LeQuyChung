using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DAL;
using System;
using System.Data;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class BangLuongBLL
    {
        public static DataTable GetAll() => BangLuongDAL.GetAll();

        public static bool Insert(BangLuong bl)
        {
            NormalizeAndValidate(bl);
            return BangLuongDAL.Insert(bl) > 0;
        }

        public static bool Update(BangLuong bl)
        {
            if (bl.MaBL <= 0) throw new Exception("Chưa chọn bảng lương để sửa");
            NormalizeAndValidate(bl);
            return BangLuongDAL.Update(bl) > 0;
        }

        public static bool Delete(int maBL)
        {
            if (maBL <= 0) throw new Exception("Chưa chọn bảng lương để xóa");
            return BangLuongDAL.Delete(maBL) > 0;
        }

        private static void NormalizeAndValidate(BangLuong bl)
        {
            if (bl.MaNV == null || bl.MaNV <= 0)
                throw new Exception("Chưa chọn nhân viên");

            if (bl.Thang == null || bl.Thang < 1 || bl.Thang > 12)
                throw new Exception("Tháng phải từ 1 đến 12");

            if (bl.Nam == null || bl.Nam < 1900 || bl.Nam > 3000)
                throw new Exception("Năm không hợp lệ");

            bl.LuongCoBan ??= 0;
            bl.PhuCap ??= 0;
            bl.KhauTru ??= 0;

            if (bl.LuongCoBan < 0) throw new Exception("Lương cơ bản không được âm");
            if (bl.PhuCap < 0) throw new Exception("Phụ cấp không được âm");
            if (bl.KhauTru < 0) throw new Exception("Khấu trừ không được âm");

            // ✅ auto tính thực lĩnh
            bl.ThucTinh = bl.LuongCoBan + bl.PhuCap - bl.KhauTru;
        }
    }
}
