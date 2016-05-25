using System;

namespace DevZa.Logger
{
    public class DefaultLoggerProvider:ILoggerProvider
    {
        public IZaLogger GetLogger<T>()
        {
            return new DefaultLogger<T>();
        }

        public IZaLogger GetLogger(object target)
        {
            var genericType = typeof(DefaultLogger<>);
            var specificType = genericType.MakeGenericType(target.GetType());
            return (IZaLogger)Activator.CreateInstance(specificType);
        }


    }
}