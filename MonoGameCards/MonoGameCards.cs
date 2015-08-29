using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MonoGameCards
{
    public class MonoGameCards : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background background = new Background();

        FaceDownZone DrawPile = new FaceDownZone(new Vector2(25, 50));
        FaceUpZone FaceUpPile = new FaceUpZone(new Vector2(200, 50));
        Hand MyHand = new Hand();

        List<PlayPile> PlayPiles = new List<PlayPile> { new PlayPile(new Vector2(25, 250)),
                                                        new PlayPile(new Vector2(200, 250)),
                                                        new PlayPile(new Vector2(375, 250)),
                                                        new PlayPile(new Vector2(550, 250)),
                                                        new PlayPile(new Vector2(725, 250)),
                                                        new PlayPile(new Vector2(900, 250)),
                                                        new PlayPile(new Vector2(1075, 250))};

        List<AcePile> AcePiles = new List<AcePile> { new AcePile(new Vector2(550, 50)),
                                                     new AcePile(new Vector2(725, 50)),
                                                     new AcePile(new Vector2(900, 50)),
                                                     new AcePile(new Vector2(1075, 50))};

        KeyboardState currentKey;
        KeyboardState previousKey;

        MouseState currentMouse;
        MouseState previousMouse;

        Vector2 mousePosition;
        Vector2 cardOffset;

        bool dragging = false;

        public MonoGameCards()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Xna Solitaire";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1024 + 256;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background.LoadContent(Content);

            DrawPile.LoadContent(Content);
            FaceUpPile.LoadContent(Content);

            foreach (AcePile acePile in AcePiles)
                acePile.LoadContent(Content);

            foreach (PlayPile playPile in PlayPiles)
                playPile.LoadContent(Content);

            SetupNewSolitaireGame();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            currentKey = Keyboard.GetState();
            currentMouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (currentKey.IsKeyDown(Keys.B) && previousKey.IsKeyUp(Keys.B))
            {
                background.Change();
            }

            if (currentKey.IsKeyDown(Keys.F2) && previousKey.IsKeyUp(Keys.F2))
            {
                SetupNewSolitaireGame();
            }

            mousePosition = new Vector2(currentMouse.X, currentMouse.Y);
            Point mousePoint = new Point((int)mousePosition.X, (int)mousePosition.Y);

            // Mouse Click
            #region MouseClick where Previous == Released && Current == Pressed
            // On Mouse Click
            if (previousMouse.LeftButton == ButtonState.Released &&
                currentMouse.LeftButton == ButtonState.Pressed)
            {
                // Draw Pile is Empty so take all cards from Face Up Pile and Return them to Draw Pile
                if (DrawPile.IsEmpty && DrawPile.Rectangle.Contains(mousePoint))
                {
                    int cardCount = FaceUpPile.Cards.Count;

                    for (int i = 0; i < cardCount; i++)
                    {
                        DrawPile.AddCard(FaceUpPile.TakeCard());
                        DrawPile.Cards[i].isFaceDown = true;
                    }
                }
                // Draw a Card from Draw Pile and place in Face Up Pile
                if (!DrawPile.IsEmpty && DrawPile.TopCard.CardRectangle.Contains(mousePoint))
                {
                    Card c = DrawPile.TakeCard();
                    c.isFaceDown = false;
                    FaceUpPile.AddCard(c);
                }
                // Play Piles
                foreach (PlayPile playPile in PlayPiles)
                {
                    if (!playPile.IsEmpty && playPile.TopCard.isFaceDown)
                    {
                        playPile.TopCard.isFaceDown = false;
                    }
                }
            }
            #endregion

            // Dragging
            #region MouseClick where Current == Pressed && Previous == Pressed
            if (currentMouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Pressed)
            {
                if (dragging)
                {
                    MyHand.Update(mousePosition - cardOffset);
                }
                else if (FaceUpPile.TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - FaceUpPile.TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(FaceUpPile.TakeCard(), FaceUpPile);
                    dragging = true;
                }
                else if (PlayPiles[0].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[0].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[0].TakeCard(), PlayPiles[0]);
                    dragging = true;
                }
                else if (PlayPiles[1].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[1].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[1].TakeCard(), PlayPiles[1]);
                    dragging = true;
                }
                else if (PlayPiles[2].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[2].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[2].TakeCard(), PlayPiles[2]);
                    dragging = true;
                }
                else if (PlayPiles[3].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[3].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[3].TakeCard(), PlayPiles[3]);
                    dragging = true;
                }
                else if (PlayPiles[4].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[4].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[4].TakeCard(), PlayPiles[4]);
                    dragging = true;
                }
                else if (PlayPiles[5].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[5].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[5].TakeCard(), PlayPiles[5]);
                    dragging = true;
                }
                else if (PlayPiles[6].TopCard.CardRectangle.Contains(mousePoint))
                {
                    cardOffset = mousePosition - PlayPiles[6].TopCard.Position;
                    if (MyHand.Cards.Count < 1) // TEMP For Testing.........Remove Later
                        MyHand.AddFromDeck(PlayPiles[6].TakeCard(), PlayPiles[6]);
                    dragging = true;
                }
            }
            else
            {
                dragging = false;
            }
            #endregion

            // Mouse Released
            #region MouseClick where Previous == Pressed && Current == Released
            // Mouse Button Released
            if (previousMouse.LeftButton == ButtonState.Pressed &&
                currentMouse.LeftButton == ButtonState.Released)
            {
                if (MyHand.IsEmpty == false)
                {
                    Point cardCorner = new Point((int)MyHand.TopCard.Position.X, (int)MyHand.TopCard.Position.Y);

                    foreach (AcePile acePile in AcePiles)
                    {
                        if (acePile.TopCard.CardRectangle.Contains(cardCorner) || acePile.Rectangle.Contains(cardCorner))
                        //if (acePile.Rectangle.Contains(cardCorner))
                        {
                            if (acePile.IsLegalAdd(MyHand.TopCard))
                            {
                                acePile.AddCard(MyHand.TakeCard());
                                break;
                            }
                        }
                    }
                }

                if (MyHand.IsEmpty == false)
                {
                    Point cardCorner = new Point((int)MyHand.TopCard.Position.X, (int)MyHand.TopCard.Position.Y);

                    foreach (PlayPile playPile in PlayPiles)
                    {
                        if (playPile.TopCard.CardRectangle.Contains(cardCorner) || playPile.Rectangle.Contains(cardCorner))
                        {
                            if (playPile.IsLegalAdd(MyHand.TopCard))
                            {
                                playPile.AddCard(MyHand.TakeCard());
                                break;
                            }
                        }
                    }
                }
                if (MyHand.IsEmpty == false)
                {
                    MyHand.LastDeck.AddCard(MyHand.TakeCard());
                }
            }
            #endregion

            previousKey = currentKey;
            previousMouse = currentMouse;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            background.Draw(spriteBatch);

            DrawPile.Draw(spriteBatch);
            FaceUpPile.Draw(spriteBatch);

            foreach (AcePile acePile in AcePiles)
                acePile.Draw(spriteBatch);

            foreach (PlayPile playPile in PlayPiles)
                playPile.Draw(spriteBatch);

            MyHand.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetupNewSolitaireGame()
        {
            DrawPile.Cards.Clear();
            FaceUpPile.Cards.Clear();
            MyHand.Cards.Clear();
            foreach (AcePile acePile in AcePiles)
                acePile.Cards.Clear();
            foreach (PlayPile playPile in PlayPiles)
                playPile.Cards.Clear();

            Deck deck = new Deck();

            deck.FillDeck();
            deck.Shuffle();

            foreach (Card card in deck.Cards)
            {
                card.LoadContent(Content);
            }

            for (int i = 0; i < PlayPiles.Count; i++)
            {
                for (int j = 0; i >= j; j++)
                {
                    PlayPiles[i].AddCard(deck.TakeCard());
                }
                PlayPiles[i].Cards[i].isFaceDown = false;
            }

            for (int i = 0; deck.Cards.Count > 0; i++)
            {
                Card c = deck.TakeCard();
                DrawPile.AddCard(c);
            }

        }

    }
}