using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class MalorianArms : CustomModItem
    {
        public override void SetDefaults()
        {
            CalculateStats();
            item.ranged = true;
            item.width = 56;
            item.height = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
            item.useAmmo = AmmoID.Bullet;
        }

        public override void PostUpdate()
        {
            CalculateStats();
        }

        public override void UpdateInventory(Player player)
        {
            CalculateStats();
            base.UpdateInventory(player);
        }

        public void CalculateStats()
        {
            if (Main.gameMenu)
                return;

            if (NPC.downedMoonlord)
            {
                item.damage = 875;
                item.knockBack = 8;
                item.crit = 36;
                item.rare = ItemRarityID.Red;
                item.value = Item.sellPrice(1, 2, 15, 0);
                item.autoReuse = true;
                item.useTime = 20;
                item.useAnimation = 20;
                item.shootSpeed = 5.75f;
                item.UseSound = SoundID.Item38;

                if (AstralVoyageWorld.MalorianArmsUpgrades[4] == false)
                {
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 6!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[4] = true;
                }
            }
            else if (NPC.downedAncientCultist)
            {
                item.damage = 582;
                item.knockBack = 7.5f;
                item.crit = 31;
                item.rare = ItemRarityID.Cyan;
                item.value = Item.sellPrice(0, 72, 88, 0);
                item.autoReuse = true;
                item.useTime = 20;
                item.useAnimation = 20;
                item.shootSpeed = 6f;
                item.UseSound = SoundID.Item38;

                if (AstralVoyageWorld.MalorianArmsUpgrades[3] == false)
                {
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 5!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[3] = true;
                }
            }
            else if (NPC.downedPlantBoss)
            {
                item.damage = 312;
                item.knockBack = 7;
                item.crit = 21;
                item.rare = ItemRarityID.Lime;
                item.value = Item.sellPrice(0, 45, 67, 0);
                item.autoReuse = false;
                item.useTime = 25;
                item.useAnimation = 25;
                item.shootSpeed = 6.5f;
                item.UseSound = SoundID.Item40;

                if (AstralVoyageWorld.MalorianArmsUpgrades[2] == false)
                {
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 4!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[2] = true;
                }
            }
            else if (Main.hardMode)
            {
                item.damage = 182;
                item.knockBack = 6;
                item.crit = 16;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(0, 26, 75, 0);
                item.autoReuse = false;
                item.useTime = 25;
                item.useAnimation = 25;
                item.shootSpeed = 6.5f;
                item.UseSound = SoundID.Item40;

                if (AstralVoyageWorld.MalorianArmsUpgrades[1] == false)
                {
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 3!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[1] = true;
                }
            }
            else if (NPC.downedQueenBee)
            {
                item.damage = 126;
                item.knockBack = 5;
                item.crit = 11;
                item.rare = ItemRarityID.Orange;
                item.value = Item.sellPrice(0, 16, 88, 0);
                item.autoReuse = false;
                item.useTime = 30;
                item.useAnimation = 30;
                item.shootSpeed = 8f;
                item.UseSound = SoundID.Item41;

                if (AstralVoyageWorld.MalorianArmsUpgrades[0] == false)
                {
                    Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 2!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[0] = true;
                }
            }
            else
            {
                item.damage = 82;
                item.knockBack = 4.5f;
                item.crit = 6;
                item.rare = ItemRarityID.Green;
                item.value = Item.sellPrice(0, 8, 22, 0);
                item.autoReuse = false;
                item.useTime = 30;
                item.useAnimation = 30;
                item.shootSpeed = 8f;
                item.UseSound = SoundID.Item11;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(mod, "", "");

            if (NPC.downedMoonlord)
            {
                line = new TooltipLine(mod, "Level6", "Weapon Level 6")
                {
                    overrideColor = new Color(213, 14, 72)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats6", "88% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("5"));
            }
            else if (NPC.downedAncientCultist)
            {
                line = new TooltipLine(mod, "Level5", "Weapon Level 5")
                {
                    overrideColor = new Color(28, 187, 229)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats5", "66% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("4"));
            }
            else if (NPC.downedPlantBoss)
            {
                line = new TooltipLine(mod, "Level4", "Weapon Level 4")
                {
                    overrideColor = new Color(149, 227, 44)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats4", "55% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("3"));
            }
            else if (Main.hardMode)
            {
                line = new TooltipLine(mod, "Level3", "Weapon Level 3")
                {
                    overrideColor = new Color(235, 158, 225)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats3", "44% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("2"));
            }
            else if (NPC.downedQueenBee)
            {
                line = new TooltipLine(mod, "Level2", "Weapon Level 2")
                {
                    overrideColor = new Color(225, 187, 152)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats2", "33% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("0"));
            }
            else
            {
                line = new TooltipLine(mod, "Level0", "Weapon Level 1")
                {
                    overrideColor = new Color(157, 238, 159)
                };
                tooltips.Add(line);
                line = new TooltipLine(mod, "Stats0", "22% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}
