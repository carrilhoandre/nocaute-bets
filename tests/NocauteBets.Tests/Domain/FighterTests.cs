using FluentAssertions;
using NocauteBets.Domain.Models;

namespace NocauteBets.Tests.Domain
{
    public class FighterTests
    {
        [Fact]
        public void Fighter_Creation_Success()
        {
            // Arrange
            string name = "Jon Jones";
            string nickname = "Bones";
            string imageUrl = "https://example.com/jon-jones.jpg";
            string cartel = "26-1-0";
            string category = "Light Heavyweight";

            // Act
            var fighter = new Fighter(name, nickname, imageUrl, cartel, category);

            // Assert
            fighter.Name.Should().Be(name);
            fighter.Nickname.Should().Be(nickname);
            fighter.ImageUrl.Should().Be(imageUrl);
            fighter.Cartel.Should().Be(cartel);
            fighter.Category.Should().Be(category);
            fighter.Country.Should().BeNull();
        }

        [Fact]
        public void Fighter_SetNickname_Success()
        {
            // Arrange
            var fighter = new Fighter("Conor McGregor", "The Notorious", "", "", "");

            // Act
            fighter.SetNickname("Conor");

            // Assert
            fighter.Nickname.Should().Be("Conor");
        }

        [Fact]
        public void Fighter_SetCartel_Success()
        {
            // Arrange
            var fighter = new Fighter("Khabib Nurmagomedov", "The Eagle", "", "29-0-0", "");

            // Act
            fighter.SeCartel("30-0-0");

            // Assert
            fighter.Cartel.Should().Be("30-0-0");
        }

        [Fact]
        public void Fighter_SetCountry_Success()
        {
            // Arrange
            var fighter = new Fighter("Amanda Nunes", "The Lioness", "", "", "");

            // Act
            fighter.SetCountry("Brazil");

            // Assert
            fighter.Country.Should().Be("Brazil");
        }
    }
}
