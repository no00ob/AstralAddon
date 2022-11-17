using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AstralVoyage.Items.Weapons
{
    public class MalorianArms : CustomModItem
    {
        public override void SetDefaults()
        {
            CalculateStats();
            Item.DamageType = DamageClass.Ranged;
            Item.width = 56;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this
            Item.useAmmo = AmmoID.Bullet;
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
                Item.damage = 875;
                Item.knockBack = 8;
                Item.crit = 36;
                Item.rare = ItemRarityID.Red;
                Item.value = Item.sellPrice(1, 2, 15, 0);
                Item.autoReuse = true;
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.shootSpeed = 5.75f;
                Item.UseSound = SoundID.Item38;

                if (AstralVoyageWorld.MalorianArmsUpgrades[4] == false)
                {
                    SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 6!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[4] = true;
                }
            }
            else if (NPC.downedAncientCultist)
            {
                Item.damage = 582;
                Item.knockBack = 7.5f;
                Item.crit = 31;
                Item.rare = ItemRarityID.Cyan;
                Item.value = Item.sellPrice(0, 72, 88, 0);
                Item.autoReuse = true;
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.shootSpeed = 6f;
                Item.UseSound = SoundID.Item38;

                if (AstralVoyageWorld.MalorianArmsUpgrades[3] == false)
                {
                    SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 5!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[3] = true;
                }
            }
            else if (NPC.downedPlantBoss)
            {
                Item.damage = 312;
                Item.knockBack = 7;
                Item.crit = 21;
                Item.rare = ItemRarityID.Lime;
                Item.value = Item.sellPrice(0, 45, 67, 0);
                Item.autoReuse = false;
                Item.useTime = 25;
                Item.useAnimation = 25;
                Item.shootSpeed = 6.5f;
                Item.UseSound = SoundID.Item40;

                if (AstralVoyageWorld.MalorianArmsUpgrades[2] == false)
                {
                    SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 4!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[2] = true;
                }
            }
            else if (Main.hardMode)
            {
                Item.damage = 182;
                Item.knockBack = 6;
                Item.crit = 16;
                Item.rare = ItemRarityID.Pink;
                Item.value = Item.sellPrice(0, 26, 75, 0);
                Item.autoReuse = false;
                Item.useTime = 25;
                Item.useAnimation = 25;
                Item.shootSpeed = 6.5f;
                Item.UseSound = SoundID.Item40;

                if (AstralVoyageWorld.MalorianArmsUpgrades[1] == false)
                {
                    SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 3!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[1] = true;
                }
            }
            else if (NPC.downedQueenBee)
            {
                Item.damage = 126;
                Item.knockBack = 5;
                Item.crit = 11;
                Item.rare = ItemRarityID.Orange;
                Item.value = Item.sellPrice(0, 16, 88, 0);
                Item.autoReuse = false;
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.shootSpeed = 8f;
                Item.UseSound = SoundID.Item41;

                if (AstralVoyageWorld.MalorianArmsUpgrades[0] == false)
                {
                    SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/upgrade"));
                    Main.NewText("Weapon has reached level 2!", 205, 130, 65);
                    AstralVoyageWorld.MalorianArmsUpgrades[0] = true;
                }
            }
            else
            {
                Item.damage = 82;
                Item.knockBack = 4.5f;
                Item.crit = 6;
                Item.rare = ItemRarityID.Green;
                Item.value = Item.sellPrice(0, 8, 22, 0);
                Item.autoReuse = false;
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.shootSpeed = 8f;
                Item.UseSound = SoundID.Item11;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "", "");

            if (NPC.downedMoonlord)
            {
                line = new TooltipLine(Mod, "Level6", "Weapon Level 6")
                {
                    OverrideColor = new Color(213, 14, 72)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats6", "88% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("5"));
            }
            else if (NPC.downedAncientCultist)
            {
                line = new TooltipLine(Mod, "Level5", "Weapon Level 5")
                {
                    OverrideColor = new Color(28, 187, 229)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats5", "66% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("4"));
            }
            else if (NPC.downedPlantBoss)
            {
                line = new TooltipLine(Mod, "Level4", "Weapon Level 4")
                {
                    OverrideColor = new Color(149, 227, 44)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats4", "55% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("3"));
            }
            else if (Main.hardMode)
            {
                line = new TooltipLine(Mod, "Level3", "Weapon Level 3")
                {
                    OverrideColor = new Color(235, 158, 225)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats3", "44% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("2"));
            }
            else if (NPC.downedQueenBee)
            {
                line = new TooltipLine(Mod, "Level2", "Weapon Level 2")
                {
                    OverrideColor = new Color(225, 187, 152)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats2", "33% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
                tooltips.RemoveAll(l => l.Name.EndsWith("0"));
            }
            else
            {
                line = new TooltipLine(Mod, "Level0", "Weapon Level 1")
                {
                    OverrideColor = new Color(157, 238, 159)
                };
                tooltips.Add(line);
                line = new TooltipLine(Mod, "Stats0", "22% Chance not to consume ammo\n'Gun to keep the fans in their pants'");
                tooltips.Add(line);
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
