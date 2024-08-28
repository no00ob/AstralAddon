using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Ores
{
    public class ElectropeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
			//DisplayName.SetDefault("Cosmite Bar");
            //Tooltip.SetDefault("'Cosmic steel imbued with celestial essence'");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(15, 8));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.value = 14000;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElectropeOre>(), 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.PaleVioletRed.ToVector3() * 0.55f * Main.essScale);
        }
    }
}
