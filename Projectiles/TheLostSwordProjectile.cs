using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AstralVoyage.Projectiles
{
    public class TheLostSwordProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 15;               //The width of projectile hitbox
            projectile.height = 35;              //The height of projectile hitbox
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = false;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 2;           //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.6f;            //How much light emit around the projectile
            projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
            aiType = ProjectileID.TerraBeam;           //Act exactly like Terrablade's beam
        }

        public override void AI()
        {
            {
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(95f);
            }

            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
                projectile.localAI[0] = 1f;
            }
            int num666 = 8;
            int num667 = Dust.NewDust(new Vector2(projectile.position.X + (float)num666 + 6, projectile.position.Y + (float)num666), projectile.width - num666 * 2, projectile.height - num666 * 2, 66, 0f, 0f, 0, new Color(0, 229, 26), 0.8f);  //projectile dust color
            Main.dust[num667].velocity *= 0.5f;
            Main.dust[num667].velocity += projectile.velocity * 0.5f;
            Main.dust[num667].noGravity = true;
            Main.dust[num667].noLight = false;
            Main.dust[num667].scale = 0.2f;
        }
    }
}
