using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 教务选课系统.MODEL
{
    public class M_Course
    {
        public int Coursenum { get; set; }
        public string Coursename { get; set; }
        public string Coursevalue { get; set; }
        public string Courseteacher { get; set; }
        public string Coursecredit { get; set; }
        public string status { get; set; }
        public string Coursecai { get; set; }
    }
}