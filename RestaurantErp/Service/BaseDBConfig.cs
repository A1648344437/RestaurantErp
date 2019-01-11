using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Service
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public class BaseDBConfig
    {
        //public static string ConnectionString = "server=.;uid=sa;pwd=123456;database=WMBlogDB";

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }
    }
}
