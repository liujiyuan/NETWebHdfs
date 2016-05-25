using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DevZa.Utilities
{
    public class XmlSerializeHelper
    {
        public static string GetXMLSerializationString<T>(Object obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            StringWriter str = new StringWriter();
            ser.Serialize(str, obj);
            string output = ReplaceLowOrderASCIICharacters(str.ToString());
            return output;
        }

        public static object XMLDeserializationFromString<T>(string instr)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            //string fix = Regex.Replace(instr, @"[\u0000-\u001F]", string.Empty);
            //string fix = ReplaceLowOrderASCIICharacters(instr);
            StringReader str = new StringReader(instr);
            return ser.Deserialize(str);
        }

        public static string ReplaceLowOrderASCIICharacters(string tmp)
        {
            StringBuilder info = new StringBuilder();
            foreach (char cc in tmp)
            {
                int ss = (int)cc;
                if (((ss >= 0) && (ss <= 8)) || ((ss >= 11) && (ss <= 12)) || ((ss >= 14) && (ss <= 32)))
                    info.AppendFormat(" ", ss);//&#x{0:X};
                else info.Append(cc);
            }
            return info.ToString();
        }

        public static string RemoveControlCharacters(string inString)
        {
            if (inString == null) return null;
            StringBuilder newString = new StringBuilder();
            char ch;
            for (int i = 0; i < inString.Length; i++)
            {
                ch = inString[i];
                if (!char.IsControl(ch))
                {
                    newString.Append(ch);
                }
            }
            return newString.ToString();
        }

        public static string SerializeObjectToString(object obj)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(obj.GetType());
                StringWriter wr = new StringWriter();
                ser.Serialize(wr, obj);
                string output = ReplaceLowOrderASCIICharacters(wr.ToString());
                return output;
            }
            catch (Exception)
            {
                return $"{obj} (Object Type Can't be XML Serialize)";
            }
        }

        public static string GetParamterString(object[] parameter)
        {
            if (parameter == null) return "null";

            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var item in parameter)
            {
                sb.Append($"Parameter {i}, type:{item.GetType()}");
                sb.Append($", Value {SerializeObjectToString(item)}");
                sb.Append(Environment.NewLine);
                i++;
            }
            return sb.ToString();
        }
    }
}
