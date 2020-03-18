using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Projectiles
{
    class JestersBulletBullet : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 8;               //The width of projectile hitbox
            projectile.height = 8;              //The height of projectile hitbox
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 8192;        //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well) 16 384
            projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 1f;            //How much light emit around the projectile
            projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
            aiType = ProjectileID.JestersArrow;           //Act exactly like default Bullet
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 9);
                projectile.localAI[0] = 1f;
            }

            Color[] colors = new Color[5];
            colors[0] = new Color(255, 95, 255); // purple
            colors[1] = new Color(255, 255, 95); // yellow
            colors[2] = new Color(255, 95, 95); // red
            colors[3] = new Color(95, 255, 255); // blue
            colors[4] = new Color(95, 255, 95); // green

            Random rand = new Random();
            int whichColor = rand.Next(0,5);

            int particleType = rand.Next(176, 180);

            int num666 = 8;
            int num667 = Dust.NewDust(new Vector2(projectile.position.X + (float)num666 + 6, projectile.position.Y + (float)num666), projectile.width - num666 * 2, projectile.height - num666 * 2, particleType, 0f, 0f, 0, default(Color), 1.1f);  //projectile dust color
            Main.dust[num667].velocity *= 0.5f;
            Main.dust[num667].velocity += projectile.velocity * 0.1f;
            Main.dust[num667].noGravity = true;
            Main.dust[num667].noLight = false;
            //Main.dust[num667].scale = 2.4f;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);

            Random rand = new Random();
            int particleType = rand.Next(176, 180);

            int num666 = 8;
            int num667 = Dust.NewDust(new Vector2(projectile.position.X + (float)num666 + 6, projectile.position.Y + (float)num666), projectile.width - num666 * 2, projectile.height - num666 * 2, particleType, 0f, 0f, 0, default(Color), 1.1f);  //projectile dust color
            Main.dust[num667].velocity *= 0.5f;
            //Main.dust[num667].velocity += projectile.velocity * 0.5f;
            Main.dust[num667].noGravity = false;
            Main.dust[num667].noLight = false;
            float current = Main.dust[num667].scale;
            //Main.dust[num667].scale = 2.4f;
        }
    }
}
