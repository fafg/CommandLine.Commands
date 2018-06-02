using System.Threading.Tasks;
using CommandLine.Commands;

namespace ProcessingCommands.Commands.Add
{
    class AddCommand : Command<AddOptions>
    {
        public override async Task<int> ExecuteAsync(AddOptions options)
        {
            return await Task.FromResult(33);
        }
    }
}