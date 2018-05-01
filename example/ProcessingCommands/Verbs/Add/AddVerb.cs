using System.Threading.Tasks;
using CommandLine.Verbs;

namespace ProcessingCommands.Verbs.Add
{
    class AddVerb : Verb<AddOptions>
    {
        public override async Task<object> ExecuteAsync(AddOptions options)
        {
            return 33;
        }
    }
}