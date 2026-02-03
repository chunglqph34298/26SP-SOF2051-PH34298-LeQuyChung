using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace Quan_Ly_Nhan_Su.DAL
{
    public static class NhanVienDAL
    {
        // ===== GET ALL (JOIN) =====
        public static DataTable GetAll()
        {
            DBUtil.OpenConnection();

            string sql = @"
                SELECT nv.Ma_NV, nv.Ten_NV, nv.Ngay_Sinh, nv.Ngay_Vao_Lam, nv.Gioi_Tinh,
                       nv.SDT, nv.Email,
                       nv.Ma_CV, cv.Ten_CV,
                       nv.Ma_PB, pb.Ten_PB
                FROM nhan_vien nv
                LEFT JOIN Chuc_vu cv ON nv.Ma_CV = cv.Ma_CV
                LEFT JOIN Phong_Ban pb ON nv.Ma_PB = pb.Ma_PB
                ORDER BY nv.Ma_NV DESC";

            var dt = DBUtil.ExecuteQueryTable(sql, null);
            DBUtil.CloseConnection();
            return dt;
        }

        // ===== INSERT =====
        // Parameters bound by index: @0, @1, @2...
        public static int Insert(NhanVien nv)
        {
            DBUtil.OpenConnection();

            string sql = @"
                INSERT INTO nhan_vien
                (Ten_NV, Ngay_Sinh, Ngay_Vao_Lam, Gioi_Tinh, SDT, Email, Ma_CV, Ma_PB)
                VALUES
                (@0, @1, @2, @3, @4, @5, @6, @7)";

            var pr = new List<object>
            {
                nv.TenNV,
                (object?)nv.NgaySinh ?? DBNull.Value,
                (object?)nv.NgayVaoLam ?? DBNull.Value,
                nv.GioiTinh,
                nv.SDT,
                nv.Email,
                nv.MaCV,
                nv.MaPB
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        // ===== UPDATE =====
        public static int Update(NhanVien nv)
        {
            DBUtil.OpenConnection();

            string sql = @"
                UPDATE nhan_vien SET
                    Ten_NV = @0,
                    Ngay_Sinh = @1,
                    Ngay_Vao_Lam = @2,
                    Gioi_Tinh = @3,
                    SDT = @4,
                    Email = @5,
                    Ma_CV = @6,
                    Ma_PB = @7
                WHERE Ma_NV = @8";

            var pr = new List<object>
            {
                nv.TenNV,
                (object?)nv.NgaySinh ?? DBNull.Value,
                (object?)nv.NgayVaoLam ?? DBNull.Value,
                nv.GioiTinh,
                nv.SDT,
                nv.Email,
                nv.MaCV,
                nv.MaPB,
                nv.MaNV
            };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }

        // ===== DELETE =====
        public static int Delete(int maNV)
        {
            DBUtil.OpenConnection();

            string sql = "DELETE FROM nhan_vien WHERE Ma_NV = @0";
            var pr = new List<object> { maNV };

            int rows = DBUtil.ExecuteNonQuery(sql, pr);
            DBUtil.CloseConnection();
            return rows;
        }
    }
}
