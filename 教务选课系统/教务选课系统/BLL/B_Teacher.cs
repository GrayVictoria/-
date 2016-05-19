using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 教务选课系统.DAL;
using 教务选课系统.MODEL;

namespace 教务选课系统.BLL
{
    public class B_Teacher
    {
        D_Course D_C = new D_Course();
        public List<M_ChooseCourse> GetChooseMessage(int year, int term, int cid)
        {
            year = 2015;
            term = 1;
            cid = 1;
            return D_C.GetChooseMessage(year, term, cid);
        }
    }
}