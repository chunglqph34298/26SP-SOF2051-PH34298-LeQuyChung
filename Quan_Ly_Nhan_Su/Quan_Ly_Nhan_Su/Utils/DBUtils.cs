using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Quan_Ly_Nhan_Su.Utils
{
    public static class DBUtil
    {
        private static readonly string _connectionString = "Server=CHUNG\\MSSQLSERVER02;" +

            "Database=Du_An_Mau_PH34298;" +
            "Integrated Security=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";

        private static SqlConnection? _connection = null;

        public static string? OpenConnection()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return null;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
        public static DataTable ExecuteQueryTable(string sql, List<object>? parameters)
        {
            SqlCommand command = new(sql, _connection);

            if (parameters != null)
            {
                int i = -1;
                parameters.ForEach(prm =>
                {
                    i++;
                    command.Parameters.AddWithValue($"@{i}", prm ?? DBNull.Value);
                });
            }

            SqlDataAdapter adapter = new(command);
            DataTable dt = new();
            adapter.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Execute INSERT/UPDATE/DELETE and return affected rows.
        /// Parameters are bound by index: @0, @1, @2...
        /// </summary>
        public static int ExecuteNonQuery(string sql, List<object>? parameters)
        {
            SqlCommand command = new(sql, _connection);

            if (parameters != null)
            {
                int i = -1;
                parameters.ForEach(prm =>
                {
                    i++;
                    command.Parameters.AddWithValue($"@{i}", prm ?? DBNull.Value);
                });
            }

            return command.ExecuteNonQuery();
        }

        public static string? CloseConnection()
        {
            try
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                return null;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
    }
}
