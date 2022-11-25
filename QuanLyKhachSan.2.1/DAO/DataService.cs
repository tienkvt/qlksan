using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyKhachSan._2._1
{
    class DataService
    {
        SqlConnection cn = new SqlConnection();

        public Boolean openConection()
        {

            try
            {
                cn = new SqlConnection();
                String str = @"Data Source=LEVY7F50\MSSQLSERVER2014;Initial Catalog=QLKS;Integrated Security=True";
                cn.ConnectionString = str;
                cn.Open();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public SqlDataReader getDataReader(String sql)
        {
            if (!openConection())
                return null;
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataTable getDataTable(String sql)
        {

            if (!openConection())
                return null;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            da.Fill(ds);
            cn.Close();
            return ds.Tables[0];
        }
        public void executeQuery(String sql)
        {
            if (!openConection())
                return;
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
