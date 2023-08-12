using FluentAssertions;
using NocauteBets.Domain.Models;

namespace NocauteBets.Tests.Domain
{
    public class OddTests
    {
        [Fact]
        public void WinOdd_Creation_Success()
        {
            // Arrange
            decimal value = 2.5m;

            // Act
            var winOdd = new WinOdd { Value = value };

            // Assert
            winOdd.Type.Should().Be(OddType.Win);
            winOdd.Value.Should().Be(value);
        }

        [Fact]
        public void SubmissionOdd_Creation_Success()
        {
            // Arrange
            decimal value = 5.0m;

            // Act
            var submissionOdd = new SubmissionOdd { Value = value };

            // Assert
            submissionOdd.Type.Should().Be(OddType.Submission);
            submissionOdd.Value.Should().Be(value);
        }

        [Fact]
        public void KOOdd_Creation_Success()
        {
            // Arrange
            decimal value = 3.0m;

            // Act
            var koOdd = new KoOdd { Value = value };

            // Assert
            koOdd.Type.Should().Be(OddType.KO);
            koOdd.Value.Should().Be(value);
        }

        [Fact]
        public void DecisionOdd_Creation_Success()
        {
            // Arrange
            decimal value = 1.8m;

            // Act
            var decisionOdd = new DecisionOdd { Value = value };

            // Assert
            decisionOdd.Type.Should().Be(OddType.Decision);
            decisionOdd.Value.Should().Be(value);
        }
    }
}
