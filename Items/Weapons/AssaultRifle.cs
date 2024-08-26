using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralAddon.Items.Weapons
{
    public class AssaultRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'This is a nice lookin' weapon'");  
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 58;
            Item.height = 20;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5;
            Item.value = 1000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 10; //idk why but all the guns in the vanilla source have this
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyIronBar", 4);
            recipe.AddIngredient(ItemID.TheUndertaker, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.Musket, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 18);
            recipe.AddIngredient(null, "ShinyLeadBar", 4);
            recipe.AddIngredient(ItemID.TheUndertaker, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
