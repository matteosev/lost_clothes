using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Sprites;

namespace lost_clothes_code
{
    public class Perso
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

        public Perso(int hauteur, int largeur, int vitesseDeplacement, int vitesseMarche, int x, int y, string animation, SpriteSheet spriteSheet)
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
    }
}
