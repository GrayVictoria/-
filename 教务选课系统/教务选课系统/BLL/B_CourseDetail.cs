using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.DAL;
using 教务选课系统.MODEL;

namespace 教务选课系统.BLL
{
    public class B_CourseDetail
    {
        D_CourseDetail D_Coursee = new D_CourseDetail();
        public List<M_CourseDetail> search(string id)
        {
            return D_Coursee.search(id);
        }

        public List<M_value> searchvalue()
        {
           return D_Coursee.searchcoursevalue();
        }

        public List<M_major> searchmajor()
        {
            return D_Coursee.seachmajor();
        }

        //public List<M_CourseDetail> GetAllCourse()
        //{
        //    return D_Coursee.GetAllCource();
        //}

        

        public List<M_CourseDetail> GetAllCourseAdministrators(string term,string major,string cnum)
        {
            return D_Coursee.GetAllCourseAdministrators(term,major,cnum);
        }

        public List<M_CourseDetail> GetAllCourseTeacher(int year,string term,string value,string cnum,string tnum)
        {
            return D_Coursee.GetAllCourseTeacher(year.ToString(), term, value, cnum, tnum);
        }

        public List<M_CourseDetail> GetAllCourseStudent(string cvalue,string status,string cnum,int year,int term,string snum)
        {
            return D_Coursee.GetAllCourseStudent(cvalue, status, cnum, year.ToString(), term.ToString(), snum);
        }

        public string DeleteTheClass(string cid,string year,string term,string snum)
        {
            
            string s = D_Coursee.DeleteTheClass(cid, year, term, snum);
            return s;
        }

        public string InsertTheClass(string cid, string year, string term, string snum)
        {
            string s = D_Coursee.InsertTheClass(cid, year, term, snum);
            return s;
        }

        public void DoNothing(string id)
        {
            int i = 0;
        }
    }
}