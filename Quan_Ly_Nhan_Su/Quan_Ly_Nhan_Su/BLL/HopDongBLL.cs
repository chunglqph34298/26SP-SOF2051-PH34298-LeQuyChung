using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DAL;
using System;
using System.Data;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class HopDongBLL
    {
        public static DataTable GetAll() => HopDongDAL.GetAll();

        public static bool Insert(HopDong hd)
        {
            Validate(hd);
            return HopDongDAL.Insert(hd) > 0;
        }

        public static bool Update(HopDong hd)
        {
            if (hd.MaHD <= 0)
                throw new Exception("Chưa chọn hợp đồng để sửa");

            Validate(hd);
            return HopDongDAL.Update(hd) > 0;
        }

        public static bool Delete(int maHD)
        {
            if (maHD <= 0)
                throw new Exception("Chưa chọn hợp đồng để xóa");

            return HopDongDAL.Delete(maHD) > 0;
        }

        private static void Validate(HopDong hd)
        {
            if (string.IsNullOrWhiteSpace(hd.LoaiHD))
                throw new Exception("Loại hợp đồng không được trống");

            if (hd.NgayBatDau == null)
                throw new Exception("Chưa chọn ngày bắt đầu");

            if (hd.NgayKetThuc == null)
                throw new Exception("Chưa chọn ngày kết thúc");

            if (hd.NgayKetThuc < hd.NgayBatDau)
                throw new Exception("Ngày kết thúc không được trước ngày bắt đầu");

            if (hd.MaNV == null || hd.MaNV <= 0)
                throw new Exception("Chưa chọn nhân viên");
        }
    }
}
