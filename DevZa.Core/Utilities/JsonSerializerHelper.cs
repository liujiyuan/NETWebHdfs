using System;
using System.Text;
using Newtonsoft.Json;

namespace DevZa.Utilities
{
    public class JsonSerializerHelper
    {
        public static string SerializeObjectToString(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return $"{obj} (Object Type Can't be JSON Serialize)";
            }
        }

        public static string GetParamterString(object[] parameter)
        {
            if (parameter == null) return "null";

            var sb = new StringBuilder();
            var i = 1;
            foreach (var item in parameter)
            {
                sb.Append($"Parm: {i}, Type: <{item.GetType()}>, ");
                sb.Append($"Value: {SerializeObjectToString(item)}; ");
                sb.Append(Environment.NewLine);
                i++;
            }
            return sb.ToString();
        }
    }
}