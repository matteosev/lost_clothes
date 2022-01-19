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
    public class niveau_3_3 : GameScreen
    {
        private Game1 _myGame;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private Sprite _perso;
        private Sprite _bulle;

        public niveau_3_3(Game1 game) : base(game)
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

            _perso = new Sprite(45, 27, 200, 2, 45, 285, "d_idle", Content.Load<SpriteSheet>("chevalier_2.sf", new JsonContentLoader()), _tiledMap);
            _bulle = new Sprite(32, 32, 100, 2, 500, 100, "d_bulle_1", Content.Load<SpriteSheet>("bulle_eau.sf", new JsonContentLoader()), _tiledMap);

            base.Initialize();
        }
        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/map_3_3");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public override void Update(GameTime gametime)
        {
            Global.Update(gametime, ref _perso, ref _stopWatchSaut, ref _stopWatchChute, ref _stopWatchMarche);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _myGame.LoadScreen3_4();
            }

            if (_bulle.X > _perso.X)
            {
                _bulle.X = _bulle.X - 1;
                _bulle.Animation = "g_bulle_1";
            }
            else
            {
                _bulle.X = _bulle.X + 1;
                _bulle.Animation = "d_bulle_1";
            }

            if (_bulle.Y > _perso.Y + 15)
            {
                _bulle.Y = _bulle.Y - 1;
            }
            else
            {
                _bulle.Y = _bulle.Y + 1;
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
