using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLine.Commands
{
    public static class ParserResultExtensions
    {
        public static ParserResult<object> WithParsed(this ParserResult<object> result, ICommand[] commands, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var command = commands.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (command != null)
                {
                    action(command.Execute(succesfullyParsed.Value));
                }
                else
                {
                    throw new NoMatchingCommandException();
                }
            }
            return result;
        }

        public static async Task<ParserResult<object>> WithParsedAsync(this ParserResult<object> result, ICommand[] commands, Action<object> action)
        {
            if (result is Parsed<object> succesfullyParsed)
            {
                var command = commands.FirstOrDefault(c => c.CanHandle(succesfullyParsed.Value));
                if (command != null)
                {
                    action(await command.ExecuteAsync(succesfullyParsed.Value));
                }
                else
                {
                    throw new NoMatchingCommandException();
                }
            }
            return result;
        }
    }
}
