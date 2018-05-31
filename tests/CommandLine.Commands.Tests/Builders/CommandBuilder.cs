using System;
using System.Threading.Tasks;
using CommandLine.Verbs;

namespace CommandLine.Commands.Tests.Builders
{
    internal class CommandBuilder<T> where T : class
    {
        internal class TestCommand : Command<T>
        {
            public Func<T, Task<object>> ExecuteAsyncFunc { get; internal set; }
            public Func<T, object> ExecuteFunc { get; internal set; }

            public override async Task<object> ExecuteAsync(T options)
            {
                return await ExecuteAsyncFunc(options);
            }

            public override object Execute(T options)
            {
                if (ExecuteFunc == null)
                {
                    return base.Execute(options);
                }
                return ExecuteFunc(options);
            }
        }

        private readonly TestCommand _builded = new TestCommand();

        public CommandBuilder<T> WithExecuteAsyncFunc(Func<T, Task<object>> func)
        {
            _builded.ExecuteAsyncFunc = func;
            return this;
        }

        public CommandBuilder<T> WithExecuteFunc(Func<T, object> func)
        {
            _builded.ExecuteFunc = func;
            return this;
        }

        internal Command<T> Build()
        {
            return _builded;
        }
    }
}