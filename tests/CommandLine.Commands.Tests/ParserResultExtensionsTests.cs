using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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
            var commandMock = new Mock<ICommand>(MockBehavior.Strict);
            TypeDescriptor.AddAttributes(commandMock.Object, new VerbAttribute("abcd"));
            commandMock.Setup(m => m.CanHandle(It.IsAny<object>())).Returns(true);
            commandMock.Setup(m => m.ExecuteAsync(It.IsAny<object>())).Returns(Task.FromResult(433));
            commandMock.Setup(m => m.OptionsType).Returns(typeof(TestOptions));

            var commands = new[] { commandMock.Object };

            // Act
            await Parser.Default.ParseArguments(new string[] { "abcd" }, commands)
                .WithNotParsed(parsed => {
                    Assert.True(false);
                })
                .WithParsedAsync(commands, result => {
                    // Assert
                    Assert.Equal(433, result);
                })
                ;
        }

        [Verb("abcd")]
        class TestOptions
        {

        }
    }
}
