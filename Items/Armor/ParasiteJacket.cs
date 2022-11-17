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
            Item.width = 30;
            Item.height = 24;
            Item.value = Item.sellPrice(0,0,20,0);
            Item.rare = ItemRarityID.Red;
            CustomRarity = 102;
            Item.vanity = true;
        }

        public override bool DrawBody()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true if you returned false */
        {
            return false; // Stop the body from being drawn underneath the clothes
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false if you had drawHands set to true. If you had drawArms set to true, you don't need to do anything */
        {
            drawArms = true; // Wether to show the hands and arms
            drawHands = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
		// Custom Rarity/Name Color
        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    float fade = Main.GameUpdateCount % 60 / 60f;
                    int index = (int)(Main.GameUpdateCount / 60 % 4);
                    line2.OverrideColor = Color.Lerp(BaseColor.DiTF[index], BaseColor.DiTF[(index + 1) % 4], fade);
                }
            }
        }
    }
}