using AstralVoyage.Items;
using AstralVoyage.Items.Accessories;
using AstralVoyage.Items.Ores;
using AstralVoyage.Items.Tiles;
using AstralVoyage.NPCs.EoC;
using AstralVoyage.NPCs.LT;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
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
			Properties/* tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled) */ = new ModProperties()
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
                TextureAssets.Tile[TileID.Loom].Value = GetTexture("Tiles/AnimatedLoom");
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

        public override void UpdateMusic(ref int music, ref SceneEffectPriority priority)/* tModPorter Note: Removed. Use ModSceneEffect.Music and .Priority, aswell as ModSceneEffect.IsSceneEffectActive */
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                return;

            if (Main.LocalPlayer.GetModPlayer<AstralVoyagePlayer>().ZoneAncient)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/ancient");
                priority = SceneEffectPriority.Environment;
            }

            if (LivingTree.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/fight3");
                priority = SceneEffectPriority.BossLow;
            }

            if (TheEaterOfCosmos_Head.bossOn == true)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/boss3");
                priority = SceneEffectPriority.BossMedium;
            }
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // To include a description:
                bossChecklist.Call("AddBossWithInfo", "Astrum Vermis", 15.999f, (Func<bool>)(() => AstralVoyageWorld.downedEaterOfCosmos), "Use a [i:" + Find<ModItem>("WormholeCrystal").Type + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Living Tree", 1.001f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + Find<ModItem>("SuspiciousLookingSprout").Type + "] at night in a forest biome.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Bellatur", 15.998f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + Find<ModItem>("BlackholeCrystal").Type + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Astrum Magus", 15.997f, (Func<bool>)(() => AstralVoyageWorld.downedLivingTree), "Use a [i:" + Find<ModItem>("CometCrystal").Type + "] at any given time, any where.");
                bossChecklist.Call("AddBossWithInfo", "Voyager", 17.998f, (Func<bool>)(() => AstralVoyageWorld.downedVoyager), "Use a [i:" + Find<ModItem>("AnomaliousMatter").Type + "] after beating the three cosmic guardians at any given time, any where.");
            }
        }

        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)/* tModPorter Note: Removed. Use ModSystem.ModifySunLightColor */
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

        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
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

        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            Recipe recipe = Recipe.Create(ItemID.MagicQuiver, 1);

            if (!calamityMode)
            {
                // Magic Quiver
                recipe.AddIngredient(ItemID.EndlessQuiver);
                recipe.AddIngredient(ItemID.PixieDust, 10);
                recipe.AddIngredient(ItemID.Lens, 5);
                recipe.AddIngredient(ItemID.SoulofLight, 8);
                recipe.AddTile(TileID.CrystalBall);
                recipe.Register();
                // Guide Voodoo Doll
                recipe = Recipe.Create(ItemID.GuideVoodooDoll, 1);
                recipe.AddIngredient(ItemID.Leather, 2);
                recipe.AddRecipeGroup("AstralVoyage:EvilPowders", 10);
                recipe.AddTile(TileID.DemonAltar);
                recipe.Register();
                // Ice Skates
                recipe = Recipe.Create(ItemID.IceSkates, 1);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.Leather, 5);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.IceMachine);
                recipe.Register();
                // Aglet
                recipe = Recipe.Create(ItemID.Aglet, 1);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Anklet of the Wind
                recipe = Recipe.Create(ItemID.AnkletoftheWind, 1);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.AddIngredient(ItemID.Cloud, 15);
                recipe.AddIngredient(ItemID.PinkGel, 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Bezoar
                recipe = Recipe.Create(ItemID.Bezoar, 1);
                recipe.AddIngredient(ItemID.Stinger, 15);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Blizzard in a Bottle
                recipe = Recipe.Create(ItemID.BlizzardinaBottle, 1);
                recipe.AddIngredient(ItemID.Feather, 4);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.SnowBlock, 50);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Cloud in a Bottle
                recipe = Recipe.Create(ItemID.CloudinaBottle, 1);
                recipe.AddIngredient(ItemID.Feather, 2);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.Cloud, 25);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Feral Claws
                recipe = Recipe.Create(ItemID.FeralClaws, 1);
                recipe.AddIngredient(ItemID.Leather, 10);
                recipe.AddIngredient(ItemID.Vine, 3);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Frog Leg
                recipe = Recipe.Create(ItemID.FrogLeg, 1);
                recipe.AddIngredient(ItemID.Frog, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Lava Charm
                recipe = Recipe.Create(ItemID.LavaCharm, 1);
                recipe.AddIngredient(ItemID.LavaBucket, 5);
                recipe.AddIngredient(ItemID.Obsidian, 25);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Lucky Horseshoe
                recipe = Recipe.Create(ItemID.LuckyHorseshoe, 1);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 10);
                recipe.AddIngredient(ItemID.GoldBar, 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                recipe = Recipe.Create(ItemID.LuckyHorseshoe, 1);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 10);
                recipe.AddIngredient(ItemID.PlatinumBar, 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Obsidian Rose
                recipe = Recipe.Create(ItemID.ObsidianRose, 1);
                recipe.AddIngredient(ItemID.JungleRose, 1);
                recipe.AddIngredient(ItemID.Obsidian, 10);
                recipe.AddIngredient(ItemID.Hellstone, 10);
                recipe.AddTile(TileID.Hellforge);
                recipe.Register();
                // Radar
                recipe = Recipe.Create(ItemID.Radar, 1);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Sandstorm in a Bottle
                recipe = Recipe.Create(ItemID.SandstorminaBottle, 1);
                recipe.AddIngredient(ItemID.Feather, 6);
                recipe.AddIngredient(ItemID.Bottle, 1);
                recipe.AddIngredient(ItemID.SandBlock, 70);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Water Walking Boots
                recipe = Recipe.Create(ItemID.WaterWalkingBoots, 1);
                recipe.AddIngredient(ItemID.WaterWalkingPotion, 8);
                recipe.AddIngredient(ItemID.Leather, 5);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Flower Boots
                recipe = Recipe.Create(ItemID.FlowerBoots, 1);
                recipe.AddIngredient(ItemID.Silk, 7);
                recipe.AddIngredient(ItemID.JungleRose, 1);
                recipe.AddIngredient(ItemID.JungleGrassSeeds, 5);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Hand Warmer
                recipe = Recipe.Create(ItemID.HandWarmer, 1);
                recipe.AddIngredient(ItemID.Silk, 5);
                recipe.AddIngredient(ItemID.Shiverthorn, 1);
                recipe.AddIngredient(ItemID.SnowBlock, 10);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Hermes Boots
                recipe = Recipe.Create(ItemID.HermesBoots, 1);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddIngredient(ItemID.SwiftnessPotion, 8);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Adhesive Bandage
                recipe = Recipe.Create(ItemID.AdhesiveBandage, 1);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddIngredient(ItemID.Gel, 50);
                recipe.AddIngredient(ItemID.GreaterHealingPotion, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Adhesive Bandage
                recipe = Recipe.Create(ItemID.ArmorPolish, 1);
                recipe.AddIngredient(ItemID.Bone, 50);
                recipe.AddIngredient(ItemID.Gel, 25);
                recipe.AddIngredient(ModContent.ItemType<Polish>(), 3);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Blindfold
                recipe = Recipe.Create(ItemID.Blindfold, 1);
                recipe.AddIngredient(ItemID.Silk, 30);
                recipe.AddIngredient(ItemID.SoulofNight, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Celestial Magnet
                recipe = Recipe.Create(ItemID.CelestialMagnet, 1);
                recipe.AddIngredient(ItemID.FallenStar, 20);
                recipe.AddIngredient(ItemID.SoulofMight, 10);
                recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.AddIngredient(ItemID.SoulofNight, 5);
                recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 3);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Cobalt Shield
                recipe = Recipe.Create(ItemID.CobaltShield, 1);
                recipe.AddRecipeGroup("AstralVoyage:CobaltBars", 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Fast Clock
                recipe = Recipe.Create(ItemID.FastClock, 1);
                recipe.AddIngredient(ItemID.Timer1Second, 1);
                recipe.AddIngredient(ItemID.PixieDust, 15);
                recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Flying Carpet
                recipe = Recipe.Create(ItemID.FlyingCarpet, 1);
                recipe.AddIngredient(ItemID.AncientCloth, 10);
                recipe.AddIngredient(ItemID.SoulofNight, 10);
                recipe.AddIngredient(ItemID.SoulofLight, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Frozen Turtle Shell
                recipe = Recipe.Create(ItemID.FrozenTurtleShell, 1);
                recipe.AddIngredient(ItemID.TurtleShell, 3);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 50);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Megaphone
                recipe = Recipe.Create(ItemID.Megaphone, 1);
                recipe.AddIngredient(ItemID.Wire, 10);
                recipe.AddIngredient(ItemID.HallowedBar, 5);
                recipe.AddIngredient(ItemID.Ruby, 3);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Metal Detector
                recipe = Recipe.Create(ItemID.MetalDetector, 1);
                recipe.AddIngredient(ItemID.Wire, 10);
                recipe.AddIngredient(ItemID.GoldDust, 5);
                recipe.AddIngredient(ItemID.SpelunkerGlowstick, 5);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Nazar
                recipe = Recipe.Create(ItemID.Nazar, 1);
                recipe.AddIngredient(ItemID.SoulofNight, 20);
                recipe.AddIngredient(ItemID.Lens, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Trifold Map
                recipe = Recipe.Create(ItemID.TrifoldMap, 1);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddIngredient(ItemID.SoulofLight, 3);
                recipe.AddIngredient(ItemID.SoulofNight, 3);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Vitamins
                recipe = Recipe.Create(ItemID.Vitamins, 1);
                recipe.AddIngredient(ItemID.BottledWater, 1);
                recipe.AddIngredient(ItemID.Waterleaf, 5);
                recipe.AddIngredient(ItemID.Blinkroot, 5);
                recipe.AddIngredient(ItemID.Daybloom, 5);
                recipe.AddIngredient(ModContent.ItemType<ZincOre>(), 3);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Shiny Red Balloon
                recipe = Recipe.Create(ItemID.ShinyRedBalloon, 1);
                recipe.AddIngredient(ItemID.Gel, 80);
                recipe.AddIngredient(ItemID.Cloud, 40);
                recipe.AddIngredient(ItemID.WhiteString, 1);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();
                // Rocket I
                recipe = Recipe.Create(ItemID.RocketI, 20);
                recipe.AddIngredient(ItemID.EmptyBullet, 20);
                recipe.AddIngredient(ItemID.ExplosivePowder, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Eskimo Coat
                recipe = Recipe.Create(ItemID.EskimoCoat, 1);
                recipe.AddIngredient(ItemID.Silk, 8);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 18);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Eskimo Hood
                recipe = Recipe.Create(ItemID.EskimoHood, 1);
                recipe.AddIngredient(ItemID.Silk, 4);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 12);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Eskimo Pants
                recipe = Recipe.Create(ItemID.EskimoPants, 1);
                recipe.AddIngredient(ItemID.Silk, 6);
                recipe.AddIngredient(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.BorealWood, 15);
                recipe.AddTile(TileID.Loom);
                recipe.Register();
                // Truffle Worm
                recipe = Recipe.Create(ItemID.TruffleWorm, 1);
                recipe.AddIngredient(ItemID.Worm, 1);
                recipe.AddIngredient(ItemID.GlowingMushroom, 15);
                recipe.AddTile(TileID.Autohammer);
                recipe.Register();
                // Life Crystal
                recipe = Recipe.Create(ItemID.LifeCrystal, 1);
                recipe.AddIngredient(ItemID.Bone, 5);
                recipe.AddIngredient(ItemID.PinkGel, 1);
                recipe.AddIngredient(ItemID.HealingPotion, 1);
                recipe.AddIngredient(ItemID.Ruby, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Lizhard Power Cell
                recipe = Recipe.Create(ItemID.LihzahrdPowerCell, 1);
                recipe.AddIngredient(ItemID.Glass, 5);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddIngredient(ItemID.LihzahrdBrick, 15);
                recipe.AddTile(TileID.LihzahrdFurnace);
                recipe.Register();
                // Temple Key
                recipe = Recipe.Create(ItemID.TempleKey, 1);
                recipe.AddIngredient(ItemID.JungleSpores, 15);
                recipe.AddIngredient(ItemID.RichMahogany, 15);
                recipe.AddIngredient(ItemID.SoulofNight, 15);
                recipe.AddIngredient(ItemID.SoulofLight, 15);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Black Lens
                recipe = Recipe.Create(ItemID.BlackLens, 1);
                recipe.AddIngredient(ItemID.Lens, 1);
                recipe.AddIngredient(ItemID.BlackDye, 1);
                recipe.AddTile(TileID.DyeVat);
                recipe.Register();
                // Leather
                recipe = Recipe.Create(ItemID.Leather, 1);
                recipe.AddIngredient(ItemID.Vertebrae, 5);
                recipe.AddTile(TileID.WorkBenches);
                recipe.Register();
                // Ice Machine
                recipe = Recipe.Create(ItemID.IceMachine, 1);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 25);
                recipe.AddIngredient(ItemID.SnowBlock, 15);
                recipe.AddRecipeGroup("IronBar", 3);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Sky Mill
                recipe = Recipe.Create(ItemID.SkyMill, 1);
                recipe.AddIngredient(ItemID.SunplateBlock, 10);
                recipe.AddIngredient(ItemID.Cloud, 5);
                recipe.AddIngredient(ItemID.RainCloud, 3);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Glass
                recipe = Recipe.Create(ItemID.Glass, 1);
                recipe.AddIngredient(ModContent.ItemType<DivineSand>(), 2);
                recipe.AddTile(TileID.Furnaces);
                recipe.Register();
                // Bug Net
                recipe = Recipe.Create(ItemID.BugNet, 1);
                recipe.AddRecipeGroup("IronBar", 3);
                recipe.AddIngredient(ItemID.Cobweb, 30);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Ice Mirror
                recipe = Recipe.Create(ItemID.IceMirror, 1);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.Glass, 10);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddRecipeGroup("IronBar", 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Magic Mirror
                recipe = Recipe.Create(ItemID.MagicMirror, 1);
                recipe.AddIngredient(ItemID.Glass, 10);
                recipe.AddIngredient(ItemID.FallenStar, 10);
                recipe.AddRecipeGroup("IronBar", 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Shadow Key
                recipe = Recipe.Create(ItemID.ShadowKey, 1);
                recipe.AddIngredient(ItemID.GoldenKey, 1);
                recipe.AddIngredient(ItemID.Obsidian, 20);
                recipe.AddIngredient(ItemID.Bone, 5);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Rod of Discord
                recipe = Recipe.Create(ItemID.RodofDiscord, 1);
                recipe.AddIngredient(ItemID.SoulofLight, 30);
                recipe.AddIngredient(ItemID.ChaosFish, 5);
                recipe.AddIngredient(ItemID.PixieDust, 50);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Water Bolt
                recipe = Recipe.Create(ItemID.WaterBolt, 1);
                recipe.AddIngredient(ItemID.SpellTome, 1);
                recipe.AddIngredient(ItemID.Waterleaf, 3);
                recipe.AddIngredient(ItemID.WaterCandle, 1);
                recipe.AddTile(TileID.Bookcases);
                recipe.Register();
                // Ice Boomerang
                recipe = Recipe.Create(ItemID.IceBoomerang, 1);
                recipe.AddRecipeGroup("AstralVoyage:IceBlocks", 20);
                recipe.AddIngredient(ItemID.SnowBlock, 10);
                recipe.AddIngredient(ItemID.Shiverthorn, 1);
                recipe.AddTile(TileID.IceMachine);
                recipe.Register();
                // Shuriken
                recipe = Recipe.Create(ItemID.Shuriken, 50);
                recipe.AddRecipeGroup("IronBar", 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Slime Staff
                recipe = Recipe.Create(ItemID.SlimeStaff, 1);
                recipe.AddRecipeGroup("Wood", 6);
                recipe.AddIngredient(ItemID.Gel, 40);
                recipe.AddIngredient(ItemID.PinkGel, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Shuriken
                recipe = Recipe.Create(ItemID.ThrowingKnife, 50);
                recipe.AddRecipeGroup("IronBar", 1);
                recipe.AddRecipeGroup("Wood", 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Wand of Sparkling
                recipe = Recipe.Create(ItemID.WandofSparking, 1);
                recipe.AddRecipeGroup("Wood", 5);
                recipe.AddIngredient(ItemID.Torch, 3);
                recipe.AddIngredient(ItemID.FallenStar, 1);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
                // Enchanted Sword
                recipe = Recipe.Create(ItemID.EnchantedSword, 1);
                recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 5);
                recipe.AddIngredient(ItemID.SoulofLight, 15);
                recipe.AddIngredient(ItemID.UnicornHorn, 3);
                recipe.AddIngredient(ItemID.LightShard, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
                // Muramasa
                recipe = Recipe.Create(ItemID.Muramasa, 1);
                recipe.AddRecipeGroup("AstralVoyage:CobaltBars", 15);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();
            }

            // Avenger Emblem
            recipe = Recipe.Create(ItemID.AvengerEmblem, 1);
            recipe.AddIngredient(ModContent.ItemType<ThrowerEmblem>(), 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            // Frost Breastplate
            recipe = Recipe.Create(ItemID.FrostBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 10);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.Register();
            // Frost Helmet
            recipe = Recipe.Create(ItemID.FrostHelmet, 1);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 6);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.Register();
            // Frost Leggings
            recipe = Recipe.Create(ItemID.FrostLeggings, 1);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 8);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.IceMachine);
            recipe.Register();
            // Starfury
            recipe = Recipe.Create(ItemID.Starfury, 1);
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<WoodriteBar>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Starfury, 1);
            recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<WoodriteBar>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}