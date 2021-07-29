using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace AstralVoyage
{
    public abstract class CustomModItem : ModItem
    {
        public int CustomRarity = 0;
        public float lerpValue = 0f;
        public float maxLerpValue = 1f;
        public bool reached;

        //custom name color
        public Color? customNameColor = null;

        bool hitMax = false;

        /*public override void UpdateInventory(Player player)
        {
            if (!hitMax)
            {
                lerpValue = lerpValue * 1.1f;
            }
            else
            {
                lerpValue = lerpValue * 0.9f;
            }

            if (lerpValue >= maxLerpValue)
                hitMax = true;
            else if (lerpValue <= 0.02f)
                hitMax = false;
            base.UpdateInventory(player);
        }*/

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            if (customNameColor != null)
            {
                foreach (TooltipLine line2 in list)
                {
                    if (line2.mod == "Terraria" && line2.Name == "ItemName")
                    {
                        line2.overrideColor = (Color)customNameColor;
                    }
                }
                return;
            }

            if (item.modItem is CustomModItem MyModItem && MyModItem.CustomRarity != 0)
            {
                Color Rare;
                switch (MyModItem.CustomRarity)
                {
                    default: Rare = Color.White; break;
                    case 12: Rare = BaseColor.Turquoise; break;
                    case 13: Rare = BaseColor.PureGreen; break;
                    case 14: Rare = BaseColor.DarkBlue; break;
                    case 15: Rare = BaseColor.Violet; break;
                    case 16: Rare = BaseColor.HotPink; break;
                    case -13: Rare = BaseColor.DarkOrange; break;
                    case -14: Rare = BaseColor.BrightOrange; break;
                    case -15: Rare = BaseColor.DarkRed; break;
                    case 101: Rare = BaseColor.Cosmite[0]; break;
					case 102: Rare = BaseColor.DiTF[0]; break;
                }
                foreach (TooltipLine line2 in list)
                {
                    if (line2.mod == "Terraria" && line2.Name == "ItemName")
                    {
                        line2.overrideColor = Rare;
                    }
                }
            }
        }


    }

    public static class BaseColor
    {
        public static Color Turquoise => new Color(31, 227, 183);
        public static Color PureGreen => new Color(39, 206, 33);
        public static Color DarkBlue => new Color(51, 90, 200);
        public static Color Violet => new Color(63, 37, 112);
        public static Color HotPink => new Color(189, 15, 192);
        public static Color DarkOrange => new Color(187, 74, 39);
        public static Color BrightOrange => new Color(229, 141, 25);
        public static Color DarkRed => new Color(98, 7, 4);
        public static Color[] Cosmite => new Color[] {
            new Color(100, 241, 255),
            new Color(216, 52, 131),
            new Color(44, 100, 255),
            new Color(204, 229, 150)
        };
		public static Color[] DiTF => new Color[] {
            new Color(255, 25, 50),
            new Color(25, 80, 255),
            new Color(255, 25, 50),
            new Color(25, 80, 255)
        };
    }
}
