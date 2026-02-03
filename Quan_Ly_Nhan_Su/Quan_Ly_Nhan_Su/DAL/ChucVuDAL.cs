using Quan_Ly_Nhan_Su.DAO;
using Quan_Ly_Nhan_Su.Utils;
using System.Data;

public static class ChucVuDAL
{
    public static DataTable GetAll()
    {
        DBUtil.OpenConnection();

        string sql = "SELECT Ma_CV, Ten_CV FROM Chuc_vu ORDER BY Ten_CV";
        var dt = DBUtil.ExecuteQueryTable(sql, null); // hoặc new List<object>()

        DBUtil.CloseConnection();
        return dt;
    }
    public static int Insert(ChucVu cv)
    {
        DBUtil.OpenConnection();
        string sql = "INSERT INTO Chuc_vu(Ten_CV) VALUES (@0)";
        var pr = new List<object> { cv.TenCV };
        int rows = DBUtil.ExecuteNonQuery(sql, pr);
        DBUtil.CloseConnection();
        return rows;
    }

    public static int Update(ChucVu cv)
    {
        DBUtil.OpenConnection();
        string sql = "UPDATE Chuc_vu SET Ten_CV = @0 WHERE Ma_CV = @1";
        var pr = new List<object> { cv.TenCV, cv.MaCV };
        int rows = DBUtil.ExecuteNonQuery(sql, pr);
        DBUtil.CloseConnection();
        return rows;
    }

    public static int Delete(int maCV)
    {
        DBUtil.OpenConnection();
        string sql = "DELETE FROM Chuc_vu WHERE Ma_CV = @0";
        var pr = new List<object> { maCV };
        int rows = DBUtil.ExecuteNonQuery(sql, pr);
        DBUtil.CloseConnection();
        return rows;
    }
}
