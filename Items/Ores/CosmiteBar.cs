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
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(15, 8));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.value = 14000;
            item.rare = ItemRarityID.Red;
            CustomRarity = 101;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CosmiteOre>(), 4);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.PaleVioletRed.ToVector3() * 0.55f * Main.essScale);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    float fade = Main.GameUpdateCount % 60 / 60f;
                    int index = (int)(Main.GameUpdateCount / 60 % 4);
                    line2.overrideColor = Color.Lerp(BaseColor.Cosmite[index], BaseColor.Cosmite[(index + 1) % 4], fade);
                }
            }
        }
    }
}
