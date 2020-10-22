using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CardsService : ICardsService
    {
        public IEnumerable<Card> FetchCards()
        {
            return new List<Card>()
            {
                new Card() {Attack = 20, Defense = 10, Name = "juansito"},
                new Card() {Attack = 30, Defense = 20, Name = "dianita"},
                new Card() {Attack = 10, Defense = 40, Name = "juansitoXX"},
                new Card() {Attack = 30, Defense = 30, Name = "Carlos"}
            };
        }
    }
}
