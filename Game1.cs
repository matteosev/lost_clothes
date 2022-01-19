using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace lost_clothes_code
{
    public class Game1 : Game
    {
        private const int HAUTEUR_FENETRE = 450;
        private const int LARGEUR_FENETRE = 765;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly ScreenManager _screenManager;
        private bool _menuStarted;

        public SpriteBatch SpriteBatch { get => _spriteBatch; set => _spriteBatch = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadScreenMenu();
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            _graphics.PreferredBackBufferHeight = HAUTEUR_FENETRE;
            _graphics.PreferredBackBufferWidth = LARGEUR_FENETRE;
            _graphics.ApplyChanges();

            if (!_menuStarted)
            {
                _menuStarted = true;
                LoadScreenMenu();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void LoadScreen1_0()
        {
            _screenManager.LoadScreen(new niveau_1_0(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen1_1()
        {
            _screenManager.LoadScreen(new niveau_1_1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen1_2()
        {
            _screenManager.LoadScreen(new niveau_1_2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen1_3()
        {
            _screenManager.LoadScreen(new niveau_1_3(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen1_4()
        {
            _screenManager.LoadScreen(new niveau_1_4(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen2_1()
        {
            _screenManager.LoadScreen(new niveau_2_1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen2_2()
        {
            _screenManager.LoadScreen(new niveau_2_2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen2_3()
        {
            _screenManager.LoadScreen(new niveau_2_3(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen2_4()
        {
            _screenManager.LoadScreen(new niveau_2_4(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen3_1()
        {
            _screenManager.LoadScreen(new niveau_3_1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen3_2()
        {
            _screenManager.LoadScreen(new niveau_3_2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen3_3()
        {
            _screenManager.LoadScreen(new niveau_3_3(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen3_4()
        {
            _screenManager.LoadScreen(new niveau_3_4(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen4_1()
        {
            _screenManager.LoadScreen(new niveau_4_1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen4_2()
        {
            _screenManager.LoadScreen(new niveau_4_2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen4_3()
        {
            _screenManager.LoadScreen(new niveau_4_3(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen4_4()
        {
            _screenManager.LoadScreen(new niveau_4_4(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen5_1()
        {
            _screenManager.LoadScreen(new niveau_5_1(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen5_2()
        {
            _screenManager.LoadScreen(new niveau_5_2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen5_3()
        {
            _screenManager.LoadScreen(new niveau_5_3(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen5_4()
        {
            _screenManager.LoadScreen(new niveau_5_4(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreenMenu()
        {
            _screenManager.LoadScreen(new Menu(this));
        }

    }

}
