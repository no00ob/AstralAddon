using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Pets
{
	public class Ekubo : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Spirit Vial");
			Tooltip.SetDefault("Summons a Evil Spirit to follow you\n'Wanna shake hands?'");
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.ZephyrFish);
            Item.width = 18;
            Item.height = 28;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item44;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Ekubo>();
			Item.buffType = ModContent.BuffType<Buffs.Ekubo>();
        }

		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}