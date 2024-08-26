using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ParasiteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            //base.SetStaticDefaults();
            //Tooltip.SetDefault("'Darling'");
            ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.value = Item.sellPrice(0,0,20,0);
            Item.rare = ItemRarityID.Red;
            Item.vanity = true;
        }

        //public override bool DrawLegs()/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Legs.Sets.HidesBottomSkin[Item.legSlot] = true if you returned false for an accessory of EquipType.Legs, and ArmorIDs.Shoe.Sets.OverridesLegs[Item.shoeSlot] = true if you returned false for an accessory of EquipType.Shoes */
        /*{
            return false; // Wether to show the legs underneath the pants usually false
        }*/

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}