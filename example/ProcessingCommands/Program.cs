using CommandLine;
using System;
using System.Threading.Tasks;
using CommandLine.Verbs;
using ProcessingCommands.Verbs.Add;

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

            await Parser.Default.ParseArguments(args, commands)
                .WithNotParsed(result =>
                {
                    // handle error
                })
                .WithParsedAsync(commands, returnValue =>
                {
                    // consume returned value
                });

            return 0;
        }
    }
}
