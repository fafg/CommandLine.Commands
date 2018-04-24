using System;
using System.Threading.Tasks;

namespace CommandLineParser.Commands
{
    public interface ICommand
    {
        Type OptionsType { get; }
        bool CanHandle(object options);
        object Execute(object options);
        Task<object> ExecuteAsync(object options);
    }

    public interface ICommand<T> : ICommand where T : class
    {
        object Execute(T options);
        Task<object> ExecuteAsync(T options);
    }
}
