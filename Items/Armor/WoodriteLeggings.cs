using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class WoodriteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("This is a Woodrite Helmet."
            //    + "\n5% increased ranged damage"
            //    + "\n5% increased movement speed");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 250;
            Item.rare = 1;
            Item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
            player.GetDamage(DamageClass.Ranged) *= 1.05f;
        }

        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "WoodriteBar", 25);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }
    }
}