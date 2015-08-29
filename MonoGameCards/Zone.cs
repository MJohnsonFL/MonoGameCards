
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameCards
{
    class Zone : Deck
    {
        protected Vector2 location;
        private Texture2D locationBox;
        public Rectangle Rectangle { get { return new Rectangle((int)location.X - 2, (int)location.Y - 3, locationBox.Width, locationBox.Height); } }

        public Zone(Vector2 Location)
        {
            this.location = Location;
        }

        public virtual void LoadContent(ContentManager Content)
        {
            locationBox = Content.Load<Texture2D>("LocationBox");
        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);
            card.Position = new Vector2(location.X + (Cards.IndexOf(card) * .3f), 50 - (Cards.IndexOf(card) * .3f));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Make Drawing of locationBox @ location determined irrespective of the image chosen
            spriteBatch.Draw(locationBox, Rectangle, Color.White);
            base.Draw(spriteBatch);
        }
    }
}