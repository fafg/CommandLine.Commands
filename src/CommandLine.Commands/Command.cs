using System;
using System.Threading.Tasks;

namespace CommandLine.Commands
{
    public abstract class Command<T> : ICommand<T> where T : class
    {
        public Type OptionsType => typeof(T);

        public virtual bool CanHandle(object options)
        {
            return options is T;
        }

        public virtual int Execute(T options)
        {
            return ExecuteAsync(options).Result;
        }

        public int Execute(object options)
        {
            return Execute(options as T);
        }

        public abstract Task<int> ExecuteAsync(T options);

        public async Task<int> ExecuteAsync(object options)
        {
            return await ExecuteAsync(options as T);
        }
    }
}
