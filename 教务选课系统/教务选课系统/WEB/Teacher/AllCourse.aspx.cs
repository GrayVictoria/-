using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 教务选课系统.WEB.Teacher
{
    public partial class AllCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            DropDownList2.Items.Insert(0, new ListItem("", ""));
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            课程表.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumSchedule.aspx");
        }
    }
}