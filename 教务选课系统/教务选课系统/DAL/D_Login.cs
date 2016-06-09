using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace 教务选课系统.DAL
{
    public class D_Login
    {
        DatabaseHelper db = new DatabaseHelper();
        public M_Login Login(string username,string userpwd)
        {
            //查询语句
            string sql = "select * from dbo.users where users.unum='"+username+"' and users.upwd='"+userpwd+"'";
            //连接数据库字符串
            SqlDataReader dr = db.GetRead(sql, null);
            M_Login M_L = new M_Login();
            while (dr.Read())
            {
                M_L.username = dr["unum"].ToString();
                M_L.userpwd = dr["upwd"].ToString();
                M_L.state = Convert.ToInt32(dr["ustate"]);
            }
            if (M_L.username == null)
                return null;
            sql = "select * from dbo.presenttime";
            dr = db.GetRead(sql, null);
            while(dr.Read())
            {
                M_L.year = Convert.ToInt32(dr["year"]);
                M_L.term = Convert.ToInt32(dr["term"]);
            }
            return M_L;
        }
    }
}