using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Ores
{
    public class CosmiteBar : CustomModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Cosmite Bar");
            Tooltip.SetDefault("'Cosmic steel imbued with celestial essence'");
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
            CustomRarity = 101;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CosmiteOre>(), 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.PaleVioletRed.ToVector3() * 0.55f * Main.essScale);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    float fade = Main.GameUpdateCount % 60 / 60f;
                    int index = (int)(Main.GameUpdateCount / 60 % 4);
                    line2.OverrideColor = Color.Lerp(BaseColor.Cosmite[index], BaseColor.Cosmite[(index + 1) % 4], fade);
                }
            }
        }
    }
}
