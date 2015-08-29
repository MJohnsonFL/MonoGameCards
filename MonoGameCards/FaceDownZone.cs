using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoGameCards
{
    class FaceDownZone : Zone
    {
        public FaceDownZone(Vector2 Location)
            : base(Location)
        {

        }

        public override void AddCard(Card card)
        {
            card.isFaceDown = true;
            base.AddCard(card);
        }
    }
}