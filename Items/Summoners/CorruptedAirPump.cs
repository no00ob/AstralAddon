using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.NPCs.Boss;

namespace AstralAddon.Items.Summoners
{
    public class CorruptedAirPump : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Summons the Corrupted Balloon\n'For all those times you didn't find a red balloon'");  //The (English) text shown below your weapon's name
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 10;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 10;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }
        /*public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<CorruptedBalloon>()) && !Main.dayTime;   //can use only at night
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        /*{
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<CorruptedBalloon>());   //boss spawn
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }*/
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.VilePowder, 30);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
