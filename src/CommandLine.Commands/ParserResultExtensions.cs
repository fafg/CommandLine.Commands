using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Verbs
{
    public static class ParserResultExtensions
    {
        public static ParserResult<object> WithParsed(this ParserResult<object> result, ICommand[] commands, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var verb = commands.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (verb != null)
                {
                    action(verb.Execute(succesfullyParsed.Value));
                }
                else
                {
                    throw new NoMatchingVerbException();
                }
            }
            return result;
        }

        public static async Task<ParserResult<object>> WithParsedAsync(this ParserResult<object> result, ICommand[] commands, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var verb = commands.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (verb != null)
                {
                    action(await verb.ExecuteAsync(succesfullyParsed.Value));
                }
                else
                {
                    throw new NoMatchingVerbException();
                }
            }
            return result;
        }
    }
}
