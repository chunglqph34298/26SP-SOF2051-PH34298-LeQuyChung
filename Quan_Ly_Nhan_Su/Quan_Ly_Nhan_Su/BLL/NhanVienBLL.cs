using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DAL;
using System;
using System.Data;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class NhanVienBLL
    {
        public static DataTable GetAll() => NhanVienDAL.GetAll();

        public static bool Insert(NhanVien nv)
        {
            Validate(nv);
            return NhanVienDAL.Insert(nv) > 0;
        }

        public static bool Update(NhanVien nv)
        {
            if (nv.MaNV <= 0) throw new Exception("Chưa chọn nhân viên để sửa");
            Validate(nv);
            return NhanVienDAL.Update(nv) > 0;
        }

        public static bool Delete(int maNV)
        {
            if (maNV <= 0) throw new Exception("Mã nhân viên không hợp lệ");
            return NhanVienDAL.Delete(maNV) > 0;
        }

        private static void Validate(NhanVien nv)
        {
            if (string.IsNullOrWhiteSpace(nv.TenNV))
                throw new Exception("Tên nhân viên không được trống");

            if (string.IsNullOrWhiteSpace(nv.GioiTinh))
                throw new Exception("Chưa chọn giới tính");

            if (nv.NgayVaoLam == null)
                throw new Exception("Chưa chọn ngày vào làm");

            if (nv.MaCV <= 0) throw new Exception("Chưa chọn chức vụ");
            if (nv.MaPB <= 0) throw new Exception("Chưa chọn phòng ban");

            if (nv.NgaySinh != null && nv.NgayVaoLam != null &&
                nv.NgayVaoLam.Value.Date < nv.NgaySinh.Value.Date)
                throw new Exception("Ngày vào làm không được trước ngày sinh");
        }
    }
}
