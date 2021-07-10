using AstralVoyage.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage.Buffs
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class WoodSplinters : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wood Splinters");
            Description.SetDefault("Foreign object stuck under your skin");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AstralVoyagePlayer>().woodSplinters = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<AstralVoyageGlobalNPC>().woodSplinters = true;
        }
    }
}
