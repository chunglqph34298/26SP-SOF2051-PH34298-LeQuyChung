using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class TaiKhoan
    {
        public int Ma_TK { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public bool Trang_Thai { get; set; } = true;

        // FK (1 NV = 1 TK)
        public int Ma_NV { get; set; }
    }
}
