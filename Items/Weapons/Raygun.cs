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
            item.damage = 350;
            item.magic = true;
            item.width = 46;
            item.height = 30;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 42000;
            item.rare = ItemRarityID.Red;
            CustomRarity = 14;
            item.UseSound = SoundID.Item114;
            item.autoReuse = true;
            item.shoot = ProjectileID.HeatRay; //idk why but all the guns in the vanilla source have this
            item.mana = 35;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3f, 1f);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = BaseColor.DarkBlue;
                }
            }
        }
    }
}
