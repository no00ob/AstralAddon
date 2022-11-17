using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ParasiteLeggings : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("'Darling'");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.value = Item.sellPrice(0,0,20,0);
            Item.rare = ItemRarityID.Red;
            CustomRarity = 102;
            Item.vanity = true;
        }

        public override bool DrawLegs()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true if you returned false for an accessory of EquipType.Legs, and ArmorIDs.Shoe.Sets.OverridesLegs[Item.shoeSlot] = true if you returned false for an accessory of EquipType.Shoes */
        {
            return false; // Wether to show the legs underneath the pants usually false
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