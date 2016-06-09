using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 教务选课系统.BLL;

namespace 教务选课系统.WEB.Administrators
{
    public partial class AllCourse : System.Web.UI.Page
    {
        //B_Student B_S = new B_Student();
        B_CourseDetail B_C = new B_CourseDetail();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //string term = DropDownList1.Text;
            //string major = DropDownList2.Text;
            //string cnum = TextBox1.Text;
     
            课程表.DataBind();
        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            DropDownList2.Items.Insert(0,new ListItem("",""));
        }
    }
}