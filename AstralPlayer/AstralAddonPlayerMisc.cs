using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace AstralAddon.AstralPlayer
{
    public partial class AstralAddonPlayer : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            // Handle minion accessories and prevent them from stacking
            if (modMinions2)
            {
                Player.maxMinions += 3;
            }
            else
            {
                if (modMinions1)
                {
                    Player.maxMinions += 2;
                }
                else if (modMinions0)
                {
                    Player.maxMinions++;
                }
            }
            // Handle damage reduction accessories and prevent them from stacking
            if (damageReduction2)
            {
                Player.endurance = 1f - (0.8f * (1f - Player.endurance));
            }
            else
            {
                if (damageReduction1)
                {
                    Player.endurance = 1f - (0.85f * (1f - Player.endurance));
                }
                else if (damageReduction0)
                {
                    Player.endurance = 1f - (0.9f * (1f - Player.endurance));
                }
            }
            // Handle defense accessories and prevent them from stacking
            if (damageReduction2 && damageReduction1 && damageReduction0)
            {
                Player.statDefense -= 80;
            }
            else
            {
                if (damageReduction2 && damageReduction1)
                {
                    Player.statDefense -= 50;
                }
                else if ((damageReduction2 && damageReduction0) || (damageReduction1 && damageReduction0))
                {
                    Player.statDefense -= 30;
                }
            }
            // Handle damage accessories and prevent them from stacking
            if (modSummonDamage1)
            {
                Player.GetKnockback<SummonDamageClass>() += 1.5f;
                Player.GetDamage<SummonDamageClass>() += 0.12f;
            }
            else if (modSummonDamage0)
            {
                Player.GetKnockback<SummonDamageClass>() += 0.33f;
                Player.GetDamage<SummonDamageClass>() += 0.08f;
            }
        }
    }
}
