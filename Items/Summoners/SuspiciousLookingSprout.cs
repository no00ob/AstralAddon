using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Summoners
{
    public class SuspiciousLookingSprout : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Summons the Living Tree");  
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 10;
            Item.rare = 1;
            Item.maxStack = 10;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 4;
            Item.consumable = true;
        }
        /*public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("LivingTree").Type);  //you can't spawn this boss multiple times
            return !Main.dayTime;   //can use only at night
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        /*{
            NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("LivingTree").Type);   //boss spawn
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }*/
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddIngredient(null, "Sapling");
            recipe.Register();
        }
    }
}
