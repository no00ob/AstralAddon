using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TrueCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Vanity Item"
                + "\n'This is the true crown of roalty'");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 23;
            Item.value = 10000;
            Item.rare = 7;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Ruby, 3);
            recipe.AddIngredient(ItemID.LargeRuby, 1);
            recipe.AddTile(TileID.Anvils);   //at anvil
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumCrown, 1);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddIngredient(ItemID.Ruby, 3);
            recipe.AddIngredient(ItemID.LargeRuby, 1);
            recipe.AddTile(TileID.Anvils);   //at anvil
            recipe.Register();
        }
    }
}