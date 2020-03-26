using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;
using System;
using Terraria.ModLoader.IO;
using System.IO;

namespace AstralVoyage
{
    public class AstralVoyageWorld : ModWorld
    {
        public static bool downedEaterOfCosmos; // Bool if this boss has been taken down.
        public static bool downedLivingTree; // Bool if this boss has been taken down.
        public static bool downedEyeOfCosmos; // Bool if this boss has been taken down.
        public static bool downedGuardianOfCosmos; // Bool if this boss has been taken down.
        public static bool downedVoyager;


        public static bool spawnOre = false;

        public override void Initialize()
        {
            downedEaterOfCosmos = false;
            downedLivingTree = false;
            downedEyeOfCosmos = false;
            downedGuardianOfCosmos = false;
            downedVoyager = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedEaterOfCosmos) downed.Add("eoc");
            if (downedGuardianOfCosmos) downed.Add("goc");
            if (downedEyeOfCosmos) downed.Add("eoc2");
            if (downedLivingTree) downed.Add("livtree");
            if (downedVoyager) downed.Add("voyager");

            return new TagCompound
            {
                {"downed", downed }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedEaterOfCosmos = downed.Contains("eoc");
            downedGuardianOfCosmos = downed.Contains("goc");
            downedEyeOfCosmos = downed.Contains("eoc2");
            downedLivingTree = downed.Contains("livtree");
            downedVoyager = downed.Contains("voyager");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedEaterOfCosmos = flags[0];
                downedLivingTree = flags[1];
                downedGuardianOfCosmos = flags[2];
                downedEyeOfCosmos = flags[3];
                downedVoyager = flags[4];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedEaterOfCosmos;
            flags[1] = downedLivingTree;
            flags[2] = downedGuardianOfCosmos;
            flags[3] = downedEyeOfCosmos;
            flags[4] = downedVoyager;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedEaterOfCosmos = flags[0];
            downedLivingTree = flags[1];
            downedGuardianOfCosmos = flags[2];
            downedEyeOfCosmos = flags[3];
            downedVoyager = flags[4];
        }

    }
}