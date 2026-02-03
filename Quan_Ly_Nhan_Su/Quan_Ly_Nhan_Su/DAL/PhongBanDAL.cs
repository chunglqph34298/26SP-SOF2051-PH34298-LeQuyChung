using Quan_Ly_Nhan_Su.Utils;
using System.Data;

public static class PhongBanDAL
{
    public static DataTable GetAll()
    {
        DBUtil.OpenConnection();
        var dt = DBUtil.ExecuteQueryTable(
            "SELECT Ma_PB, Ten_PB FROM Phong_Ban", null
        );
        DBUtil.CloseConnection();
        return dt;
    }
}
