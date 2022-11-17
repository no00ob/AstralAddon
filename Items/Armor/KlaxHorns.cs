using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class KlaxHorns : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("'Darling'");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 16;
            Item.value = 2000;
            Item.value = Item.sellPrice(0,0,20,0);
            Item.rare = ItemRarityID.Red;
            CustomRarity = 102;
            Item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true if you had drawHair set to true, and ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true if you had drawAltHair set to true */
        {
            drawHair = true;  // wether or not to show the players hair or the short alternative hair used under hats or no hair?
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