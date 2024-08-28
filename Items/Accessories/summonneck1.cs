using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;
using CalamityMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class summonneck1 : ModItem
	{
		public override void SetDefaults()
		{
            Item.accessory = true;
            Item.defense = 50;
            Item.width = 26;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 28, silver: 45);
			Item.rare = ItemRarityID.Yellow;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient<summonneck0>(1);
            recipe.AddIngredient(ItemID.BeetleHusk, 1);
            recipe.AddIngredient<LifeAlloy>(3);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AstralAddonPlayer modPlayer = player.GetAstralPlayer();
            modPlayer.modMinions1 = true;
            modPlayer.damageReduction1 = true;
            modPlayer.modSummonDamage0 = true;
        }
    }
}
