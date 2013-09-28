﻿#region Using Statements

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

using MonoGameRPG.GameScreens;

#endregion

namespace MonoGameRPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BaseGame : Game
    {
        #region Fields

        // Global game instance
        public static Game Instance;

        // Game graphics device
        private GraphicsDeviceManager graphics;
        // Game sprite batch used for drawing 2D textures
        private SpriteBatch spriteBatch;

        #endregion

        #region Constructors

        /// <summary>
        /// Game class default constructor.
        /// </summary>
        public BaseGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set default window properties
            Window.Title = "MonoGame RPG";

            Instance = this;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set graphics device and sprite batch for the screen manage and load content
            ScreenManager.Instance.LoadContent(Content);

            // Set the current game screen to the splash screen
            ScreenManager.Instance.ChangeScreen("SplashScreen");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload screen manager content
            ScreenManager.Instance.UnloadContent();

            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update the input manager
            InputManager.Instance.Update(gameTime);

            // Update the screen manager
            ScreenManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Draw the current game screen
            ScreenManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        #endregion
    }
}
