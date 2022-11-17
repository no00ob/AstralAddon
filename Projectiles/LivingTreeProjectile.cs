using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AstralVoyage.Projectiles
{
    public class LivingTreeProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 16;               //The width of projectile hitbox
            Projectile.height = 26;              //The height of projectile hitbox
            Projectile.friendly = false;         //Can the projectile deal damage to enemies?
            Projectile.hostile = true;         //Can the projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Magic;           //Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1;           //How many monsters the projectile can pentrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 200;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in)
            Projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update mutiple time in a frame	
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
            AIType = ProjectileID.EnchantedBeam;           //Act exactly like default Bullet
        }

        public override void AI()
        {
            {
                Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + MathHelper.ToRadians(95f);
            }

            if (Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
                Projectile.localAI[0] = 1f;
            }
            int num666 = 8;
            int num667 = Dust.NewDust(new Vector2(Projectile.position.X + (float)num666 + 6, Projectile.position.Y + (float)num666), Projectile.width - num666 * 2, Projectile.height - num666 * 2, 66, 0f, 0f, 0, new Color(105, 60, 45), 1.5f);  //projectile dust color
            Main.dust[num667].velocity *= 0.5f;
            Main.dust[num667].velocity += Projectile.velocity * 0.5f;
            Main.dust[num667].noGravity = true;
            Main.dust[num667].noLight = false;
            Main.dust[num667].scale = 1.4f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffType<Buffs.WoodSplinters>(), 12, false);
        }
    }
}
