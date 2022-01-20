using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;

namespace lost_clothes_code
{
    public class Global
    {
        public static bool IsCollision(TiledMapTileLayer mapLayer, ushort x, ushort y)
        {
            // détermine si la tuile en (x,y) est un obstacle (mur ou objet)
            if (mapLayer.GetTile(x, y).GlobalIdentifier > 0 && mapLayer.GetTile(x, y).GlobalIdentifier < 43)
                return true;

            return false;
        }

        public static void Update(Game1 game, GameTime gametime, ref Sprite perso, ref Stopwatch stopWatchSaut, ref Stopwatch stopWatchChute, ref Stopwatch stopWatchMarche)
        {
            float deltaSeconds = (float)gametime.ElapsedGameTime.TotalSeconds;
            int walkSpeed = (int)(deltaSeconds * perso.VitesseDeplacement);
            string sensVertical = "N";      // N = neutre, H = haut, B = bas

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                stopWatchSaut.Start();
                stopWatchChute.Start();
                sensVertical = "H";
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (stopWatchMarche.ElapsedMilliseconds >= 1000.0 / perso.VitesseMarche || perso.Animation.Substring(0, 1) == "d")
                {
                    if (sensVertical == "H")
                    {
                        if (perso.Animation == "g_jumping_2")
                            perso.Animation = "g_jumping_1";
                        else
                            perso.Animation = "g_jumping_2";
                    }
                    else
                    {
                        if (perso.Animation == "g_walking_2")
                            perso.Animation = "g_walking_1";
                        else
                            perso.Animation = "g_walking_2";
                    }
                    stopWatchMarche.Restart();
                }

                if (!perso.IsCollisionLeft())
                    perso.X -= walkSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (stopWatchMarche.ElapsedMilliseconds >= 1000.0 / perso.VitesseMarche || perso.Animation.Substring(0, 1) == "g")
                {
                    if (sensVertical == "H")
                    {
                        if (perso.Animation == "d_jumping_2")
                            perso.Animation = "d_jumping_1";
                        else
                            perso.Animation = "d_jumping_2";
                    }
                    else
                    {
                        if (perso.Animation == "d_walking_2")
                            perso.Animation = "d_walking_1";
                        else
                            perso.Animation = "d_walking_2";
                    }
                    stopWatchMarche.Restart();
                }

                if (!perso.IsCollisionRight())
                    perso.X += walkSpeed;
            }

            if (stopWatchSaut.IsRunning && !perso.IsCollisionUp())
                perso.Y -= walkSpeed;
            else
                stopWatchSaut.Reset();

            if (!perso.IsCollisionDown())
            {
                perso.Y += (int)(stopWatchChute.ElapsedMilliseconds * walkSpeed / 600);
                stopWatchChute.Start();
            }
            else
            {
                stopWatchSaut.Reset();
                stopWatchChute.Reset();
            }

            if (perso.IsDying)
                game.LoadScreenMenu();
                

            perso.AnimatedSprite.Play(perso.Animation);
            perso.AnimatedSprite.Update(deltaSeconds);
        }
    }
}
