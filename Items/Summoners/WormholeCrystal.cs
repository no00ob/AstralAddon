using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Summoners
{
    public class WormholeCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wormhole Pendant");
            Tooltip.SetDefault("Summons Astrum Vermis");  
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = 10;
            item.rare = 1;
            item.maxStack = 10;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("TheEaterOfCosmos_Head"));  //you can't spawn this boss multiple times
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheEaterOfCosmos_Head"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
