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
    public class niveau_4_3 : GameScreen
    {
        private Game1 _myGame; // pour récuperer le jeu en cours

        private TiledMap _tiledMap; // pour les collisions et generer la map
        private TiledMapRenderer _tiledMapRenderer;

        private SpriteBatch _spriteBatch;
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private Sprite _perso;
        private Sprite _bulle;

        public niveau_4_3(Game1 game) : base(game)
        {
            Content.RootDirectory = "Content";
            _myGame = game;
        }

        public override void Initialize()
        {
            _perso = new Sprite(45, 27, 200, 2, 100, 100, "d_idle", Content.Load<SpriteSheet>("chevalier_2.sf", new JsonContentLoader()), Content.Load<TiledMap>("Maps/map_4_3"));
            _bulle = new Sprite(23, 45, 100, 2, 380, 380, "feu_1", Content.Load<SpriteSheet>("feu.sf", new JsonContentLoader()), Content.Load<TiledMap>("bulle_eau.sf"));
            _stopWatchMarche = new Stopwatch();
            _stopWatchMarche.Start();
            _stopWatchSaut = new Stopwatch();
            _stopWatchChute = new Stopwatch();
            base.Initialize();
        }
        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/map_4_3");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public override void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _myGame.LoadScreen4_3();
            }

            if (_bulle.Animation == "feu_1")
            {
                _bulle.Animation = "feu_2";
            }
            else if (_bulle.Animation == "feu_2")
            {
                _bulle.Animation = "feu_3";
            }
            else if (_bulle.Animation == "feu_3")
            {
                _bulle.Animation = "feu_4";
            }
            else if (_bulle.Animation == "feu_4")
            {
                _bulle.Animation = "feu_1";
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
