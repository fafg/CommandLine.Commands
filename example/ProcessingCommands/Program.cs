using CommandLine;
using System;
using System.Threading.Tasks;
using CommandLine.Commands;
using ProcessingCommands.Commands.Add;

namespace ProcessingCommands
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var commands = new ICommand[]
            {
                // add your verbserbs here
                new AddCommand()
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
