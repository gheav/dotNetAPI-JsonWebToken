using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace JsonWebToken_API.Utils
{
    public class Converter<T>
    {
        public IEnumerable<T> ToList(SqlDataReader dr)
        {
            List<T> list = new List<T>();
            int i = 0;

            while (dr.Read())
            {
                list.Add((T)dr.GetValue(i));
                i++;
            }

            return list;
        }

        public IEnumerable<T> ToList(SqlDataReader dr, string type)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
