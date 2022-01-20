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
    public class niveau_4_4 : GameScreen
    {
        private Game1 _myGame;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite _perso;
        private Sprite _perso1;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private Vector2 _itemPosition;
        private AnimatedSprite _item;
        private string _itemAnimation;
        private Stopwatch _stopWatchItem;

        public niveau_4_4(Game1 game) : base(game)
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

            _itemPosition.X = 450;
            _itemPosition.Y = 385;
            _itemAnimation = ("1");
            _stopWatchItem = new Stopwatch();

            base.Initialize();
        }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/transition_4_5");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            SpriteSheet spriteSheetItem = Content.Load<SpriteSheet>("item_4.sf", new JsonContentLoader());
            _item = new AnimatedSprite(spriteSheetItem);

            _perso = new Sprite(45, 27, 200, 2, 90, 380, "d_idle", Content.Load<SpriteSheet>("chevalier_3.sf", new JsonContentLoader()), _tiledMap);
        }

        public override void Update(GameTime gametime)
        {
            Global.Update(_myGame, gametime, ref _perso, ref _stopWatchSaut, ref _stopWatchChute, ref _stopWatchMarche);

            if (_perso.X >= 800)
            {
                _myGame.LoadScreen5_1();
            }
            if (_stopWatchItem.ElapsedMilliseconds >= 200)
            {
                if (_itemAnimation == "1")
                {
                    _itemAnimation = "2";
                }
                else if (_itemAnimation == "2")
                {
                    _itemAnimation = "3";
                }
                else if (_itemAnimation == "3")
                {
                    _itemAnimation = "4";
                }
                else if (_itemAnimation == "4")
                {
                    _itemAnimation = "5";
                }
                else if (_itemAnimation == "5")
                {
                    _itemAnimation = "6";
                }
                else if (_itemAnimation == "6")
                {
                    _itemAnimation = "7";
                }
                else if (_itemAnimation == "7")
                {
                    _itemAnimation = "1";
                }
                _stopWatchItem.Reset();
            }
            if (_perso.X >= _itemPosition.X)
            {
                _perso.SpriteSheet = Content.Load<SpriteSheet>("chevalier_4.sf", new JsonContentLoader());
                _perso.AnimatedSprite = new AnimatedSprite(_perso.SpriteSheet, "d_idle");
                _itemPosition.X = -100;
            }

            _item.Play(_itemAnimation);
            _item.Update(gametime);

            _tiledMapRenderer.Update(gametime);
        }

        public override void Draw(GameTime gametime)
        {
            _myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            _myGame.SpriteBatch.Begin();
            _tiledMapRenderer.Draw();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso.AnimatedSprite, new Vector2(_perso.X, _perso.Y));
            _spriteBatch.Draw(_item, _itemPosition);
            _spriteBatch.End();
            _myGame.SpriteBatch.End();
        }
    }
}
