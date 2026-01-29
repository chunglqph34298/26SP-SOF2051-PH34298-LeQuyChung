using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class NghiPhep
    {
        public int Ma_NP { get; set; }
        public DateTime? Tu_Ngay { get; set; }     // DATE
        public DateTime? Den_Ngay { get; set; }    // DATE
        public string? Ly_Do { get; set; }         // NVARCHAR(200)
        public string? Trang_Thai { get; set; }    // NVARCHAR(50)

        // FK
        public int? Ma_NV { get; set; }
    }
}
