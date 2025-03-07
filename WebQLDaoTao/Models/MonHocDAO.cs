using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class MonHocDAO
    {
        //doc tat ca mon hoc
        public List<MonHoc> getAll()
        {
            List<MonHoc> ds = new List<MonHoc>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from monhoc", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ds.Add(new MonHoc
                {
                    MaMH = dr["mamh"].ToString(),
                    TenMH = dr["tenmh"].ToString(),
                    SoTiet = int.Parse(dr["sotiet"].ToString())
                });
            }
            return ds;
        }

        public int Insert(MonHoc mh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into monhoc values(@MaMH, @TenMH, @SoTiet)", conn);
            cmd.Parameters.AddWithValue("MaMH", mh.MaMH);
            cmd.Parameters.AddWithValue("TenMH", mh.TenMH);
            cmd.Parameters.AddWithValue("SoTiet", mh.SoTiet);
            return cmd.ExecuteNonQuery();
        }

        //Sửa môn học
        public int Update(MonHoc mh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update monhoc set TenMH = @TenMH, SoTiet = @SoTiet where MaMH = @MaMH", conn);
            cmd.Parameters.AddWithValue("MaMH", mh.MaMH);
            cmd.Parameters.AddWithValue("TenMH", mh.TenMH);
            cmd.Parameters.AddWithValue("SoTiet", mh.SoTiet);
            return cmd.ExecuteNonQuery();
        }

        //Xóa môn học
        public int Delete(string mamh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from monhoc where MaMH = @MaMH", conn);
            cmd.Parameters.AddWithValue("MaMH", mamh);
            return cmd.ExecuteNonQuery();
        }
    }
}