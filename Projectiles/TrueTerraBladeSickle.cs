using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralVoyage;

namespace AstralVoyage.Projectiles
{
    public class TrueTerraBladeSickle : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 16;               //The width of projectile hitbox
            projectile.height = 20;              //The height of projectile hitbox
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = false;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 2;           //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = false;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
            aiType = ProjectileID.TerraBeam;           //Act exactly like default Bullet
        }

        public override void AI()
        {
            {
                if (projectile.localAI[0] == 0f)
                {
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
                    projectile.localAI[0] = 1f;
                }
                int num666 = 8;
                int num667 = Dust.NewDust(new Vector2(projectile.position.X + (float)num666 + 6, projectile.position.Y + (float)num666), projectile.width - num666 * 2, projectile.height - num666 * 2, 66, 0f, 0f, 0, new Color(0, 229, 26), 1.5f);  //projectile dust color
                Main.dust[num667].velocity *= 0.5f;
                Main.dust[num667].velocity += projectile.velocity * 0.5f;
                Main.dust[num667].noGravity = true;
                Main.dust[num667].noLight = false;
                Main.dust[num667].scale = 2.4f;
            }
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }
    }
}