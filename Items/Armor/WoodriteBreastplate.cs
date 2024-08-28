using AstralAddon.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class WoodriteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //base.SetStaticDefaults();
            //Tooltip.SetDefault("This is a Woodrite Breastplate."
            //    + "\n10% increased minion damage"
            //    + "\n+1 max minions");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 300;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 3;
            Item.maxStack = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) *= 1.1f;
            player.maxMinions++;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<WoodriteBar>(30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}