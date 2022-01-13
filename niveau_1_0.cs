using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class niveau_1_0 : GameScreen
    {
        private Game1 _myGame; // pour récuperer le jeu en cours
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private const int HAUTEUR_PERSO = 45;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _persoPosition;
        private AnimatedSprite _perso;
        private int _vitessePerso;
        private int _vitesseMarche;     // nombre de pas par seconde pour l'_animationPerso
        private Stopwatch _stopWatchMarche;
        private Stopwatch _stopWatchSaut;
        private Stopwatch _stopWatchChute;
        private string _animationPerso;
        private int _dureeMaximaleSaut; // durée maximale de saut du perso en millisecondes
        private SpriteFont _font;
        private Vector2 _positionTexte;
        public niveau_1_0(Game1 game) : base(game)
        {
            Content.RootDirectory = "Content";
            _myGame = game;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            _persoPosition.X = 100;
            _persoPosition.Y = 400;
            _vitessePerso = 200;
            _vitesseMarche = 2;
            _stopWatchMarche = new Stopwatch();
            _stopWatchMarche.Start();
            _stopWatchSaut = new Stopwatch();
            _stopWatchChute = new Stopwatch();
            _animationPerso = "d_idle";
            _positionTexte = new Vector2(0, 0);

            base.Initialize();
        }
        public override void LoadContent()
        {
            _tiledMap = Content.Load<TiledMap>("niveau 1-0");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("chevalier_0.sf", new JsonContentLoader());
            _perso = new AnimatedSprite(spriteSheet);
            _font = Content.Load<SpriteFont>("font");

        }

        public override void Update(GameTime gametime)
        {

            _tiledMapRenderer.Update(gametime);
        }

        public override void Draw(GameTime gametime)
        {
            _myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            
            
            _myGame.SpriteBatch.Begin();
            _tiledMapRenderer.Draw();
            _spriteBatch.Begin();
            _spriteBatch.Draw(_perso, _persoPosition);
            _spriteBatch.End();
            _myGame.SpriteBatch.End();
        }

    }
}
