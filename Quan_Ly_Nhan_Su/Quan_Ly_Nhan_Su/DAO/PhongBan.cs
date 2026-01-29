using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class PhongBan
    {
        public int Ma_PB { get; set; }
        public string Ten_PB { get; set; } = "";
        public string? Mo_Ta { get; set; }
        public DateTime? Ngay_Thanh_Lap { get; set; } // DATE
    }
}
