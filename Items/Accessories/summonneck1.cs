using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    [AutoloadEquip(EquipType.Neck)]
    public class summonneck1 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.urmom.hjson' file.
		public override void SetDefaults()
		{
            Item.accessory = true;
			//Item.neckSlot = 1;
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

            // Use calamity ingredients unless the mod is not present
            if (AstralAddonMod.Instance.calamity != null && AstralAddonMod.Instance.calamity.TryFind("LifeAlloy", out ModItem LifeAlloy))
            {
                recipe.AddIngredient(ItemID.BeetleHusk, 1);
                recipe.AddIngredient(LifeAlloy.Type, 3);
            }
            else
            {
                recipe.AddIngredient(ItemID.BeetleHusk, 3);
            }

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
