using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Color = Microsoft.Xna.Framework.Color;


namespace lost_clothes_code
{
    public class niveau_5_3 : GameScreen
    {
        private Game1 _myGame; // pour récuperer le jeu en cours

        private TiledMap _tiledMap; // pour les collisions et generer la map
        private TiledMapRenderer _tiledMapRenderer;
        private TiledMapTileLayer _mapLayer;

        private SpriteBatch _spriteBatch;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private Perso _perso;
        private Vector2 _persoPosition;

        private Stopwatch _stopwatchItem;

        private Perso _bulle;
        public niveau_5_3(Game1 game) : base(game)
        {
            Content.RootDirectory = "Content";
            _myGame = game;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            _perso = new Perso(45, 27, 200, 2, 100, 100, "d_idle", Content.Load<SpriteSheet>("chevalier_4.sf", new JsonContentLoader()));
            _bulle = new Perso(23, 45, 100, 2, 385, 340, "electricite_bas_1", Content.Load<SpriteSheet>("electricite.sf", new JsonContentLoader()));
            _stopWatchMarche = new Stopwatch();
            _stopWatchMarche.Start();
            _stopWatchSaut = new Stopwatch();
            _stopWatchChute = new Stopwatch();
            _stopwatchItem = new Stopwatch();
            base.Initialize();
        }
        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/map_5_3");
            _mapLayer = _tiledMap.GetLayer<TiledMapTileLayer>("briques");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        public override void Update(GameTime gametime)
        {
            float deltaSeconds = (float)gametime.ElapsedGameTime.TotalSeconds;
            int walkSpeed = (int)(deltaSeconds * _perso.VitesseDeplacement);
            string sensVertical = "N";      // N = neutre, H = haut, B = bas
            ushort txUp = (ushort)(_perso.X / _tiledMap.TileWidth);
            ushort tyUp = (ushort)((_perso.Y + _perso.Hauteur / 2) / _tiledMap.TileHeight - 1); // tuile au-dessus
            ushort txLeft = (ushort)((_perso.X + _perso.Largeur) / _tiledMap.TileWidth - 1); // tuile à gauche
            ushort tyLeft = (ushort)(_perso.Y / _tiledMap.TileHeight);
            ushort txRight = (ushort)((_perso.X - _perso.Largeur) / _tiledMap.TileWidth + 1); // tuile à droite
            ushort tyRight = (ushort)((_perso.Y) / _tiledMap.TileHeight);
            ushort txDown = (ushort)(_perso.X / _tiledMap.TileWidth);
            ushort tyDown = (ushort)((_perso.Y - _perso.Largeur / 2) / _tiledMap.TileHeight + 1); // tuile eu-dessous


            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _stopWatchSaut.Start();
                _stopWatchChute.Start();
                sensVertical = "H";
            }
            _stopwatchItem.Start();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (_stopWatchMarche.ElapsedMilliseconds >= 1000.0 / _perso.VitesseMarche || _perso.Animation.Substring(0, 1) == "d")
                {
                    if (sensVertical == "H")
                    {
                        if (_perso.Animation == "g_jumping_2")
                            _perso.Animation = "g_jumping_1";
                        else
                            _perso.Animation = "g_jumping_2";
                    }
                    else
                    {
                        if (_perso.Animation == "g_walking_2")
                            _perso.Animation = "g_walking_1";
                        else
                            _perso.Animation = "g_walking_2";
                    }
                    _stopWatchMarche.Restart();
                }

                if (!IsCollision(txLeft, tyLeft))
                    _perso.X -= walkSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (_stopWatchMarche.ElapsedMilliseconds >= 1000.0 / _perso.VitesseMarche || _perso.Animation.Substring(0, 1) == "g")
                {
                    if (sensVertical == "H")
                    {
                        if (_perso.Animation == "d_jumping_2")
                            _perso.Animation = "d_jumping_1";
                        else
                            _perso.Animation = "d_jumping_2";
                    }
                    else
                    {
                        if (_perso.Animation == "d_walking_2")
                            _perso.Animation = "d_walking_1";
                        else
                            _perso.Animation = "d_walking_2";
                    }
                    _stopWatchMarche.Restart();
                }

                if (!IsCollision(txRight, tyRight))
                    _perso.X += walkSpeed;
            }

            if (_stopWatchSaut.IsRunning && !IsCollision(txUp, tyUp))
                _perso.Y -= walkSpeed;
            else
                _stopWatchSaut.Reset();

            if (!IsCollision(txDown, tyDown))
                _perso.Y += (int)(_stopWatchChute.ElapsedMilliseconds * walkSpeed / 600);
            else
            {
                _stopWatchSaut.Reset();
                _stopWatchChute.Reset();
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _myGame.LoadScreen5_4();
            }
            if (_stopwatchItem.ElapsedMilliseconds >= 200)
            {
                if (_bulle.Animation == "electricite_bas_1")
                {
                    _bulle.Animation = "electricite_bas_2";
                }
                else if (_bulle.Animation == "electricite_bas_2")
                {
                    _bulle.Animation = "electricite_bas_3";
                }
                else if (_bulle.Animation == "electricite_bas_3")
                {
                    _bulle.Animation = "electricite_bas_4";
                }
                else if (_bulle.Animation == "electricite_bas_4")
                {
                    _bulle.Animation = "electricite_bas_5";
                }
                else if (_bulle.Animation == "electricite_bas_5")
                {
                    _bulle.Animation = "electricite_bas_6";
                }
                else if (_bulle.Animation == "electricite_bas_6")
                {
                    _bulle.Animation = "electricite_bas_7";
                }
                else if (_bulle.Animation == "electricite_bas_7")
                {
                    _bulle.Animation = "electricite_bas_8";
                }
                else if (_bulle.Animation == "electricite_bas_8")
                {
                    _bulle.Animation = "electricite_bas_9";
                }
                else if (_bulle.Animation == "electricite_bas_9")
                {
                    _bulle.Animation = "electricite_bas_10";
                }
                else if (_bulle.Animation == "electricite_bas_10")
                {
                    _bulle.Animation = "electricite_bas_11";
                }
                else if (_bulle.Animation == "electricite_bas_11")
                {
                    _bulle.Animation = "electricite_bas_12";
                }
                else if (_bulle.Animation == "electricite_bas_12")
                {
                    _bulle.Animation = "electricite_bas_1";
                }

                _stopwatchItem.Restart();
            }


            _perso.AnimatedSprite.Play(_perso.Animation);
            _perso.AnimatedSprite.Update(deltaSeconds);

            _bulle.AnimatedSprite.Play(_bulle.Animation);
            _bulle.AnimatedSprite.Update(gametime);

            _tiledMapRenderer.Update(gametime);

        }

        public override void Draw(GameTime gametime)
        {
            _myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            _myGame.SpriteBatch.Begin();
            _tiledMapRenderer.Draw();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso.AnimatedSprite, new Vector2(_perso.X, _perso.Y));
            _spriteBatch.Draw(_bulle.AnimatedSprite, new Vector2(_bulle.X, _bulle.Y));
            _spriteBatch.End();
            _myGame.SpriteBatch.End();
        }

        private bool IsCollision(ushort x, ushort y)
        {
            if (_mapLayer.GetTile(x, y).GlobalIdentifier > 10 && _mapLayer.GetTile(x, y).GlobalIdentifier < 43)
                return true;

            return false;
        }

    }
}
