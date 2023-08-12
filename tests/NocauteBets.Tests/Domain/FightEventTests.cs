using FluentAssertions;
using NocauteBets.Domain.Models;
using NSubstitute;

namespace NocauteBets.Tests.Domain
{
    public class FightEventTests
    {
        [Fact]
        public void FightEvent_Creation_Success()
        {
            // Arrange
            string eventName = "UFC 123";
            DateTime eventDate = DateTime.Now;

            // Act
            var fightEvent = new FightEvent(eventName, eventDate);

            // Assert
            fightEvent.Name.Should().Be(eventName);
            fightEvent.Date.Should().Be(eventDate);
            fightEvent.Fights.Should().BeEmpty();
        }

        [Fact]
        public void FightEvent_AddFights_Success()
        {
            // Arrange
            var fightEvent = new FightEvent("UFC 123", DateTime.Now);
            var fights = new List<Fight>
            {
                Substitute.For<Fight>(),
                Substitute.For<Fight>(),
                Substitute.For<Fight>()
            };

            // Act
            fightEvent.AddFights(fights);

            // Assert
            fightEvent.Fights.Should().HaveCount(fights.Count);
            fightEvent.Fights.Should().BeEquivalentTo(fights);
        }

        [Fact]
        public void FightEvent_AddFights_NullFights_ThrowsException()
        {
            // Arrange
            var fightEvent = new FightEvent("UFC 123", DateTime.Now);

            // Act
            Action action = () => fightEvent.AddFights(null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
