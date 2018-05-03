using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CommandLine.Verbs.Tests
{
    public class ParserResultExtensionsTests
    {
        [Fact]
        public async Task WithParsedAsync_WhenCalled_CallsActionWithReturnedValue()
        {
            // Arrange

            // Act
            (await Parser.Default.ParseArguments(new List<string>(), new IVerb[0])
                .WithParsedAsync(new IVerb[0], result => {
                    // Assert
                    Assert.Equal(433, result);
                }))
                .WithNotParsed(parsed => { })
                ;
        }
    }
}
