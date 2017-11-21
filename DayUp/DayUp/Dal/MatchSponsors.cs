using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class MatchSponsors
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static IQueryable<dynamic> MatchSponsorsLogos()
        {
            MatchSponsors ms = new MatchSponsors();
            var data = from sponsor in ms.db.SponsorsInfo
                       select sponsor;
            return data;
        }
    }
}