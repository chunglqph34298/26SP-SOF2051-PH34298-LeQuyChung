using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quan_Ly_Nhan_Su.DAL
{
    public static class PhongBanDAL
    {
        public static DataTable GetAll()
        {
            DBUtil.OpenConnection();
            string sql = @"
                SELECT Ma_PB, Ten_PB, Mo_Ta, Ngay_Thanh_Lap
                FROM Phong_Ban
                ORDER BY Ma_PB DESC";
            var dt = DBUtil.ExecuteQueryTable(sql, null);
            DBUtil.CloseConnection();
            return dt;
        }

        public static int Insert(PhongBan pb)
        {
            DBUtil.OpenConnection();
            string sql = @"
                INSERT INTO Phong_Ban (Ten_PB, Mo_Ta, Ngay_Thanh_Lap)
                VALUES (@0, @1, @2)";

            var pr = new List<object>
            {
                pb.TenPB,
                pb.MoTa,
                (object?)pb.NgayThanhLap ?? DBNull.Value
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Update(PhongBan pb)
        {
            DBUtil.OpenConnection();
            string sql = @"
                UPDATE Phong_Ban SET
                    Ten_PB = @0,
                    Mo_Ta = @1,
                    Ngay_Thanh_Lap = @2
                WHERE Ma_PB = @3";

            var pr = new List<object>
            {
                pb.TenPB,
                pb.MoTa,
                (object?)pb.NgayThanhLap ?? DBNull.Value,
                pb.MaPB
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Delete(int maPB)
        {
            DBUtil.OpenConnection();
            string sql = "DELETE FROM Phong_Ban WHERE Ma_PB = @0";
            var pr = new List<object> { maPB };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }
    }
}
