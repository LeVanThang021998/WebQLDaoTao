using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class SinhVienDAO
    {
        public List<SinhVien> getAll()
        {
            List<SinhVien> ds = new List<SinhVien>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhVien", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                ds.Add(new SinhVien
                {
                    MaSV = rd["MaSV"].ToString(),
                    HoSV = rd["HoSV"].ToString(),
                    TenSV = rd["TenSV"].ToString(),
                    GioiTinh = Convert.ToBoolean(rd["GioiTinh"].ToString()),
                    NgaySinh = DateTime.Parse(rd["NgaySinh"].ToString()),
                    NoiSinh = rd["noisinh"].ToString(),
                    DiaChi = rd["diachi"].ToString(),
                    MaKH = rd["makh"].ToString()
                });
            }
            return ds;
        }
        public int Update(SinhVien sv)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE sinhvien SET hosv=@hosv, tensv=@tensv, gioitinh=@gioitinh, " +
                                            "ngaysinh=@ngaysinh, noisinh=@noisinh, diachi=@diachi, makh=@makh " +
                                            "WHERE masv = @masv", conn);

            cmd.Parameters.AddWithValue("@masv", sv.MaSV);
            cmd.Parameters.AddWithValue("@hosv", sv.HoSV);
            cmd.Parameters.AddWithValue("@tensv", sv.TenSV);
            cmd.Parameters.AddWithValue("@gioitinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@noisinh", sv.NoiSinh);
            cmd.Parameters.AddWithValue("@diachi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@makh", sv.MaKH);

            return cmd.ExecuteNonQuery();
        }

    }
}