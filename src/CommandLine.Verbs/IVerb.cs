using System;
using System.Threading.Tasks;

namespace CommandLine.Verbs
{
    public interface IVerb
    {
        Type OptionsType { get; }
        bool CanHandle(object options);
        object Execute(object options);
        Task<object> ExecuteAsync(object options);
    }

    public interface IVerb<in T> : IVerb where T : class
    {
        object Execute(T options);
        Task<object> ExecuteAsync(T options);
    }
}
