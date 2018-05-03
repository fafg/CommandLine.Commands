using System;
using System.Threading.Tasks;

namespace CommandLine.Verbs
{
    /// <summary>
    /// Verb commands handler
    /// </summary>
    public interface IVerb
    {
        /// <summary>
        /// Returns type of options class
        /// </summary>
        Type OptionsType { get; }
        /// <summary>
        /// Checks if can handle options class type
        /// </summary>
        /// <param name="options"></param>
        /// <returns>True when verb handler can handle option class type</returns>
        bool CanHandle(object options);
        object Execute(object options);
        Task<object> ExecuteAsync(object options);
    }

    /// <summary>
    /// Generic verb commands handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVerb<in T> : IVerb where T : class
    {
        object Execute(T options);
        Task<object> ExecuteAsync(T options);
    }
}
