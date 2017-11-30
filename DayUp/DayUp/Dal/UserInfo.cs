using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayUp.Dal
{
    public class UserInfo
    {
        Models.DayUpEntities1 db = new Models.DayUpEntities1();
        public static dynamic MatchUser(string username,string userpassword)
        {
            UserInfo ui = new UserInfo();
            var data = (from infomation in ui.db.UserInfo
                        where infomation.username == username && infomation.userpassword == userpassword
                        select infomation).FirstOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}