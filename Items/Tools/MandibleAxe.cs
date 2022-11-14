using Terraria.ID;
using Terraria.ModLoader;

namespace Thumod.Items.Tools
{
    public class MandibleAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An axe made out of antlion mandibles.");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.melee = true;
            item.width = 46;
            item.height = 44;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.axe = 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(null, "SandPickaxe");
            recipe.AddIngredient(ItemID.HardenedSand, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
