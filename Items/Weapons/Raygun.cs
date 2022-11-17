using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class Raygun : CustomModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Where's this thing keep 160 rounds?'");
        }

        public override void SetDefaults()
        {
            Item.damage = 350;
            Item.DamageType = DamageClass.Magic;
            Item.width = 46;
            Item.height = 30;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 2;
            Item.value = 42000;
            Item.rare = ItemRarityID.Red;
            CustomRarity = 14;
            Item.UseSound = SoundID.Item114;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.HeatRay; //idk why but all the guns in the vanilla source have this
            Item.mana = 35;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3f, 1f);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.OverrideColor = BaseColor.DarkBlue;
                }
            }
        }
    }
}
