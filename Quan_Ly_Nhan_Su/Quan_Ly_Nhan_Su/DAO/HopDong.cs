using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class HopDong
    {
        public int Ma_HD { get; set; }
        public string Loai_HD { get; set; } = "";    // NVARCHAR(50) NOT NULL
        public DateTime? Ngay_Bat_Dau { get; set; }  // DATE
        public DateTime? Ngay_Ket_Thuc { get; set; } // DATE

        // FK
        public int? Ma_NV { get; set; }
    }
}
