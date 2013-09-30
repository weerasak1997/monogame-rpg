﻿#region Using Statements

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGameRPG.Graphics;

#endregion

namespace MonoGameRPG.Gameplay
{
    /// <summary>
    /// Class for individual tiles in a tile map.
    /// </summary>
    public class Tile : IDrawable
    {
        #region Fields

        // Index of the tile in the tile set
        private int tileIndex;
        // Index of the tile set used according to the tile map
        private int tileSetIndex;

        // Image for the tile set
        private TileSetImage tileSetImage;
        // Source rectangle for drawing the tile
        private Rectangle sourceRect;

        // Tile position
        private Vector2 position;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the index of the tile in the tile set.
        /// </summary>
        public int TileIndex
        {
            get { return tileIndex; }
        }

        /// <summary>
        /// Gets the index of the used tile set according to the tile map.
        /// </summary>
        public int TileSetIndex
        {
            get { return tileSetIndex; }
        }

        /// <summary>
        /// Gets or sets the position of the tile.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the source rectangle for the tile.
        /// </summary>
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor creating the tile from an existing tile set image.
        /// </summary>
        /// <param name="tileSetImage">Tile set image.</param>
        public Tile(TileSetImage tileSetImage, int tileIndex, int tileSetIndex)
        {
            this.tileIndex = tileIndex;
            this.tileSetIndex = tileSetIndex;
            this.tileSetImage = tileSetImage;
            sourceRect = tileSetImage.GetSourceRectangle(tileIndex);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the content for the tile.
        /// </summary>
        /// <param name="contentManager">Content manager object.</param>
        public void LoadContent(ContentManager contentManager)
        {
            tileSetImage.LoadContent(contentManager);
        }

        /// <summary>
        /// Draws the tile to the screen.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch object used for 2D rendering.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            tileSetImage.Draw(spriteBatch, position, sourceRect);
        }

        #endregion
    }
}