using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class summonneck0 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.urmom.hjson' file.
		public override void SetDefaults()
		{
            Item.accessory = true;
			//Item.neckSlot = 1;
            Item.defense = 30;
            Item.width = 26;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 22, silver: 65);
			Item.rare = ItemRarityID.Lime;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PygmyNecklace, 1);
            recipe.AddIngredient(ItemID.WormScarf, 1);
            recipe.AddIngredient(ItemID.Shackle, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AstralAddonPlayer modPlayer = player.GetAstralPlayer();
            modPlayer.modMinions0 = true;
            modPlayer.damageReduction0 = true;
        }
    }
}
