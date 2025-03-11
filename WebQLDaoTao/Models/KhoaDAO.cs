using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebQLDaoTao.Models
{
    public class KhoaDAO 
    {
        public List<Khoa> getAll()
        {
            List<Khoa> ds = new List<Khoa>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Khoa", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ds.Add(new Khoa
                {
                    MaKH = dr["makh"].ToString(),
                    TenKH = dr["tenkh"].ToString(),
                });
            }
            return ds;
        }

        public int Insert(Khoa kh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Khoa(makh,tenkh) values(@MaKH, @TenKH)", conn);
            cmd.Parameters.AddWithValue("@tenkh", kh.TenKH);
            cmd.Parameters.AddWithValue("@makh", kh.MaKH);
            return cmd.ExecuteNonQuery();
        }

        //Sửa môn học
        public int Update(Khoa kh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Khoa set tenkh = @tenkh, where makh = @makh", conn);
            cmd.Parameters.AddWithValue("@tenkh", kh. TenKH);
            cmd.Parameters.AddWithValue("@makh", kh.MaKH);
            return cmd.ExecuteNonQuery();
        }

        //Xóa môn học
        public int Delete(string makh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Khoa where makh = @makh", conn);
            cmd.Parameters.AddWithValue("@makh", makh);
            return cmd.ExecuteNonQuery();
        }
    }
}