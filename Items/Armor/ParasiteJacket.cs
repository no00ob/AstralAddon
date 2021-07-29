using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ParasiteJacket : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("'Darling'");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = Item.sellPrice(0,0,20,0);
            item.rare = ItemRarityID.Red;
            CustomRarity = 102;
            item.vanity = true;
        }

        public override bool DrawBody()
        {
            return false; // Stop the body from being drawn underneath the clothes
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawArms = true; // Wether to show the hands and arms
            drawHands = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		// Custom Rarity/Name Color
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    float fade = Main.GameUpdateCount % 60 / 60f;
                    int index = (int)(Main.GameUpdateCount / 60 % 4);
                    line2.overrideColor = Color.Lerp(BaseColor.DiTF[index], BaseColor.DiTF[(index + 1) % 4], fade);
                }
            }
        }
    }
}