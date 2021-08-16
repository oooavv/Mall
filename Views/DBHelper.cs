using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Employee
{
    class DBHelper
    {
        public static int ExecuteNonQuery(string sql)
        {
            string son = "server = .;uid = sa;pwd = 123456;database = Retailer";
            SqlConnection con = new SqlConnection(son);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                return -1 * ex.Number;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public static object ExecuteScalar(string sql)
        {
            string son = "server = .;uid = sa;pwd = 123456;database = Retailer";
            SqlConnection con = new SqlConnection(son);
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                return cmd.ExecuteScalar();
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                if (con.State != System.Data.ConnectionState.Closed)
                    con.Close();
            }
        }

        public static SqlDataReader ExecuteReader(string sql)
        {
            string son = "server = .;uid = sa;pwd = 123456;database = Retailer";
            SqlConnection con = new SqlConnection(son);
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (SqlException)
            {
                if (con.State != System.Data.ConnectionState.Closed)
                    con.Close();
                return null;
            }
        }
    }
}
