using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Accessories
{
    public class WorkerEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'Has a terrible vibe to it.'"
            //   + "\n10% increased meelee stats"
            //    + "\n8% increased movement speed"
            //    + "\n5% increased mining speed");
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 14;
            Item.value = 10;
            Item.rare = 3;
            Item.accessory = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(null, "BrassSickle");
            recipe.AddIngredient(null, "BrassHammer");
            recipe.AddIngredient(ItemID.GoldCoin, 10);   //you need 10 Gold coins
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.GetCritChance(DamageClass.Generic) += 10;
            player.GetDamage(DamageClass.Melee) += 0.10f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
            player.moveSpeed += 0.10f;
        }
    }
}