using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace RealEstateAnalyzer.Shared
{
    public static class ExtensionMethods
    {
        public static int ToInt<T>(this T str)
        {
            try
            {
                if (String.IsNullOrEmpty(str.ToString()))
                {
                    return 0;
                }
                else
                {
                    bool isNumeric = int.TryParse(str.ToString(), out int n);
                    if (isNumeric)
                        return n;
                    else
                        return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal<T>(this T pParam)
        {
            try
            {
                if (pParam.ToString() == "")
                    return 0;
                else return Convert.ToDecimal(pParam);
            }
            catch
            {
                return 0;
            }
        }

        public static bool ToBoolean<T>(this T obj)
        {
            try
            {
                if (String.IsNullOrEmpty(obj.ToString()))
                    return false;
                else if (obj.ToString() == "1")
                    return true;
                else return Convert.ToBoolean(obj);
            }
            catch
            {
                return false;
            }
        }

        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                return default;
            }
        }


        public static DataSet ToExportDataSet<T>(this IList<T> list)
        {
            if (list == null) return null;

            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            var properties = typeof(T).GetProperties();
            foreach (var propInfo in properties)
            {
                var attribute = Attribute.GetCustomAttribute(propInfo, typeof(ExportColumnAttribute)) as ExportColumnAttribute;
                if (attribute != null)
                {
                    Type colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                    t.Columns.Add(attribute.Title, colType);
                } 
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in properties)
                {
                    var value = propInfo.GetValue(item, null);
                    row[propInfo.Name] = value ?? DBNull.Value;
                }
                t.Rows.Add(row);
            }
            return ds;
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            PropertyInfo[] properties = elementType.GetProperties();
            //add a column to table for each public property on T
            foreach (var propInfo in properties)
            {
                Type colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                t.Columns.Add(propInfo.Name, colType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in properties)
                {
                    var value = propInfo.GetValue(item, null);
                    row[propInfo.Name] = value ?? DBNull.Value;
                }
                t.Rows.Add(row);
            }
            return ds;
        }
    }   
}
