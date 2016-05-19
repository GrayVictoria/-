using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 教务选课系统.MODEL;
using 教务选课系统.DAL;
using 教务选课系统.BLL;

namespace 教务选课系统.WEB.Student
{
    public partial class AllCourse : System.Web.UI.Page
    {
        B_Student B_S = new B_Student();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string cvalue = DropDownList1.Text;
            string status = DropDownList2.Text;
            string cnum = TextBox1.Text;
            //List<M_Course> l = new List<M_Course>();
            //l = B_S.SearchCourse(cvalue, status, cnum);
            课程表.DataSource = B_S.SearchCourse(cvalue, status, cnum);
            课程表.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}