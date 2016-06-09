using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 教务选课系统.BLL;
using 教务选课系统.MODEL;

namespace 教务选课系统.WEB.Teacher
{
    public partial class CurriculumSchedule : System.Web.UI.Page
    {
        B_CourseDetail B_C = new B_CourseDetail();
        public int year = 2015;
        public int term = 1;
        public string tnum = "1853";

        public string Time(string t)
        {

            int n = t.Length / 5;
            string time = "";
            for(int i=0;i<n;i++)
            {
                int[] tmp=new int[5];
                for(int j=i*5;j<(i+1)*5;j++)
                {
                    tmp[i] = t[i] - 'a' + 1;
                }
                time = time + "第" + tmp[0] + "周-第" + tmp[1] + "周  " + "星期" + tmp[2] + "  第" + tmp[3] + "节-第" + tmp[4] + "节";
            }
            return time;
        }
    

        protected void Page_Load(object sender, EventArgs e)
        {
            List<M_CourseDetail> l = new List<M_CourseDetail>();
            //l = B_C.GetAllCourseStudent("", "", "", Convert.ToInt32(Se), term, snum);
            l = B_C.GetAllCourseTeacher(Convert.ToInt32(Session["Year"]),Session["Term"].ToString(), "", "", Session["UserName"].ToString());
            for(int i=0;i<l.Count;i++)
            {
                string time=l[i].ctime;
                int n = time.Length / 5;
                int week=0;
                int classbegin=0,classend=0;
                int weekbegin = 0,weekend = 0;
                for (int m = 0; m < n; m++)
                {
                    week = time[m * 5 + 2] - 'a' + 1;
                    classbegin = time[m * 5 + 3] - 'a' + 1;
                    classend = time[m * 5 + 4] - 'a' + 1;
                    weekbegin = time[m * 5] - 'a' + 1;
                    weekend = time[m * 5 + 1] - 'a' + 1;
                    for(int t=classbegin;t<=classend;t++)
                    {
                        Table1.Rows[t].Cells[week].Text = l[i].cname+"\n"+weekbegin+"~"+weekend+"周";
                    }
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCourse.aspx");
        }
    }
}