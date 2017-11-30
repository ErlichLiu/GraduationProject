using DayUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class Testin
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static List<CommenInfo> MatchYourComment(int id)
        {
            Testin mc = new Testin();
            var data = (from l in mc.db.CommenInfo
                       where l.userid == id
                       select l).ToList();
            return data;
        }
    }
}