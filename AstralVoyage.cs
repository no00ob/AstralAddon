using AstralVoyage.Items;
using AstralVoyage.Items.Accessories;
using AstralVoyage.Items.Ores;
using AstralVoyage.Items.Tiles;
using AstralVoyage.NPCs.EoC;
using AstralVoyage.NPCs.LT;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AstralVoyage
{
	class AstralVoyage : Mod
	{
        public static bool calamityMode;

		public AstralVoyage()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
			};
        }

        public override void Load()
        {
            for (int k = 1; k <= 4; k++)
            {
                Main.instance.LoadTiles(TileID.Loom);
                Main.tileTexture[TileID.Loom] = GetTexture("Tiles/AnimatedLoom");
                // What if....Replace a vanilla item texture and equip texture.
                //Main.itemTexture[ItemID.CopperHelmet] = GetTexture("Resprite/CopperHelmet_Item");
                //Item copperHelmet = new Item();
                //copperHelmet.SetDefaults(ItemID.CopperHelmet);
                //Main.armorHeadLoaded[copperHelmet.headSlot] = true;
                //Main.armorHeadTexture[copperHelmet.headSlot] = GetTexture("Resprite/CopperHelmet_Head");
            }

            if (ModLoader.GetMod("CalamityMod") != null)
            {
                calamityMode = true;
            }
            else
            {
                calamityMode = false;
            }
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                return;

            if (Main.LocalPlayer.GetModPlayer<AstralVoyagePlayer>().ZoneAncient)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/ancient");
                priority = MusicPriority.Environment;
            }

            if (LivingTree.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/fight3");
                priority = MusicPriority.BossLow;
            }

            if (TheEaterOfCosmos_Head.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/boss3");
                priority = MusicPriority.BossMedium;
            }
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // To include a description:
                bossChecklist.Call("AddBossWithInfo", "Astrum Vermis", 15.999f, (Func<bool>)(() => AstralVoyageWorld.downedEaterOfCosmos), "Use a [i:" + ItemType("WormholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Living Tree", 1.001f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("SuspiciousLookingSprout") + "] at night in a forest biome.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Bellatur", 15.998f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("BlackholeCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Magus", 15.997f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + ItemType("CometCrystal") + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Voyager", 17.998f, (Func<bool>)(() => AstralVoyageWorld.downedVoyager), "Use a [i:" + ItemType("AnomaliousMatter") + "] after beating the three cosmic guardians at any given time, any where.");
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            if (AstralVoyageWorld.ancientParadiseTiles <= 0)
            {
                return;
            }

            float ancientStrength = AstralVoyageWorld.ancientParadiseTiles / 200f;
            ancientStrength = Math.Min(ancientStrength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            // Remove some green and more red.
            sunR -= (int)(15f * ancientStrength * (backgroundColor.R / 255f));
            sunG -= (int)(5f * ancientStrength * (backgroundColor.G / 255f));
            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Ice Block", new int[]
            {
                ItemID.IceBlock,
                ItemID.PinkIceBlock,
                ItemID.PurpleIceBlock,
                ItemID.RedIceBlock
            });
            RecipeGroup.RegisterGroup("AstralVoyage:IceBlocks", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Powder", new int[]
            {
                ItemID.VilePowder,
                ItemID.ViciousPowder
            });
            RecipeGroup.RegisterGroup("AstralVoyage:EvilPowders", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cobalt Bar", new int[]
            {
                ItemID.CobaltBar,
                ItemID.PalladiumBar
            });
            RecipeGroup.RegisterGroup("AstralVoyage:CobaltBars", group);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);

            if (!calamityMode)
            {
                // Magic Quiver
                recipe.AddIngredient(ItemID.EndlessQuiver);
                recipe.AddIngredient(ItemID.PixieDust, 10);
                recipe.AddIngredient(ItemID.Lens, 5);
                recipe.AddIngredient(ItemID.SoulofLight, 8);
                recipe.SetResult(ItemID.MagicQuiver, 1);
                recipe.AddTile(TileID.CrystalBall);
                recipe.AddRecipe();
                // Guide Voodoo Doll
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Leather, 2);
                recipe.AddRecipeGroup("AstralVoyage:EvilPowders", 10);
                recipe.SetResult(ItemID.GuideVoodooDoll, 1);
                recipe.AddTile(TileID.DemonAltar);
                recipe.AddRecipe();
                // Ice Skates
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.Leather, 5);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.IceSkates, 1);
                recipe.AddTile(TileID.IceMachine);
                recipe.AddRecipe();
                // Aglet
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.Aglet, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Anklet of the Wind
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.AddIngredient(ItemID.Cloud, 15);
                recipe.AddIngredient(ItemID.PinkGel, 5);
                recipe.SetResult(ItemID.AnkletoftheWind, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Bezoar
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Stinger, 15);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.SetResult(ItemID.Bezoar, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Blizzard in a Bottle
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Feather, 4);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.SnowBlock, 50);
                recipe.SetResult(ItemID.BlizzardinaBottle, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Cloud in a Bottle
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Feather, 2);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.Cloud, 25);
                recipe.SetResult(ItemID.CloudinaBottle, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Feral Claws
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Leather, 10);
                recipe.AddIngredient(ItemID.Vine, 3);
                recipe.SetResult(ItemID.FeralClaws, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Frog Leg
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Frog, 10);
                recipe.SetResult(ItemID.FrogLeg, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Lava Charm
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.LavaBucket, 5);
                recipe.AddIngredient(ItemID.Obsidian, 25);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.LavaCharm, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Lucky Horseshoe
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 10);
                recipe.AddIngredient(ItemID.GoldBar, 5);
                recipe.SetResult(ItemID.LuckyHorseshoe, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 10);
                recipe.AddIngredient(ItemID.PlatinumBar, 5);
                recipe.SetResult(ItemID.LuckyHorseshoe, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Obsidian Rose
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.JungleRose, 1);
                recipe.AddIngredient(ItemID.Obsidian, 10);
                recipe.AddIngredient(ItemID.Hellstone, 10);
                recipe.SetResult(ItemID.ObsidianRose, 1);
                recipe.AddTile(TileID.Hellforge);
                recipe.AddRecipe();
                // Radar
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.Radar, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Sandstorm in a Bottle
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Feather, 6);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.SandBlock, 70);
                recipe.SetResult(ItemID.SandstorminaBottle, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Water Walking Boots
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.WaterWalkingPotion, 8);
                recipe.AddIngredient(ItemID.Leather, 5);
                recipe.SetResult(ItemID.WaterWalkingBoots, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Flower Boots
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 7);
                recipe.AddIngredient(ItemID.JungleRose, 1);
                recipe.AddIngredient(ItemID.JungleGrassSeeds, 5);
                recipe.SetResult(ItemID.FlowerBoots, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Hand Warmer
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 5);
                recipe.AddIngredient(ItemID.Shiverthorn, 1);
                recipe.AddIngredient(ItemID.SnowBlock, 10);
                recipe.SetResult(ItemID.HandWarmer, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Hermes Boots
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddIngredient(ItemID.SwiftnessPotion, 8);
                recipe.SetResult(ItemID.HermesBoots, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Adhesive Bandage
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddIngredient(ItemID.Gel, 50);
                recipe.AddIngredient(ItemID.GreaterHealingPotion, 1);
                recipe.SetResult(ItemID.AdhesiveBandage, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Adhesive Bandage
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Bone, 50);
                recipe.AddIngredient(ItemID.Gel, 25);
                recipe.AddIngredient(ModContent.ItemType<Polish>(), 3);
                recipe.SetResult(ItemID.ArmorPolish, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Blindfold
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 30);
                recipe.AddIngredient(ItemID.SoulofNight, 5);
                recipe.SetResult(ItemID.Blindfold, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Celestial Magnet
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.FallenStar, 20);
                recipe.AddIngredient(ItemID.SoulofMight, 10);
                recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.AddIngredient(ItemID.SoulofNight, 5);
                recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 3);
                recipe.SetResult(ItemID.CelestialMagnet, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Cobalt Shield
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:CobaltBars", 10);
                recipe.SetResult(ItemID.CobaltShield, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Fast Clock
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Timer1Second, 1);
                recipe.AddIngredient(ItemID.PixieDust, 15);
                recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.SetResult(ItemID.FastClock, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Flying Carpet
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.AncientCloth, 10);
                recipe.AddIngredient(ItemID.SoulofNight, 10);
                recipe.AddIngredient(ItemID.SoulofLight, 10);
                recipe.SetResult(ItemID.FlyingCarpet, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Frozen Turtle Shell
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.TurtleShell, 3);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 50);
                recipe.SetResult(ItemID.FrozenTurtleShell, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Megaphone
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Wire, 10);
                recipe.AddIngredient(ItemID.HallowedBar, 5);
                recipe.AddIngredient(ItemID.Ruby, 3);
                recipe.SetResult(ItemID.Megaphone, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Metal Detector
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Wire, 10);
                recipe.AddIngredient(ItemID.GoldDust, 5);
                recipe.AddIngredient(ItemID.SpelunkerGlowstick, 5);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.MetalDetector, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Nazar
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SoulofNight, 20);
                recipe.AddIngredient(ItemID.Lens, 5);
                recipe.SetResult(ItemID.Nazar, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Trifold Map
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddIngredient(ItemID.SoulofLight, 3);
                recipe.AddIngredient(ItemID.SoulofNight, 3);
                recipe.SetResult(ItemID.TrifoldMap, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Vitamins
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.BottledWater, 1);
                recipe.AddIngredient(ItemID.Waterleaf, 5);
                recipe.AddIngredient(ItemID.Blinkroot, 5);
                recipe.AddIngredient(ItemID.Daybloom, 5);
                recipe.AddIngredient(ModContent.ItemType<ZincOre>(), 3);
                recipe.SetResult(ItemID.Vitamins, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Shiny Red Balloon
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Gel, 80);
                recipe.AddIngredient(ItemID.Cloud, 40);
                recipe.AddIngredient(ItemID.WhiteString, 1);
                recipe.SetResult(ItemID.ShinyRedBalloon, 1);
                recipe.AddTile(TileID.Solidifier);
                recipe.AddRecipe();
                // Rocket I
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.EmptyBullet, 20);
                recipe.AddIngredient(ItemID.ExplosivePowder, 1);
                recipe.SetResult(ItemID.RocketI, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Eskimo Coat
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 8);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 18);
                recipe.SetResult(ItemID.EskimoCoat, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Eskimo Hood
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 4);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 12);
                recipe.SetResult(ItemID.EskimoHood, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Eskimo Pants
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Silk, 6);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 15);
                recipe.SetResult(ItemID.EskimoPants, 1);
                recipe.AddTile(TileID.Loom);
                recipe.AddRecipe();
                // Truffle Worm
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Worm, 1);
                recipe.AddIngredient(ItemID.GlowingMushroom, 15);
                recipe.SetResult(ItemID.TruffleWorm, 1);
                recipe.AddTile(TileID.Autohammer);
                recipe.AddRecipe();
                // Life Crystal
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Bone, 5);
                recipe.AddIngredient(ItemID.PinkGel, 1);
                recipe.AddIngredient(ItemID.HealingPotion, 1);
                recipe.AddIngredient(ItemID.Ruby, 1);
                recipe.SetResult(ItemID.LifeCrystal, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Lizhard Power Cell
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Glass, 5);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddIngredient(ItemID.LihzahrdBrick, 15);
                recipe.SetResult(ItemID.LihzahrdPowerCell, 1);
                recipe.AddTile(TileID.LihzahrdFurnace);
                recipe.AddRecipe();
                // Temple Key
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.AddIngredient(ItemID.RichMahogany, 15);
                recipe.AddIngredient(ItemID.SoulofNight, 15);
                recipe.AddIngredient(ItemID.SoulofLight, 15);
                recipe.SetResult(ItemID.TempleKey, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Black Lens
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Lens, 1);
                recipe.AddIngredient(ItemID.BlackDye, 1);
                recipe.SetResult(ItemID.BlackLens, 1);
                recipe.AddTile(TileID.DyeVat);
                recipe.AddRecipe();
                // Leather
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Vertebrae, 5);
                recipe.SetResult(ItemID.Leather, 1);
                recipe.AddTile(TileID.WorkBenches);
                recipe.AddRecipe();
                // Ice Machine
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 25);
                recipe.AddIngredient(ItemID.SnowBlock, 15);
                recipe.AddRecipeGroup("IronBar", 3);
                recipe.SetResult(ItemID.IceMachine, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Sky Mill
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 5);
                recipe.AddIngredient(ItemID.RainCloud, 3);
                recipe.SetResult(ItemID.SkyMill, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Glass
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ModContent.ItemType<DivineSand>(), 2);
                recipe.SetResult(ItemID.Glass, 1);
                recipe.AddTile(TileID.Furnaces);
                recipe.AddRecipe();
                // Bug Net
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("IronBar", 3);
                recipe.AddIngredient(ItemID.Cobweb, 30);
                recipe.SetResult(ItemID.BugNet, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Ice Mirror
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.Glass, 10);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.SetResult(ItemID.IceMirror, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Magic Mirror
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.Glass, 10);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddRecipeGroup("IronBar", 10);
                recipe.SetResult(ItemID.MagicMirror, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Shadow Key
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.GoldenKey, 1);
                recipe.AddIngredient(ItemID.Obsidian, 20);
                recipe.AddIngredient(ItemID.Bone, 5);
                recipe.SetResult(ItemID.ShadowKey, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Rod of Discord
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SoulofLight, 30);
                recipe.AddIngredient(ItemID.ChaosFish, 5);
                recipe.AddIngredient(ItemID.PixieDust, 50);
                recipe.SetResult(ItemID.RodofDiscord, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Water Bolt
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ItemID.SpellTome, 1);
                recipe.AddIngredient(ItemID.Waterleaf, 3);
                recipe.AddIngredient(ItemID.WaterCandle, 1);
                recipe.SetResult(ItemID.WaterBolt, 1);
                recipe.AddTile(TileID.Bookcases);
                recipe.AddRecipe();
                // Ice Boomerang
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.SnowBlock, 10);
                recipe.AddIngredient(ItemID.Shiverthorn, 1);
                recipe.SetResult(ItemID.IceBoomerang, 1);
                recipe.AddTile(TileID.IceMachine);
                recipe.AddRecipe();
                // Shuriken
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("IronBar", 1);
                recipe.SetResult(ItemID.Shuriken, 50);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Slime Staff
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("Wood", 6);
                recipe.AddIngredient(ItemID.Gel, 40);
                recipe.AddIngredient(ItemID.PinkGel, 10);
                recipe.SetResult(ItemID.SlimeStaff, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Shuriken
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("IronBar", 1);
                recipe.AddRecipeGroup("Wood", 1);
                recipe.SetResult(ItemID.ThrowingKnife, 50);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Wand of Sparkling
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("Wood", 5);
                recipe.AddIngredient(ItemID.Torch, 3);
                recipe.AddIngredient(ItemID.FallenStar, 1);
                recipe.SetResult(ItemID.WandofSparking, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.AddRecipe();
                // Enchanted Sword
                recipe = new ModRecipe(this);
                recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 5);
                recipe.AddIngredient(ItemID.SoulofLight, 15);
                recipe.AddIngredient(ItemID.UnicornHorn, 3);
                recipe.AddIngredient(ItemID.LightShard, 1);
                recipe.SetResult(ItemID.EnchantedSword, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
                // Muramasa
                recipe = new ModRecipe(this);
                recipe.AddRecipeGroup("AstralVoyage:CobaltBars", 15);
                recipe.SetResult(ItemID.Muramasa, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.AddRecipe();
            }

            // Avenger Emblem
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<ThrowerEmblem>(), 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.SetResult(ItemID.AvengerEmblem, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddRecipe();
            // Frost Breastplate
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.SetResult(ItemID.FrostBreastplate, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.AddRecipe();
            // Frost Helmet
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 6);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.SetResult(ItemID.FrostHelmet, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.AddRecipe();
            // Frost Leggings
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 8);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.SetResult(ItemID.FrostLeggings, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.AddRecipe();
            // Starfury
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<WoodriteBar>(), 3);
            recipe.SetResult(ItemID.Starfury, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<WoodriteBar>(), 3);
            recipe.SetResult(ItemID.Starfury, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}