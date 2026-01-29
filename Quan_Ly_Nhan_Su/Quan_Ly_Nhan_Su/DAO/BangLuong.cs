using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class BangLuong
    {
        public int Ma_BL { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }

        public double? Luong_Co_Ban { get; set; } // FLOAT
        public double? Phu_Cap { get; set; }      // FLOAT
        public double? Khau_Tru { get; set; }     // FLOAT
        public double? Thuc_Tinh { get; set; }    // FLOAT

        // FK
        public int? Ma_NV { get; set; }
    }
}
