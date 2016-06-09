using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 教务选课系统.DAL;

namespace 教务选课系统.WEB.Administrators
{
    public partial class Setting : System.Web.UI.Page
    {
        D_Course D_C = new D_Course();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCourse.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string year=TextBox1.Text;
            string term=DropDownList1.Text;
            if(year==""||year==null||term==""||term==null)
                Response.Write("<script>alert('信息填写不完整，无法创建！')</script>");
            int result = D_C.SetTerm(year, term);
            if (result == 0)
                Response.Write("<script>alert('学期已有，无法重建！')</script>");
            else if (result == 2)
                Response.Write("<script>alert('创建成功！')</script>");
            else
                Response.Write("<script>alert('创建表格时出现问题，请稍后再试')</script>");
                
        }
    }
}