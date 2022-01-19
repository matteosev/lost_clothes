using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Diagnostics;
using Color = Microsoft.Xna.Framework.Color;


namespace lost_clothes_code
{
    public class niveau_5_2 : GameScreen
    {
        private Game1 _myGame;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private TiledMapTileLayer _mapLayer;
        private SpriteBatch _spriteBatch;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private Sprite _perso;
        private Stopwatch _stopwatchItem;
        private Sprite _bulle;

        public niveau_5_2(Game1 game) : base(game)
        {
            Content.RootDirectory = "Content";
            _myGame = game;
        }

        public override void Initialize()
        {
            _stopWatchMarche = new Stopwatch();
            _stopWatchMarche.Start();
            _stopWatchSaut = new Stopwatch();
            _stopWatchChute = new Stopwatch();
            _stopwatchItem = new Stopwatch();
            base.Initialize();
        }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/map_5_2");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _perso = new Sprite(45, 27, 200, 2, 100, 100, "d_idle", Content.Load<SpriteSheet>("chevalier_2.sf", new JsonContentLoader()), _tiledMap);
            _bulle = new Sprite(23, 45, 100, 2, 290, 290, "electricite_bas_1", Content.Load<SpriteSheet>("feu.sf", new JsonContentLoader()), _tiledMap);
        }

        public override void Update(GameTime gametime)
        {
            Global.Update(gametime, ref _perso, ref _stopWatchSaut, ref _stopWatchChute, ref _stopWatchMarche);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _myGame.LoadScreen5_3();
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
    }
}
