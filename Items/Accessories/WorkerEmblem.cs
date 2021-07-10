using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Accessories
{
    public class WorkerEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Has a terrible vibe to it.'"
                + "\n10% increased meelee stats"
                + "\n8% increased movement speed"
                + "\n5% increased mining speed");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 14;
            item.value = 10;
            item.rare = 3;
            item.accessory = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BrassSickle");
            recipe.AddIngredient(null, "BrassHammer");
            recipe.AddIngredient(ItemID.GoldCoin, 10);   //you need 10 Gold coins
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.meleeCrit += 10;
            player.meleeDamage += 0.10f;
            player.meleeSpeed += 0.10f;
            player.moveSpeed += 0.10f;
        }
    }
}