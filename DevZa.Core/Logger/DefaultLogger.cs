using System;
using DevZa.Utilities;
using log4net;

namespace DevZa.Logger
{
    public class DefaultLogger<T> : IZaLogger
    {
        private ILog _log = LogManager.GetLogger(typeof (T));

        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Error(object message, Exception ex)
        {
            _log.Error(message,ex);
        }

        public void ErrorParm(object message, params object[] args)
        {
            _log.ErrorFormat("{0}, {1}", message,JsonSerializerHelper.GetParamterString(args));
        }

        public void ErrorFormat(string formatter, params object[] args)
        {
            _log.ErrorFormat(formatter,args);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Info(object message, Exception ex)
        {
            _log.Info(message,ex);
        }

        public void InfoParm(object message, params object[] args)
        {
            _log.InfoFormat("{0}, {1}", message, JsonSerializerHelper.GetParamterString(args));
        }

        public void InfoFormat(string formatter, params object[] args)
        {
            _log.InfoFormat(formatter,args);
        }

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        public void Debug(object message, Exception ex)
        {
            _log.Debug(message,ex);
        }

        public void DebugParm(object message, params object[] args)
        {
            _log.DebugFormat("{0}, {1}", message, JsonSerializerHelper.GetParamterString(args));
        }

        public void DebugFormat(string formatter, params object[] args)
        {
            _log.DebugFormat(formatter,args);
        }

        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        public void Fatal(object message, Exception ex)
        {
            _log.Fatal(message,ex);
        }

        public void FatalParm(object message, params object[] args)
        {
            _log.DebugFormat("{0}, {1}", message, JsonSerializerHelper.GetParamterString(args));
        }

        public void FatalFormat(string formatter, params object[] args)
        {
            _log.FatalFormat(formatter,args);
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        public void Warn(object message, Exception ex)
        {
            _log.Warn(message,ex);
        }

        public void WarnParm(object message, params object[] args)
        {
            _log.WarnFormat("{0}, {1}", message, JsonSerializerHelper.GetParamterString(args));
        }

        public void WarnFormat(string formatter, params object[] args)
        {
            _log.WarnFormat(formatter,args);
        }
    }
}