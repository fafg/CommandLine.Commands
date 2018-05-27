using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandLine.Commands
{
    public static class ParserExtensions
    {
        public static ParserResult<object> ParseArguments(this Parser parser, IEnumerable<string> args, ICommand[] commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException(nameof(commands));
            }
            if (!commands.Any())
            {
                throw new ArgumentException("There should be at least one verb defined", nameof(commands));
            }
            return parser.ParseArguments(args, commands.Select(command => command.OptionsType).ToArray());
        }
    }
}
