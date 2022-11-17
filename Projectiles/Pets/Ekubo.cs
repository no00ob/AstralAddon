using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Projectiles.Pets
{
	public class Ekubo : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Evil Spirit"); // Automatic from .lang files
			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.width = 40;
            Projectile.height = 46;
            //projectile.alpha = 20;
			AIType = ProjectileID.ZephyrFish;
		}
        //public override Color? GetAlpha(Color lightColor)
        //{
        //    //return Color.White;
        //    return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
        //}

        public override bool PreAI() {
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];
			AstralVoyagePlayer modPlayer = player.GetModPlayer<AstralVoyagePlayer>();
			if (player.dead) {
				modPlayer.ekubo = false;
			}
			if (modPlayer.ekubo) {
				Projectile.timeLeft = 2;
			}
		}
	}
}