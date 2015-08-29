using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameCards
{
    class Hand : Deck
    {
        public Vector2 Location = new Vector2(0, 0);
        public Deck LastDeck = null;

        public void Update(Vector2 newCardPosition)
        {
            foreach (Card card in Cards)
            {
                int i = Cards.IndexOf(card);
                card.Position = new Vector2(newCardPosition.X, newCardPosition.Y + (32 * i));
            }
        }

        public override void AddCard(Card card)
        {
            throw new InvalidOperationException("Please use AddFromDeck(Card card, Deck FromDeck) instead");
        }

        public void AddFromDeck(Card card, Deck FromDeck)
        {
            LastDeck = FromDeck;
            base.AddCard(card);
        }
    }
}