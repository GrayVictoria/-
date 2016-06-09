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
        B_CourseDetail B_C = new B_CourseDetail();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            string cvalue = DropDownList1.Text;
            string status = "已选";
            string cnum = TextBox1.Text;
            课程表.DataSource = B_S.SearchCourse(cvalue, status, cnum);
            课程表.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            课程表.DataBind();
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            DropDownList1.Items.Insert(0, new ListItem("", ""));
        }

       

        protected void Button5_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CurriculumSchedule.aspx");
        }

        protected void DropDownList2_DataBound(object sender, EventArgs e)
        {
            
            DropDownList2.Items.Insert(0, new ListItem("", ""));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cid = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string s;
            s=B_C.DeleteTheClass(cid, Session["Year"].ToString(), Session["Term"].ToString(), Session["Username"].ToString());
            Response.Write("<script>alert('"+s+"')</script>");
            GridView1.DataBind();
            课程表.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void 课程表_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cid = 课程表.Rows[e.RowIndex].Cells[0].Text;
            string s;
            s = B_C.InsertTheClass(cid, Session["Year"].ToString(), Session["Term"].ToString(), Session["Username"].ToString());
            Response.Write("<script>alert('" + s + "')</script>");
            GridView1.DataBind();
            课程表.DataBind();
        }
    }
}