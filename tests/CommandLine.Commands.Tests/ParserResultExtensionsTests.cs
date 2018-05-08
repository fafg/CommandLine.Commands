using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine.Verbs;
using Moq;
using Xunit;

namespace CommandLine.Commands.Tests
{
    public class ParserResultExtensionsTests
    {
        [Fact]
        public void ParseArguments_WhenCalledWithNoVerbs_ThrowsArgumentException()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Parser.Default.ParseArguments(new List<string>(), new ICommand[0]));
        }

        [Fact]
        public void ParseArguments_WhenCalledWithNullVerbs_ThrowsArgumentNullException()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => Parser.Default.ParseArguments(new List<string>(), null));
        }

        [Fact]
        public async Task WithParsedAsync_WhenCalled_CallsActionWithReturnedValue()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(m => m.CanHandle(It.IsAny<object>())).Returns(true);
            commandMock.Setup(m => m.ExecuteAsync(It.IsAny<object>())).Returns(Task.FromResult<object>(433));

            var commands = new[] { commandMock.Object };

            // Act
            await Parser.Default.ParseArguments(new List<string>(), commands)
                .WithNotParsed(parsed => { })
                .WithParsedAsync(commands, result => {
                    // Assert
                    Assert.Equal(433, result);
                })
                ;
        }
    }
}
