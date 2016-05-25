using System;

namespace DevZa.Logger
{
    public interface IZaLogger
    {
        void Error(object message);

        void Error(object message, Exception ex);

        void ErrorParm(object message, params object[] args);

        void ErrorFormat(string formatter, params object[] args);

        void Info(object message);

        void Info(object message, Exception ex);

        void InfoParm(object message, params object[] args);

        void InfoFormat(string formatter, params object[] args);

        void Debug(object message);

        void Debug(object message, Exception ex);

        void DebugParm(object message, params object[] args);

        void DebugFormat(string formatter, params  object[] args);

        void Fatal(object message);

        void Fatal(object message, Exception ex);

        void FatalParm(object message, params object[] args);

        void FatalFormat(string formatter, params object[] args);

        void Warn(object message);

        void Warn(object message, Exception ex);

        void WarnParm(object message, params object[] args);

        void WarnFormat(string formatter, params object[] args);
    }
}