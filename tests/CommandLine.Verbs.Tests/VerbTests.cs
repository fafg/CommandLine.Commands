using CommandLine.Verbs.Tests.Builders;
using Xunit;

namespace CommandLine.Verbs.Tests
{
    public class VerbTests
    {
        class TestOptions
        {

        }

        [Fact]
        public void CanHandle_WhenPassingNullObjectOfProperType_ReturnsFalse()
        {
            // Arrange
            var verb = new VerbBuilder<TestOptions>()
                .Build();

            // Act
            var result = verb.CanHandle((TestOptions)null);

            // Assert
            Assert.False(result);
        }
    }
}
