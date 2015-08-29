using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameCards
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }

        public Card TopCard { get { if (Cards.Count > 0) return Cards[Cards.Count - 1]; else return new Card(); } }

        public bool IsEmpty { get { return Cards.Count == 0; } }

        public void FillDeck()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        Suit = (Suit)s,
                                        Rank = (Rank)c
                                    }
                                            )
                            )
                   .ToList();
        }

        public void Shuffle()
        {
            if (Cards.Count >= 1)
                Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.LastOrDefault(); // FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public virtual void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public IEnumerable<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as Card[] ?? cards.ToArray();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Card card in Cards)
                card.Draw(spriteBatch);
        }


    }
}