using System.Diagnostics;
using DevZa.Utilities;

namespace DevZa.Logger
{
    public class LoggerHelper
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<LoggerHelper>();
            
        private  static  enumLogTraceLevel _traceLevel = enumLogTraceLevel.LogInCurrentMethod;

        private static StackFrame sf
        {
            get
            {
                return (new StackTrace()).GetFrame((int)_traceLevel);
            }
        }

        public static void Error(string message, params object[] args)
        {
            _log.ErrorFormat("Source: {0}, Method: {1}, Params: {2}",sf.GetMethod().ReflectedType.FullName,sf.GetMethod().Name,JsonSerializerHelper.GetParamterString(args));
        }

        public static void Warn(string message, params object[] args)
        {
            _log.WarnFormat("Source: {0}, Method: {1}, Params: {2}", sf.GetMethod().ReflectedType.FullName, sf.GetMethod().Name, JsonSerializerHelper.GetParamterString(args));
        }

        public static void Fatal(string message, params object[] args)
        {
            _log.FatalFormat("Source: {0}, Method: {1}, Params: {2}", sf.GetMethod().ReflectedType.FullName, sf.GetMethod().Name, JsonSerializerHelper.GetParamterString(args));
        }

        public static void Debug(string message, params object[] args)
        {
            _log.DebugFormat("Source: {0}, Method: {1}, Params: {2}", sf.GetMethod().ReflectedType.FullName, sf.GetMethod().Name, JsonSerializerHelper.GetParamterString(args));
        }

        public static void Info(string message, params object[] args)
        {
            _log.InfoFormat("Source: {0}, Method: {1}, Params: {2}", sf.GetMethod().ReflectedType.FullName, sf.GetMethod().Name, JsonSerializerHelper.GetParamterString(args));
        }
    }
}
