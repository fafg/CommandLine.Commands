using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.Commands
{
    public static class ParserExtensions
    {
        public static ParserResult<object> ParseArguments(this Parser parser, IEnumerable<string> args, ICommand[] commands)
        {
            return parser.ParseArguments(args, commands.Select(command => command.OptionsType).ToArray());
        }
    }
}
