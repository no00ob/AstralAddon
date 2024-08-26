using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class KlaxHorns : ModItem
    {
        public override void SetStaticDefaults()
        {
            //base.SetStaticDefaults();
            //Tooltip.SetDefault("'Darling'");
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 16;
            Item.value = 2000;
            Item.value = Item.sellPrice(0,0,20,0);
            Item.rare = ItemRarityID.Red;
            Item.vanity = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.Register();
        }
    }
}