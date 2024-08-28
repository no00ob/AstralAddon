using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class summonneck2 : ModItem
	{
		public override void SetDefaults()
		{
            Item.accessory = true;
            Item.defense = 80;
            Item.width = 26;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 48, silver: 95);
            Item.rare = ModContent.RarityType<PureGreen>();
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient<summonneck1>(1);
            recipe.AddIngredient<UelibloomBar>(10);
            recipe.AddIngredient<RuinousSoul>(5);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AstralAddonPlayer modPlayer = player.GetAstralPlayer();
            modPlayer.modMinions2 = true;
            modPlayer.damageReduction2 = true;
            modPlayer.modSummonDamage1 = true;
        }
    }
}
