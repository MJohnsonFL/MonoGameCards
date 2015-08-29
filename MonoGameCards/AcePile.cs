using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameCards
{
    class AcePile : Zone
    {
        public AcePile(Vector2 Location)
            : base(Location)
        {

        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);
        }

        public bool IsLegalAdd(Card card)
        {
            if (this.IsEmpty)
            {
                if (card.Rank == Rank.Ace)
                {
                    return true;
                }
                return false;
            }

            if (this.TopCard.Suit == card.Suit)
            {
                if (this.TopCard.Rank == card.Rank - 1)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}