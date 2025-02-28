using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class SinhVien
    {
        public String MaSV { get; set; }
        public String HoSV { get; set; }
        public String TenSV { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public String NoiSinh { get; set; }
        public String DiaChi { get; set; }
        public String MaKH { get; set; }
    }
}