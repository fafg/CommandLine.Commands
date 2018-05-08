using CommandLine.Commands.Tests.Builders;
using Xunit;

namespace CommandLine.Commands.Tests
{
    public class CommandTests
    {
        class TestOptions
        {

        }

        [Fact]
        public void CanHandle_WhenPassingNullObjectOfProperType_ReturnsFalse()
        {
            // Arrange
            var verb = new CommandBuilder<TestOptions>()
                .Build();

            // Act
            var result = verb.CanHandle((TestOptions)null);

            // Assert
            Assert.False(result);
        }
    }
}
