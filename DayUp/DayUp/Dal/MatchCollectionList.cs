using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class MatchCollectionList
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static dynamic MatchYourList(int id)
        {
            MatchCollectionList mc = new MatchCollectionList();
            var data = from l in mc.db.CollectionInfo
                       where l.user_id == id
                       select l;
            return data;
        }
    }
}