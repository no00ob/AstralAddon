using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AstralAddon.Items.Ores;
using AstralAddon.Items.Materials;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ToyGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'A kids size.'");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 9000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
            Item.maxStack = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
        }

        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe(ItemID.LavaBucket);
            recipe.AddIngredient(ModContent.ItemType<Plastic>(), 20);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.Register();
        }
    }
}