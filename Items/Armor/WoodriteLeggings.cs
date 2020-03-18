using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class WoodriteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a Woodrite Helmet."
                + "\n5% increased ranged damage"
                + "\n5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 250;
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
            player.rangedDamage *= 1.05f;
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WoodriteBar", 25);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}