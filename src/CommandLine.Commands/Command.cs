using System;
using System.Threading.Tasks;

namespace CommandLine.Verbs
{
    public abstract class Command<T> : ICommand<T> where T : class
    {
        public Type OptionsType => typeof(T);

        public virtual bool CanHandle(object options)
        {
            return options is T;
        }

        public virtual object Execute(T options)
        {
            return ExecuteAsync(options).Result;
        }

        public object Execute(object options)
        {
            return Execute(options as T);
        }

        public abstract Task<object> ExecuteAsync(T options);

        public async Task<object> ExecuteAsync(object options)
        {
            return await ExecuteAsync(options as T);
        }
    }
}
