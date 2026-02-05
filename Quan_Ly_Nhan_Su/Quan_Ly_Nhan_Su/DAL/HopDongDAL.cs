using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quan_Ly_Nhan_Su.DAL
{
    public static class HopDongDAL
    {
        public static DataTable GetAll()
        {
            DBUtil.OpenConnection();

            string sql = @"
                SELECT hd.Ma_HD, hd.Loai_HD, hd.Ngay_Bat_Dau, hd.Ngay_Ket_Thuc,
                       hd.Ma_NV, nv.Ten_NV
                FROM Hop_Dong hd
                LEFT JOIN nhan_vien nv ON hd.Ma_NV = nv.Ma_NV
                ORDER BY hd.Ma_HD DESC";

            var dt = DBUtil.ExecuteQueryTable(sql, null);
            DBUtil.CloseConnection();
            return dt;
        }

        public static int Insert(HopDong hd)
        {
            DBUtil.OpenConnection();

            string sql = @"
                INSERT INTO Hop_Dong (Loai_HD, Ngay_Bat_Dau, Ngay_Ket_Thuc, Ma_NV)
                VALUES (@0, @1, @2, @3)";

            var pr = new List<object>
            {
                hd.LoaiHD,
                (object?)hd.NgayBatDau ?? DBNull.Value,
                (object?)hd.NgayKetThuc ?? DBNull.Value,
                hd.MaNV
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Update(HopDong hd)
        {
            DBUtil.OpenConnection();

            string sql = @"
                UPDATE Hop_Dong SET
                    Loai_HD = @0,
                    Ngay_Bat_Dau = @1,
                    Ngay_Ket_Thuc = @2,
                    Ma_NV = @3
                WHERE Ma_HD = @4";

            var pr = new List<object>
            {
                hd.LoaiHD,
                (object?)hd.NgayBatDau ?? DBNull.Value,
                (object?)hd.NgayKetThuc ?? DBNull.Value,
                hd.MaNV,
                hd.MaHD
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        public static int Delete(int maHD)
        {
            DBUtil.OpenConnection();

            string sql = "DELETE FROM Hop_Dong WHERE Ma_HD = @0";
            var pr = new List<object> { maHD };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }
    }
}
