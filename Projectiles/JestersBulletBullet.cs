using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Projectiles
{
    class JestersBulletBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Jester's Bullet");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
            Projectile.width = 2;               //The width of projectile hitbox
            Projectile.height = 22;              //The height of projectile hitbox
            //projectile.friendly = true;         //Can the projectile deal damage to enemies?
            //projectile.hostile = false;         //Can the projectile deal damage to the player?
            //projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 8192;        //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well) 16 384
            //projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            Projectile.light = 1f;            //How much light emit around the projectile
            Projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            AIType = ProjectileID.BulletHighVelocity;           //Act exactly like default Bullet
            Projectile.aiStyle = 1;
        }

        Color RandomColor()
        {
            Color[] colors = new Color[5];
            colors[0] = new Color(255, 95, 255); // purple
            colors[1] = new Color(255, 255, 95); // yellow
            colors[2] = new Color(255, 95, 95); // red
            colors[3] = new Color(95, 255, 255); // blue
            colors[4] = new Color(95, 255, 95); // green

            Random rand = new Random();
            int whichColor = rand.Next(0, 5);

            return colors[whichColor];
        }

        int RandomType()
        {
            Random rand = new Random();
            int particleType = rand.Next(176, 180);
            return particleType;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                //spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            //if (projectile.localAI[0] == 0f)
            //{
            //   Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 9);
            //    projectile.localAI[0] = 1f;
            //}

            Random rand = new Random();

            int num666 = 22;
            int num667 = Dust.NewDust(new Vector2(Projectile.position.X + (float)num666 + 6, Projectile.position.Y + (float)num666), Projectile.width - num666 * 2, Projectile.height - num666 * 2, RandomType(), 0f, rand.Next(-10, 10), 0, default(Color), 1.2f);  //projectile dust color
            Main.dust[num667].velocity *= 0.2f;
            //Main.dust[num667].velocity += projectile.velocity * 0.1f;
            Main.dust[num667].noGravity = true;
            Main.dust[num667].noLight = false;
            //Main.dust[num667].scale = 2.4f;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            Random rand = new Random();

            int num666 = 22;
            int num667 = Dust.NewDust(new Vector2(Projectile.position.X + (float)num666 + 6, Projectile.position.Y + (float)num666), Projectile.width - num666 * 2, Projectile.height - num666 * 2, RandomType(), rand.Next(-20, 20), rand.Next(-20, 20), 0, default(Color), 1.2f);  //projectile dust color
            Main.dust[num667].velocity *= 0.2f;
            //Main.dust[num667].velocity += projectile.velocity * 0.5f;
            Main.dust[num667].noGravity = true;
            Main.dust[num667].noLight = false;
            //Main.dust[num667].scale = 2.4f;
        }
    }
}
