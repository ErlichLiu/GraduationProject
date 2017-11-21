using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class ContentSearch
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static  IQueryable<dynamic> GetBannerData()
        {
            ContentSearch cs = new ContentSearch();
            var data = from banner in cs.db.ContentInfo
                       orderby banner.hot descending
                       select banner;
            return data;
         
        }
        public static IQueryable<dynamic> GetRankingData()
        {
            ContentSearch cs = new ContentSearch();
            var data = from ranking in cs.db.ContentInfo
                       orderby ranking.hot descending
                       select ranking;
            return data;
        }
        public static IQueryable<dynamic> GetSubContent()
        {
            ContentSearch cs = new ContentSearch();
            var data = from subcontent in cs.db.ContentInfo
                       orderby subcontent.time descending
                       select subcontent;
            return data;
        }
    }
}