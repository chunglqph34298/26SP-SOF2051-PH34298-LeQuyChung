using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.DAL;
using System;
using System.Data;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class PhongBanBLL
    {
        public static DataTable GetAll() => PhongBanDAL.GetAll();

        public static bool Insert(PhongBan pb)
        {
            Validate(pb);
            return PhongBanDAL.Insert(pb) > 0;
        }

        public static bool Update(PhongBan pb)
        {
            if (pb.MaPB <= 0) throw new Exception("Chưa chọn phòng ban để sửa");
            Validate(pb);
            return PhongBanDAL.Update(pb) > 0;
        }

        public static bool Delete(int maPB)
        {
            if (maPB <= 0) throw new Exception("Chưa chọn phòng ban để xóa");
            return PhongBanDAL.Delete(maPB) > 0;
        }

        private static void Validate(PhongBan pb)
        {
            if (string.IsNullOrWhiteSpace(pb.TenPB))
                throw new Exception("Tên phòng ban không được trống");

            // mô tả có thể để trống nếu m muốn, còn không thì bật check:
            // if (string.IsNullOrWhiteSpace(pb.MoTa))
            //     throw new Exception("Mô tả không được trống");

            if (pb.NgayThanhLap == null)
                throw new Exception("Chưa chọn ngày thành lập");
        }
    }
}
