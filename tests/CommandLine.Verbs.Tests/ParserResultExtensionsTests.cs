using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandLine.Verbs.Tests
{
    [TestClass]
    public class ParserResultExtensionsTests
    {
        [TestMethod]
        [Ignore]
        public async Task WithParsedAsync_WhenCalled_CallsActionWithReturnedValue()
        {
            // Arrange

            // Act
            (await Parser.Default.ParseArguments(new List<string>(), new IVerb[0])
                .WithParsedAsync(new IVerb[0], result => {
                    // Assert
                    Assert.AreEqual(result, 433);
                }))
                .WithNotParsed(parsed => { })
                ;
        }
    }
}
