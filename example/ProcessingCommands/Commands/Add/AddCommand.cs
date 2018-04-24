using CommandLineParser.Commands;
using System.Threading.Tasks;

namespace ProcessingCommands.Commands.Add
{
    class AddCommand : Command<AddOptions>
    {
        public override async Task<object> ExecuteAsync(AddOptions options)
        {
            return 33;
        }
    }
}