using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameCards
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        // Vector2 position = new Vector2(0, 0);
        Texture2D faceTexture;
        Texture2D backTexture;
        Rectangle cardRectangle = new Rectangle();

        public Rectangle CardRectangle
        {
            get { return cardRectangle; }
            // set { cardRectangle = value; }
        }

        public bool isFaceDown = true;

        public Vector2 Position
        {
            get { return new Vector2(cardRectangle.X, cardRectangle.Y); }
            set
            {
                cardRectangle.X = (int)value.X;
                cardRectangle.Y = (int)value.Y;
            }
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            backTexture = Content.Load<Texture2D>("Cards/cardBack_blue2");
            faceTexture = Content.Load<Texture2D>("Cards/" + this.Rank.ToString() + " of " + this.Suit.ToString());
            //cardRectangle = new Rectangle(0, 0, faceTexture.Width, faceTexture.Height);
            int width = (int)(faceTexture.Width * .8);
            int height = (int)(faceTexture.Height * .8);
            cardRectangle = new Rectangle(0, 0, width, height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isFaceDown)
                spriteBatch.Draw(backTexture, cardRectangle, Color.White);
            else
                spriteBatch.Draw(faceTexture, cardRectangle, Color.White);
        }
    }
}