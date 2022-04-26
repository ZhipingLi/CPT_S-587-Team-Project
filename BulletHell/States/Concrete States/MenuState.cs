﻿namespace BulletHellShootingGame.States
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
        private Texture2D mainMenuTexture;

        public MenuState()
          : base()
        {
            var buttonTexture = TextureFactory.GetTexture("Controls/Button");
            var buttonFont = TextureFactory.GetSpriteFont("Fonts/Font");
            this.mainMenuTexture = TextureFactory.GetTexture("Titles/whiteMainMenu");

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 350),
                Text = "Quit",
            };

            quitGameButton.Click += this.QuitGameButton_Click;

            var newGameEasyButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Easy Speed",
            };

            newGameEasyButton.Click += this.NewGameEasyButton_Click;
            
            var optionsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Options",
            };
            optionsButton.Click += this.OptionsButton_Click;

            var newGameNormalButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Normal Speed",
            };

            newGameNormalButton.Click += this.NewGameNormalButton_Click;

            this.components = new List<Component>()
            {
                newGameEasyButton,
                newGameNormalButton,
                optionsButton,
                quitGameButton,
            };
        }

        public object GraphicsDevice { get; private set; }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicManagers.GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(this.mainMenuTexture, new Vector2(150, 50), Color.White);

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

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            StateManager.ChangeState(new Options());
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            StateManager.ExitEvent(null, e);
        }
    }
}