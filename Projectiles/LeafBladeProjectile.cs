using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Projectiles
{
    public class LeafBladeProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.width = 15;               //The width of projectile hitbox
            projectile.height = 28;              //The height of projectile hitbox
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = false;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 1;           //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            projectile.light = 0.3f;            //How much light emit around the projectile
            projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
            aiType = ProjectileID.TerraBeam;           //Act exactly like Terrablade's beam
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(95f);
        }
    }
}
