using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class MatchComment
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static dynamic MatchYourComment(int id)
        {
            MatchComment mc = new MatchComment();
            var data = from l in mc.db.CommenInfo
                       where l.userid == id
                       select l;
            return data;
        }
    }
}