using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Summoners
{
    public class SuspiciousLookingSprout : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons the Living Tree");  
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
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
            return !NPC.AnyNPCs(mod.NPCType("LivingTree"));  //you can't spawn this boss multiple times
            return !Main.dayTime;   //can use only at night
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("LivingTree"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddIngredient(null, "Sapling");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
