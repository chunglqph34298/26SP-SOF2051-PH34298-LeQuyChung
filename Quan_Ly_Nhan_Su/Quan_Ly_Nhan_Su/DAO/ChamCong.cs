using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class ChamCong
    {
        public int Ma_CC { get; set; }
        public DateTime? Ngay { get; set; }      // DATE
        public DateTime? Gio_Vao { get; set; }   // DATETIME
        public DateTime? Gio_Ra { get; set; }    // DATETIME

        // FK
        public int? Ma_NV { get; set; }
    }
}
