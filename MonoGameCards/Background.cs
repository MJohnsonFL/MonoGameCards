using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameCards
{
    class Background
    {
        Vector2 position = new Vector2(0, 0);
        List<Texture2D> images = new List<Texture2D>();
        int activeImage = 0;

        public void Change()
        {
            if ((activeImage + 1) >= images.Count)
                activeImage = 0;
            else
                activeImage++;
        }

        public void LoadContent(ContentManager Content)
        {
            images.Add(Content.Load<Texture2D>("Backgrounds/Green Leaf"));
            images.Add(Content.Load<Texture2D>("Backgrounds/Green Fancy"));
            images.Add(Content.Load<Texture2D>("Backgrounds/Purple Wave"));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(images[activeImage], position, Color.White);
        }
    }
}