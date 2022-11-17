using AstralVoyage.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Buffs
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class Corrupted : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted");
            Description.SetDefault("Rapidly losing life");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AstralVoyagePlayer>().corrupted = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<AstralVoyageGlobalNPC>().corrupted = true;
        }
    }
}
