using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_3layers
{
    public class Database
    {
        private string connetionString = @"Data Source=localhost\sqlexpress;Initial Catalog = QLSV; User ID = sa; Password=vuigame1";
        private SqlConnection conn;
        //private string sql;
        private DataTable dt;
        private SqlCommand cmd;
        public Database() { 
            try { 
                conn = new SqlConnection(connetionString);  
            } 
            catch(Exception ex) { 
                MessageBox.Show("connected failed: " + ex.Message);
            }    
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                //sql = "exec SelectAllSinhVien";
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (CustomParameter p in lstPara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            { conn.Close(); }
        }
        public DataRow Select(string sql) 
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql,conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];  
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi load thông tin chi tiết: "+ex.Message); 
                return null;
            }
            finally 
            {
                conn.Close();
            }
        }
        public int Execute(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (CustomParameter p in lstPara)
                {
                    cmd.Parameters.AddWithValue(p.key, p.value);
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                return -100;
            }
            finally { conn.Close(); }
        }
    }
}
