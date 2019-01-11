using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantErp.Common
{
    /// <summary>
    /// 序列化与序列化
    /// </summary>
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return jsonString;
            //return Encoding.UTF8.GetString(jsonString);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static TEntity Deserialize<TEntity>(string jsonString)
        {
            if (jsonString == null)
            {
                return default(TEntity);
            }
            //var jsonString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<TEntity>(jsonString);
        }
    }
}
