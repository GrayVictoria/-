using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace 教务选课系统.DAL
{
    public class DatabaseHelper
    {
        string strConn ="Data Source=Gray-PC\\SQLEXPRESS;Initial Catalog=UniversityManageSystem;Integrated Security=True";
        public SqlDataReader GetRead(string sql,SqlParameter[] pars)
        {
            //连接数据库对象
            SqlConnection conn = new SqlConnection(strConn);
            //执行命令对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (pars != null)
            {
                cmd.Parameters.AddRange(pars);
            }
            cmd.CommandType = CommandType.Text;
            //打开连接
            conn.Open();
            //执行读命令，返回SqlDataReader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        //执行插删改操作
        public bool ExeCommand(string sql, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                return count > 0 ? true : false;
            }
        }
    }
}
