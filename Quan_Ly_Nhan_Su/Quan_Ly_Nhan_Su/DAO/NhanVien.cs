using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.DAO
{
    public class NhanVien
    {
        public string Ma_NV { get; set; }
        public string Ten_NV { get; set; }
        public DateOnly Ngay_Sinh { get; set; }
        public bool Gioi_Tinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateOnly Ngay_Vao_Lam { get; set; }


    }
}
