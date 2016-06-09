using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.MODEL;

namespace 教务选课系统.MODEL
{
    public class M_CourseDetail
    {
        public int id { get; set; }
        public string cnum { get; set; }
        public string cplace { get; set; }
        public string ctime { get; set; }
        public int csemaster { get; set; }
        public M_major cmajor { get; set; }
        public M_value cvalue { get; set; }
        public string cai { get; set; }
        public float ccredit { get; set; }
        public string ctnum { get; set; }
        public string cteacher { get; set; }
        public string cteacher2 { get; set; }
        public string cteacher3 { get; set; }
        public string cname { get; set; }
        public string cintroduction { get; set; }
        public string cyear { get; set; }

    }
}