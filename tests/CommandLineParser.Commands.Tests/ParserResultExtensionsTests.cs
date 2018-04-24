using CommandLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandLineParser.Commands.Tests
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
            (await Parser.Default.ParseArguments(new List<string>(), new ICommand[0])
                .WithParsedAsync(new ICommand[0], result => {
                    // Assert
                    Assert.AreEqual(result, 433);
                }))
                .WithNotParsed(parsed => { })
                ;
        }
    }
}
