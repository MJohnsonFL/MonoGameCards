using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoGameCards
{
    class FaceUpZone : Zone
    {
        public FaceUpZone(Vector2 Location)
            : base(Location)
        {

        }

        public override void AddCard(Card card)
        {
            card.isFaceDown = false;
            base.AddCard(card);
        }
    }
}