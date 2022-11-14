using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThumodRe.Projectiles
{
	public class Salty : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.Name = "Salty";
			Projectile.width = 10;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = true;
			Projectile.penetrate = 25;
			Projectile.timeLeft = 400;
			Projectile.light = 0.75f;
			Projectile.extraUpdates = 1;
			Projectile.ignoreWater = true;
		}
		public override void AI()
		{
			if (Projectile.velocity.Y < 5f) // change 5 to lower if speed too fast
			{
				Projectile.velocity = Projectile.velocity + new Vector2(0, 0.2f);
			}
			Lighting.AddLight(Projectile.position, 0.5f, 0.25f, 0f);
		}
        public override void Kill(int timeLeft)
        {
			SoundEngine.PlaySound(SoundID.Item50, Projectile.position);

			Random rand = new Random();

			int num666 = 22;
			int num667 = Dust.NewDust(new Vector2(Projectile.position.X + (float)num666 + 6, Projectile.position.Y + (float)num666), Projectile.width - num666 * 2, Projectile.height - num666 * 2, DustID.Cloud, rand.Next(-20, 20), rand.Next(-20, 20), 0, default(Color), 2f);  //projectile dust color
			int num668 = Dust.NewDust(new Vector2(Projectile.position.X + (float)num666 + 6, Projectile.position.Y + (float)num666), Projectile.width - num666 * 2, Projectile.height - num666 * 2, DustID.Cloud, rand.Next(-20, 20), rand.Next(-20, 20), 0, default(Color), 2f);
			Main.dust[num667].velocity *= 0.2f;
			//Main.dust[num667].velocity += projectile.velocity * 0.5f;
			Main.dust[num667].noGravity = true;
			Main.dust[num667].noLight = true;
			//Main.dust[num667].scale = 2.4f;
			Main.dust[num668].velocity *= 0.2f;
			//Main.dust[num667].velocity += projectile.velocity * 0.5f;
			Main.dust[num668].noGravity = true;
			Main.dust[num668].noLight = true;
			//Main.dust[num667].scale = 2.4f;

			if (!Main.dust[num667].active && !Main.dust[num668].active)
				base.Kill(timeLeft);
        }
    }
}