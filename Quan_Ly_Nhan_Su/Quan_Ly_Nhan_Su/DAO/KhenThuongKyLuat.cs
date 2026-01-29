using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class KhenThuongKyLuat
    {
        public int Ma_KT_KL { get; set; }
        public bool? Loai { get; set; }          // BIT (1: Kỷ luật, 0: Khen thưởng)
        public string? Hinh_Thuc { get; set; }   // NVARCHAR(50)
        public string? Ly_Do { get; set; }       // NVARCHAR(200)
        public DateTime? Ngay_Ap_Dung { get; set; } // DATE
        public double? So_Tien { get; set; }     // FLOAT

        // FK
        public int? Ma_NV { get; set; }
    }
}
