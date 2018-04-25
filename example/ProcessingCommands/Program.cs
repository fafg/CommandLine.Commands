using CommandLine;
using ProcessingCommands.Commands.Add;
using System;
using System.Threading.Tasks;
using CommandLine.Verbs;

namespace ProcessingCommands
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var commands = new IVerb[]
            {
                // add your verbserbs here
                new AddVerb()
            };

            var parsed = Parser.Default.ParseArguments(args, commands);
            await parsed.WithParsedAsync(commands, returnValue =>
            {
                // consume returned value
            });
            parsed.WithNotParsed(result =>
            {
                // handle error
            });

            return 0;
        }
    }
}
