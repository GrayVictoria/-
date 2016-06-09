using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 教务选课系统.MODEL
{
    public class M_Login
    {
        public string username { get; set; }
        public string userpwd { get; set; }
        public int state { get; set; }
        public int year { get; set; }

        public int term { get; set; }
    }
}