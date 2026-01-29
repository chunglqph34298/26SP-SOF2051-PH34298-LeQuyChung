using Quan_Ly_Nhan_Su.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_Nhan_Su.DAO;

namespace Quan_Ly_Nhan_Su.DAL
{
    public static class NhanVienDAL
    {
        public static DataTable SelectAll()
        {
            DBUtil.OpenConnection();
            DataTable tmp = DBUtil.ExecuteQueryTable("SELECT * FROM nhan_vien", null);
            DBUtil.CloseConnection();
            return tmp;
        }

        public static int Insert(NhanVien nv)
        {
            DBUtil.OpenConnection();
            var sql = @"INSERT INTO nhan_vien(Ma_NV, Ten_NV, Ngay_Sinh, Gioi_Tinh, SDT, Email, Ngay_Vao_Lam)
                        VALUES(@0, @1, @2, @3, @4, @5, @6)";

            var rows = DBUtil.ExecuteNonQuery(sql, new List<object>
            {
                nv.Ma_NV,
                nv.Ten_NV,
                nv.Ngay_Sinh.ToDateTime(TimeOnly.MinValue),
                nv.Gioi_Tinh,
                nv.SDT,
                nv.Email,
                nv.Ngay_Vao_Lam.ToDateTime(TimeOnly.MinValue)
            });

            DBUtil.CloseConnection();
            return rows;
        }

        public static int Update(NhanVien nv)
        {
            DBUtil.OpenConnection();
            var sql = @"UPDATE nhan_vien
                        SET Ten_NV = @1,
                            Ngay_Sinh = @2,
                            Gioi_Tinh = @3,
                            SDT = @4,
                            Email = @5,
                            Ngay_Vao_Lam = @6
                        WHERE Ma_NV = @0";

            var rows = DBUtil.ExecuteNonQuery(sql, new List<object>
            {
                nv.Ma_NV,
                nv.Ten_NV,
                nv.Ngay_Sinh.ToDateTime(TimeOnly.MinValue),
                nv.Gioi_Tinh,
                nv.SDT,
                nv.Email,
                nv.Ngay_Vao_Lam.ToDateTime(TimeOnly.MinValue)
            });

            DBUtil.CloseConnection();
            return rows;
        }

        public static int Delete(string maNv)
        {
            DBUtil.OpenConnection();
            var rows = DBUtil.ExecuteNonQuery("DELETE FROM nhan_vien WHERE Ma_NV = @0", new List<object> { maNv });
            DBUtil.CloseConnection();
            return rows;
        }
    }
}
