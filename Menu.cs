using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using Color = Microsoft.Xna.Framework.Color;


namespace lost_clothes_code
{
    public class Menu : GameScreen
    {
        private Game1 _myGame;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private TiledMapTileLayer _mapLayer;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _jouerPosition;
        private AnimatedSprite _jouer;
        private string _jouerAnimation;

        public Menu(Game1 game) : base(game)
        {
            Content.RootDirectory = "Content";
            _myGame = game;
        }

        public override void Initialize()
        {
            _jouerPosition.X = 380;
            _jouerPosition.Y = 225;
            _jouerAnimation = ("sombre");
            base.Initialize();
        }

        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("Maps/ecran_acceuil");
            _mapLayer = _tiledMap.GetLayer<TiledMapTileLayer>("briques");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("jouer menu.sf", new JsonContentLoader());
            _jouer = new AnimatedSprite(spriteSheet);
        }

        public override void Update(GameTime gametime)
        {
           if ((Mouse.GetState().X > _jouerPosition.X - 270) && (Mouse.GetState().X < _jouerPosition.X + 270 ) 
                && (Mouse.GetState().Y > _jouerPosition.Y - 135) && (Mouse.GetState().Y < _jouerPosition.Y + 135))
            {
                _jouerAnimation = "clair";
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _myGame.LoadScreen1_1();
                }
            }
            else
            {
                _jouerAnimation = "sombre";
            }
            _jouer.Play(_jouerAnimation);
            _jouer.Update(gametime);
            _tiledMapRenderer.Update(gametime);

            
        }

        public override void Draw(GameTime gametime)
        {
            _myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            _myGame.SpriteBatch.Begin();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_jouer,_jouerPosition);
            _tiledMapRenderer.Draw();
            _spriteBatch.End();
            _myGame.SpriteBatch.End();
        }
    }
}
