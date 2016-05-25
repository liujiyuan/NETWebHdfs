namespace DevZa.Logger
{
    

    public class LoggerFactory
    {
        private static ILoggerProvider _loggerProvider = new DefaultLoggerProvider();

        public LoggerFactory()
        {
              
        }

        public static IZaLogger GetLogger<T>()
        {
            return _loggerProvider.GetLogger<T>();
        }

        public static IZaLogger GetLogger(object target)
        {
            return _loggerProvider.GetLogger(target);
        }

        public static void SetLoggerProvider(ILoggerProvider loggerProvider)
        {
            _loggerProvider = loggerProvider;
        }

    }
}
