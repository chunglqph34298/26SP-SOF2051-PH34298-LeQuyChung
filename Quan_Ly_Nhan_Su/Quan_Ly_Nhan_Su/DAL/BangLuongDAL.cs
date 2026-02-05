using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quan_Ly_Nhan_Su.DAL
{
    public static class BangLuongDAL
    {
        public static DataTable GetAll()
        {
            DBUtil.OpenConnection();

            string sql = @"
                SELECT bl.Ma_BL, bl.Thang, bl.Nam,
                       bl.Luong_Co_Ban, bl.Phu_Cap, bl.Khau_Tru, bl.Thuc_Tinh,
                       bl.Ma_NV, nv.Ten_NV
                FROM Bang_Luong bl
                LEFT JOIN nhan_vien nv ON bl.Ma_NV = nv.Ma_NV
                ORDER BY bl.Nam DESC, bl.Thang DESC, bl.Ma_BL DESC";

            var dt = DBUtil.ExecuteQueryTable(sql, null);
            DBUtil.CloseConnection();
            return dt;
        }

        public static int Insert(BangLuong bl)
        {
            DBUtil.OpenConnection();

            string sql = @"
                INSERT INTO Bang_Luong
                (Thang, Nam, Luong_Co_Ban, Phu_Cap, Khau_Tru, Thuc_Tinh, Ma_NV)
                VALUES
                (@0, @1, @2, @3, @4, @5, @6)";

            var pr = new List<object>
            {
                (object?)bl.Thang ?? DBNull.Value,
                (object?)bl.Nam ?? DBNull.Value,
                (object?)bl.LuongCoBan ?? DBNull.Value,
                (object?)bl.PhuCap ?? DBNull.Value,
                (object?)bl.KhauTru ?? DBNull.Value,
                (object?)bl.ThucTinh ?? DBNull.Value,
                bl.MaNV
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Update(BangLuong bl)
        {
            DBUtil.OpenConnection();

            string sql = @"
                UPDATE Bang_Luong SET
                    Thang = @0,
                    Nam = @1,
                    Luong_Co_Ban = @2,
                    Phu_Cap = @3,
                    Khau_Tru = @4,
                    Thuc_Tinh = @5,
                    Ma_NV = @6
                WHERE Ma_BL = @7";

            var pr = new List<object>
            {
                (object?)bl.Thang ?? DBNull.Value,
                (object?)bl.Nam ?? DBNull.Value,
                (object?)bl.LuongCoBan ?? DBNull.Value,
                (object?)bl.PhuCap ?? DBNull.Value,
                (object?)bl.KhauTru ?? DBNull.Value,
                (object?)bl.ThucTinh ?? DBNull.Value,
                bl.MaNV,
                bl.MaBL
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Delete(int maBL)
        {
            DBUtil.OpenConnection();

            string sql = "DELETE FROM Bang_Luong WHERE Ma_BL = @0";
            var pr = new List<object> { maBL };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }
    }
}
