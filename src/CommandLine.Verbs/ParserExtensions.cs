using System.Collections.Generic;
using System.Linq;

namespace CommandLine.Verbs
{
    public static class ParserExtensions
    {
        public static ParserResult<object> ParseArguments(this Parser parser, IEnumerable<string> args, IVerb[] verbs)
        {
            return parser.ParseArguments(args, verbs.Select(command => command.OptionsType).ToArray());
        }
    }
}
