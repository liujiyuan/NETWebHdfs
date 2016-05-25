using System;
using System.Reflection;
using DevZa.Logger;

namespace DevZa.Utilities
{
    public class ReflectionHelper
    {
        private static IZaLogger _log = LoggerFactory.GetLogger<ReflectionHelper>();

        public  T ObjectDeepCopy<T>(T source) where T:class
        {
            try
            {             
                Type type = source.GetType();
                Object target = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
                foreach (var item in type.GetProperties())
                {

                    object value1 = type.GetProperty(item.Name).GetValue(source, null);
                    target.GetType().GetProperty(item.Name).SetValue(target, value1, null);
                }
                return (T)target;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error happen when Deep Copy object, error {0}", ex);
                throw new Exception("Reflection Deept Copy Object Error",ex);
            }

        }


        public  void CopyEntityDataFromInterface<T>(object tar, object dest)
        {
            if (tar == null) return;
            Type type = typeof(T);
            foreach (var item in type.GetProperties())
            {
                type.GetProperty(item.Name).SetValue(dest, type.GetProperty(item.Name).GetValue(tar, null), null);
            }

            foreach (var face in type.GetInterfaces())
            {
                //Type fac = face.GetType();
                foreach (var pro in face.GetProperties())
                {
                    face.GetProperty(pro.Name).SetValue(dest, face.GetProperty(pro.Name).GetValue(tar, null), null);
                }
            }
        }

        public  T CopyValueObject<T>(object source) where T : class
        {

            try
            {
                Type type = source.GetType();
                Object target = typeof(T).InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
                foreach (var item in type.GetProperties())
                {
                    type.GetProperty(item.Name).SetValue(target, type.GetProperty(item.Name).GetValue(source, null), null);
                }
                return (T)target;
            }
            catch (Exception ex)
            {
                _log.ErrorParm("Copy Value Object Error",ex,source);   
                throw new Exception("Copy Value Object Fail",ex);
            }
        }


        public  void CopyValueObjectDataFromTo(object tar, object dest)
        {
            if (tar == null) return;
            Type type =tar.GetType();
            foreach (var item in type.GetProperties())
            {
                type.GetProperty(item.Name).SetValue(dest, type.GetProperty(item.Name).GetValue(tar, null), null);
            }            
        }

    }
}
