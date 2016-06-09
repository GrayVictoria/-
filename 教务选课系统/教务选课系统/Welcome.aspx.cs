using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 教务选课系统.BLL;
using 教务选课系统.MODEL;

namespace 教务选课系统
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string userpwd = TextBox2.Text;
            if (username == "" || username == null)
                Response.Write("<script>alert('信息未填写完整！')</script>");
            B_Login B_L = new B_Login();
            M_Login M_L=B_L.Login(username,userpwd);

            if (M_L!=null)
            {
                Session["UserName"] = M_L.username;
                Session["UserState"] = M_L.state;
                Session["Year"] = M_L.year;
                Session["Term"] = M_L.term;
                if(M_L.state==1)
                {
                    Response.Redirect("WEB/Student/AllCourse.aspx");
                }
                else if(M_L.state==2)
                {
                    Response.Redirect("WEB/Teacher/AllCourse.aspx");
                }
                else if(M_L.state==3)
                {
                    Response.Redirect("WEB/Administrators/AllCourse.aspx");
                }
                else
                {
                    Response.Write("<script>alert('登录身份有误')</script>");
                }

                //Response.Redirect("../Index.aspx");
                // Response.Write("<script>alert('登陆成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('登陆失败')</script>");
            }
        }
    }
}