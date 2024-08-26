using AstralAddon.AstralPlayer;
using AstralAddon.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class summonneck2 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.urmom.hjson' file.
		public override void SetDefaults()
		{
            Item.accessory = true;
			//Item.neckSlot = 1;
            Item.defense = 80;
            Item.width = 26;
			Item.height = 32;
			Item.value = Item.buyPrice(gold: 48, silver: 95);

            if (AstralAddonMod.Instance.calamity != null && AstralAddonMod.Instance.calamity.TryFind("PureGreen", out ModRarity PureGreen))
            {
                Item.rare = PureGreen.Type;
            }
            else
            {
                Item.rare = ItemRarityID.Purple;
            }
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient<summonneck1>(1);

            // Use calamity ingredients unless the mod is not present
            if (AstralAddonMod.Instance.calamity != null && AstralAddonMod.Instance.calamity.TryFind("UelibloomBar", out ModItem UelibloomBar) && AstralAddonMod.Instance.calamity.TryFind("RuinousSoul", out ModItem RuinousSoul))
            {
                recipe.AddIngredient(UelibloomBar.Type, 10);
                recipe.AddIngredient(RuinousSoul.Type, 5);
            }
            else
            {
                recipe.AddIngredient(ItemID.LunarBar, 10);
                recipe.AddIngredient(ItemID.FragmentStardust, 99);
            }

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
