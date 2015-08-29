using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGameCards
{
    class PlayPile : Zone
    {
        public PlayPile(Vector2 Location)
            : base(Location)
        {

        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);

            if (card.isFaceDown)
            {
                card.Position = new Vector2(location.X, location.Y + (10 * this.Cards.IndexOf(card)));
            }
            else if (Cards.Count > 1)
            {
                if (Cards[Cards.IndexOf(card) - 1].isFaceDown == true)
                {
                    card.Position = new Vector2(location.X, location.Y + (10 * this.Cards.IndexOf(card)));
                }
                else
                {
                    card.Position = new Vector2(location.X, Cards[Cards.IndexOf(card) - 1].Position.Y + 25);
                }
            }
            else
            {
                card.Position = location;
            }
        }

        public bool IsLegalAdd(Card card)
        {
            if (card.isFaceDown == true)
            {
                return true;
            }
            else if (this.IsEmpty)
            {
                if (card.Rank == Rank.King)
                {
                    return true;
                }
                return false;
            }
            else if (card.Suit == Suit.Clubs || card.Suit == Suit.Spades)
            {
                if ((this.TopCard.Suit == Suit.Hearts || this.TopCard.Suit == Suit.Diamonds) && this.TopCard.Rank == card.Rank + 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if ((this.TopCard.Suit == Suit.Clubs || this.TopCard.Suit == Suit.Spades) && this.TopCard.Rank == card.Rank + 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}