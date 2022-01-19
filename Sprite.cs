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
            if (this.briquesLayer.GetTile(this.TxUp, this.TyUp).GlobalIdentifier > 0 && this.briquesLayer.GetTile(this.TxUp, this.TyUp).GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionLeft()
        {
            if (this.briquesLayer.GetTile(this.TxLeft, this.TyLeft).GlobalIdentifier > 0 && this.briquesLayer.GetTile(this.TxLeft, this.TyLeft).GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionRight()
        {
            if (this.briquesLayer.GetTile(this.TxRight, this.TyRight).GlobalIdentifier > 0 && this.briquesLayer.GetTile(this.TxRight, this.TyRight).GlobalIdentifier < 43)
                return true;

            return false;
        }

        public bool IsCollisionDown()
        {
            if (this.briquesLayer.GetTile(this.TxDown, this.TyDown).GlobalIdentifier > 0 && this.briquesLayer.GetTile(this.TxDown, this.TyDown).GlobalIdentifier < 43)
                return true;

            return false;
        }


    }
}
