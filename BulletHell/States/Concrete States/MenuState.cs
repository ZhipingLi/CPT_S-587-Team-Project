namespace BulletHellShootingGame.States
{
    using System;
    using System.Collections.Generic;
    using BulletHellShootingGame.Controls;
    using BulletHellShootingGame.Game_Utilities;
    using BulletHellShootingGame.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MenuState : State
    {
        private List<Component> components;

        public MenuState()
          : base()
        {
            var buttonTexture = TextureFactory.GetTexture("Controls/Button");
            var buttonFont = TextureFactory.GetSpriteFont("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };

            newGameButton.Click += this.NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit",
            };

            quitGameButton.Click += this.QuitGameButton_Click;

            var newGameEasyButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Start Game",
            };

            newGameEasyButton.Click += this.NewGameEasyButton_Click;

            var newGameNormalButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Normal Speed",
            };

            newGameNormalButton.Click += this.NewGameNormalButton_Click;

            this.components = new List<Component>()
            {
                newGameEasyButton,
                quitGameButton,
            };
        }

        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicManagers.GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();

            foreach (var component in this.components)
            {
                component.Draw(gameTime, spriteBatch);
            }


            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in this.components)
            {
                component.Update(gameTime);
            }
        }

        public override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicManagers.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new GameState());
        }

        private void NewGameNormalButton_Click(object sender, EventArgs e)
        {
            GameLoader.LoadGameDictionary("demo");

            StateManager.ChangeState(new GameState());
        }

        private void NewGameEasyButton_Click(object sender, EventArgs e)
        {
            GameLoader.LoadGameDictionary("demo");

            StateManager.ChangeState(new GameState());
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ExitEvent(null, e);
        }
    }
}