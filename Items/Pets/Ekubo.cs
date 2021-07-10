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
			item.CloneDefaults(ItemID.ZephyrFish);
            item.width = 18;
            item.height = 28;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item44;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.shoot = ModContent.ProjectileType<Projectiles.Pets.Ekubo>();
			item.buffType = ModContent.BuffType<Buffs.Ekubo>();
        }

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}