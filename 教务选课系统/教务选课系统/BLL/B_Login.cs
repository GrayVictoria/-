using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.DAL;
using 教务选课系统.MODEL;

namespace 教务选课系统.BLL
{
    public class B_Login
    {
        D_Login D_L = new D_Login();
        public M_Login Login(string username,string userpwd)
        {
            return D_L.Login(username, userpwd);
        }
    }
}