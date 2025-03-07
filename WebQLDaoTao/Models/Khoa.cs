using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebQLDaoTao.Models
{

    public class Khoa
    {
        public string MaKH { set; get; }
        public string TenKH { set; get; }
        public int SoTrinhDo { get; internal set; }
    }
       
}
