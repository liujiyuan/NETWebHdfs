using System;

namespace DevZa.Extension
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>
        (
          Func<TDisposable> factory,
          Func<TDisposable, TResult> fn)
          where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return fn(disposable);
            }
        }

        public static void Using<TDisposable>(
            Func<TDisposable> factory,
            Action<TDisposable> action
            ) where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                action(disposable);
            }
        }
    }
}
