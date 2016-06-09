using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using 教务选课系统.MODEL;
using 教务选课系统.DAL;
using System.Data;

namespace 教务选课系统.DAL
{
    public class D_CourseDetail
    {
        DatabaseHelper db = new DatabaseHelper();

        public List<M_value> searchcoursevalue()
         {
             string sql = "select value from dbo.coursevalue";
             SqlDataReader dr = db.GetRead(sql, null);
             List<M_value> l = new List<M_value>();
             while(dr.Read())
             {
                 M_value m_v = new M_value();
                 m_v.value = dr["value"].ToString();
                 l.Add(m_v);
             }
             return l;
         }

        public List<M_major> seachmajor()
        {
            string sql = "select mname from dbo.majormessage";
            SqlDataReader dr = db.GetRead(sql, null);
            List<M_major> l = new List<M_major>();
            while(dr.Read())
            {
                M_major m_m = new M_major();
                m_m.mname = dr["mname"].ToString();
                l.Add(m_m);
            }
            return l;
        }

        public string searchteachername(string tnum)
        {
            string sql = "select tname from dbo.teacher where tnum='"+tnum+"'";
            SqlDataReader dr = db.GetRead(sql, null);
            string tname="";
            while (dr.Read())
            {
                tname = dr["tname"].ToString();
            }
            return tname;
        }

        public List<M_CourseDetail> search(string id)
        {

            //string sql="Select * Form 表名 Where 字段名 Like '%" + "@参数名" + "%'" ;
            string sql = "select * from course left join majormessage on course.cmajor=majormessage.id left join coursevalue on course.cmajor=coursevalue.id where course.id=@id";
            SqlParameter[] pars = new SqlParameter[1];
            pars[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            pars[0].Value = id;
            SqlDataReader dr = db.GetRead(sql, pars);
            List<M_CourseDetail> list = new List<M_CourseDetail>();
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_major M_m = new M_major();
                M_value M_v = new M_value();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.cnum = dr["cnum"].ToString();
                M_course.cplace = dr["cplace"].ToString();
                M_course.ctime = this.Timechuli(dr["ctime"].ToString());
                M_course.csemaster = Convert.ToInt32(dr["csemaster"]);
                M_m.mname = dr["mname"].ToString();
                M_course.cmajor = M_m;
                //M_course.cmajor = dr["cmajor"].ToString();
                //M_course.cvalue = Convert.ToInt32(dr["cvalue"]);
                M_v.value = dr["value"].ToString();
                M_course.cvalue = M_v;
                M_course.cai = dr["cai"].ToString();
                M_course.ccredit = Convert.ToSingle(dr["ccredit"]);
                M_course.ctnum = dr["ctnum"].ToString();
                       
                string teacher1 = dr["cteacher"].ToString();
                string teacher2 = dr["cteacher2"].ToString();
                string teacher3 = dr["cteacher3"].ToString();
                string teachername = "";
                if(teacher1!="")
                {
                    teachername=teachername+searchteachername(teacher1);
                }
                if (teacher2 != "")
                {
                    teachername = teachername +" "+ searchteachername(teacher2);
                }
                if (teacher3 != "")
                {
                    teachername = teachername +" "+ searchteachername(teacher3);
                }
                M_course.cteacher = teachername;


                M_course.cname = dr["cname"].ToString();
                M_course.cintroduction = dr["cintroduction"].ToString();
                M_course.cyear = dr["cyear"].ToString();
                list.Add(M_course);
            }
            return list;
        }

        
        public List<M_CourseDetail> GetAllCourseAdministrators(string term, string major, string cnum)
        {
            string sql = "select * from course left join majormessage on course.cmajor=majormessage.id where 1=1";
            if (major != ""&&major!=null)
                sql = sql + " and majormessage.mname='" + major + "' ";
            if (term != ""&&term!=null)
                sql = sql + " and course.csemaster='" + term + "' ";
            if (cnum != ""&&cnum!=null)
                sql = sql + " and course.cnum='" + cnum + "'";
            SqlDataReader dr = db.GetRead(sql, null);
            List<M_CourseDetail> list = new List<M_CourseDetail>();
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_major M_m = new M_major();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.cnum = dr["cnum"].ToString();
                M_course.cplace = dr["cplace"].ToString();
                M_course.ctime = dr["ctime"].ToString();
                M_course.csemaster = Convert.ToInt32(dr["csemaster"]);
                //M_course.cmajor = dr["cmajor"].ToString();
                //M_course.cvalue = Convert.ToInt32(dr["cvalue"]);
                M_m.mname = dr["mname"].ToString();
                M_course.cmajor = M_m;
                M_course.cai = dr["cai"].ToString();
                M_course.ccredit = Convert.ToSingle(dr["ccredit"]);
                M_course.ctnum = dr["ctnum"].ToString();
                string teacher1 = dr["cteacher"].ToString();
                string teacher2 = dr["cteacher2"].ToString();
                string teacher3 = dr["cteacher3"].ToString();
                string teachername = "";
                if (teacher1 != "")
                {
                    teachername = teachername + searchteachername(teacher1);
                }
                if (teacher2 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher2);
                }
                if (teacher3 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher3);
                }
                M_course.cteacher = teachername;
                M_course.cname = dr["cname"].ToString();
                M_course.cintroduction = dr["cintroduction"].ToString();
                M_course.cyear = dr["cyear"].ToString();
                list.Add(M_course);
            }
            return list;
        }

        public List<M_CourseDetail> GetAllCourseTeacher(string year,string term, string value, string cnum,string tnum)
        {
            string sql = "select * from course left join majormessage on course.cmajor=majormessage.id inner join coursevalue on coursevalue.id=course.cvalue where (cteacher='" + tnum + "'or cteacher2='" + tnum + "'or cteacher3='" + tnum + "')";
            if (value != "" && value != null)
                sql = sql + " and coursevalue.value='" + value + "' ";
            if (term != "" && term != null)
                sql = sql + " and course.csemaster='" + term + "' ";
            if (cnum != "" && cnum != null)
                sql = sql + " and course.cnum='" + cnum + "'";
            SqlDataReader dr = db.GetRead(sql, null);
            List<M_CourseDetail> list = new List<M_CourseDetail>();
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_major M_m = new M_major();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.cnum = dr["cnum"].ToString();
                M_course.cplace = dr["cplace"].ToString();
                M_course.ctime = dr["ctime"].ToString();
                M_course.csemaster = Convert.ToInt32(dr["csemaster"]);
                //M_course.cmajor = dr["cmajor"].ToString();
                //M_course.cvalue = Convert.ToInt32(dr["cvalue"]);
                M_m.mname = dr["mname"].ToString();
                M_course.cmajor = M_m;
                M_course.cai = dr["cai"].ToString();
                M_course.ccredit = Convert.ToSingle(dr["ccredit"]);
                M_course.ctnum = dr["ctnum"].ToString();
                string teacher1 = dr["cteacher"].ToString();
                string teacher2 = dr["cteacher2"].ToString();
                string teacher3 = dr["cteacher3"].ToString();
                string teachername = "";
                if (teacher1 != "")
                {
                    teachername = teachername + searchteachername(teacher1);
                }
                if (teacher2 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher2);
                }
                if (teacher3 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher3);
                }
                M_course.cteacher = teachername;
                M_course.cname = dr["cname"].ToString();
                M_course.cintroduction = dr["cintroduction"].ToString();
                M_course.cyear = dr["cyear"].ToString();
                list.Add(M_course);
            }
            return list;
        }

        public List<M_CourseDetail> GetAllCourseStudent(string cvalue, string status, string cnum, string year, string term, string snum)
        {
            List<M_CourseDetail> l = new List<M_CourseDetail>();
            int nextyear=Convert.ToInt32(year)+1;
            string sql = "select * from [course] inner join [coursevalue]on coursevalue.id=course.cvalue inner join [teacher] on course.cteacher=teacher.tnum inner join [stu] on [stu].smajornum=[course].cmajor where stu.snum='"+snum+"' and course.csemaster='"+term+"' and course.cyear='"+year+"-"+nextyear+"' ";
            
            if (cvalue != null && cvalue != "")
            {
                sql = sql + "and coursevalue.value='" + cvalue + "'";
            }
            if (status != "" && status != null)
            {
                if (status == "已选")
                {
                    sql = sql + " and [course].id in(select course.id from dbo.[course] inner join dbo.["+year+"-"+term+"] on [" + year + "-" + term + "].cid=course.id where [" + year + "-" + term + "].snum='" + snum + "' )";
                }
                if (status == "未选")
                {
                    sql = sql + " and course.id not in (select  course.id from dbo.course inner join dbo.[" + year + "-" + term + "] on [" + year + "-" + term + "].cid=course.id where [" + year + "-" + term + "].snum='" + snum + "' ) ";
                }
            }
            if (cnum != "" && cnum != null)
            {
                sql = sql + "and course.cnum='" + cnum + "'";
            }
            SqlDataReader dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_major M_m = new M_major();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.cnum = dr["cnum"].ToString();
                M_course.ctime = dr["ctime"].ToString();
                M_course.cai = dr["cai"].ToString();
                M_course.ccredit = Convert.ToSingle(dr["ccredit"]);
                string teacher1 = dr["cteacher"].ToString();
                string teacher2 = dr["cteacher2"].ToString();
                string teacher3 = dr["cteacher3"].ToString();
                string teachername = "";
                if (teacher1 != "")
                {
                    teachername = teachername + searchteachername(teacher1);
                }
                if (teacher2 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher2);
                }
                if (teacher3 != "")
                {
                    teachername = teachername + " " + searchteachername(teacher3);
                }
                M_course.cteacher = teachername;
                M_course.cname = dr["cname"].ToString();
                l.Add(M_course);
            }
            dr.Close();
            return l;

        }
       
        public string Timechuli(string t)
        {
            int n = t.Length / 5;
            string time = "";
            for (int i = 0; i < n; i++)
            {
                int[] tmp = new int[5];
                int ii = 0;
                for (int j = i * 5; j < (i + 1) * 5; j++)
                {
                    tmp[ii] = t[j] - 'a' + 1;
                    ii++;
                }
                time = time + "" + tmp[0] + "~" + tmp[1] + "周  " + "周" + tmp[2] + "  " + tmp[3] + "~" + tmp[4] + "节 ";
            }
            return time;
        }

        public bool TimeSame(string t1,string t2)   //t2是待加入课程，t1是被比较课程
        {
            int n1 = t1.Length / 5;
            int n2 = t2.Length / 5;
            List<string> tt1=new List<string>();
            List<string> tt2=new List<string>();
            for (int i = 0; i < n1; i++)
            {
                string t = "";
                t = t1.Substring(i * 5, 5);
                tt1.Add(t);
            }
            for (int i = 0; i < n2;i++ )
            {
                string m = "";
                m = t2.Substring(i * 5, 5);
                tt2.Add(m);
            }
            int weekstart1,weekstart2;
            int weekend1,weekend2;
            int day1,day2;
            int classstart1,classstart2;
            int classend1,classend2;
            for (int i = 0; i < tt1.Count;i++ )   //将所有课程时间一一比较
            {
                for(int j=0;j<tt2.Count;j++)
                {
                    weekstart1 = tt1[i].ToString().ElementAt(0)-'a';
                    weekstart2 = tt2[j].ToString().ElementAt(0) - 'a';
                    weekend1 = tt1[j].ToString().ElementAt(1) - 'a';
                    weekend2 = tt2[j].ToString().ElementAt(1) - 'a';
                    day1 = tt1[i].ToString().ElementAt(2) - 'a';
                    day2 = tt2[j].ToString().ElementAt(2) - 'a';
                    classstart1 = tt1[i].ToString().ElementAt(3) - 'a';
                    classstart2 = tt2[j].ToString().ElementAt(3) - 'a';
                    classend1 = tt1[i].ToString().ElementAt(4) - 'a';
                    classend2 = tt2[j].ToString().ElementAt(4) - 'a';
                   // tt1[i].ToString()
                    if ((weekstart2 + (weekend2 - weekstart2) < weekstart1) || (weekstart2 > weekend1))
                        continue;
                    if (day1 != day2)
                        continue;
                    if ((classstart2 + (classend2 - classstart2) < classstart1) || (classstart2 > classend1))
                        continue;
                    return false;
                }
            }
            return true;
        }

        

        public string DeleteTheClass(string cid, string year, string term, string snum)
        {
            string sql = "select * from dbo.course inner join dbo.[" + year + "-" + term + "] on  dbo.[" + year + "-" + term + "].cid=[course].id where snum='" + snum + "' and cid='" + cid + "'";
            SqlDataReader dr = db.GetRead(sql, null);
            int num=0;
            int value = 0;
            while(dr.Read())
            {
                if (dr["cnum"] != null)
                    num++;
                value = Convert.ToInt32(dr["cvalue"]);
            }
            dr.Close();
            if (num == 0 || num > 1)
                return "课程信息有误，无法退选，请联系管理员";
            if (value == 1)
                return "该课程是必修课程，无法退选";      //如果是必修课程则不能退选
            sql = "delete dbo.[" + year + "-" + term + "] where snum='" + snum + "' and cid='" + cid + "'";
            if (db.ExeCommand(sql, null) == false)
                return "课程退选失败，系统错误";
            else
                return "课程成功退选";
        }

        public string InsertTheClass(string cid, string year, string term, string snum)
        {
            //查询是否有选课记录
            string sql = "select * from dbo.course inner join dbo.[" + year + "-" + term + "] on  dbo.[" + year + "-" + term + "].cid=[course].id where snum='" + snum + "' and cid='"+cid+"'";
            SqlDataReader dr = db.GetRead(sql, null);
            List<M_CourseDetail> list = new List<M_CourseDetail>();
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.ctime = dr["ctime"].ToString();
                list.Add(M_course);
            }
            dr.Close();

            //查询课程信息
            M_CourseDetail c = new M_CourseDetail();
            sql = "select * from dbo.course where id='" + cid + "'";
            dr = db.GetRead(sql, null);
            while(dr.Read())
            {
                c.id = Convert.ToInt32(dr["id"]);
                c.ctime = dr["ctime"].ToString();
            }
            dr.Close();

            //查询其它课程制成列表与待加课程进行对比
            sql = "select * from dbo.course inner join dbo.[" + year + "-" + term + "] on  dbo.[" + year + "-" + term + "].cid=[course].id where snum='" + snum + "'";
            List<M_CourseDetail> listchoosed = new List<M_CourseDetail>();  //已选的所有课程
            dr = db.GetRead(sql, null);
            while (dr.Read())
            {
                M_CourseDetail M_course = new M_CourseDetail();
                M_course.id = Convert.ToInt32(dr["id"]);
                M_course.ctime = dr["ctime"].ToString();
                listchoosed.Add(M_course);
            }
            dr.Close();
            if (list.Count >= 1)
                return "课程已选,若有问题请联系管理员";
            for (int i = 0; i < listchoosed.Count;i++ )
            {
                bool sss=TimeSame( listchoosed[i].ctime.ToString(),c.ctime.ToString());
                if (sss == false)
                    return "课程时间有冲突，不能选择";
            }

            sql = "insert into dbo.["+year+"-"+term+"] values ("+cid+","+snum+",null)";
            if (db.ExeCommand(sql, null) == false)
                return "课程选择失败，系统错误";
            else
                return "课程成功选择";
        }
    }
}