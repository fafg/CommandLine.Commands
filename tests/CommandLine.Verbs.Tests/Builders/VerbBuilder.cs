using System;
using System.Threading.Tasks;

namespace CommandLine.Verbs.Tests.Builders
{
    internal class VerbBuilder<T> where T : class
    {
        internal class TestVerb<T> : Verb<T> where T : class
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

        private readonly TestVerb<T> _builded = new TestVerb<T>();

        public VerbBuilder<T> WithExecuteAsyncFunc(Func<T, Task<object>> func)
        {
            _builded.ExecuteAsyncFunc = func;
            return this;
        }

        public VerbBuilder<T> WithExecuteFunc(Func<T, object> func)
        {
            _builded.ExecuteFunc = func;
            return this;
        }

        internal Verb<T> Build()
        {
            return _builded;
        }
    }
}