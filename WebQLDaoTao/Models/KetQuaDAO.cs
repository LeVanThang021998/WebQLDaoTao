using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebQLDaoTao.Models
{
    public class KetQuaDAO
    {
        public List<KetQua> getAll()
        {
            List<KetQua> ds = new List<KetQua>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from ketqua", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KetQua kq = new KetQua()
                {
                    Id = int.Parse(rd["id"].ToString()),
                    MaSV = rd["masv"].ToString(),
                    MaMH = rd["MaMH"].ToString(),
                    HoTenSV  = rd["hotensv"].ToString() + " " + rd["tensv"].ToString()
                };

                if (!string.IsNullOrEmpty(rd["diem"].ToString()))
                {
                    kq.Diem = float.Parse(rd["diem"].ToString());
                }
                ds.Add(kq);
            }
            return ds;
        }

        internal void Update(int id, float diem)
        {
            throw new NotImplementedException();
        }

        public List<KetQua> getByMaMH(string mamh)
        {
            List<KetQua> ds = new List<KetQua>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ketqua.*, hosv, tensv from " +
                "ketqua inner join sinhvien on ketqua.masv = sinhvien.masv where mamh=@mamh", conn);

            cmd.Parameters.AddWithValue("@mamh", mamh);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KetQua kq = new KetQua()
                {
                    Id = int.Parse(rd["id"].ToString()),
                    MaSV = rd["MaSV"].ToString(),
                    MaMH = rd["mamh"].ToString(),
                    HoTenSV = rd["hosv"].ToString() + " " + rd["tensv"].ToString()

                };
                if (!string.IsNullOrEmpty(rd["diem"].ToString()))
                {
                    kq.Diem = float.Parse(rd["diem"].ToString());
                }

                ds.Add(kq);
            }

            return ds;
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}