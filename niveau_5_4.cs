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
    public class niveau_5_4 : GameScreen
    {
        private Game1 _myGame;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite _perso;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;

        public niveau_5_4(Game1 game) : base(game)
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
            base.Initialize();
        }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/transition_fin");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _perso = new Sprite(45, 27, 200, 2, 100, 300, "d_idle", Content.Load<SpriteSheet>("chevalier_4.sf", new JsonContentLoader()), _tiledMap);
        }

        public override void Update(GameTime gametime)
        {
            Global.Update(_myGame, gametime, ref _perso, ref _stopWatchSaut, ref _stopWatchChute, ref _stopWatchMarche);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _myGame.LoadScreenMenu();
            }

            _tiledMapRenderer.Update(gametime);

        }

        public override void Draw(GameTime gametime)
        {
            _myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            _myGame.SpriteBatch.Begin();
            _tiledMapRenderer.Draw();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso.AnimatedSprite, new Vector2(_perso.X, _perso.Y));
            _spriteBatch.End();
            _myGame.SpriteBatch.End();
        }
    }
}
