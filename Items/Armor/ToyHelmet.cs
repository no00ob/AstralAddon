using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using AstralAddon.Items.Ores;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ToyHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'A kids size.'");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 6000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
            Item.maxStack = 1;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ToyChainmail>() && legs.type == ModContent.ItemType<ToyGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+4 defense";
            player.statDefense += 20;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(ItemID.LavaBucket);
            recipe.AddIngredient(ModContent.ItemType<Plastic>(), 15);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}