using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Verbs
{
    public static class ParserResultExtensions
    {
        public static ParserResult<object> WithParsed(this ParserResult<object> result, IVerb[] verbs, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var verb = verbs.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (verb != null)
                {
                    action(verb.Execute(succesfullyParsed.Value));
                }
                else
                {
                    //TODO: throw exception NoMatch
                }
            }
            return result;
        }

        public static async Task<ParserResult<object>> WithParsedAsync(this ParserResult<object> result, IVerb[] verbs, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var verb = verbs.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (verb != null)
                {
                    action(await verb.ExecuteAsync(succesfullyParsed.Value));
                }
                else
                {
                    //TODO: throw exception NoMatch
                }
            }
            return result;
        }
    }
}
