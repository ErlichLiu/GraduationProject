using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    /// <summary>
    /// 于内容搜索和展示有关的数据交互层
    /// </summary>
    public class ContentSearch
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();

        /// <summary>
        /// 返回 Banner 的数据
        /// </summary>
        /// <returns></returns>
        public static  IQueryable<dynamic> GetBannerData()
        {
            ContentSearch cs = new ContentSearch();
            var data = from banner in cs.db.ContentInfo
                       orderby banner.hot descending
                       select banner;
            return data;
         
        }

        /// <summary>
        /// 返回排名的数据
        /// </summary>
        /// <returns></returns>
        public static IQueryable<dynamic> GetRankingData()
        {
            ContentSearch cs = new ContentSearch();
            var data = from ranking in cs.db.ContentInfo
                       orderby ranking.hot descending
                       select ranking;
            return data;
        }

        /// <summary>
        /// 返回普通内容的数据
        /// </summary>
        /// <returns></returns>
        public static IQueryable<dynamic> GetSubContent()
        {
            ContentSearch cs = new ContentSearch();
            var data = from subcontent in cs.db.ContentInfo
                       //join j in cs.db.UserInfo on subcontent.id equals j.id  into c
                       //from u in c.DefaultIfEmpty()
                       orderby subcontent.time descending
                       select subcontent;
            return data;
        }

        /// <summary>
        /// 传入字符串类型的关键字，用来搜索跟标题，概述，网站，类型，时间相关的内容
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<dynamic> GoSearch(string keyword)
        {
            ContentSearch cs = new ContentSearch();
            var data = from searching in cs.db.ContentInfo
                       where (string.IsNullOrEmpty(keyword) || searching.title.Contains(keyword) || searching.summary.Contains(keyword) || searching.websitename.Contains(keyword) || searching.type.Contains(keyword) || searching.time.Contains(keyword))
                       select searching;
            return data;
        }
    }
}