﻿using Terraria;
using Terraria.Audio;
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
            Item.width = 34;
            Item.height = 34;
            Item.value = 10;
            Item.rare = 1;
            Item.maxStack = 10;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 4;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("TheEaterOfCosmos_Head").Type);  //you can't spawn this boss multiple times
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("TheEaterOfCosmos_Head").Type);   //boss spawn
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.LunarBar, 3);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
