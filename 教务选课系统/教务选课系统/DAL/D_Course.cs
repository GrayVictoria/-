using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using 教务选课系统.MODEL;

namespace 教务选课系统.DAL
{
    public class D_Course
    {
        DatabaseHelper db = new DatabaseHelper();

        public List<M_ChooseCourse> GetChooseMessage(int year, int term, int cid)
        {
            string sql = "select  dbo.stu.snum,dbo.stu.sname,dbo.stu.sclass from dbo.stu inner join [" + year + "-" + term + "] on [" + year + "-" + term + "].snum=stu.snum where [" + year + "-" + term + "].cid='" + cid + "' ";
            List<M_ChooseCourse> l = new List<M_ChooseCourse>();
            SqlDataReader dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_ChooseCourse M_C = new M_ChooseCourse();// M_C.M_Smessage.snum
                M_Student M_S = new M_Student();
                M_S.snum = dr["snum"].ToString();
                M_S.sname = dr["sname"].ToString();
                M_S.sclass = dr["sclass"].ToString();
                M_C.M_Smessage = M_S;
                l.Add(M_C);

            }
            dr.Close();


            return l;
        }
        public List<M_Course> GetCourse()
        {
            List<M_Course> l = new List<M_Course>();
            string sql = "select course.cnum,course.cname,coursevalue.value,teacher.tname,course.ccredit from [course]inner join [coursevalue]on coursevalue.id=course.id inner join [teacher] on course.cteacher=teacher.tnum; ";
            SqlDataReader dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_Course M_C = new M_Course();
                M_C.Coursenum = Convert.ToInt32(dr["cnum"]);
                M_C.Coursename = dr["cname"].ToString();
                M_C.Coursevalue = dr["value"].ToString();
                M_C.Courseteacher = dr["tname"].ToString();
                M_C.Coursecredit = dr["ccredit"].ToString();
                l.Add(M_C);
            }
            dr.Close();
            return l;
        }
        //搜寻学生课程
        public List<M_Course> SearchCourse(string cvalue, string status, string cnum)
        {
            List<M_Course> l = new List<M_Course>();
            string sql = "select distinct course.cnum,course.cname,coursevalue.value,teacher.tname,course.ccredit from [course]inner join [coursevalue]on coursevalue.id=course.id inner join [teacher] on course.cteacher=teacher.tnum inner join [2015-1] on [2015-1].cid=course.id ";
            if (cvalue != null)
            {
                sql = sql + "and coursevalue.value='" + cvalue + "'";
            }
            if (status != "")
            {
                if (status == "已选")
                {
                    sql = sql + " and [2015-1].id in(select [2015-1].id from dbo.[2015-1] inner join dbo.[course] on [2015-1].cid=course.id where [2015-1].snum='2013014172' )";
                }
                if (status == "未选")
                {
                    sql = sql + " and course.id not in (select  course.id from dbo.course inner join dbo.[2015-1] on [2015-1].cid=course.id where [2015-1].snum='2013014172' ) ";
                }
            }
            if (cnum != "")
            {
                sql = sql + "and course.cnum='" + cnum + "'";
            }
            SqlDataReader dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_Course M_C = new M_Course();
                M_C.Coursenum = Convert.ToInt32(dr["cnum"]);
                M_C.Coursename = dr["cname"].ToString();
                M_C.Coursevalue = dr["value"].ToString();
                M_C.Courseteacher = dr["tname"].ToString();
                M_C.Coursecredit = dr["ccredit"].ToString();
                l.Add(M_C);
            }
            dr.Close();


            return l;

        }
        //搜寻管理员课程,老师课程
        public List<M_Course> SearchAdCourse(string term, string major, string cnum)
        {
            List<M_Course> l = new List<M_Course>();
            string sql = "select distinct course.cnum,course.cname,course.cai,teacher.tname,course.ccredit from [course]inner join [coursevalue]on coursevalue.id=course.id inner join [teacher] on course.cteacher=teacher.tnum inner join [termmessage] on course.id=termmessage.id inner join [majormessage] on course.id=majormessage.id where 1=1";
            if (term != "")
            {
                sql = sql + "and termmessage.termname='" + term + "'";
            }
            if (major != "")
            {
                sql = sql + "and course.cai='" + major + "' ";
            }
            if (cnum != "")
            {
                sql = sql + "and course.cnum='" + cnum + "'";
            }
            SqlDataReader dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_Course M_C = new M_Course();
                M_C.Coursenum = Convert.ToInt32(dr["cnum"]);
                M_C.Coursename = dr["cname"].ToString();
                M_C.Coursecai = dr["cai"].ToString();
                M_C.Courseteacher = dr["tname"].ToString();
                M_C.Coursecredit = dr["ccredit"].ToString();
                l.Add(M_C);
            }
            dr.Close();


            return l;

        }
        //增加学生课程表课程
        public bool InsertCourse(string snum)
        {
            string sql = "insert into [2015-1](snum) values(@snum)";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@snum", SqlDbType.NVarChar, 50);
            pars[0].Value = snum;
            return db.ExeCommand(sql, pars);
        }
       
    }
}