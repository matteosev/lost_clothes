using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;

namespace lost_clothes_code
{
    public class Sprite
    {
        private int hauteur;
        private int largeur;
        private int vitesseDeplacement;
        private int vitesseMarche;
        private int x;
        private int y;
        private string animation;
        private SpriteSheet spriteSheet;
        private AnimatedSprite animatedSprite;
        private TiledMap map;
        private TiledMapTileLayer briquesLayer;

        public Sprite(int hauteur, int largeur, int vitesseDeplacement, int vitesseMarche, int x, int y, string animation, SpriteSheet spriteSheet, TiledMap map)
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            this.vitesseDeplacement = vitesseDeplacement;
            this.vitesseMarche = vitesseMarche;
            this.x = x;
            this.y = y;
            this.animation = animation;
            this.spriteSheet = spriteSheet;
            this.animatedSprite = new AnimatedSprite(spriteSheet, animation);
            this.map = map;
            this.briquesLayer = this.map.GetLayer<TiledMapTileLayer>("briques");
        }

        public int Hauteur
        {
            get
            {
                return this.hauteur;
            }
            set
            {
                this.hauteur = value;
            }
        }

        public int Largeur
        {
            get
            {
                return this.largeur;
            }
            set
            {
                this.largeur = value;
            }
        }

        public int VitesseDeplacement
        {
            get
            {
                return this.vitesseDeplacement;
            }
            set
            {
                this.vitesseDeplacement = value;
            }
        }

        public int VitesseMarche
        {
            get
            {
                return this.vitesseMarche;
            }
            set
            {
                this.vitesseMarche = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public string Animation
        {
            get
            {
                return this.animation;
            }
            set
            {
                this.animation = value;
            }
        }

        public SpriteSheet SpriteSheet
        {
            get
            {
                return this.spriteSheet;
            }
            set
            {
                this.spriteSheet = value;
            }
        }

        public AnimatedSprite AnimatedSprite
        {
            get
            {
                return this.animatedSprite;
            }
            set
            {
                this.animatedSprite = value;
            }
        }

        public TiledMap Map
        {
            get
            {
                return this.map;
            }
            set
            {
                this.map = value;
            }
        }

        public ushort TxUp
        {
            get
            {
                return (ushort)(this.X / this.Map.TileWidth);
            }
        }

        public ushort TyUp
        {
            get
            {
                return (ushort)((this.Y + this.Hauteur / 2) / this.Map.TileHeight - 1);
            }
        }

        public ushort TxLeft
        {
            get
            {
                return (ushort)((this.X + this.Largeur) / this.Map.TileWidth - 1);
            }
        }

        public ushort TyLeft
        {
            get
            {
                return (ushort)(this.Y / this.Map.TileHeight);
            }
        }

        public ushort TxRight
        {
            get
            {
                return (ushort)((this.X - this.Largeur) / this.Map.TileWidth + 1);
            }
        }

        public ushort TyRight
        {
            get
            {
                return (ushort)((this.Y) / this.Map.TileHeight);
            }
        }

        public ushort TxDown
        {
            get
            {
                return (ushort)(this.X / this.Map.TileWidth);
            }
        }

        public ushort TyDown
        {
            get
            {
                return (ushort)((this.Y - this.Hauteur / 2) / this.Map.TileHeight + 1);
            }
        }

        public bool IsCollisionUp()
        {
            TiledMapTile tileUp = this.briquesLayer.GetTile(this.TxUp, this.TyUp);

            if (tileUp.GlobalIdentifier > 0 && tileUp.GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionLeft()
        {
            if (this.X <= this.Largeur)
                return true;

            TiledMapTile tileLeft = this.briquesLayer.GetTile(this.TxLeft, this.TyLeft);

            if (tileLeft.GlobalIdentifier > 0 && tileLeft.GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionRight()
        {
            TiledMapTile tileRight = this.briquesLayer.GetTile(this.TxRight, this.TyRight);

            if (tileRight.GlobalIdentifier > 0 && tileRight.GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionDown()
        {
            TiledMapTile tileDown = this.briquesLayer.GetTile(this.TxDown, this.TyDown);

            if (tileDown.GlobalIdentifier > 0 && tileDown.GlobalIdentifier < 43)
                return true;

            return false;
        }


    }
}
