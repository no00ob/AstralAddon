using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Projectiles
{
    public class BunnyBladeProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 15;               //The width of projectile hitbox
            Projectile.height = 35;              //The height of projectile hitbox
            Projectile.friendly = true;         //Can the projectile deal damage to enemies?
            Projectile.hostile = false;         //Can the projectile deal damage to the player?
            Projectile.ranged = false/* tModPorter Suggestion: Remove. See Item.DamageType */;           //Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 4;           //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 900;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            Projectile.light = 0.8f;            //How much light emit around the projectile
            Projectile.ignoreWater = false;          //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false;          //Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
            AIType = ProjectileID.TerraBeam;           //Act exactly like Terrablade's beam
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + MathHelper.ToRadians(95f);
        }
    }
}
