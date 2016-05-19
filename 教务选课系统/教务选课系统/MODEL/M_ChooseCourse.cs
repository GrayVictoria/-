using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 教务选课系统.MODEL
{
    public class M_ChooseCourse
    {
        public int cid { get; set; }  //课程编号
        public int year { get; set; }  //学年信息
        public int term { get; set; }  //学期信息
        public M_Student M_Smessage { get; set; }//学生信息
    }
}