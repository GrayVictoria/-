using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.MODEL;
using 教务选课系统.DAL;


namespace 教务选课系统.BLL
{
    public class B_Student
    {
        D_Course D_C = new D_Course();
        public List<M_Course> GetCourse()
        {
            return D_C.GetCourse();

        }
        public List<M_Course> SearchCourse(string cvalue, string status, string cnum)
        {
            return D_C.SearchCourse(cvalue, status, cnum);

        }
        public List<M_Course> SearchAdCourse(string term, string major, string cnum)
        {
            return D_C.SearchAdCourse(term, major, cnum);

        }
        //public bool InsertCourse(M_ChooseCourse M_C)
        //{
        //    return D_C.InsertCourse(M_C.snum);
        //}
    }
}