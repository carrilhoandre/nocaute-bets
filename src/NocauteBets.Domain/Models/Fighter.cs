using Shared.Domain;

namespace NocauteBets.Domain.Models
{
    public class Fighter : AggregateRoot
    {
        public Fighter(string name, string nickname, string imageUrl, string cartel, string category)
        {
            Name = name;
            Nickname = nickname;
            ImageUrl = imageUrl;
            Cartel = cartel;
            Category = category;
        }

        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public string ImageUrl { get; private set; }
        public string Cartel { get; private set; }
        public string Category { get; private set; }

        public void SetNickname(string newNickname)
        {
            Nickname = newNickname;
        }

        public void SeCartel(string newCartel)
        {
            Cartel = newCartel;
        }
        //public FighterCategory Category { get; private set; }
    }
}
