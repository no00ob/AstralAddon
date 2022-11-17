using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using AstralVoyage.Items.Tiles;
using Terraria.ID;
using AstralVoyage.Projectiles;
using System;
using AstralVoyage.Dusts;

namespace AstralVoyage.Tiles
{
    public class DivineSandBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSand[Type] = true;
            TileID.Sets.TouchDamageSands[Type] = 15;
            TileID.Sets.Conversion.Sand[Type] = true; // Allows Clentaminator solutions to convert this tile to their respective Sand tiles.
            TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true; // Allows Sandshark enemies to "swim" in this sand.
            TileID.Sets.Falling[Type] = true;
            ItemDrop = ModContent.ItemType<DivineSand>();
            AddMapEntry(new Color(239, 246, 228));
            DustType = ModContent.DustType<DivineSandDust>();
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            if (WorldGen.noTileActions)
                return true;

            Tile above = Main.tile[i, j - 1];
            Tile below = Main.tile[i, j + 1];
            bool canFall = true;

            if (below == null || below.HasTile)
                canFall = false;

            if (above.HasTile && (TileID.Sets.BasicChest[above.TileType] || TileID.Sets.BasicChestFake[above.TileType] || above.TileType == TileID.PalmTree || TileLoader.IsDresser(above.TileType)))
                canFall = false;

            if (canFall)
            {
                //Set the projectile type to ExampleSandProjectile
                int projectileType = ModContent.ProjectileType<DivineSandProjectile>();
                float positionX = i * 16 + 8;
                float positionY = j * 16 + 8;

                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.tile[i, j].ClearTile();
                    int proj = Projectile.NewProjectile(positionX, positionY, 0f, 0.41f, projectileType, 10, 0f, Main.myPlayer);
                    Main.projectile[proj].ai[0] = 1f;
                    WorldGen.SquareTileFrame(i, j);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    Main.tile[i, j].HasTile = false;
                    bool spawnProj = true;

                    for (int k = 0; k < 1000; k++)
                    {
                        Projectile otherProj = Main.projectile[k];

                        if (otherProj.active && otherProj.owner == Main.myPlayer && otherProj.type == projectileType && Math.Abs(otherProj.timeLeft - 3600) < 60 && otherProj.Distance(new Vector2(positionX, positionY)) < 4f)
                        {
                            spawnProj = false;
                            break;
                        }
                    }

                    if (spawnProj)
                    {
                        int proj = Projectile.NewProjectile(positionX, positionY, 0f, 2.5f, projectileType, 10, 0f, Main.myPlayer);
                        Main.projectile[proj].velocity.Y = 0.5f;
                        Main.projectile[proj].position.Y += 2f;
                        Main.projectile[proj].netUpdate = true;
                    }

                    NetMessage.SendTileSquare(-1, i, j, 1);
                    WorldGen.SquareTileFrame(i, j);
                }
                return false;
            }
            return true;
        }
    }
}