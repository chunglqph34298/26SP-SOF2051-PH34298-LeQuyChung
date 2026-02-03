using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Nhan_Su.BLL
{
    public static class PhongBanBLL
    {
        public static DataTable GetAll() => PhongBanDAL.GetAll();
    }
}
