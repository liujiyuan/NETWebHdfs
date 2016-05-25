namespace DevZa.Logger
{
    public interface ILoggerProvider
    {
        IZaLogger GetLogger<T>();

        IZaLogger GetLogger(object target);
    }
}