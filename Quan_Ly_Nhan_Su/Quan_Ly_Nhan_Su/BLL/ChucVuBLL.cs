using Quan_Ly_Nhan_Su.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class ChucVuBLL
    {
        public static DataTable GetAll() => ChucVuDAL.GetAll();
    public static bool Insert(ChucVu cv)
        {
            Validate(cv);
            return ChucVuDAL.Insert(cv) > 0;
        }

        public static bool Update(ChucVu cv)
        {
            if (cv.MaCV <= 0) throw new Exception("Chưa chọn chức vụ để sửa");
            Validate(cv);
            return ChucVuDAL.Update(cv) > 0;
        }

        public static bool Delete(int maCV)
        {
            if (maCV <= 0) throw new Exception("Chưa chọn chức vụ để xóa");
            return ChucVuDAL.Delete(maCV) > 0;
        }

        private static void Validate(ChucVu cv)
        {
            if (string.IsNullOrWhiteSpace(cv.TenCV))
                throw new Exception("Tên chức vụ không được trống");
        }
    } 
}
