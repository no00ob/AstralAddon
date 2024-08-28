﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using AstralAddon.Items.Ores;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class WoodriteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("This is a Woodrite Helmet."
            //    + "\n10% increased ranged damage"
            //    + "\n5% increased minion damage");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 200;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 2;
            Item.maxStack = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) *= 1.1f;
            player.GetDamage(DamageClass.Summon) *= 1.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WoodriteBreastplate>() && legs.type == ModContent.ItemType<WoodriteLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 max minions";
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<WoodriteBar>(20);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }
    }
}